using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CodeFactory;
using System.Data.OleDb;
using System.Threading;
using System.Xml;
using System.Diagnostics;

namespace SocanCode
{
    public partial class FormCodeOutput : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private Model.Database.DatabaseType _dbtype;
        private List<Model.Table> _tables;
        private string _dbName;
        public FormCodeOutput(Model.Database database)
        {
            InitializeComponent();
            cobCodeFrame.SelectedIndex = 0;
            cobCacheFrame.SelectedIndex = 0;
            cobDALFrame.SelectedIndex = 0;

            //关于注册
            //CheckForIllegalCrossThreadCalls = false;
            //Thread threadCheckRegister = new Thread(CheckRegister);
            //threadCheckRegister.Start();

            _dbtype = database.Type;
            _dbName = database.DatabaseName;
            _tables = database.Tables;

            //如果是Access数据库，不能使用缓存依赖，不能使用存储过程，不能生成存储过程
            if (_dbtype == Model.Database.DatabaseType.Access)
            {
                cobCacheFrame.Items.Remove(cobCacheFrame.Items[2]);
                cobDALFrame.Enabled = false;
                btnOutputSp.Enabled = false;
            }
            foreach (Model.Table table in _tables)
            {
                lstTables.Items.Add(table.Name);
            }
        }

        //关于注册
        //private void CheckRegister()
        //{
        //    if (File.Exists(Reg.filePath))
        //    {
        //        StreamReader sr = new StreamReader(Reg.filePath);
        //        string tmp = sr.ReadToEnd();
        //        sr.Close();
        //        if (tmp == Registers.Registers.GetValue())
        //        {
        //            chkUserControl.Enabled = chkUserControl.Checked = true;
        //        }
        //    }
        //}

        private void btnOutputCode_Click(object sender, EventArgs e)
        {
            #region 判断生成的条件
            if (lstSelectedTables.Items.Count <= 0)
            {
                FormMain.ShowMessage("未选择任何表!");
                return;
            }
            if (MessageBox.Show("确定要输出代码吗?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            #endregion

            List<Model.Table> tables = GetOutputTables();
            Model.CodeStyle codeStyle = GetOutputCodeStyle();
            Model.CreateStyle createStyle = GetOutputCreateStyle();

            if (Directory.Exists(createStyle.CreatePath))
            {
                if (MessageBox.Show("该目录已存在，是否删除?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.Delete(createStyle.CreatePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            OutputCode(tables, codeStyle, createStyle);

            CreateSln(createStyle);

            progressBar1.Value = 0;

            if (MessageBox.Show("成功生成,是否打开目录?", "恭喜", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(createStyle.CreatePath);
        }

        #region 取得生成的参数
        private Model.CreateStyle GetOutputCreateStyle()
        {
            Model.CreateStyle createStyle = new Model.CreateStyle();
            createStyle.CreatePath = txtPath.Text;
            createStyle.HasCreateBLL = chkModel.Checked;
            createStyle.HasCreateDAL = chkDAL.Checked;
            createStyle.HasCreateDALFactory = chkDALFactory.Checked;
            createStyle.HasCreateDBUtility = chkDBUtility.Checked;
            createStyle.HasCreateIDAL = chkIDAL.Checked;
            createStyle.HasCreateModel = chkModel.Checked;
            createStyle.HasCreateUserControl = chkUserControl.Checked;
            createStyle.HasCreateICacheDependency = chkICacheDependency.Checked;
            createStyle.HasCreateTableCacheDependency = chkTableCacheDependency.Checked;
            createStyle.HasCreateCacheDependencyFactory = chkCacheDependencyFactory.Checked;
            return createStyle;
        }

        private Model.CodeStyle GetOutputCodeStyle()
        {
            Model.CodeStyle codeStyle = new Model.CodeStyle();
            codeStyle.ConnVariable = "Config." + txtConnection.Text.Trim();
            codeStyle.BeforeNamespace = txtBeforeNamespace.Text.Trim();
            codeStyle.AfterNamespace = txtAfterNamespace.Text.Trim();

            switch (cobCodeFrame.SelectedIndex)
            {
                case 0:
                    codeStyle.CodeFrame = Model.CodeStyle.CodeFrames.Simple;
                    break;
                case 1:
                    codeStyle.CodeFrame = Model.CodeStyle.CodeFrames.Factory;
                    break;
                default:
                    break;
            }
            switch (cobCacheFrame.SelectedIndex)
            {
                case 0:
                    codeStyle.CacheFrame = Model.CodeStyle.CacheFrames.None;
                    break;
                case 1:
                    codeStyle.CacheFrame = Model.CodeStyle.CacheFrames.Cache;
                    break;
                case 2:
                    codeStyle.CacheFrame = Model.CodeStyle.CacheFrames.AggregateDependency;
                    break;
                default:
                    break;
            }
            switch (cobDALFrame.SelectedIndex)
            {
                case 0:
                    codeStyle.DALFrame = Model.CodeStyle.DALFrames.SQL;
                    break;
                case 1:
                    codeStyle.DALFrame = Model.CodeStyle.DALFrames.SP;
                    break;
                default:
                    break;
            }
            return codeStyle;
        }

        private List<Model.Table> GetOutputTables()
        {
            List<Model.Table> tables = new List<Model.Table>();
            foreach (object obj in lstSelectedTables.Items)
            {
                foreach (Model.Table table in _tables)
                {
                    if (table.Name == obj.ToString())
                        tables.Add(table);
                }
            }
            return tables;
        }
        #endregion

        private void btnOutputSp_Click(object sender, EventArgs e)
        {
            #region 判断生成的条件
            if (lstSelectedTables.Items.Count <= 0)
            {
                FormMain.ShowMessage("未选择任何表!");
                return;
            }
            if (MessageBox.Show("确定要输出存储过程吗?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            #endregion

            List<Model.Table> tables = GetOutputTables();
            Model.CreateStyle createStyle = GetOutputCreateStyle();

            OutputSp(tables, createStyle);

            if (MessageBox.Show("成功生成,是否打开目录?", "恭喜", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Process.Start(createStyle.CreatePath);
        }

        private void OutputSp(List<Model.Table> tables, Model.CreateStyle createStyle)
        {
            string path = createStyle.CreatePath;
            Directory.CreateDirectory(path);
            CodeFactory.CodeAccess.CreateSpFile(tables, path);
        }

        /// <summary>
        /// 创建Sln文件
        /// </summary>
        private void CreateSln(Model.CreateStyle createStyle)
        {
            StringBuilder sln = new StringBuilder();

            sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\Head.csproj"));

            if (createStyle.HasCreateBLL)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\BLL.csproj"));
            }

            if (createStyle.HasCreateDAL)
            {
                if (_dbtype == Model.Database.DatabaseType.Access)
                {
                    sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\AccessDAL.csproj"));
                }
                else
                {
                    sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\SQLServerDAL.csproj"));
                }
            }

            if (createStyle.HasCreateDALFactory)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\DALFactory.csproj"));
            }

            if (createStyle.HasCreateDBUtility)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\DBUtility.csproj"));
            }

            if (createStyle.HasCreateIDAL)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\IDAL.csproj"));
            }

            if (createStyle.HasCreateModel)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\Model.csproj"));
            }

            if (createStyle.HasCreateICacheDependency)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\ICacheDependency.csproj"));
            }

            if (createStyle.HasCreateTableCacheDependency)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\TableCacheDependency.csproj"));
            }

            if (createStyle.HasCreateCacheDependencyFactory)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\CacheDependencyFactory.csproj"));
            }

            if (createStyle.HasCreateUserControl)
            {
                sln.AppendLine(ReadString(System.Windows.Forms.Application.StartupPath + "\\Sln\\Web.csproj"));
            }

            Directory.CreateDirectory(createStyle.CreatePath);
            StreamWriter sw = new StreamWriter(createStyle.CreatePath + "\\Web.sln");
            sw.Write(sln.ToString());
            sw.Close();
        }

        private string ReadString(string path)
        {
            string result;
            StreamReader sr = new StreamReader(path);
            result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        /// <summary>
        /// 输出代码
        /// </summary>
        /// <param name="lstTable"></param>
        /// <param name="codeStyle"></param>
        /// <param name="createStyle"></param>
        private void OutputCode(List<Model.Table> tables, Model.CodeStyle codeStyle, Model.CreateStyle createStyle)
        {
            if (createStyle.HasCreateModel)
            {
                string pathModel = createStyle.CreatePath + "\\Model";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\Model", pathModel);
                CodeFactory.CodeAccess.CreateModelFile(tables, codeStyle, pathModel);
            }
            progressBar1.Value = 10;

            if (createStyle.HasCreateIDAL)
            {
                string pathIDAL = createStyle.CreatePath + "\\IDAL";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\IDAL", pathIDAL);
                CodeFactory.CodeAccess.CreateIDALFile(tables, codeStyle, pathIDAL);
            }
            progressBar1.Value = 20;

            if (createStyle.HasCreateDAL)
            {
                string pathDAL;
                if (_dbtype == Model.Database.DatabaseType.Access)
                {
                    pathDAL = createStyle.CreatePath + "\\AccessDAL";
                    CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\AccessDAL", pathDAL);
                }
                else
                {
                    pathDAL = createStyle.CreatePath + "\\SqlServerDAL";
                    CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\SqlServerDAL", pathDAL);
                }
                CodeFactory.CodeAccess.CreateDALFile(_dbtype, tables, codeStyle, pathDAL);
            }
            progressBar1.Value = 30;

            if (createStyle.HasCreateBLL)
            {
                string pathBLL = createStyle.CreatePath + "\\BLL";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\BLL", pathBLL);
                CodeFactory.CodeAccess.CreateBLLFile(_dbtype, tables, codeStyle, pathBLL);
            }
            progressBar1.Value = 40;

            if (createStyle.HasCreateUserControl)
            {
                string pathUserControl = createStyle.CreatePath + "\\" + txtWebPath.Text + "\\" + txtControlsPath.Text;
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\Web", createStyle.CreatePath + "\\" + txtWebPath.Text);
                CodeFactory.CodeAccess.CreateUserControl(tables, codeStyle, pathUserControl);
            }
            progressBar1.Value = 50;

            if (createStyle.HasCreateDALFactory)
            {
                string pathDALFactory = createStyle.CreatePath + "\\DALFactory";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\DALFactory", pathDALFactory);
                CodeFactory.CodeAccess.CreateDALFactoryFile(tables, codeStyle, pathDALFactory);
            }
            progressBar1.Value = 50;

            if (createStyle.HasCreateDBUtility)
            {
                string pathDBUtility = createStyle.CreatePath + "\\DBUtility";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility", pathDBUtility);
            }
            progressBar1.Value = 60;

            if (createStyle.HasCreateICacheDependency)
            {
                string pathICacheDependency = createStyle.CreatePath + "\\ICacheDependency";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\ICacheDependency", pathICacheDependency);
                CodeFactory.CodeAccess.CreateICacheDependencyFile(codeStyle, pathICacheDependency);
            }
            progressBar1.Value = 70;

            if (createStyle.HasCreateTableCacheDependency)
            {
                string pathTableCacheDependency = createStyle.CreatePath + "\\TableCacheDependency";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\TableCacheDependency", pathTableCacheDependency);
                CodeFactory.CodeAccess.CreateTableCacheDependencyFile(_dbName, tables, codeStyle, pathTableCacheDependency);
            }
            progressBar1.Value = 80;

            if (createStyle.HasCreateCacheDependencyFactory)
            {
                string pathCacheDependencyFactory = createStyle.CreatePath + "\\CacheDependencyFactory";
                CopyFiles(System.Windows.Forms.Application.StartupPath + "\\Template\\CacheDependencyFactory", pathCacheDependencyFactory);
                CodeFactory.CodeAccess.CreateCacheDependencyFactoryFile(tables, codeStyle, pathCacheDependencyFactory);
            }
            progressBar1.Value = 90;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dlg.SelectedPath;
            }
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstTables.SelectedItems)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstSelectedTables.Items.Add(obj);
                lstTables.Items.Remove(obj);
            }
        }

        private void btnSelectedAll_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstTables.Items)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstSelectedTables.Items.Add(obj);
                lstTables.Items.Remove(obj);
            }
        }

        private void btnUnSelected_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstSelectedTables.SelectedItems)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstTables.Items.Add(obj);
                lstSelectedTables.Items.Remove(obj);
            }
        }

        private void btnUnSelectedAll_Click(object sender, EventArgs e)
        {
            List<object> objs = new List<object>();
            foreach (object obj in lstSelectedTables.Items)
            {
                objs.Add(obj);
            }
            foreach (object obj in objs)
            {
                lstTables.Items.Add(obj);
                lstSelectedTables.Items.Remove(obj);
            }
        }

        private void txtConnection_Leave(object sender, EventArgs e)
        {
            if (txtConnection.Text.Trim() == string.Empty)
                txtConnection.Text = "Connection";
        }

        private void chkDAL_CheckedChanged(object sender, EventArgs e)
        {
            txtConnection.Enabled = chkDAL.Checked;
        }

        private void chkUserControl_CheckedChanged(object sender, EventArgs e)
        {
            txtWebPath.Enabled = txtControlsPath.Enabled = chkUserControl.Checked;
        }

        private void cobCodeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cobCodeFrame.SelectedIndex)
            {
                case 0:
                    chkDBUtility.Checked = true;
                    chkModel.Checked = true;
                    chkDAL.Checked = true;
                    chkBLL.Checked = true;
                    chkIDAL.Checked = chkIDAL.Enabled = false;
                    chkDALFactory.Checked = chkDALFactory.Enabled = false;
                    break;
                case 1:
                    chkDBUtility.Checked = true;
                    chkModel.Checked = true;
                    chkDAL.Checked = true;
                    chkBLL.Checked = true;
                    chkIDAL.Checked = chkIDAL.Enabled = true;
                    chkDALFactory.Checked = chkDALFactory.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void CopyFiles(string sourceDirectory, string targetDirectory)
        {
            Directory.CreateDirectory(targetDirectory);

            if (!Directory.Exists(sourceDirectory)) return;

            string[] directories = Directory.GetDirectories(sourceDirectory);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    CopyFiles(d, targetDirectory + d.Substring(d.LastIndexOf("\\")));
                }
            }

            string[] files = Directory.GetFiles(sourceDirectory);

            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    File.Copy(s, targetDirectory + s.Substring(s.LastIndexOf("\\")), true);
                }
            }
        }

        private void cobCacheFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cobCacheFrame.SelectedIndex)
            {
                case 2:
                    chkICacheDependency.Enabled = chkICacheDependency.Checked = true;
                    chkTableCacheDependency.Enabled = chkTableCacheDependency.Checked = true;
                    chkCacheDependencyFactory.Enabled = chkCacheDependencyFactory.Checked = true;
                    break;
                default:
                    chkICacheDependency.Enabled = chkICacheDependency.Checked = false;
                    chkTableCacheDependency.Enabled = chkTableCacheDependency.Checked = false;
                    chkCacheDependencyFactory.Enabled = chkCacheDependencyFactory.Checked = false;
                    break;
            }
        }
    }
}