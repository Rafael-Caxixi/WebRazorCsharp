namespace WebBlazorAPI.API.Requests;

public record CinemaRequestEdit(int Id, string Nome, string? FotoPerfil)
    : CinemaRequest(Nome, FotoPerfil);