using System.ComponentModel.DataAnnotations;

namespace WebRazor.Web.Requests;

public record CinemaRequest([Required]string Nome, string? FotoPerfil);