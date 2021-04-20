using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class 简易点菜 : Form
    {
        public 简易点菜()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void 简易点菜_Load(object sender, EventArgs e)
        {
            //listBox1.Items.Add(new dash("gongbaojiding", 17, "chengdu", "null"));
            dt.Columns.Add("菜名", Type.GetType("System.String"));
            dt.Columns.Add("价格", Type.GetType("System.Decimal"));
            dt.Columns.Add("来源", Type.GetType("System.String"));
            dt.Columns.Add("菜谱", Type.GetType("System.String"));
            DataRow r = dt.NewRow();
            r.SetField("菜名", "宫保鸡丁");
            r.SetField("价格", "17");
            r.SetField("来源", "成都");
            r.SetField("菜谱", "......");
            dt.Rows.Add(r);
            r = dt.NewRow();
            r.SetField("菜名", "香辣蟹");
            r.SetField("价格", "90");
            r.SetField("来源", "长沙");
            r.SetField("菜谱", "辣椒炒青蟹");
            dt.Rows.Add(r);
            listBox1.DataSource = dt;
            listBox1.DisplayMember = "菜名";

        }
        class dash
        {
            public dash(string Name, decimal Price, string Source, string Detail)
            {
                
            }
            public string Name;
            public decimal Price;
            string Source;
            string Detail;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string message = string.Format("该菜品 : {0}\n 价格: {1}\n 来源:{2}\n 菜谱:{3}", dt.Rows[listBox1.SelectedIndex].ItemArray[0], dt.Rows[listBox1.SelectedIndex].ItemArray[1], dt.Rows[listBox1.SelectedIndex].ItemArray[2], dt.Rows[listBox1.SelectedIndex].ItemArray[3]);
                MessageBox.Show(message, "菜品信息");
            }
        }
    }
}
