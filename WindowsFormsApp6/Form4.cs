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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void chbChangeIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (chbChangeIcon.Checked)
            {
                //TODO 打开更换头像窗体
            }
        }
    }
}
