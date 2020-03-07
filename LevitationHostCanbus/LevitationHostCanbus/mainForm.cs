using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECAN;
using System.IO;
using ECanTest;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace LevitationHostCanbus
{
    public delegate void addLbxDel(CAN_OBJ canobj);
    public delegate void addChartDel(Chart chartobj);

    public delegate DiagnosticData DelDiagnosticData_(int point_id);

    public partial class mainform : Form
    {
        byte m_Baudrate = (byte)7;
        byte m_Baudrate2 = (byte)7;

        byte m_connect = 0;
        bool can_device_open;
                
        // dataGridView column header
        public static string[] DataColumnHeaderStr;

        // charts add
        static chartOperation dataChart = new chartOperation();
        public static Panel[] chart_panel = new Panel[32];
        public AddDataToBuff addData2Buff = new AddDataToBuff();

        //ComProc mCan = new ComProc(addInfoDel);
        ComProc mCan = new ComProc();

        CAN_OBJ gCanobj = new CAN_OBJ();
        public static DateTime DateTimeStamp = new DateTime();  // this is the time base of the charts

        // ctrlUI global vars
        CmdData ctrlCmdData = new CmdData();
        public static MonitorData monitorData = new MonitorData();

        // multi thread sysn
        SemaphoreSlim canDataSemaphore = new SemaphoreSlim(5);
        public static ReaderWriterLockSlim canDataRWLock = new ReaderWriterLockSlim();

        // multi thread
        Thread ThreadUpdateTable;
        Thread ThreadGetCanDataBuff;

        // get diagnostic info 
        DiagnosticData diagInfoData = new DiagnosticData();


        public mainform()
        {
            InitializeComponent();

            // set size of splitter distance
            int form_width = this.splitContainer2.Width - this.splitContainer2.SplitterWidth;
            splitContainer2.SplitterDistance = form_width / 2;

            // init dataGridView1 and dataGridView2
            initDataGridView();

            //splitContainer1.SplitterDistance = dataGridView1.Size.Height + 22*0;

            // init can-port select
            this.cmbCanPorts.SelectedIndex = 0;

            setupMonitorCtrlUI();
            //setupPanelChart();

            // thread
            ThreadUpdateTable = new Thread(() => ThreadLoopUpdateTable());
            ThreadGetCanDataBuff = new Thread(() => ThreadLoopGetCanDataBuff());

            this.can_device_open = false;
            
        }

        // setup panel for every chart, 1 chart match 1 panel
        private void setupPanelChart()
        {
            for(int i = 0; i < 32; i++)
            {
                mainform.chart_panel[i] = new Panel();
                mainform.chart_panel[i].Name = "chart_panel" + Convert.ToString(i);
                //mainform.chart_panel[i].Dock = DockStyle.Fill;
                mainform.chart_panel[i].Parent = this.splitContainer1.Panel2;
            }
            
        }

        private void setupPanelChart(int ind)
        {

            mainform.chart_panel[ind] = new Panel();
            mainform.chart_panel[ind].Name = "chart_panel" + Convert.ToString(ind);
            //mainform.chart_panel[ind].Dock = DockStyle.Fill;
            mainform.chart_panel[ind].Parent = this.splitContainer1.Panel2;


        }


        private void initDataGridView()
        {
            DataColumnHeaderStr = new string[this.dataGridView1.Columns.Count];
            int i;
            for (i = 0; i < 10; i++)
            {
                this.dataGridView1.Rows.Add();
                int tmp = i * 2 + 1;
                this.dataGridView1.Rows[i].HeaderCell.Value = Convert.ToString(tmp);
                int ind;
                

                for (ind = 0; ind < dataGridView1.ColumnCount; ind++)
                {
                    this.dataGridView1.Columns[ind].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridView1.Rows[i].Cells[ind].Value = Convert.ToString(tmp * 10 * 0);// +Convert.ToString(ind * 0);
                    //this.dataGridView1.Rows[i].Cells[ind].Value = tmp * 10 + ind;
                }

                this.dataGridView2.Rows.Add();
                tmp += 1;
                this.dataGridView2.Rows[i].HeaderCell.Value = Convert.ToString(tmp);
                for (ind = 0; ind < dataGridView2.ColumnCount; ind++)
                {
                    this.dataGridView2.Columns[ind].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridView2.Rows[i].Cells[ind].Value = Convert.ToString(tmp * 10*0) + Convert.ToString(ind*0);
                }

            }

            int height = 22;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = height;
                dataGridView2.Rows[i].Height = height;

                DataColumnHeaderStr[i] = this.dataGridView1.Columns[i].HeaderText;
            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;

        }

        private void mainform_Load(object sender, EventArgs e)
        {
            this.can_device_open = false;
        }

        /// <summary>
        /// add dataGridView cell data to chart by double click cell.
        /// </summary>
        private void dataCellAddChart(string chart_area_name)
        {
            //textBox1.Text = this.dataGridView1.CurrentCell.Value.ToString();

            // add chart to ui
            //addChart2From();
            // if chart do not exist, creat it.
            if (dataChart.addChartCnt == 0 && this.can_device_open)
                addChart2UI();

            // creat series and chart area, meanwhile set the default sets.
            //dataChart.setupElements(chart_area_name);
            int ret = dataChart.setupElements(chart_area_name, dataChart.current_chart_ind, dataChart.current_area_ind);
            if (ret == -1)
                MessageBox.Show("This data chart has already been added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region canOpenCloseMethod
        /// <summary>
        /// open and close can device, baud is 500kbps
        /// </summary>
        private void canOpenClose()
        {
            if (m_connect == 1)
            {
                m_connect = 0;
                this.mCan.EnableProc = false;
                this.mCan.EnableProc2 = false;

                this.can_device_open = false;
                ECANDLL.CloseDevice(1, 0);
                btnInit.Text = "打开CAN";

                this.can_device_open = false;
                this.stopAllThread();

                /*
                btnReset.Enabled = false;
                btnWrite.Enabled = false;
                btnSendFile.Enabled = false;
                checkBoxCan1.Enabled = true;
                checkBoxCan2.Enabled = true;
                */
                return;
            }

            INIT_CONFIG init_config = new INIT_CONFIG();

            init_config.AccCode = 0;
            init_config.AccMask = 0xffffff;
            init_config.Filter = 0;

            switch (m_Baudrate)
            {
                case 0: //1000

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x14;
                    break;
                case 1: //800

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x16;
                    break;
                case 2: //666

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xb6;
                    break;
                case 3: //500

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x1c;
                    break;
                case 4://400

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xfa;
                    break;
                case 5://250

                    init_config.Timing0 = 0x01;
                    init_config.Timing1 = 0x1c;
                    break;
                case 6://200

                    init_config.Timing0 = 0x81;
                    init_config.Timing1 = 0xfa;
                    break;
                case 7://125

                    init_config.Timing0 = 0x03;
                    init_config.Timing1 = 0x1c;
                    break;
                case 8://100

                    init_config.Timing0 = 0x04;
                    init_config.Timing1 = 0x1c;
                    break;
                case 9://80

                    init_config.Timing0 = 0x83;
                    init_config.Timing1 = 0xff;
                    break;
                case 10://50

                    init_config.Timing0 = 0x09;
                    init_config.Timing1 = 0x1c;
                    break;

            }

            init_config.Mode = 0;


            if (ECANDLL.OpenDevice(1, 0, 0) != ECAN.ECANStatus.STATUS_OK)
            {

                MessageBox.Show("Open device fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            //Set can1 baud
            if (ECANDLL.InitCAN(1, 0, 0, ref init_config) != ECAN.ECANStatus.STATUS_OK)
            {

                MessageBox.Show("Init can fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ECANDLL.CloseDevice(1, 0);
                return;
            }


            //set can2 baud

            switch (m_Baudrate2)
            {
                case 0: //1000

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x14;
                    break;
                case 1: //800

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x16;
                    break;
                case 2: //666

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xb6;
                    break;
                case 3: //500

                    init_config.Timing0 = 0;
                    init_config.Timing1 = 0x1c;
                    break;
                case 4://400

                    init_config.Timing0 = 0x80;
                    init_config.Timing1 = 0xfa;
                    break;
                case 5://250

                    init_config.Timing0 = 0x01;
                    init_config.Timing1 = 0x1c;
                    break;
                case 6://200

                    init_config.Timing0 = 0x81;
                    init_config.Timing1 = 0xfa;
                    break;
                case 7://125

                    init_config.Timing0 = 0x03;
                    init_config.Timing1 = 0x1c;
                    break;
                case 8://100

                    init_config.Timing0 = 0x04;
                    init_config.Timing1 = 0x1c;
                    break;
                case 9://80

                    init_config.Timing0 = 0x83;
                    init_config.Timing1 = 0xff;
                    break;
                case 10://50

                    init_config.Timing0 = 0x09;
                    init_config.Timing1 = 0x1c;
                    break;

            }

            init_config.Mode = 0;

            if (cmbCanPorts.SelectedItem.ToString() == "CAN-1")
            {
                if (ECANDLL.InitCAN(1, 0, 1, ref init_config) != ECAN.ECANStatus.STATUS_OK)
                {

                    MessageBox.Show("Init can fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ECANDLL.CloseDevice(1, 0);
                    return;
                }
            }


            // enable the timer to rec can data frame from can device.
            m_connect = 1;
            this.can_device_open = true;
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-0")
            {
                this.mCan.EnableProc = false;

                //this.mCan.ThreadReadDataFormDevice.Start();
                //this.ThreadUpdateTable.Start();
                //this.ThreadGetCanDataBuff.Start();
                this.startAllThread();

                DateTimeStamp = DateTime.Now;  // this is the time base of the charts
            }
            else
                this.mCan.EnableProc = false;
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-1")
            {
                this.mCan.EnableProc2 = false;
                DateTimeStamp = DateTime.Now;
            }
            else
                this.mCan.EnableProc2 = false;

            btnInit.Text = "关闭CAN";
            /*
            btnReset.Enabled = true;
            btnWrite.Enabled = true;
            btnSendFile.Enabled = true;
            IncludeTextMessage("Open Success");

            if (checkBoxCan2.Checked)
                btnWrite2.Enabled = true;

            checkBoxCan1.Enabled = false;
            checkBoxCan2.Enabled = false;
             * */
            cmbCanPorts.Enabled = false;

            if (m_connect == 0)
            {
                MessageBox.Show("Not open device!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //Start Can1
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-0")
            {
                if (ECANDLL.StartCAN(1, 0, 0) == ECAN.ECANStatus.STATUS_OK)
                {
                    //IncludeTextMessage("Start CAN1 Success");
                    tmrRead.Enabled = false;

                }

                else
                {
                    //IncludeTextMessage("Start Fault");
                }
            }
            //start CAN2
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-1")
            {
                if (ECANDLL.StartCAN(1, 0, 1) == ECAN.ECANStatus.STATUS_OK)
                {
                    //IncludeTextMessage("Start CAN2 Success");
                    tmrRead.Enabled = false;

                }
                else
                {
                    //IncludeTextMessage("Start Fault");
                }
            }


        }
        #endregion


        public void ThreadLoopGetCanDataBuff()
        {
            while(true)
            {
                this.ReadMessages();
                Thread.Sleep(100);
            }
        }

        private void ReadMessages()
        {
            // lock write lock
            canDataRWLock.EnterWriteLock();
            try
            {
                // lock write lock
                //canDataRWLock.TryEnterWriteLock(200);

                CAN_OBJ frameinfo = new CAN_OBJ();
                int mCount = 0;
                bool add2buff;

                /*
                int i = 0, j = 0;
                for (i = 0; i < dataChart.addChartCnt; i++)
                {
                    for(j = 0; j < dataChart.addElementsCnt; j++)
                    {
                        if(dataChart.chart[i].Titles[j].Text == "S0")

                    }
                }

                */

                while (this.mCan.gRecMsgBufHead != this.mCan.gRecMsgBufTail  && mCount < 50)
                {
                    /*
                    frameinfo = this.mCan.gRecMsgBuf[this.mCan.gRecMsgBufTail];
                    this.mCan.gRecMsgBufTail += 1;
                    if (this.mCan.gRecMsgBufTail >= ComProc.REC_MSG_BUF_MAX)
                    {
                        this.mCan.gRecMsgBufTail = 0;
                    }
                    */
                    
                    // add queue data index
                    //canDataSemaphore.Wait();
                    if (dataChart.addChartCnt > 0)
                    {
                        if (monitorData.head < LevCanData.MAX_BUFF_LEN)
                            monitorData.head += 1;
                        else
                            monitorData.head = 0;

                        add2buff = true;
                    }
                    else
                        add2buff = false;

                    


                    // decode data
                    monitorData.copyData(this.mCan.gRecMsgBuf[this.mCan.gRecMsgBufTail].data, 8);
                    monitorData.decodingData(this.mCan.gRecMsgBuf[this.mCan.gRecMsgBufTail].ID,
                                             this.mCan.gRecMsgBuf[this.mCan.gRecMsgBufTail].TimeStamp);

                    // update data grid view
                    //int point_id = monitorData.getCanDataLevPoint(frameinfo.ID);
                    //if (point_id == 0)
                        //MessageBox.Show("PointId that decoded by method decodingData(candataID) Equas to zero","Warning", MessageBoxButtons.OK);
                    //else
                        //updateDataGridViewCellContents(point_id);
                    //canDataSemaphore.Release();

                    this.mCan.gRecMsgBufTail += 1;
                    if (this.mCan.gRecMsgBufTail >= ComProc.REC_MSG_BUF_MAX)
                    {
                        this.mCan.gRecMsgBufTail = 0;
                    }

                    mCount++;
                }
            }
            finally
            {
                // unlock write lock
                canDataRWLock.ExitWriteLock();
            }

        }

        private void updateDataGridViewCellContents(int point_id)
        {
            int i;

            if (point_id > 0)
            {
                if (point_id % 2 == 1)  // odd point
                {
                    i = (point_id - 1) >> 1;   // row index * 2 + 1 = point_id
                    this.dataGridView1.Rows[i].Cells[0].Value = monitorData.s0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[1].Value = monitorData.s1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[2].Value = monitorData.s2[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[3].Value = monitorData.s3[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[4].Value = monitorData.i1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[5].Value = monitorData.temp[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[6].Value = monitorData.u1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[7].Value = monitorData.a0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[8].Value = monitorData.a1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[9].Value = monitorData.a2[point_id - 1].ValueDecoded.ToString("0.00###");
                }
                else  // even point
                {
                    i = (point_id >> 1) - 1;  // (row index + 1) * 2 = point_id
                    this.dataGridView2.Rows[i].Cells[0].Value = monitorData.s0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[1].Value = monitorData.s1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[2].Value = monitorData.s2[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[3].Value = monitorData.s3[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[4].Value = monitorData.i1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[5].Value = monitorData.temp[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[6].Value = monitorData.u1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[7].Value = monitorData.a0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[8].Value = monitorData.a1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[9].Value = monitorData.a2[point_id - 1].ValueDecoded.ToString("0.00###");
                }
            }
        }

        private void updateDataGridViewCellContents()
        {
            int i;
            int point_id = 1;

            if (point_id > 0)
            {
                if (point_id % 2 == 1)  // odd point
                {
                    i = (point_id - 1) >> 1;   // row index * 2 + 1 = point_id
                    this.dataGridView1.Rows[i].Cells[0].Value = monitorData.s0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[1].Value = monitorData.s1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[2].Value = monitorData.s2[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[3].Value = monitorData.s3[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[4].Value = monitorData.i1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[5].Value = monitorData.temp[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[6].Value = monitorData.u1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[7].Value = monitorData.a0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[8].Value = monitorData.a1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView1.Rows[i].Cells[9].Value = monitorData.a2[point_id - 1].ValueDecoded.ToString("0.00###");
                }
                else  // even point
                {
                    i = (point_id >> 1) - 1;  // (row index + 1) * 2 = point_id
                    this.dataGridView2.Rows[i].Cells[0].Value = monitorData.s0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[1].Value = monitorData.s1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[2].Value = monitorData.s2[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[3].Value = monitorData.s3[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[4].Value = monitorData.i1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[5].Value = monitorData.temp[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[6].Value = monitorData.u1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[7].Value = monitorData.a0[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[8].Value = monitorData.a1[point_id - 1].ValueDecoded.ToString("0.00###");
                    this.dataGridView2.Rows[i].Cells[9].Value = monitorData.a2[point_id - 1].ValueDecoded.ToString("0.00###");
                }
            }
        }

        private void ThreadLoopUpdateTable()
        {
            while (true)
            {
                if (mainform.canDataRWLock.TryEnterReadLock(100))
                {
                    try
                    {
                        this.updateDataGridViewCellContents(mainform.monitorData.LevPointID);
                    }
                    finally
                    {
                        mainform.canDataRWLock.ExitReadLock();
                    }
                }
                Thread.Sleep(500);
            }
        }

        private void ReadMessages2()
        {

            CAN_OBJ frameinfo = new CAN_OBJ();
            int mCount = 0;
            while (this.mCan.gRecMsgBufHead2 != this.mCan.gRecMsgBufTail2)
            {
                string tmpstr;
                frameinfo = this.mCan.gRecMsgBuf2[this.mCan.gRecMsgBufTail2];
                this.mCan.gRecMsgBufTail2 += 1;
                if (this.mCan.gRecMsgBufTail2 >= ComProc.REC_MSG_BUF_MAX)
                {
                    this.mCan.gRecMsgBufTail2 = 0;
                }
                string str = "Rec: ";
                if (frameinfo.TimeFlag == 0)
                {
                    tmpstr = "Time:  ";
                }
                else
                {
                    tmpstr = "Time:" + string.Format("{0:X8}h", frameinfo.TimeStamp);
                }
                str = str + tmpstr;
                tmpstr = "  ID:" + string.Format("{0:X8}h", frameinfo.ID);
                str = str + tmpstr + " Format:";
                if (frameinfo.RemoteFlag == 0)
                {
                    tmpstr = "Data ";
                }
                else
                {
                    tmpstr = "Romte ";
                }
                str = str + tmpstr + " Type:";
                if (frameinfo.ExternFlag == 0)
                {
                    tmpstr = "Stand ";
                }
                else
                {
                    tmpstr = "Exten ";
                }
                str = str + tmpstr;
                if (frameinfo.RemoteFlag == 0)
                {
                    str = str + " Data:";
                    if (frameinfo.DataLen > 8)
                    {
                        frameinfo.DataLen = 8;
                    }
                    int mlen = frameinfo.DataLen - 1;
                    for (int j = 0; j <= mlen; j++)
                    {
                        tmpstr = string.Format("{0:X2}h", frameinfo.data[j]);
                        str = str + tmpstr;
                    }
                }
                this.lbxParamsLog.Items.Add(str);
                if (this.lbxParamsLog.Items.Count > 500)
                {
                    this.lbxParamsLog.Items.Clear();
                }
                mCount++;
                if (mCount >= 50)
                {
                    break;
                }
                Application.DoEvents();
            }



        }

        /// <summary>
        /// write messages to can devices
        /// </summary>
        private void writeMessages(uint message_id, byte[] data)
        {
            if (this.m_connect == 0)
            {
                MessageBox.Show("Device Didn't Open!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.mCan.gSendMsgBuf[this.mCan.gSendMsgBufHead].ID = message_id;
                this.mCan.gSendMsgBuf[this.mCan.gSendMsgBufHead].DataLen = (byte)8;
                for (int i = 0; i < 8; i++)
                {
                    this.mCan.gSendMsgBuf[this.mCan.gSendMsgBufHead].data[i] = data[i];
                }
                this.mCan.gSendMsgBuf[this.mCan.gSendMsgBufHead].ExternFlag = (byte)0;
                this.mCan.gSendMsgBuf[this.mCan.gSendMsgBufHead].RemoteFlag = (byte)0;
                this.mCan.gSendMsgBufHead += 1;
                if (this.mCan.gSendMsgBufHead >= ComProc.SEND_MSG_BUF_MAX)
                {
                    this.mCan.gSendMsgBufHead = 0;
                }
            }
        }

        /// <summary>
        /// set ctrl params data. 
        /// </summary>
        /// <param name="ind_group"></param>
        /// <returns></returns>
        private void setCtrlParamsData(int ind_group)
        {
            UInt16 data;
            int i;
            int begin_ind = ind_group * 4 - 3;
            for (i = begin_ind; i <= 4; i++)
            {
                data = Convert.ToUInt16((panelCtrlUI.Controls.Find("tbk" + i, true)[0] as TextBox).Text, 10);
                int tmp_ind = (i - 1) * 2;
                ctrlCmdData.can_data[tmp_ind] = Convert.ToByte(data & 0x00FF);
                ctrlCmdData.can_data[tmp_ind + 1] = Convert.ToByte(data & 0xFF00);
            }
        }

        private void tmrRead_Tick(object sender, EventArgs e)
        {
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-0")
            {
                ReadMessages();
                //ReadError1();

            }
            if (cmbCanPorts.SelectedItem.ToString() == "CAN-1")
            {
                ReadMessages2();
                //ReadError2();
            }
            //this.TxErrCnt.Text = ComProc.TxErrCnt.ToString("x8") + "h";
        }

        /// <summary>
        /// add chart to UI
        /// </summary>
        private void addChart2UI()
        {
            // add chart to ui
            dataChart.setupChart();
            //setupPanelChart(dataChart.addChartCnt - 1);
            
            //resizeChartsPanel(dataChart.addChartCnt);
            resizeCharts(dataChart.addChartCnt);

            //dataChart.chart[dataChart.addChartCnt - 1].Parent = mainform.chart_panel[dataChart.addChartCnt - 1];
            
            //mainform.chart_panel[dataChart.addChartCnt - 1].Controls.Add(dataChart.chart[dataChart.addChartCnt - 1]);
            //this.splitContainer1.Panel2.Controls.Add(mainform.chart_panel[dataChart.addChartCnt - 1]);
            
            //mainform.chart_panel[dataChart.addChartCnt - 1].BringToFront();

            dataChart.chart[dataChart.addChartCnt - 1].Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(dataChart.chart[dataChart.addChartCnt - 1]);
            dataChart.chart[dataChart.addChartCnt - 1].BringToFront();

            //dataChart.startAddData2Chart();
            this.btnDelChart.Enabled = true;
        }

        /// <summary>
        /// resize charts according to the amounts of charts
        /// </summary>
        /// <param name="num"></param>
        private void resizeCharts(int num_chart)
        {
            if (num_chart != 0)
            {
                int height, width, chart_width, ps_x;
                height = this.splitContainer1.Panel2.Height;
                width = this.splitContainer1.Panel2.Width;
                chart_width = (width - toolStrChartNumCtrl.Width) / num_chart;
                for (int i = 0; i < num_chart; i++)
                {
                    ps_x = i * chart_width + toolStrChartNumCtrl.Width;
                    dataChart.chart[i].Location = new Point(ps_x, 0);
                    dataChart.chart[i].Height = height;
                    dataChart.chart[i].Width = chart_width;
                    //dataChart.chart[i].BringToFront();
                }
            }
        }

        private void resizeChartsPanel(int num_chart)
        {
            if (num_chart != 0)
            {
                int height, width, chart_width, ps_x;
                height = this.splitContainer1.Panel2.Height;
                width = this.splitContainer1.Panel2.Width;
                chart_width = (width - toolStrChartNumCtrl.Width) / num_chart;
                for (int i = 0; i < num_chart; i++)
                {
                    ps_x = i * chart_width + toolStrChartNumCtrl.Width;
                    mainform.chart_panel[i].Location = new Point(ps_x, 0);
                    mainform.chart_panel[i].Height = height;
                    mainform.chart_panel[i].Width = chart_width - 5;

                    // resize charts in panel
                    dataChart.chart[i].Location = mainform.chart_panel[i].Location;
                    dataChart.chart[i].Width = mainform.chart_panel[i].Width;
                    dataChart.chart[i].Height = mainform.chart_panel[i].Height;

                }
            }
        }

        private void toolStrBtnAddChartNum_Click(object sender, EventArgs e)
        {
            if (this.can_device_open)
            {
                addChart2UI();
                this.btnDelChart.Enabled = true;
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            canOpenClose();
            //((Button)sender).t
        }

        private void btnDelChart_Click(object sender, EventArgs e)
        {
            
            int ind = 0;
            if (dataChart.addChartCnt > 0)
            {
                ind = dataChart.addChartCnt - 1;
                dataChart.addChartCnt--;
                dataChart.current_chart_ind = dataChart.addChartCnt;
                if (dataChart.current_chart_ind > 0)
                    dataChart.current_area_ind = dataChart.chart[dataChart.current_chart_ind - 1].ChartAreas.Count;
                else
                {
                    dataChart.current_area_ind = 0;
                    this.btnDelChart.Enabled = false;
                }
            }
            else
                this.btnDelChart.Enabled = false;

            if (dataChart.multiThread && dataChart.addChartCnt > 0)
                dataChart.addDataRunnerArray[ind].Abort();

            for(int i = 0; i < dataChart.chart[ind].Titles.Count; i++)
                monitorData.setAddData2BuffFlag(dataChart.chart[ind].Titles[i].Text, false);

            this.splitContainer1.Panel2.Controls.Remove(dataChart.chart[ind]);

            resizeCharts(dataChart.addChartCnt);
            

            //--------------------------------------
            /*
            int ind = 0;
            if (dataChart.addChartCnt > 0)
            {
                ind = dataChart.mouse_select_chart - 1;
                dataChart.addChartCnt--;
                dataChart.current_chart_ind = dataChart.addChartCnt;
                if (dataChart.current_chart_ind > 0)
                    dataChart.current_area_ind = dataChart.chart[dataChart.current_chart_ind - 1].ChartAreas.Count;
                else
                {
                    dataChart.current_area_ind = 0;
                    this.btnDelChart.Enabled = false;
                }
            }
            else
                this.btnDelChart.Enabled = false;

            if (dataChart.multiThread && dataChart.addChartCnt > 0)
                dataChart.addDataRunnerArray[ind].Abort();

            this.splitContainer1.Panel2.Controls.Remove(dataChart.chart[ind]);

            resizeCharts(dataChart.addChartCnt);
            */
        }

        /// <summary>
        /// open ctrl UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtrl_Click(object sender, EventArgs e)
        {
            //this.hideMonitorUI();
            this.showCtrlUI();
        }

        /// <summary>
        /// open monitor UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            //this.hideCtrlUI();
            this.showMonitorUI();
        }

        private void setupMonitorCtrlUI()
        {
            this.panelCtrlUI.Visible = true;  // hide the ctrl UI
            this.panelCtrlUI.Dock = DockStyle.Fill;
            if (dataChart.addChartCnt <= 0)
                this.btnDelChart.Enabled = false;
            else
                this.btnDelChart.Enabled = true;
            this.panelCtrlUI.Parent = this.splitContainer1.Panel1;

            this.splitContainer2.Visible = true;  // show the ctrl UI
            this.splitContainer2.BringToFront();

            //this.dataGridView1.Height = this.dataGridView1.RowCount * this.dataGridView1.Rows[0].Height;
            //this.dataGridView2.Height = this.dataGridView2.RowCount * this.dataGridView2.Rows[0].Height;
            float height = this.dataGridView1.RowCount * this.dataGridView1.Rows[0].Height;// *1.0f;
            this.splitContainer1.SplitterDistance = 210 ;
            //this.splitContainer1.
        }

        private void showCtrlUI()
        {
            //this.panelCtrlUI.Visible = true;
            this.panelCtrlUI.BringToFront();
        }

        private void hideCtrlUI()
        {
            this.panelCtrlUI.Visible = false;
        }

        private void showMonitorUI()
        {
            //this.splitContainer2.Visible = true;
            this.splitContainer2.BringToFront();
        }

        private void hideMonitorUI()
        {
            this.splitContainer2.Visible = false;
        }

        private void adjustPanelParamsLog()
        {
            //this.panelParamsLog.
        }

        private void btnSelectAllPoints_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 21; i++)
            {
                (panelCtrlUI.Controls.Find("checkBox" + i, true)[0] as CheckBox).Checked = true;
            }
        }

        private void btnClearAllPoints_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 21; i++)
            {
                (tableLayoutPanelLevitationPoint.Controls.Find("checkBox" + i, true)[0] as CheckBox).Checked = false;
            }
        }

        /// <summary>
        /// set gselectCtrlPoint by select the checkBox point
        /// </summary>
        /// <param name="ind"></param>
        private void selectCtrlPoint(int ind)
        {
            int mask = ind - 1;
            if ((tableLayoutPanelLevitationPoint.Controls.Find("checkBox" + ind, true)[0] as CheckBox).Checked)
                ctrlCmdData.LevPointID |= 1 << mask;
            else
                ctrlCmdData.LevPointID &= ~(1 << mask);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(3);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(4);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(5);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(6);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(7);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(8);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(9);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(10);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(11);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(12);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(13);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(14);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(15);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(16);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(17);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(18);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(19);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            selectCtrlPoint(20);
        }

        private void sendParamsGroup(int group_num, uint cmdIDSendParamsGroup)
        {
            setCtrlParamsData(group_num);
            uint id;
            if (ctrlCmdData.LevPointID != 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (((ctrlCmdData.LevPointID >> i) & 0x00001) == 1)
                    {
                        id = ctrlCmdData.setCmdDataID((uint)i + 1, cmdIDSendParamsGroup);
                        this.writeMessages(id, ctrlCmdData.can_data);
                    }
                }
            }
        }

        private void btnParamsGroup1_Click(object sender, EventArgs e)
        {
            sendParamsGroup(1, ctrlCmdData.mailboxIDSendParamsG1);
        }

        private void btnParamsGroup2_Click(object sender, EventArgs e)
        {
            sendParamsGroup(2, ctrlCmdData.mailoxIDSendParamsG2);
        }

        private void btnParamsGroup3_Click(object sender, EventArgs e)
        {
            sendParamsGroup(3, ctrlCmdData.mailoxIDSendParamsG2);
        }

        private void btnParamsGroup4_Click(object sender, EventArgs e)
        {
            sendParamsGroup(4, ctrlCmdData.mailboxIDSendParamsG4);
        }
        
        /// <summary>
        /// Get the diagnostic info by double click row header to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string row_ind = (string)((DataGridView)sender).CurrentRow.HeaderCell.Value;

            DelDiagnosticData_ DelGetDiagInfo = new DelDiagnosticData_(getDiagInfo);

            LevPointDiagnosticInfo LevPointDiagInfoForm = new LevPointDiagnosticInfo(DelGetDiagInfo, Convert.ToInt32(row_ind));
            LevPointDiagInfoForm.ShowDialog();

            //MessageBox.Show("row header double click", "double click", MessageBoxButtons.OKCancel);
        }

        
        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string row_ind = (string)((DataGridView)sender).CurrentRow.HeaderCell.Value;

            DelDiagnosticData_ DelGetDiagInfo = new DelDiagnosticData_(getDiagInfo);

            LevPointDiagnosticInfo LevPointDiagInfoForm = new LevPointDiagnosticInfo(DelGetDiagInfo, Convert.ToInt32(row_ind));
            LevPointDiagInfoForm.ShowDialog();
        }

        public DiagnosticData getDiagInfo(int point_id)
        {
            this.diagInfoData.cap_charge_status = 1;
            this.diagInfoData.km1_fbk += 1;
            this.diagInfoData.km2_fbk += 1;
            this.diagInfoData.senseor_status = 0;
            return this.diagInfoData;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 1)  // prevent to creating the chart area by double click row header.
            {
                string name = this.dataGridView1.CurrentCell.OwningRow.HeaderCell.Value.ToString() + "-";
                name += this.dataGridView1.CurrentCell.OwningColumn.HeaderCell.Value.ToString();
                // creat chart area by the levitation point and the message contents(such as s0, a0, temp, current, acc etc.)
                dataCellAddChart(name);
                monitorData.setAddData2BuffFlag(name, true);
            }
        }

        private string getDataUnit(string cell_column_headr)
        {
            string str = "";
            if (cell_column_headr == "S0" || cell_column_headr == "S1" || cell_column_headr == "S2" || cell_column_headr == "S3")
                str = "mm";
            else if (cell_column_headr == "A0" || cell_column_headr == "A1" || cell_column_headr == "A2")
                str = "m/s2";
            else if (cell_column_headr == "Temp")
                str = "摄氏度";
            else if (cell_column_headr == "I1")
                str = "A";
            else
                str = "";

            return str;
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView2.SelectedCells.Count == 1)  // prevent to creating the chart area by double click row header.
            {
                string name = this.dataGridView2.CurrentCell.OwningRow.HeaderCell.Value.ToString() + "-";
                name += this.dataGridView2.CurrentCell.OwningColumn.HeaderCell.Value.ToString();
                dataCellAddChart(name);
                monitorData.setAddData2BuffFlag(name, true);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.resizeCharts(dataChart.addChartCnt);
        }

        private void splitContainer1_Panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.mypanel2.Parent = this.splitContainer1.Panel2;
            Control result = this.splitContainer1.GetChildAtPoint(e.Location);
            //Control result = this.GetChildAtPoint(e.Location);
            if (result != null)
            {
                result.Select();
                string str = result.Name;
                //if ( result.
                //if (result.ChartElementType == ChartElementType.DataPoint)


                MessageBox.Show("this is " + str, "Note!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("this is splitContainer1 panel2.", "Note!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            //stopAllThread();
        }

        private void startAllThread()
        {
            if (ThreadUpdateTable.IsAlive == false)
                ThreadUpdateTable.Start();

            if (ThreadGetCanDataBuff.IsAlive == false)
                ThreadGetCanDataBuff.Start();

            if (this.mCan.ThreadReadDataFormDevice.IsAlive == false)
                this.mCan.ThreadReadDataFormDevice.Start();

            if (dataChart.multiThread)
            {
                for (int i = 0; i < dataChart.addChartCnt; i++)
                {
                    if (dataChart.addDataRunnerArray[i].IsAlive == false)
                        dataChart.addDataRunnerArray[i].Start();
                }
            }
            else
            {
                if (dataChart.addDataRunner.IsAlive == false)
                    dataChart.addDataRunner.Start();
            }
        }

        private void stopAllThread()
        {

            if (ThreadUpdateTable.IsAlive == true)
                ThreadUpdateTable.Abort();

            if (ThreadGetCanDataBuff.IsAlive == true)
                ThreadGetCanDataBuff.Abort();

            if (this.mCan.ThreadReadDataFormDevice.IsAlive)
                this.mCan.ThreadReadDataFormDevice.Abort();

            if (dataChart.multiThread)
            {
                for (int i = 0; i < dataChart.addChartCnt; i++)
                {
                    if (dataChart.addDataRunnerArray[i].IsAlive)
                        dataChart.addDataRunnerArray[i].Abort();
                }
            }
            else
            {
                if (dataChart.addDataRunner.IsAlive)
                    dataChart.addDataRunner.Abort();
            }
        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.can_device_open == true)
                canOpenClose();

            stopAllThread();
        }
    
    }
}
