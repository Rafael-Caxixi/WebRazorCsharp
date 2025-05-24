using Microsoft.AspNetCore.Mvc;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Endpoints;

public static class CinemasExtensions
{
    public static void AddEndPointsCinemas(this WebApplication app)
    {
        app.MapGet("/Cinemas", ([FromServices] DAL<Cinema> dal) =>
        {
            return Results.Ok(dal.Listar());
        });


        app.MapGet("/Cinemas/{nome}", ([FromServices] DAL<Cinema> dal, string nome) =>
        {
            var cinema = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (cinema is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            return Results.Ok(cinema);
        });

        app.MapPost("/Cinemas", ([FromServices] DAL<Cinema> dal, [FromBody] Cinema cinema) =>
        {
            dal.Adicionar(cinema);
            return Results.Created($"/Cinemas/{cinema.Nome}", cinema);
        });

        app.MapDelete("/Cinemas/{id}", ([FromServices] DAL<Cinema
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

        app.MapPut("/Cinemas/{id}", ([FromServices] DAL<Cinema> dal, [FromBody] Cinema cinema, int id) =>
        {
            var cinemaExistente = dal.RecuperaPor(c => c.Id == id);
            if (cinemaExistente is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            cinemaExistente.Nome = cinema.Nome;
            dal.Atualizar(cinemaExistente);
            return Results.Ok($"Cinema {cinema.Nome} atualizado com sucesso.");
        });
    }
}
