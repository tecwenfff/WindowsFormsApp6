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
    public partial class changeIcon : Form
    {
        public changeIcon()
        {
            InitializeComponent();
        }
        string picPath;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "图片文件|*.jpg";
            if (of.ShowDialog() == DialogResult.OK && of.FileName != "")
            {
                picPath = of.FileName;
                icon.Image = Image.FromFile(picPath);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        List<PictureBox> list = new List<PictureBox>();
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage2)
            {
                int top = 0, left = 0;
                string pa = Application.StartupPath + "\\image\\";
                for (int i = 1; i <= 35; i++)
                {
                    if ((i - 1) % 10 == 0)
                    {
                        top = i / 10 * 50 + 30;
                        left = 10;
                    }
                    PictureBox p = new PictureBox();
                    list.Add(p);
                    p.Click += new EventHandler(pictureBox1_Click);
                    p.Name = i.ToString();
                    p.Height = 40;
                    p.Width = 40;
                    groupBox1.Controls.Add(p);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Image = Image.FromFile(pa + i + ".jpg");
                    p.Visible = true;
                    p.Left = left;
                    p.Top = top;
                    left += 50;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            picPath = Application.StartupPath + "\\image\\" + p.Name + ".jpg";
        }
    }
}
