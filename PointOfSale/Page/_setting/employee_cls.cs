using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Drawing;

namespace PointOfSale.Page._setting
{
    class employee_cls
    {
        DataTable dt = null;
        OpenFileDialog ofdFindPhoto = new OpenFileDialog();
        method dd = new method();
        string saveDirectory = @"D:\Employee_Photos\";
        
        string fileSavePath,selectted_file="";
        string empid = "";
        string fileName = "";
        public void upload(PictureBox pbbox)
        {
            ofdFindPhoto.Title = "Select a Photo ";
            ofdFindPhoto.InitialDirectory = @"D:\Desktop";
            ofdFindPhoto.FileName = "";
            ofdFindPhoto.Filter = "JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png|BMP Image|*.bmp";
            ofdFindPhoto.Multiselect = false;
            if (ofdFindPhoto.ShowDialog() != DialogResult.OK) { return; }



            // Show the recently uploaded photo on profile
            pbbox.ImageLocation = ofdFindPhoto.FileName;
            
            /*
            photoPath = Application.StartupPath + @"D:\Employee_Photos\" + 
                   Path.GetExtension(ofdFindPhoto.FileName);
            if (!Directory.Exists(Application.StartupPath + @"D:\Employee_Photos"))
                Directory.CreateDirectory(Application.StartupPath + @"D:\Employee_Photos");
       */

            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

             fileName = Path.GetFileName(ofdFindPhoto.FileName);
             fileSavePath = Path.Combine(saveDirectory, fileName);
         
        }
        public void save_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtname, TextBox txtfname, NumericUpDown starting_salary, TextBox txt_age, TextBox txt_cnic, NumericUpDown current_salary, TextBox txt_contact, TextBox txt_address, PictureBox pbox, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (!string.IsNullOrWhiteSpace(fileSavePath) || !string.IsNullOrEmpty(fileSavePath))
            {
                if (!dd.IsAvailable("select * from tbl_employie where emp_name='" + txtname.Text + "' and emp_fname='" + txtfname.Text + "'  and start_salary=" + starting_salary.Value + " and emp_age='" + txt_age.Text + "' and emp_cnic='" + txt_cnic.Text + "' and current_salary=" + current_salary.Value + " and emp_contactno='" + txt_contact.Text + "' and emp_address='" + txt_address.Text + "' and emp_picture='" + fileSavePath + "' "))
                {
                    if (dd.IsRunQuery("  insert into tbl_employie (emp_name,emp_fname,start_salary,emp_age,emp_cnic,current_salary,emp_contactno,emp_address,emp_Registeration_date,emp_picture)"
                        + "values('" + txtname.Text + "','" + txtfname.Text + "'," + starting_salary.Value + ",'" + txt_age.Text + "','" + txt_cnic.Text + "'," + current_salary.Value + ",'" + txt_contact.Text + "','" + txt_address.Text + "','Convert(datetime," + DateTime.Now.ToString("dd-MM-yyyy") + ",105)','" + fileSavePath + "')"))
                    {
                        File.Copy(ofdFindPhoto.FileName, fileSavePath, true);

                        show_all(lstview, lbl_rows, txtname, txtfname, starting_salary, txt_age, txt_cnic, current_salary, txt_contact, txt_address, pbox, btn_save, btn_edit, btn_del);
                    }
                }
            }
        }
        public void edit_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtname, TextBox txtfname, NumericUpDown starting_salary, TextBox txt_age, TextBox txt_cnic, NumericUpDown current_salary, TextBox txt_contact, TextBox txt_address, PictureBox pbox, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (!string.IsNullOrWhiteSpace(fileSavePath) || !string.IsNullOrEmpty(fileSavePath) && !string.IsNullOrWhiteSpace(empid) || !string.IsNullOrEmpty(empid))
            {
                if (dd.IsAvailable("select * from tbl_employie where  ID=" + empid + " "))
                {

                    if (dd.IsRunQuery("update tbl_employie set emp_name='"+txtname.Text+"',emp_fname='"+txtfname.Text+"',start_salary="+starting_salary.Value+",emp_age='"+txt_age.Text+"',emp_cnic='"+txt_cnic.Text+"',current_salary="+current_salary.Value+",emp_contactno='"+txt_contact.Text+"',emp_address='"+txt_address.Text+"',emp_picture='"+fileSavePath+"'"
                        + "where ID="+empid+""))
                    {
                        if (selectted_file == null || selectted_file == string.Empty)
                        {
                            pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                        }
                        else
                        {
                            if (File.Exists(selectted_file))
                            {
                                pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                               // File.Delete(selectted_file);
                            }
                            else
                            {
                                pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                            }

                        }
                        File.Copy(ofdFindPhoto.FileName, fileSavePath, true);
                        show_all(lstview, lbl_rows, txtname, txtfname, starting_salary, txt_age, txt_cnic, current_salary, txt_contact, txt_address, pbox, btn_save, btn_edit, btn_del);
                    
                    }
                }
            }

        }
        public void del_(ListView lstview, ToolStripStatusLabel lbl_rows, TextBox txtname, TextBox txtfname, NumericUpDown starting_salary, TextBox txt_age, TextBox txt_cnic, NumericUpDown current_salary, TextBox txt_contact, TextBox txt_address, PictureBox pbox, Button btn_save, Button btn_edit, Button btn_del)
        {
            if (!string.IsNullOrWhiteSpace(fileSavePath) || !string.IsNullOrEmpty(fileSavePath) && !string.IsNullOrWhiteSpace(empid) || !string.IsNullOrEmpty(empid))
            {
                if (dd.IsAvailable("select * from tbl_employie where  ID="+empid+" "))
                {

                    if (dd.IsRunQuery("Delete from tbl_employie where ID="+empid+""))
                    {
                        if (selectted_file == null || selectted_file == string.Empty)
                        {
                            pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                        }
                        else
                        {
                            if (File.Exists(selectted_file))
                            {
                                pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                                File.Delete(selectted_file);
                            }
                            else
                            {
                                pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                            }
                            
                        }
                        show_all(lstview, lbl_rows, txtname, txtfname, starting_salary, txt_age, txt_cnic, current_salary, txt_contact, txt_address, pbox, btn_save, btn_edit, btn_del);
                    
                    }
                }
            }

        }

        public void show_all(ListView lstview,ToolStripStatusLabel lbl_rows, TextBox txtname, TextBox txtfname, NumericUpDown starting_salary, TextBox txt_age, TextBox txt_cnic, NumericUpDown current_salary, TextBox txt_contact, TextBox txt_address, PictureBox pbox, Button btn_save, Button btn_edit, Button btn_del)
        {
            pbox.Image = Image.FromFile(Application.StartupPath+"\\profile.png");
            txt_address.Text = string.Empty;
            txt_age.Text = string.Empty;
            txt_cnic.Text = string.Empty;
            txt_contact.Text = string.Empty;
            txtfname.Text = string.Empty;
            txtname.Text = string.Empty;
            starting_salary.Value = 0;
            current_salary.Value = 0;
            Get_lstview(lstview, "Select *  from tbl_employie");
            lbl_rows.Text = "Rows: " + dd.RunQuery_Scaler("Select Count(ID)  from tbl_employie");


            empid = null;
                if (btn_del.Enabled == true)
                {
                    btn_del.Enabled = false;
                }
                if (btn_edit.Enabled == true)
                {
                    btn_edit.Enabled = false;
                }
                if (btn_save.Enabled == false)
                {
                    btn_save.Enabled = true;
                }
            
            

 
        }
        public void lstset(ListView lstveiw)
        {

            ///Start list view 
            lstveiw.View = View.Details;
            lstveiw.GridLines = true;
            lstveiw.FullRowSelect = true;

            //Add column header
            lstveiw.Columns.Add("     ID    ", 100, HorizontalAlignment.Center);

            lstveiw.Columns.Add("     Name    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Father name    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Start Salary    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Age    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Cnic    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Current Salary    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Contact no#    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Address    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Picture path    ", 100, HorizontalAlignment.Center);
            lstveiw.Columns.Add("     Registeration Date    ", 100, HorizontalAlignment.Center);




            //ComID,PrdctID,txtSize
            /// End Here 
            /// PrvnceID,CntryID,txtCity
        }

        public void Get_lstview(ListView lstveiw, string sel)
        {
            if (lstveiw.Items.Count > 0)
            {
                lstveiw.Items.Clear();
            }
            if (lstveiw.SelectedItems.Count > 0)
            {
                lstveiw.Items.Clear();
            }

            dt = dd.dT_get(sel);


            ImageList imageList = new ImageList();



            lstveiw.Items.Clear();






            imageList.ImageSize = new Size(32, 32);



            lstveiw.View = View.Details;



            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem listitem = new ListViewItem(dr["ID"].ToString()); //1

                    listitem.SubItems.Add(dr["emp_name"].ToString()); //2
                    listitem.SubItems.Add(dr["emp_fname"].ToString());//3
                    listitem.SubItems.Add(dr["start_salary"].ToString());//4
                    listitem.SubItems.Add(dr["emp_age"].ToString());//5
                    listitem.SubItems.Add(dr["emp_cnic"].ToString());//6
                    listitem.SubItems.Add(dr["current_salary"].ToString());//7
                    listitem.SubItems.Add(dr["emp_contactno"].ToString());//8
                    listitem.SubItems.Add(dr["emp_address"].ToString());//9
                    listitem.SubItems.Add(dr["emp_picture"].ToString());//10
                    listitem.SubItems.Add(dr["emp_Registeration_date"].ToString());//11
                 
                   // imageList.Images.Add(Image.FromFile(dr["emp_picture"].ToString()));
                   // lstveiw.LargeImageList = imageList;
                    //lstveiw.SmallImageList = imageList;
                    lstveiw.Items.Add(listitem);
                    //lstveiw.LargeImageList = imageList;
                }


            }
        }
        public void _Selected(ListView listView1, TextBox txtname, TextBox txtfname, NumericUpDown starting_salary, TextBox txt_age, TextBox txt_cnic, NumericUpDown current_salary, TextBox txt_contact, TextBox txt_address,PictureBox pbox, Button btn_save, Button btn_edit, Button btn_del, object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {


                ListViewItem item = listView1.SelectedItems[0];
                empid = item.SubItems[0].Text;


                txtname.Text = item.SubItems[1].Text;
                txtfname.Text = item.SubItems[2].Text;
                starting_salary.Value = Convert.ToInt32(item.SubItems[3].Text);
                txt_age.Text = item.SubItems[4].Text;
                txt_cnic.Text = item.SubItems[5].Text;
                current_salary.Value = Convert.ToInt32(item.SubItems[6].Text);
                txt_contact.Text = item.SubItems[7].Text;
                txt_address.Text = item.SubItems[8].Text;

                if (item.SubItems[9].Text != null || item.SubItems[9].Text != string.Empty)
                {
                    if (File.Exists(item.SubItems[9].Text))
                    {
                        pbox.Image = Image.FromFile(item.SubItems[9].Text);
                    }
                    else
                    {
                        pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                    }

                }
                else
                {
                    pbox.Image = Image.FromFile(Application.StartupPath + "\\profile.png");
                }
                
                selectted_file = item.SubItems[9].Text;
                // MessageBox.Show("Selected " + item.SubItems[0].Text);
            }
            if (Convert.ToInt32(empid) > 0)
            {
                if (btn_del.Enabled == false)
                {
                    btn_del.Enabled = true;
                }
                if (btn_edit.Enabled == false)
                {
                    btn_edit.Enabled = true;
                }
                if (btn_save.Enabled == true)
                {
                    btn_save.Enabled = false;
                }
            }
        }
       
    }
}
