using BookStoreApi;
using System.Net.Http;

namespace BookStore.Services.Abstract
{
    public abstract class ADataStore
    {
        protected readonly Client _service;
        public ADataStore()
        {
            //Use this code to test locally - localhost do not have certificate
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            _service = new Client("https://localhost:7220", client);
        }
    }
}
