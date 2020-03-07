using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LevitationHostCanbus
{
    public partial class LevPointDiagnosticInfo : Form
    {
        DelDiagnosticData_ DelGetDiagInfo;
        DiagnosticData DiagDataInfo = new DiagnosticData();
        int point_id;

        public LevPointDiagnosticInfo(DelDiagnosticData_ DelGetDiagnosticData, int point_id_)
        {
            this.DelGetDiagInfo = DelGetDiagnosticData;
            InitializeComponent();

            this.point_id = point_id_;
            this.Text = Convert.ToString(this.point_id) + "#诊断信息";
            this.timerGetData.Enabled = true;

        }

        private void timerGetData_Tick(object sender, EventArgs e)
        {
            DiagDataInfo = this.DelGetDiagInfo(this.point_id);
            this.tbxKM1Fbk.Text = DiagDataInfo.km1_fbk.ToString();
            this.tbxKM2Fbk.Text = DiagDataInfo.km2_fbk.ToString();
            this.tbxCapChargeStatus.Text = DiagDataInfo.cap_charge_status.ToString();
        }

        private void LevPointDiagnosticInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timerGetData.Enabled = false;
        }




    }
}
