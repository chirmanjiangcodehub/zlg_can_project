using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LevitationHostCanbus
{
    /// <summary>
    /// 新建窗口，为图表区域设置参数，如Y轴最大值最小值
    /// X轴长度等等
    /// </summary>
    public partial class SetCharts : Form
    {
        DelSetChartsParams DelSetChartsParams_;

        private ChartSetting chartSetting = new ChartSetting();

        public SetCharts(DelSetChartsParams DelSetting_, ChartSetting setting)
        {
            InitializeComponent();
            this.DelSetChartsParams_ = DelSetting_;

            this.labChartAreaName.Text = (setting.hitTestResult.ChartArea.Name.Split('.'))[1];
            this.tbxYmax.Text = Convert.ToString(setting.hitTestResult.ChartArea.AxisY.Maximum);
            this.tbxYmin.Text = Convert.ToString(setting.hitTestResult.ChartArea.AxisY.Minimum);
            this.tbxTimeLen.Text = "50";

            this.chartSetting.ChartInd = setting.ChartInd;

            this.chartSetting.hitTestResult = setting.hitTestResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.chartSetting.YMax = Convert.ToDouble(this.tbxYmax.Text);
            this.chartSetting.YMin = Convert.ToDouble(this.tbxYmin.Text);
            

            this.DelSetChartsParams_(chartSetting);
            this.Close();
        }

        private void SetCharts_Load(object sender, EventArgs e)
        {
            this.btnOK.Focus();
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
