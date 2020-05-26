using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidInfoPH
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iacImageButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://iacademy.edu.ph/");
        }

        private void dohImageButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.doh.gov.ph/");
        }
    }
}
