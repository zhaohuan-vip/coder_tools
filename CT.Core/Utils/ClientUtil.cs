using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HIHS.Core.Utils
{
    public class ClientUtil
    {
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <param name="dtNow"></param>
        /// <returns></returns>
        public static string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty;                         // 年龄的字符串表示
            int intYear = 0;                                   // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天
            // 如果没有设定出生日期, 返回空
            if (dtBirthday == DateTime.MinValue)
            {
                return string.Empty;
            }
            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }
            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }
            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;
            // 格式化年龄输出
            if (intYear >= 1)                                            // 年份输出
            {
                strAge = intYear.ToString() + "岁";
            }
            if (intMonth > 0 && intYear <= 5)                           // 五岁以下可以输出月数
            {
                strAge += intMonth.ToString() + "月";
            }
            if (intDay >= 0 && intYear < 1)                              // 一岁以下可以输出天数
            {
                if (strAge.Length == 0 || intDay > 0)
                {
                    strAge += intDay.ToString() + "天";
                }
            }
            return strAge;
        }
        /// <summary>
        /// 获取文件的HashCode
        /// </summary>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
