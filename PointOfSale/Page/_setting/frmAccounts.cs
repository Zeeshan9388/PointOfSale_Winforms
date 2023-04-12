using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale.Page._setting
{
    public partial class frmAccounts : UserControl
    {
        cls_employee_salaries es = new cls_employee_salaries();
       
        cls_item_account cia = new cls_item_account();
        Classess_.gernal g = new Classess_.gernal();
        public frmAccounts()
        {
            InitializeComponent();
            cia.lstset(lstview_item);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        #region item_ buton_hover and leave 
        
        
        private void btn_p_add_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_p_add, "h");

        }

        private void btn_p_add_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_p_add, "l");
        }

        private void btn_p_update_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_p_update, "h");
        }

        private void btn_p_update_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_p_update, "l");
        }

        private void btn_p_del_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_p_del, "h");
        }

        private void btn_p_del_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_p_del, "l");
        }

        private void btn_p_clr_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_p_clr, "h");
        }

        private void btn_p_clr_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_p_clr, "l");
        }

        private void btn_slry_add_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_slry_add, "h");
        }

        private void btn_slry_add_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_slry_add, "l");
        }

        private void btn_slry_edit_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_slry_edit, "h");
        }

        private void btn_slry_edit_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_slry_edit, "l");
        }

        private void btn_slry_del_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_slry_del, "h");
        }

        private void btn_slry_del_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_slry_del, "l");
        }

        private void btn_slry_clr_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_slry_clr, "h");
        }

        private void btn_slry_clr_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_slry_clr, "l");
        }
        #endregion
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            cia.show_all(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del);
            es.emp_record(combox_employee);
        }
        #region Item account button
        
       
        private void btn_p_add_Click(object sender, EventArgs e)
        {
            cia.save_(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del);
            lbl_item_per_unit.Text = string.Empty;
        }

        private void btn_p_update_Click(object sender, EventArgs e)
        {
            cia.edit_(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del);
            lbl_item_per_unit.Text = string.Empty;
        }

        private void btn_p_del_Click(object sender, EventArgs e)
        {
            cia.del_(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del);
        }

        private void btn_p_clr_Click(object sender, EventArgs e)
        {
            cia.show_all(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del);
            lbl_item_per_unit.Text = string.Empty;
        }
       

        private void txt_p_qty_TextChanged(object sender, EventArgs e)
        {
            cia.per_unit(txt_p_qty, txt_price, txt_weight, lbl_item_per_unit);
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            cia.per_unit(txt_p_qty, txt_price, txt_weight, lbl_item_per_unit);
       
        }

        private void txt_weight_SelectedIndexChanged(object sender, EventArgs e)
        {
            cia.per_unit(txt_p_qty, txt_price, txt_weight, lbl_item_per_unit);
       
        }

        private void lstview_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            cia._Selected(lstview_item, lbl_item_row, txt_item, txt_p_qty, txt_weight, txt_usage_product, txt_price, btn_p_add, btn_p_update, btn_p_del,sender,e);
        }
        #endregion
    }
}
