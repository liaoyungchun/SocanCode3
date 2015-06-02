using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CodeFactory;
using DBUtility;
using System.Diagnostics;

namespace SocanCode
{
    public partial class FormDatabase : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public FormDatabase()
        {
            InitializeComponent();
        }

        public bool AddDatabase(Model.Database database)
        {
            CodeUtility.DatabaseInfo.GetDatabaseInfo(database);
            if (database.Connected == true)
            {
                TreeNode tnDatabase = new TreeNode(database.DatabaseName, 0, 0);
                tnDatabase.Tag = database;
                this.tvDatabase.Nodes.Add(tnDatabase);

                ShowDatabase(database, tnDatabase);
                return true;
            }
            else
            {
                MessageBox.Show("连接失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tvDatabase.SelectedNode != null && tvDatabase.SelectedNode.Level == 0)
            {
                Model.Database database = tvDatabase.SelectedNode.Tag as Model.Database;
                CodeUtility.DatabaseInfo.GetDatabaseInfo(database);
                if (database.Connected)
                {
                    tvDatabase.SelectedNode.Nodes.Clear();
                    ShowDatabase(database, tvDatabase.SelectedNode);
                }
                else
                {
                    MessageBox.Show("连接失败！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 数据库显示在TreeView中
        /// </summary>
        /// <param name="l"></param>
        /// <param name="tnMain"></param>
        private static void ShowDatabase(Model.Database database, TreeNode tnDatabase)
        {
            tnDatabase.Nodes.Add(new TreeNode("表", 1, 1));
            tnDatabase.Nodes.Add(new TreeNode("视图", 1, 1));
            tnDatabase.Nodes.Add(new TreeNode("存储过程", 1, 1));

            foreach (Model.Table table in database.Tables)
            {
                TreeNode tnTable = new TreeNode(table.Name, 2, 2);
                tnTable.Tag = table;
                tnDatabase.Nodes[0].Nodes.Add(tnTable);

                foreach (Model.Field field in table.Fields)
                {
                    TreeNode tnField = new TreeNode(field.FieldName + ":" + field.FieldType + "(" + field.FieldSize + ")", 3, 3);
                    tnTable.Nodes.Add(tnField);
                }
            }

            foreach (string view in database.Views)
            {
                tnDatabase.Nodes[1].Nodes.Add(new TreeNode(view, 4, 4));
            }

            foreach (string storeProcedure in database.StoreProcedures)
            {
                tnDatabase.Nodes[2].Nodes.Add(new TreeNode(storeProcedure, 5, 5));
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripItem menu in contextMenuStrip1.Items)
            {
                menu.Visible = false;
            }
            if (tvDatabase.SelectedNode != null)
            {
                switch (tvDatabase.SelectedNode.Level)
                {
                    case 0:
                        menuOutput.Visible = true;
                        menuDeleteDatabase.Visible = true;
                        if ((tvDatabase.SelectedNode.Tag as Model.Database).Type != Model.Database.DatabaseType.Access)
                        {
                            menuEnableDatabaseForSqlCacheDependency.Visible = true;
                            menuDisableDatabaseForSqlCacheDependency.Visible = true;
                        }
                        break;
                    case 1:
                        if (tvDatabase.SelectedNode.Index == 0)
                        {
                            if ((tvDatabase.SelectedNode.Parent.Tag as Model.Database).Type != Model.Database.DatabaseType.Access)
                            {
                                menuEnableAllTablesForSqlCacheDependency.Visible = true;
                                menuDisableAllTablesForSqlCacheDependency.Visible = true;
                            }
                        }
                        break;
                    case 2:
                        if (tvDatabase.SelectedNode.Parent.Index == 0)
                        {
                            menuCreateCode.Visible = true;
                            if ((tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database).Type != Model.Database.DatabaseType.Access)
                            {
                                menuEnableTableForSqlCacheDependency.Visible = true;
                                menuDisableTableForSqlCacheDependency.Visible = true;
                                menuCreateStoreProcedure.Visible = true;
                            }
                        }
                        if (tvDatabase.SelectedNode.Parent.Index == 2)
                        {
                            menuViewStoreProcedure.Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void menuOutput_Click(object sender, EventArgs e)
        {
            if (tvDatabase.SelectedNode != null && tvDatabase.SelectedNode.Level == 0)
            {
                FormCodeOutput frm = new FormCodeOutput(tvDatabase.SelectedNode.Tag as Model.Database);
                frm.Show(FormMain.dp);
            }
            else
            {
                FormMain.ShowMessage("请先选择一个数据库");
            }
        }

        public void menuCreateCode_Click(object sender, EventArgs e)
        {
            if (tvDatabase.SelectedNode != null && tvDatabase.SelectedNode.Level == 2 && tvDatabase.SelectedNode.Parent.Index == 0)
            {
                string dbName = tvDatabase.SelectedNode.Parent.Parent.Text;
                FormCodeCreate frm = new FormCodeCreate((tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database).Type, dbName, tvDatabase.SelectedNode.Tag as Model.Table);
                frm.Show(FormMain.dp);
            }
            else
            {
                FormMain.ShowMessage("请先选择一个表");
            }
        }

        public void menuCreateStoreProcedure_Click(object sender, EventArgs e)
        {
            if (tvDatabase.SelectedNode != null && tvDatabase.SelectedNode.Level == 2 && tvDatabase.SelectedNode.Parent.Index == 0)
            {
                FormCodeView frm = new FormCodeView(tvDatabase.SelectedNode.Text + "的存储过程", Codes.Sp.GetSpCode(tvDatabase.SelectedNode.Tag as Model.Table), "TSQL");
                frm.Show(FormMain.dp);
            }
            else
            {
                FormMain.ShowMessage("请先选择一个表");
            }
        }

        private void tvDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnRefresh.Enabled = btnDelete.Enabled = (tvDatabase.SelectedNode.Level == 0);
        }

        private void menuDeleteDatabase_Click(object sender, EventArgs e)
        {
            if (tvDatabase.SelectedNode != null && tvDatabase.SelectedNode.Level == 0)
                tvDatabase.Nodes.Remove(tvDatabase.SelectedNode);
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            FormConnection frm = new FormConnection(this);
            frm.ShowDialog();
        }

        #region 启用/禁用缓存命令
        private void menuEnableDatabaseForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.EnableDatabaseForSqlCacheDependency(tvDatabase.SelectedNode.Tag as Model.Database);
        }

        private void menuDisableDatabaseForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.DisableDatabaseForSqlCacheDependency(tvDatabase.SelectedNode.Tag as Model.Database);
        }

        private void menuEnableAllTablesForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.EnableAllTablesForSqlCacheDependency(tvDatabase.SelectedNode.Parent.Tag as Model.Database);
        }

        private void menuDisableAllTablesForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.DisableAllTablesForSqlCacheDependency(tvDatabase.SelectedNode.Parent.Tag as Model.Database);
        }

        private void menuEnableTableForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.EnableTableForSqlCacheDependency(tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database, tvDatabase.SelectedNode.Tag as Model.Table);
        }

        private void menuDisableTableForSqlCacheDependency_Click(object sender, EventArgs e)
        {
            CodeUtility.CommandHelper.DisableTableForSqlCacheDependency(tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database, tvDatabase.SelectedNode.Tag as Model.Table);
        }
        #endregion

        private void menuViewStoreProcedure_Click(object sender, EventArgs e)
        {
            Model.Database database = tvDatabase.SelectedNode.Parent.Parent.Tag as Model.Database;
            string text = CodeUtility.SpInfo.GetSpInfo(database, tvDatabase.SelectedNode.Text);
            FormCodeView frm = new FormCodeView(tvDatabase.SelectedNode.Text, text, "TSQL");
            frm.Show(FormMain.dp);
        }

        /// <summary>
        /// 得到TreeView里鼠标指向的节点,同时把该节点设置为当前选中的节点
        /// </summary>
        /// <param name="tv"></param>
        /// <returns></returns>
        public TreeNode GetMouseNode(TreeView tv, Control currentForm)
        {
            Point pt = currentForm.PointToScreen(tv.Location);
            Point p = new Point(Control.MousePosition.X - pt.X, Control.MousePosition.Y - pt.Y);
            TreeNode tn = tv.GetNodeAt(p);
            return tn;
        }

        private void tvDatabase_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = GetMouseNode(tvDatabase, this);
            if (tn != null)
            {
                tvDatabase.SelectedNode = tn;
            }
        }
    }
}