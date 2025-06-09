namespace WebRazor.Web.Requests;

public record FilmeRequestEdit(
    int Id,
    string Nome,
    int anoLancamento,
    int CinemaId,
    bool Ativo
);
