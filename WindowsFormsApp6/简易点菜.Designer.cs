
namespace WindowsFormsApp6
{
    partial class 简易点菜
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTbale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.disOrder = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnDisAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.btnPringBill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "台号";
            // 
            // txtTbale
            // 
            this.txtTbale.Location = new System.Drawing.Point(171, 37);
            this.txtTbale.Name = "txtTbale";
            this.txtTbale.Size = new System.Drawing.Size(294, 30);
            this.txtTbale.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(844, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "总价";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(938, 41);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(303, 30);
            this.txtTotalPrice.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "今日菜单";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(844, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "你的菜单";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(171, 247);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(294, 324);
            this.listBox1.TabIndex = 6;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(938, 247);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(303, 324);
            this.listBox2.TabIndex = 7;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(618, 247);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(144, 48);
            this.btnOrder.TabIndex = 8;
            this.btnOrder.Text = "点菜";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            this.btnOrder.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnOrder_DragDrop);
            // 
            // disOrder
            // 
            this.disOrder.Location = new System.Drawing.Point(617, 321);
            this.disOrder.Name = "disOrder";
            this.disOrder.Size = new System.Drawing.Size(144, 50);
            this.disOrder.TabIndex = 9;
            this.disOrder.Text = "退菜";
            this.disOrder.UseVisualStyleBackColor = true;
            this.disOrder.Click += new System.EventHandler(this.disOrder_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(617, 397);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(144, 45);
            this.btnAll.TabIndex = 10;
            this.btnAll.Text = "全点";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnDisAll
            // 
            this.btnDisAll.Location = new System.Drawing.Point(616, 478);
            this.btnDisAll.Name = "btnDisAll";
            this.btnDisAll.Size = new System.Drawing.Size(145, 44);
            this.btnDisAll.TabIndex = 11;
            this.btnDisAll.Text = "全退";
            this.btnDisAll.UseVisualStyleBackColor = true;
            this.btnDisAll.Click += new System.EventHandler(this.btnDisAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 598);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "日期";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(153, 598);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 20);
            this.date.TabIndex = 13;
            // 
            // btnPringBill
            // 
            this.btnPringBill.Location = new System.Drawing.Point(938, 598);
            this.btnPringBill.Name = "btnPringBill";
            this.btnPringBill.Size = new System.Drawing.Size(114, 31);
            this.btnPringBill.TabIndex = 14;
            this.btnPringBill.Text = "打印账单";
            this.btnPringBill.UseVisualStyleBackColor = true;
            this.btnPringBill.Click += new System.EventHandler(this.btnPringBill_Click);
            // 
            // 简易点菜
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 750);
            this.Controls.Add(this.btnPringBill);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDisAll);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.disOrder);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTbale);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 15F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "简易点菜";
            this.Text = "简易点菜";
            this.Load += new System.EventHandler(this.简易点菜_Load);
            this.Click += new System.EventHandler(this.简易点菜_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTbale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button disOrder;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnDisAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button btnPringBill;
    }
}