namespace PointOfSale.Page
{
    partial class demo
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
            this.lstbox = new System.Windows.Forms.ListBox();
            this.combox_chcking = new System.Windows.Forms.ComboBox();
            this.txt_content = new System.Windows.Forms.TextBox();
            this.lbl_rows = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstbox
            // 
            this.lstbox.FormattingEnabled = true;
            this.lstbox.Location = new System.Drawing.Point(12, 44);
            this.lstbox.Name = "lstbox";
            this.lstbox.Size = new System.Drawing.Size(262, 199);
            this.lstbox.TabIndex = 17;
            // 
            // combox_chcking
            // 
            this.combox_chcking.AllowDrop = true;
            this.combox_chcking.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combox_chcking.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combox_chcking.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.combox_chcking.FormattingEnabled = true;
            this.combox_chcking.Location = new System.Drawing.Point(347, 12);
            this.combox_chcking.Name = "combox_chcking";
            this.combox_chcking.Size = new System.Drawing.Size(262, 21);
            this.combox_chcking.TabIndex = 16;
            this.combox_chcking.SelectedIndexChanged += new System.EventHandler(this.combox_chcking_SelectedIndexChanged);
            // 
            // txt_content
            // 
            this.txt_content.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_content.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_content.Location = new System.Drawing.Point(12, 12);
            this.txt_content.Multiline = true;
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(262, 26);
            this.txt_content.TabIndex = 15;
            this.txt_content.TextChanged += new System.EventHandler(this.txt_content_TextChanged);
            // 
            // lbl_rows
            // 
            this.lbl_rows.AutoSize = true;
            this.lbl_rows.Location = new System.Drawing.Point(12, 256);
            this.lbl_rows.Name = "lbl_rows";
            this.lbl_rows.Size = new System.Drawing.Size(35, 13);
            this.lbl_rows.TabIndex = 18;
            this.lbl_rows.Text = "label1";
            // 
            // demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 278);
            this.Controls.Add(this.lbl_rows);
            this.Controls.Add(this.lstbox);
            this.Controls.Add(this.combox_chcking);
            this.Controls.Add(this.txt_content);
            this.Name = "demo";
            this.Text = "demo";
            this.Load += new System.EventHandler(this.demo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbox;
        private System.Windows.Forms.ComboBox combox_chcking;
        private System.Windows.Forms.TextBox txt_content;
        private System.Windows.Forms.Label lbl_rows;
    }
}