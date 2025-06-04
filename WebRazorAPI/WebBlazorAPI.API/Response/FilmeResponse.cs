using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Response;

public record FilmeResponse(
    int id,
    string nome,
    int anoLancamento,
    int cinemaId,
    bool ativo
);
