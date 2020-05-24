namespace CovidInfoPH
{
    partial class RegionSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionSearchForm));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.formElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuImageButton1 = new Bunifu.UI.WinForms.BunifuImageButton();
            this.searchBarTextBox = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.SuspendLayout();
            // 
            // formElipse
            // 
            this.formElipse.ElipseRadius = 50;
            this.formElipse.TargetControl = this;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.ActiveImage = null;
            this.bunifuImageButton1.AllowAnimations = true;
            this.bunifuImageButton1.AllowBuffering = false;
            this.bunifuImageButton1.AllowZooming = true;
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.ErrorImage")));
            this.bunifuImageButton1.FadeWhenInactive = true;
            this.bunifuImageButton1.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.bunifuImageButton1.Image = global::CovidInfoPH.Properties.Resources.icons8_delete_104px;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.ImageLocation = null;
            this.bunifuImageButton1.ImageMargin = 5;
            this.bunifuImageButton1.ImageSize = new System.Drawing.Size(39, 39);
            this.bunifuImageButton1.ImageZoomSize = new System.Drawing.Size(44, 44);
            this.bunifuImageButton1.InitialImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.InitialImage")));
            this.bunifuImageButton1.Location = new System.Drawing.Point(246, 12);
            this.bunifuImageButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Rotation = 0;
            this.bunifuImageButton1.ShowActiveImage = true;
            this.bunifuImageButton1.ShowCursorChanges = true;
            this.bunifuImageButton1.ShowImageBorders = true;
            this.bunifuImageButton1.ShowSizeMarkers = false;
            this.bunifuImageButton1.Size = new System.Drawing.Size(44, 44);
            this.bunifuImageButton1.TabIndex = 1;
            this.bunifuImageButton1.ToolTipText = "";
            this.bunifuImageButton1.WaitOnLoad = false;
            this.bunifuImageButton1.Zoom = 5;
            this.bunifuImageButton1.ZoomSpeed = 10;
            // 
            // searchBarTextBox
            // 
            this.searchBarTextBox.AcceptsReturn = false;
            this.searchBarTextBox.AcceptsTab = false;
            this.searchBarTextBox.AnimationSpeed = 200;
            this.searchBarTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.searchBarTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.searchBarTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.searchBarTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchBarTextBox.BackgroundImage")));
            this.searchBarTextBox.BorderColorActive = System.Drawing.Color.Silver;
            this.searchBarTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.searchBarTextBox.BorderColorHover = System.Drawing.Color.Silver;
            this.searchBarTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.searchBarTextBox.BorderRadius = 1;
            this.searchBarTextBox.BorderThickness = 2;
            this.searchBarTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.searchBarTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBarTextBox.DefaultFont = new System.Drawing.Font("Proxima Soft", 9.999999F);
            this.searchBarTextBox.DefaultText = "";
            this.searchBarTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.searchBarTextBox.ForeColor = System.Drawing.Color.White;
            this.searchBarTextBox.HideSelection = true;
            this.searchBarTextBox.IconLeft = null;
            this.searchBarTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBarTextBox.IconPadding = 10;
            this.searchBarTextBox.IconRight = global::CovidInfoPH.Properties.Resources.icons8_search_208px_1;
            this.searchBarTextBox.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.searchBarTextBox.Lines = new string[0];
            this.searchBarTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchBarTextBox.MaxLength = 32767;
            this.searchBarTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.searchBarTextBox.Modified = false;
            this.searchBarTextBox.Multiline = false;
            this.searchBarTextBox.Name = "searchBarTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.Silver;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBarTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.searchBarTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.Silver;
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBarTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.searchBarTextBox.OnIdleState = stateProperties4;
            this.searchBarTextBox.PasswordChar = '\0';
            this.searchBarTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.searchBarTextBox.PlaceholderText = "Search country";
            this.searchBarTextBox.ReadOnly = false;
            this.searchBarTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchBarTextBox.SelectedText = "";
            this.searchBarTextBox.SelectionLength = 0;
            this.searchBarTextBox.SelectionStart = 0;
            this.searchBarTextBox.ShortcutsEnabled = true;
            this.searchBarTextBox.Size = new System.Drawing.Size(227, 44);
            this.searchBarTextBox.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Material;
            this.searchBarTextBox.TabIndex = 0;
            this.searchBarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.searchBarTextBox.TextMarginBottom = 0;
            this.searchBarTextBox.TextMarginLeft = 5;
            this.searchBarTextBox.TextMarginTop = 0;
            this.searchBarTextBox.TextPlaceholder = "Search country";
            this.searchBarTextBox.UseSystemPasswordChar = false;
            this.searchBarTextBox.WordWrap = true;
            // 
            // RegionSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(303, 416);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.searchBarTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegionSearchForm";
            this.Text = "RegionSearchForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse formElipse;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox searchBarTextBox;
        private Bunifu.UI.WinForms.BunifuImageButton bunifuImageButton1;
    }
}