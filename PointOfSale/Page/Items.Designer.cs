namespace PointOfSale.Page
{
    partial class Items
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_clr = new MetroFramework.Controls.MetroButton();
            this.btn_add = new MetroFramework.Controls.MetroButton();
            this.ddl_Category = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_rows = new System.Windows.Forms.Label();
            this.txt_item = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Product = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_clr
            // 
            this.btn_clr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clr.BackColor = System.Drawing.Color.White;
            this.btn_clr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_clr.ForeColor = System.Drawing.Color.Red;
            this.btn_clr.Location = new System.Drawing.Point(998, 574);
            this.btn_clr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(112, 38);
            this.btn_clr.TabIndex = 42;
            this.btn_clr.Text = "Clear";
            this.btn_clr.UseSelectable = true;
            this.btn_clr.Click += new System.EventHandler(this.btn_clr_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.ForeColor = System.Drawing.Color.Red;
            this.btn_add.Location = new System.Drawing.Point(878, 574);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(112, 38);
            this.btn_add.TabIndex = 39;
            this.btn_add.Text = "+ Add";
            this.btn_add.UseSelectable = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // ddl_Category
            // 
            this.ddl_Category.FormattingEnabled = true;
            this.ddl_Category.ItemHeight = 23;
            this.ddl_Category.Location = new System.Drawing.Point(34, 117);
            this.ddl_Category.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_Category.Name = "ddl_Category";
            this.ddl_Category.Size = new System.Drawing.Size(246, 29);
            this.ddl_Category.TabIndex = 38;
            this.ddl_Category.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 55);
            this.label2.TabIndex = 37;
            this.label2.Text = "Product ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Select Category";
            // 
            // lbl_rows
            // 
            this.lbl_rows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_rows.AutoSize = true;
            this.lbl_rows.Location = new System.Drawing.Point(30, 574);
            this.lbl_rows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_rows.Name = "lbl_rows";
            this.lbl_rows.Size = new System.Drawing.Size(62, 20);
            this.lbl_rows.TabIndex = 35;
            this.lbl_rows.Text = "Rows 0";
            // 
            // txt_item
            // 
            this.txt_item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_item.Lines = new string[0];
            this.txt_item.Location = new System.Drawing.Point(291, 118);
            this.txt_item.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_item.MaxLength = 32767;
            this.txt_item.Name = "txt_item";
            this.txt_item.PasswordChar = '\0';
            this.txt_item.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_item.SelectedText = "";
            this.txt_item.Size = new System.Drawing.Size(819, 31);
            this.txt_item.TabIndex = 33;
            this.txt_item.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Enter Product Name";
            // 
            // dgv_Product
            // 
            this.dgv_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Product.Location = new System.Drawing.Point(34, 157);
            // 
            // dgv_Product
            // 
            this.dgv_Product.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgv_Product.Name = "dgv_Product";
            this.dgv_Product.Size = new System.Drawing.Size(1076, 386);
            this.dgv_Product.TabIndex = 43;
            this.dgv_Product.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dgv_Product_CellFormatting);
            this.dgv_Product.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgv_Product_CommandCellClick);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgv_Product);
            this.Controls.Add(this.btn_clr);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.ddl_Category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_rows);
            this.Controls.Add(this.txt_item);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Items";
            this.Size = new System.Drawing.Size(1144, 634);
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.UseStyleColors = true;
            this.Load += new System.EventHandler(this.Items_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_clr;
        private MetroFramework.Controls.MetroButton btn_add;
        private MetroFramework.Controls.MetroComboBox ddl_Category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_rows;
        private MetroFramework.Controls.MetroTextBox txt_item;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView dgv_Product;
    }
}
