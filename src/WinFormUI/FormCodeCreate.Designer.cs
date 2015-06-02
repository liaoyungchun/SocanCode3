namespace SocanCode
{
    partial class FormCodeCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCodeCreate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtAfterNamespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBeforeNamespace = new System.Windows.Forms.TextBox();
            this.cobCodeFrame = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cobDALFrame = new System.Windows.Forms.ComboBox();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.cobCacheFrame = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tcCodes = new System.Windows.Forms.TabControl();
            this.tpModel = new System.Windows.Forms.TabPage();
            this.txtModel = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpDBUtility = new System.Windows.Forms.TabPage();
            this.txtDBUtility = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpIDAL = new System.Windows.Forms.TabPage();
            this.txtIDAL = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpDAL = new System.Windows.Forms.TabPage();
            this.txtDAL = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpDALFactory = new System.Windows.Forms.TabPage();
            this.txtDALFactory = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpICacheDependency = new System.Windows.Forms.TabPage();
            this.txtICacheDependency = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpTableDependency = new System.Windows.Forms.TabPage();
            this.txtTableDependency = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpTableCacheDependency = new System.Windows.Forms.TabPage();
            this.txtTableCacheDependency = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpDependencyAccess = new System.Windows.Forms.TabPage();
            this.txtDependencyAccess = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpDependencyFacade = new System.Windows.Forms.TabPage();
            this.txtDependencyFacade = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpBLL = new System.Windows.Forms.TabPage();
            this.txtBLL = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpUserControl = new System.Windows.Forms.TabPage();
            this.txtUserControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.tpUserControlCs = new System.Windows.Forms.TabPage();
            this.txtUserControlCs = new ICSharpCode.TextEditor.TextEditorControl();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcCodes.SuspendLayout();
            this.tpModel.SuspendLayout();
            this.tpDBUtility.SuspendLayout();
            this.tpIDAL.SuspendLayout();
            this.tpDAL.SuspendLayout();
            this.tpDALFactory.SuspendLayout();
            this.tpICacheDependency.SuspendLayout();
            this.tpTableDependency.SuspendLayout();
            this.tpTableCacheDependency.SuspendLayout();
            this.tpDependencyAccess.SuspendLayout();
            this.tpDependencyFacade.SuspendLayout();
            this.tpBLL.SuspendLayout();
            this.tpUserControl.SuspendLayout();
            this.tpUserControlCs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 109);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtAfterNamespace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBeforeNamespace);
            this.groupBox1.Controls.Add(this.cobCodeFrame);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cobDALFrame);
            this.groupBox1.Controls.Add(this.txtConnection);
            this.groupBox1.Controls.Add(this.cobCacheFrame);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 109);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置选项";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(433, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "生成代码";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtAfterNamespace
            // 
            this.txtAfterNamespace.Location = new System.Drawing.Point(303, 69);
            this.txtAfterNamespace.Name = "txtAfterNamespace";
            this.txtAfterNamespace.Size = new System.Drawing.Size(124, 21);
            this.txtAfterNamespace.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "三层结构";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "命名空间后缀";
            // 
            // txtBeforeNamespace
            // 
            this.txtBeforeNamespace.Location = new System.Drawing.Point(303, 46);
            this.txtBeforeNamespace.Name = "txtBeforeNamespace";
            this.txtBeforeNamespace.Size = new System.Drawing.Size(124, 21);
            this.txtBeforeNamespace.TabIndex = 3;
            // 
            // cobCodeFrame
            // 
            this.cobCodeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCodeFrame.FormattingEnabled = true;
            this.cobCodeFrame.Items.AddRange(new object[] {
            "简单三层结构",
            "工厂模式三层结构"});
            this.cobCodeFrame.Location = new System.Drawing.Point(93, 24);
            this.cobCodeFrame.Name = "cobCodeFrame";
            this.cobCodeFrame.Size = new System.Drawing.Size(114, 20);
            this.cobCodeFrame.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "缓存结构";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "命名空间前缀";
            // 
            // cobDALFrame
            // 
            this.cobDALFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDALFrame.FormattingEnabled = true;
            this.cobDALFrame.Items.AddRange(new object[] {
            "SQL语句",
            "存储过程"});
            this.cobDALFrame.Location = new System.Drawing.Point(93, 70);
            this.cobDALFrame.Name = "cobDALFrame";
            this.cobDALFrame.Size = new System.Drawing.Size(114, 20);
            this.cobDALFrame.TabIndex = 1;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(303, 22);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(124, 21);
            this.txtConnection.TabIndex = 2;
            this.txtConnection.Text = "Connection";
            // 
            // cobCacheFrame
            // 
            this.cobCacheFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCacheFrame.FormattingEnabled = true;
            this.cobCacheFrame.Items.AddRange(new object[] {
            "不使用",
            "简单缓存对象",
            "聚合缓存依赖"});
            this.cobCacheFrame.Location = new System.Drawing.Point(93, 47);
            this.cobCacheFrame.Name = "cobCacheFrame";
            this.cobCacheFrame.Size = new System.Drawing.Size(114, 20);
            this.cobCacheFrame.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "数据库连接名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "数据库读写";
            // 
            // tcCodes
            // 
            this.tcCodes.Controls.Add(this.tpModel);
            this.tcCodes.Controls.Add(this.tpDBUtility);
            this.tcCodes.Controls.Add(this.tpIDAL);
            this.tcCodes.Controls.Add(this.tpDAL);
            this.tcCodes.Controls.Add(this.tpDALFactory);
            this.tcCodes.Controls.Add(this.tpICacheDependency);
            this.tcCodes.Controls.Add(this.tpTableDependency);
            this.tcCodes.Controls.Add(this.tpTableCacheDependency);
            this.tcCodes.Controls.Add(this.tpDependencyAccess);
            this.tcCodes.Controls.Add(this.tpDependencyFacade);
            this.tcCodes.Controls.Add(this.tpBLL);
            this.tcCodes.Controls.Add(this.tpUserControl);
            this.tcCodes.Controls.Add(this.tpUserControlCs);
            this.tcCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCodes.Location = new System.Drawing.Point(0, 109);
            this.tcCodes.Name = "tcCodes";
            this.tcCodes.SelectedIndex = 0;
            this.tcCodes.Size = new System.Drawing.Size(615, 336);
            this.tcCodes.TabIndex = 2;
            // 
            // tpModel
            // 
            this.tpModel.Controls.Add(this.txtModel);
            this.tpModel.Location = new System.Drawing.Point(4, 21);
            this.tpModel.Name = "tpModel";
            this.tpModel.Padding = new System.Windows.Forms.Padding(3);
            this.tpModel.Size = new System.Drawing.Size(607, 311);
            this.tpModel.TabIndex = 0;
            this.tpModel.Text = "Model";
            this.tpModel.UseVisualStyleBackColor = true;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.Encoding = ((System.Text.Encoding)(resources.GetObject("txtModel.Encoding")));
            this.txtModel.Location = new System.Drawing.Point(3, 3);
            this.txtModel.Name = "txtModel";
            this.txtModel.ShowEOLMarkers = true;
            this.txtModel.ShowInvalidLines = false;
            this.txtModel.ShowSpaces = true;
            this.txtModel.ShowTabs = true;
            this.txtModel.ShowVRuler = true;
            this.txtModel.Size = new System.Drawing.Size(601, 305);
            this.txtModel.TabIndex = 0;
            // 
            // tpDBUtility
            // 
            this.tpDBUtility.Controls.Add(this.txtDBUtility);
            this.tpDBUtility.Location = new System.Drawing.Point(4, 21);
            this.tpDBUtility.Name = "tpDBUtility";
            this.tpDBUtility.Size = new System.Drawing.Size(607, 311);
            this.tpDBUtility.TabIndex = 3;
            this.tpDBUtility.Text = "DBUtility";
            this.tpDBUtility.UseVisualStyleBackColor = true;
            // 
            // txtDBUtility
            // 
            this.txtDBUtility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDBUtility.Encoding = ((System.Text.Encoding)(resources.GetObject("txtDBUtility.Encoding")));
            this.txtDBUtility.Location = new System.Drawing.Point(0, 0);
            this.txtDBUtility.Name = "txtDBUtility";
            this.txtDBUtility.ShowEOLMarkers = true;
            this.txtDBUtility.ShowInvalidLines = false;
            this.txtDBUtility.ShowSpaces = true;
            this.txtDBUtility.ShowTabs = true;
            this.txtDBUtility.ShowVRuler = true;
            this.txtDBUtility.Size = new System.Drawing.Size(607, 311);
            this.txtDBUtility.TabIndex = 1;
            // 
            // tpIDAL
            // 
            this.tpIDAL.Controls.Add(this.txtIDAL);
            this.tpIDAL.Location = new System.Drawing.Point(4, 21);
            this.tpIDAL.Name = "tpIDAL";
            this.tpIDAL.Padding = new System.Windows.Forms.Padding(3);
            this.tpIDAL.Size = new System.Drawing.Size(607, 311);
            this.tpIDAL.TabIndex = 1;
            this.tpIDAL.Text = "IDAL";
            this.tpIDAL.UseVisualStyleBackColor = true;
            // 
            // txtIDAL
            // 
            this.txtIDAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIDAL.Encoding = ((System.Text.Encoding)(resources.GetObject("txtIDAL.Encoding")));
            this.txtIDAL.Location = new System.Drawing.Point(3, 3);
            this.txtIDAL.Name = "txtIDAL";
            this.txtIDAL.ShowEOLMarkers = true;
            this.txtIDAL.ShowInvalidLines = false;
            this.txtIDAL.ShowSpaces = true;
            this.txtIDAL.ShowTabs = true;
            this.txtIDAL.ShowVRuler = true;
            this.txtIDAL.Size = new System.Drawing.Size(601, 305);
            this.txtIDAL.TabIndex = 1;
            // 
            // tpDAL
            // 
            this.tpDAL.Controls.Add(this.txtDAL);
            this.tpDAL.Location = new System.Drawing.Point(4, 21);
            this.tpDAL.Name = "tpDAL";
            this.tpDAL.Size = new System.Drawing.Size(607, 311);
            this.tpDAL.TabIndex = 2;
            this.tpDAL.Text = "DAL";
            this.tpDAL.UseVisualStyleBackColor = true;
            // 
            // txtDAL
            // 
            this.txtDAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDAL.Encoding = ((System.Text.Encoding)(resources.GetObject("txtDAL.Encoding")));
            this.txtDAL.Location = new System.Drawing.Point(0, 0);
            this.txtDAL.Name = "txtDAL";
            this.txtDAL.ShowEOLMarkers = true;
            this.txtDAL.ShowInvalidLines = false;
            this.txtDAL.ShowSpaces = true;
            this.txtDAL.ShowTabs = true;
            this.txtDAL.ShowVRuler = true;
            this.txtDAL.Size = new System.Drawing.Size(607, 311);
            this.txtDAL.TabIndex = 1;
            // 
            // tpDALFactory
            // 
            this.tpDALFactory.Controls.Add(this.txtDALFactory);
            this.tpDALFactory.Location = new System.Drawing.Point(4, 21);
            this.tpDALFactory.Name = "tpDALFactory";
            this.tpDALFactory.Size = new System.Drawing.Size(607, 311);
            this.tpDALFactory.TabIndex = 5;
            this.tpDALFactory.Text = "DALFactory";
            this.tpDALFactory.UseVisualStyleBackColor = true;
            // 
            // txtDALFactory
            // 
            this.txtDALFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDALFactory.Encoding = ((System.Text.Encoding)(resources.GetObject("txtDALFactory.Encoding")));
            this.txtDALFactory.Location = new System.Drawing.Point(0, 0);
            this.txtDALFactory.Name = "txtDALFactory";
            this.txtDALFactory.ShowEOLMarkers = true;
            this.txtDALFactory.ShowInvalidLines = false;
            this.txtDALFactory.ShowSpaces = true;
            this.txtDALFactory.ShowTabs = true;
            this.txtDALFactory.ShowVRuler = true;
            this.txtDALFactory.Size = new System.Drawing.Size(607, 311);
            this.txtDALFactory.TabIndex = 1;
            // 
            // tpICacheDependency
            // 
            this.tpICacheDependency.Controls.Add(this.txtICacheDependency);
            this.tpICacheDependency.Location = new System.Drawing.Point(4, 21);
            this.tpICacheDependency.Name = "tpICacheDependency";
            this.tpICacheDependency.Padding = new System.Windows.Forms.Padding(3);
            this.tpICacheDependency.Size = new System.Drawing.Size(607, 311);
            this.tpICacheDependency.TabIndex = 8;
            this.tpICacheDependency.Text = "ICacheDependency";
            this.tpICacheDependency.UseVisualStyleBackColor = true;
            // 
            // txtICacheDependency
            // 
            this.txtICacheDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtICacheDependency.Encoding = ((System.Text.Encoding)(resources.GetObject("txtICacheDependency.Encoding")));
            this.txtICacheDependency.Location = new System.Drawing.Point(3, 3);
            this.txtICacheDependency.Name = "txtICacheDependency";
            this.txtICacheDependency.ShowEOLMarkers = true;
            this.txtICacheDependency.ShowInvalidLines = false;
            this.txtICacheDependency.ShowSpaces = true;
            this.txtICacheDependency.ShowTabs = true;
            this.txtICacheDependency.ShowVRuler = true;
            this.txtICacheDependency.Size = new System.Drawing.Size(601, 305);
            this.txtICacheDependency.TabIndex = 2;
            // 
            // tpTableDependency
            // 
            this.tpTableDependency.Controls.Add(this.txtTableDependency);
            this.tpTableDependency.Location = new System.Drawing.Point(4, 21);
            this.tpTableDependency.Name = "tpTableDependency";
            this.tpTableDependency.Size = new System.Drawing.Size(607, 311);
            this.tpTableDependency.TabIndex = 10;
            this.tpTableDependency.Text = "TableDependency";
            this.tpTableDependency.UseVisualStyleBackColor = true;
            // 
            // txtTableDependency
            // 
            this.txtTableDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableDependency.Encoding = ((System.Text.Encoding)(resources.GetObject("txtTableDependency.Encoding")));
            this.txtTableDependency.Location = new System.Drawing.Point(0, 0);
            this.txtTableDependency.Name = "txtTableDependency";
            this.txtTableDependency.ShowEOLMarkers = true;
            this.txtTableDependency.ShowInvalidLines = false;
            this.txtTableDependency.ShowSpaces = true;
            this.txtTableDependency.ShowTabs = true;
            this.txtTableDependency.ShowVRuler = true;
            this.txtTableDependency.Size = new System.Drawing.Size(607, 311);
            this.txtTableDependency.TabIndex = 3;
            // 
            // tpTableCacheDependency
            // 
            this.tpTableCacheDependency.Controls.Add(this.txtTableCacheDependency);
            this.tpTableCacheDependency.Location = new System.Drawing.Point(4, 21);
            this.tpTableCacheDependency.Name = "tpTableCacheDependency";
            this.tpTableCacheDependency.Size = new System.Drawing.Size(607, 311);
            this.tpTableCacheDependency.TabIndex = 9;
            this.tpTableCacheDependency.Text = "TableCacheDependency";
            this.tpTableCacheDependency.UseVisualStyleBackColor = true;
            // 
            // txtTableCacheDependency
            // 
            this.txtTableCacheDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTableCacheDependency.Encoding = ((System.Text.Encoding)(resources.GetObject("txtTableCacheDependency.Encoding")));
            this.txtTableCacheDependency.Location = new System.Drawing.Point(0, 0);
            this.txtTableCacheDependency.Name = "txtTableCacheDependency";
            this.txtTableCacheDependency.ShowEOLMarkers = true;
            this.txtTableCacheDependency.ShowInvalidLines = false;
            this.txtTableCacheDependency.ShowSpaces = true;
            this.txtTableCacheDependency.ShowTabs = true;
            this.txtTableCacheDependency.ShowVRuler = true;
            this.txtTableCacheDependency.Size = new System.Drawing.Size(607, 311);
            this.txtTableCacheDependency.TabIndex = 3;
            // 
            // tpDependencyAccess
            // 
            this.tpDependencyAccess.Controls.Add(this.txtDependencyAccess);
            this.tpDependencyAccess.Location = new System.Drawing.Point(4, 21);
            this.tpDependencyAccess.Name = "tpDependencyAccess";
            this.tpDependencyAccess.Size = new System.Drawing.Size(607, 311);
            this.tpDependencyAccess.TabIndex = 11;
            this.tpDependencyAccess.Text = "DependencyAccess";
            this.tpDependencyAccess.UseVisualStyleBackColor = true;
            // 
            // txtDependencyAccess
            // 
            this.txtDependencyAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDependencyAccess.Encoding = ((System.Text.Encoding)(resources.GetObject("txtDependencyAccess.Encoding")));
            this.txtDependencyAccess.Location = new System.Drawing.Point(0, 0);
            this.txtDependencyAccess.Name = "txtDependencyAccess";
            this.txtDependencyAccess.ShowEOLMarkers = true;
            this.txtDependencyAccess.ShowInvalidLines = false;
            this.txtDependencyAccess.ShowSpaces = true;
            this.txtDependencyAccess.ShowTabs = true;
            this.txtDependencyAccess.ShowVRuler = true;
            this.txtDependencyAccess.Size = new System.Drawing.Size(607, 311);
            this.txtDependencyAccess.TabIndex = 3;
            // 
            // tpDependencyFacade
            // 
            this.tpDependencyFacade.Controls.Add(this.txtDependencyFacade);
            this.tpDependencyFacade.Location = new System.Drawing.Point(4, 21);
            this.tpDependencyFacade.Name = "tpDependencyFacade";
            this.tpDependencyFacade.Size = new System.Drawing.Size(607, 311);
            this.tpDependencyFacade.TabIndex = 12;
            this.tpDependencyFacade.Text = "DependencyFacade";
            this.tpDependencyFacade.UseVisualStyleBackColor = true;
            // 
            // txtDependencyFacade
            // 
            this.txtDependencyFacade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDependencyFacade.Encoding = ((System.Text.Encoding)(resources.GetObject("txtDependencyFacade.Encoding")));
            this.txtDependencyFacade.Location = new System.Drawing.Point(0, 0);
            this.txtDependencyFacade.Name = "txtDependencyFacade";
            this.txtDependencyFacade.ShowEOLMarkers = true;
            this.txtDependencyFacade.ShowInvalidLines = false;
            this.txtDependencyFacade.ShowSpaces = true;
            this.txtDependencyFacade.ShowTabs = true;
            this.txtDependencyFacade.ShowVRuler = true;
            this.txtDependencyFacade.Size = new System.Drawing.Size(607, 311);
            this.txtDependencyFacade.TabIndex = 4;
            // 
            // tpBLL
            // 
            this.tpBLL.Controls.Add(this.txtBLL);
            this.tpBLL.Location = new System.Drawing.Point(4, 21);
            this.tpBLL.Name = "tpBLL";
            this.tpBLL.Size = new System.Drawing.Size(607, 311);
            this.tpBLL.TabIndex = 4;
            this.tpBLL.Text = "BLL";
            this.tpBLL.UseVisualStyleBackColor = true;
            // 
            // txtBLL
            // 
            this.txtBLL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBLL.Encoding = ((System.Text.Encoding)(resources.GetObject("txtBLL.Encoding")));
            this.txtBLL.Location = new System.Drawing.Point(0, 0);
            this.txtBLL.Name = "txtBLL";
            this.txtBLL.ShowEOLMarkers = true;
            this.txtBLL.ShowInvalidLines = false;
            this.txtBLL.ShowSpaces = true;
            this.txtBLL.ShowTabs = true;
            this.txtBLL.ShowVRuler = true;
            this.txtBLL.Size = new System.Drawing.Size(607, 311);
            this.txtBLL.TabIndex = 1;
            // 
            // tpUserControl
            // 
            this.tpUserControl.Controls.Add(this.txtUserControl);
            this.tpUserControl.Location = new System.Drawing.Point(4, 21);
            this.tpUserControl.Name = "tpUserControl";
            this.tpUserControl.Size = new System.Drawing.Size(607, 311);
            this.tpUserControl.TabIndex = 6;
            this.tpUserControl.Text = "用户控件";
            this.tpUserControl.UseVisualStyleBackColor = true;
            // 
            // txtUserControl
            // 
            this.txtUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserControl.Encoding = ((System.Text.Encoding)(resources.GetObject("txtUserControl.Encoding")));
            this.txtUserControl.Location = new System.Drawing.Point(0, 0);
            this.txtUserControl.Name = "txtUserControl";
            this.txtUserControl.ShowEOLMarkers = true;
            this.txtUserControl.ShowInvalidLines = false;
            this.txtUserControl.ShowSpaces = true;
            this.txtUserControl.ShowTabs = true;
            this.txtUserControl.ShowVRuler = true;
            this.txtUserControl.Size = new System.Drawing.Size(607, 311);
            this.txtUserControl.TabIndex = 2;
            // 
            // tpUserControlCs
            // 
            this.tpUserControlCs.Controls.Add(this.txtUserControlCs);
            this.tpUserControlCs.Location = new System.Drawing.Point(4, 21);
            this.tpUserControlCs.Name = "tpUserControlCs";
            this.tpUserControlCs.Size = new System.Drawing.Size(607, 311);
            this.tpUserControlCs.TabIndex = 7;
            this.tpUserControlCs.Text = "用户控件后台";
            this.tpUserControlCs.UseVisualStyleBackColor = true;
            // 
            // txtUserControlCs
            // 
            this.txtUserControlCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserControlCs.Encoding = ((System.Text.Encoding)(resources.GetObject("txtUserControlCs.Encoding")));
            this.txtUserControlCs.Location = new System.Drawing.Point(0, 0);
            this.txtUserControlCs.Name = "txtUserControlCs";
            this.txtUserControlCs.ShowEOLMarkers = true;
            this.txtUserControlCs.ShowInvalidLines = false;
            this.txtUserControlCs.ShowSpaces = true;
            this.txtUserControlCs.ShowTabs = true;
            this.txtUserControlCs.ShowVRuler = true;
            this.txtUserControlCs.Size = new System.Drawing.Size(607, 311);
            this.txtUserControlCs.TabIndex = 3;
            // 
            // FormCodeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 445);
            this.Controls.Add(this.tcCodes);
            this.Controls.Add(this.panel1);
            this.Name = "FormCodeCreate";
            this.TabText = "生成代码";
            this.Text = "frmCode";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tcCodes.ResumeLayout(false);
            this.tpModel.ResumeLayout(false);
            this.tpDBUtility.ResumeLayout(false);
            this.tpIDAL.ResumeLayout(false);
            this.tpDAL.ResumeLayout(false);
            this.tpDALFactory.ResumeLayout(false);
            this.tpICacheDependency.ResumeLayout(false);
            this.tpTableDependency.ResumeLayout(false);
            this.tpTableCacheDependency.ResumeLayout(false);
            this.tpDependencyAccess.ResumeLayout(false);
            this.tpDependencyFacade.ResumeLayout(false);
            this.tpBLL.ResumeLayout(false);
            this.tpUserControl.ResumeLayout(false);
            this.tpUserControlCs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tcCodes;
        private System.Windows.Forms.TabPage tpModel;
        private ICSharpCode.TextEditor.TextEditorControl txtModel;
        private System.Windows.Forms.TabPage tpDBUtility;
        private ICSharpCode.TextEditor.TextEditorControl txtDBUtility;
        private System.Windows.Forms.TabPage tpIDAL;
        private ICSharpCode.TextEditor.TextEditorControl txtIDAL;
        private System.Windows.Forms.TabPage tpDAL;
        private ICSharpCode.TextEditor.TextEditorControl txtDAL;
        private System.Windows.Forms.TabPage tpDALFactory;
        private ICSharpCode.TextEditor.TextEditorControl txtDALFactory;
        private System.Windows.Forms.TabPage tpBLL;
        private ICSharpCode.TextEditor.TextEditorControl txtBLL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cobCodeFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobCacheFrame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tpUserControl;
        private ICSharpCode.TextEditor.TextEditorControl txtUserControl;
        private System.Windows.Forms.TabPage tpUserControlCs;
        private ICSharpCode.TextEditor.TextEditorControl txtUserControlCs;
        private System.Windows.Forms.TextBox txtAfterNamespace;
        private System.Windows.Forms.TextBox txtBeforeNamespace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tpICacheDependency;
        private ICSharpCode.TextEditor.TextEditorControl txtICacheDependency;
        private System.Windows.Forms.TabPage tpTableDependency;
        private ICSharpCode.TextEditor.TextEditorControl txtTableDependency;
        private System.Windows.Forms.TabPage tpTableCacheDependency;
        private ICSharpCode.TextEditor.TextEditorControl txtTableCacheDependency;
        private System.Windows.Forms.TabPage tpDependencyAccess;
        private ICSharpCode.TextEditor.TextEditorControl txtDependencyAccess;
        private System.Windows.Forms.TabPage tpDependencyFacade;
        private ICSharpCode.TextEditor.TextEditorControl txtDependencyFacade;
        private System.Windows.Forms.ComboBox cobDALFrame;
        private System.Windows.Forms.Label label6;

    }
}