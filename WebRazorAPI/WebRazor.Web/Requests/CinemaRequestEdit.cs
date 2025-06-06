using System.ComponentModel.DataAnnotations;

namespace WebRazor.Web.Requests;

public record CinemaRequestEdit(int Id, string Nome, string? FotoPerfil)
    : CinemaRequest(Nome, FotoPerfil);