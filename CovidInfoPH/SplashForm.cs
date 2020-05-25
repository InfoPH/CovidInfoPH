using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CovidInfoPH.Models;
using SheetToObjects.Adapters.GoogleSheets;
using SheetToObjects.Lib;
using SheetToObjects.Lib.FluentConfiguration;

namespace CovidInfoPH
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        #region Fetch data
        private async Task LoadDataFromSheetAsync()
        {
            //create config for sheetMapper
            SheetMapper sheetMapper = new SheetMapper()
                .AddConfigFor<Patient>(cfg => cfg
                    .MapColumn(column => column.WithHeader("Age").IsRequired().MapTo(p => p.Age))
                    .MapColumn(column =>
                        column.WithHeader("DateRepConf").IsRequired().UsingFormat("dd-MM-yy")
                            .MapTo(p => p.DateConfirmed))
                    .MapColumn(column =>
                        column.WithHeader("DateRecover").UsingFormat("dd-MM-yy").WithDefaultValue<DateTime?>(null)
                            .MapTo(p => p.DateRecovered))
                    .MapColumn(column => column.WithHeader("DateDied").UsingFormat("dd-MM-yy")
                        .WithDefaultValue<DateTime?>(null).MapTo(p => p.DateDied))
                    .MapColumn(column => column.WithHeader("RegionRes").MapTo(p => p.Region))
                    .MapColumn(column => column.WithHeader("ProvRes").MapTo(p => p.Province))
                    .MapColumn(column => column.WithHeader("ProvCityRes").MapTo(p => p.City)))
                .AddConfigFor<HistoricalInfo>(cfg => cfg
                    .MapColumn(column => column.WithHeader("Cases").IsRequired().MapTo(p => p.Cases))
                    .MapColumn(column => column.WithHeader("Deaths").IsRequired().MapTo(p => p.Deaths))
                    .MapColumn(column => column.WithHeader("Recoveries").IsRequired().MapTo(p => p.Recoveries))
                    .MapColumn(column => column.WithHeader("Admitted").IsRequired().MapTo(p => p.Admitted)));

            GoogleSheetAdapter adapter = new GoogleSheetAdapter();
            //Get sheet data
            Task<Sheet> dohDataDropSheet = adapter.GetAsync("16g_PUxKYMC0XjeEKF6FPUBq2-pFgmTkHoj5lbVrGLhE", "'DOH Data Drop'!A1:ZZ", "AIzaSyCkssJLOPN-8WdM3HX_8N3kdq62_9hn_wA");
            Task<Sheet> historicalSheet = adapter.GetAsync("16g_PUxKYMC0XjeEKF6FPUBq2-pFgmTkHoj5lbVrGLhE",
                "'Historical'!A1:ZZ", "AIzaSyCkssJLOPN-8WdM3HX_8N3kdq62_9hn_wA");
            await Task.WhenAll(dohDataDropSheet, historicalSheet);
            //Map Patients
            MainForm.Patients = sheetMapper.Map<Patient>(dohDataDropSheet.Result).ParsedModels.Select(o => o.Value)
                .OrderBy(o => o.DateConfirmed).ToList();
            //Negros Island Region (NIR) data update
            foreach (Patient patient in MainForm.Patients.Where(p => p.Province == "Negros Occidental" || p.Province == "Negros Oriental"))
            {
                patient.Region = "Negros Island Region (NIR)";
            }

            InitializeRegions();

            //Map Historical
            List<HistoricalInfo> historicalInfos = sheetMapper.Map<HistoricalInfo>(historicalSheet.Result).ParsedModels
                .Select(o => o.Value).ToList();
            List<DateTime> historicalDates = historicalSheet.Result.Rows
                .Where(o => DateTime.TryParse((string)o.Cells[0].Value, out _) && o.Cells.Count != 1)
                .Select(o => DateTime.Parse((string)o.Cells[0].Value)).ToList();
            MainForm.Historical = Enumerable.Range(0, historicalDates.Count)
                .ToDictionary(i => historicalDates[i], i => historicalInfos[i]);

        }

        private void InitializeRegions()
        {
            List<string> regions = MainForm.Patients.Select(p => p.Region).Where(p => !string.IsNullOrEmpty(p)).Distinct()
                .ToList();
            List<DateTime> dates = MainForm.Patients.Select(p => p.DateConfirmed).Distinct().ToList();
            dates.Sort();
            MainForm.Regions = new Dictionary<string, Dictionary<DateTime, RegionDateInfo>>();
            foreach (string region in regions)
            {

                List<Patient> localPatients = MainForm.Patients.Where(p => p.Region == region).ToList();
                Dictionary<DateTime, RegionDateInfo> regionHistorical = new Dictionary<DateTime, RegionDateInfo>();
                RegionDateInfo regionDateInfo = new RegionDateInfo()
                {
                    Cases = 0,
                    Deaths = 0,
                    Recoveries = 0
                };

                foreach (DateTime date in dates)
                {
                    regionDateInfo.Cases += localPatients.Count(p => p.DateConfirmed == date);
                    regionDateInfo.Deaths += localPatients.Count(p => p.DateDied == date);
                    regionDateInfo.Recoveries += localPatients.Count(p => p.DateRecovered == date);
                    regionHistorical.Add(date, regionDateInfo);


                }
                MainForm.Regions.Add(region, regionHistorical);
            }
        }

        #endregion

        private void OnShowForm(object sender, EventArgs e)
        {
            logoTimer.Start();
        }

        public void OnClickClose(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private async void showFace_Tick(object sender, EventArgs e)
        {
            showFace.Stop();

            bunifuTransition1.HideSync(itang);
            bunifuTransition1.HideSync(itangName);

            bunifuTransition1.HideSync(braulio);
            bunifuTransition1.HideSync(braulioName);

            bunifuTransition1.HideSync(arizala);
            bunifuTransition1.HideSync(arizalaName);

            bunifuTransition1.ShowSync(martinez);
            bunifuTransition1.ShowSync(martinezName);

            bunifuTransition1.ShowSync(nino);
            bunifuTransition1.ShowSync(ninoName);

            bunifuTransition1.ShowSync(ortega);
            bunifuTransition1.ShowSync(ortegaName);

            bunifuTransition1.ShowSync(guna2WinProgressIndicator1);

            await LoadDataFromSheetAsync();

            bunifuTransition1.Hide(martinez);
            bunifuTransition1.Hide(martinezName);

            bunifuTransition1.Hide(nino);
            bunifuTransition1.Hide(ninoName);

            bunifuTransition1.Hide(ortega);
            bunifuTransition1.Hide(ortegaName);

            bunifuTransition1.Hide(guna2WinProgressIndicator1);
            bunifuTransition1.HideSync(meetLabel);

            Close();
        }

        private void nino_Click(object sender, EventArgs e)
        {

        }

        private void ortega_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void itang_Click(object sender, EventArgs e)
        {

        }

        private void arizala_Click(object sender, EventArgs e)
        {

        }

        private void braulio_Click(object sender, EventArgs e)
        {

        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void arizalaName_Click(object sender, EventArgs e)
        {

        }

        private void martinezName_Click(object sender, EventArgs e)
        {

        }

        private void braulioName_Click(object sender, EventArgs e)
        {

        }

        private void ninoName_Click(object sender, EventArgs e)
        {

        }

        private void itangName_Click(object sender, EventArgs e)
        {

        }

        private void ortegaName_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2WinProgressIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void meetLabel_Click(object sender, EventArgs e)
        {

        }

        private void martinez_Click(object sender, EventArgs e)
        {

        }
    }
}
