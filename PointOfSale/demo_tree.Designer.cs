namespace PointOfSale
{
    partial class demo_tree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node3");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lbl_ = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Node4";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Node1";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Node2";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Node0";
            treeNode5.Name = "Node3";
            treeNode5.Text = "Node3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(491, 64);
            this.treeView1.TabIndex = 0;
            // 
            // lbl_
            // 
            this.lbl_.AutoSize = true;
            this.lbl_.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_.Location = new System.Drawing.Point(71, 122);
            this.lbl_.Name = "lbl_";
            this.lbl_.Size = new System.Drawing.Size(51, 20);
            this.lbl_.TabIndex = 1;
            this.lbl_.Text = "label1";
            // 
            // demo_tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 316);
            this.Controls.Add(this.lbl_);
            this.Controls.Add(this.treeView1);
            this.Name = "demo_tree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "demo_tree";
            this.Load += new System.EventHandler(this.demo_tree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lbl_;
    }
}