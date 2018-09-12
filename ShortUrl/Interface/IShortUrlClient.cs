using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ShortUrl.Interface
{
    /// <summary>
    /// 接口-客户端
    /// </summary>
    public interface IShortUrlClient
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="T">响应对应的泛型</typeparam>
        /// <param name="request">请求</param>
        /// <returns></returns>
        T Excute<T>(IShortUrlRequest<T> request) where T : IShortUrlResponse;
    }
}
