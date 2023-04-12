using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale.Page
{
    public partial class demo : MetroFramework.Forms.MetroForm
    {
        method dd = new method();
        DataTable dt = null;
        public demo()
        {
            InitializeComponent();
        }
        public void al()
        {
            DataTable dataTable = new DataTable("UItems_");

            dataTable.Columns.Add("ID", typeof(String));
            dataTable.Columns.Add("Category", typeof(String));
            dataTable.Columns.Add("Items", typeof(String));
            dt = dd.dT_get("select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID ");

            ///  da.items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dataTable.Rows.Add(new String[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString() });
            }
            combox_chcking.DataSource = dataTable;
            combox_chcking.DisplayMember = dataTable.Columns[0].ToString() + "" + dataTable.Columns[1].ToString() + "" + dataTable.Columns[2].ToString();
            combox_chcking.ValueMember = "Category";
        }
        public void chc()
        {
            string sel = "";
            sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID where i.UItems_ like '%%" + combox_chcking.Text + "%%' OR c.Catname like '%%" + combox_chcking.Text + "%%' OR Cast(i.ItemID as Char) like '%%" + combox_chcking.Text + "%%'";

            dt = dd.dT_get(sel);

           // da.items.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                //DataRow dr_ = da.items.NewRow();
                //dr_["Id"] = dr[0].ToString();
                //dr_["catname"] = dr[1].ToString();
                //dr_["items"] = dr[2].ToString();
                //da.items.Rows.Add(dr_);

                combox_chcking.Items.Add(dr[0].ToString() + "               " + dr[1].ToString() + "               " + dr[2].ToString());
            }
            // radMultiColumnComboBox1.DataBindings = da.items[0];
            //radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns = "";

        }
        public void chc_()
        {

            if (txt_content.TextLength < 1)
            {
                //lstbox.Hide();

                lstbox.ForeColor = Color.Black;
                lstbox.BackColor = Color.White;
            }
            else
            {
                try
                {
                    if (lstbox.Items.Count > 0)
                    {
                        lstbox.Items.Clear();

                    }
                    string sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID";
                    //if (Convert.ToInt32(txt_content.Text) == Int32.Parse(txt_content.Text))
                    //{

                    //    lbl_rows.Text = "enter correct value of int";
                    //    sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID where i.UItemID= " + Convert.ToInt32(txt_content.Text) + "";

                    //}
                    //else
                    //{
                        lbl_rows.Text = "enter correct value of string";
                        sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID where i.UItems_ like '%%" + txt_content.Text + "%%' OR c.Catname like '%%" + txt_content.Text + "%%' OR Cast(i.ItemID as Char) like '%%"+txt_content.Text+"%%'";

                   // }

                    dt = dd.dT_get(sel);





                    foreach (DataRow dr in dt.Rows)
                    {
                        lstbox.ForeColor = Color.White;
                        lstbox.BackColor = Color.Black;
                        lstbox.Items.Add(dr[0].ToString() + "               " + dr[1].ToString() + "               " + dr[2].ToString());
                    }
                    lstbox.Show();
                    lbl_rows.Text = "Rows: "+lstbox.Items.Count.ToString();
                }
                catch (Exception)
                { }
                lbl_rows.Text = "Rows: " + lstbox.Items.Count.ToString();
            }
        }
        private void demo_Load(object sender, EventArgs e)
        {
            //   chc();
            MetroFramework.MetroMessageBox.Show(this, "testing", "demo", MessageBoxButtons.OK);
        }

        private void txt_content_TextChanged(object sender, EventArgs e)
        {
            chc_();

        }

        private void combox_chcking_SelectedIndexChanged(object sender, EventArgs e)
        {
            chc();
        }
    }
}
