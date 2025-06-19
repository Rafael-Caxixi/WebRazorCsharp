using Microsoft.AspNetCore.Mvc;
using WebBlazorAPI.API.Requests;
using WebBlazorAPI.API.Response;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Endpoints;

public static class CinemasExtensions
{
    public static void AddEndPointsCinemas(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("cinemas")
            .RequireAuthorization()
            .WithTags("Cinemas");

        groupBuilder.MapGet("", ([FromServices] DAL<Cinema> dal) =>
        {
            var listaDeCinamas = dal.Listar();
            if (listaDeCinamas is null)
            {
                return Results.NotFound();
            }

            var listaCinemasResponse = EntityListToResponseList(listaDeCinamas);
            return Results.Ok(listaCinemasResponse);
        });


        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Cinema> dal, string nome) =>
        {
            var cinema = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (cinema is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            return Results.Ok(EntityToResponse(cinema));
        });

        groupBuilder.MapPost("",async ([FromServices]IHostEnvironment env, [FromServices] DAL<Cinema> dal, [FromBody] CinemaRequest cinemaRequest) =>
        {
            var nome = cinemaRequest.Nome.Trim();
            var imagemCinema = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpg";

            var path = Path.Combine(env.ContentRootPath,
                      "wwwroot", "FotosPerfil", imagemCinema);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(cinemaRequest.FotoPerfil!));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);

            var cinema = new Cinema(cinemaRequest.Nome)
            {
                FotoPerfil = $"/FotosPerfil/{imagemCinema}"
            };

            dal.Adicionar(cinema);
            return Results.Created($"/cinemas/{cinema.Nome}", cinemaRequest);
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Cinema
    > dal, int id) =>
        {
            var cinema = dal.RecuperaPor(c => c.Id == id);
            if (cinema is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            dal.Deletar(cinema);
            return Results.Ok($"Cinema {cinema.Nome} deletado com sucesso.");
        });

        groupBuilder.MapPut("", ([FromServices] DAL<Cinema> dal, [FromBody] CinemaRequestEdit cinemaRequest) =>
        {
            var cinemaExistente = dal.RecuperaPor(c => c.Id == cinemaRequest.Id);
            if (cinemaExistente is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            cinemaExistente.Nome = cinemaRequest.Nome;
            dal.Atualizar(cinemaExistente);
            return Results.Ok($"Cinema {cinemaExistente.Nome} atualizado com sucesso.");
        });
    }

    private static ICollection<CinemaResponse> EntityListToResponseList(IEnumerable<Cinema> listaCinemasResponse)
    {
        return listaCinemasResponse.Select(c => EntityToResponse(c)).ToList();
    }

    private static CinemaResponse EntityToResponse(Cinema cinema)
    {
        return new CinemaResponse(cinema.Id, cinema.Nome,cinema.FotoPerfil);
    }
}
