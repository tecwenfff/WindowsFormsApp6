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
using System.Configuration;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private SqlConnection connectDataBase()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = "Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;";
            sq.Open();
            return sq;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand();
            sc.Connection = connectDataBase();
            sc.CommandText = "select * from UserLogin where UserAccount = @UserAccount and UserPwd = @UserPwd";
            sc.Parameters.Add(new SqlParameter("@UserAccount", textBox1.Text));
            sc.Parameters.Add(new SqlParameter("@UserPwd", textBox2.Text));
            SqlDataReader reader = sc.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("login seccess");
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("no user or password is fake");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
