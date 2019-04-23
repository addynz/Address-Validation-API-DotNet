using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    public interface IRequestClient : IDisposable
    {
        Task<T> GetAsync<T>(string query) where T : class;
    }
}
