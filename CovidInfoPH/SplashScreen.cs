using System;
using System.Windows.Forms;

namespace CovidInfoPH
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void OnShowForm(object sender, EventArgs e)
        {
            bunifuFormFadeTransition.ShowAsyc(this);           
        }

        public void OnClickClose(object sender, EventArgs e)
        {
            Close();
        }

        private void logoTimer_Tick(object sender, EventArgs e)
        {

        }

        private void nameTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
