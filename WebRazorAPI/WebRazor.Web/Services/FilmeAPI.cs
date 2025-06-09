using System.Net.Http.Json;
using WebRazor.Web.Requests;
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

    public async Task AddFilmeAsync(FilmeRequest filmeRequest)
    {
        await _httpClient.PostAsJsonAsync("filmes", filmeRequest);
    }

    public async Task DeleteFilmeAsync(int id)
    {
        await _httpClient.DeleteAsync($"filmes/{id}");
    }

    public async Task UpdateFilmesync(FilmeRequestEdit filmeRequestEdit)
    {
        await _httpClient.PutAsJsonAsync($"filmes/${filmeRequestEdit.Id}", filmeRequestEdit);
    }

    public async Task<FilmeResponse> GetFilmePorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<FilmeResponse>($"filmes/{nome}");
    }
}
