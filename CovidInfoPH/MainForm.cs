using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using BunifuAnimatorNS;
using Syncfusion.Windows.Forms.Maps;
using Syncfusion.UI.Xaml.Maps;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using CovidInfoPH.Models;
using DevExpress.Data.Filtering;
using DevExpress.XtraCharts;

namespace CovidInfoPH
{
    public partial class MainForm : Form
    {
        internal static List<Patient> Patients;
        internal static Dictionary<DateTime, HistoricalInfo> Historical;
        internal static Dictionary<string, Dictionary<DateTime, RegionDateInfo>> Regions;

        public MainForm()
        {
            Form splash = new SplashForm();
            splash.Show();
            splash.Closed += ShowForm;

            InitializeComponent();
            webControl1.WebView.BeforeNavigate += WebView_BeforeNavigate;
        }

        #region Methods

        #region Load form & chart
        private DataTable CreateChartData(List<DateTime> dates, List<int> numbers)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Argument", typeof(DateTime));
            dt.Columns.Add("Value", typeof(int));

            for (int i = 0; i < dates.Count; i++)
            {
                var row = dt.NewRow();
                row["Argument"] = dates[i];
                row["Value"] = numbers[i];
                dt.Rows.Add(row);
            }

            return dt;
        }

        private void LoadDashBoardChart()
        {
            dashBoardChart.Series["Cases"].DataSource = CreateChartData(Historical.Keys.ToList(),
            Historical.Values.Select(p => p.Cases).ToList());
            dashBoardChart.Series["Deaths"].DataSource = CreateChartData(Historical.Keys.ToList(),
                Historical.Values.Select(p => p.Deaths).ToList());
            dashBoardChart.Series["Recoveries"].DataSource = CreateChartData(Historical.Keys.ToList(),
                Historical.Values.Select(p => p.Recoveries).ToList());
        }

        private void LoadDashBoardChart(string region)
        {
            dashBoardChart.Series["Cases"].DataSource = CreateChartData(Regions[region].Keys.ToList(),
                Regions[region].Values.Select(p => p.Cases).ToList());
            dashBoardChart.Series["Deaths"].DataSource = CreateChartData(Regions[region].Keys.ToList(),
                Regions[region].Values.Select(p => p.Deaths).ToList());
            dashBoardChart.Series["Recoveries"].DataSource = CreateChartData(Regions[region].Keys.ToList(),
                Regions[region].Values.Select(p => p.Recoveries).ToList());
        }

        private void ShowForm(object sender, EventArgs e)
        {
            LoadDashBoardChart();
            latestData.Text = $"Latest data fetched: {Historical.Keys.Max(d => d):MMMM dd, yyyy}";
            ShowInTaskbar = true;
            bunifuFormFadeTransition1.ShowAsyc(this);
            DisplayGraph();
            InitializeMap();
            DisplayDataGrid();
            RefreshData();
        }
        #endregion

        #region Heat Map Color Generation
        public Color CalculateHeatMapColor(decimal value, decimal min, decimal max)
        {
            //Minimum color - khaki
            //Maximum color - red
            decimal val = (value - min) / (max - min);
            const int a = 255;
            byte r = Convert.ToByte(Color.Khaki.R * (1 + (1 - (decimal)Color.Red.R / Color.Khaki.R) * val));
            byte g = Convert.ToByte(Color.Khaki.G * (1 - val));
            byte b = Convert.ToByte(Color.Khaki.B * (1 - val));
            return Color.FromArgb(a, r, g, b);
        }
        #endregion

        #region Display data
        private void DisplayDataGrid()
        {
            caseGridView.Rows.Clear();
            if (monthRadioButton.Checked)
            {
                DateTime latestDate = Historical.Where(p => p.Key >=
                    new
                        DateTime(
                            datePicker
                                .Value
                                .Year,
                            datePicker
                                .Value
                                .Month,
                            1) && p.Key <=
                    new DateTime(
                        datePicker
                            .Value
                            .Year,
                        datePicker
                            .Value
                            .Month,
                        DateTime.DaysInMonth(
                            datePicker
                                .Value
                                .Year,
                            datePicker.Value
                                .Month))).Aggregate((i1, i2) => i1.Key > i2.Key ? i1 : i2).Key;
                foreach (KeyValuePair<DateTime, HistoricalInfo> historicalDateInfo in Historical.Where(d => d.Key >= new DateTime(datePicker.Value.Year, datePicker.Value.Month, 1) && d.Key <= latestDate).Reverse())
                {
                    caseGridView.Rows.Add($"{historicalDateInfo.Key:MM-dd-yyyy}", historicalDateInfo.Value.Cases,
                        historicalDateInfo.Value.Deaths, historicalDateInfo.Value.Recoveries);
                }
            }
            else
            {
                foreach (KeyValuePair<DateTime, HistoricalInfo> historicalDateInfo in Historical.Where(h => h.Key > datePicker.Value.AddDays(-7) && h.Key <= datePicker.Value).Reverse())
                {
                    caseGridView.Rows.Add($"{historicalDateInfo.Key:MM-dd-yyyy}", historicalDateInfo.Value.Cases,
                        historicalDateInfo.Value.Deaths, historicalDateInfo.Value.Recoveries);
                }
            }
        }

        private void DisplayDataGrid(string region)
        {
            caseGridView.Rows.Clear();
            if (monthRadioButton.Checked)
            {
                DateTime latestDate = Regions[region].Where(p => p.Key >=
                    new
                        DateTime(
                            datePicker
                                .Value
                                .Year,
                            datePicker
                                .Value
                                .Month,
                            1) && p.Key <=
                    new DateTime(
                        datePicker
                            .Value
                            .Year,
                        datePicker
                            .Value
                            .Month,
                        DateTime.DaysInMonth(
                            datePicker
                                .Value
                                .Year,
                            datePicker.Value
                                .Month))).Aggregate((i1, i2) => i1.Key > i2.Key ? i1 : i2).Key;

                foreach (KeyValuePair<DateTime, RegionDateInfo> regionInfo in Regions[region].Where(r => r.Key >=
                                                                                                         new DateTime(
                                                                                                                 datePicker
                                                                                                                     .Value
                                                                                                                     .Year,
                                                                                                                 datePicker
                                                                                                                     .Value
                                                                                                                     .Month,
                                                                                                                 1)
                                                                                                           &&
                                                                                                         r.Key <=
                                                                                                        latestDate).Reverse())
                {
                    caseGridView.Rows.Add($"{regionInfo.Key:MM-dd-yyyy}", regionInfo.Value.Cases,
                        regionInfo.Value.Deaths, regionInfo.Value.Recoveries);
                }
            }
            else
            {
                foreach (KeyValuePair<DateTime, RegionDateInfo> regionInfo in Regions[region]
                    .Where(r => r.Key > datePicker.Value.AddDays(-7) && r.Key <= datePicker.Value).Reverse())
                {
                    caseGridView.Rows.Add($"{regionInfo.Key:MM-dd-yyyy}", regionInfo.Value.Cases,
                        regionInfo.Value.Deaths, regionInfo.Value.Recoveries);
                }
            }
        }

        private void RefreshData()
        {
            double cases;
            double deaths;
            double recoveries;
            int newCases;

            if (monthRadioButton.Checked)
            {
                HistoricalInfo latestDate = Historical.Where(p => p.Key >=
                    new
                        DateTime(
                            datePicker
                                .Value
                                .Year,
                            datePicker
                                .Value
                                .Month,
                            1) && p.Key <=
                    new DateTime(
                        datePicker
                            .Value
                            .Year,
                        datePicker
                            .Value
                            .Month,
                        DateTime.DaysInMonth(
                            datePicker
                                .Value
                                .Year,
                            datePicker.Value
                                .Month))).Aggregate((i1, i2) => i1.Key > i2.Key ? i1 : i2).Value;

                cases = latestDate.Cases;
                deaths = latestDate.Deaths;
                recoveries = latestDate.Recoveries;
                newCases = latestDate.Cases - Historical[
                               new DateTime(datePicker.Value.Year, datePicker.Value.Month, 1).AddDays(-1)].Cases;
                weeklyReport.Text = $"{datePicker.Value:MMMM yyyy} Report";
                newCasesDesc.Text = "New cases this \nmonth";
            }
            else
            {
                cases = Historical[datePicker.Value].Cases;
                deaths = Historical[datePicker.Value].Deaths;
                recoveries = Historical[datePicker.Value].Recoveries;
                newCases = Historical[datePicker.Value].Cases - Historical[datePicker.Value.AddDays(-6)].Cases;
                weeklyReport.Text = $"Weekly Report as of {datePicker.Value:d}";
                newCasesDesc.Text = $"New cases since\n{datePicker.Value.AddDays(-6).DayOfWeek}";
            }

            casesNum.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum.Text = deaths.ToString(CultureInfo.InvariantCulture);
            caseNum2.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum2.Text = deaths.ToString(CultureInfo.InvariantCulture);
            recovNum.Text = recoveries.ToString(CultureInfo.InvariantCulture);
            newCasesNum.Text = newCases.ToString();
            deathPercent.Value = Convert.ToInt32(deaths / cases * 100);

        }

        private void RefreshData(string region)
        {
            double cases;
            double deaths;
            double recoveries;
            int newCases;
            if (monthRadioButton.Checked)
            {
                RegionDateInfo latestDayData = Regions[region].Where(p => p.Key >=
                    new
                        DateTime(
                            datePicker
                                .Value
                                .Year,
                            datePicker
                                .Value
                                .Month,
                            1) && p.Key <=
                    new DateTime(
                        datePicker
                            .Value
                            .Year,
                        datePicker
                            .Value
                            .Month,
                        DateTime.DaysInMonth(
                            datePicker
                                .Value
                                .Year,
                            datePicker.Value
                                .Month))).Aggregate((i1, i2) => i1.Key > i2.Key ? i1 : i2).Value;
                cases = latestDayData.Cases;
                deaths = latestDayData.Deaths;
                recoveries = latestDayData.Recoveries;
                newCases = latestDayData.Cases -
                           Regions[region][new DateTime(datePicker.Value.Year, datePicker.Value.Month, 1).AddDays(-1)]
                               .Cases;
                weeklyReport.Text = $"{datePicker.Value:MMMM yyyy} Report";
                newCasesDesc.Text = "New cases this \nmonth";
            }
            else
            {
                cases = Regions[region][datePicker.Value].Cases;
                deaths = Regions[region][datePicker.Value].Deaths;
                recoveries = Regions[region][datePicker.Value].Recoveries;
                newCases = Regions[region][datePicker.Value].Cases - Regions[region][datePicker.Value.AddDays(-6)].Cases;
                weeklyReport.Text = $"Weekly Report as of {datePicker.Value:d}";
                newCasesDesc.Text = $"New cases since\n{datePicker.Value.AddDays(-6).DayOfWeek}";
            }
            casesNum.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum.Text = deaths.ToString(CultureInfo.InvariantCulture);
            caseNum2.Text = cases.ToString(CultureInfo.InvariantCulture);
            deathNum2.Text = deaths.ToString(CultureInfo.InvariantCulture);
            recovNum.Text = recoveries.ToString(CultureInfo.InvariantCulture);
            newCasesNum.Text = newCases.ToString();
            deathPercent.Value = Convert.ToInt32(deaths / cases * 100);

        }

        private void DisplayGraph()
        {
            if (monthRadioButton.Checked)
            {
                CriteriaOperator oneMonth = new BinaryOperator("Argument",
                                                new DateTime(datePicker.Value.Year, datePicker.Value.Month, 1),
                                                BinaryOperatorType.GreaterOrEqual) &
                                            new BinaryOperator("Argument",
                                                new DateTime(datePicker.Value.Year,
                                                    datePicker.Value.Month, DateTime.DaysInMonth(datePicker.Value.Year,
                                                        datePicker.Value.Month)),
                                                BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Cases"].FilterCriteria = oneMonth;
                dashBoardChart.Series["Deaths"].FilterCriteria = oneMonth;
                dashBoardChart.Series["Recoveries"].FilterCriteria = oneMonth;

            }
            else
            {
                dashBoardChart.Series["Cases"].FilterCriteria =
                    new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                    new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Deaths"].FilterCriteria =
                    new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                    new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Recoveries"].FilterCriteria =
                    new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                    new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
            }
        }

        private void RefreshDashboardPage()
        {

            FadeOutValues();
            if (selectedRegionlabel.Text.Substring(
                selectedRegionlabel.Text.IndexOf(':') + 2) != "All")
            {
                RefreshData(RegionSearchForm.SearchResult);
                DisplayGraph();
                DisplayDataGrid(RegionSearchForm.SearchResult);
            }
            else
            {
                RefreshData();
                DisplayGraph();
                DisplayDataGrid();
            }

            FadeInValues();
            datePicker.Enabled = true;
        }
        #endregion

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
            List<int> values = item.Regions.Select(r => r.Cases).ToList();
            ObservableCollection<ColorMapping> colors = new ObservableCollection<ColorMapping>(values.Select(c =>
                new EqualColorMapping { Value = c, Color = CalculateHeatMapColor(c, values.Min(), values.Max()) }));

            philippineShape.ShapeSetting.FillSetting.ColorMappings = colors;
            philippinesMap.MapBackgroundBrush = new SolidBrush(Color.FromArgb(20, 30, 39));
            philippinesMap.Layers.Add(philippineShape);
        }

        #region Transtion data
        private void FadeOutValues()
        {
            datePicker.Enabled = false;
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
            datePicker.Enabled = true;
            bunifuTransition1.ShowSync(recovNum);
            bunifuTransition1.ShowSync(deathNum);
            bunifuTransition1.ShowSync(casesNum);
            bunifuTransition1.ShowSync(caseNum2);
            bunifuTransition1.ShowSync(deathNum2);
            bunifuTransition1.ShowSync(newCasesNum);
            bunifuTransition1.ShowSync(caseGridView);

        }
        #endregion

        #region Create Report
        private void SetStyles(out PdfCellStyle altStyle, out PdfCellStyle defStyle, out PdfCellStyle headerStyle)
        {
            PdfFont font = new PdfTrueTypeFont(new Font("Century Gothic", 12f), false);
            PdfFont boldFont = new PdfTrueTypeFont(new Font("Century Gothic", 22f, FontStyle.Bold), false);
            PdfPen borderPen = new PdfPen(PdfBrushes.Black) { Width = 0 };

            //AltStyle
            altStyle = new PdfCellStyle
            {
                Font = font,
                BackgroundBrush = new PdfSolidBrush(new PdfColor(192, 201, 219)),
                BorderPen = borderPen
            };

            //DefStyle
            defStyle = new PdfCellStyle
            {
                Font = font,
                BackgroundBrush = PdfBrushes.White,
                BorderPen = borderPen,
                StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle)
            };

            //HeaderStyle
            headerStyle = new PdfCellStyle(boldFont, PdfBrushes.White, PdfPens.DarkBlue)
            {
                BackgroundBrush = new PdfSolidBrush(Color.FromArgb(33, 67, 126)),
                StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle)
            };
        }

        private void SetData(ref DataTable table)
        {
            DateTime latestDate = Patients[Patients.Count - 1].DateConfirmed;
            table.Clear();
            table.Columns.Add("Date");
            table.Columns.Add("Cases");
            table.Columns.Add("Deaths");
            table.Columns.Add("Recoveries");
            //Header
            DataRow header = table.NewRow();
            header["Date"] = "Date";
            header["Cases"] = "Cases";
            header["Deaths"] = "Deaths";
            header["Recoveries"] = "Recoveries";
            table.Rows.Add(header);

            //FirstRow
            DataRow date1 = table.NewRow();
            date1["Date"] = latestDate.AddDays(-6);
            date1["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-6)].Cases;
            date1["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-6)].Deaths;
            date1["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-6)].Recoveries;
            table.Rows.Add(date1);

            DataRow date2 = table.NewRow();
            date2["Date"] = latestDate.AddDays(-5);
            date2["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-5)].Cases;
            date2["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-5)].Deaths;
            date2["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-5)].Recoveries;
            table.Rows.Add(date2);

            DataRow date3 = table.NewRow();
            date3["Date"] = latestDate.AddDays(-4);
            date3["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-4)].Cases;
            date3["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-4)].Deaths;
            date3["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-4)].Recoveries;
            table.Rows.Add(date3);

            DataRow date4 = table.NewRow();
            date4["Date"] = latestDate.AddDays(-3);
            date4["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-3)].Cases;
            date4["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-3)].Deaths;
            date4["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-3)].Recoveries;
            table.Rows.Add(date4);

            DataRow date5 = table.NewRow();
            date5["Date"] = latestDate.AddDays(-2);
            date5["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-2)].Cases;
            date5["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-2)].Deaths;
            date5["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-2)].Recoveries;
            table.Rows.Add(date5);

            DataRow date6 = table.NewRow();
            date6["Date"] = latestDate.AddDays(-1);
            date6["Cases"] = Regions[regionLabel.Text][latestDate.AddDays(-1)].Cases;
            date6["Deaths"] = Regions[regionLabel.Text][latestDate.AddDays(-1)].Deaths;
            date6["Recoveries"] = Regions[regionLabel.Text][latestDate.AddDays(-1)].Recoveries;
            table.Rows.Add(date6);

            DataRow date7 = table.NewRow();
            date7["Date"] = latestDate;
            date7["Cases"] = Regions[regionLabel.Text][latestDate].Cases;
            date7["Deaths"] = Regions[regionLabel.Text][latestDate].Deaths;
            date7["Recoveries"] = Regions[regionLabel.Text][latestDate].Recoveries;
            table.Rows.Add(date7);
        }

        private string SetImage()
        {
            string regionText = regionLabel.Text;
            if (regionText.IndexOf(':') != -1) regionText = regionText.Substring(0, regionText.IndexOf(':'));
            else if (regionText.IndexOf('(') != -1) regionText = regionText.Substring(0, (regionText.IndexOf('(') - 1));
            return regionText;
        }

        #endregion

        #region Input events

        #region Dashboard options changed
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshDashboardPage();
        }

        private void monthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (monthRadioButton.Checked)
            {
                datePicker.Format = DateTimePickerFormat.Custom;
                bunifuTransition1.Hide(label10, false, Animation.HorizSlide);
                foreach (Series series in dashBoardChart.Series)
                {
                    series.ChangeView(ViewType.StackedArea);
                }
            }
            else if (weekRadioButton.Checked)
            {
                datePicker.Format = DateTimePickerFormat.Long;
                bunifuTransition1.Show(label10, false, Animation.HorizSlide);
                foreach (Series series in dashBoardChart.Series)
                {
                    series.ChangeView(ViewType.Bar);
                }
            }

            RefreshDashboardPage();
        }

        private void searchRegionButton_Click(object sender, EventArgs e)
        {
            var searchButtonLocation = PointToScreen(searchRegionButton.Location);
            RegionSearchForm searchBar = new RegionSearchForm
            {
                Location = searchButtonLocation,
                ShowInTaskbar = false
            };
            searchBar.guna2AnimateWindow1.SetAnimateWindow(searchBar);
            searchBar.ShowDialog();
            if (!string.IsNullOrEmpty(RegionSearchForm.SearchResult) && selectedRegionlabel.Text.Substring(
                selectedRegionlabel.Text.IndexOf(':') + 2) != RegionSearchForm.SearchResult)
            {
                selectedRegionlabel.Text = RegionSearchForm.SearchResult != "All"
                    ? $"Selected Region: {RegionSearchForm.SearchResult}"
                    : "Selected Region: All";
                RefreshDashboardPage();
            }
        }
        #endregion

        #region Switch pages
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = false;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton4.FadeWhenInactive = true;
            bunifuTransition1.ShowSync(searchRegionButton);
            bunifuTransition1.ShowSync(selectedRegionlabel);
            CovidInfoPages.SetPage(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = false;
            bunifuImageButton4.FadeWhenInactive = true;
            bunifuTransition1.HideSync(searchRegionButton);
            bunifuTransition1.HideSync(selectedRegionlabel);
            CovidInfoPages.SetPage(1);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton4.FadeWhenInactive = false;
            bunifuTransition1.HideSync(searchRegionButton);
            bunifuTransition1.HideSync(selectedRegionlabel);
            CovidInfoPages.SetPage(2);
        }
        #endregion

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void philippinesMap_ShapeSelected(object sender, ShapeSelectedEventArgs e)
        {
            uploadButton.Enabled = true;
            List<DateTime> dates = Patients.Select(p => p.DateConfirmed).Distinct().ToList();
            dates.Sort();
            foreach (PhRegion region in e.Data)
            {
                regionLabel.Text = region.Region;
                lineChart.Series["Cases"].DataSource = CreateChartData(Regions[region.Region].Keys.ToList(),
                    Regions[region.Region].Values.Select(p => p.Cases).ToList());
                lineChart.Series["Deaths"].DataSource = CreateChartData(Regions[region.Region].Keys.ToList(),
                    Regions[region.Region].Values.Select(p => p.Deaths).ToList());
                lineChart.Series["Recoveries"].DataSource = CreateChartData(Regions[region.Region].Keys.ToList(),
                    Regions[region.Region].Values.Select(p => p.Recoveries).ToList());
            }

            lineChart.Series["Cases"].ValueDataMembers.AddRange("Value");
            lineChart.Series["Deaths"].ValueDataMembers.AddRange("Value");
            lineChart.Series["Recoveries"].ValueDataMembers.AddRange("Value");
        }

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            localSaveStatusLabel.Text = string.Empty;
            ftpUploadStatusLabel.Text = string.Empty;
            //SetStyle
            PdfDocument doc = new PdfDocument { PageSettings = { Height = 800 } };
            SetStyles(out PdfCellStyle altStyle, out PdfCellStyle defStyle, out PdfCellStyle headerStyle);
            PdfPage page = doc.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Set the image
            string imageName = SetImage();
            PdfBitmap logoTitle = new PdfBitmap(Properties.Resources.pdf_logo);
            PdfBitmap regionImage =
                new PdfBitmap(
                    (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName.Replace(' ', '_')
                        .Replace('-', '_')));
            //Save graph to image
            MemoryStream chartImage = new MemoryStream();
            lineChart.ExportToImage(chartImage, ImageFormat.Bmp);
            PdfBitmap chartBitmap = new PdfBitmap(chartImage);

            g.DrawString(imageName, new PdfTrueTypeFont(new Font("Century Gothic", 26f, FontStyle.Bold), false),
                PdfBrushes.Black, new PointF(0, 210));
            g.DrawImage(logoTitle, ((g.ClientSize.Width - 612) / 2), 0, 612, 210);
            g.DrawImage(regionImage, 0, 250, 200, 250);
            g.DrawImage(chartBitmap, ((g.ClientSize.Width) / 2), 500, chartBitmap.Width / 2.3f, chartBitmap.Height / 2.3f);

            //Create the table
            PdfLightTable table = new PdfLightTable();

            //Create data
            DataTable dt = new DataTable();
            SetData(ref dt);

            //Set the source
            table.DataSource = dt;
            table.Style.AlternateStyle = altStyle;
            table.Style.DefaultStyle = defStyle;
            table.Style.HeaderStyle = headerStyle;

            //Formatting
            table.Draw(page, 210, (210 + 40), 305);

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "PDF File (*.pdf)|*.pdf",
                AddExtension = true,
                FileName = $"Stats Report - {imageName}.pdf",
                DefaultExt = ".pdf"
            };

            if (option1.Checked)
            {
                if (saveFile.ShowDialog() == DialogResult.OK && saveFile.CheckPathExists)
                {
                    try
                    {
                        doc.Save(saveFile.FileName);
                        localSaveStatusLabel.ForeColor = Color.Green;
                        localSaveStatusLabel.Text = "— success";
                    }
                    catch
                    {
                        localSaveStatusLabel.ForeColor = Color.Red;
                        localSaveStatusLabel.Text = "— fail";
                    }
                }
            }

            if (option2.Checked)
            {
                MemoryStream stream = new MemoryStream();
                doc.Save(stream);

                LoginForm login = new LoginForm();
                login.guna2AnimateWindow1.SetAnimateWindow(login);
                login.ShowDialog();
                if (!string.IsNullOrEmpty(LoginForm.Username))
                {
                    WebClient client = new WebClient
                    { Credentials = new NetworkCredential(LoginForm.Username, LoginForm.Password) };
                    try
                    {
                        await client.UploadDataTaskAsync(
                            new Uri($"ftp://66.220.9.50/My Documents/Stats Report - {imageName}.pdf"),
                            stream.ToArray());
                        ftpUploadStatusLabel.ForeColor = Color.Green;
                        ftpUploadStatusLabel.Text = "— success";
                    }
                    catch
                    {
                        ftpUploadStatusLabel.ForeColor = Color.Red;
                        ftpUploadStatusLabel.Text = "— fail";
                    }
                }
            }

            doc.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void option_CheckedChanged(object sender, EventArgs e)
        {
            if (!option1.Checked && !option2.Checked)
            {
                uploadButton.Enabled = false;
            }
            else
            {
                uploadButton.Enabled = true;
            }
        }


        private void WebView_BeforeNavigate(object sender, EO.WebBrowser.BeforeNavigateEventArgs e)
        {
            if (e.IsUserGesture)
            {
                e.Cancel = true;
                Process.Start(e.NewUrl);
            }

        }
        #endregion

        #endregion
    }
}
