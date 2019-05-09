using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Development_Toolbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] word = textBox1.Lines;
            List<string> newLines = new List<string>();
            //newLines.Add("/// <summary>");
            //newLines.Add("/// ");
            //newLines.Add("/// </summary>");
            //newLines.Add("public enum IsValuable");
            //newLines.Add("{");

            foreach (var line in word)
            {
                string itemString = line;
                Regex reg = new Regex(@"value=(\d+)>(.+)<", RegexOptions.IgnoreCase);
                MatchCollection ms = reg.Matches(itemString);

                newLines.Add("<option value=\"" + ms[0].Groups[2].Value + "\">" + ms[0].Groups[2].Value + "</option>");
                //newLines.Add("/// <summary>");
                //newLines.Add("/// " + ms[0].Groups[2].Value);
                //newLines.Add("/// </summary>");
                //newLines.Add("[Description(\"" + ms[0].Groups[2].Value + "\")]");
                //if (line == word[word.Length - 1])
                //{
                //    newLines.Add(ms[0].Groups[2].Value + " = " + ms[0].Groups[1].Value);
                //}
                //else
                //{
                //    newLines.Add(ms[0].Groups[2].Value + " = " + ms[0].Groups[1].Value + ",");
                //}
            }
            //newLines.Add("}");
            textBox2.Lines = newLines.ToArray();
        }
    }
}
