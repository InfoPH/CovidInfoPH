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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DatePicker = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.GeneralCaseChart = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.bunifuTransition2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // DatePicker
            // 
            this.DatePicker.BorderRadius = 1;
            this.DatePicker.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.DatePicker.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuTransition2.SetDecoration(this.DatePicker, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.DatePicker, BunifuAnimatorNS.DecorationType.None);
            this.DatePicker.DisabledColor = System.Drawing.Color.Gray;
            this.DatePicker.DisplayWeekNumbers = false;
            this.DatePicker.DPHeight = 0;
            this.DatePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DatePicker.FillDatePicker = false;
            this.DatePicker.ForeColor = System.Drawing.Color.Purple;
            this.DatePicker.Icon = ((System.Drawing.Image)(resources.GetObject("DatePicker.Icon")));
            this.DatePicker.IconColor = System.Drawing.Color.Purple;
            this.DatePicker.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.DatePicker.Location = new System.Drawing.Point(1091, 16);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DatePicker.MinimumSize = new System.Drawing.Size(244, 32);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(244, 32);
            this.DatePicker.TabIndex = 19;
            this.DatePicker.Value = new System.DateTime(2020, 5, 12, 0, 0, 0, 0);
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
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
            // GeneralCaseChart
            // 
            this.GeneralCaseChart.animationEnabled = false;
            this.GeneralCaseChart.AxisLineColor = System.Drawing.Color.LightGray;
            this.GeneralCaseChart.AxisXFontColor = System.Drawing.Color.Gray;
            this.GeneralCaseChart.AxisXGridColor = System.Drawing.Color.Gray;
            this.GeneralCaseChart.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GeneralCaseChart.AxisYFontColor = System.Drawing.Color.Gray;
            this.GeneralCaseChart.AxisYGridColor = System.Drawing.Color.Gray;
            this.GeneralCaseChart.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GeneralCaseChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.GeneralCaseChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuTransition2.SetDecoration(this.GeneralCaseChart, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this.GeneralCaseChart, BunifuAnimatorNS.DecorationType.None);
            this.GeneralCaseChart.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralCaseChart.Location = new System.Drawing.Point(298, 16);
            this.GeneralCaseChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GeneralCaseChart.Name = "GeneralCaseChart";
            this.GeneralCaseChart.Size = new System.Drawing.Size(1037, 470);
            this.GeneralCaseChart.TabIndex = 18;
            this.GeneralCaseChart.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.GeneralCaseChart.Title = "";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1350, 691);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.GeneralCaseChart);
            this.bunifuTransition2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuDatePicker DatePicker;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private Bunifu.DataViz.WinForms.BunifuDataViz GeneralCaseChart;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition2;
    }
}

