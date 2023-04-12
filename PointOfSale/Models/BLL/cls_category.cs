using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Telerik.WinControls.UI;
using System.Drawing;
using PointOfSale.Page.Classess_;


namespace PointOfSale.Models.BLL
{
   
   public class cls_category
    {

        //int CategoryID = 0;
        method dd = new method();
        DBModel.dbPOSEntities dbPOSEntitie = new DBModel.dbPOSEntities();

        public string Savedb(string category, int id, int query)
        {
            var result = dd.RunQuery_Scaler(" exec SP_Category @ID="+ id + ",@Category='"+category+"',@CreatedBy=1,@query="+query);

            if (result.ToLower().Contains("save"))
            {
                ClsMessage.Success(ClsMessage.CategoryHeader, ClsMessage.CategorySave);

            }
            else if (result.ToLower().Contains("already"))
            {
                ClsMessage.Already(ClsMessage.CategoryHeader, ClsMessage.CategoryAlready);

            }
            return result;
        }
        public void save(int categoryID,MetroFramework.Controls.MetroTextBox txtCategory, Label lbl_row, Telerik.WinControls.UI.RadGridView radGridView, MetroFramework.Controls.MetroButton btn_save)
        {
            try
            {
                int query = 1;
                if (btn_save.Text == ClsMessage.BtnSAVED)
                    query = 1;
                else
                    query = 2;
                Savedb(txtCategory.Text, categoryID, query);
                get_all(txtCategory, radGridView, lbl_row, btn_save);

            }
            catch (Exception ex)
            {
                const string V = " \n\n";
                ClsMessage.Already(ClsMessage.CategoryHeader, ClsMessage.CategoryError + V + ex.Message);
            }
        }

        public void get_all(MetroFramework.Controls.MetroTextBox txtCategory, Telerik.WinControls.UI.RadGridView radGridView, Label lbl_rows, MetroFramework.Controls.MetroButton btn_save)
        {
            txtCategory.Text = string.Empty;
            Get_lstview(radGridView, lbl_rows, null);
          
            btn_save.Text = ClsMessage.BtnSAVED;

        }

        public void srch(string search, Telerik.WinControls.UI.RadGridView radGridView, Label lbl_rows) => Get_lstview(radGridView, lbl_rows, search);
        public List<DBModel.Vu_Category> Get_Categories(string search)
        {
            
            return (!string.IsNullOrWhiteSpace(search) || !string.IsNullOrEmpty(search) ? dbPOSEntitie.Vu_Category.Where(c => c.Category.Contains(search)).ToList() : dbPOSEntitie.Vu_Category.ToList());
        }

        public void Get_lstview(Telerik.WinControls.UI.RadGridView radGridView, Label lblrow, string search)
        {
            try
            {
                if (radGridView.MasterTemplate.Columns.Count > 0)
            {
                radGridView.MasterTemplate.Columns.Clear();
            }
                 radGridView.DataSource = Get_Categories(search).ToList();

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
             


                radGridView.Columns[0].IsVisible = radGridView.Columns[2].IsVisible = radGridView.Columns[3].IsVisible =
                    radGridView.Columns[4].IsVisible = radGridView.Columns[5].IsVisible = radGridView.Columns[6].IsVisible = false;
                radGridView.Columns[7].Width = 10;
                //radGridView.CommandCellClick += new CommandCellClickEventHandler(radGridView_CommandCellClick);




                lblrow.Text = ClsMessage.lblROW + " " + radGridView.Rows.Count.ToString();
        }
            catch (Exception ex)
            {
                ClsMessage.Error(ClsMessage.CategoryHeader, ex.Message);
            }
}
        public void radGridView_CommandCellClick(Telerik.WinControls.UI.RadGridView radGridView, Label lblRows, object sender, EventArgs e)
        {
            GridCommandCellElement gridCommandCellElement = ((sender as GridCommandCellElement));
            if (gridCommandCellElement.ColumnInfo.Name == "btnDelete")
            {
                var result = ClsMessage.Question("Are you sure want to delete ?", ClsMessage.CategoryHeader);
                if (result == 1)
                {
                    if (((sender as GridCommandCellElement)).Value != null)
                    {
                        int category = Convert.ToInt32(((sender as GridCommandCellElement)).Value.ToString());
                        var categoryResult = Savedb(category: null, id: category, query: 3);
                        Get_lstview(radGridView, lblRows, null);
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
                int categoryid = Convert.ToInt32(((sender as GridCommandCellElement)).Value.ToString());
                var lstcategory = dbPOSEntitie.Vu_Category.Where(c => c.ID == categoryid).FirstOrDefault();
                Models.SideDesign.EditCategory editCategory = new SideDesign.EditCategory(categoryid, lstcategory.Category,1);
                editCategory.Show();
            }

        }
        public void dgv_Selected(Telerik.WinControls.UI.RadGridView radGridView, MetroFramework.Controls.MetroTextBox txtCategory, MetroFramework.Controls.MetroButton btn_save, object sender, EventArgs e)
        {
            Telerik.WinControls.UI.RadGridView radGridViewdep = (sender) as Telerik.WinControls.UI.RadGridView;
           
            txtCategory.Text = radGridViewdep.CurrentRow.Cells[1].Value.ToString();

        }
        public void TxtCategory_KeyUp(int categoryID, MetroFramework.Controls.MetroTextBox txtCategory, Telerik.WinControls.UI.RadGridView radGridView_, Label lbl_rows, MetroFramework.Controls.MetroButton btn_add, object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                save(categoryID, txtCategory, lbl_rows, radGridView_, btn_add);
            }
        }
        public void dgvCategory_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
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
        public void dgvCategory_CurrentRowChanging(int categoryID, MetroFramework.Controls.MetroTextBox txtCategory, Telerik.WinControls.UI.RadGridView radGridView, Label lbl_rows, MetroFramework.Controls.MetroButton btn_save, object sender, Telerik.WinControls.UI.CurrentRowChangingEventArgs e)
        {
            try
            {
                Savedb(e.CurrentRow.Cells[1].Value.ToString(), categoryID, 2);
                get_all(txtCategory, radGridView, lbl_rows, btn_save);
            }
            catch { }
        }
    }
}
