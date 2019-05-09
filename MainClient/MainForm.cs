using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Development_Toolbox
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            try
            {
                txtOldText.Text = Clipboard.GetText();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            OperationString = txtOldText.Text;
            OperationLinesStrings = txtOldText.Lines;


        }


        /// <summary>
        /// 设置获取大小写0:正常,1:大写,2:小写
        /// </summary>
        /// <value></value>
        protected int UpperOrLower { get; set; }


        protected string OperationString
        {
            get { return txtOldText.Text; }
            set { }
        }

        /// <summary>
        /// Gets the operation lines strings.
        /// </summary>
        /// <value>The operation lines strings.</value>
        protected string[] OperationLinesStrings
        {
            get { return txtOldText.Lines; }
            set { }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is tirm.
        /// </summary>
        /// <value><c>true</c> if this instance is tirm; otherwise, <c>false</c>.</value>
        protected bool IsTirm { get; set; }


        private void btnToUpper_Click(object sender, EventArgs e)
        {
            UpperOrLower = 1;
            txtNewText.Text = IsTirm ? OperationString.Trim().ToUpper() : OperationString.ToUpper();
        }

        private void btnToLower_Click(object sender, EventArgs e)
        {
            UpperOrLower = 2;
            txtNewText.Text = IsTirm ? OperationString.Trim().ToLower() : OperationString.ToLower();
        }

        private void btnInLine_Click(object sender, EventArgs e)
        {

            string newText = OperationLinesStrings.Aggregate((current, line) => current + line);
            txtNewText.Text = IsTirm ? newText.Trim() : newText;
            switch (UpperOrLower)
            {
                case 1:
                    {
                        txtNewText.Text = txtNewText.Text.ToUpper();
                        break;
                    }
                case 2:
                    {
                        txtNewText.Text = txtNewText.Text.ToLower();
                        break;
                    }
            }

        }



        /// <summary>
        /// 加引号
        /// </summary>
        /// <param name="charstring">The charstring.</param>
        private string[] AddQuotes(string charstring)
        {
            List<string> newLines = new List<string>();
            if (OperationLinesStrings.Any())
            {
                foreach (var line in OperationLinesStrings)
                {
                    string itemString = line;
                    Regex reg = new Regex(@"\w+", RegexOptions.IgnoreCase);
                    MatchCollection ms = reg.Matches(itemString);
                    for (int i = 0; i < ms.Count; i++)
                    {
                        if (string.IsNullOrEmpty(charstring))
                        {
                            itemString = itemString.Replace(ms[i].Value, "\"" + ms[i].Value + "\"");
                        }
                        else
                        {
                            itemString = itemString.Replace(ms[i].Value, ms[i].Value + charstring);
                        }
                    }
                    newLines.Add(itemString);
                }

            }
            return newLines.ToArray();
        }


        private void btnAddQuotes_Click(object sender, EventArgs e)
        {
            txtNewText.Lines = AddQuotes(txtAddString.Text);
        }

        private void ckbTrim_CheckedChanged(object sender, EventArgs e)
        {
            IsTirm = ckbTrim.Checked;
        }
        private void btnHtmlToc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVariable.Text))
            {
                txtNewText.Lines =
               txtOldText.Lines.Select(line => string.Format("{0}+=\"{1}\";", txtVariable.Text, line.Replace("\"", "\\\"").Trim())).ToArray();
            }
            else
            {
                txtNewText.Lines =
               txtOldText.Lines.Select(line => string.Format("\"{0}\"", line.Replace("\"", "\\\"").Trim())).ToArray();
            }

        }
        #region 托盘功能
        /// <summary>
        /// Handles the SizeChanged event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
                notifyIcon.Visible = true;  //托盘图标可见
            }
        }

        /// <summary>
        /// Handles the MouseClick event of the notifyIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible)
            {
                this.ShowInTaskbar = true;  //显示在系统任务栏
                notifyIcon.Visible = false;  //托盘图标隐藏
                this.Visible = true;
                this.Show();
                this.Activate();
            }
            else
            {
                this.ShowInTaskbar = false;  //显示在系统任务栏
                notifyIcon.Visible = true;  //托盘图标隐藏
                this.Visible = false;
            }
        }
        #endregion

        #region 热键功能
        private void MainForm_Activated(object sender, EventArgs e)
        {
            ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。  
            //HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            ////注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。  
            //HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.B);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。  
            //HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.D);
            //注册热键Alt+V，Id号为103。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。  
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.Alt, Keys.V);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            ////注销Id号为100的热键设定  
            //HotKey.UnregisterHotKey(Handle, 100);
            ////注销Id号为101的热键设定  
            //HotKey.UnregisterHotKey(Handle, 101);
            ////注销Id号为102的热键设定  
            //HotKey.UnregisterHotKey(Handle, 102);
            //注销Id号为103的热键设定  
            HotKey.UnregisterHotKey(Handle, 103);
        }

        //重载FromA中的WndProc函数  
        /////  
        ///// 监视Windows消息  
        ///// 重载WndProc方法，用于实现热键响应  
        /////  
        /////  
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键  
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:     //按下的是Shift+S  
                            //此处填写快捷键响应代码          
                            break;
                        case 101:     //按下的是Ctrl+B  
                            //此处填写快捷键响应代码  
                            break;
                        case 102:     //按下的是Alt+D  
                            //此处填写快捷键响应代码  
                            break;
                        case 103:    //按下的是Alt+V  
                            if (!this.Visible)
                            {
                                this.ShowInTaskbar = true;  //显示在系统任务栏
                                notifyIcon.Visible = false;  //托盘图标隐藏
                                this.Visible = true;
                                this.Activate();
                            }
                            else
                            {
                                this.ShowInTaskbar = false;  //不显示在系统任务栏
                                notifyIcon.Visible = true;  //托盘图标可见
                                this.Visible = false;
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注销Id号为103的热键设定  
            //HotKey.UnregisterHotKey(Handle, 103);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }




    }
}
