using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Requests;

public record FilmeRequestEdit(
    int id,
    string nome,
    int anoLancamento,
    int cinemaId,
    Genero genero,
    bool ativo
);
