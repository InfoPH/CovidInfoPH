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
            logoTimer.Start();          
        }

        public void OnClickClose(object sender, EventArgs e)
        {
            Close();
        }

        private void logoTimer_Tick(object sender, EventArgs e)
        {
            logoTimer.Stop();
            bunifuTransition1.ShowSync(logoPictureBox, false, BunifuAnimatorNS.Animation.VertBlind);
            nameTimer.Start();
        }

        private void nameTimer_Tick(object sender, EventArgs e)
        {
            nameTimer.Stop();
            bunifuTransition1.ShowSync(name);
            showLogo.Start();
        }

        private void showLogo_Tick(object sender, EventArgs e)
        {
            showLogo.Stop();
            bunifuTransition1.HideSync(name);
            bunifuTransition1.HideSync(logoPictureBox);
            bunifuTransition1.ShowSync(meetLabel);
            bunifuTransition1.ShowSync(arizala);
            bunifuTransition1.ShowSync(arizalaName);
            bunifuTransition1.ShowSync(braulio);
            bunifuTransition1.ShowSync(braulioName);
            bunifuTransition1.ShowSync(itang);
            bunifuTransition1.ShowSync(itangName);
            showFace.Start();
        }

        private void showFace_Tick(object sender, EventArgs e)
        {
            showFace.Stop();
            bunifuTransition1.HideSync(arizala);
            bunifuTransition1.HideSync(arizalaName);
            bunifuTransition1.HideSync(braulio);
            bunifuTransition1.HideSync(braulioName);
            bunifuTransition1.HideSync(itang);
            bunifuTransition1.HideSync(itangName);
            bunifuTransition1.ShowSync(martinez);
            bunifuTransition1.ShowSync(martinezName);
            bunifuTransition1.ShowSync(nino);
            bunifuTransition1.ShowSync(ninoName);
            bunifuTransition1.ShowSync(ortega);
            bunifuTransition1.ShowSync(ortegaName);
        }
    }
}
