using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PointOfSale.Page.Classess_
{
    class gernal
    {
        
        public static string login_name = "";
        public void btn_chck(Button btn_sale, Button btn_cat, Button btn_item, Button btn_price, Button btn_report, Button btn_setting, Panel SlidePanel, string btn)
        {

            if (btn == "sale")
            {
                SlidePanel.Height = btn_sale.Height;
                SlidePanel.Top = btn_sale.Top;

                btn_sale.BackColor = Color.Maroon;
                btn_sale.ForeColor = Color.White;

                //------------------------
                btn_cat.BackColor = Color.Red;
                btn_cat.ForeColor = Color.White;
                //-----------------------
                btn_item.BackColor = Color.Red;
                btn_item.ForeColor = Color.White;
                //-------------------------------
                btn_price.BackColor = Color.Red;
                btn_price.ForeColor = Color.White;
                //-------------------------------
                btn_report.BackColor = Color.Red;
                btn_report.ForeColor = Color.White;
                //-------------------------------
                btn_setting.BackColor = Color.Red;
                btn_setting.ForeColor = Color.White;
            }
            if (btn == "cat")
            {
                btn_cat.BackColor = Color.Maroon;
                btn_cat.ForeColor = Color.White;

                SlidePanel.Height = btn_cat.Height;
                SlidePanel.Top = btn_cat.Top;

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                  //-----------------------
                btn_item.BackColor = Color.Red;
                btn_item.ForeColor = Color.White;
                //-------------------------------
                btn_price.BackColor = Color.Red;
                btn_price.ForeColor = Color.White;
                //-------------------------------
                btn_report.BackColor = Color.Red;
                btn_report.ForeColor = Color.White;
                //-------------------------------
                btn_setting.BackColor = Color.Red;
                btn_setting.ForeColor = Color.White;
            

            }
            if (btn == "item")
            {
                btn_item.BackColor = Color.Maroon;
                btn_item.ForeColor = Color.White;

                SlidePanel.Height = btn_item.Height;
                SlidePanel.Top = btn_item.Top;

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_cat.BackColor = Color.Red;
                btn_cat.ForeColor = Color.White;
                
                //-------------------------------
                btn_price.BackColor = Color.Red;
                btn_price.ForeColor = Color.White;
                //-------------------------------
                btn_report.BackColor = Color.Red;
                btn_report.ForeColor = Color.White;
                //-------------------------------
                btn_setting.BackColor = Color.Red;
                btn_setting.ForeColor = Color.White;

            }
            if (btn == "price")
            {
                btn_price.BackColor = Color.Maroon;
                btn_price.ForeColor = Color.White;

                SlidePanel.Height = btn_price.Height;
                SlidePanel.Top = btn_price.Top;

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_cat.BackColor = Color.Red;
                btn_cat.ForeColor = Color.White;

                //-------------------------------
                btn_item.BackColor = Color.Red;
                btn_item.ForeColor = Color.White;
                //-------------------------------
                btn_report.BackColor = Color.Red;
                btn_report.ForeColor = Color.White;

                //-------------------------------
                btn_setting.BackColor = Color.Red;
                btn_setting.ForeColor = Color.White;

            }
            if (btn == "rprt")
            {

                SlidePanel.Height = btn_report.Height;
                SlidePanel.Top = btn_report.Top;

                btn_report.BackColor = Color.Maroon;
                btn_report.ForeColor = Color.White;

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_cat.BackColor = Color.Red;
                btn_cat.ForeColor = Color.White;

                //-------------------------------
                btn_item.BackColor = Color.Red;
                btn_item.ForeColor = Color.White;
                //-------------------------------
                btn_price.BackColor = Color.Red;
                btn_price.ForeColor = Color.White;
                //-------------------------------
                btn_setting.BackColor = Color.Red;
                btn_setting.ForeColor = Color.White;

            }
            if (btn == "setting")
            {

                SlidePanel.Height = btn_setting.Height;
                SlidePanel.Top = btn_setting.Top;


                btn_setting.BackColor = Color.Maroon;
                btn_setting.ForeColor = Color.White;
               

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_cat.BackColor = Color.Red;
                btn_cat.ForeColor = Color.White;

                //-------------------------------
                btn_item.BackColor = Color.Red;
                btn_item.ForeColor = Color.White;
                //-------------------------------
                btn_price.BackColor = Color.Red;
                btn_price.ForeColor = Color.White;
                //---------------------------------

                btn_report.BackColor = Color.Red;
                btn_report.ForeColor = Color.White;

            }

        }
        
              public void ch_login_(Telerik.WinControls.UI.RadButton btn)
        {
            if (login_name == "User")
            {
                btn.Visible = false;
            }
            if (login_name == "Admin")
            {
                btn.Visible = true;
            }

        }
        public void ch_login_(MetroFramework.Controls.MetroButton btn)
        {
            if (login_name == "User")
            {
                btn.Visible = false;
            }
            if (login_name == "Admin")
            {
                btn.Visible = true;
            }

        }
        public void ch_login_(Button btn)
        {
            if (login_name == "User")
            {
                btn.Visible = false;
            }
            if (login_name == "Admin")
            {
                btn.Visible = true;
            }

        }
        public Label addlbl(int strt, int end, int width, int height, string lbl_str, string lbl_name, Color forecolor, Color backcolor)
        {
            Label l = new Label();
            l.Name = lbl_name;
            l.Text = lbl_str;
            l.ForeColor = forecolor;
            l.BackColor = backcolor;
            l.Font = new Font("Arial", 12, FontStyle.Bold);
            //l.Width = 170;
            //l.Height = 80;
            l.Width = width;
            l.Height = height;
            l.Location = new Point(strt, end);
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Margin = new Padding(5);

            return l;
        }
        public RadioButton radiobtnMethod(int strt, int end, int width, int height, string lbl_str, string lbl_name, Color forecolor, Color backcolor)
        {
            RadioButton radiobtn = new RadioButton();

            radiobtn.Name = lbl_name;
            radiobtn.Text = lbl_str;
            radiobtn.ForeColor = forecolor;
            radiobtn.BackColor = backcolor;
            radiobtn.Font = new Font("Arial", 9, FontStyle.Regular);

            radiobtn.Width = width;
            radiobtn.Height = height;
            radiobtn.Location = new Point(strt, end);
            radiobtn.TextAlign = ContentAlignment.MiddleCenter;
            radiobtn.Margin = new Padding(5);

            return radiobtn;
        }
        public MetroFramework.Controls.MetroRadioButton radiobtnMethod(int strt, int end, int width, int height, string lbl_str, string lbl_name)
        {
            MetroFramework.Controls.MetroRadioButton radiobtn = new MetroFramework.Controls.MetroRadioButton();

            radiobtn.Name = lbl_name;
            radiobtn.Text = lbl_str;

            // r.Font = new Font("Arial", 7, FontStyle.Regular);

            radiobtn.Width = width;
            radiobtn.Height = height;
            radiobtn.Location = new Point(strt, end);
            radiobtn.TextAlign = ContentAlignment.MiddleCenter;
            radiobtn.Margin = new Padding(5);

            return radiobtn;
        }
  
        public void btn(string str,Button btn)
        {
            if (str == "h")
            {
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Red;
            }
            if(str=="l")
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Red;
            }
        }
        public void btn_(Button btn, string str)
        {
            if (str == "h")
            {
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Red;
            }
            if (str == "l")
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Red;
            }
        }
    }
}
