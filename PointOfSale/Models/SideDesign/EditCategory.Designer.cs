namespace PointOfSale.Models.SideDesign
{
    partial class EditCategory
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new MetroFramework.Controls.MetroButton();
            this.txtBoxCategory = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_add.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btn_add.ForeColor = System.Drawing.Color.Red;
            this.btn_add.Location = new System.Drawing.Point(372, 149);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(112, 40);
            this.btn_add.TabIndex = 25;
            this.btn_add.Text = "+ Add";
            this.btn_add.UseSelectable = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txtBoxCategory
            // 
            this.txtBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCategory.Lines = new string[0];
            this.txtBoxCategory.Location = new System.Drawing.Point(103, 113);
            this.txtBoxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxCategory.MaxLength = 32767;
            this.txtBoxCategory.Name = "txtBoxCategory";
            this.txtBoxCategory.PasswordChar = '\0';
            this.txtBoxCategory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBoxCategory.SelectedText = "";
            this.txtBoxCategory.Size = new System.Drawing.Size(381, 26);
            this.txtBoxCategory.TabIndex = 27;
            this.txtBoxCategory.UseSelectable = true;
            // 
            // EditCategory
            // 
            this.AcceptButton = this.btn_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 214);
            this.Controls.Add(this.txtBoxCategory);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCategory";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Category";
            this.Load += new System.EventHandler(this.EditCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btn_add;
        private MetroFramework.Controls.MetroTextBox txtBoxCategory;
    }
}