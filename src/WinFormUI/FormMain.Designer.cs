namespace SocanCode
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewSqlHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewAccessHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewCommonHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewPageHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateStoreProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menufrmDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHtmlToJs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpTopic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labNewVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuCode,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewSqlHelper,
            this.menuViewAccessHelper,
            this.menuViewCommonHelper,
            this.menuViewPageHelper});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            // 
            // menuViewSqlHelper
            // 
            this.menuViewSqlHelper.Name = "menuViewSqlHelper";
            this.menuViewSqlHelper.Size = new System.Drawing.Size(168, 22);
            this.menuViewSqlHelper.Text = "SqlHelper";
            this.menuViewSqlHelper.Click += new System.EventHandler(this.menuViewSqlHelper_Click);
            // 
            // menuViewAccessHelper
            // 
            this.menuViewAccessHelper.Name = "menuViewAccessHelper";
            this.menuViewAccessHelper.Size = new System.Drawing.Size(168, 22);
            this.menuViewAccessHelper.Text = "AccessHelper";
            this.menuViewAccessHelper.Click += new System.EventHandler(this.menuViewAccessHelper_Click);
            // 
            // menuViewCommonHelper
            // 
            this.menuViewCommonHelper.Name = "menuViewCommonHelper";
            this.menuViewCommonHelper.Size = new System.Drawing.Size(168, 22);
            this.menuViewCommonHelper.Text = "CommonHelper";
            this.menuViewCommonHelper.Click += new System.EventHandler(this.menuViewCommonHelper_Click);
            // 
            // menuViewPageHelper
            // 
            this.menuViewPageHelper.Name = "menuViewPageHelper";
            this.menuViewPageHelper.Size = new System.Drawing.Size(168, 22);
            this.menuViewPageHelper.Text = "PageHelper";
            this.menuViewPageHelper.Click += new System.EventHandler(this.menuViewPageHelper_Click);
            // 
            // menuCode
            // 
            this.menuCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOutput,
            this.menuCreateCode,
            this.menuCreateStoreProcedure});
            this.menuCode.Name = "menuCode";
            this.menuCode.Size = new System.Drawing.Size(44, 21);
            this.menuCode.Text = "代码";
            // 
            // menuOutput
            // 
            this.menuOutput.Name = "menuOutput";
            this.menuOutput.Size = new System.Drawing.Size(177, 22);
            this.menuOutput.Text = "输出代码/存储过程";
            this.menuOutput.Click += new System.EventHandler(this.menuOutput_Click);
            // 
            // menuCreateCode
            // 
            this.menuCreateCode.Name = "menuCreateCode";
            this.menuCreateCode.Size = new System.Drawing.Size(177, 22);
            this.menuCreateCode.Text = "生成代码";
            this.menuCreateCode.Click += new System.EventHandler(this.menuCreateCode_Click);
            // 
            // menuCreateStoreProcedure
            // 
            this.menuCreateStoreProcedure.Name = "menuCreateStoreProcedure";
            this.menuCreateStoreProcedure.Size = new System.Drawing.Size(177, 22);
            this.menuCreateStoreProcedure.Text = "生成存储过程";
            this.menuCreateStoreProcedure.Click += new System.EventHandler(this.menuCreateStoreProcedure_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menufrmDatabase});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 21);
            this.menuView.Text = "视图";
            // 
            // menufrmDatabase
            // 
            this.menufrmDatabase.Name = "menufrmDatabase";
            this.menufrmDatabase.Size = new System.Drawing.Size(172, 22);
            this.menufrmDatabase.Text = "数据库资源管理器";
            this.menufrmDatabase.Click += new System.EventHandler(this.menufrmDatabase_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHtmlToJs});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(44, 21);
            this.menuTools.Text = "工具";
            // 
            // menuHtmlToJs
            // 
            this.menuHtmlToJs.Name = "menuHtmlToJs";
            this.menuHtmlToJs.Size = new System.Drawing.Size(179, 22);
            this.menuHtmlToJs.Text = "HTML转Javascript";
            this.menuHtmlToJs.Click += new System.EventHandler(this.menuHtmlToJs_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpTopic,
            this.menuWebsite,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 21);
            this.menuHelp.Text = "帮助";
            // 
            // menuHelpTopic
            // 
            this.menuHelpTopic.Name = "menuHelpTopic";
            this.menuHelpTopic.Size = new System.Drawing.Size(152, 22);
            this.menuHelpTopic.Text = "主题";
            this.menuHelpTopic.Click += new System.EventHandler(this.menuHelpTopic_Click);
            // 
            // menuWebsite
            // 
            this.menuWebsite.Name = "menuWebsite";
            this.menuWebsite.Size = new System.Drawing.Size(152, 22);
            this.menuWebsite.Text = "官方网站";
            this.menuWebsite.Click += new System.EventHandler(this.menuWebsite_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(152, 22);
            this.menuAbout.Text = "关于";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labNewVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(798, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labNewVersion
            // 
            this.labNewVersion.IsLink = true;
            this.labNewVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.labNewVersion.Name = "labNewVersion";
            this.labNewVersion.Size = new System.Drawing.Size(89, 17);
            this.labNewVersion.Tag = "http://www.cnblogs.com/Files/yvesliao/SocanCode.rar";
            this.labNewVersion.Text = "正在检测版本...";
            this.labNewVersion.Click += new System.EventHandler(this.labNewVersion_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(798, 494);
            this.dockPanel1.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 541);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SocanCode代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuWebsite;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labNewVersion;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuViewSqlHelper;
        private System.Windows.Forms.ToolStripMenuItem menuHelpTopic;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menufrmDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuHtmlToJs;
        private System.Windows.Forms.ToolStripMenuItem menuCode;
        private System.Windows.Forms.ToolStripMenuItem menuOutput;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode;
        private System.Windows.Forms.ToolStripMenuItem menuCreateStoreProcedure;
        private System.Windows.Forms.ToolStripMenuItem menuViewAccessHelper;
        private System.Windows.Forms.ToolStripMenuItem menuViewCommonHelper;
        private System.Windows.Forms.ToolStripMenuItem menuViewPageHelper;
    }
}