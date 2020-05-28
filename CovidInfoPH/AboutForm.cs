using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CovidInfoPH
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void iacImageButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://iacademy.edu.ph/");
        }

        private void dohImageButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.doh.gov.ph/");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
