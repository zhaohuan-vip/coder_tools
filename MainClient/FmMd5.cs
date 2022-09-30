using HIHS.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MainClient
{
    public partial class FmMd5 : Form
    {
        public FmMd5()
        {
            InitializeComponent();
        }
        public string getSign()
        {
            string sign = "";
            sign = string.Format("AppId={0}&Secret={1}&Url={2}&Timestamp={3}&Version={4}", txtAppId.Text.Trim(), txtSecret.Text.Trim(), txtUrl.Text.Trim(), txtTimestamp.Text.Trim(),1);
            sign = MD5Util.MD5Encrypt32(sign);
            return sign;
        }

        private void FmMd5_Load(object sender, EventArgs e)
        {
            txtTimestamp.Text = DateTime.Now.ToUniversalTime().Ticks.ToString();
            //txtSign.Text = getSign();
            txtTimestamp.Text = "11111";
        }

        private void btnMd5_Click(object sender, EventArgs e)
        {
            txtTimestamp.Text = DateTime.Now.ToUniversalTime().Ticks.ToString();
            txtSign.Text = getSign();
        }
    }

   
}
