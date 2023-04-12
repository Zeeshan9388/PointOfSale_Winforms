namespace PointOfSale
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_setting = new MetroFramework.Controls.MetroButton();
            this.btn_report = new MetroFramework.Controls.MetroButton();
            this.btn_price = new MetroFramework.Controls.MetroButton();
            this.btn_item = new MetroFramework.Controls.MetroButton();
            this.btn_cate = new MetroFramework.Controls.MetroButton();
            this.SlidePanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_sale = new MetroFramework.Controls.MetroButton();
            this.progressbar1 = new PointOfSale.Page.Progressbar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(30, 92);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.progressbar1);
            this.splitContainer2.Size = new System.Drawing.Size(1462, 626);
            this.splitContainer2.SplitterDistance = 244;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_setting);
            this.panel2.Controls.Add(this.btn_report);
            this.panel2.Controls.Add(this.btn_price);
            this.panel2.Controls.Add(this.btn_item);
            this.panel2.Controls.Add(this.btn_cate);
            this.panel2.Controls.Add(this.SlidePanel);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_sale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 626);
            this.panel2.TabIndex = 0;
            // 
            // btn_setting
            // 
            this.btn_setting.ForeColor = System.Drawing.Color.Red;
            this.btn_setting.Location = new System.Drawing.Point(36, 622);
            this.btn_setting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(316, 74);
            this.btn_setting.TabIndex = 0;
            this.btn_setting.Text = "Setting";
            this.btn_setting.UseSelectable = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            this.btn_setting.MouseEnter += new System.EventHandler(this.btn_setting_MouseEnter);
            this.btn_setting.MouseLeave += new System.EventHandler(this.btn_setting_MouseLeave);
            // 
            // btn_report
            // 
            this.btn_report.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_report.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_report.ForeColor = System.Drawing.Color.Red;
            this.btn_report.Location = new System.Drawing.Point(36, 540);
            this.btn_report.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(316, 72);
            this.btn_report.Style = MetroFramework.MetroColorStyle.Orange;
            this.btn_report.TabIndex = 0;
            this.btn_report.Text = "Report";
            this.btn_report.UseSelectable = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            this.btn_report.MouseEnter += new System.EventHandler(this.btn_report_MouseEnter);
            this.btn_report.MouseLeave += new System.EventHandler(this.btn_report_MouseLeave);
            // 
            // btn_price
            // 
            this.btn_price.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_price.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_price.ForeColor = System.Drawing.Color.Red;
            this.btn_price.Location = new System.Drawing.Point(36, 458);
            this.btn_price.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_price.Name = "btn_price";
            this.btn_price.Size = new System.Drawing.Size(316, 72);
            this.btn_price.Style = MetroFramework.MetroColorStyle.Orange;
            this.btn_price.TabIndex = 0;
            this.btn_price.Text = "Price";
            this.btn_price.UseSelectable = true;
            this.btn_price.Click += new System.EventHandler(this.btn_price_Click);
            this.btn_price.MouseEnter += new System.EventHandler(this.btn_price_MouseEnter);
            this.btn_price.MouseLeave += new System.EventHandler(this.btn_price_MouseLeave);
            // 
            // btn_item
            // 
            this.btn_item.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_item.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_item.ForeColor = System.Drawing.Color.Red;
            this.btn_item.Location = new System.Drawing.Point(36, 377);
            this.btn_item.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_item.Name = "btn_item";
            this.btn_item.Size = new System.Drawing.Size(316, 72);
            this.btn_item.Style = MetroFramework.MetroColorStyle.Orange;
            this.btn_item.TabIndex = 0;
            this.btn_item.Text = "Items";
            this.btn_item.UseSelectable = true;
            this.btn_item.Click += new System.EventHandler(this.btn_item_Click);
            this.btn_item.MouseEnter += new System.EventHandler(this.btn_item_MouseEnter);
            this.btn_item.MouseLeave += new System.EventHandler(this.btn_item_MouseLeave);
            // 
            // btn_cate
            // 
            this.btn_cate.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_cate.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_cate.ForeColor = System.Drawing.Color.Red;
            this.btn_cate.Location = new System.Drawing.Point(36, 295);
            this.btn_cate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_cate.Name = "btn_cate";
            this.btn_cate.Size = new System.Drawing.Size(316, 72);
            this.btn_cate.Style = MetroFramework.MetroColorStyle.Orange;
            this.btn_cate.TabIndex = 0;
            this.btn_cate.Text = "Category";
            this.btn_cate.UseSelectable = true;
            this.btn_cate.Click += new System.EventHandler(this.btn_cate_Click);
            this.btn_cate.MouseEnter += new System.EventHandler(this.btn_cate_MouseEnter);
            this.btn_cate.MouseLeave += new System.EventHandler(this.btn_cate_MouseLeave);
            // 
            // SlidePanel
            // 
            this.SlidePanel.BackColor = System.Drawing.Color.Red;
            this.SlidePanel.Location = new System.Drawing.Point(12, 214);
            this.SlidePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SlidePanel.Name = "SlidePanel";
            this.SlidePanel.Size = new System.Drawing.Size(15, 72);
            this.SlidePanel.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(57, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(254, 163);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btn_sale
            // 
            this.btn_sale.BackColor = System.Drawing.Color.White;
            this.btn_sale.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_sale.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_sale.ForeColor = System.Drawing.Color.Red;
            this.btn_sale.Location = new System.Drawing.Point(36, 214);
            this.btn_sale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_sale.Name = "btn_sale";
            this.btn_sale.Size = new System.Drawing.Size(316, 72);
            this.btn_sale.Style = MetroFramework.MetroColorStyle.Orange;
            this.btn_sale.TabIndex = 0;
            this.btn_sale.Text = "Sale";
            this.btn_sale.UseSelectable = true;
            this.btn_sale.Click += new System.EventHandler(this.btn_sale_Click);
            this.btn_sale.MouseEnter += new System.EventHandler(this.btn_sale_MouseEnter);
            this.btn_sale.MouseLeave += new System.EventHandler(this.btn_sale_MouseLeave);
            // 
            // progressbar1
            // 
            this.progressbar1.Location = new System.Drawing.Point(174, 131);
            this.progressbar1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.progressbar1.Name = "progressbar1";
            this.progressbar1.Size = new System.Drawing.Size(338, 318);
            this.progressbar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 749);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btn_sale;
        private MetroFramework.Controls.MetroButton btn_cate;
        private MetroFramework.Controls.MetroButton btn_item;
        private MetroFramework.Controls.MetroButton btn_price;
        private MetroFramework.Controls.MetroButton btn_report;
        private MetroFramework.Controls.MetroButton btn_setting;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel SlidePanel;
        private Page.Progressbar progressbar1;
        public System.Windows.Forms.SplitContainer splitContainer2;
    }
}

