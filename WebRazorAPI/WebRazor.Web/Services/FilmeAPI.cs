using System.Net.Http.Json;
using WebRazor.Web.Response;

namespace WebRazor.Web.Services;

public class FilmeAPI
{
    private readonly HttpClient _httpClient;

    public FilmeAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<FilmeResponse>?> GetFilmesAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<FilmeResponse>>("filmes");
    }
}
