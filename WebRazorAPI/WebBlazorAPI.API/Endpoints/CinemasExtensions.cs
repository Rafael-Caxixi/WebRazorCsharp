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

        app.MapGet("/cinemas", ([FromServices] DAL<Cinema> dal) =>
        {
            var listaDeCinamas = dal.Listar();
            if (listaDeCinamas is null)
            {
                return Results.NotFound();
            }

            var listaCinemasResponse = EntityListToResponseList(listaDeCinamas);
            return Results.Ok(listaCinemasResponse);
        });


        app.MapGet("/cinemas/{nome}", ([FromServices] DAL<Cinema> dal, string nome) =>
        {
            var cinema = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (cinema is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            return Results.Ok(new CinemaResponse(cinema.Id, cinema.Nome));
        });

        app.MapPost("/cinemas", ([FromServices] DAL<Cinema> dal, [FromBody] CinemaRequest cinemaRequest) =>
        {
            var cinema = new Cinema(cinemaRequest.nome);
            dal.Adicionar(cinema);
            return Results.Created($"/cinemas/{cinema.Nome}", cinemaRequest);
        });

        app.MapDelete("/cinemas/{id}", ([FromServices] DAL<Cinema
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

        app.MapPut("/cinemas/{id}", ([FromServices] DAL<Cinema> dal, [FromBody] CinemaRequestEdit cinemaRequest) =>
        {
            var cinemaExistente = dal.RecuperaPor(c => c.Id == cinemaRequest.id);
            if (cinemaExistente is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            cinemaExistente.Nome = cinemaRequest.nome;
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
        return new CinemaResponse(cinema.Id, cinema.Nome);
    }
}
