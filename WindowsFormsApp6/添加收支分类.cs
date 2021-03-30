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
    public partial class 添加收支分类 : Form
    {
        public 添加收支分类()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void 添加收支分类_Load(object sender, EventArgs e)
        {
            sqlDbHelper sdh = new sqlDbHelper();
            int b = (int)sdh.ExecuteScalar("select count(*) from IncomeExpendType");
            textBox1.Text = b.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear(); 
            button1.Enabled = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlDbHelper sdh = new sqlDbHelper();
            string TypeName;
            if (radioButton1.Checked)
                TypeName = "收入";
            else
                TypeName = "支出";
            SqlParameter[] pa = { new SqlParameter("@tyName", TypeName), new SqlParameter("@ieTypeName", textBox1.Text), new SqlParameter("@rm", textBox2.Text) };
            int c = sdh.ExecuteNonquery("insert into IncomeExpendType values (@tyName, @ieTypeName, @rm)", CommandType.Text, pa);
            if (c > 0)
            {
                MessageBox.Show("添加成功");
                if (checkBox1.Checked)
                    this.Call(sender, e);
                else
                    Close();
            }
            else
                MessageBox.Show("添加失败");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public event EventHandler Call;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Call(sender, e);
        }
    }
}
