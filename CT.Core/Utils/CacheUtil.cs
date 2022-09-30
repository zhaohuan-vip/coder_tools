using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace HIHS.Core.Utils
{
    /// <summary>
    /// 缓存工具类
    /// </summary>
    public class CacheUtil
    {
        //private static ObjectCache Cache = new MemoryCache("myCache");
        private static Dictionary<string, object> Cache=new Dictionary<string,object>();
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static object GetCache(string cacheKey)
        {
            if(Cache.ContainsKey(cacheKey))
                return Cache[cacheKey];
            return null;
        }
        /// <summary>
        /// 设置数据缓存
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="objObject">The object object.</param>
        public static void SetCache(string cacheKey, object objObject)
        {
            if (Cache.ContainsKey(cacheKey))
                Cache.Remove(cacheKey);
            Cache.Add(cacheKey,objObject);
        }


    }
}
