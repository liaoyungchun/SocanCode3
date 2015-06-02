using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SocanCode
{
    public partial class FormConnection : Form
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        private Model.Database.DatabaseType dbType
        {
            get
            {
                if (rbAccess.Checked)
                {
                    return Model.Database.DatabaseType.Access;
                }
                else if (rbSql2005.Checked)
                {
                    return Model.Database.DatabaseType.Sql2005;
                }
                else
                {
                    return Model.Database.DatabaseType.Sql2000;
                }
            }
            set
            {

                if (value == Model.Database.DatabaseType.Access)
                {
                    rbAccess.Checked = true;
                }
                else if (value == Model.Database.DatabaseType.Sql2005)
                {
                    rbSql2005.Checked = true;
                }
                else
                {
                    rbSql2000.Checked = true;
                }
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string strConn
        {
            get
            {
                if (dbType != Model.Database.DatabaseType.Access)
                {
                    return TxtDbstr.Text.Trim().Replace("Provider=SQLOLEDB.1;", null).Replace("Provider=SQLOLEDB;", null);
                }
                else
                {
                    return TxtDbstr.Text.Trim();
                }
            }
        }

        private FormDatabase _frmConnection;
        private string historyFile = System.Windows.Forms.Application.StartupPath + "\\Connection.history";
        public FormConnection(FormDatabase frm)
        {
            InitializeComponent();
            _frmConnection = frm;
            if (File.Exists(historyFile))
            {
                string[] strArray = CodeUtility.CodeHelper.ReadFile(historyFile).Split(new char[] { '|' });
                TxtDbstr.Text = strArray[0];
                try
                {
                    this.dbType = (Model.Database.DatabaseType)Enum.Parse(typeof(Model.Database.DatabaseType), strArray[1]);
                }
                catch
                {
                    this.dbType = Model.Database.DatabaseType.Sql2000;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Model.Database db = new Model.Database();
            db.ConnectionString = strConn;
            db.Type = dbType;
            if (_frmConnection.AddDatabase(db))
            {
                CodeUtility.CodeHelper.WriteFile(historyFile, TxtDbstr.Text.Trim() + "|" + db.Type.ToString());
                Close();
            }
        }

        private void btnSetConnect_Click(object sender, EventArgs e)
        {
            MSDASC.DataLinks datalinks = new MSDASC.DataLinksClass();
            ADODB._Connection tmpconc = new ADODB.ConnectionClass();

            if (TxtDbstr.Text == String.Empty)
            {
                tmpconc = (ADODB._Connection)datalinks.PromptNew();
                if (tmpconc != null)
                {
                    TxtDbstr.Text = tmpconc.ConnectionString;
                }
            }
            else
            {
                Object oconc = tmpconc;
                tmpconc.ConnectionString = TxtDbstr.Text;
                try
                {
                    if (datalinks.PromptEdit(ref oconc))
                    {
                        TxtDbstr.Text = tmpconc.ConnectionString;
                    }
                }
                catch
                {
                    tmpconc = (ADODB._Connection)datalinks.PromptNew();
                    if (tmpconc != null)
                    {
                        TxtDbstr.Text = tmpconc.ConnectionString;
                    }
                }
            }
        }
    }
}