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
using System.Drawing;
using System.Globalization;

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

        #region Methods

        #region Load form & chart
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataFromSheetAsync();
            SetChartColors();
            DisplayGraph();
            DisplayDataGrid();
            RefreshData();
        }
        private void SetChartColors()
        {
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 135, 143));
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 94, 109));
            generalCaseChart.colorSet.Add(Color.FromArgb(142, 174, 189));
        }
        #endregion

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
        #endregion

        #region Display data
        private void DisplayDataGrid()
        {
            caseGridView.Rows.Clear();
            for (int i = -6; i < 1; i++)
            {
                caseGridView.Rows.Add($"{datePicker.Value.AddDays(i) : MM-dd-yyyy}", Historical[datePicker.Value.AddDays(i)].Cases,
                Historical[datePicker.Value.AddDays(i)].Deaths, Historical[datePicker.Value.AddDays(i)].Recoveries);
            }
        }
        private void DisplayGraph()
        {
            Canvas canvas = new Canvas();
            DataPoint cases = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint deaths = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint recoveries = new DataPoint(BunifuDataViz._type.Bunifu_column);

            for (int i = -6; i < 1; i++)
            {
                cases.addLabely(datePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[datePicker.Value.AddDays(i)].Cases);
                deaths.addLabely(datePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[datePicker.Value.AddDays(i)].Deaths);
                recoveries.addLabely(datePicker.Value.AddDays(i).DayOfWeek.ToString(), Historical[datePicker.Value.AddDays(i)].Recoveries);
            }

            canvas.addData(cases);
            canvas.addData(recoveries);
            canvas.addData(deaths);
            generalCaseChart.Render(canvas);
        }

        private string SetMonth(int month)
        {
            if (month == 1)
            {
                return "January";
            }
            else if (month == 2)
            {
                return "February";
            }
            else if (month == 3)
            {
                return "March";
            }
            else if (month == 4)
            {
                return "April";
            }
            else if (month == 5)
            {
                return "May";
            }
            else return " ";
        }
        private void RefreshData()
        {
            string month = SetMonth(datePicker.Value.Month);
            double cases = Historical[datePicker.Value].Cases;
            double deaths = Historical[datePicker.Value].Deaths;
            double recoveries = Historical[datePicker.Value].Recoveries;
            int newCases = Historical[datePicker.Value].Cases - Historical[datePicker.Value.AddDays(-6)].Cases;
            casesNum.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum.Text = deaths.ToString(CultureInfo.InvariantCulture);
            caseNum2.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum2.Text = deaths.ToString(CultureInfo.InvariantCulture);
            recovNum.Text = recoveries.ToString(CultureInfo.InvariantCulture);
            newCasesNum.Text = newCases.ToString();
            deathPercent.Value = Convert.ToInt32(deaths / cases * 100);
            weeklyReport.Text = $"Weekly Report as of {month} {datePicker.Value.Day}, 2020";
            newCasesDesc.Text = $"New cases since\n{datePicker.Value.AddDays(-6).DayOfWeek}";
        }
        #endregion

        #region Transtion data

        private void FadeOutValues()
        {
            datePicker.Enabled = false;
            bunifuTransition2.HideSync(generalCaseChart);
            bunifuTransition1.HideSync(caseGridView);
            bunifuTransition1.HideSync(newCasesNum);
            bunifuTransition1.HideSync(deathNum2);
            bunifuTransition1.HideSync(caseNum2);
            bunifuTransition1.HideSync(casesNum);
            bunifuTransition1.HideSync(deathNum);
            bunifuTransition1.HideSync(recovNum);
        }

        private void FadeInValues()
        {
            bunifuTransition1.ShowSync(recovNum);
            bunifuTransition1.ShowSync(deathNum);
            bunifuTransition1.ShowSync(casesNum);
            bunifuTransition1.ShowSync(caseNum2);
            bunifuTransition1.ShowSync(deathNum2);
            bunifuTransition1.ShowSync(newCasesNum);
            bunifuTransition1.ShowSync(caseGridView);
            bunifuTransition2.ShowSync(generalCaseChart);
           
        }
        #endregion

        #region Input events

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {         
            FadeOutValues();
            RefreshData();
            DisplayGraph();
            DisplayDataGrid();
            FadeInValues();
            datePicker.Enabled = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = false;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton3.FadeWhenInactive = true;
            DashBoard.SetPage(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = false;
            bunifuImageButton3.FadeWhenInactive = true;
            DashBoard.SetPage(1);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton3.FadeWhenInactive = false;
            DashBoard.SetPage(2);
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        #endregion

        #endregion

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
