using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale.Page
{
    public partial class Setting : MetroFramework.Controls.MetroUserControl
    {

        public Setting()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void synsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page._setting.frmEmployee s = new Page._setting.frmEmployee();
            if (splitContainer1.Panel2.Controls.Count > 0)
            {

                splitContainer1.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(s);
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page._setting.frmAccounts s = new Page._setting.frmAccounts();
            if (splitContainer1.Panel2.Controls.Count > 0)
            {

                splitContainer1.Panel2.Controls.Clear();
            }
            s.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(s);
        }

      

       
    }
}
