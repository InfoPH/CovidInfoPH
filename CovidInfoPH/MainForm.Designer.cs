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
            this.bunifuDataViz1 = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bunifuDataViz1
            // 
            this.bunifuDataViz1.animationEnabled = false;
            this.bunifuDataViz1.AxisLineColor = System.Drawing.Color.LightGray;
            this.bunifuDataViz1.AxisXFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisXGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz1.AxisYFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisYGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDataViz1.Location = new System.Drawing.Point(112, 63);
            this.bunifuDataViz1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuDataViz1.Name = "bunifuDataViz1";
            this.bunifuDataViz1.Size = new System.Drawing.Size(506, 253);
            this.bunifuDataViz1.TabIndex = 18;
            this.bunifuDataViz1.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.bunifuDataViz1.Title = "";
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.bunifuDataViz1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.DataViz.WinForms.BunifuDataViz bunifuDataViz1;
        private System.Windows.Forms.Timer timer1;
    }
}

