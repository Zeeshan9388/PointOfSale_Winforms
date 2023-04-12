
using System.Windows.Forms;

namespace PointOfSale.Page.Classess_ 
{
    public  class ClsMessage  : MetroFramework.Forms.MetroForm
    {

        public const string DevelopedBy= "Software Developed by: MZR Software\n  www.mzrsoftware.com";
        #region Alert Box
        //--- Success
        public static void Success(string header, string message)
        {
            MetroFramework.MetroMessageBox.Show(Dashboard.ActiveForm, message, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static int Question(string header, string message)
        {
           
            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(Dashboard.ActiveForm,  header,message, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                return 1;
            }
            else { return 0; }
            }

        //--- Error
        public static void Error(string header, string message) => MetroFramework.MetroMessageBox.Show(Dashboard.ActiveForm,  message, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //--- Already
        public static void Already(string header, string message) => MetroFramework.MetroMessageBox.Show(Dashboard.ActiveForm, message, header, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        #endregion
        #region Button Text
        public const string BtnSAVED = "Save";
        public const string BtnEDIT = "Edit";
        public const string lblROW = "Rows: ";
        #endregion
        #region Category Message
        public const string CategoryHeader = "Category";
        public const string CategorySave = "New record has been saved.";
        public const string CategoryDelete = "Select record has been deleted";
        public const string CategoryError = "Category has an error ";
        public const string CategoryAlready = "Already Category Exists ";
        #endregion
        #region General
        public const string OPERATION_FAILD = "Operation failed !";
        #endregion
        #region Items
        public const string ItemsHeader = "Products ";
        public const string ItemsSaved = "New product has been saved.";
        public const string ItemsAlready = "Already Exists Product";
        public const string ItemsError = "Product Error: ";
        public const string ItemsDeleted = "Selected product has been deleted.";
        public const string ItemsUpdated = "Selected product has been updated.";
        #endregion
        #region Items Size
        public const string SizeHeader = " Size ";
        public const string SizeSaved = "New  Size has been saved.";
        public const string SizeAlready = "Already Exists  Size";
        public const string SizeError = " Size Error: ";
        public const string SizeDeleted = "Selected size has been deleted.";
        public const string SizeUpdated = "Selected size has been updated.";
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClsMessage
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "ClsMessage";
            this.Load += new System.EventHandler(this.ClsMessage_Load);
            this.ResumeLayout(false);

        }

        private void ClsMessage_Load(object sender, System.EventArgs e)
        {

        }
    }
}
