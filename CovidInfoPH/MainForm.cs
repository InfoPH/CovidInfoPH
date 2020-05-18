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


namespace CovidInfoPH
{
    public partial class MainForm : Form
    {
        public List<Patient> Patients;
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataFromSheet();
            DisplayGraph();
        }

        private async Task LoadDataFromSheet()  
        {
            SheetMapper sheetMapper = new SheetMapper()
                .AddConfigFor<Patient>(cfg => cfg
                   .MapColumn(column => column.WithHeader("Age").IsRequired().MapTo(p => p.Age))
                   .MapColumn(column => column.WithHeader("DateRepConf").IsRequired().UsingFormat("dd-MM-yy").MapTo(p => p.DateConfirmed))
                   .MapColumn(column => column.WithHeader("DateRecover").UsingFormat("dd-MM-yy").WithDefaultValue<DateTime?>(null).MapTo(p => p.DateRecovered))
                   .MapColumn(column => column.WithHeader("DateDied").UsingFormat("dd-MM-yy")
                       .WithDefaultValue<DateTime?>(null).MapTo(p => p.DateDied)));

            
            Sheet sheetData = await new GoogleSheetAdapter().GetAsync("16g_PUxKYMC0XjeEKF6FPUBq2-pFgmTkHoj5lbVrGLhE", "'DOH Data Drop'!A1:ZZ", "AIzaSyCkssJLOPN-8WdM3HX_8N3kdq62_9hn_wA");
            MappingResult<Patient> result = sheetMapper.Map<Patient>(sheetData);
            Patients = result.ParsedModels.Select(o => o.Value).OrderBy(o => o.DateConfirmed).ToList();

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
