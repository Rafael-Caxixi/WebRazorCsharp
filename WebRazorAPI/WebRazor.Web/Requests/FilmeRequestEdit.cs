namespace WebRazor.Web.Requests;

public record FilmeRequestEdit(
    int id,
    string nome,
    int anoLancamento,
    int cinemaId,
    bool ativo
);
