using System.Net.Http;

namespace Addy.Address.Service
{
    public interface IRequestFactory
    {
        HttpClient CreateClient();
    }
}
