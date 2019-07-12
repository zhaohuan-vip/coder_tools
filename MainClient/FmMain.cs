using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Development_Toolbox
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        #region 托盘功能
        /// <summary>
        /// Handles the SizeChanged event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FmMain_SizeChanged(object sender, EventArgs e)
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
        private void FmMain_Activated(object sender, EventArgs e)
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

        private void FmMain_Leave(object sender, EventArgs e)
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

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注销Id号为103的热键设定  
            //HotKey.UnregisterHotKey(Handle, 103);
        }

        private void btnToggleCase_Click(object sender, EventArgs e)
        {
            FmToggleCase fmToggleCase = new FmToggleCase();
            fmToggleCase.ShowDialog();
        }
    }
}
