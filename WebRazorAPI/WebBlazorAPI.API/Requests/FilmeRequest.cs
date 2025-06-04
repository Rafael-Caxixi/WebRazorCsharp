using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Requests;

public record FilmeRequest(
    string nome,
    int anoLancamento,
    int cinemaId
);