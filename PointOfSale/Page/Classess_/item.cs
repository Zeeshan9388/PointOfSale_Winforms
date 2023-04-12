using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace PointOfSale.Page.Classess_
{
    public class item
    {
        DataTable dt = null;
        string prdctid,itemid = null;
        method objmethod = new method();
        // Classssss.mmthod dd = new Classssss.mmthod();
        
        
        public void save(MetroFramework.Controls.MetroTextBox txtname, Label lbl, ListView lst, Button btn_save, Button btn_edit, Button btn_del)
        {
            try
            {
                if (!objmethod.IsAvailable("select * from UItems_ where NID=" +prdctid + " and UItems_='"+txtname.Text+"' "))
                {

                    if (objmethod.IsRunQuery("insert into UItems_ (NID,UItems_) values ("+prdctid+",'" + txtname.Text.Trim() + "')"))
                    {
                        objmethod.lblForeColorChange(lbl, "Save ", "t");

                        txtname.Text = string.Empty;
                        get_all(txtname, lst, lbl, btn_save, btn_edit, btn_del);
                        //// dd.viewall("select * from catname", dgv);
                        // dd.lbl_(lbl, "Rows: "+dd.RunQuery_Scaler("select count(NID) from catname"), "t");
                        // Get_lstview(lst, "select * from catname");
                    }

                }
                else
                {
                    objmethod.lblForeColorChange(lbl, "Exisitng Record", "f");
                }
            }
            catch (Exception)
            {
            }
        }
        public void edit(MetroFramework.Controls.MetroTextBox txt_user, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (txt_user.Text.Any())
            {
                if (objmethod.IsRunQuery("update UItems_ Set NID=" + prdctid + ", UItems_='" + txt_user.Text.Trim() + "' Where ItemID=" + itemid + ""))
                {
                    txt_user.Focus();
                    get_all(txt_user, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
                else
                {
                    
                  ClsMessage.Error(ClsMessage.ItemsHeader, ClsMessage.OPERATION_FAILD);
                    get_all(txt_user, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void del(MetroFramework.Controls.MetroTextBox txt_user, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (txt_user.Text.Any())
            {
                if (objmethod.IsRunQuery("Delete From UItems_  Where ItemID=" + itemid + ""))
                {
                    txt_user.Focus();
                    get_all(txt_user, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
                else
                {

                    ClsMessage.Error(ClsMessage.ItemsHeader, ClsMessage.ItemsDeleted);

                    get_all(txt_user, lstview, lbl_rows, btn_save, btn_del, btn_del);
                }
            }
        }
        public void get_all(MetroFramework.Controls.MetroTextBox txt_user, ListView lstview, Label lbl_rows, Button btn_save, Button btn_edit, Button btn_del)
        {
            txt_user.Text = string.Empty;
           // Get_lstview(lstview, "Select i.ItemID,cat.catname,i.UItems_,cat.NID From CatName as cat , UItems_  as i");
           
           Get_lstview(lstview, "Select i.ItemID,cat.catname,i.UItems_,cat.NID From CatName as cat inner join  UItems_ as i  on cat.NID=i.NID");
            lbl_rows.Text = "Rows : " + objmethod.RunQuery_Scaler("Select Count(ItemID) From  UItems_");
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
       
        public void srch(MetroFramework.Controls.MetroTextBox txt_user, ListView lstview, Label lbl_rows)
        {
            if (objmethod.IsAvailable("Select * From CatName Where Catname like '" + txt_user.Text + "%'"))
            {
                Get_lstview(lstview, "Select * From CatName Where Catname like '" + txt_user.Text + "%'");
                lbl_rows.Text = "Rows : " + objmethod.RunQuery_Scaler("Select Count(NID) From CatName Where Catname like '" + txt_user.Text + "%'");
            }
        }
        public void lstset(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     ID    ", 100,HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Product name    ", 100, HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Item    ", 100, HorizontalAlignment.Center);

            


            //ComID,PrdctID,txtSize
            /// End Here 
            /// PrvnceID,CntryID,txtCity
        }
        public void get_id(ComboBox combox)
        {
            prdctid = objmethod.RunQuery_Scaler("select NID from catname where catname='"+combox.Text+"'");

            if (prdctid == "" ||prdctid==string.Empty||prdctid=="0")
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

            dt = objmethod.dT_get(sel);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    
                    ListViewItem listitem = new ListViewItem(dr["ItemID"].ToString());



                    if (dr["NID"].ToString() == "" || dr["NID"].ToString() == string.Empty)
                    {
                        listitem.ForeColor = Color.Red;
                        listitem.BackColor = Color.Yellow;
                        listitem.SubItems.Add(dr["Catname"].ToString(), Color.Red, Color.Yellow, new Font("Arial", 10));
                   
                    }
                    listitem.SubItems.Add(dr["Catname"].ToString(),Color.Red,Color.Yellow,new Font("Arial",10));
                    listitem.ForeColor = Color.Black;
                    listitem.BackColor = Color.White;
                    listitem.SubItems.Add(dr["UItems_"].ToString());


                    lstveiw.Items.Add(listitem);
                }


            }
        }
        public void dgv_Selected(ListView listView1, MetroFramework.Controls.MetroTextBox txt_product, Button btn_save, Button btn_edit, Button btn_del, object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {


                ListViewItem item = listView1.SelectedItems[0];
                itemid = item.SubItems[0].Text;


                txt_product.Text = item.SubItems[2].Text;

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
        public void txt_prdct_KeyUp(MetroFramework.Controls.MetroTextBox txt_item, ListView lstview_, Label lbl_rows, Button btn_add, Button btn_edit, Button btn_del, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (prdctid == null)
                {
                    save(txt_item, lbl_rows, lstview_, btn_add, btn_edit, btn_del);

                }
                else
                {
                    edit(txt_item, lstview_, lbl_rows, btn_add, btn_edit, btn_del);

                }
            }
        }
   
    }
}
