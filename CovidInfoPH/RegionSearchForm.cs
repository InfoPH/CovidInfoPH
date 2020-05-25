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
        public static string SearchResult { get; set; }

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
            dt.Rows.Add("All");
            foreach (var region in regions)
            {
                dt.Rows.Add(region);
            }
            bunifuDataGridView1.DataSource = dt;
            searchBarTextBox.Focus();
        }

        private void searchBarTextBox_TextChange(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.RowCount != 0)
            {
                ((DataTable)bunifuDataGridView1.DataSource).DefaultView.RowFilter = null;
            }
            ((DataTable)bunifuDataGridView1.DataSource).DefaultView.RowFilter = $"Regions like '%{searchBarTextBox.Text.Trim().Replace("'", "''")}%'";
        }

        private void searchBarTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                MoveUp();
            }

            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                MoveDown();
            }

            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                if (bunifuDataGridView1.RowCount <= 0 && bunifuDataGridView1.SelectedCells.Count <= 0) return;
                searchBarTextBox.Text = (string) bunifuDataGridView1.CurrentCell.Value;
                SearchResult = (string) bunifuDataGridView1.CurrentCell.Value;
                Close();
            }
        }

        private void MoveUp()
        {
            if (bunifuDataGridView1.RowCount <= 0 && bunifuDataGridView1.SelectedCells.Count <= 0) return;
            bunifuDataGridView1.CurrentCell = bunifuDataGridView1.CurrentCell.RowIndex == 0 ? bunifuDataGridView1[0, bunifuDataGridView1.RowCount - 1] : bunifuDataGridView1[0, bunifuDataGridView1.CurrentCell.RowIndex - 1];
        }

        private void MoveDown()
        {
            if (bunifuDataGridView1.RowCount <= 0 && bunifuDataGridView1.SelectedCells.Count <= 0) return;
            bunifuDataGridView1.CurrentCell = bunifuDataGridView1.CurrentCell.RowIndex == bunifuDataGridView1.RowCount - 1 ? bunifuDataGridView1[0, 0] : bunifuDataGridView1[0, bunifuDataGridView1.CurrentCell.RowIndex + 1];
        }
    }
}
