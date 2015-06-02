using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using CodeFactory;
using System.IO;
using System.Net;
using System.Xml;
using System.Reflection;

namespace SocanCode
{
    public partial class FormMain : Form
    {
        private const string HOME_URL = "http://www.Socansoft.com";
        private const string XML_URL = "http://www.socansoft.com/downloads/socancode/SocanCode.xml";
        private const string DOWNLOAD_URL = "http://www.socansoft.com/downloads/SocanCode/SocanCode.rar";

        public static WeifenLuo.WinFormsUI.Docking.DockPanel dp;
        private static FormDatabase frmDatabase;
        public static FormStatus frmStatus;
        public FormMain()
        {
            InitializeComponent();
            dp = this.dockPanel1;
            labNewVersion.Tag = DOWNLOAD_URL;

            CheckForIllegalCrossThreadCalls = false;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " V" + new FormAbout().AssemblyVersion;

            frmDatabase = new FormDatabase();
            frmDatabase.Show(dp);

            frmStatus = new FormStatus();
            frmStatus.Show(dp);

            OpenUrl(HOME_URL);

        }

        #region 版本检测
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            bool hasGetVersion = false;
            while (!hasGetVersion && count < 3)
            {
                try
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(XML_URL);
                    e.Result = xml;
                    return;
                }
                catch
                {
                    count++;
                }
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                labNewVersion.Text = "连接服务器失败!";
                labNewVersion.LinkColor = Color.Red;
                return;
            }

            XmlDocument xml = e.Result as XmlDocument;
            XmlNode display = xml.SelectSingleNode("DOCUMENT").SelectSingleNode("item").SelectSingleNode("display");
            Version lastVersion = new Version(display.SelectSingleNode("content2").InnerText);
            Version currVersion = Assembly.GetExecutingAssembly().GetName().Version;
            labNewVersion.Tag = display.SelectSingleNode("button").Attributes["buttonlink"].Value;

            if (lastVersion > currVersion)
            {
                labNewVersion.Text = "发现新版本 V" + lastVersion + ", 请点击此处下载";
                labNewVersion.LinkColor = Color.Red;
            }
            else
            {
                labNewVersion.Text = "当前版本已经是最新版本";
                labNewVersion.LinkColor = Color.Green;
            }
        }
        #endregion

        private void labNewVersion_Click(object sender, EventArgs e)
        {
            Process.Start((sender as ToolStripStatusLabel).Tag.ToString());
        }

        private void menuWebsite_Click(object sender, EventArgs e)
        {
            OpenUrl(HOME_URL);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.ShowDialog();
        }

        private void menuHelpTopic_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\Resources\\Readme.txt", Encoding.Default);
            string code = sr.ReadToEnd();
            sr.Close();
            FormCodeView frm = new FormCodeView("帮助", code, "C#");
            frm.Show(dp);
        }

        public static void ShowMessage(string msg)
        {
            frmStatus.txtMsg.Text = msg;
            frmStatus.Show(dp);
        }

        private void menufrmDatabase_Click(object sender, EventArgs e)
        {
            frmDatabase.Show(dp);
        }

        private void menuHtmlToJs_Click(object sender, EventArgs e)
        {
            FormHtmlToJs frm = new FormHtmlToJs();
            frm.Show(dp);
        }

        private void OpenUrl(string url)
        {
            WebBrowser.WebBrowser frm = new WebBrowser.WebBrowser(dp, url);
            frm.Show(dp);
        }

        private void menuOutput_Click(object sender, EventArgs e)
        {
            frmDatabase.menuOutput_Click(null, null);
        }

        private void menuCreateCode_Click(object sender, EventArgs e)
        {
            frmDatabase.menuCreateCode_Click(null, null);
        }

        private void menuCreateStoreProcedure_Click(object sender, EventArgs e)
        {
            frmDatabase.menuCreateStoreProcedure_Click(null, null);
        }

        private void menuViewSqlHelper_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility\\SqlHelper.cs", Encoding.Default);
            string code = sr.ReadToEnd();
            sr.Close();
            FormCodeView frm = new FormCodeView("SqlHelper", code, "C#");
            frm.Show(dp);
        }

        private void menuViewAccessHelper_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility\\AccessHelper.cs", Encoding.Default);
            string code = sr.ReadToEnd();
            sr.Close();
            FormCodeView frm = new FormCodeView("AccessHelper", code, "C#");
            frm.Show(dp);
        }

        private void menuViewCommonHelper_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility\\CommonHelper.cs", Encoding.Default);
            string code = sr.ReadToEnd();
            sr.Close();
            FormCodeView frm = new FormCodeView("CommonHelper", code, "C#");
            frm.Show(dp);
        }

        private void menuViewPageHelper_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Windows.Forms.Application.StartupPath + "\\Template\\DBUtility\\PageHelper.cs", Encoding.Default);
            string code = sr.ReadToEnd();
            sr.Close();
            FormCodeView frm = new FormCodeView("PageHelper", code, "C#");
            frm.Show(dp);
        }
    }
}