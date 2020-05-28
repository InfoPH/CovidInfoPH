using Syncfusion.Licensing;
using System;
using System.Windows.Forms;

namespace CovidInfoPH
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            SyncfusionLicenseProvider.RegisterLicense("MTMzN0AzMTM4MmUzMTJlMzBYTml4RFZ2ZmVsRmlNbmdCcDNjVG9naS9qWEFzVXJvL0FkSmlJbnkzVHV3PQ==");
            EO.WebBrowser.Runtime.AddLicense(Properties.Resources.webLicense);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
