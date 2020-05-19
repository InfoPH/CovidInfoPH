using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SheetToObjects.Lib;
using SheetToObjects.Lib.FluentConfiguration;
using SheetToObjects.Adapters.GoogleSheets;
using Bunifu.DataViz.WinForms;
using CovidInfoPH.Models;
using Task = System.Threading.Tasks.Task;


namespace CovidInfoPH
{
    public partial class MainForm : Form
    {
        public List<Patient> Patients;
        public Dictionary<DateTime, HistoricalInfo> Historical;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataFromSheetAsync();
            DisplayGraph();
        }

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
            Patients = sheetMapper.Map<Patient>(dohDataDropSheet.Result).ParsedModels.Select(o => o.Value)
                .OrderBy(o => o.DateConfirmed).ToList();
            //Map Historical
            List<HistoricalInfo> historicalInfos = sheetMapper.Map<HistoricalInfo>(historicalSheet.Result).ParsedModels
                .Select(o => o.Value).ToList();
            List<DateTime> historicalDates = historicalSheet.Result.Rows
                .Where(o => DateTime.TryParse((string)o.Cells[0].Value, out _) && o.Cells.Count != 1)
                .Select(o => DateTime.Parse((string)o.Cells[0].Value)).ToList();
            Historical = Enumerable.Range(0, historicalDates.Count)
                .ToDictionary(i => historicalDates[i], i => historicalInfos[i]);

        }

        private void DisplayGraph()
        {
            Canvas canvas = new Canvas();
            DataPoint data = new DataPoint(BunifuDataViz._type.Bunifu_line);

            int caseDayCount = 0;

            for (int j = 0; j < 10; j++)
            {
                DateTime currentDate = Patients[caseDayCount].DateConfirmed;
                //Count all patients that are confirmed on the current date
                caseDayCount += Patients.Count(patient => patient.DateConfirmed == currentDate);

                data.addLabely(Patients[caseDayCount].DateConfirmed.ToString("d"), caseDayCount);
                canvas.addData(data);

            }
            bunifuDataViz1.Render(canvas);
        }
    }
}
