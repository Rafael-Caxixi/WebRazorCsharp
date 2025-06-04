using Microsoft.AspNetCore.Mvc;
using WebBlazorAPI.API.Requests;
using WebBlazorAPI.API.Response;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Endpoints;

public static class FilmesExtensions
{
    public static void AddEndPointsFilmes(this WebApplication app)
    {

        app.MapGet("/filmes", ([FromServices] DAL<Filme> dal) =>
        {
            if (dal.Listar().Count() == 0)
            {
                return Results.NotFound("Nenhum filme encontrado.");
            }
            IEnumerable<FilmeResponse> filmesResponse = dal.Listar().Select(f => new FilmeResponse(f.Id, f.Nome, f.AnoLancamento, f.CinemaId, f.Ativo));
            return Results.Ok(filmesResponse);
        });


        app.MapGet("/filmes/{nome}", ([FromServices] DAL<Filme> dal, string nome) =>
        {
            var filme = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (filme is null)
            {
                return Results.NotFound("Filme não encontrado.");
            }
            return Results.Ok(new FilmeResponse(filme.Id, filme.Nome, filme.AnoLancamento, filme.CinemaId, filme.Ativo));
        });

        app.MapPost("/filmes", ([FromServices] DAL<Filme> dal, [FromBody] FilmeRequest filmeRequest) =>
        {
            var filme = new Filme(filmeRequest.nome, filmeRequest.anoLancamento, filmeRequest.cinemaId);
            dal.Adicionar(filme);
            return Results.Created($"/filmes/{filme.Nome}", filme);
        });

        app.MapDelete("/filmes/{id}", ([FromServices] DAL<Filme
    > dal, int id) =>
        {
            var filme = dal.RecuperaPor(f => f.Id == id);
            if (filme is null)
            {
                return Results.NotFound("Filme não encontrado.");
            }
            dal.Deletar(filme);
            return Results.Ok($"Filme {filme.Nome} deletado com sucesso.");
        });

        app.MapPut("/filmes/{id}", ([FromServices] DAL<Filme> dal, [FromBody] FilmeRequestEdit filmeRequest) =>
        {
            var filmeExistente = dal.RecuperaPor(c => c.Id == filmeRequest.id);
            if (filmeExistente is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            filmeExistente.Nome = filmeRequest.nome;
            filmeExistente.AnoLancamento = filmeRequest.anoLancamento;
            filmeExistente.CinemaId = filmeRequest.cinemaId;
            filmeExistente.Ativo = filmeRequest.ativo;
            dal.Atualizar(filmeExistente);
            return Results.Ok($"Cinema {filmeExistente.Nome} atualizado com sucesso.");
        });
    }
}
