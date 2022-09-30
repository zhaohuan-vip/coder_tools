namespace Development_Toolbox
{
    partial class FmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.btnToggleCase = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnConvertToClass = new System.Windows.Forms.Button();
            this.btnMd5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToggleCase
            // 
            this.btnToggleCase.Location = new System.Drawing.Point(16, 15);
            this.btnToggleCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToggleCase.Name = "btnToggleCase";
            this.btnToggleCase.Size = new System.Drawing.Size(100, 41);
            this.btnToggleCase.TabIndex = 0;
            this.btnToggleCase.Text = "大小写转换";
            this.btnToggleCase.UseVisualStyleBackColor = true;
            this.btnToggleCase.Click += new System.EventHandler(this.btnToggleCase_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Coder Tools";
            this.notifyIcon.BalloonTipTitle = "Coder Tools";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Coder Tools";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // btnConvertToClass
            // 
            this.btnConvertToClass.Location = new System.Drawing.Point(124, 15);
            this.btnConvertToClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConvertToClass.Name = "btnConvertToClass";
            this.btnConvertToClass.Size = new System.Drawing.Size(121, 41);
            this.btnConvertToClass.TabIndex = 1;
            this.btnConvertToClass.Text = "SQL转Model类";
            this.btnConvertToClass.UseVisualStyleBackColor = true;
            this.btnConvertToClass.Click += new System.EventHandler(this.btnConvertToClass_Click);
            // 
            // btnMd5
            // 
            this.btnMd5.Location = new System.Drawing.Point(253, 15);
            this.btnMd5.Margin = new System.Windows.Forms.Padding(4);
            this.btnMd5.Name = "btnMd5";
            this.btnMd5.Size = new System.Drawing.Size(100, 41);
            this.btnMd5.TabIndex = 2;
            this.btnMd5.Text = "Md5";
            this.btnMd5.UseVisualStyleBackColor = true;
            this.btnMd5.Click += new System.EventHandler(this.btnMd5_Click);
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 405);
            this.Controls.Add(this.btnMd5);
            this.Controls.Add(this.btnConvertToClass);
            this.Controls.Add(this.btnToggleCase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmMain";
            this.Text = "Coder Tools";
            this.Activated += new System.EventHandler(this.FmMain_Activated);
            this.SizeChanged += new System.EventHandler(this.FmMain_SizeChanged);
            this.Leave += new System.EventHandler(this.FmMain_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToggleCase;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnConvertToClass;
        private System.Windows.Forms.Button btnMd5;
    }
}