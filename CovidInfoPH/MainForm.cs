using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using SheetToObjects.Adapters.GoogleSheets;
using SheetToObjects.Lib;
using SheetToObjects.Lib.FluentConfiguration;


namespace CovidInfoPH
{
    public partial class MainForm : Form
    {

        public SheetMapper SheetMapper;
        public Sheet SheetData;
        public MappingResult<PatientInfo> Result;

        public MainForm()
        {
            InitializeComponent();
        }

        private async Task LoadStuff()
        {
            SheetMapper = new SheetMapper()
                .AddConfigFor<PatientInfo>(cfg => cfg
                   .MapColumn(column => column.WithHeader("Age").IsRequired().MapTo(p => p.Age))
                   .MapColumn(column => column.WithHeader("DateRepConf").IsRequired().UsingFormat("dd-MM-yy").MapTo(p => p.DateConfirmed))
                   .MapColumn(column => column.WithHeader("DateRecover").UsingFormat("dd-MM-yy").WithDefaultValue<DateTime?>(null).MapTo(p => p.DateRecovered))
                   .MapColumn(column => column.WithHeader("DateDied").UsingFormat("dd-MM-yy")
                       .WithDefaultValue<DateTime?>(null).MapTo(p => p.DateDied)));


            SheetData = await new GoogleSheetAdapter().GetAsync("16g_PUxKYMC0XjeEKF6FPUBq2-pFgmTkHoj5lbVrGLhE", "'DOH Data Drop'!A1:ZZ", "AIzaSyCkssJLOPN-8WdM3HX_8N3kdq62_9hn_wA");
            Result = SheetMapper.Map<PatientInfo>(SheetData);
        }

        private void LoadData()
        {
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Bunifu.DataViz.WinForms.DataPoint data = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_line);

            int caseNum = 0;

            for (int j = 0; j < 10; j++)
            {
                DateTime currentDate = Result.ParsedModels[caseNum].Value.DateConfirmed;
                for (int i = caseNum; currentDate == Result.ParsedModels[i].Value.DateConfirmed; i++)
                {
                    caseNum++;
                }
                data.addLabely(Result.ParsedModels[caseNum].Value.DateConfirmed.ToString("d"), caseNum);
                canvas.addData(data);

            }
            bunifuDataViz1.Render(canvas);
        }



        private void MainForm_Load(object sender, System.EventArgs e)
        {
            LoadStuff();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadData();
            timer1.Stop();
        }

        public class PatientInfo
        {
            public int Age { get; set; }
            public DateTime DateConfirmed { get; set; }
            public DateTime? DateRecovered { get; set; }
            public DateTime? DateDied { get; set; }
        }
    }
}
