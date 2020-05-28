using System;
using System.Windows.Forms;

namespace CovidInfoPH
{
    public partial class LoginForm : Form
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Username = string.Empty;
            Password = string.Empty;
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void passTextBox_IconRightClick(object sender, EventArgs e)
        {
            if (passTextBox.PasswordChar == '•')
            {
                passTextBox.IconRight = Properties.Resources.icons8_eye_512px_1;
                passTextBox.PasswordChar = '\0';
            }
            else
            {
                passTextBox.IconRight = Properties.Resources.icons8_hide_512px;
                passTextBox.PasswordChar = '•';
            }
        }

        private void passTextBox_TextChanged(object sender, EventArgs e)
        {
            authenticateButton.Enabled = usernameTextBox.Text != string.Empty && passTextBox.Text != string.Empty;
        }

        private void authenticateButton_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passTextBox.Text;
            Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
