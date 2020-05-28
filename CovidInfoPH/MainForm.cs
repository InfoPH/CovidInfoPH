using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CovidInfoPH.Models;
using System.Drawing;
using System.Globalization;
using Syncfusion.Windows.Forms.Maps;
using Syncfusion.UI.Xaml.Maps;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Data;
using System.Diagnostics;
using System.Net;
using Syncfusion.Pdf;
using DevExpress.Data.Filtering;

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
        //Overload for second page
        private DataTable CreateChartData(DateTime dates, int number)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Argument", typeof(DateTime));
            dt.Columns.Add("Value", typeof(int));

            var row = dt.NewRow();
            row["Argument"] = dates;
            row["Value"] = number;
            dt.Rows.Add(row);

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

            dashBoardChart.Series["Cases"].ValueDataMembers.AddRange("Value");
            dashBoardChart.Series["Deaths"].ValueDataMembers.AddRange("Value");
            dashBoardChart.Series["Recoveries"].ValueDataMembers.AddRange("Value");
        }
        private void ShowForm(object sender, EventArgs e)
        {
            LoadDashBoardChart();
            latestData.Text = $"Latest data fetched: {Historical.Keys.Max(d => d):MMMM dd, yyyy}";
            ShowInTaskbar = true;
            bunifuFormFadeTransition1.ShowAsyc(this);
            DisplayGraph(false);
            InitializeMap();
            DisplayDataGrid(false);
            RefreshData(false);
        }
        #endregion

        #region Display data
        private void DisplayDataGrid(bool isMonth)
        {
            caseGridView.Rows.Clear();
            if (isMonth)
            {
                for (int i = -(Historical.Count - 1); i < 1; i++)
                {
                    caseGridView.Rows.Add($"{Historical.Keys.Last().AddDays(i): MM-dd-yyyy}", Historical[Historical.Keys.Last().AddDays(i)].Cases,
                 Historical[Historical.Keys.Last().AddDays(i)].Deaths, Historical[Historical.Keys.Last().AddDays(i)].Recoveries);
                }
            }
            else
            {
                for (int i = -6; i < 1; i++)
                {
                    caseGridView.Rows.Add($"{datePicker.Value.AddDays(i): MM-dd-yyyy}", Historical[datePicker.Value.AddDays(i)].Cases,
                    Historical[datePicker.Value.AddDays(i)].Deaths, Historical[datePicker.Value.AddDays(i)].Recoveries);
                }
            }
        }

        private void DisplayDataGrid(string region, bool isMonth)
        {
            //No region feature
            caseGridView.Rows.Clear();
            for (int i = -6; i < 1; i++)
            {
                caseGridView.Rows.Add($"{datePicker.Value.AddDays(i): MM-dd-yyyy}",
                    Regions[region][datePicker.Value.AddDays(i)].Cases,
                    Regions[region][datePicker.Value.AddDays(i)].Deaths, Regions[region][datePicker.Value.AddDays(i)].Recoveries);
            }
        }

        private void DisplayGraph(bool isMonth)
        {
            if (isMonth)
            {
                dashBoardChart.Series["Cases"].FilterCriteria = new BinaryOperator("Argument", Historical.Keys.Last(), BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Deaths"].FilterCriteria = new BinaryOperator("Argument", Historical.Keys.Last(), BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Recoveries"].FilterCriteria = new BinaryOperator("Argument", Historical.Keys.Last(), BinaryOperatorType.LessOrEqual);

            }
            else
            {
                dashBoardChart.Series["Cases"].FilterCriteria = new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                                                              new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Deaths"].FilterCriteria = new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                                                   new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
                dashBoardChart.Series["Recoveries"].FilterCriteria = new BinaryOperator("Argument", datePicker.Value.AddDays(-6), BinaryOperatorType.GreaterOrEqual) &
                                                   new BinaryOperator("Argument", datePicker.Value, BinaryOperatorType.LessOrEqual);
            }
        }

        private void DisplayGraph(string region, bool isMonth)
        {
           //No region feature
        }

        private void RefreshData(bool isMonth)
        {
            double cases;
            double deaths;
            double recoveries;
            int newCases;

            if (isMonth)
            {
                cases = Historical[Historical.Keys.Last()].Cases;
                deaths = Historical[Historical.Keys.Last()].Deaths;
                recoveries = Historical[Historical.Keys.Last()].Recoveries;
                newCases = Historical[Historical.Keys.Last()].Cases - Historical[datePicker.Value.AddMonths(-1)].Cases;
                weeklyReport.Text = $"Monthly Report as of {Historical.Keys.Last(): MMMM dd, yyyy}";
                newCasesDesc.Text = $"New cases since\n{Historical.Keys.Last().AddMonths(-1): MMMM}";
            }
            else
            {
                cases = Historical[datePicker.Value].Cases;
                deaths = Historical[datePicker.Value].Deaths;
                recoveries = Historical[datePicker.Value].Recoveries;
                newCases = Historical[datePicker.Value].Cases - Historical[datePicker.Value.AddDays(-6)].Cases;
                weeklyReport.Text = $"Weekly Report as of {datePicker.Value: MMMM dd, yyyy}";
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

        private void RefreshData(string region, bool isMonth)
        {
            double cases;
            double deaths;
            double recoveries;
            int newCases;
            if (isMonth)
            {
                cases = Regions[region][Patients[Patients.Count - 1].DateConfirmed].Cases;
                deaths = Regions[region][Patients[Patients.Count - 1].DateConfirmed].Deaths;
                recoveries = Regions[region][Patients[Patients.Count - 1].DateConfirmed].Recoveries;
                newCases = Regions[region][Patients[Patients.Count - 1].DateConfirmed].Cases - Regions[region][Patients[Patients.Count - 1].DateConfirmed.AddMonths(-1)].Cases;
                weeklyReport.Text = $"Monthly Report as of {Patients[Patients.Count - 1].DateConfirmed:MMMM dd, yyyy}";
                newCasesDesc.Text = $"New cases since\n{Patients[Patients.Count - 1].DateConfirmed.AddMonths(-1)}";
            }
            else
            {
                cases = Regions[region][datePicker.Value].Cases;
                deaths = Regions[region][datePicker.Value].Deaths;
                recoveries = Regions[region][datePicker.Value].Recoveries;
                newCases = Regions[region][datePicker.Value].Cases - Regions[region][datePicker.Value.AddDays(-6)].Cases;
                weeklyReport.Text = $"Weekly Report as of {datePicker.Value:MMMM dd, yyyy}";
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
            philippineShape.ShapeSetting.FillSetting.ColorMappings =
                new System.Collections.ObjectModel.ObservableCollection<ColorMapping>
                {
                    new RangeColorMapping {From = 4, To = 22, Color = Color.FromArgb(255, 193, 0)},
                    new RangeColorMapping {From = 28, To = 37, Color = Color.FromArgb(255, 154, 0)},
                    new RangeColorMapping {From = 47, To = 69, Color = Color.FromArgb(255, 116, 0)},
                    new RangeColorMapping {From = 107, To = 237, Color = Color.FromArgb(255, 77, 0)},
                    new RangeColorMapping {From = 481, To = 11000, Color = Color.FromArgb(255, 0, 0)}
                };
            philippinesMap.MapBackgroundBrush = new SolidBrush(Color.FromArgb(20, 30, 39));
            philippinesMap.ShapeSelected += PhilippinesMap_ShapeSelected; //Hook the ShapeSelected event
            philippinesMap.Layers.Add(philippineShape);
        }
        #endregion

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

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (selectedRegionlabel.Text.Substring(
                     selectedRegionlabel.Text.IndexOf(':') + 2) != "All")
            {
                selectedRegionlabel.Text = $"Selected Region: {RegionSearchForm.SearchResult}";
                FadeOutValues();
                RefreshData(RegionSearchForm.SearchResult, false);
                DisplayGraph(RegionSearchForm.SearchResult, false);
                DisplayDataGrid(RegionSearchForm.SearchResult, false);
                FadeInValues();
                datePicker.Enabled = true;
            }
            else
            {
                FadeOutValues();
                RefreshData(false);
                DisplayGraph(false);
                DisplayDataGrid(false);
                FadeInValues();
                datePicker.Enabled = true;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = false;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton4.FadeWhenInactive = true;
            bunifuTransition1.Show(searchRegionButton);
            bunifuTransition1.Show(selectedRegionlabel);
            CovidInfoPages.SetPage(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = false;
            bunifuImageButton4.FadeWhenInactive = true;
            bunifuTransition1.Hide(searchRegionButton);
            bunifuTransition1.Hide(selectedRegionlabel);
            CovidInfoPages.SetPage(1);
        }
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.FadeWhenInactive = true;
            bunifuImageButton2.FadeWhenInactive = true;
            bunifuImageButton4.FadeWhenInactive = false;
            bunifuTransition1.Hide(searchRegionButton);
            bunifuTransition1.Hide(selectedRegionlabel);
            CovidInfoPages.SetPage(2);
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
            uploadButton.Enabled = true;
            List<DateTime> dates = Patients.Select(p => p.DateConfirmed).Distinct().ToList();
            dates.Sort();
            foreach (PhRegion region in e.Data)
            {
                regionLabel.Text = region.Region;
                stackedChart.Series["Cases"].DataSource = CreateChartData(dates.Last(),
               Regions[region.Region][dates.Last()].Cases);
                stackedChart.Series["Deaths"].DataSource = CreateChartData(dates.Last(),
                         Regions[region.Region][dates.Last()].Deaths);
                stackedChart.Series["Recoveries"].DataSource = CreateChartData(dates.Last(),
                          Regions[region.Region][dates.Last()].Recoveries);
            }
            stackedChart.Series["Cases"].ValueDataMembers.AddRange("Value");
            stackedChart.Series["Deaths"].ValueDataMembers.AddRange("Value");
            stackedChart.Series["Recoveries"].ValueDataMembers.AddRange("Value");
        }

        private void searchRegionButton_Click(object sender, EventArgs e)
        {
            //Check for radioButton
            bool isMonth;
            if (monthRadioButton.Checked) isMonth = false;
            else isMonth = true;

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
                if (RegionSearchForm.SearchResult != "All")
                {
                    selectedRegionlabel.Text = $"Selected Region: {RegionSearchForm.SearchResult}";
                    FadeOutValues();
                    RefreshData(RegionSearchForm.SearchResult, isMonth);
                    DisplayGraph(RegionSearchForm.SearchResult, isMonth);
                    DisplayDataGrid(RegionSearchForm.SearchResult, isMonth);
                    FadeInValues();
                    datePicker.Enabled = true;
                }
                else
                {
                    FadeOutValues();
                    RefreshData(isMonth);
                    DisplayGraph(isMonth);
                    DisplayDataGrid(isMonth);
                    FadeInValues();
                    datePicker.Enabled = true;
                }
            }
        }

        private void regionDatePicker_ValueChanged(object sender, EventArgs e)
        {
            //remove
   
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
            g.DrawString(imageName, new PdfTrueTypeFont(new Font("Century Gothic", 26f, FontStyle.Bold), false),
                PdfBrushes.Black, new PointF(0, 210));
            g.DrawImage(logoTitle, ((g.ClientSize.Width - 612) / 2), 0, 612, 210);
            g.DrawImage(regionImage, 0, (210 + 40), 200, 250);

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
                        {Credentials = new NetworkCredential(LoginForm.Username, LoginForm.Password)};
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

        private void weekRadioButton_Click(object sender, EventArgs e)
        {
            //Still no region feature      
            FadeOutValues();
            DisplayGraph(false);
            DisplayDataGrid(false);
            RefreshData(false);
            FadeInValues();
            datePicker.Enabled = true;
        }

        private void monthRadioButton_Click(object sender, EventArgs e)
        {
            //Still no region feature
            datePicker.Enabled = false;
            FadeOutValues();
            DisplayGraph(true);
            DisplayDataGrid(true);
            RefreshData(true);
            FadeInValues();
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
