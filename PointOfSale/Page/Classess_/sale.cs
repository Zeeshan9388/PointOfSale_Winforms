using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;

namespace PointOfSale.Page.Classess_
{
    class sale
    {
        string takeaway, din, hd = string.Empty;
        float f_txt, price1, total;
        int strt = 5, end = 1;
        DataTable dt = null;
        public static string saleid, ssid, tblid, prdctid, itemid, PID, itemsize,  lblsize, deal_size, psid, pstatus, OCate = string.Empty;
        gernal g = new gernal();
       method dd = new method();
        public static MetroFramework.Controls.MetroRadioButton radiobtn_size, size;
        /// <summary>
        /// Create Radiobtn in loop 
        /// </summary>
        /// 
        string descrip = "Software Developed by: MZR Softwares\n 0335 1206586 - www.mzrsoftware.com";
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
            dt = dd.dT_get("Select * From tbl_Pricelist Where NID=" + prdctid + " AND ItemID=" + itemid + "");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Size_"].ToString() == "")
                {
                    lblsize = "";
                }
                if (dr["Size_"].ToString() == "No size")
                {
                    lblsize = "";
                }
                if (dr["Size_"].ToString() == "Large")
                {
                    lblsize = "( L )";
                }
                if (dr["Size_"].ToString() == "Medium")
                {
                    lblsize = "( M )";
                }
                if (dr["Size_"].ToString() == "Small")
                {
                    lblsize = "( S )";
                }
                if (dr["Size_"].ToString() == "Extra Large")
                {
                    lblsize = "( X-L )";
                }
                if (dr["Size_"].ToString() == "Jambo")
                {
                    lblsize = "( J )";
                }
                radiobtn_size = g.radiobtnMethod(strt, end, 110, 20, dr["Price_"].ToString() + " " + lblsize, dr["PID"].ToString());
                //  radiobtn_size = g.radiobtn(strt, end, 90, 20, dr["Price_"].ToString() , dr["PID"].ToString());

                flp.Controls.Add(radiobtn_size);
                radiobtn_size.Click += new EventHandler(this.radiobtn_size_Click);
                end += 100;
            }
        }
        void radiobtn_size_Click(object sender, EventArgs e)
        {
            size = (MetroFramework.Controls.MetroRadioButton)sender;



        }
        /// <summary>
        /// All Method here  
        /// </summary>
        /// 
        public string ID()
        {
            if (Convert.ToInt32(dd.RunQuery_Scaler("Select isnull(([SalesID]),0) From tbl_sale Order by [SalesID] desc")) > 0)
            {
                saleid = dd.RunQuery_Scaler("Select isnull((([SalesID])+1),0) From tbl_sale Order by [SalesID] desc");
            }
            else
            {
                saleid = "1001";
            }
            return saleid;
        }
        public void qty(NumericUpDown numberic, Label lbl_total)
        {
            try
            {
                itemsize = dd.RunQuery_Scaler("Select Size_ From tbl_Pricelist Where PID=" + size.Name + "");
                price1 = ((float)Convert.ToDouble(dd.RunQuery_Scaler("Select Isnull(Sum(Price_),0) From tbl_Pricelist Where PID=" + size.Name + "")));
                total = ((float)Convert.ToDouble(numberic.Value) * (price1));
                lbl_total.Text = "Total : " + ((float)Convert.ToDouble(numberic.Value) * (price1)).ToString();
            }
            catch (Exception)
            {
                lbl_total.Text = "Total : " + "0";
            }
        }
        public void select_product(ComboBox combox_prdct, ComboBox combox_item, object sender, EventArgs e)
        {
            if (dd.RunQuery_Scaler("Select NID From CatName Where Catname='" + combox_prdct.Text + "'") == "")
            {
                prdctid = "0";
            }
            else
            {
                prdctid = dd.RunQuery_Scaler("Select NID From CatName Where Catname='" + combox_prdct.Text + "'");

            }
            
            dd.get_Combox_only("Select UItems_ From UItems_ Where NID= " + prdctid + "", combox_item);
        }
        public void select_product(ListBox lstbox_prdct, ListBox lstbox_item, object sender, EventArgs e)
        {
            if (dd.RunQuery_Scaler("Select NID From CatName Where Catname='" + lstbox_prdct.Text + "'") == "")
            {
                prdctid = "0";
            }
            else
            {
                prdctid = dd.RunQuery_Scaler("Select NID From CatName Where Catname='" + lstbox_prdct.Text + "'");

            }
            dd.IsFillListBox("Select UItems_ From UItems_ Where NID= " + prdctid + "", lstbox_item);

        }
        public void get_prdct(ListBox lstbox, TextBox txtbox, Label lbl_rows_prdct)
        {
            /*    dd.get_lstbox("Select Catname From CatName Where Catname like '" + txtbox.Text + "%'", lstbox);
            lbl_rows_prdct.Text = "Rows: " + dd.RunQuery_Scaler("Select IsNull(Count(NID),0) From CatName Where Catname like '" + txtbox.Text + "%'");
        */
            lstbox.ForeColor = Color.Red;
            dd.IsFillListBox("Select Catname From CatName ", lstbox);
            lbl_rows_prdct.Text = "Rows: " + dd.RunQuery_Scaler("Select IsNull(Count(NID),0) From CatName ");
        }
        public void get_item(ListBox lstbox, TextBox txtbox, Label lbl_item, string s)
        {
            dd.IsFillListBox("Select UItems_ From UItems_ Where NID=" + prdctid + " ", lstbox);
            lbl_item.Text = "Rows: " + dd.RunQuery_Scaler("Select Isnull(Count(ItemID),0) From UItems_ Where NID=" + prdctid + "");

            /*            dd.get_lstbox("Select UItems_ From UItems_ Where NID=" + prdctid + " AND UItems_ like '%" + txtbox.Text + "%'", lstbox);
            lbl_item.Text = "Rows: " + dd.RunQuery_Scaler("Select Isnull(Count(ItemID),0) From UItems_ Where NID=" + prdctid + " AND UItems_ like '" + txtbox.Text + "%'");
*/
            //if (s == "all")
            //{
            //    lbl_item.Text = "Rows: " + dd.RunQuery_Scaler("Select Count((ItemID),0) From UItems_ Where NID=" + prdctid + "");

            //}
            //else
            //{

           
            //}

        }
        public void select_item(ComboBox combox_item, object sender, EventArgs e)
        {
            if (dd.RunQuery_Scaler("Select ItemID From UItems_ Where UItems_='" + combox_item.Text + "'") == "")
            {
                itemid = "0";
            }
            else
            {
                itemid = dd.RunQuery_Scaler("Select ItemID From UItems_ Where UItems_='" + combox_item.Text + "'");

            }
        }
        public void select_item(ListBox lstbox_item, object sender, EventArgs e)
        {
            if (dd.RunQuery_Scaler("Select ItemID From UItems_ Where UItems_='" + lstbox_item.Text + "'") == "")
            {
                itemid = "0";
            }
            else
            {
                itemid = dd.RunQuery_Scaler("Select ItemID From UItems_ Where UItems_='" + lstbox_item.Text + "'");

            }
        }

        public void select_size(ComboBox combox_size, object sender, EventArgs e)
        {
            itemsize = combox_size.Text;
        }

        public void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            dd.IsdecimalAllow(sender, e);
        }
        public float float_(TextBox txt)
        {
            try
            {
                f_txt = (float)Convert.ToDouble(txt.Text);
            }
            catch (Exception)
            {
                f_txt = 0;
            }
            txt.Text = f_txt.ToString();
            return f_txt;
        }
        public void srch(TextBox txt_user, ListView lstview, Label lbl_rows)
        {
             Get_lstview(lstview, "Select PID as[ID],prdct.Catname as[Product],it.UItems_ as[Items],Size_ as[Size],rate.Price_ as[Price] from tbl_Pricelist rate,CatName prdct,UItems_ it Where prdct.NID= " + prdctid + " AND it.ItemID=" + itemid + " AND rate.Size_ ='" + size + "'");
                lbl_rows.Text = "Rows : " + lstview.Items.Count.ToString();
            
        }
        public void lstset(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     ID   ", 50);
            lstveiw.Columns.Add("     Sale ID   ", 70);

            lstveiw.Columns.Add("     Categorie   ", 110);

            lstveiw.Columns.Add("    Flavor   ", 110);
            lstveiw.Columns.Add("     Size    ", 100);
            lstveiw.Columns.Add("     Price    ", 75);
            lstveiw.Columns.Add("     Qty    ", 175);
            lstveiw.Columns.Add("     Total    ", 175);
            lstveiw.Columns.Add("     Status    ", 175);

            //ComID,PrdctID,txtSize
            /// End Here 
            /// PrvnceID,CntryID,txtCity
        }
        public void Get_lstview(ListView lstveiw, string sel)
        {
            if (lstveiw.Items.Count > 0)
            {
                lstveiw.Items.Clear();
            }
            if (lstveiw.SelectedItems.Count > 0)
            {
                lstveiw.Items.Clear();
            }

            dt = dd.dT_get(sel);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem listitem = new ListViewItem(dr["tblID"].ToString());

                    listitem.SubItems.Add(dr["SalesID"].ToString());
                    listitem.SubItems.Add(dr["Categorie"].ToString());
                    listitem.SubItems.Add(dr["Items"].ToString());

                    listitem.SubItems.Add(dr["Size"].ToString());
                    listitem.SubItems.Add(dr["Price"].ToString());
                    listitem.SubItems.Add(dr["Qty"].ToString());
                    listitem.SubItems.Add(dr["Total"].ToString());
                    listitem.SubItems.Add(dr["Status_"].ToString());


                    lstveiw.Items.Add(listitem);
                }


            }
        }
        public void lstset_process(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     Sale ID   ", 90);
            lstveiw.Columns.Add("     Status   ", 100);
            lstveiw.Columns.Add("     TakeAway   ", 100);
            lstveiw.Columns.Add("     Dinning   ", 150);
            lstveiw.Columns.Add("     Home Delivery   ", 140);


            //ComID,PrdctID,txtSize
            /// End Here 
            /// PrvnceID,CntryID,txtCity
        }
        public void Get_lstview_process(ListView lstveiw, string sel)
        {
            if (lstveiw.Items.Count > 0)
            {
                lstveiw.Items.Clear();
            }
            if (lstveiw.SelectedItems.Count > 0)
            {
                lstveiw.Items.Clear();
            }

            dt = dd.dT_get(sel);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem listitem = new ListViewItem(dr["SaleID"].ToString());

                    // listitem.SubItems.Add(dr["[SalesID]"].ToString());

                    listitem.SubItems.Add(dr["Status_"].ToString());
                    listitem.SubItems.Add(dr["Takeaway"].ToString());
                    listitem.SubItems.Add(dr["Dinning"].ToString());
                    listitem.SubItems.Add(dr["HomeDelivery"].ToString());


                    lstveiw.Items.Add(listitem);
                }


            }
        }
        public void lst_process_Selected(ListView lstprocess, ListView lstview_selected, Label lbl_rows_selected, Label lbl_Grosstotal, NumericUpDown numberic_dis, Label lbl_disvalue, Label lbl_netvalue, MetroFramework.Controls.MetroRadioButton btn_print, MetroFramework.Controls.MetroRadioButton btn_tender, MetroFramework.Controls.MetroRadioButton btn_cancelld, MetroFramework.Controls.MetroRadioButton btn_edite, MetroFramework.Controls.MetroRadioButton btn_dele, object sender, EventArgs e)
        {

            if (lstprocess.SelectedItems.Count > 0)
            {


                ListViewItem item = lstprocess.SelectedItems[0];
                psid = item.SubItems[0].Text;
                pstatus = item.SubItems[1].Text;
                if (Convert.ToInt32(psid) > 0)
                {
                    if (btn_tender.Enabled == false)
                    {
                        btn_tender.Enabled = true;
                    }
                    if (btn_dele.Enabled == false)
                    {
                        btn_dele.Enabled = true;
                    }
                    if (btn_edite.Enabled == false)
                    {
                        btn_edite.Enabled = true;
                    }

                    if (btn_print.Enabled == false)
                    {
                        btn_print.Enabled = true;
                    }
                    if (btn_tender.Enabled == false)
                    {
                        btn_tender.Enabled = true;
                    }
                    btn_cancelld.Enabled = true;
                    if (lstprocess.Items.Count > 0)
                    {
                        btn_print.Enabled = true;
                    }
                    else
                    {
                        btn_print.Enabled = false;
                    }
                    Get_lstview(lstview_selected, "Select  s.tblID,s.[SalesID],(Select p.Catname from CatName p Where p.NID=s.NID) as[Categorie],(Select i.UItems_ from UItems_ i Where i.ItemID=s.ItemID AND i.NID=s.NID ) as[Items],s.ItemSize as[Size],s.ItemRate as[Price],s.Qty,s.Total,s.Status_ From tbl_sale s Where s.[SalesID]=" + psid + "");

                    lbl_rows_selected.Text = "Rows : " + dd.RunQuery_Scaler("Select isnull(Count([SalesID]),0) From tbl_sale Where [SalesID]=" + psid + "");
                    lbl_Grosstotal.Text = dd.RunQuery_Scaler("Select ISNULL(SUM(GTotal),0) from tbl_NetTotal Where SaleID=" + psid + "");
                    lbl_disvalue.Text = dd.RunQuery_Scaler("Select ISNULL(SUM(DValue),0) from tbl_NetTotal Where SaleID=" + psid + "");
                    lbl_netvalue.Text = dd.RunQuery_Scaler("Select ISNULL(SUM(NetTotal),0) from tbl_NetTotal Where SaleID=" + psid + "");
                    numberic_dis.Value = Convert.ToInt64(dd.RunQuery_Scaler("Select ISNULL(SUM(DPrcnatge),0) from tbl_NetTotal Where SaleID=" + psid + ""));
                    // discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

                }
                else
                {
                    if (btn_tender.Enabled == true)
                    {
                        btn_tender.Enabled = false;
                    }
                    btn_cancelld.Enabled = false;
                }


                // MessageBox.Show("Selected " + item.SubItems[0].Text);
            }

        }

        public void listView1_Selected(ListView listView1, ListView lstview_selected, Label lbl_rows_selected, Label lbl_Grosstotal, NumericUpDown numberic_dis, Label lbl_disvalue, Label lbl_netvalue, NumericUpDown numericUpDown1, MetroFramework.Controls.MetroRadioButton btn_save, MetroFramework.Controls.MetroRadioButton btn_edit, MetroFramework.Controls.MetroRadioButton btn_del, object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {


                ListViewItem item = listView1.SelectedItems[0];
                tblid = item.SubItems[0].Text;
                ssid = item.SubItems[1].Text;
                if (Convert.ToInt32(ssid) > 0)
                {
                    if (btn_del.Enabled == false)
                    {
                        btn_del.Enabled = true;
                    }
                    if (btn_edit.Enabled == false)
                    {
                        btn_edit.Enabled = true;
                    }
                    if (btn_save.Enabled == true)
                    {
                        btn_save.Enabled = false;
                    }
                }
                //lbl_rows_selected.Text = "Rows: " + tblid + " Total: " + dd.RunQuery_Scaler("Select s.Total from tbl_sale as s inner join tbl_NetTotal as n on n.SaleID=s.SalesID Where s.SalesID=" + ssid + " AND s.tblID=" + tblid + "");
                lbl_rows_selected.Text = "Rows: " + tblid + " Total: " + item.SubItems[7].Text;

                numericUpDown1.Value = Convert.ToInt32(item.SubItems[6].Text);
                if (item.SubItems[4].Text == "Super Meal" || item.SubItems[4].Text == "Super Deal" || item.SubItems[4].Text == "Classic Treat" || item.SubItems[4].Text == "Couple Treat" || item.SubItems[4].Text == "Smart Meal" || item.SubItems[4].Text == "Smart Meal 2" || item.SubItems[4].Text == "Value Deal" || item.SubItems[4].Text == "Value Deal 2" || item.SubItems[4].Text == "Family Feast" || item.SubItems[4].Text == "Midnight Offer")
                {
                    deal_size = "d";
                    btn_edit.Enabled = false;
                }
                else
                {
                    btn_edit.Enabled = true;
                    deal_size = "r";
                }

                discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);
                // MessageBox.Show("Selected " + item.SubItems[0].Text);
            }

        }
        public void txt_price_KeyUp(TextBox txt_item, ListView lstview_, ComboBox combox_prdct, Label lbl_rows, MetroFramework.Controls.MetroRadioButton btn_add, MetroFramework.Controls.MetroRadioButton btn_edit, MetroFramework.Controls.MetroRadioButton btn_del, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (itemid == "0")
                {
                    // save(txt_item, lstview_, combox_prdct, lbl_rows, btn_add, btn_edit, btn_del);

                }
                else
                {
                    // edit(txt_item, lstview_, combox_prdct, lbl_rows, btn_add, btn_edit, btn_del);

                }
            }
        }

        public void save(NumericUpDown numberic, Label lbl_total,
            Label lbl_Grosstotal, 
            NumericUpDown numberic_dis, Label lbl_disvalue, Label lbl_netvalue, 
            ListView lstview, ListBox lst_prdct, TextBox txt_prdct, 
            Label lbl_rows_selected, Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (numberic.Value > 0)
            {

                PID = size.Name;
                if (prdctid != "0" && itemid != "0" && PID != "0")
                {
                    itemsize = dd.RunQuery_Scaler("Select Size_ From tbl_Pricelist Where PID=" + size.Name + "");
                    price1 = ((float)Convert.ToDouble(dd.RunQuery_Scaler("Select Isnull(Sum(Price_),0) From tbl_Pricelist Where PID=" + size.Name + "")));


                    string sel = "";
                    if (Convert.ToInt32(psid) > 0)
                    {
                        sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate) Values(" + psid + "," + prdctid + "," + itemid + "," + size.Name + ",'" + itemsize + "'," + price1.ToString() + "," + numberic.Value + "," + total.ToString() + ",Convert(date,Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),103))";

                    }

                    else
                    {
                        sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate) Values(" + saleid + "," + prdctid + "," + itemid + "," + size.Name + ",'" + itemsize + "'," + price1.ToString() + "," + numberic.Value + "," + total.ToString() + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103))";

                    }

                    if (dd.IsRunQuery(sel))
                    {
                    }
                    else
                    {
                        dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                    }
                    discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);
                }
                else
                {
                    dd.Error_("Sorry ! ", "Again Select Product or Items ");
                }
                get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_del, btn_del, "");


            }
        }
        public void edit(NumericUpDown numberic, Label lbl_total,
            Label lbl_Grosstotal, NumericUpDown numberic_dis,
            Label lbl_disvalue, Label lbl_netvalue,
            ListView lstview, ListBox lst_prdct,
            TextBox txt_prdct, Label lbl_rows_selected,
            Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (numberic.Value > 0)
            {
                if (prdctid != "0" && itemid != "0" && size.Name != "0")
                {

                    itemsize = dd.RunQuery_Scaler("Select Size_ From tbl_Pricelist Where PID=" + size.Name + "");
                    price1 = ((float)Convert.ToDouble(dd.RunQuery_Scaler("Select Isnull(Sum(Price_),0) From tbl_Pricelist Where PID=" + size.Name + "")));
                    string sel = "";
                    if (ssid == psid)
                    {
                        if (Convert.ToInt32(psid) > 0)
                        {
                            sel = "Update tbl_sale Set NID=" + prdctid + ",ItemID=" + itemid + ",PID=" + size.Name + ",ItemSize='" + itemsize + "',ItemRate=" + price1.ToString() + ",Qty=" + numberic.Value + ",Total=" + total.ToString() + " ,AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103) Where SalesID=" + psid + " AND tblID=" + tblid + "";

                        }
                    }
                    if (ssid != psid)
                    {
                        if (Convert.ToInt32(ssid) > 0)
                        {
                            sel = "Update tbl_sale Set NID=" + prdctid + ",ItemID=" + itemid + ",PID=" + size.Name + ",ItemSize='" + itemsize + "',ItemRate=" + price1.ToString() + ",Qty=" + numberic.Value + ",Total=" + total.ToString() + " ,AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103) Where SalesID=" + ssid + " AND tblID=" + tblid + "";

                        }
                    }


                    if (dd.IsRunQuery(sel))
                    {
                        //      get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                    }
                    else
                    {
                        dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                        //     get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                    }
                    discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);
                    get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_del, btn_del, "");

                }
                else
                {
                    dd.Error_("Sorry ! ", "Again Select Product or Items ");
                }

            }
        }
        public void del(NumericUpDown numberic, Label lbl_total, Label lbl_Grosstotal,
            NumericUpDown numberic_dis, Label lbl_disvalue, Label lbl_netvalue,
            ListView lstview, ListBox lst_prdct, 
            TextBox txt_prdct, Label lbl_rows_selected,
            Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (numberic.Value > 0)
            {
                string sel = "";
                if (Convert.ToInt32(psid) > 0)
                {
                    sel = "Delete From tbl_sale Where SalesID=" + psid + " AND tblID=" + tblid + "";
                }

                if (Convert.ToInt32(ssid) > 0)
                {
                    sel = "Delete From tbl_sale Where SalesID=" + ssid + " AND tblID=" + tblid + "";

                }


                if (dd.IsRunQuery(sel))
                {

                }
                else
                {
                    dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                }
                get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_del, btn_del, "");

                discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

                //}
                //else
                //{
                //    dd.Error_("Sorry ! ", "Again Select Product or Items ");
                //}
                //}
                //else
                //{
                //    MessageBox.Show(" Already Save !", "Exisiting ! ( Information )", MessageBoxMetroFramework.Controls.MetroRadioButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
        public void clear(NumericUpDown numberic, Label lbl_total,
            Label lbl_Grosstotal, NumericUpDown numberic_dis,
            Label lbl_disvalue, Label lbl_netvalue, ListView lstview,
            ListBox lst_prdct, TextBox txt_prdct, Label lbl_rows_selected,
            Label lbl_rows_prdct, Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (numberic.Value > 0)
            {
                string sel = "";

                sel = "Delete From tbl_sale Where SalesID=" + ssid + " ";




                if (dd.IsRunQuery(sel))
                {

                }
                else
                {
                    dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                }
                get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_del, btn_del, "");

                discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

                //}
                //else
                //{
                //    dd.Error_("Sorry ! ", "Again Select Product or Items ");
                //}
                //}
                //else
                //{
                //    MessageBox.Show(" Already Save !", "Exisiting ! ( Information )", MessageBoxMetroFramework.Controls.MetroRadioButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        #region for string
        string sel = null;
        public void save(string str, NumericUpDown numberic, Label lbl_total,
            Label lbl_Grosstotal, NumericUpDown numberic_dis,
            Label lbl_disvalue, Label lbl_netvalue, 
            ListView lstview, ListBox lst_prdct,
            TextBox txt_prdct, Label lbl_rows_selected,
            Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del,
            Telerik.WinControls.UI.RadButton btn_ko,
            Telerik.WinControls.UI.RadButton btn_prnt)
        {



            itemsize = dd.RunQuery_Scaler("Select Size_ From tbl_Pricelist Where PID=" + size.Name + "");
            price1 = ((float)Convert.ToDouble(dd.RunQuery_Scaler("Select Isnull(Sum(Price_),0) From tbl_Pricelist Where PID=" + size.Name + "")));
            string sel = "";

            if (Convert.ToInt32(psid) > 0)
            {
                sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate,Status_) Values(" + psid + "," + prdctid + "," + itemid + "," + size.Name + ",'" + itemsize + "'," + price1.ToString() + "," + numberic.Value + "," + total.ToString() + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid')";


            }
            else
            {
                sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate,Status_) Values(" + saleid + "," + prdctid + "," + itemid + "," + size.Name + ",'" + itemsize + "'," + price1.ToString() + "," + numberic.Value + "," + total.ToString() + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid')";


            }
            if (str == "new")
            {
                sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate,Status_) Values(" + saleid + "," + prdctid + "," + itemid + "," + size.Name + ",'" + itemsize + "'," + price1.ToString() + "," + numberic.Value + "," + total.ToString() + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid')";

            }





            if (dd.IsRunQuery(sel))
            {
                sel = null;


            }
            else
            {
                dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
            }

            get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_edit, btn_del, "");
            discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

            //if (lstview.Items.Count > 0&& lst_prdct.Items.Count>0)
            //{
            //    btn_ko.Enabled = true;
            //}
            //else
            //{
            //    btn_ko.Enabled = false;
            //}
            if (lstview.Items.Count > 0)
            {
                btn_ko.Enabled = true;
            }
            else
            {
                btn_ko.Enabled = false;
            }


        }
        public void save_(string str, string deal_name, string price,
            NumericUpDown numberic, Label lbl_total, Label lbl_Grosstotal,
            NumericUpDown numberic_dis, Label lbl_disvalue,
            Label lbl_netvalue, ListView lstview, 
            ListBox lst_prdct, TextBox txt_prdct,
            Label lbl_rows_selected, 
            Label lbl_rows_prdct,
           Telerik.WinControls.UI.RadButton btn_save,
           Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {

            string sel = "";

            if (Convert.ToInt32(psid) > 0)
            {
                sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate,Status_) Values(" + psid + ",0,0,0,'" + deal_name + "'," + price + ",1," + price + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid')";


            }

            else
            {
                sel = "insert into tbl_sale(SalesID,NID,ItemID,PID,ItemSize,ItemRate,Qty,Total,AddDate,Status_) Values(" + saleid + ",0,0,0,'" + deal_name + "'," + price + ",1," + price + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid')";


            }








            if (dd.IsRunQuery(sel))
            {
                sel = null;



            }
            else
            {
                dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
            }
            get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_edit, btn_del, "");


            discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);


        }

        public void edit_(MetroFramework.Controls.MetroRadioButton radbtn_Takeway,MetroFramework.Controls.MetroRadioButton radbtn_Dinning,
            MetroFramework.Controls.MetroRadioButton radbtn_Homedeilvery, ComboBox combox_table,
            NumericUpDown numberic, Label lbl_total, Label lbl_Grosstotal, NumericUpDown numberic_dis, 
            Label lbl_disvalue, Label lbl_netvalue, ListView lstview, ListBox lst_prdct,
            TextBox txt_prdct, Label lbl_rows_selected,
            Label lbl_rows_prdct, 
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit, 
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (numberic.Value > 0)
            {
                if (radbtn_Takeway.Checked)
                {
                    takeaway = "Yes";
                }
                else
                {
                    takeaway = "No";
                }
                if (radbtn_Dinning.Checked)
                {
                    din = combox_table.Text;
                }
                else
                {
                    din = "No";
                }
                if (radbtn_Homedeilvery.Checked)
                {
                    hd = "Yes";
                }
                else
                {
                    hd = "No";
                }
                if (prdctid != "0" && itemid != "0" && size.Name != "0")
                {
                    itemsize = dd.RunQuery_Scaler("Select Size_ From tbl_Pricelist Where PID=" + size.Name + "");
                    price1 = ((float)Convert.ToDouble(dd.RunQuery_Scaler("Select Isnull(Sum(Price_),0) From tbl_Pricelist Where PID=" + size.Name + "")));

                    string nel = "";

                    if (Convert.ToInt32(psid) > 0)
                    {
                        if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + psid + ""))
                        {
                            sel = "Update tbl_sale Set NID=" + prdctid + ",ItemID=" + itemid + ",PID=" + size.Name + ",ItemSize='" + itemsize + "',ItemRate=" + price1.ToString() + ",Qty=" + numberic.Value + ",Total=" + total.ToString() + " Where tblID=" + tblid + " AND SalesID=" + psid + "";

                            nel = " update tbl_NetTotal Set GTotal=" + total.ToString() + " ,DPrcnatge=" + numberic_dis.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_netvalue.Text + " ,Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery'" + hd + "' Where SaleID=" + psid + "";
                            dd.IsRunQuery(nel);
                        }
                    }

                    if (psid == null)
                    {
                        sel = "Update tbl_sale Set NID=" + prdctid + ",ItemID=" + itemid + ",PID=" + size.Name + ",ItemSize='" + itemsize + "',ItemRate=" + price1.ToString() + ",Qty=" + numberic.Value + ",Total=" + total.ToString() + " Where tblID=" + tblid + " AND SalesID=" + saleid + "";
                        if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + saleid + ""))
                        {
                            nel = " update tbl_NetTotal Set GTotal=" + total.ToString() + " ,DPrcnatge=" + numberic_dis.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_netvalue.Text + " ,Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery'" + hd + "' Where SaleID=" + saleid + "";
                            dd.IsRunQuery(nel);
                        }
                    }



                    if (dd.IsRunQuery(sel))
                    {
                        //if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + saleid + ""))
                        //{
                        //    dd.en_save(nel);
                        //}
                    }
                    else
                    {
                        dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                    }
                    get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_edit, btn_del, "");

                    discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

                }
                else
                {
                    dd.Error_("Sorry ! ", "Again Select Product or Items ");
                }

            }
        }
        public void del_(NumericUpDown numberic, Label lbl_total, Label lbl_Grosstotal, 
            NumericUpDown numberic_dis, Label lbl_disvalue, Label lbl_netvalue,
            ListView lstview, ListBox lst_prdct, TextBox txt_prdct, 
            Label lbl_rows_selected, Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {


            if (ssid != "0" && tblid != "0")
            {

                if (Convert.ToInt32(psid) > 0)
                {
                    sel = "Delete From tbl_sale Where SalesID=" + psid + " AND tblID=" + tblid + "";

                }


                else
                {
                    sel = "Delete From tbl_sale Where SalesID=" + ssid + " AND tblID=" + tblid + "";

                }

                if (dd.IsRunQuery(sel))
                {
                }
                else
                {
                    dd.Error_("Item Size and Price   ( Information )", "Item Size and Price has not been saved");
                }
                get_deal(numberic, numberic_dis, lbl_Grosstotal, lbl_disvalue, lbl_netvalue, lstview, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_del, btn_del, "");

                discount(lbl_Grosstotal, numberic_dis, lbl_disvalue, lbl_netvalue);

            }
            else
            {
                dd.Error_("Sorry ! ", "Again Select Product or Items ");
            }


        }

        #endregion
        public void discount(Label lbl_Grosstotal, NumericUpDown numberic, Label lbl_disvalue, Label lbl_netvalue)
        {
            try
            {
                string sel = "";

                if (Convert.ToInt32(psid) > 0)
                {
                    sel = "Select ISNULL(SUM(Total),0) From tbl_sale Where [SalesID]=" + psid + "";

                }


                else
                {
                    sel = "Select ISNULL(SUM(Total),0) From tbl_sale Where [SalesID]=" + saleid + "";

                }
                if (Convert.ToInt32(ssid) > 0)
                {
                    sel = "Select ISNULL(SUM(Total),0) From tbl_sale Where [SalesID]=" + saleid + " AND tblID=" + tblid + "";

                }
                if (sel != "")
                {
                    lbl_Grosstotal.Text = dd.RunQuery_Scaler(sel);
                    lbl_disvalue.Text = ((float)Convert.ToDouble(numberic.Value) * (float)Convert.ToDouble(lbl_Grosstotal.Text) / 100).ToString();
                    lbl_netvalue.Text = ((float)Convert.ToDouble(lbl_Grosstotal.Text) - (float)Convert.ToDouble(lbl_disvalue.Text)).ToString();
                }
            }
            catch (Exception)
            {
                lbl_Grosstotal.Text = "x";
                lbl_disvalue.Text = "x";
                lbl_netvalue.Text = "x";
            }
        }
        public void get_all(NumericUpDown numberic_qty, ListView lstview, ListBox lst_prdct, TextBox txt_prdct, Label lbl_rows, MetroFramework.Controls.MetroRadioButton btn_save, MetroFramework.Controls.MetroRadioButton btn_edit, MetroFramework.Controls.MetroRadioButton btn_del)
        {

            numberic_qty.Value = 0;
            Get_lstview(lstview, "Select  s.tblID,s.SalesID,p.Catname as [Categorie],i.UItems_ as[Items],r.Size_ as[Size],r.Price_ as[Price],s.Qty,s.Total From tbl_sale s,tbl_Pricelist r,CatName p , UItems_ i Where p.NID=s.NID AND i.ItemID=s.ItemID AND r.PID=s.PID AND s.[SalesID]=" + saleid + "");
            lbl_rows.Text = "Rows : " + dd.RunQuery_Scaler("Select Count([SalesID]) From  tbl_sale Where [SalesID]=" + saleid + "");
            itemid = "0";
            if (btn_del.Enabled == true)
            {
                btn_del.Enabled = false;
            }
            if (btn_edit.Enabled == true)
            {
                btn_edit.Enabled = false;
            }
            if (btn_save.Enabled == false)
            {
                btn_save.Enabled = true;
            }
            get_prdct(lst_prdct, txt_prdct, lbl_rows);

        }
        public void nettotal(Label lbl_GTotal, 
            NumericUpDown numberic_qty, 
            NumericUpDown Discount, 
            Label lbl_disvalue, 
            Label lbl_Nettotal,
            MetroFramework.Controls.MetroRadioButton radbtn_Takeway,
            MetroFramework.Controls.MetroRadioButton radbtn_Dinning,
            MetroFramework.Controls.MetroRadioButton radbtn_Homedeilvery,
            ComboBox combox_table, 
            ListView lst_process,
            ListView lst_selected,
            ListBox lst_prdct, 
            TextBox txt_prdct, 
            Label lbl_rows, Label lbl_rows_selected, Label lbl_rows_prdct, Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit, Telerik.WinControls.UI.RadButton btn_del)
        {
            if (radbtn_Takeway.Checked)
            {
                takeaway = "Yes";
            }
            else
            {
                takeaway = "No";
            }
            if (radbtn_Dinning.Checked)
            {
                din = combox_table.Text;
            }
            else
            {
                din = "No";
            }
            if (radbtn_Homedeilvery.Checked)
            {
                hd = "Yes";
            }
            else
            {
                hd = "No";
            }
            if (Convert.ToInt32(psid) > 0)
            {





                if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + psid + ""))
                {
                    sel = "Update tbl_NetTotal Set GTotal=" + lbl_GTotal.Text + ",DPrcnatge=" + Discount.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_Nettotal.Text + ",AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),Status_='Unpaid',Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery='" + hd + "' Where SaleID=" + psid + "";
                }
                if (!dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + psid + ""))
                {
                    sel = " insert into tbl_NetTotal(SaleID,GTotal,DPrcnatge,DValue,NetTotal,AddDate,Status_,Takeaway,Dinning,HomeDelivery) Values(" + saleid + "," + lbl_GTotal.Text + "," + Discount.Value + "," + lbl_disvalue.Text + "," + lbl_Nettotal.Text + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid','" + takeaway + "','" + din + "','" + hd + "')";
                }
            }
            if (psid == null || psid == "")
            {





                if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + saleid + ""))
                {
                    sel = "Update tbl_NetTotal Set GTotal=" + lbl_GTotal.Text + ",DPrcnatge=" + Discount.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_Nettotal.Text + ",AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),Status_='Unpaid',Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery='" + hd + "' Where SaleID=" + saleid + "";
                }
                if (!dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + saleid + ""))
                {
                    sel = " insert into tbl_NetTotal(SaleID,GTotal,DPrcnatge,DValue,NetTotal,AddDate,Status_,Takeaway,Dinning,HomeDelivery) Values(" + saleid + "," + lbl_GTotal.Text + "," + Discount.Value + "," + lbl_disvalue.Text + "," + lbl_Nettotal.Text + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid','" + takeaway + "','" + din + "','" + hd + "')";
                }
            }

            //if (Convert.ToInt32(psid) > 0)
            //{
            //    //sel = " insert into tbl_NetTotal(SaleID,GTotal,DPrcnatge,DValue,NetTotal,AddDate,Status_,Takeaway,Dinning,HomeDelivery) Values(" + psid + "," + lbl_GTotal.Text + "," + Discount.Value + "," + lbl_disvalue.Text + "," + lbl_Nettotal.Text + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid','" + takeaway + "','" + din + "','" + hd + "')";

            //    if (dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + psid + ""))
            //    {
            //        sel = "Update tbl_NetTotal Set GTotal=" + lbl_GTotal.Text + ",DPrcnatge=" + Discount.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_Nettotal.Text + ",AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),Status_='Unpaid',Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery='" + hd + "' Where SaleID=" + psid + "";
            //    }
            //    if (!dd.IsAvailable("Select * from tbl_NetTotal Where SaleID=" + psid + ""))
            //    {
            //        sel = " insert into tbl_NetTotal(SaleID,GTotal,DPrcnatge,DValue,NetTotal,AddDate,Status_,Takeaway,Dinning,HomeDelivery) Values(" + saleid + "," + lbl_GTotal.Text + "," + Discount.Value + "," + lbl_disvalue.Text + "," + lbl_Nettotal.Text + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid','" + takeaway + "','" + din + "','" + hd + "')";
            //    }
            //}
            //else
            //{


            //}
            if (sel != "")
            {
                if (dd.IsRunQuery(sel))
                {
                    show_process(lst_process, lbl_rows);
                    //ID();
                    get_deal(numberic_qty, Discount, lbl_GTotal, lbl_disvalue, lbl_Nettotal, lst_selected, lst_prdct, txt_prdct, lbl_rows_selected, lbl_rows_prdct, btn_save, btn_edit, btn_del, "");
                }
                else
                {
                    dd.Error_("Selected Prodcut   ( Information )", "Selected Product has not been saved");
                    //              get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                }
            }

        }
        public void get_deal(NumericUpDown numberic_qty, NumericUpDown numberic_dis,
            Label lbl_GTotal, Label lbl_DValue, Label lbl_NetValue, 
            ListView lstview, ListBox lst_prdct, TextBox txt_prdct,
            Label lbl_rows_selected, Label lbl_rows_prdct,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del, string str)
        {
            if (str == "new")
            {
                sel = "Select  s.tblID,s.[SalesID],(Select p.Catname from CatName p Where p.NID=s.NID) as[Categorie],(Select i.UItems_ from UItems_ i Where i.ItemID=s.ItemID AND i.NID=s.NID ) as[Items],s.ItemSize as[Size],s.ItemRate as[Price],s.Qty,s.Total,s.Status_ From tbl_sale s Where s.[SalesID]=" + saleid + "";

                lbl_rows_selected.Text = "Rows : " + dd.RunQuery_Scaler("Select isnull(Count(SalesID),0) From tbl_sale Where SalesID=" + saleid + "");
            }
            else
            {
                if (Convert.ToInt32(psid) > 0)
                {
                    //sel = " insert into tbl_NetTotal(SaleID,GTotal,DPrcnatge,DValue,NetTotal,AddDate,Status_,Takeaway,Dinning,HomeDelivery) Values(" + psid + "," + lbl_GTotal.Text + "," + Discount.Value + "," + lbl_disvalue.Text + "," + lbl_Nettotal.Text + ",Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),'Unpaid','" + takeaway + "','" + din + "','" + hd + "')";


                    sel = "Select  s.tblID,s.[SalesID],(Select p.Catname from CatName p Where p.NID=s.NID) as[Categorie],(Select i.UItems_ from UItems_ i Where i.ItemID=s.ItemID AND i.NID=s.NID ) as[Items],s.ItemSize as[Size],s.ItemRate as[Price],s.Qty,s.Total,s.Status_ From tbl_sale s Where s.[SalesID]=" + psid + "";
                    lbl_rows_selected.Text = "Rows : " + dd.RunQuery_Scaler("Select isnull(Count(SalesID),0) From tbl_sale Where SalesID=" + psid + "");
                }
                else
                {

                    sel = "Select  s.tblID,s.[SalesID],(Select p.Catname from CatName p Where p.NID=s.NID) as[Categorie],(Select i.UItems_ from UItems_ i Where i.ItemID=s.ItemID AND i.NID=s.NID ) as[Items],s.ItemSize as[Size],s.ItemRate as[Price],s.Qty,s.Total,s.Status_ From tbl_sale s Where s.[SalesID]=" + saleid + "";

                    lbl_rows_selected.Text = "Rows : " + dd.RunQuery_Scaler("Select isnull(Count([SalesID]),0) From tbl_sale Where [SalesID]=" + saleid + "");
                }

            }
            Get_lstview(lstview, sel);

            itemid = "0";
            if (btn_del.Enabled == true)
            {
                btn_del.Enabled = false;
            }
            if (btn_edit.Enabled == true)
            {
                btn_edit.Enabled = false;
            }
            if (btn_save.Enabled == false)
            {
                btn_save.Enabled = true;
            }
            get_prdct(lst_prdct, txt_prdct, lbl_rows_prdct);
            numberic_dis.Value = 0;
            lbl_DValue.Text = "0";
            lbl_GTotal.Text = "0";
            lbl_NetValue.Text = "0";
            numberic_qty.Value = 0;
        }
        public void get_KO(NumericUpDown numberic_qty, NumericUpDown numberic_dis, Label lbl_GTotal, 
            Label lbl_DValue, Label lbl_NetValue, ListView lstview, ListBox lst_prdct, 
            TextBox txt_prdct, Label lbl_rows, Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit, Telerik.WinControls.UI.RadButton btn_del)
        {

            Get_lstview(lstview, "Select  s.SalesID,s.Status_ From tbl_sale s Where s.SalesID=" + saleid + "");
            numberic_dis.Value = 0;
            lbl_DValue.Text = "0";
            lbl_GTotal.Text = "0";
            lbl_NetValue.Text = "0";
            numberic_qty.Value = 0;
            lbl_rows.Text = "Rows : " + dd.RunQuery_Scaler("Select isnull(Count(SalesID),0) From tbl_sale Where SalesID=1051");
            itemid = "0";
            if (btn_del.Enabled == true)
            {
                btn_del.Enabled = false;
            }
            if (btn_edit.Enabled == true)
            {
                btn_edit.Enabled = false;
            }
            if (btn_save.Enabled == false)
            {
                btn_save.Enabled = true;
            }
            get_prdct(lst_prdct, txt_prdct, lbl_rows);

        }


        string underLine=string.Empty;

        public void prnt_kitchen_PrintPage(Label lbl_order_status, object sender, PrintPageEventArgs e)
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

        private void na(Graphics graphics, int startY, int Offset, DataRow dr)
        {
            if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Fast Food")
            {
                graphics.DrawString("F:Food - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + "\t" + dr["Qty"].ToString(), new Font("Arial", 8),
                         new SolidBrush(Color.Black), 10, startY + Offset);
            }
            if (dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") == "Sweets")
            {
                graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - ( " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " )\t " + dr["Qty"].ToString() + " ", new Font("Arial", 8),
                                                        new SolidBrush(Color.Black), 10, startY + Offset);
            }
            else
            {
                graphics.DrawString(dd.RunQuery_Scaler("Select Catname From CatName Where NID=" + dr["NID"].ToString() + "") + " - " + dd.RunQuery_Scaler("Select UItems_ From UItems_ Where ItemID=" + dr["ItemID"].ToString() + "") + " - " + dr["ItemSize"].ToString() + "\t" + dr["Qty"].ToString(), new Font("Arial", 8),
                          new SolidBrush(Color.Black), 10, startY + Offset);
            }
        }
        public void prnt_sale_PrintPage(Label lbl_order_status, object sender, PrintPageEventArgs e)
        {


            #region Sale Print in customer printer btn


            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 20;
            int Offset = 40;


            if (psid != "")
            {
                dt = dd.dT_get("Select * From tbl_sale Where SalesID=" + psid + "");
            }


            graphics.DrawString("For Customer ", new Font("Arial", 8, FontStyle.Regular),
                            new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Shop name", new Font("Colonna MT", 14, FontStyle.Bold),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Location: ", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 10 + Offset);
            /*
            graphics.DrawString("For Customer ", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Shop name ", new Font("Colonna MT", 14, FontStyle.Bold),
                                new SolidBrush(Color.Black), 10, 0 + Offset);
            Offset = Offset + 20;

            graphics.DrawString("Shop Address", new Font("Arial", 8, FontStyle.Regular),
                                new SolidBrush(Color.Black), 10, 10 + Offset);
            */
            Offset = Offset + 20;
            graphics.DrawString("Ticket ID :" + psid,
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
                    if (dr["NID"].ToString() != "0" && dr["ItemID"].ToString() != "0")
                    {


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

                }
                else
                {
                    graphics.DrawString("Deal - " + dr["ItemSize"].ToString(), new Font("Arial", 8),
                             new SolidBrush(Color.Black), 10, startY + Offset);

                }


                graphics.DrawString(dr["Qty"].ToString(), new Font("Arial", 8),
                         new SolidBrush(Color.Black), 140, startY + Offset);

                graphics.DrawString(dr["Total"].ToString(), new Font("Arial", 8),
                         new SolidBrush(Color.Black), 190, startY + Offset);
                Offset = Offset + 20;


            }



            graphics.DrawString(underLine, new Font("Arial", 9),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
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

            Offset = Offset + 20;
            graphics.DrawString(descrip, new Font("Arial", 8),
                     new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            lbl_order_status.Text = saleid + " This Order has been Paid and done  ";
            #endregion
        }
        public void na(Graphics graphics, int startY, int Offset)
        {

        }
        public void show_process(ListView lst_process, Label lbl_rows)
        {
            Get_lstview_process(lst_process, "  Select * From tbl_NetTotal Where Status_='Unpaid'");
            lbl_rows.Text = "Rows: " + dd.RunQuery_Scaler("Select Isnull(Count(SaleID),0) From tbl_NetTotal Where Status_='Unpaid'");

        }
        public void tl(MetroFramework.Controls.MetroRadioButton radiobtn_Takeaway,
            MetroFramework.Controls.MetroRadioButton radiobtn_dinning,MetroFramework.Controls.MetroRadioButton radiobtn_hd, ComboBox combox_table)
        {
            if (radiobtn_dinning.Checked)
            {
                if (combox_table.Items.Count > 0)
                {
                    combox_table.SelectedIndex = 0;
                }
                combox_table.Enabled = true;
                OCate = "Dinning >>> " + combox_table.Text;

            }
            if (radiobtn_hd.Checked)
            {

                combox_table.Enabled = false;
                OCate = "Home Delivery";
            }
            if (radiobtn_Takeaway.Checked)
            {
                combox_table.Enabled = false;
                OCate = "Take Away";
            }
        }
        public void order_del(Label lbl_GTotal, NumericUpDown numberic_qty, NumericUpDown Discount, Label lbl_disvalue, 
            Label lbl_Nettotal, Telerik.WinControls.UI.RadButton radbtn_Takeway,
            Telerik.WinControls.UI.RadButton radbtn_Dinning,
            Telerik.WinControls.UI.RadButton radbtn_Homedeilvery,
            ComboBox combox_table, ListView lst_process, 
            ListView lst_selected, ListBox lst_prdct, 
            TextBox txt_prdct, Label lbl_rows, 
            Label lbl_rows_selected, Label lbl_rows_prdct,
            Label lbl_order_status, Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (psid != "" || psid != "0")
            {
                if (dd.IsRunQuery("Delete  From tbl_NetTotal Where SaleID=" + psid + ""))
                {
                    if (dd.IsRunQuery("Delete  From tbl_sale Where SalesID=" + psid + ""))
                    {
                        if (lst_selected.Items.Count > 0)
                        {
                            lst_selected.Items.Clear();
                            lbl_disvalue.Text = "0";
                            lbl_GTotal.Text = "0";
                            lbl_Nettotal.Text = "0";
                            numberic_qty.Value = 0;
                            lbl_rows_selected.Text = "0";
                        }
                        show_process(lst_process, lbl_rows);
                        lbl_order_status.Text = psid + " this order has been cancelled ";
                    }
                }
                else
                {
                    lbl_order_status.Text = psid + " cancellation problem ";
                    dd.Error_("Order Cancel  ( Information )", "Selected Order has not been cancelled");
                    //              get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void order_paid(Label lbl_GTotal, NumericUpDown numberic_qty, NumericUpDown Discount, Label lbl_disvalue, Label lbl_Nettotal,
            Telerik.WinControls.UI.RadButton radbtn_Takeway,
            Telerik.WinControls.UI.RadButton radbtn_Dinning,
            Telerik.WinControls.UI.RadButton radbtn_Homedeilvery, 
            ComboBox combox_table, ListView lst_process, 
            ListView lst_selected, ListBox lst_prdct,
            TextBox txt_prdct, Label lbl_rows, Label lbl_rows_selected, 
            Label lbl_rows_prdct, Label lbl_order_status,
            Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
            Telerik.WinControls.UI.RadButton btn_del)
        {
            if (psid != "" || psid != "0")
            {
                if (dd.IsRunQuery("Update tbl_NetTotal Set GTotal=" + lbl_GTotal.Text + ",DPrcnatge=" + Discount.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_Nettotal.Text + ",AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),Status_='Paid',Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery='" + hd + "' Where SaleID=" + psid + ""))
                {
                    if (dd.IsRunQuery("Update tbl_sale Set Status_='Paid' Where SalesID=" + psid + ""))
                    {
                        if (lst_selected.Items.Count > 0)
                        {
                            lst_selected.Items.Clear();
                            lbl_disvalue.Text = "0";
                            lbl_GTotal.Text = "0";
                            lbl_Nettotal.Text = "0";
                            numberic_qty.Value = 0;
                            lbl_rows_selected.Text = "0";
                        }
                        show_process(lst_process, lbl_rows);
                        lbl_order_status.Text = psid + " this order has been completed ";
                    }
                }
                else
                {
                    lbl_order_status.Text = psid + " cancellation problem ";
                    dd.Error_("Order Cancel  ( Information )", "Selected Order has not been cancelled");
                    //              get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void order_edit(Label lbl_GTotal, NumericUpDown numberic_qty,
            NumericUpDown Discount, Label lbl_disvalue, Label lbl_Nettotal,
            Telerik.WinControls.UI.RadButton radbtn_Takeway,
            Telerik.WinControls.UI.RadButton radbtn_Dinning,
            Telerik.WinControls.UI.RadButton radbtn_Homedeilvery,
            ComboBox combox_table, ListView lst_process,
            ListView lst_selected, ListBox lst_prdct, 
            TextBox txt_prdct, Label lbl_rows,
            Label lbl_rows_selected, Label lbl_rows_prdct, 
            Label lbl_order_status, Telerik.WinControls.UI.RadButton btn_save,
            Telerik.WinControls.UI.RadButton btn_edit,
           Telerik.WinControls.UI.RadButton btn_del)
        {
            if (psid != "" || psid != "0")
            {
                if (dd.IsRunQuery("Update tbl_sale Set NID=" + prdctid + ",ItemID=" + itemid + ",PID=" + size.Name + ",ItemSize='" + itemsize + "',ItemRate=" + price1.ToString() + ",Qty=" + numberic_qty.Value + ",Total=" + total.ToString() + " ,AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103) Where SalesID=" + psid + " "))
                {
                    if (dd.IsRunQuery("Update tbl_NetTotal Set GTotal=" + lbl_GTotal.Text + ",DPrcnatge=" + Discount.Value + ",DValue=" + lbl_disvalue.Text + ",NetTotal=" + lbl_Nettotal.Text + ",AddDate=Convert(date,'" + DateTime.Now.ToString("dd-MMM-yyyy") + "',103),Status_='Unpaid',Takeaway='" + takeaway + "',Dinning='" + din + "',HomeDelivery='" + hd + "' Where SaleID=" + psid + ""))
                    {
                        show_process(lst_process, lbl_rows);
                        lbl_order_status.Text = psid + " this order has been completed ";
                    }
                }
                else
                {
                    lbl_order_status.Text = psid + " cancellation problem ";
                    dd.Error_("Order Cancel  ( Information )", "Selected Order has not been cancelled");
                    //              get_all(numberic, lstview, lst_prdct, txt_prdct, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }


        //public void KO_print(PrintDocument prnt)
        //{
        //    try
        //    {
        //        itemperpage = totalnumber = 0;
        //        printPreviewDialog1.Document = prntdoc;
        //        prnt.DefaultPageSettings.PaperSize = paperSize;
        //        printPreviewDialog1.ShowDialog();
        //    }
        //    catch (Exception e)
        //    {
        //        qq.Error(e.Message, "Print Error");
        //    }
        //}
    }
}
