using System;
using System.Windows.Forms;
using Syncfusion.Licensing;

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
            SyncfusionLicenseProvider.RegisterLicense(
                "MTMzN0AzMTM4MmUzMTJlMzBYTml4RFZ2ZmVsRmlNbmdCcDNjVG9naS9qWEFzVXJvL0FkSmlJbnkzVHV3PQ==");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
