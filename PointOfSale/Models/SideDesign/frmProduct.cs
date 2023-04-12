using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale.Models.SideDesign
{
    public partial class frmProduct : MetroFramework.Forms.MetroForm
    {
        Models.BLL.cls_product cls_Product = new BLL.cls_product();
        public int _ID { get; set; }
        public long? _CategoryID { get; set; }
        public string _Product { get; set; }
        public int _CreatedBy { get; set; }
        public frmProduct(int ID, long? CategoryID,string Product,int CreatedBy)
        {
            InitializeComponent();
            _ID = ID;
            _CategoryID = CategoryID;
            _Product = Product;
            _CreatedBy = CreatedBy;
            cls_Product.FillCategory(ddl_Category);
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            
            
            ddl_Category.SelectedValue = _CategoryID;
            txt_item.Text = _Product;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                cls_Product.Savedb(_ID, _CategoryID, _Product, 2);
                Dashboard form1 = new Dashboard();
                Page.Category UC_category = new Page.Category();
                if (form1.splitContainer2.Panel2.Controls.Count > 0)
                {
                    form1.splitContainer2.Panel2.Controls.Clear();
                }
                UC_category.Dock = DockStyle.Fill;
                form1.splitContainer2.Panel2.Controls.Add(UC_category);
                this.Hide();
            }
            catch { }
        }
    }
}
