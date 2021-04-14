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
    public partial class 收支类目管理 : Form
    {
        public 收支类目管理()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 收支类目管理_Load(object sender, EventArgs e)
        {
            BindInExpType(sender, e);
        }


        private SqlConnection connectDataBase()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = "Data Source=DESKTOP-7OA7319;Database=note;Integrated Security=true;";
            sq.Open();
            return sq;
        }

        private void 图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void BindInExpType(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            sqlDbHelper helper = new sqlDbHelper();
            SqlDataReader reader = helper.ExecuteReader("select * from IncomeExpendType");
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(2));
                lv.SubItems.Add(reader.GetString(1));
                lv.SubItems.Add(reader.GetInt32(0).ToString());
                lv.SubItems.Add(reader.GetString(3));
                listView1.Items.Add(lv);
            }
            reader.Close();
        }


        private void 添加记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            添加收支分类 frm = new 添加收支分类();
            frm.Show(); frm.Call += new EventHandler(BindInExpType);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
                MessageBox.Show("请选中至少一项");
            sqlDbHelper helper = new sqlDbHelper();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                string strid = listView1.SelectedItems[i].SubItems[2].Text;
                helper.ExecuteNonquery("delete from IncomeExpendType where IncomeExependTypeId = @id", CommandType.Text, new SqlParameter("id", strid));
            }
            BindInExpType(sender, e);
        }
    }
}
