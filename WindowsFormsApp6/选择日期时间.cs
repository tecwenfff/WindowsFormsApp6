using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class 选择日期时间 : Form
    {
        public 选择日期时间()
        {
            InitializeComponent();
        }

        private void 选择日期时间_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-mm-dd dddd";
            textBox1.Text = dateTimePicker1.Text;
            Console.WriteLine("true");
        }
    }
}
