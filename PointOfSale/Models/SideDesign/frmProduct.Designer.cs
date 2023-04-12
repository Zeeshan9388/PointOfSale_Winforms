namespace PointOfSale.Models.SideDesign
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ddl_Category = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_item = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // ddl_Category
            // 
            this.ddl_Category.FormattingEnabled = true;
            this.ddl_Category.ItemHeight = 23;
            this.ddl_Category.Location = new System.Drawing.Point(35, 130);
            this.ddl_Category.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_Category.Name = "ddl_Category";
            this.ddl_Category.Size = new System.Drawing.Size(246, 29);
            this.ddl_Category.TabIndex = 42;
            this.ddl_Category.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Select Category";
            // 
            // txt_item
            // 
            this.txt_item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_item.Lines = new string[0];
            this.txt_item.Location = new System.Drawing.Point(297, 129);
            this.txt_item.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_item.MaxLength = 32767;
            this.txt_item.Name = "txt_item";
            this.txt_item.PasswordChar = '\0';
            this.txt_item.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_item.SelectedText = "";
            this.txt_item.Size = new System.Drawing.Size(466, 31);
            this.txt_item.TabIndex = 40;
            this.txt_item.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Enter Product Name";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.ForeColor = System.Drawing.Color.Red;
            this.btn_add.Location = new System.Drawing.Point(621, 195);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(112, 38);
            this.btn_add.TabIndex = 43;
            this.btn_add.Text = "+ Add";
            this.btn_add.UseSelectable = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // frmProduct
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 258);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.ddl_Category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_item);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduct";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Product ";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ddl_Category;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txt_item;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btn_add;
    }
}