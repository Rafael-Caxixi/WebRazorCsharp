using System.Net.Http.Json;
using WebRazor.Web.Requests;
using WebRazor.Web.Response;

namespace WebRazor.Web.Services;

public class CinemaAPI
{
    private readonly HttpClient _httpClient;
    public CinemaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<ICollection<CinemaResponse>?> GetCinemasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<CinemaResponse>>("cinemas");
    }

    public async Task AddCinemasAsync(CinemaRequest cinemaRequest)
    {
        await _httpClient.PostAsJsonAsync("cinemas", cinemaRequest);
    }

    public async Task DeleteCinemaAsync(int id)
    {
        await _httpClient.DeleteAsync($"cinemas/{id}");
    }

    public async Task UpdateCinemaAsync(CinemaRequestEdit cinemaRequestEdit)
    {
        await _httpClient.PutAsJsonAsync($"cinemas/${cinemaRequestEdit.Id}", cinemaRequestEdit);
    }

    public async Task<CinemaResponse> GetCinemaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<CinemaResponse>($"cinemas/{nome}");
    }
}
