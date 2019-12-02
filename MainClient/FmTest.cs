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
    public partial class FmTest : Form
    {
        public FmTest()
        {
            InitializeComponent();
        }

        private void FmTest_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> result = new List<string>();
            foreach (var s in txtText.Lines)
            {
                Regex reg = new Regex(@"\d+(\.\d+)?", RegexOptions.IgnoreCase);
                //MatchCollection ms = reg.Matches(s);

                //result.Add(ms.Count>0? ms[0].Value:"");
                result.Add(reg.IsMatch(s) ? reg.Match(s).Value : "");
            }
            txtResult.Lines = result.ToArray();

        }
    }
}
