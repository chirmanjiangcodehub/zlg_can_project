namespace LevitationHostCanbus
{
    partial class LevPointDiagnosticInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labDriverBoard = new System.Windows.Forms.Label();
            this.labSensorStatus = new System.Windows.Forms.Label();
            this.labCapChargeStatus = new System.Windows.Forms.Label();
            this.labKM1Fbk = new System.Windows.Forms.Label();
            this.labCPUStatus = new System.Windows.Forms.Label();
            this.labPowerSupply = new System.Windows.Forms.Label();
            this.labTempStatus = new System.Windows.Forms.Label();
            this.labLevStatus = new System.Windows.Forms.Label();
            this.labKM2Fbk = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxDriverBoard = new System.Windows.Forms.TextBox();
            this.tbxSensorStatus = new System.Windows.Forms.TextBox();
            this.tbxCapChargeStatus = new System.Windows.Forms.TextBox();
            this.tbxKM1Fbk = new System.Windows.Forms.TextBox();
            this.tbxCPUStatus = new System.Windows.Forms.TextBox();
            this.tbxPowerSupplyStatus = new System.Windows.Forms.TextBox();
            this.tbxTempStatus = new System.Windows.Forms.TextBox();
            this.tbxLevStatus = new System.Windows.Forms.TextBox();
            this.tbxKM2Fbk = new System.Windows.Forms.TextBox();
            this.timerGetData = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labDriverBoard
            // 
            this.labDriverBoard.AutoSize = true;
            this.labDriverBoard.Location = new System.Drawing.Point(3, 0);
            this.labDriverBoard.Name = "labDriverBoard";
            this.labDriverBoard.Size = new System.Drawing.Size(52, 15);
            this.labDriverBoard.TabIndex = 0;
            this.labDriverBoard.Text = "驱动板";
            this.labDriverBoard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labSensorStatus
            // 
            this.labSensorStatus.AutoSize = true;
            this.labSensorStatus.Location = new System.Drawing.Point(3, 37);
            this.labSensorStatus.Name = "labSensorStatus";
            this.labSensorStatus.Size = new System.Drawing.Size(52, 15);
            this.labSensorStatus.TabIndex = 1;
            this.labSensorStatus.Text = "传感器";
            this.labSensorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCapChargeStatus
            // 
            this.labCapChargeStatus.AutoSize = true;
            this.labCapChargeStatus.Location = new System.Drawing.Point(3, 74);
            this.labCapChargeStatus.Name = "labCapChargeStatus";
            this.labCapChargeStatus.Size = new System.Drawing.Size(67, 15);
            this.labCapChargeStatus.TabIndex = 2;
            this.labCapChargeStatus.Text = "充电状态";
            this.labCapChargeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labKM1Fbk
            // 
            this.labKM1Fbk.AutoSize = true;
            this.labKM1Fbk.Location = new System.Drawing.Point(3, 111);
            this.labKM1Fbk.Name = "labKM1Fbk";
            this.labKM1Fbk.Size = new System.Drawing.Size(31, 15);
            this.labKM1Fbk.TabIndex = 3;
            this.labKM1Fbk.Text = "KM1";
            this.labKM1Fbk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCPUStatus
            // 
            this.labCPUStatus.AutoSize = true;
            this.labCPUStatus.Location = new System.Drawing.Point(3, 148);
            this.labCPUStatus.Name = "labCPUStatus";
            this.labCPUStatus.Size = new System.Drawing.Size(61, 15);
            this.labCPUStatus.TabIndex = 4;
            this.labCPUStatus.Text = "CPU状态";
            this.labCPUStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labPowerSupply
            // 
            this.labPowerSupply.AutoSize = true;
            this.labPowerSupply.Location = new System.Drawing.Point(198, 0);
            this.labPowerSupply.Name = "labPowerSupply";
            this.labPowerSupply.Size = new System.Drawing.Size(67, 15);
            this.labPowerSupply.TabIndex = 5;
            this.labPowerSupply.Text = "电源电压";
            this.labPowerSupply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTempStatus
            // 
            this.labTempStatus.AutoSize = true;
            this.labTempStatus.Location = new System.Drawing.Point(198, 37);
            this.labTempStatus.Name = "labTempStatus";
            this.labTempStatus.Size = new System.Drawing.Size(67, 15);
            this.labTempStatus.TabIndex = 6;
            this.labTempStatus.Text = "温度状态";
            this.labTempStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labLevStatus
            // 
            this.labLevStatus.AutoSize = true;
            this.labLevStatus.Location = new System.Drawing.Point(198, 74);
            this.labLevStatus.Name = "labLevStatus";
            this.labLevStatus.Size = new System.Drawing.Size(67, 15);
            this.labLevStatus.TabIndex = 7;
            this.labLevStatus.Text = "悬浮状态";
            this.labLevStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labKM2Fbk
            // 
            this.labKM2Fbk.AutoSize = true;
            this.labKM2Fbk.Location = new System.Drawing.Point(198, 111);
            this.labKM2Fbk.Name = "labKM2Fbk";
            this.labKM2Fbk.Size = new System.Drawing.Size(31, 15);
            this.labKM2Fbk.TabIndex = 8;
            this.labKM2Fbk.Text = "KM2";
            this.labKM2Fbk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labDriverBoard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labSensorStatus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labLevStatus, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labCapChargeStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labKM1Fbk, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labPowerSupply, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labCPUStatus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxDriverBoard, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxSensorStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxCapChargeStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxKM1Fbk, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxCPUStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxPowerSupplyStatus, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxTempStatus, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxLevStatus, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxKM2Fbk, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labTempStatus, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labKM2Fbk, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 185);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tbxDriverBoard
            // 
            this.tbxDriverBoard.Location = new System.Drawing.Point(76, 3);
            this.tbxDriverBoard.Name = "tbxDriverBoard";
            this.tbxDriverBoard.ReadOnly = true;
            this.tbxDriverBoard.Size = new System.Drawing.Size(100, 25);
            this.tbxDriverBoard.TabIndex = 9;
            // 
            // tbxSensorStatus
            // 
            this.tbxSensorStatus.Location = new System.Drawing.Point(76, 40);
            this.tbxSensorStatus.Name = "tbxSensorStatus";
            this.tbxSensorStatus.ReadOnly = true;
            this.tbxSensorStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxSensorStatus.TabIndex = 10;
            // 
            // tbxCapChargeStatus
            // 
            this.tbxCapChargeStatus.Location = new System.Drawing.Point(76, 77);
            this.tbxCapChargeStatus.Name = "tbxCapChargeStatus";
            this.tbxCapChargeStatus.ReadOnly = true;
            this.tbxCapChargeStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxCapChargeStatus.TabIndex = 11;
            // 
            // tbxKM1Fbk
            // 
            this.tbxKM1Fbk.Location = new System.Drawing.Point(76, 114);
            this.tbxKM1Fbk.Name = "tbxKM1Fbk";
            this.tbxKM1Fbk.ReadOnly = true;
            this.tbxKM1Fbk.Size = new System.Drawing.Size(100, 25);
            this.tbxKM1Fbk.TabIndex = 12;
            // 
            // tbxCPUStatus
            // 
            this.tbxCPUStatus.Location = new System.Drawing.Point(76, 151);
            this.tbxCPUStatus.Name = "tbxCPUStatus";
            this.tbxCPUStatus.ReadOnly = true;
            this.tbxCPUStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxCPUStatus.TabIndex = 13;
            // 
            // tbxPowerSupplyStatus
            // 
            this.tbxPowerSupplyStatus.Location = new System.Drawing.Point(271, 3);
            this.tbxPowerSupplyStatus.Name = "tbxPowerSupplyStatus";
            this.tbxPowerSupplyStatus.ReadOnly = true;
            this.tbxPowerSupplyStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxPowerSupplyStatus.TabIndex = 14;
            // 
            // tbxTempStatus
            // 
            this.tbxTempStatus.Location = new System.Drawing.Point(271, 40);
            this.tbxTempStatus.Name = "tbxTempStatus";
            this.tbxTempStatus.ReadOnly = true;
            this.tbxTempStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxTempStatus.TabIndex = 15;
            // 
            // tbxLevStatus
            // 
            this.tbxLevStatus.Location = new System.Drawing.Point(271, 77);
            this.tbxLevStatus.Name = "tbxLevStatus";
            this.tbxLevStatus.ReadOnly = true;
            this.tbxLevStatus.Size = new System.Drawing.Size(100, 25);
            this.tbxLevStatus.TabIndex = 16;
            // 
            // tbxKM2Fbk
            // 
            this.tbxKM2Fbk.Location = new System.Drawing.Point(271, 114);
            this.tbxKM2Fbk.Name = "tbxKM2Fbk";
            this.tbxKM2Fbk.ReadOnly = true;
            this.tbxKM2Fbk.Size = new System.Drawing.Size(100, 25);
            this.tbxKM2Fbk.TabIndex = 17;
            // 
            // timerGetData
            // 
            this.timerGetData.Interval = 750;
            this.timerGetData.Tick += new System.EventHandler(this.timerGetData_Tick);
            // 
            // LevPointDiagnosticInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LevPointDiagnosticInfo";
            this.ShowIcon = false;
            this.Text = "诊断信息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LevPointDiagnosticInfo_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labDriverBoard;
        private System.Windows.Forms.Label labSensorStatus;
        private System.Windows.Forms.Label labCapChargeStatus;
        private System.Windows.Forms.Label labKM1Fbk;
        private System.Windows.Forms.Label labCPUStatus;
        private System.Windows.Forms.Label labPowerSupply;
        private System.Windows.Forms.Label labTempStatus;
        private System.Windows.Forms.Label labLevStatus;
        private System.Windows.Forms.Label labKM2Fbk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbxDriverBoard;
        private System.Windows.Forms.TextBox tbxSensorStatus;
        private System.Windows.Forms.TextBox tbxCapChargeStatus;
        private System.Windows.Forms.TextBox tbxKM1Fbk;
        private System.Windows.Forms.TextBox tbxCPUStatus;
        private System.Windows.Forms.TextBox tbxPowerSupplyStatus;
        private System.Windows.Forms.TextBox tbxTempStatus;
        private System.Windows.Forms.TextBox tbxLevStatus;
        private System.Windows.Forms.TextBox tbxKM2Fbk;
        private System.Windows.Forms.Timer timerGetData;
    }
}