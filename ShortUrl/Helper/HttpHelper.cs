using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ShortUrl.Helper
{
    /// <summary>
    /// HTTP助手
    /// </summary>
    internal sealed class HttpHelper
    {
        /// <summary>
        /// HTTP POST 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="sign">签名</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public string Post(string url, string param)
        {
            string strResult = string.Empty;
            HttpWebRequest myRequest = null;
            WebResponse myWebResponse = null;

            try
            {
                myRequest = (HttpWebRequest)WebRequest.Create(url);

                myRequest.Method = "POST";
                myRequest.Timeout = 60000;
                myRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8;";

                byte[] bs = Encoding.UTF8.GetBytes(param);
                myRequest.ContentLength = Encoding.UTF8.GetByteCount(param);

                //往服务器写入数据
                Stream reqStream = myRequest.GetRequestStream();
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();

                //获取服务端返回
                myWebResponse = myRequest.GetResponse();

                //获取服务端返回数据
                using (StreamReader reader = new StreamReader(myWebResponse.GetResponseStream(), Encoding.UTF8))
                {
                    strResult = reader.ReadToEnd().Trim();
                }

                return strResult;
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort();
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭连接和流
                if (myWebResponse != null)
                {
                    myWebResponse.Close();
                }
                if (myRequest != null)
                {
                    myRequest.Abort();
                }
            }
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return null;
            }

            StringBuilder query = new StringBuilder();
            bool hasParam = false;

            foreach (KeyValuePair<string, string> kv in parameters)
            {
                string name = kv.Key;
                string value = kv.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        query.Append("&");
                    }

                    query.Append(name);
                    query.Append("=");
                    //query.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    query.Append(value);
                    hasParam = true;
                }
            }

            return query.ToString();
        }

    }
}
