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
using System.Drawing;

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
            SetChartColors();
            DisplayGraph();
            DisplayDataGrid();
            RefreshData();
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

        private void SetChartColors()
        {
            GeneralCaseChart.colorSet.Add(Color.FromArgb(152, 135, 143));
            GeneralCaseChart.colorSet.Add(Color.FromArgb(152, 94, 109));
            GeneralCaseChart.colorSet.Add(Color.FromArgb(142, 174, 189));
        }

        private void DisplayDataGrid()
        {
            caseGridView.Rows.Clear();
            for (int i = 0; i < 7; i++)
            {
                caseGridView.Rows.Add(DatePicker.Value.AddDays(i).ToString("d"), Historical[DatePicker.Value.AddDays(i)].Cases,
                Historical[DatePicker.Value.AddDays(i)].Deaths, Historical[DatePicker.Value.AddDays(i)].Recoveries);
            }
        }
        private void DisplayGraph()
        {
            Canvas canvas = new Canvas();
            DataPoint cases = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint deaths = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint recoveries = new DataPoint(BunifuDataViz._type.Bunifu_column);
            
            for(int i = 0; i < 7; i++)
            {
                cases.addLabely(DatePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[DatePicker.Value.AddDays(i)].Cases);
                deaths.addLabely(DatePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[DatePicker.Value.AddDays(i)].Deaths);
                recoveries.addLabely(DatePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[DatePicker.Value.AddDays(i)].Recoveries);
            }

            canvas.addData(cases);
            canvas.addData(recoveries);
            canvas.addData(deaths);
            GeneralCaseChart.Render(canvas);
        }

        private void RefreshData()
        {
           int cases = 0, deaths = 0, recoveries = 0;
           int admitPercentage = Historical[DatePicker.Value.AddDays(6)].Admitted / Historical[DatePicker.Value].Admitted * 100;
           int newCases = Historical[DatePicker.Value.AddDays(6)].Cases - Historical[DatePicker.Value].Cases;
           for (int i = 0; i < caseGridView.Rows.Count; i++)
           {
                cases += Convert.ToInt32(caseGridView[1, i].Value);
                deaths += Convert.ToInt32(caseGridView[2, i].Value);
                recoveries += Convert.ToInt32(caseGridView[3, i].Value);
           }

            casesNum.Text = cases.ToString();
            deathNum.Text = deaths.ToString();
            recovNum.Text = recoveries.ToString();
            admittedNum.Text = admitPercentage.ToString() + "%";
            newCasesNum.Text = newCases.ToString();
            newCasesDesc.Text = "New cases since " + "\n" + DatePicker.Value.DayOfWeek.ToString();
        }
        
        private void FadeOutValues()
        {
            bunifuTransition1.HideSync(caseGridView, true);
            bunifuTransition1.HideSync(GeneralCaseChart, true);
            bunifuTransition1.HideSync(newCasesNum, true);
            bunifuTransition1.HideSync(admittedNum, true);
            bunifuTransition1.HideSync(casesNum, true);
            bunifuTransition1.HideSync(deathNum, true);
            bunifuTransition1.HideSync(recovNum, true);
        }

        private void FadeInValues()
        {
            bunifuTransition1.Show(caseGridView);
            bunifuTransition1.Show(newCasesNum);
            bunifuTransition1.Show(admittedNum);
            bunifuTransition1.Show(casesNum);
            bunifuTransition1.Show(deathNum);
            bunifuTransition1.Show(recovNum);
            bunifuTransition1.Show(GeneralCaseChart);
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            FadeOutValues();
            RefreshData();         
            DisplayGraph();
            DisplayDataGrid();
            FadeInValues();        
        }
    }
}
