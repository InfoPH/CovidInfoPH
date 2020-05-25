using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidInfoPH
{
    public partial class RegionSearchForm : Form
    {

        public RegionSearchForm()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RegionSearchForm_Load(object sender, EventArgs e)
        {
            List<string> regions = MainForm.Regions.Keys.OrderBy(k => k).ToList();
            DataTable dt = new DataTable();
            guna2ShadowForm1.SetShadowForm(this);
            dt.Columns.Add("Regions");
            foreach (var region in regions)
            {
                dt.Rows.Add(region);
            }
            AutoCompleteStringCollection regionsCollection = new AutoCompleteStringCollection();
            regionsCollection.AddRange(regions.ToArray());
            searchBarTextBox.AutoCompleteCustomSource = regionsCollection;
            bunifuDataGridView1.DataSource = dt;
        }

        private void searchBarTextBox_TextChange(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.RowCount != 0)
            {
                ((DataTable) bunifuDataGridView1.DataSource).DefaultView.RowFilter = null;
            }
            ((DataTable)bunifuDataGridView1.DataSource).DefaultView.RowFilter = $"Regions like '%{searchBarTextBox.Text.Trim().Replace("'","''")}%'";
        }
    }
}
