using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace PointOfSale.Page.Classess_
{
    class price
    {
        DataTable dt = null;
        string prdctid = null;
        method dd = new method();
        // Classssss.mmthod dd = new Classssss.mmthod();


        public void save(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, Label lbl, ListView lst, Button btn_save, Button btn_edit, Button btn_del)
        {
            try
            {
                if (txtsize.Text.Any() && txtprice.Text.Any() && catid != "0" && itemid != "0")
                {
                    if (!dd.IsAvailable("select * from tbl_Pricelist where NID=" + catid + " and ItemID=" + itemid + " and Size_='" + txtsize.Text + "' and Price_=" + dd.float_(txtprice).ToString() + ""))
                    {

                        if (dd.IsRunQuery("insert into tbl_Pricelist (NID,ItemID,Size_,Price_) values (" + catid + "," + itemid + ",'" + txtsize.Text.Trim() + "'," + dd.float_(txtprice).ToString() + ")"))
                        {
                            dd.lblForeColorChange(lbl, "Save ", "t");

                            txtsize.Text = string.Empty;
                            get_all(txtsize,txtprice, lst, lbl, btn_save, btn_edit, btn_del);
                            //// dd.viewall("select * from catname", dgv);
                            // dd.lbl_(lbl, "Rows: "+dd.RunQuery_Scaler("select count(NID) from catname"), "t");
                            // Get_lstview(lst, "select * from catname");
                        }

                    }
                    else
                    {
                        dd.lblForeColorChange(lbl, "Exisitng Record", "f");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void edit(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (txtsize.Text.Any() && txtprice.Text.Any() && catid!="0" && itemid!="0")
            {
                string sel = "Update tbl_Pricelist Set NID=" + catid + ",ItemID=" + itemid + ",Size_='" + txtsize.Text.Trim() + "',Price_=" + dd.float_(txtprice).ToString() + " where PID=" + prdctid + "";
              //  MessageBox.Show(sel);
                if (dd.IsRunQuery(sel))
                {
                   
                    get_all(txtsize,txtprice, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
                else
                {
                    dd.Error_(" Product price and size   ( Information )", "Product price and size  has not been updated");
                    get_all(txtsize, txtprice, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void del(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (txtsize.Text.Any() && txtprice.Text.Any() && catid != "0" && itemid != "0")
            {
                if (dd.IsRunQuery("Delete From UItems_  Where ItemID=" + itemid + ""))
                {
                    txtsize.Focus();
                    txtprice.Focus();
                    get_all(txtsize, txtprice, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
                else
                {
                    dd.Error_(" Product price and size  ( Information )", "Product price and size has not been deleted");

                    get_all(txtsize, txtprice, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void get_all(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
           // txt_user.Text = string.Empty;
            // Get_lstview(lstview, "Select i.ItemID,cat.catname,i.UItems_,cat.NID From CatName as cat , UItems_  as i");

            txtprice.Text = string.Empty;
            txtsize.Text = string.Empty;
            Get_lstview(lstview, "SELECT tbl_Pricelist.PID,CatName.catname,UItems_.UItems_,tbl_Pricelist.Size_,tbl_Pricelist.Price_ FROM (CatName INNER JOIN UItems_ ON CatName.NID = UItems_.NID) INNER JOIN tbl_Pricelist ON (UItems_.ItemID = tbl_Pricelist.ItemID) AND (CatName.NID = tbl_Pricelist.NID);");
            lbl_rows.Text = "Rows : " + dd.RunQuery_Scaler("Select Count(PID) From  tbl_Pricelist") + "Total : " + dd.RunQuery_Scaler("Select isnull(Sum(Price_),0) From  tbl_Pricelist");
            prdctid = null;
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
        }

        public void srch(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, ListView lstview, Label lbl_rows)
        {
            //if (dd.IsAvailable("Select * From CatName Where Catname like '" + txt_user.Text + "%'"))
            //{
            //    Get_lstview(lstview, "Select * From CatName Where Catname like '" + txt_user.Text + "%'");
            //    lbl_rows.Text = "Rows : " + dd.RunQuery_Scaler("Select Count(NID) From CatName Where Catname like '" + txt_user.Text + "%'");
            //}
        }
        public void lstset(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     ID    ", 100, HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Product    ", 100, HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Item    ", 100, HorizontalAlignment.Center);
           
            lstveiw.Columns.Add("     Size    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Price    ", 100, HorizontalAlignment.Center);




            //ComID,PrdctID,txtSize
            /// End Here 
            /// PrvnceID,CntryID,txtCity
        }
        public void get_id(ComboBox combox)
        {
            prdctid = dd.RunQuery_Scaler("select NID from catname where catname='" + combox.Text + "'");

            if (prdctid == "" || prdctid == string.Empty || prdctid == "0")
            {
                prdctid = "0";
            }
            // MessageBox.Show("Category ID: "+prdctid);

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

                    ListViewItem listitem = new ListViewItem(dr["PID"].ToString());



                    
                        
                        listitem.SubItems.Add(dr["catname"].ToString(), Color.Red, Color.Yellow, new Font("Arial", 10));


                        listitem.SubItems.Add(dr["UItems_"].ToString(), Color.Red, Color.Yellow, new Font("Arial", 10));

                        listitem.SubItems.Add(dr["Size_"].ToString());
                        listitem.SubItems.Add("$$: "+dr["Price_"].ToString());

                    lstveiw.Items.Add(listitem);
                }


            }
        }
       
        public void dgv_Selected(ListView listView1, MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, Button btn_save, Button btn_edit, Button btn_del, object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {


                ListViewItem item = listView1.SelectedItems[0];
                prdctid = item.SubItems[0].Text;


                txtsize.Text = item.SubItems[3].Text;
                //item.SubItems[4].Text.Remove(4);
                txtprice.Text = item.SubItems[4].Text.Remove(0, 3);

                // MessageBox.Show("Selected " + item.SubItems[0].Text);
            }
            if (Convert.ToInt32(prdctid) > 0)
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
        }
        public void txt_prdct_KeyUp(MetroFramework.Controls.MetroTextBox txtsize, MetroFramework.Controls.MetroTextBox txtprice, ListView lstview_, Label lbl_rows, Button btn_add, Button btn_edit, Button btn_del, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (prdctid == null)
                {
                    //save(txt_size,txtprice, lbl_rows, lstview_, btn_add, btn_edit, btn_del);

                }
                else
                {
                   // edit(txt_size, txtprice, lbl_rows, lstview_, btn_add, btn_edit, btn_del);

                }
            }
        }

        #region GetRecord in combox
        string catid, itemid = "";
        public void get_categoy(ComboBox combox)
        {
            dd.get_Combox_only("select catname from CatName", combox);
        }
        public void get_item(ComboBox combox_cate, ComboBox combox_item)
        {
            catid = dd.RunQuery_Scaler("select NID from CatName where catname='"+combox_cate.Text+"'");
            if (catid != null || catid != string.Empty||catid!="0")
            {

                dd.get_Combox_only("select UItems_ from UItems_ where NID=" + catid + "", combox_item);
            }
            else
            {
                catid = "0";
            }
        }
        public void get_itemid(ComboBox combox_item)
        {
            itemid = dd.RunQuery_Scaler("select ItemID from UItems_ where NID=" + catid + " and UItems_ ='" + combox_item.Text + "'");
            if (itemid != null || itemid != string.Empty||itemid!="0")
            {
            }
            else
            {
                itemid = "0";
            }
        }
        #endregion
    }
}
