using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PointOfSale.Page
{
    public partial class Sale : MetroFramework.Controls.MetroUserControl
    {
        //string takeaway, din, hd = string.Empty;
        //float f_txt, price1, total=0;
        int strt = 5, end = 1;
       
        public static string saleid, ssid, tblid, prdctid, itemid, PID, itemsize, itemrate, lblsize, deal_size, psid, pstatus, OCate = null;
       
        public static MetroFramework.Controls.MetroRadioButton radiobtn_size, size;
        string descrip = Classess_.ClsMessage.DevelopedBy;
         DataTable dt = null;
        method dd = new method();
        Page.Classess_.sale objsale = new Classess_.sale();
        Classess_.gernal objgenral = new Classess_.gernal();
        int small, large = 0;
        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            
            lbl_id.Text = objsale.ID();
            objsale.lstset(lstview_selected);
            objsale.lstset_process(lstview_process);
            objsale.get_prdct(lst_prdct, txt_prdct, lbl_prdct_rows);
            objsale.tl(radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables);
            objsale.show_process(lstview_process, lbl_process_rows);
            objsale.get_deal(numberic_qty, numberic_dis, lbl_grosstotal, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset, "new");
           objgenral.ch_login_(btn_cancelled);
        }

        private void tabControl2_Resize(object sender, EventArgs e)
        {
            small = 50;
            large = 150;
            if (this.Width < 462)
            {
                btn_sm.Width = small;
                btn_sd.Width = small;
                btn_Smart_1.Width = small;
                btn_smrt_2.Width = small;
                btn_value_1.Width = small;
                btn_value_2.Width = small;
                btn_classic.Width = small;
                btn_couple.Width = small;
                btn_family_feast.Width = small;
                btn_midnight.Width = small;
            }
            else
            {
                btn_sm.Width = large;
                btn_sd.Width = large;
                btn_Smart_1.Width = large;
                btn_smrt_2.Width = large;
                btn_value_1.Width = large;
                btn_value_2.Width = large;
                btn_classic.Width = large;
                btn_couple.Width = large;
                btn_family_feast.Width = large;
                btn_midnight.Width = large;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            objsale.save("q", numberic_qty, lbl_total, lbl_grosstotal, numberic_dis, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset, btn_KO, btn_print);
            lbl_select_id.Text = "Selected Items " + Page.Classess_.sale.saleid;
          
        }

        private void numberic_qty_ValueChanged(object sender, EventArgs e)
        {
            objsale.qty(numberic_qty, lbl_total);
        }

        private void numberic_dis_ValueChanged(object sender, EventArgs e)
        {
            objsale.discount(lbl_grosstotal, numberic_dis, lbl_dis_value, lbl_nettotal);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            lbl_id.Text = objsale.ID();
            objsale.get_deal(numberic_qty, numberic_dis, lbl_grosstotal, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset, "new");
       
        }
        [DllImport("Winspool.drv")]
        private static extern bool SetDefaultPrinter(string printerName);
        private void btn_KO_Click(object sender, EventArgs e)
        {
            try
            {
                objsale.nettotal(lbl_grosstotal, numberic_qty, numberic_dis, lbl_dis_value, lbl_nettotal, radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables, lstview_process, lstview_selected, lst_prdct, txt_prdct, lbl_process_rows, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset);
                var defaultPrinterName = prntdoc_KO.PrinterSettings.PrinterName;
                prntdoc_KO.PrinterSettings.PrinterName = prntdoc_KO.PrinterSettings.PrinterName;

                if (prntdoc_KO.PrinterSettings.IsValid)
                {
                    SetDefaultPrinter(prntdoc_KO.PrinterSettings.PrinterName);
                    prntdoc_KO.Print();

                    Classess_.sale.psid = null;
                    lbl_id.Text = objsale.ID();
                   // lbl_ticket.Text = s.ID();
                    // panel2.Show();
                    SetDefaultPrinter(defaultPrinterName);
                }
                //prntdoc_KO.Print();

                // s.nettotal(lbl_grosstotal, numberic_qty, numberic_dis, lbl_dis_value, lbl_nettotal, radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables, lstview_process, lstview_selected, lst_prdct, txt_prdct, lbl_process_rows, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset);

                //   prntdoc_customer_recipet.Print();
                objsale.show_process(lstview_process, lbl_process_rows);
                objsale.get_deal(numberic_qty, numberic_dis, lbl_grosstotal, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset, "new");
                lbl_select_id.Text = "Selected Items";
            }
            catch (Exception)
            { }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            objsale.edit_(radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables, numberic_qty, lbl_total, lbl_grosstotal, numberic_dis, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset);
       
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            objsale.del_(numberic_qty, lbl_total, lbl_grosstotal, numberic_dis, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset);
       
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            objsale.clear(numberic_qty, lbl_total, lbl_grosstotal, numberic_dis, lbl_dis_value, lbl_nettotal, lstview_selected, lst_prdct, txt_prdct, lbl_selected_rows, lbl_prdct_rows, btn_add, btn_update, btn_reset);
       
        }

        private void radiobtn_homedeliver_CheckedChanged(object sender, EventArgs e)
        {
            objsale.tl(radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables);
       
        }

        private void radiobtn_dinning_CheckedChanged(object sender, EventArgs e)
        {
            objsale.tl(radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables);
       
        }

        private void radiobtn_takeaway_CheckedChanged(object sender, EventArgs e)
        {
            objsale.tl(radiobtn_takeaway, radiobtn_dinning, radiobtn_homedeliver, combox_tables);
       
        }
        
        /*------------------------[ E N D ]----------------------------*/
      
        public void crete_company(FlowLayoutPanel flp)
        {
            if (flp.Controls.Count > 0)
            {
                flp.Controls.Clear();
            }
            /*No size
Jambo
Extra Large
Large
Medium
Small*/
            dt = dd.dT_get("Select * From tbl_Pricelist Where NID=" + Classess_.sale.prdctid + " AND ItemID=" + Classess_.sale.itemid + "");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Size_"].ToString() == "No size")
                {
                    itemsize = "";
                }
                if (dr["Size_"].ToString() == "Large")
                {
                    itemsize = "( L )";
                }
                if (dr["Size_"].ToString() == "Medium")
                {
                    itemsize = "( M )";
                }
                if (dr["Size_"].ToString() == "Small")
                {
                    itemsize = "( S )";
                }
                if (dr["Size_"].ToString() == "Extra Large")
                {
                    itemsize = "( X-L )";
                }
                if (dr["Size_"].ToString() == "Jambo")
                {
                    itemsize = "( J )";
                }

                // radiobtn_size = g.radiobtn(strt, end, 90, 20, dr["Price_"].ToString() + " " + itemsize, dr["PID"].ToString());
                Classess_.sale.radiobtn_size = objgenral.radiobtnMethod(strt, end, 90, 20, dr["Price_"].ToString() + " " + itemsize, dr["PID"].ToString());

                flp.Controls.Add(Classess_.sale.radiobtn_size);
                Classess_.sale.radiobtn_size.Click += new EventHandler(this.radiobtn_size_Click);
                end += 100;
            }
        }
        void radiobtn_size_Click(object sender, EventArgs e)
        {

            Classess_.sale.size = (MetroFramework.Controls.MetroRadioButton)sender;

            objsale.qty(numberic_qty, lbl_total);

        }

        private void txt_prdct_TextChanged(object sender, EventArgs e)
        {
            objsale.get_prdct(lst_prdct, txt_prdct, lbl_prdct_rows);
        }

        private void txt_item_TextChanged(object sender, EventArgs e)
        {
            objsale.get_item(lst_item, txt_item, lbl_item_rows, "");
        }

        private void lst_prdct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            objsale.select_product(lst_prdct, lst_item, sender, e);
            lbl_prdct.Text = lst_prdct.Text + " : " + lst_item.Text;
            lbl_pname.Text = "Search " + lst_prdct.Text + "'s";

            objsale.get_item(lst_item, txt_item, lbl_item_rows, "");
        }

        private void lst_item_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            objsale.select_item(lst_item, sender, e);
            lbl_prdct.Text = lst_prdct.Text + " : " + lst_item.Text;
            crete_company(flowLayoutPanel1);
        }
        string underLine=string.Empty;
        private void prntdoc_KO_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region  K-O print Recipt


            //  try
            ////  {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 20;
            int Offset = 40;
            //cash book
            //con.Open();
            string sid = "";
            string sel = "";
            if (ssid == psid)
            {

            }
            if (Convert.ToInt32(psid) > 0)
            {
                sel = "Select * From tbl_sale Where SalesID=" + psid + "";
                sid = psid;
            }
            if (Convert.ToInt32(ssid) > 0)
            {
                sel = "Select * From tbl_sale Where SalesID=" + ssid + "";
                sid = ssid;
            }
            if (dd.RunQuery_Scaler("Select SalesID From tbl_sale Order by SalesID desc") == saleid)
            {
                sel = "Select * From tbl_sale Where SalesID=" + saleid + "";
                sid = saleid;

            }
            dt = dd.dT_get(sel);





            graphics.DrawString("For Kichten Staff ", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Shop's name ", new Font("Colonna MT", 14, FontStyle.Bold),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Location: -----", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 10 + Offset);

            /*
            graphics.DrawString("For Kichten Staff ", new Font("Arial", 8, FontStyle.Regular),
                                       new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Shop name ", new Font("Colonna MT", 14, FontStyle.Bold),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Shop Address", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 10 + Offset);*/
            Offset = Offset + 20;
            graphics.DrawString("Ticket ID :" + sid,
                    new Font("Courier New", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Date: " + DateTime.Now.ToString("dd-MMM-yyyy"),
                     new Font("Courier New", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Time: " + DateTime.Now.ToShortTimeString(),
                     new Font("Courier New", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Order Type: " + OCate,
                         new Font("Courier New", 9),
                         new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;





            graphics.DrawString("Item's            Qty ",
                     new Font("Courier New", 9, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 10;
            underLine = "-------------------------------------------";
            graphics.DrawString(underLine, new Font("Arial", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;


            foreach (DataRow dr in dt.Rows)
            {

                //dd.RunQuery_Scaler("Select Catname From CatName Where NID="++"");
                if (dr["NID"].ToString() != "0" && dr["ItemID"].ToString() != "0")
                {

                    //if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Sweets")
                    //{
                    //    graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " \t " + dr["Qty"].ToString() + " ", new Font("Arial", 8),
                    //                                            new SolidBrush(Color.Black), 10, startY + Offset);
                    //}
                    if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Fast Food")
                    {
                        graphics.DrawString("F:Food  -   " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                                 new SolidBrush(Color.Black), 10, startY + Offset);
                    }
                    else if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Pizza")
                    {
                        graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " - " + dr["ItemSize"].ToString(), new Font("Arial", 8),
                                  new SolidBrush(Color.Black), 10, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                                                               new SolidBrush(Color.Black), 10, startY + Offset);
                    }

                    //graphics.DrawString(dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                    //     new SolidBrush(Color.Black), 75, startY + Offset);
                }
                else
                {
                    graphics.DrawString("Deal - " + dr["ItemSize"].ToString(), new Font("Arial", 8),
                             new SolidBrush(Color.Black), 10, startY + Offset);

                }
                graphics.DrawString(dr["Qty"].ToString(), new Font("Arial", 8),
                    new SolidBrush(Color.Black), 150, startY + Offset);
                //Offset = Offset + 20;
                //graphics.DrawString(dr["Qty"].ToString(), new Font("Arial", 8),
                //         new SolidBrush(Color.Black), 120, startY + Offset);

                Offset = Offset + 20;


            }



            // Offset = Offset + 20;
            graphics.DrawString(underLine, new Font("Arial", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            // Offset = Offset + 20;

            Offset = Offset + 20;
            graphics.DrawString(descrip, new Font("Arial", 8),
                 new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            Offset = Offset + 20;
            Offset = Offset + 20;
            Offset = Offset + 20;
            Offset = Offset + 20;
            Offset = Offset + 20;
            #endregion

            // --------------------CUSTOMER -------- Print 

            #region Customer Recipt


            if (Convert.ToInt32(psid) > 0)
            {

                sid = psid;
            }

            if (dd.RunQuery_Scaler("Select SalesID From tbl_sale Order by SalesID desc") == saleid && psid == "" || psid == null)
            {

                sid = saleid;

            }

            graphics.DrawString("For Customer ", new Font("Arial", 8, FontStyle.Regular),
                                 new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Shop's name ", new Font("Colonna MT", 14, FontStyle.Bold),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Location: -----", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 10 + Offset);
            /*  graphics.DrawString("For Customer ", new Font("Arial", 8, FontStyle.Regular),
                               new SolidBrush(Color.Black), 10, 0 + Offset);
              Offset = Offset + 20;
              graphics.DrawString("Shop name ", new Font("Colonna MT", 14, FontStyle.Bold),
                                  new SolidBrush(Color.Black), 10, 0 + Offset);
              Offset = Offset + 20;

              graphics.DrawString("Shop Address ", new Font("Arial", 8, FontStyle.Regular),
                                  new SolidBrush(Color.Black), 10, 10 + Offset);
          */
            Offset = Offset + 20;
            graphics.DrawString("Ticket ID :" + sid,
                    new Font("Courier New", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Date: " + DateTime.Now.ToString("dd-MMM-yyyy"),
                     new Font("Courier New", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Time: " + DateTime.Now.ToShortTimeString(),
                     new Font("Courier New", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Order Type: " + OCate,
                         new Font("Courier New", 9),
                         new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;





            graphics.DrawString("Item's          Qty   Total",
                     new Font("Courier New", 9, FontStyle.Bold),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 10;
            underLine = "----------------------------------------------------";
            graphics.DrawString(underLine, new Font("Arial", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;


            foreach (DataRow dr in dt.Rows)
            {


                if (dr["NID"].ToString() != "0" && dr["ItemID"].ToString() != "0")
                {

                    //if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Sweets")
                    //{
                    //    graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " \t " + dr["Qty"].ToString() + " ", new Font("Arial", 8),
                    //                                            new SolidBrush(Color.Black), 10, startY + Offset);
                    //}
                    if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Fast Food")
                    {
                        graphics.DrawString("F:Food - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                                 new SolidBrush(Color.Black), 10, startY + Offset);
                    }

                    else if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Pizza")
                    {
                        graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " - " + dr["ItemSize"].ToString(), new Font("Arial", 8),
                                  new SolidBrush(Color.Black), 10, startY + Offset);
                    }
                    else
                    {
                        graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                                                               new SolidBrush(Color.Black), 10, startY + Offset);
                    }

                    //graphics.DrawString(dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + ""), new Font("Arial", 8),
                    //     new SolidBrush(Color.Black), 75, startY + Offset);
                }
                else
                {
                    graphics.DrawString("Deal - " + dr["ItemSize"].ToString(), new Font("Arial", 8),
                             new SolidBrush(Color.Black), 10, startY + Offset);

                }


                graphics.DrawString(dr["Qty"].ToString(), new Font("Arial", 8),
                         new SolidBrush(Color.Black), 150, startY + Offset);

                graphics.DrawString(dr["Total"].ToString(), new Font("Arial", 8),
                         new SolidBrush(Color.Black), 190, startY + Offset);
                Offset = Offset + 20;


            }



            graphics.DrawString(underLine, new Font("Arial", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            if (Convert.ToInt64(psid) > 0)
            {
                graphics.DrawString("GrossTotal: " + dd.RunQuery_Scaler(" Select Isnull(Sum(GTotal),0) From tbl_NetTotal Where SaleID=" + psid + ""), new Font("Arial", 8),
                       new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Discount %: " + dd.RunQuery_Scaler(" Select Isnull(Sum(DPrcnatge),0) From tbl_NetTotal Where SaleID=" + psid + ""), new Font("Arial", 8),
                        new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Discount V: " + dd.RunQuery_Scaler(" Select Isnull(Sum(DValue),0) From tbl_NetTotal Where SaleID=" + psid + ""), new Font("Arial", 8),
                       new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("NetTotal: " + dd.RunQuery_Scaler(" Select Isnull(Sum(NetTotal),0) From tbl_NetTotal Where SaleID=" + psid + ""), new Font("Arial", 8),
                       new SolidBrush(Color.Black), 150, startY + Offset);
            }
            else
            {
                graphics.DrawString("GrossTotal: " + dd.RunQuery_Scaler(" Select Isnull(Sum(GTotal),0) From tbl_NetTotal Where SaleID=" + sid + ""), new Font("Arial", 8),
                     new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Discount %: " + dd.RunQuery_Scaler(" Select Isnull(Sum(DPrcnatge),0) From tbl_NetTotal Where SaleID=" + sid + ""), new Font("Arial", 8),
                        new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Discount V: " + dd.RunQuery_Scaler(" Select Isnull(Sum(DValue),0) From tbl_NetTotal Where SaleID=" + sid + ""), new Font("Arial", 8),
                       new SolidBrush(Color.Black), 150, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("NetTotal: " + dd.RunQuery_Scaler(" Select Isnull(Sum(NetTotal),0) From tbl_NetTotal Where SaleID=" + sid + ""), new Font("Arial", 8),
                       new SolidBrush(Color.Black), 150, startY + Offset);
            }



            Offset = Offset + 20;
            graphics.DrawString(descrip, new Font("Arial", 8),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            lbl_order_status.Text = saleid + "  Processing... ";
            #endregion
        }

        private void prntdoc_customer_recipet_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void btn_Tender_Click(object sender, EventArgs e)
        {

        }

       

       
    }
}
