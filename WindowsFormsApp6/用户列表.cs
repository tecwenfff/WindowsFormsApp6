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
    public partial class 用户列表 : Form
    {
        public 用户列表()
        {
            InitializeComponent();
        }

        private void 用户列表_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;");
            con.Open();
            SqlDataAdapter adapetr = new SqlDataAdapter("select * from UserLogin", con);
            DataSet dataset = new DataSet();
            adapetr.Fill(dataset, "UserLogin");
            dataGridView1.DataSource = dataset.Tables[0];
            DataGridViewColumn dgvc = (DataGridViewColumn)dataGridView1.Columns["icon"];
            for (int a = 0; a < dataGridView1.Rows.Count - 1; a++)
            {
                dataGridView1.Rows[a].Height = 100;
                DataGridViewImageCell dgvcc = (DataGridViewImageCell)dataGridView1.Rows[a].Cells["icon"];
                try
                {
                    string picName = dataset.Tables[0].Rows[a][3].ToString();
                    Bitmap bmp = new Bitmap(Application.StartupPath + picName);
                    dgvcc.Value = bmp;
                }
                catch
                {
                    
                }
            }
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.Name = "Details";
            bc.HeaderText = "Details";
            bc.Width = 110;
            bc.Text = "Details...";
            bc.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Insert(dataGridView1.Columns.Count, bc);
           
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "useraccont")
            {
                if (e.Value != null && e.Value.ToString() == "admin")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                MessageBox.Show("该行记录的详细信息是: " + dataGridView1.Rows[e.RowIndex].Cells["useraccont"].Value);
            }
        }
    }
}
