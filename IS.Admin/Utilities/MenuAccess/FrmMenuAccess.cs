using IS.Admin.Model;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Admin.Setup
{
    public partial class FrmMenuAccess : BaseForm
    {
        ISFactory factory = new ISFactory();
        MenuStrip _MenuStrip { get; set; }
        public FrmMenuAccess(MenuStrip mstrip)
        {
            InitializeComponent();
            _MenuStrip = mstrip;
            this.ActiveControl = cboName;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMenuAccess_Load(object sender, EventArgs e)
        {
            var response = factory.AdministratorsRepository.Find(null).Where(x => x.Loginname.ToUpper() != "ADMIN").ToList();
            cboName.DataSource = response;
            cboName.DisplayMember = "Fullname";
            cboName.ValueMember = "AdminId";

           loadTreeView();
        }

        private void loadTreeView()
        {
            if (cboName.SelectedValue != null)
            {
                treeView1.Nodes.Clear();
                var MenuAccess = factory.MenuAccessRepository.GetListWithAdminId(cboName.SelectedValue.ToString());

                int index1 = 0;
                int index2 = 0;
                foreach (ToolStripMenuItem item in _MenuStrip.Items)
                {
                    if (MenuAccess.Where(x => x.MenuName == item.Name).Count() > 0)
                    {
                        treeView1.Nodes.Add(item.Text).Name = item.Name;
                        treeView1.Nodes[item.Name].Text = string.IsNullOrEmpty(item.Text) ? "-" : item.Text;
                        treeView1.Nodes[item.Name].Checked = true;
                    }
                    else
                    {
                        treeView1.Nodes.Add(item.Text).Name = item.Name;
                        treeView1.Nodes[item.Name].Text = string.IsNullOrEmpty(item.Text) ? "-" : item.Text;
                    }

                    foreach (ToolStripItem sub in item.DropDownItems)
                    {
                        if (MenuAccess.Where(x => x.MenuName == sub.Name).Count() > 0)
                        {
                            treeView1.Nodes[index1].Nodes.Add(sub.Text).Name = sub.Name;
                            treeView1.Nodes[index1].Nodes[sub.Name].Text = string.IsNullOrEmpty(sub.Text) ? "-" : sub.Text;
                            treeView1.Nodes[index1].Nodes[sub.Name].Checked = true;
                        }
                        else
                        {
                            treeView1.Nodes[index1].Nodes.Add(sub.Name).Name = sub.Name;
                            treeView1.Nodes[index1].Nodes[sub.Name].Text = string.IsNullOrEmpty(sub.Text) ? "-" : sub.Text;
                        }

                        index2++;
                    }
                  
        
                    index1++;
                    index2 = 0;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboName.SelectedValue == null)
            {
                MessageBox.Show("User not found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure do want to save this access menu?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var menuChecked = GetCheckedNodes(treeView1.Nodes);
                    MenuAccess model = new MenuAccess();
                    model.AdminId = cboName.SelectedValue.ToString();
                    factory.MenuAccessRepository.Delete(model);

                    foreach (Dictionary<string, string> menu in menuChecked)
                    {
                        model = new MenuAccess();
                        model.AdminId = cboName.SelectedValue.ToString();
                        model.MenuName = menu.FirstOrDefault().Key;
                        model.MenuText = menu.FirstOrDefault().Value;
                        factory.MenuAccessRepository.Insert(model);
                    }
                    MessageBox.Show("Access menu save!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    cboName.Focus();
                }
            }
        }

        public List<Dictionary<string,string>> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<Dictionary<string, string>> nodeList = new List<Dictionary<string, string>>();
            if (nodes == null)
            {
                return nodeList;
            }

            foreach (TreeNode childNode in nodes)
            {
                if (childNode.Checked)
                {
                    var dic = new Dictionary<string, string>
                    {
                        { childNode.Name, childNode.Text }
                    };
                    nodeList.Add(dic);
                }
                nodeList.AddRange(GetCheckedNodes(childNode.Nodes));
            }
            return nodeList;
        }

        private void cboName_TextChanged(object sender, EventArgs e)
        {
            loadTreeView();
        }
    }
}
