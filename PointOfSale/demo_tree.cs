using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class demo_tree : Form
    {
        method dd = new method();
        DataTable dt = null;
        TreeNode tn;
        public void tr()
        {
            try
            {
                
                dt = dd.dT_get("select * from catname");
                foreach (DataRow dr in dt.Rows)
                {
                    tn = new TreeNode(dr["UItems_"].ToString());
                    dt = dd.dT_get("select * from UItems_ where NID=" + dr["NID"].ToString() + "");

                    
                    foreach (DataRow drChild in dt.Rows)
                    {
                       tn = new TreeNode(dr["UItems_"].ToString());
                        tn.Nodes.Add(drChild["UItems_"].ToString());
                    }
                    treeView1.Nodes.Add(tn);
                }
                treeView1.Nodes.Add(tn);
                //TreeNode t = new TreeNode();
                //t.TreeView.Nodes.Add("Apni buses.com");
                //t.TreeView.Nodes.Add("Apni buses.com","Apni buses",1,1);
                //treeView1.Nodes.Add(t);
                //treeView1.Nodes.Add("Sec A", "Sec B ");

                //treeView1.Nodes.Add("Class C");

                //treeView1.Nodes.Add("Class D");
            }
            catch (Exception)
            { }
        }
        //void CreateNode(TreeNode node)
        //{
        //    DataSet ds = dd.dS_get("Select topicid, name from Category where Parent_ID =" + node.+"");
        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        return;
        //    }
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        TreeNode tnode = new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
        //        tnode.SelectAction = TreeNodeSelectAction.Expand;
        //        node.ChildNodes.Add(tnode);
        //        CreateNode(tnode);
        //    }

        //}
        public demo_tree()
        {
            InitializeComponent();
        }

        private void demo_tree_Load(object sender, EventArgs e)
        {
            //tr();
            lbl_.Text = "Search by:    ";
            DataTable dt = dd.dT_get("select * from catname");
            foreach (DataRow dr in dt.Rows)
            {
                lbl_.Text +=dr["Catname"].ToString()+"    /    ";
            }
            //this.PopulateTreeView(dt, 0,null);
        }
        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["Catname"].ToString(),
                    Tag = row["NID"]
                };
                if (parentId == 0)
                {
                    treeView1.Nodes.Add(child);
                    DataTable dtChild = dd.dT_get("select * from UItems_ where NID= " + child.Tag + "");
                    PopulateTreeView(dtChild, Convert.ToInt32(child.Tag), child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
            }
            treeView1.Nodes.Add(treeNode);
        }
    }
}
