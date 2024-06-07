using System.Net.Http;

namespace HR.ManagementHub.BlazorUI.Services.Base;

public partial class Client : IClient
{
    public HttpClient HttpClient
    {
        get
        {
            return _httpClient;
        }
    }
}

