namespace SocanCode
{
    partial class FormDatabase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabase));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddDatabase = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tvDatabase = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnableDatabaseForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisableDatabaseForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnableAllTablesForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisableAllTablesForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCreateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateStoreProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEnableTableForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisableTableForSqlCacheDependency = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewStoreProcedure = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDatabase,
            this.btnDelete,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(248, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Image = global::SocanCode.Properties.Resources.PublishPlanHS;
            this.btnAddDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(49, 22);
            this.btnAddDatabase.Text = "新增";
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::SocanCode.Properties.Resources.DeleteHS;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.menuDeleteDatabase_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::SocanCode.Properties.Resources.RepeatHS;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.ToolTipText = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tvDatabase
            // 
            this.tvDatabase.ContextMenuStrip = this.contextMenuStrip1;
            this.tvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDatabase.ImageIndex = 0;
            this.tvDatabase.ImageList = this.imageList1;
            this.tvDatabase.Location = new System.Drawing.Point(0, 25);
            this.tvDatabase.Name = "tvDatabase";
            this.tvDatabase.SelectedImageIndex = 0;
            this.tvDatabase.Size = new System.Drawing.Size(248, 423);
            this.tvDatabase.TabIndex = 1;
            this.tvDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDatabase_AfterSelect);
            this.tvDatabase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvDatabase_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOutput,
            this.menuEnableDatabaseForSqlCacheDependency,
            this.menuDisableDatabaseForSqlCacheDependency,
            this.menuEnableAllTablesForSqlCacheDependency,
            this.menuDisableAllTablesForSqlCacheDependency,
            this.menuDeleteDatabase,
            this.toolStripMenuItem1,
            this.menuCreateCode,
            this.menuCreateStoreProcedure,
            this.menuEnableTableForSqlCacheDependency,
            this.menuDisableTableForSqlCacheDependency,
            this.toolStripMenuItem2,
            this.menuViewStoreProcedure});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 280);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menuOutput
            // 
            this.menuOutput.Name = "menuOutput";
            this.menuOutput.Size = new System.Drawing.Size(208, 22);
            this.menuOutput.Text = "输出代码/存储过程";
            this.menuOutput.Click += new System.EventHandler(this.menuOutput_Click);
            // 
            // menuEnableDatabaseForSqlCacheDependency
            // 
            this.menuEnableDatabaseForSqlCacheDependency.Name = "menuEnableDatabaseForSqlCacheDependency";
            this.menuEnableDatabaseForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuEnableDatabaseForSqlCacheDependency.Text = "为SQL缓存依赖启用该库";
            this.menuEnableDatabaseForSqlCacheDependency.Click += new System.EventHandler(this.menuEnableDatabaseForSqlCacheDependency_Click);
            // 
            // menuDisableDatabaseForSqlCacheDependency
            // 
            this.menuDisableDatabaseForSqlCacheDependency.Name = "menuDisableDatabaseForSqlCacheDependency";
            this.menuDisableDatabaseForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuDisableDatabaseForSqlCacheDependency.Text = "为SQL缓存依赖禁用该库";
            this.menuDisableDatabaseForSqlCacheDependency.Click += new System.EventHandler(this.menuDisableDatabaseForSqlCacheDependency_Click);
            // 
            // menuEnableAllTablesForSqlCacheDependency
            // 
            this.menuEnableAllTablesForSqlCacheDependency.Name = "menuEnableAllTablesForSqlCacheDependency";
            this.menuEnableAllTablesForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuEnableAllTablesForSqlCacheDependency.Text = "为SQL缓存依赖启用所有表";
            this.menuEnableAllTablesForSqlCacheDependency.Click += new System.EventHandler(this.menuEnableAllTablesForSqlCacheDependency_Click);
            // 
            // menuDisableAllTablesForSqlCacheDependency
            // 
            this.menuDisableAllTablesForSqlCacheDependency.Name = "menuDisableAllTablesForSqlCacheDependency";
            this.menuDisableAllTablesForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuDisableAllTablesForSqlCacheDependency.Text = "为SQL缓存依赖禁用所有表";
            this.menuDisableAllTablesForSqlCacheDependency.Click += new System.EventHandler(this.menuDisableAllTablesForSqlCacheDependency_Click);
            // 
            // menuDeleteDatabase
            // 
            this.menuDeleteDatabase.Name = "menuDeleteDatabase";
            this.menuDeleteDatabase.Size = new System.Drawing.Size(208, 22);
            this.menuDeleteDatabase.Text = "删除";
            this.menuDeleteDatabase.Click += new System.EventHandler(this.menuDeleteDatabase_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // menuCreateCode
            // 
            this.menuCreateCode.Name = "menuCreateCode";
            this.menuCreateCode.Size = new System.Drawing.Size(208, 22);
            this.menuCreateCode.Text = "生成代码";
            this.menuCreateCode.Click += new System.EventHandler(this.menuCreateCode_Click);
            // 
            // menuCreateStoreProcedure
            // 
            this.menuCreateStoreProcedure.Name = "menuCreateStoreProcedure";
            this.menuCreateStoreProcedure.Size = new System.Drawing.Size(208, 22);
            this.menuCreateStoreProcedure.Text = "生成存储过程";
            this.menuCreateStoreProcedure.Click += new System.EventHandler(this.menuCreateStoreProcedure_Click);
            // 
            // menuEnableTableForSqlCacheDependency
            // 
            this.menuEnableTableForSqlCacheDependency.Name = "menuEnableTableForSqlCacheDependency";
            this.menuEnableTableForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuEnableTableForSqlCacheDependency.Text = "为SQL缓存依赖启用该表";
            this.menuEnableTableForSqlCacheDependency.Click += new System.EventHandler(this.menuEnableTableForSqlCacheDependency_Click);
            // 
            // menuDisableTableForSqlCacheDependency
            // 
            this.menuDisableTableForSqlCacheDependency.Name = "menuDisableTableForSqlCacheDependency";
            this.menuDisableTableForSqlCacheDependency.Size = new System.Drawing.Size(208, 22);
            this.menuDisableTableForSqlCacheDependency.Text = "为SQL缓存依赖禁用该表";
            this.menuDisableTableForSqlCacheDependency.Click += new System.EventHandler(this.menuDisableTableForSqlCacheDependency_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
            // 
            // menuViewStoreProcedure
            // 
            this.menuViewStoreProcedure.Name = "menuViewStoreProcedure";
            this.menuViewStoreProcedure.Size = new System.Drawing.Size(208, 22);
            this.menuViewStoreProcedure.Text = "查看存储过程";
            this.menuViewStoreProcedure.Click += new System.EventHandler(this.menuViewStoreProcedure_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "db.gif");
            this.imageList1.Images.SetKeyName(1, "folder.gif");
            this.imageList1.Images.SetKeyName(2, "table.gif");
            this.imageList1.Images.SetKeyName(3, "field.gif");
            this.imageList1.Images.SetKeyName(4, "view.gif");
            this.imageList1.Images.SetKeyName(5, "sp.gif");
            this.imageList1.Images.SetKeyName(6, "parameter.gif");
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 448);
            this.Controls.Add(this.tvDatabase);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "FormDatabase";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "数据库资源管理器";
            this.Text = "数据库资源管理器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddDatabase;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuOutput;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteDatabase;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.TreeView tvDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuEnableDatabaseForSqlCacheDependency;
        private System.Windows.Forms.ToolStripMenuItem menuEnableAllTablesForSqlCacheDependency;
        private System.Windows.Forms.ToolStripMenuItem menuEnableTableForSqlCacheDependency;
        private System.Windows.Forms.ToolStripMenuItem menuDisableDatabaseForSqlCacheDependency;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuDisableAllTablesForSqlCacheDependency;
        private System.Windows.Forms.ToolStripMenuItem menuDisableTableForSqlCacheDependency;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuViewStoreProcedure;
        private System.Windows.Forms.ToolStripMenuItem menuCreateStoreProcedure;

    }
}