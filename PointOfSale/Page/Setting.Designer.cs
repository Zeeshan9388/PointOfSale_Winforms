namespace PointOfSale.Page
{
    partial class Setting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new Telerik.WinControls.UI.RadMenu();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radMenuItemAccount = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemReport = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemSetting = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1365, 775);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemAccount,
            this.radMenuItemReport,
            this.radMenuItemSetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1365, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ThemeName = "ControlDefault";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            this.accountsToolStripMenuItem.Click += new System.EventHandler(this.accountsToolStripMenuItem_Click);
            // 
            // radMenuItemAccount
            // 
            this.radMenuItemAccount.Image = global::PointOfSale.Properties.Resources.accounts;
            this.radMenuItemAccount.Name = "radMenuItemAccount";
            this.radMenuItemAccount.Text = "Accounts";
            this.radMenuItemAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radMenuItemReport
            // 
            this.radMenuItemReport.Image = global::PointOfSale.Properties.Resources.invoice;
            this.radMenuItemReport.Name = "radMenuItemReport";
            this.radMenuItemReport.Text = "Reports";
            this.radMenuItemReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radMenuItemSetting
            // 
            this.radMenuItemSetting.Image = global::PointOfSale.Properties.Resources.Login;
            this.radMenuItemSetting.Name = "radMenuItemSetting";
            this.radMenuItemSetting.Text = "Change Password";
            this.radMenuItemSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Setting";
            this.Size = new System.Drawing.Size(1365, 775);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuStrip1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadMenu menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAccount;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemReport;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemSetting;
    }
}
