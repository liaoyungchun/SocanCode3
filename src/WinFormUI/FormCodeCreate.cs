using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.IO;

namespace SocanCode
{
    public partial class FormCodeCreate : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private Model.Table _table;
        private string _dbName;
        private Model.Database.DatabaseType _dbType;
        public FormCodeCreate(Model.Database.DatabaseType dbType, string dbName, Model.Table table)
        {
            InitializeComponent();

            //如果是ACCESS数据库，不允许使用缓存依赖，不能使用存储过程方式
            if (dbType == Model.Database.DatabaseType.Access)
            {
                cobCacheFrame.Items.Remove(cobCacheFrame.Items[2]);
                cobDALFrame.Enabled = false;
            }
            _dbType = dbType;

            tcCodes.Controls.Clear();
            cobCodeFrame.SelectedIndex = 0;
            cobCacheFrame.SelectedIndex = 0;
            cobDALFrame.SelectedIndex = 0;
            _dbName = dbName;
            _table = table;

            TextEditor.SetStyle(txtModel, "C#");
            TextEditor.SetStyle(txtIDAL, "C#");
            TextEditor.SetStyle(txtDBUtility, "C#");
            TextEditor.SetStyle(txtDALFactory, "C#");
            TextEditor.SetStyle(txtDAL, "C#");
            TextEditor.SetStyle(txtBLL, "C#");
            TextEditor.SetStyle(txtUserControl, "HTML");
            TextEditor.SetStyle(txtUserControlCs, "C#");

            TextEditor.SetStyle(txtICacheDependency, "C#");
            TextEditor.SetStyle(txtTableDependency, "C#");
            TextEditor.SetStyle(txtTableCacheDependency, "C#");
            TextEditor.SetStyle(txtDependencyAccess, "C#");
            TextEditor.SetStyle(txtDependencyFacade, "C#");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 获取生成样式
            Model.CodeStyle style = new Model.CodeStyle();
            style.ConnVariable = "Config." + txtConnection.Text.Trim();
            style.BeforeNamespace = txtBeforeNamespace.Text.Trim();
            style.AfterNamespace = txtAfterNamespace.Text.Trim();

            switch (cobCodeFrame.SelectedIndex)
            {
                case 0:
                    style.CodeFrame = Model.CodeStyle.CodeFrames.Simple;
                    break;
                case 1:
                    style.CodeFrame = Model.CodeStyle.CodeFrames.Factory;
                    break;
                default:
                    break;
            }
            switch (cobCacheFrame.SelectedIndex)
            {
                case 0:
                    style.CacheFrame = Model.CodeStyle.CacheFrames.None;
                    break;
                case 1:
                    style.CacheFrame = Model.CodeStyle.CacheFrames.Cache;
                    break;
                case 2:
                    style.CacheFrame = Model.CodeStyle.CacheFrames.AggregateDependency;
                    break;
                default:
                    break;
            }
            switch (cobDALFrame.SelectedIndex)
            {
                case 0:
                    style.DALFrame = Model.CodeStyle.DALFrames.SQL;
                    break;
                case 1:
                    style.DALFrame = Model.CodeStyle.DALFrames.SP;
                    break;
                default:
                    break;
            }
            #endregion

            List<Model.Table> tables = new List<Model.Table>();
            tables.Add(_table);

            tcCodes.Controls.Clear();

            //Model
            txtModel.Text = Codes.ModelCode.GetModelCode(_table, style);
            tcCodes.Controls.Add(tpModel);


            //DBUtility
            tcCodes.Controls.Add(tpDBUtility);
            string fileSqlHelper = System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility\\SqlHelper.cs";
            if (File.Exists(fileSqlHelper))
            {
                StreamReader sr = new StreamReader(fileSqlHelper, Encoding.Default);
                txtDBUtility.Text = sr.ReadToEnd();
                sr.Close();
            }
            else
                txtDBUtility.Text = "无法生成,可能程序被破坏,建议重新安装";

            //IDAL
            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
            {
                txtIDAL.Text = Codes.IDALCode.GetIDALCode(_table, style);
                tcCodes.Controls.Add(tpIDAL);
            }

            //DAL
            txtDAL.Text = Codes.DALCode.GetDALCode(_dbType, _table, style);
            tcCodes.Controls.Add(tpDAL);

            //DALFactory
            if (style.CodeFrame == Model.CodeStyle.CodeFrames.Factory)
            {
                txtDALFactory.Text = Codes.DALFactoryCode.GetDALFactoryCode(tables, style);
                tcCodes.Controls.Add(tpDALFactory);
            }

            if (style.CacheFrame == Model.CodeStyle.CacheFrames.AggregateDependency)
            {
                //ICacheDependency
                txtICacheDependency.Text = Codes.ICacheDependencyCode.GetICacheDependencyCode(style);
                tcCodes.Controls.Add(tpICacheDependency);

                //TableDependency
                txtTableDependency.Text = Codes.TableCacheDependencyCode.GetTableDependencyCode(_dbName, style);
                tcCodes.Controls.Add(tpTableDependency);

                //TableCacheDependency
                txtTableCacheDependency.Text = Codes.TableCacheDependencyCode.GetTableCacheDependencyCode(_dbName, _table, style);
                tcCodes.Controls.Add(tpTableCacheDependency);

                //DependencyAccess
                txtDependencyAccess.Text = Codes.CacheDependencyFactoryCode.GetDependencyAccessCode(tables, style);
                tcCodes.Controls.Add(tpDependencyAccess);

                //DependencyFacade
                txtDependencyFacade.Text = Codes.CacheDependencyFactoryCode.GetDependencyFacadeCode(tables, style);
                tcCodes.Controls.Add(tpDependencyFacade);
            }

            //BLL
            txtBLL.Text = Codes.BLLCode.GetBLLCode(_dbType, _table, style);
            tcCodes.Controls.Add(tpBLL);

            //用户控件
            txtUserControl.Text = Codes.UserControlCode.GetUserControlCode(_table, style);
            tcCodes.Controls.Add(tpUserControl);

            //用户控件后台
            txtUserControlCs.Text = Codes.UserControlCode.GetWebUserControlCsCode(_table, style);
            tcCodes.Controls.Add(tpUserControlCs);
        }
    }
}