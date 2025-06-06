using System.ComponentModel.DataAnnotations;

namespace WebBlazorAPI.API.Requests;

public record CinemaRequest([Required] string Nome, string? FotoPerfil);