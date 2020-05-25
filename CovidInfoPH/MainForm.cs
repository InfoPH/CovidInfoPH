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
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Data;
using System.Net;
using Syncfusion.Pdf;

namespace CovidInfoPH
{
    public partial class MainForm : Form
    {
        internal static List<Patient> Patients;
        internal static Dictionary<DateTime, HistoricalInfo> Historical;
        internal static Dictionary<string, Dictionary<DateTime, Models.RegionDateInfo>> Regions;

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
            latestData.Text = $"Latest data fetched: {Historical.Keys.Max(d => d):MMMM dd, yyyy}";
            ShowInTaskbar = true;
            bunifuFormFadeTransition1.ShowAsyc(this);
            SetChartColors();
            DisplayGraph();
            InitializeMap();
            DisplayDataGrid();
            RefreshData();
        }
        private void SetChartColors()
        {
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 135, 143));
            generalCaseChart.colorSet.Add(Color.FromArgb(142, 174, 189));
            generalCaseChart.colorSet.Add(Color.FromArgb(152, 94, 109));
            regionMapView.colorSet.Add(Color.FromArgb(152, 135, 143));
            regionMapView.colorSet.Add(Color.FromArgb(142, 174, 189));
            regionMapView.colorSet.Add(Color.FromArgb(152, 94, 109));
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
            uploadButton.Enabled = true;
            regionDatePicker.Enabled = true;
            Canvas canvas = new Canvas();
            DataPoint cases = new DataPoint(BunifuDataViz._type.Bunifu_line);
            DataPoint deaths = new DataPoint(BunifuDataViz._type.Bunifu_line);
            DataPoint recoveries = new DataPoint(BunifuDataViz._type.Bunifu_line);

            //Adding transitions makes it laggy ://
            foreach (PhRegion region in e.Data)
            {
                regionLabel.Text = region.Region;
                for (int i = -6; i < 1; i++)
                {
                    cases.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[region.Region][regionDatePicker.Value.AddDays(i)].Cases);
                    deaths.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[region.Region][regionDatePicker.Value.AddDays(i)].Deaths);
                    recoveries.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[region.Region][regionDatePicker.Value.AddDays(i)].Recoveries);
                }

                canvas.addData(cases);
                canvas.addData(recoveries);
                canvas.addData(deaths);
                regionMapView.Render(canvas);
            }

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
            if (!string.IsNullOrEmpty(RegionSearchForm.SearchResult) && RegionSearchForm.SearchResult != "All")
            {

            }
        }

        #endregion

        #endregion
        private void UploadReport()
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("Johndayll", "apple2001");
            client.UploadFile("ftp://66.220.9.50/My Documents/RegionReport.pdf",
                @"C:\Users\ADMIN\Downloads\CovidInfoPH\CovidInfoPH\bin\Debug\Documents\RegionInfo.pdf");
        }

        private void regionDatePicker_ValueChanged(object sender, EventArgs e)
        {
            Canvas canvas = new Canvas();
            DataPoint cases = new DataPoint(BunifuDataViz._type.Bunifu_line);
            DataPoint deaths = new DataPoint(BunifuDataViz._type.Bunifu_line);
            DataPoint recoveries = new DataPoint(BunifuDataViz._type.Bunifu_line);

            for (int i = -6; i < 1; i++)
            {
                cases.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[regionLabel.Text][regionDatePicker.Value.AddDays(i)].Cases);
                deaths.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[regionLabel.Text][regionDatePicker.Value.AddDays(i)].Deaths);
                recoveries.addLabely(regionDatePicker.Value.AddDays(i).DayOfWeek.ToString(), Regions[regionLabel.Text][regionDatePicker.Value.AddDays(i)].Recoveries);
            }

            canvas.addData(cases);
            canvas.addData(recoveries);
            canvas.addData(deaths);
            regionMapView.Render(canvas);
        }

        private void regionMapView_Load(object sender, EventArgs e)
        {

        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            //SetStyle
            PdfDocument doc = new PdfDocument();
            doc.PageSettings.Height = 800;
            PdfCellStyle altStyle = new PdfCellStyle();
            PdfCellStyle defStyle = new PdfCellStyle();
            PdfCellStyle headerStyle = new PdfCellStyle();
            SetStyles(ref altStyle, ref defStyle, ref headerStyle);
            PdfPage page = doc.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Set the image
            string imageName = SetImage();
            PdfBitmap logoTitle = new PdfBitmap(@"C:\Users\ADMIN\Downloads\CovidInfoPH\CovidInfoPH\Resources\pdf_logo.jpg");
            PdfBitmap regionImage = new PdfBitmap($@"C:\Users\ADMIN\Downloads\CovidInfoPH\CovidInfoPH\Resources\region-photos\{imageName}.png");
            g.DrawString(imageName, new PdfTrueTypeFont(new Font("Century Gothic", 26f, FontStyle.Bold), false), PdfBrushes.Black, new PointF(0, 210));
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

            //Save the document.
            doc.Save(@"..\..\Documents\RegionInfo.pdf");

            UploadReport();
        }

        #region SetTable
        private void SetStyles(ref PdfCellStyle altStyle, ref PdfCellStyle defStyle, ref PdfCellStyle headerStyle)
        {
            PdfFont font = new PdfTrueTypeFont(new Font("Century Gothic", 12f), false);
            PdfFont boldFont = new PdfTrueTypeFont(new Font("Century Gothic", 22f, FontStyle.Bold), false);
            PdfPen borderPen = new PdfPen(PdfBrushes.Black);
            borderPen.Width = 0;

            //AltStyle
            altStyle = new PdfCellStyle();
            altStyle.Font = font;
            altStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(192, 201, 219));
            altStyle.BorderPen = borderPen;

            //DefStyle
            defStyle = new PdfCellStyle();
            defStyle.Font = font;
            defStyle.BackgroundBrush = PdfBrushes.White;
            defStyle.BorderPen = borderPen;
            defStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            //HeaderStyle
            headerStyle = new PdfCellStyle(boldFont, PdfBrushes.White, PdfPens.DarkBlue);
            headerStyle.BackgroundBrush = new PdfSolidBrush(Color.FromArgb(33, 67, 126));
            headerStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
        }

        private void SetData(ref DataTable table)
        {
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
            date1["Date"] = regionDatePicker.Value.AddDays(-6);
            date1["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-6)].Cases;
            date1["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-6)].Deaths;
            date1["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-6)].Recoveries;
            table.Rows.Add(date1);

            DataRow date2 = table.NewRow();
            date2["Date"] = regionDatePicker.Value.AddDays(-5);
            date2["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-5)].Cases;
            date2["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-5)].Deaths;
            date2["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-5)].Recoveries;
            table.Rows.Add(date2);

            DataRow date3 = table.NewRow();
            date3["Date"] = regionDatePicker.Value.AddDays(-4);
            date3["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-4)].Cases;
            date3["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-4)].Deaths;
            date3["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-4)].Recoveries;
            table.Rows.Add(date3);

            DataRow date4 = table.NewRow();
            date4["Date"] = regionDatePicker.Value.AddDays(-3);
            date4["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-3)].Cases;
            date4["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-3)].Deaths;
            date4["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-3)].Recoveries;
            table.Rows.Add(date4);

            DataRow date5 = table.NewRow();
            date5["Date"] = regionDatePicker.Value.AddDays(-2);
            date5["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-2)].Cases;
            date5["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-2)].Deaths;
            date5["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-2)].Recoveries;
            table.Rows.Add(date5);

            DataRow date6 = table.NewRow();
            date6["Date"] = regionDatePicker.Value.AddDays(-1);
            date6["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-1)].Cases;
            date6["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-1)].Deaths;
            date6["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value.AddDays(-1)].Recoveries;
            table.Rows.Add(date6);

            DataRow date7 = table.NewRow();
            date7["Date"] = regionDatePicker.Value;
            date7["Cases"] = Regions[regionLabel.Text][regionDatePicker.Value].Cases;
            date7["Deaths"] = Regions[regionLabel.Text][regionDatePicker.Value].Deaths;
            date7["Recoveries"] = Regions[regionLabel.Text][regionDatePicker.Value].Recoveries;
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
    }
}
