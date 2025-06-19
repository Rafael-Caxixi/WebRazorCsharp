using System.Net.Http.Json;
using WebRazor.Web.Response;

namespace WebRazor.Web.Services;

public class AuthAPI(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("API");

    public async Task<AuthResponse> LoginAsync(string email, string senha)
    {
        var response =  await _httpClient.PostAsJsonAsync("auth/login", new
        {
            email,
            password = senha
        });

        if (response.IsSuccessStatusCode)
        {
            return new AuthResponse { Sucesso = true };
        }
        else
        {
            return new AuthResponse { Sucesso = false, Erros = ["Email ou senha inválido"] };
        }
    }
}
