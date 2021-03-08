namespace Development_Toolbox
{
    partial class FmToggleCase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmToggleCase));
            this.txtNewText = new System.Windows.Forms.TextBox();
            this.btnToUpper = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbBuilder = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddString = new System.Windows.Forms.TextBox();
            this.txtVariable = new System.Windows.Forms.TextBox();
            this.btnCreateCode = new System.Windows.Forms.Button();
            this.ckbTrim = new System.Windows.Forms.CheckBox();
            this.btnAddQuotes = new System.Windows.Forms.Button();
            this.btnInLine = new System.Windows.Forms.Button();
            this.btnToLower = new System.Windows.Forms.Button();
            this.txtOldText = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewText
            // 
            this.txtNewText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewText.Location = new System.Drawing.Point(6, 196);
            this.txtNewText.Multiline = true;
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNewText.Size = new System.Drawing.Size(547, 170);
            this.txtNewText.TabIndex = 0;
            // 
            // btnToUpper
            // 
            this.btnToUpper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToUpper.Location = new System.Drawing.Point(8, 371);
            this.btnToUpper.Name = "btnToUpper";
            this.btnToUpper.Size = new System.Drawing.Size(75, 23);
            this.btnToUpper.TabIndex = 1;
            this.btnToUpper.Text = "大写";
            this.btnToUpper.UseVisualStyleBackColor = true;
            this.btnToUpper.Click += new System.EventHandler(this.btnToUpper_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 427);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbBuilder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtAddString);
            this.tabPage1.Controls.Add(this.txtVariable);
            this.tabPage1.Controls.Add(this.btnCreateCode);
            this.tabPage1.Controls.Add(this.ckbTrim);
            this.tabPage1.Controls.Add(this.btnAddQuotes);
            this.tabPage1.Controls.Add(this.btnInLine);
            this.tabPage1.Controls.Add(this.btnToLower);
            this.tabPage1.Controls.Add(this.txtOldText);
            this.tabPage1.Controls.Add(this.txtNewText);
            this.tabPage1.Controls.Add(this.btnToUpper);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(561, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "大小写转换";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbBuilder
            // 
            this.cbBuilder.AutoSize = true;
            this.cbBuilder.Location = new System.Drawing.Point(63, 174);
            this.cbBuilder.Name = "cbBuilder";
            this.cbBuilder.Size = new System.Drawing.Size(102, 16);
            this.cbBuilder.TabIndex = 14;
            this.cbBuilder.Text = "StringBuilder";
            this.cbBuilder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "字符：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "变量名：";
            // 
            // txtAddString
            // 
            this.txtAddString.Location = new System.Drawing.Point(323, 147);
            this.txtAddString.Name = "txtAddString";
            this.txtAddString.Size = new System.Drawing.Size(100, 21);
            this.txtAddString.TabIndex = 10;
            // 
            // txtVariable
            // 
            this.txtVariable.Location = new System.Drawing.Point(63, 147);
            this.txtVariable.Name = "txtVariable";
            this.txtVariable.Size = new System.Drawing.Size(100, 21);
            this.txtVariable.TabIndex = 10;
            // 
            // btnCreateCode
            // 
            this.btnCreateCode.Location = new System.Drawing.Point(169, 145);
            this.btnCreateCode.Name = "btnCreateCode";
            this.btnCreateCode.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCode.TabIndex = 9;
            this.btnCreateCode.Text = "生成";
            this.btnCreateCode.UseVisualStyleBackColor = true;
            this.btnCreateCode.Click += new System.EventHandler(this.btnCreateCode_Click);
            // 
            // ckbTrim
            // 
            this.ckbTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbTrim.AutoSize = true;
            this.ckbTrim.Location = new System.Drawing.Point(171, 174);
            this.ckbTrim.Name = "ckbTrim";
            this.ckbTrim.Size = new System.Drawing.Size(60, 16);
            this.ckbTrim.TabIndex = 8;
            this.ckbTrim.Text = "去空格";
            this.ckbTrim.UseVisualStyleBackColor = true;
            this.ckbTrim.CheckedChanged += new System.EventHandler(this.ckbTrim_CheckedChanged);
            // 
            // btnAddQuotes
            // 
            this.btnAddQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddQuotes.Location = new System.Drawing.Point(429, 145);
            this.btnAddQuotes.Name = "btnAddQuotes";
            this.btnAddQuotes.Size = new System.Drawing.Size(75, 23);
            this.btnAddQuotes.TabIndex = 7;
            this.btnAddQuotes.Text = "空白加符号";
            this.btnAddQuotes.UseVisualStyleBackColor = true;
            this.btnAddQuotes.Click += new System.EventHandler(this.btnAddQuotes_Click);
            // 
            // btnInLine
            // 
            this.btnInLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInLine.Location = new System.Drawing.Point(170, 371);
            this.btnInLine.Name = "btnInLine";
            this.btnInLine.Size = new System.Drawing.Size(75, 23);
            this.btnInLine.TabIndex = 5;
            this.btnInLine.Text = "一行";
            this.btnInLine.UseVisualStyleBackColor = true;
            this.btnInLine.Click += new System.EventHandler(this.btnInLine_Click);
            // 
            // btnToLower
            // 
            this.btnToLower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToLower.Location = new System.Drawing.Point(89, 371);
            this.btnToLower.Name = "btnToLower";
            this.btnToLower.Size = new System.Drawing.Size(75, 23);
            this.btnToLower.TabIndex = 4;
            this.btnToLower.Text = "小写";
            this.btnToLower.UseVisualStyleBackColor = true;
            this.btnToLower.Click += new System.EventHandler(this.btnToLower_Click);
            // 
            // txtOldText
            // 
            this.txtOldText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldText.Location = new System.Drawing.Point(6, 3);
            this.txtOldText.Multiline = true;
            this.txtOldText.Name = "txtOldText";
            this.txtOldText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOldText.Size = new System.Drawing.Size(547, 140);
            this.txtOldText.TabIndex = 2;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            // 
            // FmToggleCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 427);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmToggleCase";
            this.Text = "开发工具箱";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewText;
        private System.Windows.Forms.Button btnToUpper;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtOldText;
        private System.Windows.Forms.Button btnToLower;
        private System.Windows.Forms.Button btnInLine;
        private System.Windows.Forms.Button btnAddQuotes;
        private System.Windows.Forms.CheckBox ckbTrim;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnCreateCode;
        private System.Windows.Forms.TextBox txtVariable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddString;
        private System.Windows.Forms.CheckBox cbBuilder;
    }
}

