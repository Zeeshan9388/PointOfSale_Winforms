using PointOfSale.Page.Classess_;
using System;


namespace PointOfSale.Page
{
    public partial class Category : MetroFramework.Controls.MetroUserControl
    {
        Models.BLL.cls_category objcategory = new Models.BLL.cls_category();
        public Category()
        {
            InitializeComponent();
            
        }

        private void btn_add_Click(object sender, EventArgs e) => objcategory.save(0,txtBoxCategory, lbl_rows, dgvCategory, btn_add);
        private void btn_clr_Click(object sender, EventArgs e) => objcategory.get_all(txtBoxCategory, dgvCategory, lbl_rows, btn_add);
        private void dgvCategory_SelectedIndexChanged(object sender, EventArgs e) => objcategory.dgv_Selected(dgvCategory, txtBoxCategory, btn_add, sender, e);
        private void txtBoxCategory_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) => objcategory.TxtCategory_KeyUp(0,txtBoxCategory, dgvCategory, lbl_rows, btn_add, sender, e);

        private void dgvCategory_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            objcategory.dgvCategory_CellFormatting(sender, e);
        }

        private void dgvCategory_CommandCellClick(object sender, EventArgs e)
        {
            objcategory.radGridView_CommandCellClick(dgvCategory,lbl_rows,sender, e);
        }

        private void Category_Load(object sender, EventArgs e)
        {
            objcategory.get_all(txtBoxCategory, dgvCategory, lbl_rows, btn_add);
        }

       

        private void dgvCategory_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
        }

        private void dgvCategory_CurrentRowChanging(object sender, Telerik.WinControls.UI.CurrentRowChangingEventArgs e)
        {
            
           // objcategory.dgvCategory_CurrentRowChanging(txtBoxCategory, dgvCategory, lbl_rows, btn_add, sender, e);

        }
    }
}
