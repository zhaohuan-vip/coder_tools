using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HIHS.Core.Utils
{
    public class SignUtil
    {
        /// <summary>
        /// 生成指定长度的随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string generateRandomNonce(int length)
        {
            StringBuilder builder = new StringBuilder();
            char[] characters = @"abcdefghigklmnopqrstuvwxyz".ToArray();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                builder.Append(characters[random.Next(0, 26)]);
            }

            return builder.ToString();
        }

        public static IDictionary<string, string> ObjectToMap(object obj)
        {
            IDictionary<string, string> map = new Dictionary<string, string>();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Type[] types = new Type[] { typeof(int), typeof(int?), typeof(decimal), typeof(decimal?), typeof(string), typeof(bool), typeof(bool?), typeof(DateTime), typeof(DateTime?) };
            foreach (PropertyInfo p in pi)
            {
                if (types.Contains(p.PropertyType))
                {
                    MethodInfo m = p.GetGetMethod();
                    if (m != null && m.IsPublic)
                    {
                        if (m.Invoke(obj, new object[] { }) != null)
                        {
                            if (p.PropertyType == typeof(string) && m.Invoke(obj, new object[] { }).ToString() == "")
                            {
                                continue;
                            }
                            map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString());
                        }
                    }
                }
            }
            return map;
        }

        /// <summary>
        /// Get Sign Content
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetSignContent(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);
            return content;
        }
    }
}
