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
    public partial class Items : MetroFramework.Controls.MetroUserControl
    {
        Page.Classess_.item objItems = new Classess_.item();
        Models.BLL.cls_product cls_Product = new Models.BLL.cls_product();
        method dd = new method();
        public Items() => InitializeComponent();

        private void Items_Load(object sender, EventArgs e)
        {
            cls_Product.FillCategory(ddl_Category);
            cls_Product.GetAllProducts(txt_item, dgv_Product, lbl_rows, btn_add);
        }
        private void btn_add_Click(object sender, EventArgs e) => cls_Product.save(0, Convert.ToInt64(ddl_Category.SelectedValue.ToString()), txt_item, lbl_rows, dgv_Product, btn_add);
        private void btn_clr_Click(object sender, EventArgs e) => cls_Product.GetAllProducts(txt_item, dgv_Product, lbl_rows, btn_add);
        private void dgv_Product_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e) => cls_Product.dgvCategory_CellFormatting(sender, e);
        private void dgv_Product_CommandCellClick(object sender, EventArgs e) => cls_Product.radGridView_CommandCellClick(dgv_Product, lbl_rows, sender, e);
    }
}
