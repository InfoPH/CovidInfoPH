namespace CovidInfoPH
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.GraphPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.caseGridView = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recoveries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recovNum = new Bunifu.UI.WinForms.BunifuLabel();
            this.deathNum = new Bunifu.UI.WinForms.BunifuLabel();
            this.casesNum = new Bunifu.UI.WinForms.BunifuLabel();
            this.admitted = new Bunifu.UI.WinForms.BunifuLabel();
            this.admittedDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.newCasesDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.GeneralCaseChart = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.newCasesNum = new Bunifu.UI.WinForms.BunifuLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.casesDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.deathsDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.recovDesc = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPictureBox3 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuPictureBox2 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.DatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuPictureBox4 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuPictureBox5 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.GraphPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caseGridView)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.bunifuTransition1.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.bunifuTransition1.DefaultAnimation = animation2;
            this.bunifuTransition1.Interval = 15;
            // 
            // bunifuTransition2
            // 
            this.bunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.bunifuTransition2.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuTransition2.DefaultAnimation = animation1;
            this.bunifuTransition2.Interval = 15;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.bunifuLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuLabel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(706, 686);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(0, 0);
            this.bunifuLabel1.TabIndex = 21;
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // GraphPanel
            // 
            this.GraphPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.GraphPanel.Controls.Add(this.GeneralCaseChart);
            this.bunifuTransition2.SetDecoration(this.GraphPanel, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.GraphPanel, BunifuAnimatorNS.DecorationType.None);
            this.GraphPanel.Location = new System.Drawing.Point(99, 118);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.ShadowDecoration.Parent = this.GraphPanel;
            this.GraphPanel.Size = new System.Drawing.Size(1332, 397);
            this.GraphPanel.TabIndex = 22;
            // 
            // caseGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.caseGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.caseGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.caseGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.caseGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.caseGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.caseGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.caseGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.caseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.caseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Cases,
            this.Deaths,
            this.Recoveries});
            this.bunifuTransition1.SetDecoration(this.caseGridView, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.caseGridView, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.caseGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.caseGridView.DoubleBuffered = true;
            this.caseGridView.EnableHeadersVisualStyles = false;
            this.caseGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.caseGridView.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.caseGridView.HeaderForeColor = System.Drawing.Color.White;
            this.caseGridView.Location = new System.Drawing.Point(3, 3);
            this.caseGridView.Name = "caseGridView";
            this.caseGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.caseGridView.RowHeadersVisible = false;
            this.caseGridView.RowHeadersWidth = 51;
            this.caseGridView.RowTemplate.Height = 24;
            this.caseGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.caseGridView.Size = new System.Drawing.Size(502, 247);
            this.caseGridView.TabIndex = 49;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Cases
            // 
            this.Cases.HeaderText = "Cases";
            this.Cases.MinimumWidth = 6;
            this.Cases.Name = "Cases";
            this.Cases.ReadOnly = true;
            // 
            // Deaths
            // 
            this.Deaths.HeaderText = "Deaths";
            this.Deaths.MinimumWidth = 6;
            this.Deaths.Name = "Deaths";
            this.Deaths.ReadOnly = true;
            // 
            // Recoveries
            // 
            this.Recoveries.HeaderText = "Recoveries";
            this.Recoveries.MinimumWidth = 6;
            this.Recoveries.Name = "Recoveries";
            this.Recoveries.ReadOnly = true;
            // 
            // recovNum
            // 
            this.recovNum.AutoEllipsis = false;
            this.recovNum.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.recovNum, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.recovNum, BunifuAnimatorNS.DecorationType.None);
            this.recovNum.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recovNum.ForeColor = System.Drawing.Color.White;
            this.recovNum.Location = new System.Drawing.Point(977, 712);
            this.recovNum.Name = "recovNum";
            this.recovNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.recovNum.Size = new System.Drawing.Size(48, 35);
            this.recovNum.TabIndex = 41;
            this.recovNum.Text = "100";
            this.recovNum.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.recovNum.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // deathNum
            // 
            this.deathNum.AutoEllipsis = false;
            this.deathNum.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.deathNum, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.deathNum, BunifuAnimatorNS.DecorationType.None);
            this.deathNum.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathNum.ForeColor = System.Drawing.Color.White;
            this.deathNum.Location = new System.Drawing.Point(1281, 712);
            this.deathNum.Name = "deathNum";
            this.deathNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deathNum.Size = new System.Drawing.Size(48, 35);
            this.deathNum.TabIndex = 42;
            this.deathNum.Text = "100";
            this.deathNum.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.deathNum.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // casesNum
            // 
            this.casesNum.AutoEllipsis = false;
            this.casesNum.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.casesNum, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.casesNum, BunifuAnimatorNS.DecorationType.None);
            this.casesNum.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casesNum.ForeColor = System.Drawing.Color.White;
            this.casesNum.Location = new System.Drawing.Point(685, 712);
            this.casesNum.Name = "casesNum";
            this.casesNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.casesNum.Size = new System.Drawing.Size(93, 35);
            this.casesNum.TabIndex = 43;
            this.casesNum.Text = "100000";
            this.casesNum.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.casesNum.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // admitted
            // 
            this.admitted.AutoEllipsis = false;
            this.admitted.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.admitted, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.admitted, BunifuAnimatorNS.DecorationType.None);
            this.admitted.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admitted.ForeColor = System.Drawing.Color.White;
            this.admitted.Location = new System.Drawing.Point(171, 33);
            this.admitted.Name = "admitted";
            this.admitted.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.admitted.Size = new System.Drawing.Size(54, 35);
            this.admitted.TabIndex = 44;
            this.admitted.Text = "90%";
            this.admitted.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.admitted.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // admittedDesc
            // 
            this.admittedDesc.AutoEllipsis = false;
            this.admittedDesc.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.admittedDesc, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.admittedDesc, BunifuAnimatorNS.DecorationType.None);
            this.admittedDesc.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admittedDesc.ForeColor = System.Drawing.Color.White;
            this.admittedDesc.Location = new System.Drawing.Point(171, 74);
            this.admittedDesc.Name = "admittedDesc";
            this.admittedDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.admittedDesc.Size = new System.Drawing.Size(130, 35);
            this.admittedDesc.TabIndex = 45;
            this.admittedDesc.Text = "Admitted";
            this.admittedDesc.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.admittedDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // newCasesDesc
            // 
            this.newCasesDesc.AutoEllipsis = false;
            this.newCasesDesc.AutoSize = false;
            this.newCasesDesc.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.newCasesDesc, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.newCasesDesc, BunifuAnimatorNS.DecorationType.None);
            this.newCasesDesc.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCasesDesc.ForeColor = System.Drawing.Color.White;
            this.newCasesDesc.Location = new System.Drawing.Point(149, 74);
            this.newCasesDesc.Name = "newCasesDesc";
            this.newCasesDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.newCasesDesc.Size = new System.Drawing.Size(222, 68);
            this.newCasesDesc.TabIndex = 46;
            this.newCasesDesc.Text = "New Cases \r\nThis Week";
            this.newCasesDesc.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.newCasesDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // GeneralCaseChart
            // 
            this.GeneralCaseChart.animationEnabled = false;
            this.GeneralCaseChart.AxisLineColor = System.Drawing.Color.LightGray;
            this.GeneralCaseChart.AxisXFontColor = System.Drawing.Color.White;
            this.GeneralCaseChart.AxisXGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.GeneralCaseChart.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GeneralCaseChart.AxisYFontColor = System.Drawing.Color.White;
            this.GeneralCaseChart.AxisYGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.GeneralCaseChart.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GeneralCaseChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.GeneralCaseChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition2.SetDecoration(this.GeneralCaseChart, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.GeneralCaseChart, BunifuAnimatorNS.DecorationType.None);
            this.GeneralCaseChart.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralCaseChart.ForeColor = System.Drawing.Color.White;
            this.GeneralCaseChart.Location = new System.Drawing.Point(3, 0);
            this.GeneralCaseChart.Margin = new System.Windows.Forms.Padding(4);
            this.GeneralCaseChart.Name = "GeneralCaseChart";
            this.GeneralCaseChart.Size = new System.Drawing.Size(1328, 393);
            this.GeneralCaseChart.TabIndex = 39;
            this.GeneralCaseChart.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.GeneralCaseChart.Title = "";
            // 
            // newCasesNum
            // 
            this.newCasesNum.AutoEllipsis = false;
            this.newCasesNum.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.newCasesNum, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.newCasesNum, BunifuAnimatorNS.DecorationType.None);
            this.newCasesNum.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCasesNum.ForeColor = System.Drawing.Color.White;
            this.newCasesNum.Location = new System.Drawing.Point(149, 33);
            this.newCasesNum.Name = "newCasesNum";
            this.newCasesNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.newCasesNum.Size = new System.Drawing.Size(93, 35);
            this.newCasesNum.TabIndex = 43;
            this.newCasesNum.Text = "100000";
            this.newCasesNum.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.newCasesNum.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.caseGridView);
            this.bunifuTransition2.SetDecoration(this.guna2Panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.guna2Panel1, BunifuAnimatorNS.DecorationType.None);
            this.guna2Panel1.Location = new System.Drawing.Point(99, 529);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(502, 247);
            this.guna2Panel1.TabIndex = 50;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.guna2Panel2.Controls.Add(this.newCasesNum);
            this.guna2Panel2.Controls.Add(this.newCasesDesc);
            this.guna2Panel2.Controls.Add(this.bunifuPictureBox1);
            this.bunifuTransition2.SetDecoration(this.guna2Panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.guna2Panel2, BunifuAnimatorNS.DecorationType.None);
            this.guna2Panel2.Location = new System.Drawing.Point(616, 529);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(394, 175);
            this.guna2Panel2.TabIndex = 40;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.guna2Panel3.Controls.Add(this.admitted);
            this.guna2Panel3.Controls.Add(this.admittedDesc);
            this.guna2Panel3.Controls.Add(this.bunifuPictureBox2);
            this.bunifuTransition2.SetDecoration(this.guna2Panel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.guna2Panel3, BunifuAnimatorNS.DecorationType.None);
            this.guna2Panel3.Location = new System.Drawing.Point(1032, 529);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(398, 175);
            this.guna2Panel3.TabIndex = 40;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.bunifuLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuLabel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuLabel2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel2.Location = new System.Drawing.Point(99, 12);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(184, 35);
            this.bunifuLabel2.TabIndex = 43;
            this.bunifuLabel2.Text = "COVIDinfo-PH";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // guna2Separator1
            // 
            this.bunifuTransition1.SetDecoration(this.guna2Separator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition2.SetDecoration(this.guna2Separator1, BunifuAnimatorNS.DecorationType.None);
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(102, 53);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(137, 10);
            this.guna2Separator1.TabIndex = 51;
            // 
            // casesDesc
            // 
            this.casesDesc.AutoEllipsis = false;
            this.casesDesc.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.casesDesc, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.casesDesc, BunifuAnimatorNS.DecorationType.None);
            this.casesDesc.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casesDesc.ForeColor = System.Drawing.Color.White;
            this.casesDesc.Location = new System.Drawing.Point(685, 746);
            this.casesDesc.Name = "casesDesc";
            this.casesDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.casesDesc.Size = new System.Drawing.Size(81, 35);
            this.casesDesc.TabIndex = 43;
            this.casesDesc.Text = "Cases";
            this.casesDesc.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.casesDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // deathsDesc
            // 
            this.deathsDesc.AutoEllipsis = false;
            this.deathsDesc.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.deathsDesc, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.deathsDesc, BunifuAnimatorNS.DecorationType.None);
            this.deathsDesc.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathsDesc.ForeColor = System.Drawing.Color.White;
            this.deathsDesc.Location = new System.Drawing.Point(977, 746);
            this.deathsDesc.Name = "deathsDesc";
            this.deathsDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deathsDesc.Size = new System.Drawing.Size(95, 35);
            this.deathsDesc.TabIndex = 43;
            this.deathsDesc.Text = "Deaths";
            this.deathsDesc.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.deathsDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // recovDesc
            // 
            this.recovDesc.AutoEllipsis = false;
            this.recovDesc.CursorType = null;
            this.bunifuTransition2.SetDecoration(this.recovDesc, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.recovDesc, BunifuAnimatorNS.DecorationType.None);
            this.recovDesc.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recovDesc.ForeColor = System.Drawing.Color.White;
            this.recovDesc.Location = new System.Drawing.Point(1281, 746);
            this.recovDesc.Name = "recovDesc";
            this.recovDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.recovDesc.Size = new System.Drawing.Size(149, 35);
            this.recovDesc.TabIndex = 43;
            this.recovDesc.Text = "Recoveries";
            this.recovDesc.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.recovDesc.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPictureBox3
            // 
            this.bunifuPictureBox3.AllowFocused = false;
            this.bunifuPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox3.BorderRadius = 50;
            this.bunifuTransition2.SetDecoration(this.bunifuPictureBox3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPictureBox3, BunifuAnimatorNS.DecorationType.None);
 
            this.bunifuPictureBox3.IsCircle = true;
            this.bunifuPictureBox3.Location = new System.Drawing.Point(607, 710);
            this.bunifuPictureBox3.Name = "bunifuPictureBox3";
            this.bunifuPictureBox3.Size = new System.Drawing.Size(75, 75);
            this.bunifuPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox3.TabIndex = 52;
            this.bunifuPictureBox3.TabStop = false;
            this.bunifuPictureBox3.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // bunifuPictureBox2
            // 
            this.bunifuPictureBox2.AllowFocused = false;
            this.bunifuPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuPictureBox2.BorderRadius = 50;
            this.bunifuTransition2.SetDecoration(this.bunifuPictureBox2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPictureBox2, BunifuAnimatorNS.DecorationType.None);

            this.bunifuPictureBox2.IsCircle = true;
            this.bunifuPictureBox2.Location = new System.Drawing.Point(17, 11);
            this.bunifuPictureBox2.Name = "bunifuPictureBox2";
            this.bunifuPictureBox2.Size = new System.Drawing.Size(153, 153);
            this.bunifuPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox2.TabIndex = 48;
            this.bunifuPictureBox2.TabStop = false;
            this.bunifuPictureBox2.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuPictureBox1.BorderRadius = 50;
            this.bunifuTransition2.SetDecoration(this.bunifuPictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPictureBox1, BunifuAnimatorNS.DecorationType.None);
          
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(-3, 11);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(153, 153);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 48;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // DatePicker
            // 
            this.DatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.DatePicker.BorderRadius = 1;
            this.DatePicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(107)))));
            this.DatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.DatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition2.SetDecoration(this.DatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.DatePicker, BunifuAnimatorNS.DecorationType.None);
            this.DatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.DatePicker.DisplayWeekNumbers = false;
            this.DatePicker.DPHeight = 0;
            this.DatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DatePicker.FillDatePicker = false;
            this.DatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(107)))));
            this.DatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("DatePicker.Icon")));
            this.DatePicker.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(107)))));
            this.DatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.DatePicker.Location = new System.Drawing.Point(1181, 71);
            this.DatePicker.MinimumSize = new System.Drawing.Size(250, 32);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(250, 32);
            this.DatePicker.TabIndex = 40;
            this.DatePicker.Value = new System.DateTime(2020, 5, 12, 0, 0, 0, 0);
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // bunifuPictureBox4
            // 
            this.bunifuPictureBox4.AllowFocused = false;
            this.bunifuPictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox4.BorderRadius = 50;
            this.bunifuTransition2.SetDecoration(this.bunifuPictureBox4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPictureBox4, BunifuAnimatorNS.DecorationType.None);
         
            this.bunifuPictureBox4.IsCircle = true;
            this.bunifuPictureBox4.Location = new System.Drawing.Point(896, 712);
            this.bunifuPictureBox4.Name = "bunifuPictureBox4";
            this.bunifuPictureBox4.Size = new System.Drawing.Size(75, 75);
            this.bunifuPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox4.TabIndex = 52;
            this.bunifuPictureBox4.TabStop = false;
            this.bunifuPictureBox4.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // bunifuPictureBox5
            // 
            this.bunifuPictureBox5.AllowFocused = false;
            this.bunifuPictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox5.BorderRadius = 50;
            this.bunifuTransition2.SetDecoration(this.bunifuPictureBox5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.bunifuPictureBox5, BunifuAnimatorNS.DecorationType.None);
         
            this.bunifuPictureBox5.IsCircle = true;
            this.bunifuPictureBox5.Location = new System.Drawing.Point(1200, 710);
            this.bunifuPictureBox5.Name = "bunifuPictureBox5";
            this.bunifuPictureBox5.Size = new System.Drawing.Size(75, 75);
            this.bunifuPictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox5.TabIndex = 52;
            this.bunifuPictureBox5.TabStop = false;
            this.bunifuPictureBox5.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1452, 793);
            this.Controls.Add(this.bunifuPictureBox5);
            this.Controls.Add(this.bunifuPictureBox4);
            this.Controls.Add(this.bunifuPictureBox3);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.recovNum);
            this.Controls.Add(this.deathNum);
            this.Controls.Add(this.recovDesc);
            this.Controls.Add(this.deathsDesc);
            this.Controls.Add(this.casesDesc);
            this.Controls.Add(this.casesNum);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.bunifuLabel1);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GraphPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.caseGridView)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid caseGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cases;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recoveries;
        private Bunifu.UI.WinForms.BunifuDatePicker DatePicker;
        private Bunifu.UI.WinForms.BunifuLabel recovNum;
        private Bunifu.UI.WinForms.BunifuLabel deathNum;
        private Bunifu.UI.WinForms.BunifuLabel newCasesNum;
        private Bunifu.UI.WinForms.BunifuLabel casesNum;
        private Bunifu.UI.WinForms.BunifuLabel admitted;
        private Bunifu.UI.WinForms.BunifuLabel admittedDesc;
        private Bunifu.UI.WinForms.BunifuLabel newCasesDesc;
        private Guna.UI2.WinForms.Guna2Panel GraphPanel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.DataViz.WinForms.BunifuDataViz GeneralCaseChart;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox2;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel recovDesc;
        private Bunifu.UI.WinForms.BunifuLabel deathsDesc;
        private Bunifu.UI.WinForms.BunifuLabel casesDesc;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox5;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox4;
    }
}

