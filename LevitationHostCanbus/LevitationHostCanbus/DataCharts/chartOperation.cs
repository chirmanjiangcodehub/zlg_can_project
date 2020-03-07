using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace LevitationHostCanbus
{
    public delegate void AddDataDelegate();
    public delegate void AddDataDelegateArray(int ind, int cnt);

    public delegate void DelSetChartsParams(ChartSetting Settings);

    class chartOperation
    {
        // threads
        public Thread addDataRunner;
        public Thread[] addDataRunnerArray = new Thread[32];
        private Random rand = new Random();
        public AddDataDelegate addDataDel;
        public AddDataDelegateArray[] addDataDelArray = new AddDataDelegateArray[32];
        private bool multi_thread;
        private ManualResetEvent threadCtrl = new ManualResetEvent(false);

        public Chart[] chart = new Chart[32];
        public Series[] series = new Series[255];
        public ChartArea[] chartAreaArray = new ChartArea[255];
        public ChartSetting chartSettings = new ChartSetting();

        public int addElementsCnt;  // times of add Series and ChartArea
        public int addChartCnt;  // num of charts in UI
        public int current_chart_ind;
        public int current_area_ind;

        public int mouse_select_chart;

        private int chart_update_interval;
        private int add_num_amount;

        public bool multiThread
        {
            get { return multi_thread; }
        }
        public chartOperation()
        {
            // set the multi thread on/off
            multi_thread = true;

            addElementsCnt = 0;
            addChartCnt = 0;
            current_chart_ind = 0;
            current_area_ind = 0;

            mouse_select_chart = 0;

            chart_update_interval = 1000;  // unit: ms
            add_num_amount = 10;

            if (!multi_thread)
            {
                // create the Adding Data Thread but do not start until start button clicked
                //ThreadStart addDataThreadStart = new ThreadStart(AddDataThreadLoop);
                //addDataRunner = new Thread(addDataThreadStart);

                addDataRunner = new Thread(() => AddDataThreadLoop());

                // create a delegate for adding data
                addDataDel += new AddDataDelegate(AddData);
            }
        }

        /// <summary>
        /// setup thread for everyone chart, and setup the delegate for everyone chart
        /// </summary>
        /// <param name="ind"></param>
        private void setupChartThread(int ind)
        {
            if (multi_thread)
            {
                int i_local = ind;
                addDataRunnerArray[i_local] = new Thread(() => AddDataThreadLoop(i_local));
                addDataRunnerArray[i_local].Name = "thread_" + chart[i_local].Name;

                // create a delegate for adding data
                //addDataDel += new AddDataDelegate(AddData);
                addDataDelArray[i_local] += new AddDataDelegateArray(AddData);
            }
            else
            {
                if(addDataRunner.Name == null)
                    addDataRunner.Name = "SingleThreadForChart";
            }
        }

        private void AddDataThreadLoop()
        {
            while (true)
            {
                chart[0].BeginInvoke(addDataDel);

                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// thread loop, threadloop time inteval can be set by user!
        /// multi thread
        /// </summary>
        /// <param name="ind"></param>
        private void AddDataThreadLoop(int ind)
        {
            int i = ind;
            int add_data_times_cnt = 0;

            while (true)
            {
                
                chart[i].BeginInvoke(addDataDelArray[i], i, add_data_times_cnt);
                if (add_data_times_cnt < 10)
                    add_data_times_cnt += 1;
                else
                    add_data_times_cnt = 0;

                Thread.Sleep(this.chart_update_interval);
            }
        }

        /// <summary>
        /// AddData for single thread situation
        /// </summary>
        public void AddData()
        {
            DateTime timeStamp = DateTime.Now;

            for (int i = 0; i < addChartCnt; i++)
            {
                if (chart[i].Series.Count != 0)
                {
                    foreach (Series ptSeries in chart[i].Series)
                    {
                        //AddNewPoint(timeStamp, ptSeries, i, 0, 0);
                    }
                }
            }
        }

        /// <summary>
        /// add data for thread array (multi thread)
        /// </summary>
        /// <param name="ind"></param>
        public void AddData(int ind, int add_data_times_cnt)
        {
            DateTime timeStamp = DateTime.Now;
            int i = ind;

            if (chart[i].Series.Count != 0)
            {
                int area_ind = 0;
                foreach (Series ptSeries in chart[i].Series)
                {
                    if (mainform.canDataRWLock.TryEnterReadLock(this.chart_update_interval))
                    {
                        try
                        {
                            timeStamp = DateTime.Now;
                            AddNewPoint(timeStamp, ptSeries, i, area_ind, add_data_times_cnt);

                            if (area_ind < chart[i].Series.Count)
                                area_ind += 1;
                            else
                                area_ind = 0;
                        }
                        finally
                        {
                            mainform.canDataRWLock.ExitReadLock();
                        }
                    }
                    else
                    {
                        if (area_ind < chart[i].Series.Count)
                            area_ind += 1;
                        else
                            area_ind = 0;

                        continue;
                    }
                }
            }
        }

        /// The AddNewPoint function is called for each series in the chart when
        /// new points need to be added.  The new point will be placed at specified
        /// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
        /// data point's Y value, and not smaller than zero.
        public void AddNewPoint(DateTime timeStamp, Series ptSeries, int chart_ind, int area_ind, int add_data_times_cnt)
        {
            int time_length = 120;  // unit: seconds
            double[] data = new double[2];
            double[] data_value;
            int cnt = chart[chart_ind].ChartAreas.Count;
            ChartLineDataInfo lineDataInfo = new ChartLineDataInfo();
            ChartLineDataInfo lineData = new ChartLineDataInfo();
            DateTime time_tmp = DateTime.Now;

            for (int i = 0; i < 1; i++)
            {
                // including point_id and the date type(s0, s1, etc..)
                //string[] name_str = chart[chart_ind].Titles[area_ind].Text.Split('-');  // 1-S0, 5-S1 6-U1 etc.

                lineDataInfo.setDataInfo(chart[chart_ind].Titles[area_ind].Text);
                int buff_cnt = 0;
                
                double time_offset;
                double data_time_interval = this.chart_update_interval / this.add_num_amount;

                

                int tail = mainform.monitorData[lineDataInfo.DataName, lineDataInfo.DataPointID].tail;
                int head = mainform.monitorData[lineDataInfo.DataName, lineDataInfo.DataPointID].head;

                data_value = getDataBuffFromTail(lineDataInfo.DataName, lineDataInfo.DataPointID, add_num_amount);

                while (mainform.monitorData.tail != mainform.monitorData.head && buff_cnt < add_num_amount)
                {
                    //lineDataInfo.getDataInfo(chart[chart_ind].Titles[area_ind].Text);

                    //if (lineDataInfo.DataName != "")
                    {
                        
                        /*
                        // get data from buff
                        if (buff_cnt == 0)
                            mainform.monitorData[lineDataInfo.DataName, lineDataInfo.DataPointID].tail = mainform.monitorData[lineDataInfo.DataName, lineDataInfo.DataPointID].head - add_num_amount;
                        
                        lineData = getDataBuffFromTail(lineDataInfo.DataName, lineDataInfo.DataPointID);

                        time_offset = (double)(-data_time_interval) * (add_num_amount - buff_cnt - 1);  // ms
                        time_tmp = timeStamp.AddMilliseconds(time_offset);
                        ptSeries.Points.AddXY(time_tmp.ToOADate(), lineData.YValueDataValue);
                        */

                        
                        time_offset = (double)(-data_time_interval) * (add_num_amount - buff_cnt - 1);  // ms
                        time_tmp = timeStamp.AddMilliseconds(time_offset);
                        ptSeries.Points.AddXY(time_tmp.ToOADate(), data_value[buff_cnt]);
                        

                        /*
                        lineData.YValueDataValue = mainform.monitorData.getDecodedValue(lineDataInfo.DataName, lineDataInfo.DataPointID);
                        ptSeries.Points.AddXY(timeStamp.ToOADate(), lineData.YValueDataValue);
                        */

                        mainform.monitorData.tail += 1;
                        buff_cnt += 1;
                    }
                }


                // Add new data point to its series.
                //ptSeries.Points.AddXY(timeStamp.ToOADate(), rand.Next(5, 20));
                //ptSeries.Points.AddXY(mainform.DateTimeStamp.AddMilliseconds(data[1]).ToOADate(), data[0]);

                if (add_data_times_cnt >= 0)
                {
                    // remove all points from the source series older than 1.5 minutes.
                    double removeBefore = timeStamp.AddSeconds((double)(time_length) * (-1.2)).ToOADate();
                    //remove oldest values to maintain a constant number of data points
                    if (ptSeries.Points.Count > 0)
                    {
                        while (ptSeries.Points[0].XValue < removeBefore)
                        {
                            if (ptSeries.Points.Count > 1)
                                ptSeries.Points.RemoveAt(0);
                            else
                                break;

                        }
                    }

                    //chart[ind].ChartAreas[i].AxisX.Minimum = ptSeries.Points[0].XValue;
                    //chart[ind].ChartAreas[i].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddSeconds((double)time_length).ToOADate();
                    chart[chart_ind].ChartAreas[area_ind].AxisX.Minimum = timeStamp.AddSeconds((double)(time_length) * (-1)).ToOADate();
                    chart[chart_ind].ChartAreas[area_ind].AxisX.Maximum = timeStamp.ToOADate();

                    //chart[chart_ind].Invalidate();
                }

            }
            
            // redraw chart[i]
            //chart[chart_ind].Invalidate();
            
        }

        /// <summary>
        /// read the data buff and timestamp buff start from buff tail
        /// 
        /// </summary>
        /// <param name="data_name"></param>
        /// <param name="point_id"></param>
        /// <returns></returns>
        private ChartLineDataInfo getDataBuffFromTail(string data_name, int point_id)
        {
            ChartLineDataInfo info = new ChartLineDataInfo();

                info = mainform.monitorData[data_name, point_id].readDecodedValueBuff(1);
                return info;

        }

        private double[] getDataBuffFromTail(string data_name, int point_id, int len)
        {
            double[] data;

            data = mainform.monitorData[data_name, point_id].readDecodedValueBuff(0, len);
            return data;


        }
        

        /// <summary>
        ///  setup Chart, such background color, name and so on...
        ///  and then add chart to UI
        /// </summary>
        public void setupChart()
        {
            // instantiate chart
            chart[addChartCnt] = new Chart();
            chart[addChartCnt].Name = "chart-" + Convert.ToString(this.addChartCnt);
            chart[addChartCnt].MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDoubleClick);
            chart[addChartCnt].MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            chart[addChartCnt].Series.Clear();
            chart[addChartCnt].ChartAreas.Clear();
            //chart[addChartCnt].Location = new Point(129, 85);
            //chart[addChartCnt].Name = "chart" + Convert.ToString(addChartCnt);
            // Set Back Color
            chart[addChartCnt].BackColor = Color.AliceBlue;
            chart[addChartCnt].BackSecondaryColor = Color.WhiteSmoke;
            // Set Gradient Type
            chart[addChartCnt].BackGradientStyle = GradientStyle.TopBottom;

            // Set Border Skin
            chart[addChartCnt].BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart[addChartCnt].BorderSkin.PageColor = Color.WhiteSmoke;
            // Set Border Color
            chart[addChartCnt].BorderSkin.BorderColor = Color.Black;

            // setup chart thread for every chart
            setupChartThread(addChartCnt);
            
            
            setSelectedChart(current_chart_ind);
            
            if(addChartCnt < 32)
            {
                this.addChartCnt++;
                this.current_chart_ind = this.addChartCnt;

                this.addElementsCnt = 0;
                this.current_area_ind = 0;
            }

            
        }

        public void chart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string chart_name = ((Chart)sender).Name;

            //string[] name_str = chart[ind].Titles[i].Text.Split('-');
            string[] chart_name = ((Chart)sender).Name.Split('-');
            int chart_ind = Convert.ToInt32(chart_name[1]);

            HitTestResult result = chart[chart_ind].HitTest(e.X, e.Y);

            if (result.ChartElementType != ChartElementType.Nothing && result.ChartElementType != ChartElementType.Title)
            {
                string elementType = result.ChartElementType.ToString();
                elementType = result.ChartArea.Name;

                // get the chart setting by the sub form
                this.chartSettings.ChartInd = chart_ind;
                this.chartSettings.hitTestResult = result;
                DelSetChartsParams DelSetChartsParams_ = new DelSetChartsParams(SetChartsParams);
                SetCharts ChartSettingsForm = new SetCharts(DelSetChartsParams_, chartSettings);
                ChartSettingsForm.ShowDialog();
            }
        }

        public void chart_MouseDown(object sender, MouseEventArgs e)
        {
            string[] chart_name = ((Chart)sender).Name.Split('-');
            int chart_ind = Convert.ToInt32(chart_name[1]);

            /*
            if( this.mouse_select_chart > 0)
                this.chart[this.mouse_select_chart - 1].BorderSkin.PageColor = Color.WhiteSmoke;
            this.current_chart_ind = chart_ind + 1;

            this.chart[this.current_chart_ind - 1].BorderSkin.PageColor = Color.Silver;

            this.mouse_select_chart = this.current_chart_ind;

            this.current_area_ind = ((Chart)sender).ChartAreas.Count;
             * */
            setSelectedChart(chart_ind);
        }

        private void setSelectedChart(int chart_ind)
        {
            if (this.mouse_select_chart > 0)
                this.chart[this.mouse_select_chart - 1].BorderSkin.PageColor = Color.WhiteSmoke;
            this.current_chart_ind = chart_ind + 1;

            this.chart[this.current_chart_ind - 1].BorderSkin.PageColor = Color.Silver;

            this.mouse_select_chart = this.current_chart_ind;

            this.current_area_ind = chart[chart_ind].ChartAreas.Count;

        }

        /// <summary>
        /// setup series and chart area, such name, axisX, background color etc...
        /// add series and ChartArea to chart
        /// </summary>
        public int setupElements(string chart_area_name)
        {
            if (this.addChartCnt == 0)
                setupChart();

            // instantiate series and chart area
            series[addElementsCnt] = new Series();
            chartAreaArray[addElementsCnt] = new ChartArea();

            chartAreaArray[addElementsCnt].Name = "ChartArea." + chart_area_name;
            for (int i = 0; i < addElementsCnt; i++)
            {
                if (chartAreaArray[i].Name == ("ChartArea." + chart_area_name))
                    return -1;

            }
            chartAreaArray[addElementsCnt].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chartAreaArray[addElementsCnt].AxisX.Interval = 10;
            chartAreaArray[addElementsCnt].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartAreaArray[addElementsCnt].AxisX.IsMarginVisible = false;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.Enabled = true;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Seconds;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.Interval = 1;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.LineColor = Color.Silver;

            chartAreaArray[addElementsCnt].AxisY.MajorTickMark.Size = 1;
            chartAreaArray[addElementsCnt].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.InsideArea;
            chartAreaArray[addElementsCnt].AxisY.MinorGrid.Enabled = true;
            chartAreaArray[addElementsCnt].AxisY.MinorGrid.LineColor = Color.Silver;
           
            // Set Back Color
            chartAreaArray[addElementsCnt].BackColor = Color.AliceBlue;
            // Set Back Gradient End Color
            chartAreaArray[addElementsCnt].BackSecondaryColor = Color.WhiteSmoke;
            // Set Gradient Type
            chartAreaArray[addElementsCnt].BackGradientStyle = GradientStyle.TopBottom;
            // Set Border Color
            chartAreaArray[addElementsCnt].BorderColor = Color.Black;
            // Set Border Style
            chartAreaArray[addElementsCnt].BorderDashStyle = ChartDashStyle.Solid;

            chartAreaArray[addElementsCnt].AxisX.MaximumAutoSize = 10;

            if (addElementsCnt != 0)
            {
                chartAreaArray[addElementsCnt].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                //chartAreaArray[addElementsCnt].AlignWithChartArea = chartAreaArray[addElementsCnt - 1].Name;
            }

            chart[addChartCnt-1].ChartAreas.Add(chartAreaArray[addElementsCnt]);

            series[addElementsCnt].Name = "Series" + Convert.ToString(addElementsCnt);
            series[addElementsCnt].Color = Color.Red;
            series[addElementsCnt].BorderWidth = 5;
            series[addElementsCnt].IsVisibleInLegend = false;
            series[addElementsCnt].IsXValueIndexed = false;
            series[addElementsCnt].ChartType = SeriesChartType.Line;
            series[addElementsCnt].ChartArea = chartAreaArray[addElementsCnt].Name;  // set series belong to chart area
            series[addElementsCnt].XValueType = ChartValueType.DateTime;

            
            // Predefine the viewing area of the chart
            DateTime maxValue = DateTime.Now;
            DateTime minValue = maxValue.AddSeconds((double) (10) * (-1));

            chart[addChartCnt - 1].ChartAreas[addElementsCnt].AxisX.Minimum = minValue.ToOADate();
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].AxisX.Maximum = maxValue.ToOADate();
            //chart[addChartCnt - 1].Titles.Add("area" + Convert.ToString(addElementsCnt));  chart_area_name
            //chart[addChartCnt - 1].ChartAreas[addElementsCnt].Name = chart_area_name;
            chart[addChartCnt - 1].Titles.Add(chart_area_name);
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].Tag = chart_area_name;
            chart[addChartCnt - 1].Titles[addElementsCnt].DockedToChartArea = chart[addChartCnt - 1].ChartAreas[addElementsCnt].Name;
            chart[addChartCnt - 1].Series.Add(series[addElementsCnt]);

            
            // adjust chart area position and size
            int chart_area_cnt = chart[addChartCnt - 1].ChartAreas.Count;
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].Position.Auto = false;
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].InnerPlotPosition.Auto = false;
            for (int i = 0; i < chart_area_cnt; i++)
            {
                float height = 100.0f / (float)chart_area_cnt;
                chart[addChartCnt - 1].ChartAreas[i].Position.Width = 98.0f;
                chart[addChartCnt - 1].ChartAreas[i].Position.Height = height;
                chart[addChartCnt - 1].ChartAreas[i].Position.X = 0.0f;
                chart[addChartCnt - 1].ChartAreas[i].Position.Y = (float) i * (height);

                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Width = 92.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Height = 78.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.X = 6.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Y = 8.0f;
            }
            

            /*
            for (int i = 0; i < 10; i++)
            {
                series[addElementsCnt].Points.AddXY(i, i * 2 + addElementsCnt * 50);
            }
            */
            if (addElementsCnt < 255)
                addElementsCnt++;
            current_area_ind = addElementsCnt;

            // multi thread true/false ?
            if (multi_thread)
                startAddData2ChartThread(addChartCnt - 1);
            else
                startAddData2Chart();

            return 0;
        }

        public int setupElements(string chart_area_name, int current_chart_ind, int current_area_ind)
        {
            if (this.addChartCnt == 0)
                setupChart();

            int addChartCnt = current_chart_ind;
            int addElementsCnt = current_area_ind;

            // instantiate series and chart area
            series[addElementsCnt] = new Series();
            chartAreaArray[addElementsCnt] = new ChartArea();

            chartAreaArray[addElementsCnt].Name = "ChartArea." + chart_area_name;
            for (int i = 0; i < addElementsCnt; i++)
            {
                if (chartAreaArray[i].Name == ("ChartArea." + chart_area_name))
                    return -1;

            }

            chartAreaArray[addElementsCnt].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chartAreaArray[addElementsCnt].AxisX.Interval = 10;
            chartAreaArray[addElementsCnt].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartAreaArray[addElementsCnt].AxisX.IsMarginVisible = false;
            chartAreaArray[addElementsCnt].AxisX.MajorGrid.LineColor = Color.DarkGray;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.Enabled = true;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Seconds;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.Interval = 1;
            chartAreaArray[addElementsCnt].AxisX.MinorGrid.LineColor = Color.Gainsboro;

            chartAreaArray[addElementsCnt].AxisY.MajorTickMark.Size = 1;
            chartAreaArray[addElementsCnt].AxisY.MajorGrid.LineColor = Color.DarkGray;
            chartAreaArray[addElementsCnt].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.InsideArea;
            chartAreaArray[addElementsCnt].AxisY.MinorGrid.Enabled = false;
            chartAreaArray[addElementsCnt].AxisY.MinorGrid.LineColor = Color.Gainsboro;

            // Set Back Color
            chartAreaArray[addElementsCnt].BackColor = Color.AliceBlue;
            // Set Back Gradient End Color
            chartAreaArray[addElementsCnt].BackSecondaryColor = Color.WhiteSmoke;
            // Set Gradient Type
            chartAreaArray[addElementsCnt].BackGradientStyle = GradientStyle.TopBottom;
            // Set Border Color
            chartAreaArray[addElementsCnt].BorderColor = Color.Black;
            // Set Border Style
            chartAreaArray[addElementsCnt].BorderDashStyle = ChartDashStyle.Solid;

            chartAreaArray[addElementsCnt].AxisX.MaximumAutoSize = 10;

            if (addElementsCnt != 0)
            {
                chartAreaArray[addElementsCnt].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                //chartAreaArray[addElementsCnt].AlignWithChartArea = chartAreaArray[addElementsCnt - 1].Name;
            }

            chart[addChartCnt - 1].ChartAreas.Add(chartAreaArray[addElementsCnt]);

            series[addElementsCnt].Name = "Series" + Convert.ToString(addElementsCnt);
            series[addElementsCnt].Color = Color.Red;
            series[addElementsCnt].BorderColor = Color.Red;
            series[addElementsCnt].BorderWidth = 1;
            series[addElementsCnt].IsVisibleInLegend = false;
            series[addElementsCnt].IsXValueIndexed = false;
            series[addElementsCnt].ChartType = SeriesChartType.Line;
            series[addElementsCnt].ChartArea = chartAreaArray[addElementsCnt].Name;  // set series belong to chart area
            series[addElementsCnt].XValueType = ChartValueType.DateTime;


            // Predefine the viewing area of the chart
            DateTime maxValue = DateTime.Now;
            DateTime minValue = maxValue.AddSeconds((double)(10) * (-1));

            chart[addChartCnt - 1].ChartAreas[addElementsCnt].AxisX.Minimum = minValue.ToOADate();
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].AxisX.Maximum = maxValue.ToOADate();
            //chart[addChartCnt - 1].Titles.Add("area" + Convert.ToString(addElementsCnt));  chart_area_name
            //chart[addChartCnt - 1].ChartAreas[addElementsCnt].Name = chart_area_name;
            chart[addChartCnt - 1].Titles.Add(chart_area_name);
            chart[addChartCnt - 1].Titles[addElementsCnt].DockedToChartArea = chart[addChartCnt - 1].ChartAreas[addElementsCnt].Name;
            chart[addChartCnt - 1].Series.Add(series[addElementsCnt]);


            // adjust chart area position and size
            int chart_area_cnt = chart[addChartCnt - 1].ChartAreas.Count;
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].Position.Auto = false;
            chart[addChartCnt - 1].ChartAreas[addElementsCnt].InnerPlotPosition.Auto = false;
            for (int i = 0; i < chart_area_cnt; i++)
            {
                float height = 100.0f / (float)chart_area_cnt;
                chart[addChartCnt - 1].ChartAreas[i].Position.Width = 98.0f;
                chart[addChartCnt - 1].ChartAreas[i].Position.Height = height;
                chart[addChartCnt - 1].ChartAreas[i].Position.X = 0.0f;
                chart[addChartCnt - 1].ChartAreas[i].Position.Y = (float)i * (height);

                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Width = 92.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Height = 78.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.X = 6.0f;
                chart[addChartCnt - 1].ChartAreas[i].InnerPlotPosition.Y = 8.0f;
            }


            /*
            for (int i = 0; i < 10; i++)
            {
                series[addElementsCnt].Points.AddXY(i, i * 2 + addElementsCnt * 50);
            }
            */
            if (addElementsCnt < 255)
                addElementsCnt++;
            this.current_area_ind = addElementsCnt;

            // multi thread true/false ?
            if (multi_thread)
                startAddData2ChartThread(addChartCnt - 1);
            else
                startAddData2Chart();

            return 0;
        }
        
        /// <summary>
        /// startThread to add data for chart, this method suits for just one thread,
        /// which controls the refresh of all charts on the UI
        /// </summary>
        public void startAddData2Chart()
        {
            // start worker threads.
            if ( addDataRunner.IsAlive == true )
            {
                //addDataRunner.Resume();
            }
            else
            {
                addDataRunner.Start();
            }
        }

        /// <summary>
        /// startThread to add data for chart, this method suits for thread array,
        /// which control the refresh of all charts on the UI, but one thread vs one chart,
        /// that means every chart owns their thread
        /// </summary>
        /// <param name="ind"></param>
        private void startAddData2ChartThread(int ind)
        {
            // start worker threads.
            if (addDataRunnerArray[ind].IsAlive == true)
            {
                //addDataRunner.Resume();
            }
            else
            {
                addDataRunnerArray[ind].Start();
            }
        }


        public void SetChartsParams(ChartSetting Settings)
        {
            chart[Settings.ChartInd].ChartAreas[Settings.hitTestResult.ChartArea.Name].AxisY.Maximum = Settings.YMax;
            chart[Settings.ChartInd].ChartAreas[Settings.hitTestResult.ChartArea.Name].AxisY.Minimum = Settings.YMin;

        }
    }

    public class ChartLineDataInfo
    {
        private double time_stamp;
        private double data_value;

        private int point_id;
        private int chart_ind;

        private string area_name;
        private string data_name;


        public ChartLineDataInfo()
        {
            this.time_stamp = 0.0;
            this.data_value = 0.0;
        }

        public ChartLineDataInfo(double time_stamp_, double data_value_)
        {
            this.time_stamp = time_stamp_;
            this.data_value = data_value_;

        }

        public void setDataInfo(string area_title)
        {
            string[] str = area_title.Split('-');  // levtation_point-data_name, 1-s0, 2-s0. etc.

            if (str.Length > 1)
            {
                this.point_id = Convert.ToInt32(str[0]);
                this.data_name = str[1];
            }
            else
            {
                this.point_id = 0;
                this.data_name = "";
            }

        }

        public int DataPointID
        {
            get { return point_id; }
        }

        public string DataName
        {
            get { return data_name; }
        }
       

        public double XValueTimeStamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        public double YValueDataValue
        {
            get { return data_value; }
            set { data_value = value; }
        }
    }
}
