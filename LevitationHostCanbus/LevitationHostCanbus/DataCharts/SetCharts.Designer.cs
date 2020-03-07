namespace LevitationHostCanbus
{
    partial class SetCharts
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
            this.tbxTimeLen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxYmax = new System.Windows.Forms.TextBox();
            this.tbxYmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.labChartAreaName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxTimeLen
            // 
            this.tbxTimeLen.Location = new System.Drawing.Point(152, 35);
            this.tbxTimeLen.Name = "tbxTimeLen";
            this.tbxTimeLen.Size = new System.Drawing.Size(73, 25);
            this.tbxTimeLen.TabIndex = 0;
            this.tbxTimeLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "时间轴长度(秒)";
            // 
            // tbxYmax
            // 
            this.tbxYmax.Location = new System.Drawing.Point(152, 78);
            this.tbxYmax.Name = "tbxYmax";
            this.tbxYmax.Size = new System.Drawing.Size(73, 25);
            this.tbxYmax.TabIndex = 1;
            this.tbxYmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxYmin
            // 
            this.tbxYmin.Location = new System.Drawing.Point(152, 121);
            this.tbxYmin.Name = "tbxYmin";
            this.tbxYmin.Size = new System.Drawing.Size(73, 25);
            this.tbxYmin.TabIndex = 2;
            this.tbxYmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y轴最大值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y轴最小值";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(30, 181);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 40);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(152, 181);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(82, 40);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // labChartAreaName
            // 
            this.labChartAreaName.AutoSize = true;
            this.labChartAreaName.Location = new System.Drawing.Point(102, 9);
            this.labChartAreaName.Name = "labChartAreaName";
            this.labChartAreaName.Size = new System.Drawing.Size(55, 15);
            this.labChartAreaName.TabIndex = 5;
            this.labChartAreaName.Text = "label4";
            this.labChartAreaName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetCharts
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(264, 233);
            this.Controls.Add(this.labChartAreaName);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxYmin);
            this.Controls.Add(this.tbxYmax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxTimeLen);
            this.Name = "SetCharts";
            this.ShowIcon = false;
            this.Text = "图表设置";
            this.Load += new System.EventHandler(this.SetCharts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTimeLen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxYmax;
        private System.Windows.Forms.TextBox tbxYmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label labChartAreaName;
    }
}