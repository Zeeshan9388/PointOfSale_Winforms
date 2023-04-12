using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        Page.Classess_.gernal g= new Page.Classess_.gernal();
        public Dashboard()
        {
            InitializeComponent();
            SlidePanel.Height = btn_sale.Height;
           // SlidePanel.Top = btn_sale.Top;
           // g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "sale");

        }

        private void btn_sale_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report,btn_setting, SlidePanel, "sale");


            Page.Sale s = new Page.Sale();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s);
        }

        private void btn_cate_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "cat");


            Page.Category s = new Page.Category();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s);
        }

        private void btn_item_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "item");



            Page.Items s = new Page.Items();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s);
        }

        private void btn_price_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "price");


            Page.Price s = new Page.Price();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s);
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "rprt");


            Page.Report s = new Page.Report();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s);
        }

        private void btn_sale_MouseEnter(object sender, EventArgs e)
        {
            //g.btn("h", btn_sale);
        }

        private void btn_sale_MouseLeave(object sender, EventArgs e)
        {
           // g.btn("l", btn_sale);
        }

        private void btn_cate_MouseEnter(object sender, EventArgs e)
        {
            //g.btn("h", btn_cate);
        }

        private void btn_cate_MouseLeave(object sender, EventArgs e)
        {
           // g.btn("l", btn_cate);
        }

        private void btn_item_MouseEnter(object sender, EventArgs e)
        {
           // g.btn("h", btn_item);
        }

        private void btn_item_MouseLeave(object sender, EventArgs e)
        {
           // g.btn("l", btn_item);
        }

        private void btn_price_MouseEnter(object sender, EventArgs e)
        {
           // g.btn("h", btn_price);
        }

        private void btn_price_MouseLeave(object sender, EventArgs e)
        {
          //  g.btn("l", btn_price);
        }

        private void btn_report_MouseEnter(object sender, EventArgs e)
        {
          //  g.btn("h", btn_report);
        }

        private void btn_report_MouseLeave(object sender, EventArgs e)
        {
          //  g.btn("l", btn_report);
        }

        private void btn_setting_MouseEnter(object sender, EventArgs e)
        {
          //  g.btn("h", btn_setting);
        }

        private void btn_setting_MouseLeave(object sender, EventArgs e)
        {
          //  g.btn("l", btn_setting);
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            g.btn_chck(btn_sale, btn_cate, btn_item, btn_price, btn_report, btn_setting, SlidePanel, "setting");

            //if (splitContainer2.Panel2.Controls.Count > 0)
            //{

            //    splitContainer2.Panel2.Controls.Clear();
            //}

            //for (int i = 0; i <= 100; i++)
            //{
            //    new Thread(new System.Threading.ParameterizedThreadStart(this.Progressupgrade)).Start(i);
            //}
            
            Page.Setting s = new Page.Setting();
            if (splitContainer2.Panel2.Controls.Count > 0)
            {

                splitContainer2.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(s); 
        }
        public void Progressupgrade(object progress)
        {
            progressbar1.Invoke((MethodInvoker)delegate { progressbar1.updateprogress(Convert.ToInt32(progress)); });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Progressupgrade(100);
        }
    }
}
