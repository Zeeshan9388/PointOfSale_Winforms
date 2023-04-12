using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using KeepAutomation.Barcode.Bean;
using System.Runtime.InteropServices;
using System.Globalization;

namespace PointOfSale.Page
{
    public partial class Fo1 : Form
    {
        BarCode barcode = new BarCode();
        Image img_barcode;
        Category c = new Category();
        string path = "D:\\Barcode_\\";
        public Fo1()
        {
            InitializeComponent();
            SlidePanel.Height = btn_sale.Height;
            SlidePanel.Top = btn_sale.Top;
            chc();
          //  al();
            //  c.BringToFront();
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
            dt = dd.dT_get("select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID ");

             da.items.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                 DataRow dr_ = da.items.NewRow();
                 dr_["Id"] = dr[0].ToString();
                 dr_["catname"] = dr[1].ToString();
                 dr_["items"] = dr[2].ToString();
                 da.items.Rows.Add(dr_);
        
                combox_chcking.Items.Add(dr[0].ToString() + "               " + dr[1].ToString() + "               " + dr[2].ToString());
            }
           // radMultiColumnComboBox1.DataBindings = da.items[0];
            //radMultiColumnComboBox1.MultiColumnComboBoxElement.Columns = "";

        }
        public void chc_()
        {

            if (txt_content.TextLength < 1)
            {
                lstbox.Hide();
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
                    if (Convert.ToInt32(txt_content.Text)==Int32.Parse(txt_content.Text))
                    {
                        sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID where i.UItemID= " + Convert.ToInt32(txt_content.Text) + "";
                   
                    }
                    else
                    {
                        sel = "select i.ItemID,c.Catname,i.UItems_ from CatName as c inner join UItems_ as i on i.NID=c.NID where i.UItems_ like '%" + txt_content.Text + "%'"; 
                   
                    }

                    dt = dd.dT_get(sel);





                    foreach (DataRow dr in dt.Rows)
                    {

                        lstbox.Items.Add(dr[0].ToString() + "               " + dr[1].ToString() + "               " + dr[2].ToString());
                    }
                    lstbox.Show();
                }
                catch (Exception)
                { }
            }
        }
        private void Fo1_Load(object sender, EventArgs e)
        {

            //SlidePanel.Height = btn_sale.Height;
            //SlidePanel.Top = btn_sale.Top;
           // c.BringToFront();
        }
        public void generate_(string lbl_invoice)
        {
            //if ((Convert.ToInt32(lbl_invoice)) > 0)
            //{
                // count = Convert.ToInt32(dd.RunQuery_Scaler("select isnull(count(BarcodeID),0) from tbl_barcode"));

                barcode.Symbology = KeepAutomation.Barcode.Symbology.UPCA;

                barcode.CodeToEncode = lbl_invoice;
                barcode.X = 1;
                barcode.Y = 10;
                barcode.BarCodeWidth = 20;
                barcode.BarCodeHeight = 40;
               
                barcode.DisplayText = true;
                barcode.DisplayStartStop = true;
                barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
                barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
                barcode.DPI = 72;
                barcode.ImageFormat = ImageFormat.Bmp;
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(path + lbl_invoice + ".png"))
                {
                    barcode.generateBarcodeToImageFile(path + lbl_invoice + ".png");
                }
                //File.WriteAllText(Path.Combine(path + getbarcode, path + getbarcode + ".png"), pbbox.Image);
                pictureBox1.Image = Image.FromFile(path + lbl_invoice + ".png");
                img_barcode = Image.FromFile(path + lbl_invoice + ".png");


            //}
            //else
            //{
            //    //dd.info_("Invaild Barcode Pin!", "Invaild Barcode Pin", "err");
            //}
        }
        private void txt_content_TextChanged(object sender, EventArgs e)
        {
            lbl_rows.Text = (txt_content.TextLength).ToString();
            chc_();
        }
        public void Progressupgrade(object progress)
        {
            progressbar1.Invoke((MethodInvoker)delegate { progressbar1.updateprogress(Convert.ToInt32(progress)); });
        }
        private void btn_sale_Click(object sender, EventArgs e)
        {
            txt_value.Text = String.Format("{0:d11}", (DateTime.Now.Ticks / 10) % 1000000000);
            lbl_lenght.Text = txt_value.TextLength.ToString();
            String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            //progressbar1.updateprogress(20);

            for (int i = 0; i <= 100; i++)
            {
                progressbar1.updateprogress(i / 100 * 20);
                new Thread(new System.Threading.ParameterizedThreadStart(this.Progressupgrade)).Start(i);
                Progressupgrade(Convert.ToInt32(i));
                Thread.Sleep(100);
            }
            //btn_chck(btn_sale, "Sale");
            //SlidePanel.Height = btn_sale.Height;
            //SlidePanel.Top = btn_sale.Top;
           // c.BringToFront();
        }
        public void btn_chck(Button btnn,string btn)
        {
            
            if (btn == "Sale")
            {
                btn_sale.BackColor = Color.Maroon;
                btn_sale.ForeColor = Color.Red;

                //------------------------
                btn_edit.BackColor = Color.Red;
                btn_edit.ForeColor = Color.White;
                //-----------------------
                btn_del.BackColor = Color.Red;
                btn_del.ForeColor = Color.White;
            }
            if (btn == "Edit")
            {
                btn_edit.BackColor = Color.Maroon;
                btn_edit.ForeColor = Color.Red;
             

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_del.BackColor = Color.Red;
                btn_del.ForeColor = Color.White;
            }
            if (btn == "Del")
            {
                btn_del.BackColor = Color.Maroon;
                btn_del.ForeColor = Color.Red;
               

                //------------------------
                btn_sale.BackColor = Color.Red;
                btn_sale.ForeColor = Color.White;
                //-----------------------
                btn_edit.BackColor = Color.Red;
                btn_edit.ForeColor = Color.White;

            }

        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_chck(btn_edit, "Edit");
           
            SlidePanel.Height = btn_edit.Height;
            SlidePanel.Top = btn_edit.Top;
          //  c.BringToFront();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            btn_chck(btn_del, "Del");
           
            SlidePanel.Height = btn_del.Height;
            SlidePanel.Top = btn_del.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string digits14 = Math.Round(r.NextDouble() * 1e+11).ToString(CultureInfo.InvariantCulture).PadLeft(11, '1');
            textBox1.Text = digits14; 
            SlidePanel.Height = button4.Height;
            SlidePanel.Top = button4.Top;


            barcode.Symbology = KeepAutomation.Barcode.Symbology.Code39;
            barcode.CodeToEncode = "111222333";
            barcode.ChecksumEnabled = true;
            barcode.X = 1;
            barcode.Y = 50;
            barcode.BarCodeWidth = 100;
            barcode.BarCodeHeight = 70;
            barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree90;
            barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            barcode.DPI = 72;
            barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Gif;
            barcode.generateBarcodeToImageFile("D:\\abc" + a.ToString() + ".gif");
            img_barcode = Image.FromFile("D:\\abc" + a.ToString() + ".png");
            var defaultPrinterName = printDocument1.PrinterSettings.PrinterName;
            printDocument1.PrinterSettings.PrinterName = printDocument1.PrinterSettings.PrinterName;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();

            //if (printDocument1.PrinterSettings.IsValid)
            //{
            //    SetDefaultPrinter(printDocument1.PrinterSettings.PrinterName);

            //    // printPreviewControl1.Document = printDocument1;
            //    printPreviewDialog1.Document = printDocument1;
            //    printPreviewDialog1.Show();
            //    // printDocument1.Print();
            //    // panel2.Show();
            //    SetDefaultPrinter(defaultPrinterName);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = button5.Height;
            SlidePanel.Top = button5.Top;

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barcode = "9897656";

            Bitmap bitm = new Bitmap(barcode.Length * 40, 150);
            using (Graphics graphic = Graphics.FromImage(bitm))
            {

                //IDAutomationHC39M
                Font newfont = new Font("IDAutomationHC39M", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, bitm.Width, bitm.Height);
                graphic.DrawString("Product - Size ", new Font("Courier New", 9, FontStyle.Bold), black, 0,0);
                graphic.DrawString("" + barcode + "", newfont, black, 0,10);
               
                //Offset = Offset + 20;

            }

            using (MemoryStream Mmst = new MemoryStream())
            {


                bitm.Save("ms", ImageFormat.Jpeg);
                pictureBox1.Image = bitm;
                pictureBox1.Width = bitm.Width;
                pictureBox1.Height = bitm.Height;


            }
        }
        int a = 0;
        string descrip = "Software Developed by: MZR Softwares\n 0335 1206586 - www.mzrsoftware.com";
        [DllImport("Winspool.drv")]
        private static extern bool SetDefaultPrinter(string printerName);
        private void button6_Click(object sender, EventArgs e)
        {

            
            barcode.Symbology = KeepAutomation.Barcode.Symbology.UPCA;
            //barcode.CodeToEncode = "12345678911";
            //barcode.X = 1;
            //barcode.Y = 10;
            //barcode.TopMargin = 10;
            //barcode.BottomMargin = 10;
            //barcode.LeftMargin = 10;
            //barcode.RightMargin = 10;
            //barcode.DisplayText = true;
            //barcode.DisplayStartStop = true;
            //barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            //barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
            //barcode.DPI = 72;
            //barcode.ImageFormat = ImageFormat.Bmp;
            //barcode.BarCodeWidth = 10;
            //BarCode barcode = new BarCode();
           // barcode.Symbology = KeepAutomation.Barcode.Symbology.UPCA;
            barcode.CodeToEncode = "84325785412";
            
            barcode.X = 1;
            barcode.Y = 10;
            barcode.BarCodeWidth = 20;
            barcode.BarCodeHeight = 40;
           // barcode.DisplayText = true;
           // barcode.DisplayStartStop = true;
            barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
            barcode.DPI = 72;
            //barcode.DPI = 60;
            
            barcode.ImageFormat = ImageFormat.Bmp;
            //barcode.generateBarcodeToImageFile("C://barcode-upca-csharp.bmp");
            //barcode.BarCodeHeight = 40;
            barcode.generateBarcodeToImageFile("D:\\abc"+a.ToString()+".png");
            img_barcode = Image.FromFile("D:\\abc" + a.ToString() + ".png");
            pictureBox1.Image = Image.FromFile("D:\\abc" + a.ToString() + ".png");

            //BarCode code128 = new BarCode();
            //code128.Symbology = KeepAutomation.Barcode.Symbology.CodeAuto;
            //code128.CodeToEncode = "128128128";
            //code128.generateBarcodeToImageFile("C://code128.png");
            generate_bar_();
            var defaultPrinterName = printDocument1.PrinterSettings.PrinterName;
            printDocument1.PrinterSettings.PrinterName = printDocument1.PrinterSettings.PrinterName;

            if (printDocument1.PrinterSettings.IsValid)
            {
                SetDefaultPrinter(printDocument1.PrinterSettings.PrinterName);

               // printPreviewControl1.Document = printDocument1;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.Show();
               // printDocument1.Print();
                // panel2.Show();
                SetDefaultPrinter(defaultPrinterName);
            }
            a = a + 1;
        }
        public void generate_bar_()
        {
            string barcode = txt_value.Text;

            Bitmap bitm = new Bitmap(barcode.Length * 45, 160);
            
            using (Graphics graphic = Graphics.FromImage(bitm))
            {


                Font newfont = new Font("IDAutomationHC39M", 20);
                PointF point = new PointF(1f, 1f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0,10,20);
                graphic.DrawString("*" + barcode + "*", newfont, black, point);


            }

            using (MemoryStream Mmst = new MemoryStream())
            {


                bitm.Save("ms", ImageFormat.Jpeg);
                pictureBox1.Image = bitm;
                //pictureBox1.Width = 40;
                //pictureBox1.Height = bitm.Height;



            } 
        }
        method dd = new method();
        DataTable dt = null;
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region Sale Print in customer printer btn
            
            generate_("53253247634");
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 10);
            float fontHeight = font.GetHeight();
            
            int startY = 10;
            int Offset = 40;

           
               
                graphics.DrawString("Product - Size", new Font("Arial", 8),
                         new SolidBrush(Color.Black), 10, startY + Offset);
                Offset = Offset + 20;
                
                graphics.DrawImage(img_barcode, 0, startY + Offset);
                Offset = Offset + 20;
                Offset = Offset + 20;
                Offset = Offset + 20;
                Offset = Offset + 20;
                graphics.DrawString("Barcode without dll", new Font("Arial", 8),
                             new SolidBrush(Color.Black), 10, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawImage(pictureBox1.Image, 0, startY + Offset);
                
                Offset = Offset + 20;
                Offset = Offset + 20;
                Offset = Offset + 20;
                Offset = Offset + 20;
                graphics.DrawString(descrip, new Font("Arial", 8),
                         new SolidBrush(Color.Black), 10, startY + Offset);
                Offset = Offset + 20;
            
            //lbl_order_status.Text = saleid + " This Order has been Paid and done  ";
            #endregion
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.TextLength.ToString();
        }

        private void combox_chcking_SelectedIndexChanged(object sender, EventArgs e)
        {
            chc_();
        }
    }
}
