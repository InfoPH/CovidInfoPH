using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bunifu.DataViz.WinForms;
using CovidInfoPH.Models;
using System.Drawing;
using System.Globalization;
using Syncfusion.Windows.Forms.Maps;
using Syncfusion.UI.Xaml.Maps;

namespace CovidInfoPH
{
    public partial class MainForm : Form
    {
        internal static List<Patient> Patients;
        internal static Dictionary<DateTime, HistoricalInfo> Historical;
        public Dictionary<string, Models.RegionInfo> Regions = new Dictionary<string, Models.RegionInfo>();

        public MainForm()
        {
            Form splash = new SplashForm();
            splash.Show();
            splash.Closed += ShowForm;

            InitializeComponent();
        }

        #region Methods

        #region Load form & chart
        private void ShowForm(object sender, EventArgs e)
        {
            latestData.Text = $"Latest data fetched: {Historical.Keys.Last():MMMM dd, yyyy}";
            ShowInTaskbar = true;
            bunifuFormFadeTransition1.ShowAsyc(this);
            SetChartColors();
            DisplayGraph();
            InitializeRegions();
            InitializeMap();
            DisplayDataGrid();
            RefreshData();
        }
        private void SetChartColors()
        {
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 135, 143));
            generalCaseChart.colorSet.Add(Color.FromArgb(142, 174, 189));
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 94, 109));
        }
        #endregion

        #region Display data
        private void DisplayDataGrid()
        {
            caseGridView.Rows.Clear();
            for (int i = -6; i < 1; i++)
            {
                caseGridView.Rows.Add($"{datePicker.Value.AddDays(i): MM-dd-yyyy}", Historical[datePicker.Value.AddDays(i)].Cases,
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

        private void RefreshData()
        {
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
            weeklyReport.Text = $"Weekly Report as of {datePicker.Value:MMMM dd, yyyy}";
            newCasesDesc.Text = $"New cases since\n{datePicker.Value.AddDays(-6).DayOfWeek}";
        }

        private void InitializeRegions()
        {
            List<string> regions = Patients.Select(p => p.Region).Where(p => !string.IsNullOrEmpty(p)).Distinct().ToList();

            foreach (string region in regions)
            {
                Models.RegionInfo regionInfo = new Models.RegionInfo();
                List<Patient> localPatients = Patients.Where(p => p.Region == region).ToList();

                regionInfo.Cases = localPatients.Count;
                regionInfo.Deaths = localPatients.Count(p => p.DateDied != null);
                regionInfo.Recoveries = localPatients.Count(p => p.DateRecovered != null);

                Regions.Add(region, regionInfo);
            }
        }

        private void InitializeMap()
        {
            ItemSource item = new ItemSource(Regions);
            ShapeFileLayer philippineShape = new ShapeFileLayer
            {
                Uri = @"Resources\ph-regions\ph-regions-2015.shp",
                ShapeSetting = { SelectedShapeColor = "#8EAEBD" },
                ItemSource = item.Regions,
                ShapeIDPath = "Region",
                ShapeIDTableField = "REGION",
                EnableSelection = true,
                ShowMapItem = true
            };
            philippineShape.ShapeSetting.FillSetting.AutoFillColors = false;
            philippineShape.ShapeSetting.ShapeColorValuePath = "Cases";
            philippineShape.ShapeSetting.FillSetting.ColorMappings = new System.Collections.ObjectModel.ObservableCollection<ColorMapping>();
            philippineShape.ShapeSetting.FillSetting.ColorMappings.Add(new RangeColorMapping { From = 4, To = 22, Color = System.Drawing.Color.FromArgb(255, 193, 0) });
            philippineShape.ShapeSetting.FillSetting.ColorMappings.Add(new RangeColorMapping { From = 28, To = 37, Color = System.Drawing.Color.FromArgb(255, 154, 0) });
            philippineShape.ShapeSetting.FillSetting.ColorMappings.Add(new RangeColorMapping { From = 47, To = 69, Color = System.Drawing.Color.FromArgb(255, 116, 0) });
            philippineShape.ShapeSetting.FillSetting.ColorMappings.Add(new RangeColorMapping { From = 107, To = 237, Color = System.Drawing.Color.FromArgb(255, 77, 0) });
            philippineShape.ShapeSetting.FillSetting.ColorMappings.Add(new RangeColorMapping { From = 481, To = 9000, Color = System.Drawing.Color.FromArgb(255, 0, 0) });
            philippinesMap.MapBackgroundBrush = new SolidBrush(Color.FromArgb(20, 30, 39));
            philippinesMap.ShapeSelected += PhilippinesMap_ShapeSelected; //Hook the ShapeSelected event
            philippinesMap.Layers.Add(philippineShape);
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
            DashBoard.SetPage(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = false;
            DashBoard.SetPage(1);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void PhilippinesMap_ShapeSelected(object sender, ShapeSelectedEventArgs e)
        {
           //Adding transitions makes it laggy ://
            foreach (PhRegion region in e.Data)
            {
                double deaths = Convert.ToDouble(Regions[region.Region].Deaths);
                double cases = Convert.ToDouble(Regions[region.Region].Cases);
                regionLabel.Text = region.Region;
                regionCases.Text = Regions[region.Region].Cases.ToString();
                regionDeaths.Text = Regions[region.Region].Deaths.ToString();
                regionRecoveries.Text = Regions[region.Region].Recoveries.ToString();
                regionCases2.Text = Regions[region.Region].Cases.ToString();
                regionDeaths2.Text = Regions[region.Region].Deaths.ToString();
                regionCircleProgress.Value = Convert.ToInt32(deaths/cases * 100);
            }
           

            #endregion

            #endregion
        }
    }
}
