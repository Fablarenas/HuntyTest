using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpExternalServices.Interfaces
{
    public interface IHttpServices
    {
        Task<T> GetRequest<T>(string url);
        Task<TOut> PostRequest<TIn, TOut>(TIn content, string url, string token = "");
    }
}
