using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PointOfSale.Page._setting
{
    class cls_item_account
    {
        DataTable dt = null;
        OpenFileDialog ofdFindPhoto = new OpenFileDialog();
        method dd = new method();
        string itemid = "";
        float qty, price, weight = 0;
        public void save_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtitem,  TextBox txt_qty, ComboBox txt_weight, TextBox txt_usage, TextBox txtprice,  Button btn_save, Button btn_edit, Button btn_del)
        {
            try
            {
                qty=((float)Convert.ToDouble(txt_qty.Text));
            }
            catch(Exception)
            {
                qty=0;
            }
              try
            {
               price=((float)Convert.ToDouble(txtprice.Text));
            }
            catch(Exception)
            {
                price=0;
            }
            

             if (!dd.IsAvailable(" select * from  tbl_account_item where Item_='" + txtitem.Text + "' and Qty=" + qty + " and Weight='" + txt_weight.Text + "' and Usage_='" + txt_usage.Text + "'and Price_=" + price + " "))
                {
                    if (dd.IsRunQuery("  insert into tbl_account_item (Item_,Qty,[Weight],Usage_,Price_,Reg_date) values ('"+txtitem.Text+"',"+qty+",'" + txt_weight.Text + "','"+txt_usage.Text+"',"+price+",Convert(datetime,'"+DateTime.Now.ToString("dd-MM-yyyy")+"',105))"))
                    {

                        show_all(lstview, lbl_rows, txtitem, txt_qty, txt_weight, txt_usage, txtprice, btn_save, btn_edit, btn_del);
                    }
                }
            
        }
        public void edit_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtitem, TextBox txt_qty, ComboBox txt_weight, TextBox txt_usage, TextBox txtprice, Button btn_save, Button btn_edit, Button btn_del)
        {
            try
            {
                qty = ((float)Convert.ToDouble(txt_qty.Text));
            }
            catch (Exception)
            {
                qty = 0;
            }
            try
            {
                price = ((float)Convert.ToDouble(txtprice.Text));
            }
            catch (Exception)
            {
                price = 0;
            }
            try
            {
                weight = ((float)Convert.ToDouble(txt_weight.Text));
            }
            catch (Exception)
            {
                weight = 0;
            }

            if (dd.IsAvailable(" select * from  tbl_account_item where ID="+itemid+" "))
            {
                if (dd.IsRunQuery(" update tbl_account_item set  Item_='"+txtitem.Text+"',Qty="+qty+",[Weight]='" + txt_weight.Text + "',Usage_='"+txt_usage.Text+"',Price_="+price+",Reg_date=Convert(datetime,'"+DateTime.Now.ToString("dd-MM-yyyy")+"',105) where ID="+itemid+""))
                {

                    show_all(lstview, lbl_rows, txtitem, txt_qty, txt_weight, txt_usage, txtprice, btn_save, btn_edit, btn_del);
                }
            }
            

        }
        public void del_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtitem, TextBox txt_qty, ComboBox txt_weight, TextBox txt_usage, TextBox txtprice, Button btn_save, Button btn_edit, Button btn_del)
        {

            if (dd.IsAvailable("select * from tbl_account_item where  ID=" + itemid + " "))
                {

                    if (dd.IsRunQuery("Delete from tbl_account_item where ID=" + itemid + ""))
                    {
                      
                        show_all(lstview, lbl_rows,txtitem,txt_qty,txt_weight,txt_usage,txtprice,  btn_save, btn_edit, btn_del);

                    }
                }
            

        }
        public void per_unit(TextBox txt_qty, TextBox txt_price, ComboBox combox_unit, Label lbl_unit)
        {
            if (txt_price.TextLength > 0 && txt_qty.TextLength > 0)
            {
                lbl_unit.Text = " Per  " + combox_unit.Text + " : " + ((float)Convert.ToDouble(txt_price.Text) / (float)Convert.ToDouble(txt_qty.Text)).ToString() + "  ";
            }
        }
        public void show_all(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtitem, TextBox txt_qty, ComboBox txt_weight, TextBox txt_usage, TextBox txtprice, Button btn_save, Button btn_edit, Button btn_del)
        {
            txtitem.Text = string.Empty;
            txt_weight.Text = string.Empty;
            txt_usage.Text = string.Empty;
            txt_weight.Text = string.Empty;
            txtprice.Text = string.Empty;
            txt_qty.Text = string.Empty;
            Get_lstview(lstview, "Select *  from tbl_account_item");
            lbl_rows.Text = "Rows: " + dd.RunQuery_Scaler("Select Count(ID)  from tbl_account_item");


           itemid  = null;
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
        public void lstset(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     ID    ", 100, HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Item name    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Quantity    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Weight    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Usage Purpose    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Price    ", 100, HorizontalAlignment.Center);
            
            lstveiw.Columns.Add("     Registeration Date    ", 100, HorizontalAlignment.Center);




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
                    ListViewItem listitem = new ListViewItem(dr["ID"].ToString()); //1

                    listitem.SubItems.Add(dr["Item_"].ToString()); //2
                    listitem.SubItems.Add(dr["Qty"].ToString());//3
                    listitem.SubItems.Add(dr["Weight"].ToString());//4
                    listitem.SubItems.Add(dr["Usage_"].ToString());//5
                    listitem.SubItems.Add(dr["Price_"].ToString());//6
                    listitem.SubItems.Add(dr["Reg_date"].ToString());//7
                    
                   
                    lstveiw.Items.Add(listitem);
                   
                }


            }
        }
        public void _Selected(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtitem, TextBox txt_qty, ComboBox txt_weight, TextBox txt_usage, TextBox txtprice, Button btn_save, Button btn_edit, Button btn_del, object sender, EventArgs e)
        {
            if (lstview.SelectedItems.Count > 0)
            {
                

                ListViewItem item = lstview.SelectedItems[0];
               itemid  = item.SubItems[0].Text;


               txtitem.Text = item.SubItems[1].Text;
               txt_qty.Text = item.SubItems[2].Text;
               txt_weight.Text = item.SubItems[3].Text;
               txt_usage.Text = item.SubItems[4].Text;
               txtprice.Text = item.SubItems[5].Text;
               

               

               // selectted_file = item.SubItems[9].Text;
                // MessageBox.Show("Selected " + item.SubItems[0].Text);
            }
            if (Convert.ToInt32(itemid) > 0)
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
       
    }
}
