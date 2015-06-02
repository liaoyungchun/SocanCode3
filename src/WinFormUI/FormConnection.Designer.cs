namespace SocanCode
{
    partial class FormConnection
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtDbstr = new System.Windows.Forms.TextBox();
            this.btnSetConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbDbType = new System.Windows.Forms.GroupBox();
            this.rbAccess = new System.Windows.Forms.RadioButton();
            this.rbSql2000 = new System.Windows.Forms.RadioButton();
            this.rbSql2005 = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.gbDbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtDbstr);
            this.groupBox3.Controls.Add(this.btnSetConnect);
            this.groupBox3.Location = new System.Drawing.Point(113, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 104);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库连接";
            // 
            // TxtDbstr
            // 
            this.TxtDbstr.Location = new System.Drawing.Point(16, 25);
            this.TxtDbstr.Multiline = true;
            this.TxtDbstr.Name = "TxtDbstr";
            this.TxtDbstr.Size = new System.Drawing.Size(306, 67);
            this.TxtDbstr.TabIndex = 14;
            this.TxtDbstr.Text = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data " +
                "Source=.";
            // 
            // btnSetConnect
            // 
            this.btnSetConnect.Location = new System.Drawing.Point(328, 67);
            this.btnSetConnect.Name = "btnSetConnect";
            this.btnSetConnect.Size = new System.Drawing.Size(33, 23);
            this.btnSetConnect.TabIndex = 13;
            this.btnSetConnect.Text = "...";
            this.btnSetConnect.UseVisualStyleBackColor = true;
            this.btnSetConnect.Click += new System.EventHandler(this.btnSetConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(321, 187);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(399, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBox1.Location = new System.Drawing.Point(12, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(476, 38);
            this.textBox1.TabIndex = 33;
            this.textBox1.Text = "请选择正确的数据库类型，如果类型与实际的连接不一致将导致连接失败！\r\n\r\n如果是SQLServer，建议使用Windows验证，如果要用用户名和密码验证请勾选\"记" +
                "住密码\"";
            // 
            // gbDbType
            // 
            this.gbDbType.Controls.Add(this.rbSql2005);
            this.gbDbType.Controls.Add(this.rbSql2000);
            this.gbDbType.Controls.Add(this.rbAccess);
            this.gbDbType.Location = new System.Drawing.Point(12, 76);
            this.gbDbType.Name = "gbDbType";
            this.gbDbType.Size = new System.Drawing.Size(88, 103);
            this.gbDbType.TabIndex = 34;
            this.gbDbType.TabStop = false;
            this.gbDbType.Text = "数据库类型";
            // 
            // rbAccess
            // 
            this.rbAccess.AutoSize = true;
            this.rbAccess.Location = new System.Drawing.Point(16, 26);
            this.rbAccess.Name = "rbAccess";
            this.rbAccess.Size = new System.Drawing.Size(59, 16);
            this.rbAccess.TabIndex = 0;
            this.rbAccess.Text = "ACCESS";
            this.rbAccess.UseVisualStyleBackColor = true;
            // 
            // rbSql2000
            // 
            this.rbSql2000.AutoSize = true;
            this.rbSql2000.Checked = true;
            this.rbSql2000.Location = new System.Drawing.Point(16, 48);
            this.rbSql2000.Name = "rbSql2000";
            this.rbSql2000.Size = new System.Drawing.Size(65, 16);
            this.rbSql2000.TabIndex = 1;
            this.rbSql2000.TabStop = true;
            this.rbSql2000.Text = "SQL2000";
            this.rbSql2000.UseVisualStyleBackColor = true;
            // 
            // rbSql2005
            // 
            this.rbSql2005.AutoSize = true;
            this.rbSql2005.Location = new System.Drawing.Point(16, 70);
            this.rbSql2005.Name = "rbSql2005";
            this.rbSql2005.Size = new System.Drawing.Size(65, 16);
            this.rbSql2005.TabIndex = 2;
            this.rbSql2005.Text = "SQL2005";
            this.rbSql2005.UseVisualStyleBackColor = true;
            // 
            // FormConnection
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(492, 225);
            this.Controls.Add(this.gbDbType);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置连接";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDbType.ResumeLayout(false);
            this.gbDbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtDbstr;
        private System.Windows.Forms.Button btnSetConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbDbType;
        private System.Windows.Forms.RadioButton rbSql2005;
        private System.Windows.Forms.RadioButton rbSql2000;
        private System.Windows.Forms.RadioButton rbAccess;
    }
}