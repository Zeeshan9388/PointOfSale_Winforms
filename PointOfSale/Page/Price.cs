using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale.Page
{
    public partial class Price : MetroFramework.Controls.MetroUserControl
    {
        Page.Classess_.price objPrice = new Classess_.price();
        public Price()
        {
            InitializeComponent();
            objPrice.lstset(lstview_price);
         //   txt_price.Text = "Rs: ";
        }

        

        
        private void Price_Load(object sender, EventArgs e)
        {
            objPrice.get_categoy(combox_prdct);
            objPrice.get_all(txt_size, txt_price, lstview_price, lbl_rows, btn_add, btn_edit, btn_del);
        }

        private void combox_prdct_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPrice.get_item(combox_prdct, combox_item);
        }

        private void combox_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPrice.get_itemid(combox_item);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            objPrice.get_all(txt_size, txt_price, lstview_price, lbl_rows, btn_add, btn_edit, btn_del);
        
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            objPrice.del(txt_size, txt_price, lstview_price, lbl_rows, btn_add, btn_edit, btn_del);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            objPrice.edit(txt_size, txt_price, lstview_price, lbl_rows, btn_add, btn_edit, btn_del);
       
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            objPrice.save(txt_size, txt_price, lbl_rows,lstview_price,  btn_add, btn_edit, btn_del);
       
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            //if (txt_price.TextLength > 3)
            //{

            //    txt_price.Text.Contains("Rs: ");
            //}
            //else
            //{
            //    txt_price.Text = "Rs: ";
            //}
        }

        private void lstview_price_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPrice.dgv_Selected(lstview_price, txt_size, txt_price, btn_add, btn_edit, btn_del, sender, e);
        }
    }
}
