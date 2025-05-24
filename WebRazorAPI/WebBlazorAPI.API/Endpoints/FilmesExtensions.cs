using Microsoft.AspNetCore.Mvc;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

namespace WebBlazorAPI.API.Endpoints;

public static class FilmesExtensions
{
    public static void AddEndPointsFilmes(this WebApplication app)
    {

        app.MapGet("/Filmes", ([FromServices] DAL<Filme> dal) =>
        {
            return Results.Ok(dal.Listar());
        });


        app.MapGet("/Filmes/{nome}", ([FromServices] DAL<Filme> dal, string nome) =>
        {
            var filme = dal.RecuperaPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

            if (filme is null)
            {
                return Results.NotFound("Filme não encontrado.");
            }
            return Results.Ok(filme);
        });

        app.MapPost("/Filmes", ([FromServices] DAL<Filme> dal, [FromBody] Filme filme) =>
        {
            dal.Adicionar(filme);
            return Results.Created($"/Filmes/{filme.Nome}", filme);
        });

        app.MapDelete("/Filmes/{id}", ([FromServices] DAL<Filme
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

        app.MapPut("/Filmes/{id}", ([FromServices] DAL<Filme> dal, [FromBody] Filme filme, int id) =>
        {
            var filmeExistente = dal.RecuperaPor(c => c.Id == id);
            if (filmeExistente is null)
            {
                return Results.NotFound("Cinema não encontrado.");
            }
            filmeExistente.Nome = filme.Nome;
            filmeExistente.AnoLancamento = filme.AnoLancamento;
            filmeExistente.Genero = filme.Genero;
            filmeExistente.CinemaId = filme.CinemaId;
            filmeExistente.Ativo = filme.Ativo;
            dal.Atualizar(filmeExistente);
            return Results.Ok($"Cinema {filmeExistente.Nome} atualizado com sucesso.");
        });
    }
}
