using System;
using System.Windows.Forms;

using Bunifu.UI.WinForms.BunifuAnimatorNS;

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
                    bunifuTransition1.ShowSync(continueButton, true, Animation.Transparent);

                    timer.Stop();
                }
            };
        }

        private void OnShowForm(object sender, EventArgs e)
        {
            bunifuFormFadeTransition.ShowAsyc(this);
            PlayAnimation();
        }

        private void OnClickClose(object sender, EventArgs e)
        {
            Close();
        }
    }
}
