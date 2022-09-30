using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HIHS.Core.Utils
{
    public class HttpUtil
    {
        /// <summary>
        /// 从网站上下载文件，保存到其他路径
        /// </summary>
        /// <param name="saveFilePathName">要保存的文件本地路径名称</param>
        /// <param name="fileUrl">文件Url</param>
        /// <returns>完整的文件名</returns>
        public static string SaveRemoteFile(string saveFilePathName, string fileUrl)
        {
            var f = saveFilePathName + Guid.NewGuid().ToString("D") + ".pdf";
            Uri downUri = new Uri(fileUrl);
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(downUri);
            using (Stream stream = hwr.GetResponse().GetResponseStream())
            {
                using (FileStream fs = File.Create(f))
                {
                    byte[] bytes = new byte[102400];
                    int n = 1;
                    while (n > 0)
                    {
                        n = stream.Read(bytes, 0, 10240);
                        fs.Write(bytes, 0, n);　
                    }
                }
            }
            return f;
        }
    }
}
