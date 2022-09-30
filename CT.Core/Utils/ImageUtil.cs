using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace HIHS.Core.Utils
{
    public class ImageUtil
    {
        /// <summary>
        /// 生成缩略图 
        /// </summary>
        /// <param name="originalImage">源图路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <returns>缩放后的图片</returns>
        public static byte[] MakeThumbnail(string url, int width, int height)
        {
            string imgUrl = FormatUrl(url);
            byte[] buffer = UrlToBytes(imgUrl);
            MemoryStream ms = new MemoryStream(buffer);
            Image originalImage = System.Drawing.Image.FromStream(ms);
            //缩略图画布宽高 
            int towidth = width;
            int toheight = height;
            //原始图片写入画布坐标和宽高(用来设置裁减溢出部分) 
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            //原始图片画布,设置写入缩略图画布坐标和宽高(用来原始图片整体宽高缩放) 
            int bg_x = 0;
            int bg_y = 0;
            int bg_w = towidth;
            int bg_h = toheight;
            //倍数变量 
            double multiple = 0;
            //获取宽长的或是高长与缩略图的倍数 
            if (originalImage.Width >= originalImage.Height) multiple = (double)originalImage.Width / (double)width;
            else multiple = (double)originalImage.Height / (double)height;
            //上传的图片的宽和高小等于缩略图 
            if (ow <= width && oh <= height)
            {
                //缩略图按原始宽高 
                bg_w = originalImage.Width;
                bg_h = originalImage.Height;
                //空白部分用背景色填充 
                bg_x = Convert.ToInt32(((double)towidth - (double)ow) / 2);
                bg_y = Convert.ToInt32(((double)toheight - (double)oh) / 2);
            }
            //上传的图片的宽和高大于缩略图 
            else
            {
                //宽高按比例缩放 
                bg_w = Convert.ToInt32((double)originalImage.Width / multiple);
                bg_h = Convert.ToInt32((double)originalImage.Height / multiple);
                //空白部分用背景色填充 
                bg_y = Convert.ToInt32(((double)height - (double)bg_h) / 2);
                bg_x = Convert.ToInt32(((double)width - (double)bg_w) / 2);
            }
            //新建一个bmp图片,并设置缩略图大小. 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并设置背景色 
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            //在指定位置并且按指定大小绘制原图片的指定部分 
            //第一个System.Drawing.Rectangle是原图片的画布坐标和宽高,第二个是原图片写在画布上的坐标和宽高,最后一个参数是指定数值单位为像素 
            g.DrawImage(originalImage, new System.Drawing.Rectangle(bg_x, bg_y, bg_w, bg_h), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            try
            {

                return ImageUtil.ImageToByte(bitmap);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 生成缩略图 
        /// </summary>
        /// <param name="url">源图完整路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <returns>缩放后的图片</returns>
        public static byte[] MakeThumbnailByUrl(string url, int width, int height)
        {
            //string imgUrl = FormatUrl(url);
            byte[] buffer = UrlToBytes(url);
            MemoryStream ms = new MemoryStream(buffer);
            Image originalImage = System.Drawing.Image.FromStream(ms);
            //缩略图画布宽高 
            int towidth = width;
            int toheight = height;
            //原始图片写入画布坐标和宽高(用来设置裁减溢出部分) 
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            //原始图片画布,设置写入缩略图画布坐标和宽高(用来原始图片整体宽高缩放) 
            int bg_x = 0;
            int bg_y = 0;
            int bg_w = towidth;
            int bg_h = toheight;
            //倍数变量 
            double multiple = 0;
            //获取宽长的或是高长与缩略图的倍数 
            if (originalImage.Width >= originalImage.Height) multiple = (double)originalImage.Width / (double)width;
            else multiple = (double)originalImage.Height / (double)height;
            //上传的图片的宽和高小等于缩略图 
            if (ow <= width && oh <= height)
            {
                //缩略图按原始宽高 
                bg_w = originalImage.Width;
                bg_h = originalImage.Height;
                //空白部分用背景色填充 
                bg_x = Convert.ToInt32(((double)towidth - (double)ow) / 2);
                bg_y = Convert.ToInt32(((double)toheight - (double)oh) / 2);
            }
            //上传的图片的宽和高大于缩略图 
            else
            {
                //宽高按比例缩放 
                bg_w = Convert.ToInt32((double)originalImage.Width / multiple);
                bg_h = Convert.ToInt32((double)originalImage.Height / multiple);
                //空白部分用背景色填充 
                bg_y = Convert.ToInt32(((double)height - (double)bg_h) / 2);
                bg_x = Convert.ToInt32(((double)width - (double)bg_w) / 2);
            }
            //新建一个bmp图片,并设置缩略图大小. 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并设置背景色 
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            //在指定位置并且按指定大小绘制原图片的指定部分 
            //第一个System.Drawing.Rectangle是原图片的画布坐标和宽高,第二个是原图片写在画布上的坐标和宽高,最后一个参数是指定数值单位为像素 
            g.DrawImage(originalImage, new System.Drawing.Rectangle(bg_x, bg_y, bg_w, bg_h), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            try
            {

                return ImageUtil.ImageToByte(bitmap);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 获取图片URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FormatUrl(string url)
        {
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                return url;
            }
            else
            {
                string RegexStr = "^http://";
                string RegexStr2 = "^//";
                string RegexStr3 = "^/";
                Regex rep_regex = new Regex(RegexStr);
                Regex rep_regex2 = new Regex(RegexStr2);
                Regex rep_regex3 = new Regex(RegexStr3);
                string s1 = rep_regex.Replace(url, "");
                string s2 = rep_regex2.Replace(s1, "");
                string s3 = rep_regex3.Replace(s2, "");
                return "http://" + s3;
            }
        }
        /// <summary>
        /// 根据url将图片转二进制
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] UrlToBytes(string url)
        {
            try
            {
                Image img =DownloadImage(url);
                return ImageToByte(img);
                //WebRequest request = WebRequest.Create(url);
                //WebResponse response = request.GetResponse();
                //Stream stream = response.GetResponseStream();
                //byte[] bytes = new byte[stream.Length];
                //stream.Read(bytes, 0, bytes.Length);
                //stream.Seek(0, SeekOrigin.Begin);
                //return bytes;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image DownloadImage(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream reader = response.GetResponseStream();
                Image img = System.Drawing.Bitmap.FromStream(reader);
                reader.Close();
                reader.Dispose();
                response.Close();
                return img;
            }
            catch
            {
                return null;
            }
        }
        public static byte[] ImageToByte(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                else
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                byte[] buffer = new byte[ms.Length];

                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// byte[]转图片
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            if (buffer != null)
            {
                MemoryStream ms = new MemoryStream(buffer);
                Image image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            else
            {
                return null;
            }
        }
    }
}
