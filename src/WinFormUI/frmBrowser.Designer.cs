namespace SocanCode
{
    partial class WebBrowser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGoBack = new System.Windows.Forms.ToolStripButton();
            this.tsbGoFoward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmbURL = new System.Windows.Forms.ToolStripComboBox();
            this.tsbGo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbGoHome = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDown = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAll = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AxWebBrowser1 = new AxSHDocVw.AxWebBrowser();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWebBrowser1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGoBack,
            this.tsbGoFoward,
            this.toolStripSeparator2,
            this.tscmbURL,
            this.tsbGo,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbStop,
            this.tsbGoHome});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGoBack
            // 
            this.tsbGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGoBack.Image = global::SocanCode.Properties.Resources.NavBack;
            this.tsbGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGoBack.Name = "tsbGoBack";
            this.tsbGoBack.Size = new System.Drawing.Size(23, 22);
            this.tsbGoBack.Text = "后退";
            this.tsbGoBack.Click += new System.EventHandler(this.tsbGoBack_Click);
            // 
            // tsbGoFoward
            // 
            this.tsbGoFoward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGoFoward.Image = global::SocanCode.Properties.Resources.NavForward;
            this.tsbGoFoward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGoFoward.Name = "tsbGoFoward";
            this.tsbGoFoward.Size = new System.Drawing.Size(23, 22);
            this.tsbGoFoward.Text = "前进";
            this.tsbGoFoward.Click += new System.EventHandler(this.tsbGoFoward_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tscmbURL
            // 
            this.tscmbURL.Name = "tscmbURL";
            this.tscmbURL.Size = new System.Drawing.Size(500, 25);
            this.tscmbURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tscmbURL_KeyPress);
            // 
            // tsbGo
            // 
            this.tsbGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGo.Image = global::SocanCode.Properties.Resources.GoLtrHS;
            this.tsbGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGo.Name = "tsbGo";
            this.tsbGo.Size = new System.Drawing.Size(23, 22);
            this.tsbGo.Text = "转到";
            this.tsbGo.Click += new System.EventHandler(this.tsbGo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::SocanCode.Properties.Resources.RepeatHS;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::SocanCode.Properties.Resources.error;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "停止";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbGoHome
            // 
            this.tsbGoHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGoHome.Image = global::SocanCode.Properties.Resources.HomeHS;
            this.tsbGoHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGoHome.Name = "tsbGoHome";
            this.tsbGoHome.Size = new System.Drawing.Size(23, 22);
            this.tsbGoHome.Text = "主页";
            this.tsbGoHome.Click += new System.EventHandler(this.tsbGoHome_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tspbStatus,
            this.toolStripStatusLabel1,
            this.tsslDown,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tsslAll,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.AutoSize = false;
            this.tsslStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tsslStatus.Size = new System.Drawing.Size(300, 17);
            this.tsslStatus.Text = "就绪";
            this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbStatus
            // 
            this.tspbStatus.Name = "tspbStatus";
            this.tspbStatus.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "  已下载";
            // 
            // tsslDown
            // 
            this.tsslDown.Name = "tsslDown";
            this.tsslDown.Size = new System.Drawing.Size(11, 17);
            this.tsslDown.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "字节/";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel4.Text = "共";
            // 
            // tsslAll
            // 
            this.tsslAll.Name = "tsslAll";
            this.tsslAll.Size = new System.Drawing.Size(11, 17);
            this.tsslAll.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel6.Text = "字节";
            // 
            // AxWebBrowser1
            // 
            this.AxWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxWebBrowser1.Enabled = true;
            this.AxWebBrowser1.Location = new System.Drawing.Point(0, 25);
            this.AxWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWebBrowser1.OcxState")));
            this.AxWebBrowser1.Size = new System.Drawing.Size(792, 406);
            this.AxWebBrowser1.TabIndex = 7;
            this.AxWebBrowser1.NewWindow2 += new AxSHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(this.AxWebBrowser1_NewWindow2);
            this.AxWebBrowser1.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.AxWebBrowser1_BeforeNavigate2);
            this.AxWebBrowser1.ProgressChange += new AxSHDocVw.DWebBrowserEvents2_ProgressChangeEventHandler(this.AxWebBrowser1_ProgressChange);
            this.AxWebBrowser1.DownloadComplete += new System.EventHandler(this.AxWebBrowser1_DownloadComplete);
            this.AxWebBrowser1.TitleChange += new AxSHDocVw.DWebBrowserEvents2_TitleChangeEventHandler(this.AxWebBrowser1_TitleChange);
            this.AxWebBrowser1.NavigateError += new AxSHDocVw.DWebBrowserEvents2_NavigateErrorEventHandler(this.AxWebBrowser1_NavigateError);
            this.AxWebBrowser1.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(this.AxWebBrowser1_NavigateComplete2);
            // 
            // WebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 453);
            this.Controls.Add(this.AxWebBrowser1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WebBrowser";
            this.ShowHint = WeifenLuo.WinFormsUI.DockState.Document;
            this.TabText = "网页浏览器";
            this.Text = "网页浏览器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWebBrowser1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscmbURL;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbGoBack;
        private System.Windows.Forms.ToolStripButton tsbGoFoward;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbGo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbGoHome;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripProgressBar tspbStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDown;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsslAll;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public AxSHDocVw.AxWebBrowser AxWebBrowser1;
    }
}