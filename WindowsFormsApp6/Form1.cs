using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = new Button();
            bt.Text = "bt";
            bt.Left = 200;
            bt.Top = 200;
            this.Controls.Add(bt);
            bt.Click += new System.EventHandler(this.bt_Click);
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = "Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;";
            sq.Open();
            MessageBox.Show(sq.State.ToString());
            SqlCommand sc = new SqlCommand();
            sc.Connection = sq;
            sc.CommandText = "select * from IncomeExpendType";
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string TypeName = reader.GetString(1);
                    string Ie = reader.GetString(2);
                    string remark = reader.GetString(3);
                    string st = string.Format("{0} {1} {2} {3}", id, TypeName, Ie, remark);
                    textBox1.AppendText(st);
                }
            }
        }
        private void bt_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("you click");
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Visible = false;
            if (frm2.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Visible = true;
            }
        }
    }
}
