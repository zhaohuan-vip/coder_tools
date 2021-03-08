using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Development_Toolbox
{
    public partial class FmToggleCase : Form
    {

        public FmToggleCase()
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
        /// 待处理字符串数组
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
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVariable.Text))
            {
                string formatStr = "{0}+=\"{1}\";";
                if (cbBuilder.Checked)
                {
                    formatStr = "{0}.append(\"{1}\");";
                }
                txtNewText.Lines =
               txtOldText.Lines.Select(line => string.Format(formatStr, txtVariable.Text, IsTirm ? line.Replace("\"", "\\\"").Trim(): line.Replace("\"", "\\\""))).ToArray();
            }
            else
            {
                txtNewText.Lines =
               txtOldText.Lines.Select(line => string.Format("\"{0}\"", IsTirm ? line.Replace("\"", "\\\"").Trim() : line.Replace("\"", "\\\""))).ToArray();
            }
        }
    }
}
