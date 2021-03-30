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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.AppendText("ID    小类    大类    账户    金额    时间    备注 \r\n");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connectDataBase();
            sqlCommand.CommandText = "queryDetByAccount"; //"select a.IncomeExpendDetId as id,b.IncomeExpendTypeName as 小类, b.TypeName as 大类, c.UserAccount as 账户,a.AccountMoney as 金额,a.IEDatetime as 时间,a.Remark as 备注 from IncomeExpendDet a  inner join IncomeExpendType b on a.IncomeExpendTypeId = b.IncomeExependTypeId inner join UserLogin c on a.UserLoginId = c.UserLoginId and c.UserAccount = @UserAccount";
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter para = new SqlParameter("@UserAccount", comboBox1.Text);
            sqlCommand.Parameters.Add(para);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string show = "\r\n" + reader.GetInt32(0).ToString() + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\t" + reader.GetString(3) + "\t" + reader.GetSqlMoney(4) + "\t" + reader.GetDateTime(5) + "\r\n";
                textBox1.AppendText(show);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“noteDataSet.UserLogin”中。您可以根据需要移动或删除它。
            this.userLoginTableAdapter.Fill(this.noteDataSet.UserLogin);
            textBox1.AppendText("ID    小类    大类    账户    金额    时间    备注 \r\n");
        }

        private SqlConnection connectDataBase()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = "Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;";
            sq.Open();
            return sq;
        }
    }
}
