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
    public partial class frmEmployee : UserControl
    {
        Classess_.gernal g = new Classess_.gernal();
        employee_cls ec = new employee_cls();
        public frmEmployee()
        {
            InitializeComponent();
            ec.lstset(lstview_emp);
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ec.show_all(lstview_emp, lbl_rows, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del);
        }

        private void picbox_upload_Click(object sender, EventArgs e)
        {
            ec.upload(picbox_upload);
        }

        private void btn_add_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_add, "h");
        }

        private void btn_add_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_add, "l");
        }

        private void btn_edit_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_edit, "h");
        }

        private void btn_edit_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_edit, "l");
        }

        private void btn_del_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_del, "h");
        }

        private void btn_del_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_del, "l");
        }

        private void btn_clr_MouseEnter(object sender, EventArgs e)
        {
            g.btn_(btn_clr, "h");
        }

        private void btn_clr_MouseLeave(object sender, EventArgs e)
        {
            g.btn_(btn_clr, "l");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ec.save_(lstview_emp, lbl_rows, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del);

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            ec.edit_(lstview_emp, lbl_rows, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            ec.del_(lstview_emp, lbl_rows, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del);
        }

        private void btn_clr_Click(object sender, EventArgs e)
        {
            ec.show_all(lstview_emp, lbl_rows, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del);
       
        }

        private void lstview_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec._Selected(lstview_emp, txt_name, txt_fname, numbric_ssalary, txt_age, txt_cnic, numbric_csalary, txt_contact, txt_address, picbox_upload, btn_add, btn_edit, btn_del, sender, e);
        }

        
    }
}
