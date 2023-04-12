using PointOfSale.Models.BLL;
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
    public partial class EditCategory :  MetroFramework.Forms.MetroForm
    {
        cls_category cls_Category = new cls_category();

        public int _ID { get; set; }
        public string _Category { get; set; }
        public int _CreatedBy { get; set; }
        public EditCategory(int ID,string Category,int CreatedBy)
        {
            InitializeComponent();
            _ID = ID;
            _Category = Category;
            _CreatedBy = CreatedBy;
        }

        private void EditCategory_Load(object sender, EventArgs e)
        {
            txtBoxCategory.Text = _Category;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try {
                cls_Category.Savedb(txtBoxCategory.Text, _ID, 2);
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

        private void btn_clr_Click(object sender, EventArgs e)
        {
            txtBoxCategory.Text = "";
        }
    }
}
