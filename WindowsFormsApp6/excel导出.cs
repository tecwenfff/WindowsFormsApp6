using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp6
{
    public partial class excel导出 : Form
    {
        public excel导出()
        {
            InitializeComponent();
        }
        DataSet dataset = new DataSet();
        private void excel导出_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter = sqlDbHelper.ExecuteAdapter("select * from IncomeExpendType", CommandType.Text, null, con);
            adapter.Fill(dataset, "bbb");
            dataGridView1.DataSource = dataset.Tables["bbb"];
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            ExportExcel("123456.xls", dataGridView1);
        }
        public static void ExportExcel(string fileName, DataGridView view)
        {
            string saveFileName = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "excel文件|*.xls";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            saveFileName = sfd.FileName;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("未创建成功");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            for (int i = 0; i < view.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = view.Columns[i].HeaderText;
            }
            for (int r = 0; r < view.Rows.Count; r++)
            {
                for (int j = 0; j < view.Columns.Count; j++)
                {
                    worksheet.Cells[r + 2, j + 1] = view.Rows[r].Cells[j].Value;
                }
                Application.DoEvents();
            }
            if (saveFileName != null)
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            worksheet.Columns.EntireColumn.AutoFit();
            xlApp.Quit();
            GC.Collect();
            MessageBox.Show("文件保存成功");
        }
    }
}
