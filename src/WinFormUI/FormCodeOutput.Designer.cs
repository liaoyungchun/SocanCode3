namespace SocanCode
{
    partial class FormCodeOutput
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnOutputCode = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOutputSp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCacheDependencyFactory = new System.Windows.Forms.CheckBox();
            this.chkTableCacheDependency = new System.Windows.Forms.CheckBox();
            this.chkICacheDependency = new System.Windows.Forms.CheckBox();
            this.cobDALFrame = new System.Windows.Forms.ComboBox();
            this.cobCacheFrame = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cobCodeFrame = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtControlsPath = new System.Windows.Forms.TextBox();
            this.txtAfterNamespace = new System.Windows.Forms.TextBox();
            this.txtBeforeNamespace = new System.Windows.Forms.TextBox();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.txtWebPath = new System.Windows.Forms.TextBox();
            this.chkUserControl = new System.Windows.Forms.CheckBox();
            this.chkBLL = new System.Windows.Forms.CheckBox();
            this.chkDBUtility = new System.Windows.Forms.CheckBox();
            this.chkModel = new System.Windows.Forms.CheckBox();
            this.chkDALFactory = new System.Windows.Forms.CheckBox();
            this.chkIDAL = new System.Windows.Forms.CheckBox();
            this.chkDAL = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstSelectedTables = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectedAll = new System.Windows.Forms.Button();
            this.btnSelected = new System.Windows.Forms.Button();
            this.btnUnSelected = new System.Windows.Forms.Button();
            this.btnUnSelectedAll = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(20, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(318, 21);
            this.txtPath.TabIndex = 0;
            this.txtPath.Text = "C:\\Documents and Settings\\Administrator\\桌面\\Template";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelectPath.Location = new System.Drawing.Point(344, 20);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(34, 23);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnOutputCode
            // 
            this.btnOutputCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOutputCode.Location = new System.Drawing.Point(384, 20);
            this.btnOutputCode.Name = "btnOutputCode";
            this.btnOutputCode.Size = new System.Drawing.Size(96, 23);
            this.btnOutputCode.TabIndex = 2;
            this.btnOutputCode.Text = "输出代码";
            this.btnOutputCode.UseVisualStyleBackColor = true;
            this.btnOutputCode.Click += new System.EventHandler(this.btnOutputCode_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 454);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(592, 19);
            this.progressBar1.TabIndex = 21;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPath);
            this.groupBox4.Controls.Add(this.btnOutputSp);
            this.groupBox4.Controls.Add(this.btnOutputCode);
            this.groupBox4.Controls.Add(this.btnSelectPath);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(592, 53);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "输出路径";
            // 
            // btnOutputSp
            // 
            this.btnOutputSp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOutputSp.Location = new System.Drawing.Point(483, 20);
            this.btnOutputSp.Name = "btnOutputSp";
            this.btnOutputSp.Size = new System.Drawing.Size(103, 23);
            this.btnOutputSp.TabIndex = 2;
            this.btnOutputSp.Text = "输出存储过程";
            this.btnOutputSp.UseVisualStyleBackColor = true;
            this.btnOutputSp.Click += new System.EventHandler(this.btnOutputSp_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 59);
            this.panel1.TabIndex = 37;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 395);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.chkCacheDependencyFactory);
            this.groupBox5.Controls.Add(this.chkTableCacheDependency);
            this.groupBox5.Controls.Add(this.chkICacheDependency);
            this.groupBox5.Controls.Add(this.cobDALFrame);
            this.groupBox5.Controls.Add(this.cobCacheFrame);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.cobCodeFrame);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtControlsPath);
            this.groupBox5.Controls.Add(this.txtAfterNamespace);
            this.groupBox5.Controls.Add(this.txtBeforeNamespace);
            this.groupBox5.Controls.Add(this.txtConnection);
            this.groupBox5.Controls.Add(this.txtWebPath);
            this.groupBox5.Controls.Add(this.chkUserControl);
            this.groupBox5.Controls.Add(this.chkBLL);
            this.groupBox5.Controls.Add(this.chkDBUtility);
            this.groupBox5.Controls.Add(this.chkModel);
            this.groupBox5.Controls.Add(this.chkDALFactory);
            this.groupBox5.Controls.Add(this.chkIDAL);
            this.groupBox5.Controls.Add(this.chkDAL);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(345, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 389);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "代码结构";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "数据库读写";
            // 
            // chkCacheDependencyFactory
            // 
            this.chkCacheDependencyFactory.AutoSize = true;
            this.chkCacheDependencyFactory.Location = new System.Drawing.Point(13, 348);
            this.chkCacheDependencyFactory.Name = "chkCacheDependencyFactory";
            this.chkCacheDependencyFactory.Size = new System.Drawing.Size(156, 16);
            this.chkCacheDependencyFactory.TabIndex = 42;
            this.chkCacheDependencyFactory.Text = "CacheDependencyFactory";
            this.chkCacheDependencyFactory.UseVisualStyleBackColor = true;
            // 
            // chkTableCacheDependency
            // 
            this.chkTableCacheDependency.AutoSize = true;
            this.chkTableCacheDependency.Location = new System.Drawing.Point(13, 325);
            this.chkTableCacheDependency.Name = "chkTableCacheDependency";
            this.chkTableCacheDependency.Size = new System.Drawing.Size(144, 16);
            this.chkTableCacheDependency.TabIndex = 41;
            this.chkTableCacheDependency.Text = "TableCacheDependency";
            this.chkTableCacheDependency.UseVisualStyleBackColor = true;
            // 
            // chkICacheDependency
            // 
            this.chkICacheDependency.AutoSize = true;
            this.chkICacheDependency.Location = new System.Drawing.Point(13, 302);
            this.chkICacheDependency.Name = "chkICacheDependency";
            this.chkICacheDependency.Size = new System.Drawing.Size(120, 16);
            this.chkICacheDependency.TabIndex = 40;
            this.chkICacheDependency.Text = "ICacheDependency";
            this.chkICacheDependency.UseVisualStyleBackColor = true;
            // 
            // cobDALFrame
            // 
            this.cobDALFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobDALFrame.FormattingEnabled = true;
            this.cobDALFrame.Items.AddRange(new object[] {
            "SQL语句",
            "存储过程"});
            this.cobDALFrame.Location = new System.Drawing.Point(138, 181);
            this.cobDALFrame.Name = "cobDALFrame";
            this.cobDALFrame.Size = new System.Drawing.Size(97, 20);
            this.cobDALFrame.TabIndex = 1;
            this.cobDALFrame.SelectedIndexChanged += new System.EventHandler(this.cobCacheFrame_SelectedIndexChanged);
            // 
            // cobCacheFrame
            // 
            this.cobCacheFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCacheFrame.FormattingEnabled = true;
            this.cobCacheFrame.Items.AddRange(new object[] {
            "不使用",
            "简单缓存对象",
            "聚合缓存依赖"});
            this.cobCacheFrame.Location = new System.Drawing.Point(94, 43);
            this.cobCacheFrame.Name = "cobCacheFrame";
            this.cobCacheFrame.Size = new System.Drawing.Size(138, 20);
            this.cobCacheFrame.TabIndex = 1;
            this.cobCacheFrame.SelectedIndexChanged += new System.EventHandler(this.cobCacheFrame_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "命名空间后缀";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "命名空间前缀";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "缓存结构";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "三层结构";
            // 
            // cobCodeFrame
            // 
            this.cobCodeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCodeFrame.FormattingEnabled = true;
            this.cobCodeFrame.Items.AddRange(new object[] {
            "简单三层结构",
            "工厂模式三层结构"});
            this.cobCodeFrame.Location = new System.Drawing.Point(94, 21);
            this.cobCodeFrame.Name = "cobCodeFrame";
            this.cobCodeFrame.Size = new System.Drawing.Size(138, 20);
            this.cobCodeFrame.TabIndex = 0;
            this.cobCodeFrame.SelectedIndexChanged += new System.EventHandler(this.cobCodeFrame_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "数据库连接名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "用户控件目录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "网页目录";
            // 
            // txtControlsPath
            // 
            this.txtControlsPath.Location = new System.Drawing.Point(136, 274);
            this.txtControlsPath.Name = "txtControlsPath";
            this.txtControlsPath.Size = new System.Drawing.Size(96, 21);
            this.txtControlsPath.TabIndex = 13;
            this.txtControlsPath.Text = "Controls";
            // 
            // txtAfterNamespace
            // 
            this.txtAfterNamespace.Location = new System.Drawing.Point(94, 88);
            this.txtAfterNamespace.Name = "txtAfterNamespace";
            this.txtAfterNamespace.Size = new System.Drawing.Size(138, 21);
            this.txtAfterNamespace.TabIndex = 3;
            // 
            // txtBeforeNamespace
            // 
            this.txtBeforeNamespace.Location = new System.Drawing.Point(94, 65);
            this.txtBeforeNamespace.Name = "txtBeforeNamespace";
            this.txtBeforeNamespace.Size = new System.Drawing.Size(138, 21);
            this.txtBeforeNamespace.TabIndex = 2;
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(138, 156);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(96, 21);
            this.txtConnection.TabIndex = 8;
            this.txtConnection.Text = "Connection";
            // 
            // txtWebPath
            // 
            this.txtWebPath.Location = new System.Drawing.Point(136, 248);
            this.txtWebPath.Name = "txtWebPath";
            this.txtWebPath.Size = new System.Drawing.Size(96, 21);
            this.txtWebPath.TabIndex = 12;
            this.txtWebPath.Text = "Web";
            // 
            // chkUserControl
            // 
            this.chkUserControl.AutoSize = true;
            this.chkUserControl.Checked = true;
            this.chkUserControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserControl.Location = new System.Drawing.Point(13, 229);
            this.chkUserControl.Name = "chkUserControl";
            this.chkUserControl.Size = new System.Drawing.Size(72, 16);
            this.chkUserControl.TabIndex = 11;
            this.chkUserControl.Text = "用户控件";
            this.chkUserControl.UseVisualStyleBackColor = true;
            this.chkUserControl.CheckedChanged += new System.EventHandler(this.chkUserControl_CheckedChanged);
            // 
            // chkBLL
            // 
            this.chkBLL.AutoSize = true;
            this.chkBLL.Checked = true;
            this.chkBLL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBLL.Location = new System.Drawing.Point(109, 207);
            this.chkBLL.Name = "chkBLL";
            this.chkBLL.Size = new System.Drawing.Size(42, 16);
            this.chkBLL.TabIndex = 10;
            this.chkBLL.Text = "BLL";
            this.chkBLL.UseVisualStyleBackColor = true;
            // 
            // chkDBUtility
            // 
            this.chkDBUtility.AutoSize = true;
            this.chkDBUtility.Checked = true;
            this.chkDBUtility.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDBUtility.Location = new System.Drawing.Point(13, 119);
            this.chkDBUtility.Name = "chkDBUtility";
            this.chkDBUtility.Size = new System.Drawing.Size(78, 16);
            this.chkDBUtility.TabIndex = 4;
            this.chkDBUtility.Text = "DBUtility";
            this.chkDBUtility.UseVisualStyleBackColor = true;
            // 
            // chkModel
            // 
            this.chkModel.AutoSize = true;
            this.chkModel.Checked = true;
            this.chkModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModel.Location = new System.Drawing.Point(97, 119);
            this.chkModel.Name = "chkModel";
            this.chkModel.Size = new System.Drawing.Size(54, 16);
            this.chkModel.TabIndex = 5;
            this.chkModel.Text = "Model";
            this.chkModel.UseVisualStyleBackColor = true;
            // 
            // chkDALFactory
            // 
            this.chkDALFactory.AutoSize = true;
            this.chkDALFactory.Location = new System.Drawing.Point(13, 207);
            this.chkDALFactory.Name = "chkDALFactory";
            this.chkDALFactory.Size = new System.Drawing.Size(84, 16);
            this.chkDALFactory.TabIndex = 9;
            this.chkDALFactory.Text = "DALFactory";
            this.chkDALFactory.UseVisualStyleBackColor = true;
            // 
            // chkIDAL
            // 
            this.chkIDAL.AutoSize = true;
            this.chkIDAL.Location = new System.Drawing.Point(170, 119);
            this.chkIDAL.Name = "chkIDAL";
            this.chkIDAL.Size = new System.Drawing.Size(48, 16);
            this.chkIDAL.TabIndex = 6;
            this.chkIDAL.Text = "IDAL";
            this.chkIDAL.UseVisualStyleBackColor = true;
            // 
            // chkDAL
            // 
            this.chkDAL.AutoSize = true;
            this.chkDAL.Checked = true;
            this.chkDAL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDAL.Location = new System.Drawing.Point(13, 138);
            this.chkDAL.Name = "chkDAL";
            this.chkDAL.Size = new System.Drawing.Size(42, 16);
            this.chkDAL.TabIndex = 7;
            this.chkDAL.Text = "DAL";
            this.chkDAL.UseVisualStyleBackColor = true;
            this.chkDAL.CheckedChanged += new System.EventHandler(this.chkDAL_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstSelectedTables);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(199, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 389);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要输出代码的表";
            // 
            // lstSelectedTables
            // 
            this.lstSelectedTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedTables.FormattingEnabled = true;
            this.lstSelectedTables.ItemHeight = 12;
            this.lstSelectedTables.Location = new System.Drawing.Point(3, 17);
            this.lstSelectedTables.Name = "lstSelectedTables";
            this.lstSelectedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedTables.Size = new System.Drawing.Size(134, 364);
            this.lstSelectedTables.TabIndex = 0;
            this.lstSelectedTables.DoubleClick += new System.EventHandler(this.btnUnSelected_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTables);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 389);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库中的表";
            // 
            // lstTables
            // 
            this.lstTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.ItemHeight = 12;
            this.lstTables.Location = new System.Drawing.Point(3, 17);
            this.lstTables.Name = "lstTables";
            this.lstTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTables.Size = new System.Drawing.Size(134, 364);
            this.lstTables.TabIndex = 0;
            this.lstTables.DoubleClick += new System.EventHandler(this.btnSelected_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectedAll, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSelected, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnUnSelected, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnUnSelectedAll, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(149, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(44, 389);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnSelectedAll
            // 
            this.btnSelectedAll.Location = new System.Drawing.Point(3, 147);
            this.btnSelectedAll.Name = "btnSelectedAll";
            this.btnSelectedAll.Size = new System.Drawing.Size(38, 44);
            this.btnSelectedAll.TabIndex = 1;
            this.btnSelectedAll.Text = ">>";
            this.btnSelectedAll.UseVisualStyleBackColor = true;
            this.btnSelectedAll.Click += new System.EventHandler(this.btnSelectedAll_Click);
            // 
            // btnSelected
            // 
            this.btnSelected.Location = new System.Drawing.Point(3, 97);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(38, 44);
            this.btnSelected.TabIndex = 0;
            this.btnSelected.Text = ">";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // btnUnSelected
            // 
            this.btnUnSelected.Location = new System.Drawing.Point(3, 197);
            this.btnUnSelected.Name = "btnUnSelected";
            this.btnUnSelected.Size = new System.Drawing.Size(38, 44);
            this.btnUnSelected.TabIndex = 2;
            this.btnUnSelected.Text = "<";
            this.btnUnSelected.UseVisualStyleBackColor = true;
            this.btnUnSelected.Click += new System.EventHandler(this.btnUnSelected_Click);
            // 
            // btnUnSelectedAll
            // 
            this.btnUnSelectedAll.Location = new System.Drawing.Point(3, 247);
            this.btnUnSelectedAll.Name = "btnUnSelectedAll";
            this.btnUnSelectedAll.Size = new System.Drawing.Size(38, 44);
            this.btnUnSelectedAll.TabIndex = 3;
            this.btnUnSelectedAll.Text = "<<";
            this.btnUnSelectedAll.UseVisualStyleBackColor = true;
            this.btnUnSelectedAll.Click += new System.EventHandler(this.btnUnSelectedAll_Click);
            // 
            // FormCodeOutput
            // 
            this.AcceptButton = this.btnOutputCode;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "FormCodeOutput";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "输出代码";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnOutputCode;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtControlsPath;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.TextBox txtWebPath;
        private System.Windows.Forms.CheckBox chkUserControl;
        private System.Windows.Forms.CheckBox chkBLL;
        private System.Windows.Forms.CheckBox chkDBUtility;
        private System.Windows.Forms.CheckBox chkModel;
        private System.Windows.Forms.CheckBox chkDALFactory;
        private System.Windows.Forms.CheckBox chkIDAL;
        private System.Windows.Forms.CheckBox chkDAL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstSelectedTables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSelectedAll;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button btnUnSelected;
        private System.Windows.Forms.Button btnUnSelectedAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cobCodeFrame;
        private System.Windows.Forms.ComboBox cobCacheFrame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAfterNamespace;
        private System.Windows.Forms.TextBox txtBeforeNamespace;
        private System.Windows.Forms.CheckBox chkCacheDependencyFactory;
        private System.Windows.Forms.CheckBox chkTableCacheDependency;
        private System.Windows.Forms.CheckBox chkICacheDependency;
        private System.Windows.Forms.ComboBox cobDALFrame;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOutputSp;
    }
}

