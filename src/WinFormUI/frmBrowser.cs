using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocanCode
{
    public partial class WebBrowser : WeifenLuo.WinFormsUI.DockContent
    {
        private WeifenLuo.WinFormsUI.DockPanel m_dp;
        public WebBrowser()
        {
            InitializeComponent();
        }

        public WebBrowser(WeifenLuo.WinFormsUI.DockPanel dp)
        {
            InitializeComponent();
            this.m_dp = dp;
        }
        
        public WebBrowser(string URL)
        {
            InitializeComponent();
            AxWebBrowser1.Navigate(URL);
        }

        public WebBrowser(WeifenLuo.WinFormsUI.DockPanel dp, string URL)
        {
            InitializeComponent();
            this.m_dp = dp;
            AxWebBrowser1.Navigate(URL);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.Refresh();
            }
            catch
            {

            }
        }

        private void tsbGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.GoBack();
            }
            catch
            { }
        }

        private void tsbGoFoward_Click(object sender, EventArgs e)
        {
            try
            {
                AxWebBrowser1.GoForward();
            }
            catch
            { }
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            AxWebBrowser1.Stop();
        }

        private void tscmbURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tsbGo_Click(null, null);
            }
        }

        private void tsbGo_Click(object sender, EventArgs e)
        {
            string URL = tscmbURL.Text.Trim();
            if (URL.ToUpper().IndexOf("HTTP://") < 0)
            {
                if (URL.IndexOf(".") < 0)
                {
                    URL = "http://www.baidu.com/s?ie=gb2312&bs=test&sr=&z=&cl=3&f=8&wd=" + URL + "&ct=0";
                }
                else
                {
                    URL = URL.Insert(0, "http://");
                }
                tscmbURL.Text = URL;
            }

            AxWebBrowser1.Navigate(URL);
            if (tscmbURL.Items.IndexOf(URL) < 0)
            {
                tscmbURL.Items.Add(URL);
            }
        }

        private void tsbGoHome_Click(object sender, EventArgs e)
        {
            AxWebBrowser1.GoHome();
        }

        private void AxWebBrowser1_NewWindow2(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow2Event e)
        {
            WebBrowser frmms = new WebBrowser();
            e.ppDisp = frmms.AxWebBrowser1.Application;
            if (m_dp != null)
            {
                frmms.Show(m_dp);
            }
            else
            {
                frmms.Show();
            }
        }

        private void AxWebBrowser1_DownloadComplete(object sender, EventArgs e)
        {
            tsslStatus.Text = "就绪";
            tspbStatus.Value = 0;
        }

        private void AxWebBrowser1_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        {
            tsslDown.Text = e.progress.ToString();
            tsslAll.Text = e.progressMax.ToString();
            tspbStatus.Value = Convert.ToInt16(100 * e.progress / e.progressMax);
        }

        private void AxWebBrowser1_BeforeNavigate2(object sender, AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
        {
            tscmbURL.Text = e.uRL.ToString();
        }

        private void AxWebBrowser1_NavigateComplete2(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
        {
            tsslStatus.Text = "网址已找到.正在打开网页" + e.uRL.ToString();
        }

        private void AxWebBrowser1_NavigateError(object sender, AxSHDocVw.DWebBrowserEvents2_NavigateErrorEvent e)
        {
            tsslStatus.Text = "网址没找到...";
        }

        private void AxWebBrowser1_TitleChange(object sender, AxSHDocVw.DWebBrowserEvents2_TitleChangeEvent e)
        {
            this.TabText = e.text;
            this.ToolTipText = e.text;
        }  
    }
}