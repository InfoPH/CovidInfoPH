﻿using System;
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
            SheetMapper sheetMapper = new SheetMapper()
                .AddConfigFor<Patient>(cfg => cfg
                   .MapColumn(column => column.WithHeader("Age").IsRequired().MapTo(p => p.Age))
                   .MapColumn(column => column.WithHeader("DateRepConf").IsRequired().UsingFormat("dd-MM-yy").MapTo(p => p.DateConfirmed))
                   .MapColumn(column => column.WithHeader("DateRecover").UsingFormat("dd-MM-yy").WithDefaultValue<DateTime?>(null).MapTo(p => p.DateRecovered))
                   .MapColumn(column => column.WithHeader("DateDied").UsingFormat("dd-MM-yy")
                       .WithDefaultValue<DateTime?>(null).MapTo(p => p.DateDied)))
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
            //Map the data accordingly
            Patients = sheetMapper.Map<Patient>(dohDataDropSheet.Result).ParsedModels.Select(o => o.Value)
                .OrderBy(o => o.DateConfirmed).ToList();
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
            SetDateLimit();
            Canvas canvas = new Canvas();
            DataPoint cases = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint deaths = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DataPoint recoveries = new DataPoint(BunifuDataViz._type.Bunifu_column);
            DateTime currentDate;
            int month = DatePicker.Value.Month;
            int day = DatePicker.Value.Day;
           for(int i = 0; i < 7; i++, day++)
            {
                if(((month == 1 || month == 3) && day > 31) ||
                    (month == 2 && day > 29))
                {
                    month++;
                    day = 1;
                }
                else if (day > 30)
                {
                    month++;
                    day = 1;
                }
                currentDate = new DateTime(2020, month, day);
                cases.addLabely(currentDate.DayOfWeek.ToString(), Historical[currentDate].Cases);
                deaths.addLabely(currentDate.DayOfWeek.ToString(), Historical[currentDate].Deaths);
                recoveries.addLabely(currentDate.DayOfWeek.ToString(), Historical[currentDate].Recoveries);
            }

            canvas.addData(cases);
            canvas.addData(recoveries);
            canvas.addData(deaths);
            GeneralCaseChart.Render(canvas);
        }
        private void SetDateLimit()
        {
            DatePicker.MaxDate = Historical.ElementAt(Historical.Count - 7).Key;
            DatePicker.MinDate = Historical.ElementAt(0).Key;
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            bunifuTransition1.Hide(GeneralCaseChart);
            DisplayGraph();
            FadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            FadeTimer.Stop();
            bunifuTransition1.Show(GeneralCaseChart);
        }
    }
}
