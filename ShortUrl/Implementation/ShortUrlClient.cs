using ShortUrl.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Implementation
{
    /// <summary>
    /// 实现-客户端
    /// </summary>
    public class ShortUrlClient : IShortUrlClient
    {
        public T Excute<T>(IShortUrlRequest<T> request) where T : IShortUrlResponse
        {
            throw new NotImplementedException();
        }
    }
}
