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
    public partial class 记账记录 : Form
    {
        public 记账记录()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con;
        SqlDataAdapter sda;
        DataSet ds;
        SqlCommandBuilder scb;
        DateTimePicker dtp = new DateTimePicker();
        Rectangle rg;
        DataTable dtinfor = new DataTable();
        private void dataBind(object sender, EventArgs e)
        {
            string strSql = "select * from IncomeExpendDet where UserLoginID = @ulid";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@ulid", "1") };
            con = new SqlConnection("Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;");
            sda = sqlDbHelper.ExecuteAdapter(strSql, CommandType.Text, sp, con);
            scb = new SqlCommandBuilder(sda);
            dataGridView1.AutoGenerateColumns = false;
            ds = new DataSet();
            sda.Fill(ds, "ttt");
            dtinfor = ds.Tables[0];
            bindingSource1.DataSource = dtinfor;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            dtinfor.Columns[2].DefaultValue = "1";
            dataGridView1.Columns[0].DataPropertyName = dtinfor.Columns[0].ColumnName;
            dataGridView1.Columns[1].DataPropertyName = dtinfor.Columns[1].ColumnName;
            dataGridView1.Columns[2].DataPropertyName = dtinfor.Columns[2].ColumnName;
            dataGridView1.Columns[3].DataPropertyName = dtinfor.Columns[3].ColumnName;
            dataGridView1.Columns[4].DataPropertyName = dtinfor.Columns[4].ColumnName;
            dataGridView1.Columns[5].DataPropertyName = dtinfor.Columns[5].ColumnName;

            string sql = "select IncomeExependTypeId, IncomeExpendTypeName from IncomeExpendType";

            sqlDbHelper sdh = new sqlDbHelper();
            DataTable dt = sdh.ExecuteDataTable(sql, CommandType.Text, null);
            收支类目.DataSource = dt;
            收支类目.DisplayMember = "IncomeExpendTypeName";
            收支类目.ValueMember = "IncomeExependTypeId";
            User.DataSource = dt;
            User.DisplayMember = "IncomeExependTypeId";
            User.ValueMember = "IncomeExpendTypeName";
            con.Close();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void 记账记录_Load(object sender, EventArgs e)
        {
            dataBind(sender, e);
        }
    }
}
