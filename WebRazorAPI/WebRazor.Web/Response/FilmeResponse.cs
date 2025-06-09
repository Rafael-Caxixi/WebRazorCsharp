namespace WebRazor.Web.Response;

public record FilmeResponse(
    int Id,
    string Nome,
    int anoLancamento,
    int CinemaId,
    bool Ativo
);
