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

        public void PlayAnimation()
        {
            var count = 0;
            var timer = new Timer { Interval = 1000, Enabled = true };

            timer.Tick += delegate
            {
                count++;

                if (count == 11)
                {
                    pictureBox1.Enabled = false;
                    timer.Stop();
                }
            };
        }

        private void OnShowForm(object sender, EventArgs e)
        {
            bunifuFormFadeTransition.ShowAsyc(this);
            PlayAnimation();
        }

        public void OnClickClose(object sender, EventArgs e)
        {
            Close();
        }
    }
}
