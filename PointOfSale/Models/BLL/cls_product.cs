using PointOfSale.Page.Classess_;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using MetroFramework.Controls;
namespace PointOfSale.Models.BLL
{
  public  class cls_product
    {
        method dd = new method();
        DBModel.dbPOSEntities dbPOSEntitie = new DBModel.dbPOSEntities();

        public List<DBModel.tbl_ItemCategory> FillDropDownCategory() => dbPOSEntitie.tbl_ItemCategory.Where(c=>c.IsActive==true).ToList();
        public List<DBModel.tbl_Items> GetItems() => dbPOSEntitie.tbl_Items.ToList();

        public string Savedb(int id, long? categoryID,string ProductName,  int query)
        {
            var result = dd.RunQuery_Scaler($"exec SP_Items @ID={id},@CatID={categoryID},@Items={ProductName}, @CreatedBy=1,@query={query}");

            if (result.ToLower().Contains("save"))
            {
                ClsMessage.Success(ClsMessage.ItemsHeader, ClsMessage.ItemsSaved);

            }
            else if (result.ToLower().Contains("already"))
            {
                ClsMessage.Already(ClsMessage.ItemsHeader, ClsMessage.ItemsAlready);

            }
            return result;
        }
        public void save(int ItemID,long? categoryID,MetroTextBox txtProduct, Label lbl_row,RadGridView radGridView,MetroButton btn_save)
        {
            try
            {
                int query = 1;
                if (btn_save.Text == ClsMessage.BtnSAVED)
                    query = 1;
                else
                    query = 2;
                Savedb(ItemID,categoryID,txtProduct.Text,  query);
                GetAllProducts(txtProduct, radGridView, lbl_row, btn_save);

            }
            catch (Exception ex)
            {
                const string V = " \n\n";
                ClsMessage.Already(ClsMessage.CategoryHeader, ClsMessage.CategoryError + V + ex.Message);
            }
        }
        public void FillCategory(MetroComboBox metroComboBox)
        {
            var lstCategory = FillDropDownCategory();
            metroComboBox.DataSource = lstCategory;
            metroComboBox.DisplayMember = "Category";
            metroComboBox.ValueMember = "ID";
            metroComboBox.Text = "-- Select Category --";
        }

        public void GetAllProducts(MetroTextBox metroTextBox, RadGridView radGridView, Label lbl_rows,MetroButton btn_save)
        {
            metroTextBox.Text = string.Empty;
            FillGridView(radGridView, lbl_rows, null);
            btn_save.Text = ClsMessage.BtnSAVED;
            //----
            metroTextBox.Text = string.Empty;
            FillGridView(radGridView, lbl_rows, null);


        }

        public void srch(string search,RadGridView radGridView, Label lbl_rows) => FillGridView(radGridView, lbl_rows, search);
        public List<DBModel.Vu_Items> Get_Items(string search)
        {

            return (!string.IsNullOrWhiteSpace(search) || !string.IsNullOrEmpty(search) ? dbPOSEntitie.Vu_Items.Where(c => c.Category.Contains(search)).ToList() : dbPOSEntitie.Vu_Items.ToList());
        }

        public void FillGridView(RadGridView radGridView, Label lblrow, string search)
        {
            try
            {
                if (radGridView.MasterTemplate.Columns.Count > 0)
                {
                    radGridView.MasterTemplate.Columns.Clear();
                }
                radGridView.DataSource = Get_Items(search).ToList();

                GridViewCommandColumn commandDelete = new GridViewCommandColumn();

                commandDelete.Name = "btnEdit";
                commandDelete.UseDefaultText = true;
                commandDelete.FieldName = "ID";
                commandDelete.IsVisible = true;
                commandDelete.HeaderText = "Edit";
                commandDelete.Width = 10;
                radGridView.MasterTemplate.Columns.Add(commandDelete);
                commandDelete = new GridViewCommandColumn();
                commandDelete.Name = "btnDelete";
                commandDelete.UseDefaultText = true;
                commandDelete.FieldName = "ID";
                commandDelete.IsVisible = true;
                commandDelete.HeaderText = "Delete";
                commandDelete.Width = 10;
                radGridView.MasterTemplate.Columns.Add(commandDelete);



                radGridView.Columns[0].IsVisible =  radGridView.Columns[3].IsVisible =
                    radGridView.Columns[4].IsVisible = radGridView.Columns[5].IsVisible = radGridView.Columns[6].IsVisible = false;
                radGridView.Columns[7].Width = 10;
                radGridView.Columns[8].Width = 10;
                //radGridView.CommandCellClick += new CommandCellClickEventHandler(radGridView_CommandCellClick);




                lblrow.Text = ClsMessage.lblROW + " " + radGridView.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                ClsMessage.Error(ClsMessage.CategoryHeader, ex.Message);
            }
        }
        public void radGridView_CommandCellClick(RadGridView radGridView, Label lblRows, object sender, EventArgs e)
        {
            GridCommandCellElement gridCommandCellElement = ((sender as GridCommandCellElement));
            if (gridCommandCellElement.ColumnInfo.Name == "btnDelete")
            {
                var result = ClsMessage.Question("Are you sure want to delete ?", ClsMessage.CategoryHeader);
                if (result == 1)
                {
                    if (((sender as GridCommandCellElement)).Value != null)
                    {
                        int itemid = Convert.ToInt32(((sender as GridCommandCellElement)).Value.ToString());
                        var categoryResult = Savedb(id:itemid,categoryID:0,ProductName:string.Empty,query:3);
                        FillGridView(radGridView, lblRows, null);
                        Dashboard form1 = new Dashboard();
                        Page.Category UC_category = new Page.Category();
                        if (form1.splitContainer2.Panel2.Controls.Count > 0)
                        {
                            form1.splitContainer2.Panel2.Controls.Clear();
                        }
                        UC_category.Dock = DockStyle.Fill;
                        form1.splitContainer2.Panel2.Controls.Add(UC_category);
                        ClsMessage.Success(categoryResult, ClsMessage.CategoryHeader);
                    }
                }
            }
            else if (gridCommandCellElement.ColumnInfo.Name == "btnEdit")
            {
                int itemID = Convert.ToInt32(((sender as GridCommandCellElement)).Value.ToString());
                var Items = dbPOSEntitie.tbl_Items.Where(c => c.ID == itemID).FirstOrDefault();
                Models.SideDesign.frmProduct frmProduct = new SideDesign.frmProduct(itemID,Items.CatID,Items.Items,1);
                frmProduct.Show();
             
            }

        }
        public void dgv_Selected(RadGridView radGridView, MetroTextBox txtCategory, MetroButton btn_save, object sender, EventArgs e)
        {
            RadGridView radGridViewdep = (sender) as RadGridView;
            txtCategory.Text = radGridViewdep.CurrentRow.Cells[1].Value.ToString();

        }
        public void TxtCategory_KeyUp(int ItemID,long? CategoryID,MetroTextBox txtCategory,RadGridView radGridView_, Label lbl_rows,MetroButton btn_add, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save(ItemID, CategoryID, txtCategory, lbl_rows, radGridView_, btn_add);
            }
        }
        public void dgvCategory_CellFormatting(object sender,CellFormattingEventArgs e)
        {
            if (e.CellElement is GridCommandCellElement)
            {
                if (e.Column.Name == "btnEdit")
                {
                    ((RadButtonElement)e.CellElement.Children[0]).Image = Properties.Resources.edit;
                    ((RadButtonElement)e.CellElement.Children[0]).ImageAlignment = ContentAlignment.MiddleCenter;
                }
                if (e.Column.Name == "btnDelete")
                {
                    ((RadButtonElement)e.CellElement.Children[0]).Image = Properties.Resources.cross;
                    ((RadButtonElement)e.CellElement.Children[0]).ImageAlignment = ContentAlignment.MiddleCenter;
                }
                //if (e.CellElement.RowInfo.Cells["btnDelete"].Tag != null)
                //{
                //    ((RadButtonElement)e.CellElement.Children[0]).Image = Properties.Resources.cross;
                //    ((RadButtonElement)e.CellElement.Children[0]).ImageAlignment = ContentAlignment.MiddleCenter;
                //}
                //  ((RadButtonElement)e.CellElement.Children[0]).Image = Properties.Resources.edit;
                //((RadButtonElement)e.CellElement.Children[0]).ImageAlignment = ContentAlignment.MiddleCenter;
                //((RadButtonElement)e.CellElement.Children[1]).Image = Properties.Resources.cross;
                //((RadButtonElement)e.CellElement.Children[1]).ImageAlignment = ContentAlignment.MiddleCenter;
                //if (e.CellElement.RowInfo.Cells["btnEdit"].Tag != null)
                //{
                //    ((RadButtonElement)e.CellElement.Children[1]).Image = Properties.Resources.edit;
                //((RadButtonElement)e.CellElement.Children[1]).ImageAlignment = ContentAlignment.MiddleCenter;
                ////}



            }
        }
       

    }
}
