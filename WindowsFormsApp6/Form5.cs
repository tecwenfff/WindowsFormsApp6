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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet dataset;
        SqlCommandBuilder builder;
        private void Form5_Load(object sender, EventArgs e)
        {
            string strCon = "Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;";
            con = new SqlConnection(strCon);
            cmd = new SqlCommand("select * from IncomeExpendType", con);
            con.Open();
            adapter = new SqlDataAdapter(cmd);
            builder = new SqlCommandBuilder(adapter);
            dataset = new DataSet();
            adapter.Fill(dataset, "iet");
            con.Close();
            dataGridView1.DataSource = dataset.Tables["iet"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                adapter.Update(dataset.Tables["iet"].GetChanges());
                dataset.Tables["iet"].AcceptChanges();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("delete", "warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    dataset.Tables[0].Rows[dataGridView1.CurrentRow.Index].Delete();
                    con.Open();
                    adapter.Update(dataset.Tables[0].GetChanges());
                    dataset.Tables[0].AcceptChanges();
                    MessageBox.Show("delect");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                dataset.Tables[0].RejectChanges(); 
            }
            con.Close();
        }
    }
}
