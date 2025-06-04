
namespace WebRazor.Web.Requests;

public record FilmeRequest(
    string nome,
    int anoLancamento,
    int cinemaId
);