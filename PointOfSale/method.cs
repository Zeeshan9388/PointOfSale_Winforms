using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;

namespace PointOfSale
{
    class method
    {
        public void btn_(Button btn, string status)
        {
            try
            {
                if (status == "h")
                {

                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.White;
                }
                if (status == "l")
                {
                    btn.ForeColor = Color.DarkGray;
                    btn.BackColor = Color.Transparent;

                }
            }
            catch (Exception)
            { }
        }
        public void init(Button btn)
        {
            btn.ForeColor = Color.FromArgb(0, 255, 254, 255);
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 254);
            // Transparent border
        }
        //DataTable dtbl = new DataTable();
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        
        SqlConnection con = new SqlConnection(dsn.con);
        
        SqlCommand com;
        
        
        SqlDataAdapter adptr;

        
        
       SqlDataReader dr;
       
        float f_txt = 0;
        bool  ischck, como = false;
        #region Method
        public bool IsFillListBox(string query, ListBox lstbox)
        {

            //try
            //{
                if (lstbox.Items.Count > 0)
                {
                    lstbox.Items.Clear();
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
               com = new SqlCommand(query, con);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    if (lstbox.Items.Count > 0)
                    {
                        lstbox.Items.Clear();
                    }
                    lstbox.Enabled = true;

                    while (dr.Read())
                    {
                        lstbox.Items.Add(dr[0].ToString());
                        //   MessageBox.Show("Country " + dr[0].ToString());
                    }
                }
                else
                {
                    lstbox.Enabled = false;
                    if (lstbox.Items.Count > 0)
                    {
                        lstbox.Items.Clear();
                    }
                }
                dr.Dispose();
                if (lstbox.Items.Count > 0)
                {

                    lstbox.Enabled = true;
                    lstbox.SelectedIndex = 0;
                }
                else
                {
                    lstbox.Enabled = false;
                }

                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            //}
            //catch (Exception)
            //{
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }

            //}
            return como;
        }

        public string lblInvoke(Label lbl, string str)
        {
            try
            {
                lbl.Invoke(new Action(() =>
                {
                    lbl.Text = str;
                    lbl.BackColor = Color.White;

                }));
                lbl.Invoke((Action)(() => lbl.Update()));
            }
            catch (Exception)
            {
            }
            return lbl.Text;
        }
        public string lblInvokeWithColor(Label lbl, string str, Color clr)
        {
            try
            {
                lbl.Invoke(new Action(() =>
                {
                    lbl.Text = str;
                    lbl.ForeColor = clr;
                    lbl.BackColor = Color.Black;

                }));
                lbl.Invoke((Action)(() => lbl.Update()));
            }
            catch (Exception)
            {
            }
            return lbl.Text;
        }
        public string BtnInvoke(Button btn, string str)
        {
            try
            {
                btn.Invoke(new Action(() =>
                {
                    btn.Text = str;

                }));
                btn.Invoke((Action)(() => btn.Update()));
            }
            catch (Exception)
            {
            }
            return btn.Text;
        }
        public string IsBtnInvokeEnabled(Button btn, bool str)
        {
            try
            {
                btn.Invoke(new Action(() =>
                {
                    btn.Enabled = str;

                }));
                btn.Invoke((Action)(() => btn.Update()));
            }
            catch (Exception)
            {
            }
            return btn.Text;
        }

        public string ddlInvoke(ComboBox combox, string str)
        {
            try
            {
                combox.Invoke(new Action(() =>
                {
                    combox.Text = str;

                }));
                combox.Invoke((Action)(() => combox.SelectedValue.ToString()));
                return combox.Text;
            }
            catch (Exception)
            {
            }
            //if (combox.InvokeRequired)
            //{
            //    combox.Invoke(new MethodInvoker(delegate() { _invoke(combox, str); }));
            //}
            //else
            //{
            //    combox.Text = str;
            //}
            return combox.Text;
        }
        public bool IsddlInvokeEnabled(ComboBox combox, bool str)
        {
            //try
            //{
            combox.Invoke(new Action(() =>
            {
                combox.Enabled = str;

            }));
            combox.Invoke((Action)(() => combox.Enabled = str));
            return combox.Enabled = str;
            //}
            //catch (Exception)
            //{
            //}
            //if (combox.InvokeRequired)
            //{
            //    combox.Invoke(new MethodInvoker(delegate() { _invoke(combox, str); }));
            //}
            //else
            //{
            //    combox.Text = str;
            //}
            //  return combox.Text;
        }
        public string IstxtboxInvokeEnabled(MetroFramework.Controls.MetroTextBox txt_, bool str)
        {
            try
            {
                txt_.Invoke(new Action(() =>
                {
                    txt_.Enabled = str;

                }));
                txt_.Invoke((Action)(() => txt_.Text.ToString()));
                return txt_.Text;
            }
            catch (Exception)
            {
            }
            //if (combox.InvokeRequired)
            //{
            //    combox.Invoke(new MethodInvoker(delegate() { _invoke(combox, str); }));
            //}
            //else
            //{
            //    combox.Text = str;
            //}
            return txt_.Text;
        }
        public string DatePickerInvoke(DateTimePicker date, string str)
        {
            try
            {
                //date.Invoke(new Action(() =>
                //{
                //    date.Text = str;

                //}));
                //date.Invoke((Action)(() => date.Update()));
            }
            catch (Exception)
            {
            }
            return date.Text;
        }
        public string ListViewInvoke(ListView lstview, string str, Control s)
        {
            try
            {
                lstview.Invoke(new Action(() =>
                {
                    lstview.Controls.Add(s);

                }));
                lstview.Invoke((Action)(() => lstview.Update()));
            }
            catch (Exception)
            {
            }
            return str;
        }
        public decimal NumericUpDownInvoke(NumericUpDown num, decimal nu)
        {
            try
            {
                if (num.InvokeRequired)
                {
                    num.Invoke(new MethodInvoker(delegate() { NumericUpDownInvoke(num, nu); }));
                }
                else
                {
                    nu = num.Value;
                }
            }
            catch (Exception)
            {
            }
            return nu;
        }
        public string txtboxInvoke(MetroFramework.Controls.MetroTextBox txt, string str)
        {
            try
            {
                //txt.Invoke(new Action(() =>
                //{
                //    txt.Text = str;

                //}));
                //txt.Invoke((Action)(() => txt.Update()));

                if (txt.InvokeRequired)
                {
                    txt.Invoke(new MethodInvoker(delegate() { txtboxInvoke(txt, str); }));
                }
                else
                {
                    txt.Text = str;
                }
            }
            catch (Exception)
            {
            }
            return txt.Text;
        }
        public bool IsRunQuery(string sel, string header, string message)
        {
            bool result = false;
            try
            {
                if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //--------
            com = new SqlCommand(sel, con);
            if (com.ExecuteNonQuery() > 0)
            {
                    result = true;
                Page.Classess_.ClsMessage.Success(header, message);
            }
            else
            {
                    result = false;
                
                Page.Classess_.ClsMessage.Error(header, Page.Classess_.ClsMessage.OPERATION_FAILD);

            }


            //--------
            if (con.State == ConnectionState.Open)
                con.Close();
            
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                result = false;
                Page.Classess_.ClsMessage.Error(header, ex.Message);
            }
            return result;
        }
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public bool IsInternetWorking()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
       
        public bool IsRunQuery(string sel)
        {
            bool status = false;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
                com = new SqlCommand(sel, con);
                if (com.ExecuteNonQuery() > 0)
                    status = true;
                else
                    status = false;



                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception )
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                status = false;

            }
            return status;
        }
        public string RunQuery_Scaler(string sel)
        {
            string status = string.Empty;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
                com = new SqlCommand(sel, con);
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    status= dr[0].ToString();
                }


                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                status= "Error";
                
            }
            return status;
        }
        public string Error_(string header, string message) { return ""; }
        //RadLabelElement

        public void lblForeColorChange(Label lbl, string msg, string order)
        {
            if (order == "t")
            {
                lbl.ForeColor = Color.Green;

                lbl.Text = msg;
            }
            if (order == "f")
            {
                lbl.Text = msg;
                lbl.ForeColor = Color.Red;
            }
            lbl.BackColor = Color.White;
        }
        public void ToolStatualbl_Forecolorchange(ToolStripLabel lbl, string msg, string order)
        {
            lbl.BackColor = Color.White;
            if (order == "t")
            {
                lbl.ForeColor = Color.Green;
                lbl.Text = msg;
            }
            if (order == "f")
            {
                lbl.Text = msg;
                lbl.ForeColor = Color.Red;
            }
        }
        
        public void info_(string str, string header)
        {
            MessageBox.Show(str, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool get_Combo_box_dt(string query, string display_, string value_, ComboBox combox)
        {

            //try
            //{

            //if (combox.Items.Count > 0)
            //{
            //    combox.Items.Clear();
            //}

            //--------
            DataTable dt = new DataTable();
            //dt.Columns.Add(value_, typeof(int));
            //dt.Columns.Add(display_, typeof(string));

            dt = dT_get(query);
            //  if (dt != null)
            //  {
            DataRow dr = dt.NewRow();

            //try
            //{

            dr[display_] = "----Select----";
            dr[value_] = "0";


            dt.Rows.InsertAt(dr, 0);


            combox.DisplayMember = display_;
            combox.ValueMember = value_;
            combox.DataSource = dt;
            // dt = null;
            //combox.SelectedValue = value_;
            // combox.Items.Insert(0, new ListItem(""));
            //}
            //catch (Exception)
            //{
            //    dr[value_] = "0";
            //}

            // Insert it into the 0th index

            //dt = null;
            // }    
            if (combox.Items.Count > 0)
            {

                combox.Enabled = true;
                combox.SelectedIndex = 0;
            }
            else
            {
                combox.Enabled = false;
            }

            //--------


            combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combox.AutoCompleteSource = AutoCompleteSource.ListItems;
            //}
            //catch (Exception)
            //{
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }

            //}
            return como;
        }
        List<string> lst = new List<string>();
        public void get_lstbox_ds(string query, ListBox lstbox)
        {

            try
            {
                if (lstbox.Items.Count > 0)
                {
                    lstbox.Items.Clear();
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
                com = new SqlCommand(query.Trim(), con);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    //if (combox.Items.Count > 0)
                    //{
                    //    combox.Items.Clear();
                    //}
                    //combox.Enabled = true;

                    while (dr.Read())
                    {
                        // lst.Add(dr[0].ToString());
                        lstbox.Items.Add(dr[0].ToString());
                        //   MessageBox.Show("Country " + dr[0].ToString());
                    }
                }
                else
                {
                    // combox.Enabled = false;
                    if (lstbox.Items.Count > 0)
                    {
                        lstbox.Items.Clear();
                    }
                }
                dr.Dispose();
                //if (lst.Count > 0)
                //{
                //    MessageBox.Show(lst.ToString());
                //}
                if (lstbox.Items.Count > 0)
                {

                    lstbox.Enabled = true;
                    //lstbox.SelectedIndex = 0;
                }
                else
                {
                    lstbox.Enabled = false;
                }
                //combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                //combox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //combox.AutoCompleteSource = AutoCompleteSource.ListItems;
                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

        }

        public bool get_Combox_only(string query, ComboBox combox)
        {

            try
            {
                combox.Invoke(new Action(() =>
                {
                    if (combox.Items.Count > 0)
                    {
                        combox.Items.Clear();
                    }
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //--------
                    com = new SqlCommand(query.Trim(), con);
                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        //if (combox.Items.Count > 0)
                        //{
                        //    combox.Items.Clear();
                        //}
                        //combox.Enabled = true;

                        while (dr.Read())
                        {
                            // lst.Add(dr[0].ToString());
                            combox.Items.Add(dr[0].ToString());
                            //   MessageBox.Show("Country " + dr[0].ToString());
                        }
                    }
                    else
                    {
                        // combox.Enabled = false;
                        if (combox.Items.Count > 0)
                        {
                            combox.Items.Clear();
                        }
                    }
                    dr.Dispose();
                    //if (lst.Count > 0)
                    //{
                    //    MessageBox.Show(lst.ToString());
                    //}
                    if (combox.Items.Count > 0)
                    {

                        combox.Enabled = true;
                        combox.SelectedIndex = 0;
                    }
                    else
                    {
                        combox.Enabled = false;
                    }
                    combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                    combox.AutoCompleteMode = AutoCompleteMode.Append;
                    combox.AutoCompleteSource = AutoCompleteSource.ListItems;
                    //--------
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }));
                combox.Invoke((Action)(() => combox.Update()));
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return como;
        }
        
        //RadDropDownList
        public bool get_Combo_box(string query, string display_, string value_, ComboBox combox)
        {

            try
            {

                DataSet ds = new DataSet();
                if (combox.Items.Count > 0)
                {
                    combox.Items.Clear();
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
                com = new SqlCommand(query, con);
                ds = dS_get(query);
                combox.DataSource = ds.Tables[0];
                combox.DisplayMember = display_;
                combox.ValueMember = value_;
                com.ExecuteNonQuery();

                if (combox.Items.Count > 0)
                {

                    combox.Enabled = true;
                    combox.SelectedIndex = 0;
                }
                else
                {
                    combox.Enabled = false;
                }

                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                combox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return como;
        }

        public void viewall(string sel, DataGridView dgv)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                adptr = new SqlDataAdapter(sel, con);


                DataSet dss = new DataSet();

                adptr.Fill(dss);
                //  dgv.ReadOnly = true;


                dataTable = new DataTable();
                adptr.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;

                dgv.DataSource = bindingSource;

                // if you want to hide Identity column
                dgv.Columns[0].Visible = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }




            }

            catch (Exception ec)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MessageBox.Show(ec.Message);

            }
        }
        public bool IsAvailable(string sel)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //--------
                com = new SqlCommand(sel, con);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {


                        ischck = true;
                    }
                }
                else
                {

                    ischck = false;
                }


                //--------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                ischck = false;
            }
            return ischck;
        }

        public DataTable dT_get(string sel)
        {
            DataTable dt = new DataTable();
            try
            {
                adptr = new SqlDataAdapter(sel, con);
            // SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            adptr.Fill(dt);
            return (dt!=null? dt:null);
        }
            catch (Exception)
            {
                //throw;
            }
            return dt;
        }
        public string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }
        public void IsnumberAllow(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as MetroFramework.Controls.MetroTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public void IsdecimalAllow(object sender, KeyEventArgs e)
        {


            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))

            //{
            //    e.Handled = true;
            //}

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as MetroFramework.Controls.MetroTextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
            if ((e.KeyCode != Keys.OemPeriod) || (e.KeyCode != Keys.Decimal))
            {
                // A non-numerical keystroke was pressed.
                // Set the flag to true and evaluate in KeyPress event.
                e.Handled = true;
            }
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void txt_decimal(MetroFramework.Controls.MetroTextBox txt)
        {
            double parsedValue;

            if (!double.TryParse(txt.Text, out parsedValue))
            {
                txt.Text = "";
            }
        }
     
        public void IsdecimalAllow(object sender, KeyPressEventArgs e)
        {
            //  float f = 0;
            MetroFramework.Controls.MetroTextBox txt = (sender as MetroFramework.Controls.MetroTextBox);
            //try
            //{
            //    f=(float)Convert.ToDouble(txt.Text);
            //    txt.Text = f.ToString();
            //}
            //catch (Exception)
            //{
            //    f = 0;
            //    txt.Text = "";

            //}
            double parsedValue;

            if (!double.TryParse(txt.Text, out parsedValue))
            {
                txt.Text = "";
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))

            //{
            //    e.Handled = true;
            //}

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as MetroFramework.Controls.MetroTextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
            //if((e.KeyCode != Keys.OemPeriod)||(e.KeyCode !=Keys.Decimal))
            //{
            //    // A non-numerical keystroke was pressed.
            //    // Set the flag to true and evaluate in KeyPress event.
            //    e.Handled = true;
            //}
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public bool IsOKForDecimalTextbox(char theCharacter, MetroFramework.Controls.MetroTextBox textBox)
        {
            // Only allow control characters, digits, plus and minus signs.
            // Only allow ONE plus sign.
            // Only allow ONE minus sign.
            // Only allow the plus or minus sign as the FIRST character.
            // Only allow ONE decimal point.
            // Do NOT allow decimal point or digits BEFORE any plus or minus sign.

            if (
                !char.IsControl(theCharacter)
                && !char.IsDigit(theCharacter)
                && (theCharacter != '.')
                && (theCharacter != '-')
                && (theCharacter != '+')
            )
            {
                // Then it is NOT a character we want allowed in the text box.
                return false;
            }



            // Only allow one decimal point.
            if (theCharacter == '.'
                && textBox.Text.IndexOf('.') > -1)
            {
                // Then there is already a decimal point in the text box.
                return false;
            }

            // Only allow one minus sign.
            if (theCharacter == '-'
                && textBox.Text.IndexOf('-') > -1)
            {
                // Then there is already a minus sign in the text box.
                return false;
            }

            // Only allow one plus sign.
            if (theCharacter == '+'
                && textBox.Text.IndexOf('+') > -1)
            {
                // Then there is already a plus sign in the text box.
                return false;
            }

            // Only allow one plus sign OR minus sign, but not both.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                &&
                (
                    (textBox.Text.IndexOf('-') > -1)
                    ||
                    (textBox.Text.IndexOf('+') > -1)
                )
                )
            {
                // Then the user is trying to enter a plus or minus sign and
                // there is ALREADY a plus or minus sign in the text box.
                return false;
            }

            // Only allow a minus or plus sign at the first character position.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                
                )
            {
                // Then the user is trying to enter a minus or plus sign at some position 
                // OTHER than the first character position in the text box.
                return false;
            }

            // Only allow digits and decimal point AFTER any existing plus or minus sign
            if (
                    (
                // Is digit or decimal point
                        char.IsDigit(theCharacter)
                        ||
                        (theCharacter == '.')
                    )
                    &&
                    (
                // A plus or minus sign EXISTS
                        (textBox.Text.IndexOf('-') > -1)
                        ||
                        (textBox.Text.IndexOf('+') > -1)
                    )
                    
                )
            {
                // Then the user is trying to enter a digit or decimal point in front of a minus or plus sign.
                return false;
            }

            // Otherwise the character is perfectly fine for a decimal value and the character
            // may indeed be placed at the current insertion position.
            return true;
        }
        public DataSet dS_get(string sel)
        {
            //try
            //{
            DataSet ds = new DataSet();

            adptr = new SqlDataAdapter(sel, con);
            // SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            adptr.Fill(ds);
            return ds;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        #endregion
        private Color _borderColor = Color.White;
        #region Get windows Product Code
        [DllImportAttribute("HardwareIDExtractorC.dll")]
        public static extern String GetIDESerialNumber(byte DriveNumber);
        public string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }
        #endregion

        public Color BorderColor
        {
            get { return this._borderColor; }
            set { this._borderColor = value; }
        }
        public  List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {

                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public  T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border


                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
        public void GP_bdr(object sender, PaintEventArgs e)
        {

            GroupBox box = sender as GroupBox;
            e.Graphics.Clear(box.BackColor = Color.White);
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);

        }
        public float float_(MetroFramework.Controls.MetroTextBox txt)
        {
           
            try
            {
                f_txt = (float)Convert.ToDouble(txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                f_txt = 0;
            }
            txt.Text = f_txt.ToString();
            return f_txt;
        }
    }
}
