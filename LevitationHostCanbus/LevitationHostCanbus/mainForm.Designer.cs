namespace LevitationHostCanbus
{
    partial class mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
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

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.S0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelCtrlUI = new System.Windows.Forms.Panel();
            this.panelParamsLog = new System.Windows.Forms.Panel();
            this.lbxParamsLog = new System.Windows.Forms.ListBox();
            this.toolStripParamsLogCmd = new System.Windows.Forms.ToolStrip();
            this.btnLogParams = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRestoreParams = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenParamsFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbk2 = new System.Windows.Forms.TextBox();
            this.tbk3 = new System.Windows.Forms.TextBox();
            this.tbk4 = new System.Windows.Forms.TextBox();
            this.tbk5 = new System.Windows.Forms.TextBox();
            this.tbk6 = new System.Windows.Forms.TextBox();
            this.tbk7 = new System.Windows.Forms.TextBox();
            this.tbk8 = new System.Windows.Forms.TextBox();
            this.tbk9 = new System.Windows.Forms.TextBox();
            this.tbk10 = new System.Windows.Forms.TextBox();
            this.tbk11 = new System.Windows.Forms.TextBox();
            this.tbk12 = new System.Windows.Forms.TextBox();
            this.tbk13 = new System.Windows.Forms.TextBox();
            this.tbk14 = new System.Windows.Forms.TextBox();
            this.tbk15 = new System.Windows.Forms.TextBox();
            this.tbk16 = new System.Windows.Forms.TextBox();
            this.btnParamsGroup1 = new System.Windows.Forms.Button();
            this.btnParamsGroup2 = new System.Windows.Forms.Button();
            this.btnParamsGroup3 = new System.Windows.Forms.Button();
            this.btnParamsGroup4 = new System.Windows.Forms.Button();
            this.tbk1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanelCMD = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnClearAllPoints = new System.Windows.Forms.Button();
            this.btnSelectAllPoints = new System.Windows.Forms.Button();
            this.tableLayoutPanelLevitationPoint = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.toolStrChartNumCtrl = new System.Windows.Forms.ToolStrip();
            this.btnAddChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelChart = new System.Windows.Forms.ToolStripButton();
            this.tmrRead = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripHostCmd = new System.Windows.Forms.ToolStrip();
            this.btnInit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLogData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbCanPorts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMonitor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCtrl = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelCtrlUI.SuspendLayout();
            this.panelParamsLog.SuspendLayout();
            this.toolStripParamsLogCmd.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelCMD.SuspendLayout();
            this.tableLayoutPanelLevitationPoint.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrChartNumCtrl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripHostCmd.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(761, 291);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelCtrlUI);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrChartNumCtrl);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 561);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer2.Size = new System.Drawing.Size(1024, 204);
            this.splitContainer2.SplitterDistance = 519;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S0,
            this.S1,
            this.S2,
            this.S3,
            this.Column1,
            this.Column2,
            this.Column3,
            this.A0,
            this.A1,
            this.A2,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 47;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(519, 204);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // S0
            // 
            this.S0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.S0.HeaderText = "S0";
            this.S0.Name = "S0";
            this.S0.ReadOnly = true;
            // 
            // S1
            // 
            this.S1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.S1.HeaderText = "S1";
            this.S1.Name = "S1";
            this.S1.ReadOnly = true;
            // 
            // S2
            // 
            this.S2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.S2.HeaderText = "S2";
            this.S2.Name = "S2";
            this.S2.ReadOnly = true;
            // 
            // S3
            // 
            this.S3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.S3.HeaderText = "S3";
            this.S3.Name = "S3";
            this.S3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "I1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Temp";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "U1";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // A0
            // 
            this.A0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.A0.HeaderText = "A0";
            this.A0.Name = "A0";
            this.A0.ReadOnly = true;
            // 
            // A1
            // 
            this.A1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.A1.HeaderText = "A1";
            this.A1.Name = "A1";
            this.A1.ReadOnly = true;
            // 
            // A2
            // 
            this.A2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.A2.HeaderText = "A2";
            this.A2.Name = "A2";
            this.A2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "LevStatus";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "KM2D";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column6,
            this.Column7,
            this.Column15,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column16,
            this.Column17});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.RowHeadersWidth = 47;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(502, 204);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentDoubleClick);
            this.dataGridView2.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseDoubleClick);
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "S0";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "S1";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "S2";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.HeaderText = "S3";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "I1";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Temp";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column15.HeaderText = "U1";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column12.HeaderText = "A0";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column13.HeaderText = "A1";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column14.HeaderText = "A2";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column16.HeaderText = "LevStatus";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column17.HeaderText = "KM2D";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // panelCtrlUI
            // 
            this.panelCtrlUI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCtrlUI.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelCtrlUI.Controls.Add(this.panelParamsLog);
            this.panelCtrlUI.Controls.Add(this.tableLayoutPanel1);
            this.panelCtrlUI.Controls.Add(this.tableLayoutPanelCMD);
            this.panelCtrlUI.Controls.Add(this.btnClearAllPoints);
            this.panelCtrlUI.Controls.Add(this.btnSelectAllPoints);
            this.panelCtrlUI.Controls.Add(this.tableLayoutPanelLevitationPoint);
            this.panelCtrlUI.Location = new System.Drawing.Point(28, 2);
            this.panelCtrlUI.Margin = new System.Windows.Forms.Padding(2);
            this.panelCtrlUI.Name = "panelCtrlUI";
            this.panelCtrlUI.Size = new System.Drawing.Size(835, 275);
            this.panelCtrlUI.TabIndex = 1;
            // 
            // panelParamsLog
            // 
            this.panelParamsLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParamsLog.Controls.Add(this.lbxParamsLog);
            this.panelParamsLog.Controls.Add(this.toolStripParamsLogCmd);
            this.panelParamsLog.Location = new System.Drawing.Point(466, 2);
            this.panelParamsLog.Margin = new System.Windows.Forms.Padding(2);
            this.panelParamsLog.Name = "panelParamsLog";
            this.panelParamsLog.Size = new System.Drawing.Size(360, 270);
            this.panelParamsLog.TabIndex = 10;
            // 
            // lbxParamsLog
            // 
            this.lbxParamsLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxParamsLog.BackColor = System.Drawing.Color.Beige;
            this.lbxParamsLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxParamsLog.FormattingEnabled = true;
            this.lbxParamsLog.ItemHeight = 12;
            this.lbxParamsLog.Location = new System.Drawing.Point(0, 22);
            this.lbxParamsLog.Margin = new System.Windows.Forms.Padding(2);
            this.lbxParamsLog.Name = "lbxParamsLog";
            this.lbxParamsLog.Size = new System.Drawing.Size(361, 242);
            this.lbxParamsLog.TabIndex = 1;
            // 
            // toolStripParamsLogCmd
            // 
            this.toolStripParamsLogCmd.BackColor = System.Drawing.Color.PapayaWhip;
            this.toolStripParamsLogCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogParams,
            this.toolStripSeparator6,
            this.btnRestoreParams,
            this.toolStripSeparator7,
            this.btnOpenParamsFile,
            this.toolStripSeparator8,
            this.btnSaveToFile});
            this.toolStripParamsLogCmd.Location = new System.Drawing.Point(0, 0);
            this.toolStripParamsLogCmd.Name = "toolStripParamsLogCmd";
            this.toolStripParamsLogCmd.Size = new System.Drawing.Size(360, 25);
            this.toolStripParamsLogCmd.TabIndex = 0;
            this.toolStripParamsLogCmd.Text = "toolStrip1";
            // 
            // btnLogParams
            // 
            this.btnLogParams.Image = global::LevitationHostCanbus.Properties.Resources.document_prepare;
            this.btnLogParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogParams.Name = "btnLogParams";
            this.btnLogParams.Size = new System.Drawing.Size(52, 22);
            this.btnLogParams.Text = "记录";
            this.btnLogParams.ToolTipText = "记录参数";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRestoreParams
            // 
            this.btnRestoreParams.Image = global::LevitationHostCanbus.Properties.Resources.arrow_redo;
            this.btnRestoreParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRestoreParams.Name = "btnRestoreParams";
            this.btnRestoreParams.Size = new System.Drawing.Size(52, 22);
            this.btnRestoreParams.Text = "恢复";
            this.btnRestoreParams.ToolTipText = "恢复参数";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenParamsFile
            // 
            this.btnOpenParamsFile.Image = global::LevitationHostCanbus.Properties.Resources.folder;
            this.btnOpenParamsFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenParamsFile.Name = "btnOpenParamsFile";
            this.btnOpenParamsFile.Size = new System.Drawing.Size(76, 22);
            this.btnOpenParamsFile.Text = "打开文件";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Image = global::LevitationHostCanbus.Properties.Resources.save_as;
            this.btnSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(88, 22);
            this.btnSaveToFile.Text = "保存至文件";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbk2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbk3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbk4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbk5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbk6, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbk7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbk8, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbk9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbk10, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbk11, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbk12, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbk13, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbk14, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbk15, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbk16, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnParamsGroup1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnParamsGroup2, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnParamsGroup3, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnParamsGroup4, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbk1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 3, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(150, 81);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(274, 170);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tbk2
            // 
            this.tbk2.Location = new System.Drawing.Point(56, 18);
            this.tbk2.Margin = new System.Windows.Forms.Padding(2);
            this.tbk2.Name = "tbk2";
            this.tbk2.Size = new System.Drawing.Size(50, 21);
            this.tbk2.TabIndex = 1;
            this.tbk2.Text = "0";
            this.tbk2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk3
            // 
            this.tbk3.Location = new System.Drawing.Point(110, 18);
            this.tbk3.Margin = new System.Windows.Forms.Padding(2);
            this.tbk3.Name = "tbk3";
            this.tbk3.Size = new System.Drawing.Size(50, 21);
            this.tbk3.TabIndex = 2;
            this.tbk3.Text = "0";
            this.tbk3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk4
            // 
            this.tbk4.Location = new System.Drawing.Point(164, 18);
            this.tbk4.Margin = new System.Windows.Forms.Padding(2);
            this.tbk4.Name = "tbk4";
            this.tbk4.Size = new System.Drawing.Size(50, 21);
            this.tbk4.TabIndex = 3;
            this.tbk4.Text = "0";
            this.tbk4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk5
            // 
            this.tbk5.Location = new System.Drawing.Point(2, 60);
            this.tbk5.Margin = new System.Windows.Forms.Padding(2);
            this.tbk5.Name = "tbk5";
            this.tbk5.Size = new System.Drawing.Size(50, 21);
            this.tbk5.TabIndex = 4;
            this.tbk5.Text = "0";
            this.tbk5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk6
            // 
            this.tbk6.Location = new System.Drawing.Point(56, 60);
            this.tbk6.Margin = new System.Windows.Forms.Padding(2);
            this.tbk6.Name = "tbk6";
            this.tbk6.Size = new System.Drawing.Size(50, 21);
            this.tbk6.TabIndex = 5;
            this.tbk6.Text = "0";
            this.tbk6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk7
            // 
            this.tbk7.Location = new System.Drawing.Point(110, 60);
            this.tbk7.Margin = new System.Windows.Forms.Padding(2);
            this.tbk7.Name = "tbk7";
            this.tbk7.Size = new System.Drawing.Size(50, 21);
            this.tbk7.TabIndex = 6;
            this.tbk7.Text = "0";
            this.tbk7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk8
            // 
            this.tbk8.Location = new System.Drawing.Point(164, 60);
            this.tbk8.Margin = new System.Windows.Forms.Padding(2);
            this.tbk8.Name = "tbk8";
            this.tbk8.Size = new System.Drawing.Size(50, 21);
            this.tbk8.TabIndex = 7;
            this.tbk8.Text = "0";
            this.tbk8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk9
            // 
            this.tbk9.Location = new System.Drawing.Point(2, 102);
            this.tbk9.Margin = new System.Windows.Forms.Padding(2);
            this.tbk9.Name = "tbk9";
            this.tbk9.Size = new System.Drawing.Size(50, 21);
            this.tbk9.TabIndex = 8;
            this.tbk9.Text = "0";
            this.tbk9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk10
            // 
            this.tbk10.Location = new System.Drawing.Point(56, 102);
            this.tbk10.Margin = new System.Windows.Forms.Padding(2);
            this.tbk10.Name = "tbk10";
            this.tbk10.Size = new System.Drawing.Size(50, 21);
            this.tbk10.TabIndex = 9;
            this.tbk10.Text = "0";
            this.tbk10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk11
            // 
            this.tbk11.Location = new System.Drawing.Point(110, 102);
            this.tbk11.Margin = new System.Windows.Forms.Padding(2);
            this.tbk11.Name = "tbk11";
            this.tbk11.Size = new System.Drawing.Size(50, 21);
            this.tbk11.TabIndex = 10;
            this.tbk11.Text = "0";
            this.tbk11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk12
            // 
            this.tbk12.Location = new System.Drawing.Point(164, 102);
            this.tbk12.Margin = new System.Windows.Forms.Padding(2);
            this.tbk12.Name = "tbk12";
            this.tbk12.Size = new System.Drawing.Size(50, 21);
            this.tbk12.TabIndex = 11;
            this.tbk12.Text = "0";
            this.tbk12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk13
            // 
            this.tbk13.Location = new System.Drawing.Point(2, 144);
            this.tbk13.Margin = new System.Windows.Forms.Padding(2);
            this.tbk13.Name = "tbk13";
            this.tbk13.Size = new System.Drawing.Size(50, 21);
            this.tbk13.TabIndex = 12;
            this.tbk13.Text = "0";
            this.tbk13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk14
            // 
            this.tbk14.Location = new System.Drawing.Point(56, 144);
            this.tbk14.Margin = new System.Windows.Forms.Padding(2);
            this.tbk14.Name = "tbk14";
            this.tbk14.Size = new System.Drawing.Size(50, 21);
            this.tbk14.TabIndex = 13;
            this.tbk14.Text = "0";
            this.tbk14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk15
            // 
            this.tbk15.Location = new System.Drawing.Point(110, 144);
            this.tbk15.Margin = new System.Windows.Forms.Padding(2);
            this.tbk15.Name = "tbk15";
            this.tbk15.Size = new System.Drawing.Size(50, 21);
            this.tbk15.TabIndex = 14;
            this.tbk15.Text = "0";
            this.tbk15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbk16
            // 
            this.tbk16.Location = new System.Drawing.Point(164, 144);
            this.tbk16.Margin = new System.Windows.Forms.Padding(2);
            this.tbk16.Name = "tbk16";
            this.tbk16.Size = new System.Drawing.Size(50, 21);
            this.tbk16.TabIndex = 15;
            this.tbk16.Text = "0";
            this.tbk16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnParamsGroup1
            // 
            this.btnParamsGroup1.Location = new System.Drawing.Point(218, 18);
            this.btnParamsGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.btnParamsGroup1.Name = "btnParamsGroup1";
            this.btnParamsGroup1.Size = new System.Drawing.Size(50, 22);
            this.btnParamsGroup1.TabIndex = 16;
            this.btnParamsGroup1.Text = "发送";
            this.btnParamsGroup1.UseVisualStyleBackColor = true;
            this.btnParamsGroup1.Click += new System.EventHandler(this.btnParamsGroup1_Click);
            // 
            // btnParamsGroup2
            // 
            this.btnParamsGroup2.Location = new System.Drawing.Point(218, 60);
            this.btnParamsGroup2.Margin = new System.Windows.Forms.Padding(2);
            this.btnParamsGroup2.Name = "btnParamsGroup2";
            this.btnParamsGroup2.Size = new System.Drawing.Size(50, 22);
            this.btnParamsGroup2.TabIndex = 17;
            this.btnParamsGroup2.Text = "发送";
            this.btnParamsGroup2.UseVisualStyleBackColor = true;
            this.btnParamsGroup2.Click += new System.EventHandler(this.btnParamsGroup2_Click);
            // 
            // btnParamsGroup3
            // 
            this.btnParamsGroup3.Location = new System.Drawing.Point(218, 102);
            this.btnParamsGroup3.Margin = new System.Windows.Forms.Padding(2);
            this.btnParamsGroup3.Name = "btnParamsGroup3";
            this.btnParamsGroup3.Size = new System.Drawing.Size(50, 22);
            this.btnParamsGroup3.TabIndex = 18;
            this.btnParamsGroup3.Text = "发送";
            this.btnParamsGroup3.UseVisualStyleBackColor = true;
            this.btnParamsGroup3.Click += new System.EventHandler(this.btnParamsGroup3_Click);
            // 
            // btnParamsGroup4
            // 
            this.btnParamsGroup4.Location = new System.Drawing.Point(218, 144);
            this.btnParamsGroup4.Margin = new System.Windows.Forms.Padding(2);
            this.btnParamsGroup4.Name = "btnParamsGroup4";
            this.btnParamsGroup4.Size = new System.Drawing.Size(50, 22);
            this.btnParamsGroup4.TabIndex = 19;
            this.btnParamsGroup4.Text = "发送";
            this.btnParamsGroup4.UseVisualStyleBackColor = true;
            this.btnParamsGroup4.Click += new System.EventHandler(this.btnParamsGroup4_Click);
            // 
            // tbk1
            // 
            this.tbk1.Location = new System.Drawing.Point(2, 18);
            this.tbk1.Margin = new System.Windows.Forms.Padding(2);
            this.tbk1.Name = "tbk1";
            this.tbk1.Size = new System.Drawing.Size(50, 21);
            this.tbk1.TabIndex = 0;
            this.tbk1.Text = "0";
            this.tbk1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "k1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "k2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "k3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "k4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "k5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "k6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "k7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "k8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "k9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "k10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(110, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "k11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "k12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 126);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 32;
            this.label13.Text = "k13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(56, 126);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 12);
            this.label14.TabIndex = 33;
            this.label14.Text = "k14";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(110, 126);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "k15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(164, 126);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "k16";
            // 
            // tableLayoutPanelCMD
            // 
            this.tableLayoutPanelCMD.ColumnCount = 2;
            this.tableLayoutPanelCMD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCMD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCMD.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanelCMD.Controls.Add(this.button4, 0, 1);
            this.tableLayoutPanelCMD.Controls.Add(this.button5, 0, 2);
            this.tableLayoutPanelCMD.Controls.Add(this.button6, 0, 3);
            this.tableLayoutPanelCMD.Controls.Add(this.button7, 1, 0);
            this.tableLayoutPanelCMD.Controls.Add(this.button8, 1, 1);
            this.tableLayoutPanelCMD.Controls.Add(this.button9, 1, 2);
            this.tableLayoutPanelCMD.Controls.Add(this.button10, 1, 3);
            this.tableLayoutPanelCMD.Location = new System.Drawing.Point(2, 81);
            this.tableLayoutPanelCMD.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelCMD.Name = "tableLayoutPanelCMD";
            this.tableLayoutPanelCMD.RowCount = 4;
            this.tableLayoutPanelCMD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCMD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCMD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCMD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCMD.Size = new System.Drawing.Size(125, 170);
            this.tableLayoutPanelCMD.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(2, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 38);
            this.button3.TabIndex = 0;
            this.button3.Text = "悬浮";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(2, 44);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 38);
            this.button4.TabIndex = 1;
            this.button4.Text = "记录";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(2, 86);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 38);
            this.button5.TabIndex = 2;
            this.button5.Text = "标定";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(2, 128);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(58, 40);
            this.button6.TabIndex = 3;
            this.button6.Text = "屏蔽 ";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(64, 2);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(59, 38);
            this.button7.TabIndex = 4;
            this.button7.Text = "降落";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(64, 44);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 38);
            this.button8.TabIndex = 5;
            this.button8.Text = "下载";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Location = new System.Drawing.Point(64, 86);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 38);
            this.button9.TabIndex = 6;
            this.button9.Text = "电流";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Location = new System.Drawing.Point(64, 128);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(59, 40);
            this.button10.TabIndex = 7;
            this.button10.Text = "烧写";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnClearAllPoints
            // 
            this.btnClearAllPoints.Location = new System.Drawing.Point(402, 44);
            this.btnClearAllPoints.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearAllPoints.Name = "btnClearAllPoints";
            this.btnClearAllPoints.Size = new System.Drawing.Size(22, 20);
            this.btnClearAllPoints.TabIndex = 7;
            this.btnClearAllPoints.Text = "清";
            this.btnClearAllPoints.UseVisualStyleBackColor = true;
            this.btnClearAllPoints.Click += new System.EventHandler(this.btnClearAllPoints_Click);
            // 
            // btnSelectAllPoints
            // 
            this.btnSelectAllPoints.Location = new System.Drawing.Point(402, 20);
            this.btnSelectAllPoints.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAllPoints.Name = "btnSelectAllPoints";
            this.btnSelectAllPoints.Size = new System.Drawing.Size(22, 20);
            this.btnSelectAllPoints.TabIndex = 6;
            this.btnSelectAllPoints.Text = "全";
            this.btnSelectAllPoints.UseVisualStyleBackColor = true;
            this.btnSelectAllPoints.Click += new System.EventHandler(this.btnSelectAllPoints_Click);
            // 
            // tableLayoutPanelLevitationPoint
            // 
            this.tableLayoutPanelLevitationPoint.ColumnCount = 5;
            this.tableLayoutPanelLevitationPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLevitationPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLevitationPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLevitationPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLevitationPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLevitationPoint.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelLevitationPoint.Controls.Add(this.groupBox5, 4, 0);
            this.tableLayoutPanelLevitationPoint.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanelLevitationPoint.Controls.Add(this.groupBox4, 3, 0);
            this.tableLayoutPanelLevitationPoint.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanelLevitationPoint.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanelLevitationPoint.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelLevitationPoint.Name = "tableLayoutPanelLevitationPoint";
            this.tableLayoutPanelLevitationPoint.RowCount = 1;
            this.tableLayoutPanelLevitationPoint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLevitationPoint.Size = new System.Drawing.Size(398, 74);
            this.tableLayoutPanelLevitationPoint.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(75, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "悬浮架1";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(42, 40);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(30, 16);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(42, 20);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(30, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(5, 40);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(30, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(5, 20);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(30, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox20);
            this.groupBox5.Controls.Add(this.checkBox17);
            this.groupBox5.Controls.Add(this.checkBox19);
            this.groupBox5.Controls.Add(this.checkBox18);
            this.groupBox5.Location = new System.Drawing.Point(318, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(75, 64);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "悬浮架5";
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Checked = true;
            this.checkBox20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox20.Location = new System.Drawing.Point(38, 40);
            this.checkBox20.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(36, 16);
            this.checkBox20.TabIndex = 9;
            this.checkBox20.Text = "20";
            this.checkBox20.UseVisualStyleBackColor = true;
            this.checkBox20.CheckedChanged += new System.EventHandler(this.checkBox20_CheckedChanged);
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Checked = true;
            this.checkBox17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox17.Location = new System.Drawing.Point(4, 20);
            this.checkBox17.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(36, 16);
            this.checkBox17.TabIndex = 6;
            this.checkBox17.Text = "17";
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Checked = true;
            this.checkBox19.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox19.Location = new System.Drawing.Point(38, 20);
            this.checkBox19.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(36, 16);
            this.checkBox19.TabIndex = 8;
            this.checkBox19.Text = "19";
            this.checkBox19.UseVisualStyleBackColor = true;
            this.checkBox19.CheckedChanged += new System.EventHandler(this.checkBox19_CheckedChanged);
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Checked = true;
            this.checkBox18.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox18.Location = new System.Drawing.Point(4, 40);
            this.checkBox18.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(36, 16);
            this.checkBox18.TabIndex = 7;
            this.checkBox18.Text = "18";
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox8);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Location = new System.Drawing.Point(81, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(75, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "悬浮架2";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Location = new System.Drawing.Point(43, 40);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(30, 16);
            this.checkBox8.TabIndex = 9;
            this.checkBox8.Text = "8";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(4, 20);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(30, 16);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(43, 20);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(30, 16);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Text = "7";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(4, 40);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(30, 16);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox16);
            this.groupBox4.Controls.Add(this.checkBox13);
            this.groupBox4.Controls.Add(this.checkBox15);
            this.groupBox4.Controls.Add(this.checkBox14);
            this.groupBox4.Location = new System.Drawing.Point(239, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(75, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "悬浮架4";
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Checked = true;
            this.checkBox16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox16.Location = new System.Drawing.Point(40, 40);
            this.checkBox16.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(36, 16);
            this.checkBox16.TabIndex = 9;
            this.checkBox16.Text = "16";
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Checked = true;
            this.checkBox13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox13.Location = new System.Drawing.Point(4, 20);
            this.checkBox13.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(36, 16);
            this.checkBox13.TabIndex = 6;
            this.checkBox13.Text = "13";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Checked = true;
            this.checkBox15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox15.Location = new System.Drawing.Point(40, 20);
            this.checkBox15.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(36, 16);
            this.checkBox15.TabIndex = 8;
            this.checkBox15.Text = "15";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Checked = true;
            this.checkBox14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox14.Location = new System.Drawing.Point(4, 40);
            this.checkBox14.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(36, 16);
            this.checkBox14.TabIndex = 7;
            this.checkBox14.Text = "14";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox12);
            this.groupBox3.Controls.Add(this.checkBox9);
            this.groupBox3.Controls.Add(this.checkBox11);
            this.groupBox3.Controls.Add(this.checkBox10);
            this.groupBox3.Location = new System.Drawing.Point(160, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(75, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "悬浮架3";
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Checked = true;
            this.checkBox12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox12.Location = new System.Drawing.Point(37, 40);
            this.checkBox12.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(36, 16);
            this.checkBox12.TabIndex = 9;
            this.checkBox12.Text = "12";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox9.Location = new System.Drawing.Point(4, 20);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(30, 16);
            this.checkBox9.TabIndex = 6;
            this.checkBox9.Text = "9";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Checked = true;
            this.checkBox11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox11.Location = new System.Drawing.Point(37, 20);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(36, 16);
            this.checkBox11.TabIndex = 8;
            this.checkBox11.Text = "11";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Checked = true;
            this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox10.Location = new System.Drawing.Point(4, 40);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(36, 16);
            this.checkBox10.TabIndex = 7;
            this.checkBox10.Text = "10";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // toolStrChartNumCtrl
            // 
            this.toolStrChartNumCtrl.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrChartNumCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrChartNumCtrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddChart,
            this.toolStripSeparator2,
            this.btnDelChart});
            this.toolStrChartNumCtrl.Location = new System.Drawing.Point(0, 0);
            this.toolStrChartNumCtrl.Name = "toolStrChartNumCtrl";
            this.toolStrChartNumCtrl.Size = new System.Drawing.Size(26, 346);
            this.toolStrChartNumCtrl.TabIndex = 3;
            this.toolStrChartNumCtrl.Text = "toolStrip1";
            // 
            // btnAddChart
            // 
            this.btnAddChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddChart.Image = global::LevitationHostCanbus.Properties.Resources.add;
            this.btnAddChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddChart.Name = "btnAddChart";
            this.btnAddChart.Size = new System.Drawing.Size(23, 20);
            this.btnAddChart.Text = "+";
            this.btnAddChart.ToolTipText = "AddChart";
            this.btnAddChart.Click += new System.EventHandler(this.toolStrBtnAddChartNum_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(25, 35);
            // 
            // btnDelChart
            // 
            this.btnDelChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelChart.Image = global::LevitationHostCanbus.Properties.Resources.delete;
            this.btnDelChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelChart.Name = "btnDelChart";
            this.btnDelChart.Size = new System.Drawing.Size(23, 20);
            this.btnDelChart.Text = "-";
            this.btnDelChart.ToolTipText = "DelChart";
            this.btnDelChart.Click += new System.EventHandler(this.btnDelChart_Click);
            // 
            // tmrRead
            // 
            this.tmrRead.Interval = 500;
            this.tmrRead.Tick += new System.EventHandler(this.tmrRead_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStripHostCmd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 28);
            this.panel1.TabIndex = 2;
            // 
            // toolStripHostCmd
            // 
            this.toolStripHostCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripHostCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInit,
            this.toolStripSeparator1,
            this.btnLogData,
            this.toolStripSeparator3,
            this.cmbCanPorts,
            this.toolStripSeparator4,
            this.btnMonitor,
            this.toolStripSeparator5,
            this.btnCtrl});
            this.toolStripHostCmd.Location = new System.Drawing.Point(0, 0);
            this.toolStripHostCmd.Name = "toolStripHostCmd";
            this.toolStripHostCmd.Size = new System.Drawing.Size(1028, 28);
            this.toolStripHostCmd.TabIndex = 0;
            this.toolStripHostCmd.Text = "toolStripHostCmd";
            // 
            // btnInit
            // 
            this.btnInit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInit.Image = ((System.Drawing.Image)(resources.GetObject("btnInit.Image")));
            this.btnInit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(62, 25);
            this.btnInit.Text = "打开CAN";
            this.btnInit.ToolTipText = "打开/关闭CAN设备";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // btnLogData
            // 
            this.btnLogData.Image = global::LevitationHostCanbus.Properties.Resources.save_as;
            this.btnLogData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogData.Name = "btnLogData";
            this.btnLogData.Size = new System.Drawing.Size(77, 25);
            this.btnLogData.Text = "LogData";
            this.btnLogData.ToolTipText = "记录数据";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(55, 0, 0, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // cmbCanPorts
            // 
            this.cmbCanPorts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCanPorts.Items.AddRange(new object[] {
            "CAN-0",
            "CAN-1"});
            this.cmbCanPorts.Name = "cmbCanPorts";
            this.cmbCanPorts.Size = new System.Drawing.Size(92, 28);
            this.cmbCanPorts.ToolTipText = "选择CAN设备通道";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Image = global::LevitationHostCanbus.Properties.Resources.lcd_tv_test;
            this.btnMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(52, 25);
            this.btnMonitor.Text = "监视";
            this.btnMonitor.ToolTipText = "打开监视界面";
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // btnCtrl
            // 
            this.btnCtrl.Image = global::LevitationHostCanbus.Properties.Resources.hammer;
            this.btnCtrl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCtrl.Name = "btnCtrl";
            this.btnCtrl.Size = new System.Drawing.Size(52, 25);
            this.btnCtrl.Text = "控制";
            this.btnCtrl.ToolTipText = "打开控制界面";
            this.btnCtrl.Click += new System.EventHandler(this.btnCtrl_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 589);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "悬浮控制";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainform_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainform_FormClosed);
            this.Load += new System.EventHandler(this.mainform_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelCtrlUI.ResumeLayout(false);
            this.panelParamsLog.ResumeLayout(false);
            this.panelParamsLog.PerformLayout();
            this.toolStripParamsLogCmd.ResumeLayout(false);
            this.toolStripParamsLogCmd.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelCMD.ResumeLayout(false);
            this.tableLayoutPanelLevitationPoint.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrChartNumCtrl.ResumeLayout(false);
            this.toolStrChartNumCtrl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripHostCmd.ResumeLayout(false);
            this.toolStripHostCmd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Timer tmrRead;
        private System.Windows.Forms.ToolStrip toolStrChartNumCtrl;
        private System.Windows.Forms.ToolStripButton btnAddChart;
        private System.Windows.Forms.ToolStripButton btnDelChart;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStripHostCmd;
        private System.Windows.Forms.ToolStripButton btnInit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbCanPorts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnLogData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCtrl;
        private System.Windows.Forms.Panel panelCtrlUI;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLevitationPoint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCMD;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnClearAllPoints;
        private System.Windows.Forms.Button btnSelectAllPoints;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbk2;
        private System.Windows.Forms.TextBox tbk3;
        private System.Windows.Forms.TextBox tbk4;
        private System.Windows.Forms.TextBox tbk5;
        private System.Windows.Forms.TextBox tbk6;
        private System.Windows.Forms.TextBox tbk7;
        private System.Windows.Forms.TextBox tbk8;
        private System.Windows.Forms.TextBox tbk9;
        private System.Windows.Forms.TextBox tbk10;
        private System.Windows.Forms.TextBox tbk11;
        private System.Windows.Forms.TextBox tbk12;
        private System.Windows.Forms.TextBox tbk13;
        private System.Windows.Forms.TextBox tbk14;
        private System.Windows.Forms.TextBox tbk15;
        private System.Windows.Forms.TextBox tbk16;
        private System.Windows.Forms.Button btnParamsGroup1;
        private System.Windows.Forms.Button btnParamsGroup2;
        private System.Windows.Forms.Button btnParamsGroup3;
        private System.Windows.Forms.Button btnParamsGroup4;
        private System.Windows.Forms.TextBox tbk1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelParamsLog;
        private System.Windows.Forms.ListBox lbxParamsLog;
        private System.Windows.Forms.ToolStrip toolStripParamsLogCmd;
        private System.Windows.Forms.ToolStripButton btnLogParams;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnRestoreParams;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnOpenParamsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnSaveToFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn S0;
        private System.Windows.Forms.DataGridViewTextBoxColumn S1;
        private System.Windows.Forms.DataGridViewTextBoxColumn S2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn A0;
        private System.Windows.Forms.DataGridViewTextBoxColumn A1;
        private System.Windows.Forms.DataGridViewTextBoxColumn A2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

