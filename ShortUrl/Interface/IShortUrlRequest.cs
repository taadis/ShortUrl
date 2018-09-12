using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Interface
{
    /// <summary>
    /// 接口-请求
    /// </summary>
    public interface IShortUrlRequest<out T> where T : IShortUrlResponse
    {
    }
}
