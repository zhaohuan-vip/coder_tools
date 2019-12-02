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

namespace MainClient
{
    public partial class FmConvertToClass : Form
    {
        public FmConvertToClass()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            List<string> preText = txtPreText.Lines.ToList();
            List<string> newLines = new List<string>();
            List<string> messages = new List<string>();
            //newLines.Add("/// <summary>");
            //newLines.Add("/// ");
            //newLines.Add("/// </summary>");
            //newLines.Add("public enum IsValuable");
            //newLines.Add("{");

            foreach (var line in preText)
            {
                string itemString = line;
                Regex reg = new Regex(@"`(?<name>.*)`\s(?<type>int|varchar|datetime|decimal|timestamp).*COMMENT\s'(?<comment>.*)'", RegexOptions.IgnoreCase);
                MatchCollection ms = reg.Matches(itemString);
                if (ms.Count > 0 && ms[0].Success)
                {
                    string type = "String";
                    //newLines.Add("<option value=\"" + ms[0].Groups[2].Value + "\">" + ms[0].Groups[2].Value + "</option>");
                    string hType = ms[0].Groups["type"].ToString();
                    string name = ms[0].Groups["name"].ToString();


                    name =  Regex.Replace(name, @"_[a-z]", match => match.Value.ToUpper().Remove(0,1));
                    
                    
                    //转换为java类型
                    switch (hType)
                    {
                        case "int":
                            type = "Integer";
                            break;
                        case "decimal":
                            type = "BigDecimal";
                            break;
                        case "varchar":
                            type = "String";
                            break;
                        case "datetime":
                            type = "Date";
                            break;
                        case "timestamp":
                            type = "Timestamp";
                            break;
                        default:
                            break;

                    }

                    newLines.Add("/**");
                    newLines.Add(" * " + ms[0].Groups["comment"].ToString());
                    newLines.Add(" */'");
                    newLines.Add("private" + " " + type + " " + name + ";");
                }
                else
                {
                    messages.Add(itemString + " 转换失败！");
                }

            }
            //newLines.Add("}");
            txtCode.Lines = newLines.ToArray();
            txtMessage.Lines = messages.ToArray();

        }
    }
}
