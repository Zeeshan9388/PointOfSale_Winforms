namespace PointOfSale.Page
{
    partial class Category
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
            this.lbl_rows = new System.Windows.Forms.Label();
            this.txtBoxCategory = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCategory = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_clr
            // 
            this.btn_clr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clr.BackColor = System.Drawing.Color.Transparent;
            this.btn_clr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_clr.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_clr.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_clr.ForeColor = System.Drawing.Color.Red;
            this.btn_clr.Location = new System.Drawing.Point(748, 635);
            this.btn_clr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(112, 40);
            this.btn_clr.TabIndex = 24;
            this.btn_clr.Text = "Clear";
            this.btn_clr.UseSelectable = true;
            this.btn_clr.Click += new System.EventHandler(this.btn_clr_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_add.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_add.ForeColor = System.Drawing.Color.Red;
            this.btn_add.Location = new System.Drawing.Point(628, 635);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(112, 40);
            this.btn_add.TabIndex = 21;
            this.btn_add.Text = "+ Add";
            this.btn_add.UseSelectable = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_rows
            // 
            this.lbl_rows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_rows.AutoSize = true;
            this.lbl_rows.Location = new System.Drawing.Point(21, 635);
            this.lbl_rows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_rows.Name = "lbl_rows";
            this.lbl_rows.Size = new System.Drawing.Size(62, 20);
            this.lbl_rows.TabIndex = 20;
            this.lbl_rows.Text = "Rows 0";
            // 
            // txtBoxCategory
            // 
            this.txtBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCategory.Lines = new string[0];
            this.txtBoxCategory.Location = new System.Drawing.Point(26, 142);
            this.txtBoxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxCategory.MaxLength = 32767;
            this.txtBoxCategory.Name = "txtBoxCategory";
            this.txtBoxCategory.PasswordChar = '\0';
            this.txtBoxCategory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxCategory.SelectedText = "";
            this.txtBoxCategory.Size = new System.Drawing.Size(832, 26);
            this.txtBoxCategory.TabIndex = 18;
            this.txtBoxCategory.UseSelectable = true;
            this.txtBoxCategory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxCategory_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 55);
            this.label2.TabIndex = 16;
            this.label2.Text = "Category ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Enter Product name";
            // 
            // dgvCategory
            // 
            this.dgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategory.Location = new System.Drawing.Point(25, 176);
            // 
            // dgvCategory
            // 
            this.dgvCategory.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.Size = new System.Drawing.Size(833, 451);
            this.dgvCategory.TabIndex = 25;
            this.dgvCategory.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.dgvCategory_CellFormatting);
            this.dgvCategory.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.dgvCategory_CurrentRowChanged);
            this.dgvCategory.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.dgvCategory_CurrentRowChanging);
            this.dgvCategory.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.dgvCategory_CommandCellClick);
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvCategory);
            this.Controls.Add(this.btn_clr);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lbl_rows);
            this.Controls.Add(this.txtBoxCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Category";
            this.Size = new System.Drawing.Size(876, 703);
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btn_add;
        private System.Windows.Forms.Label lbl_rows;
        private MetroFramework.Controls.MetroTextBox txtBoxCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadGridView dgvCategory;
        public MetroFramework.Controls.MetroButton btn_clr;
    }
}
