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
            //User.DataSource = dt;
            //User.DisplayMember = "IncomeExependTypeId";
            //User.ValueMember = "IncomeExpendTypeName";
            cmbType.DataSource = dt;
            cmbType.DisplayMember = "IncomeExpendTypeName";
            cmbType.ValueMember = "IncomeExependTypeId";
            con.Close();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Value.ToString();
        }

        private void 记账记录_Load(object sender, EventArgs e)
        {
            dataBind(sender, e);
            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    rg = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(rg.Width, rg.Height);
                    dtp.Location = new Point(rg.Left, rg.Top);
                    dtp.Visible = true;
                }
            }
            else
            {
                dtp.Visible = false;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                try
                {
                    decimal val = Convert.ToDecimal(e.FormattedValue.ToString());
                    e.Cancel = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    e.Cancel = true;
                }
            }
        }

        private void toolSstipButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int count = sda.Update(dtinfor);
                if (count > 0)
                {
                    MessageBox.Show("更新成功");
                    //MessageBox.Show(count.ToString());
                    con.Close();
                }
                else
                {
                    MessageBox.Show("更新失败");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            DataRow r = dtinfor.NewRow();
            r.SetField(0, txtID.Text);
            r.SetField(1, cmbType.SelectedValue);
            //r.ItemArray[0] = txtID.Text;
            //r.ItemArray[1] = cmbType.SelectedValue;
            decimal money = 0;
            if (decimal.TryParse(txtMoney.Text, out money) == false)
            {
                MessageBox.Show("输入金额不合法");
                txtMoney.SelectAll();
                return;
            }
            r.SetField(3, money);
            r.SetField(4, dateTimePicker1.Value);
            //r.ItemArray[3] = money;
            //r.ItemArray[4] = dateTimePicker1.Value;
            dtinfor.Rows.InsertAt(r, dtinfor.Rows.Count);
            bindingSource1.DataSource = dtinfor;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            //dataBind(sender, e);
        }
    }
}
