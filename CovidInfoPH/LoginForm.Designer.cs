namespace CovidInfoPH
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bunifuElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.bunifuImageButton1 = new Bunifu.UI.WinForms.BunifuImageButton();
            this.authenticateButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.usernameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.passTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // bunifuElipse
            // 
            this.bunifuElipse.ElipseRadius = 60;
            this.bunifuElipse.TargetControl = this;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Proxima Soft", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(42, 37);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(338, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Authenticate to FTP server";
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
            this.bunifuImageButton1.ImageMargin = 15;
            this.bunifuImageButton1.ImageSize = new System.Drawing.Size(22, 22);
            this.bunifuImageButton1.ImageZoomSize = new System.Drawing.Size(37, 37);
            this.bunifuImageButton1.InitialImage = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.InitialImage")));
            this.bunifuImageButton1.Location = new System.Drawing.Point(373, 14);
            this.bunifuImageButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Rotation = 0;
            this.bunifuImageButton1.ShowActiveImage = true;
            this.bunifuImageButton1.ShowCursorChanges = true;
            this.bunifuImageButton1.ShowImageBorders = true;
            this.bunifuImageButton1.ShowSizeMarkers = false;
            this.bunifuImageButton1.Size = new System.Drawing.Size(37, 37);
            this.bunifuImageButton1.TabIndex = 4;
            this.bunifuImageButton1.ToolTipText = "";
            this.bunifuImageButton1.WaitOnLoad = false;
            this.bunifuImageButton1.Zoom = 15;
            this.bunifuImageButton1.ZoomSpeed = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // authenticateButton
            // 
            this.authenticateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.authenticateButton.Animated = true;
            this.authenticateButton.AutoRoundedCorners = true;
            this.authenticateButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.authenticateButton.BorderRadius = 27;
            this.authenticateButton.BorderThickness = 1;
            this.authenticateButton.CheckedState.Parent = this.authenticateButton;
            this.authenticateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authenticateButton.CustomImages.Parent = this.authenticateButton;
            this.authenticateButton.Enabled = false;
            this.authenticateButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
            this.authenticateButton.Font = new System.Drawing.Font("Proxima Soft", 11F);
            this.authenticateButton.ForeColor = System.Drawing.Color.White;
            this.authenticateButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(139)))), ((int)(((byte)(162)))));
            this.authenticateButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(139)))), ((int)(((byte)(162)))));
            this.authenticateButton.HoverState.Parent = this.authenticateButton;
            this.authenticateButton.Image = global::CovidInfoPH.Properties.Resources.icons8_login_208px;
            this.authenticateButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.authenticateButton.Location = new System.Drawing.Point(34, 299);
            this.authenticateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.authenticateButton.Name = "authenticateButton";
            this.authenticateButton.ShadowDecoration.Parent = this.authenticateButton;
            this.authenticateButton.Size = new System.Drawing.Size(355, 56);
            this.authenticateButton.TabIndex = 3;
            this.authenticateButton.Text = "Authenticate";
            this.authenticateButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.authenticateButton.Click += new System.EventHandler(this.authenticateButton_Click);
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Animated = true;
            this.usernameTextBox.BorderColor = System.Drawing.Color.Silver;
            this.usernameTextBox.BorderThickness = 2;
            this.usernameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTextBox.DefaultText = "";
            this.usernameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextBox.DisabledState.Parent = this.usernameTextBox;
            this.usernameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.usernameTextBox.FocusedState.BorderColor = System.Drawing.Color.White;
            this.usernameTextBox.FocusedState.ForeColor = System.Drawing.Color.White;
            this.usernameTextBox.FocusedState.Parent = this.usernameTextBox;
            this.usernameTextBox.Font = new System.Drawing.Font("Proxima Soft", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.Silver;
            this.usernameTextBox.HoverState.BorderColor = System.Drawing.Color.LightGray;
            this.usernameTextBox.HoverState.ForeColor = System.Drawing.Color.LightGray;
            this.usernameTextBox.HoverState.Parent = this.usernameTextBox;
            this.usernameTextBox.IconLeft = global::CovidInfoPH.Properties.Resources.icons8_user_account_208px;
            this.usernameTextBox.IconLeftSize = new System.Drawing.Size(25, 25);
            this.usernameTextBox.Location = new System.Drawing.Point(34, 131);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PasswordChar = '\0';
            this.usernameTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.usernameTextBox.PlaceholderText = "Username/Email";
            this.usernameTextBox.SelectedText = "";
            this.usernameTextBox.ShadowDecoration.Parent = this.usernameTextBox;
            this.usernameTextBox.Size = new System.Drawing.Size(355, 46);
            this.usernameTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.usernameTextBox.TabIndex = 5;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.passTextBox_TextChanged);
            // 
            // passTextBox
            // 
            this.passTextBox.Animated = true;
            this.passTextBox.BorderColor = System.Drawing.Color.Silver;
            this.passTextBox.BorderThickness = 2;
            this.passTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passTextBox.DefaultText = "";
            this.passTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTextBox.DisabledState.Parent = this.passTextBox;
            this.passTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.passTextBox.FocusedState.BorderColor = System.Drawing.Color.White;
            this.passTextBox.FocusedState.ForeColor = System.Drawing.Color.White;
            this.passTextBox.FocusedState.Parent = this.passTextBox;
            this.passTextBox.Font = new System.Drawing.Font("Proxima Soft", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTextBox.ForeColor = System.Drawing.Color.Silver;
            this.passTextBox.HoverState.BorderColor = System.Drawing.Color.LightGray;
            this.passTextBox.HoverState.ForeColor = System.Drawing.Color.LightGray;
            this.passTextBox.HoverState.Parent = this.passTextBox;
            this.passTextBox.IconLeft = global::CovidInfoPH.Properties.Resources.icons8_password_208px;
            this.passTextBox.IconLeftSize = new System.Drawing.Size(25, 25);
            this.passTextBox.IconRight = global::CovidInfoPH.Properties.Resources.icons8_hide_512px;
            this.passTextBox.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.passTextBox.IconRightOffset = new System.Drawing.Point(5, 0);
            this.passTextBox.IconRightSize = new System.Drawing.Size(25, 25);
            this.passTextBox.Location = new System.Drawing.Point(34, 202);
            this.passTextBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '•';
            this.passTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.passTextBox.PlaceholderText = "Password";
            this.passTextBox.SelectedText = "";
            this.passTextBox.ShadowDecoration.Parent = this.passTextBox;
            this.passTextBox.Size = new System.Drawing.Size(355, 46);
            this.passTextBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.passTextBox.TabIndex = 6;
            this.passTextBox.TextChanged += new System.EventHandler(this.passTextBox_TextChanged);
            this.passTextBox.IconRightClick += new System.EventHandler(this.passTextBox_IconRightClick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(423, 450);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.authenticateButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authenticate to FTP server";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2Button authenticateButton;
        private Bunifu.UI.WinForms.BunifuImageButton bunifuImageButton1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        public Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox usernameTextBox;
        private Guna.UI2.WinForms.Guna2TextBox passTextBox;
    }
}