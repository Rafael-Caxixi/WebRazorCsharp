using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

var builder = WebApplication.CreateBuilder(args);

//try
//{
//    var context = new WebRazorContext();
//    var dalFilme = new DAL<Filme>(context);
//    //var filme1 = new Filme("Os Vingadores", 2018, Genero.Acao, 1);
//    //var filme2 = new Filme("Jogador N°1", 2021, Genero.FiccaoCientifica, 1);
//    //var filme3 = new Filme("Gente Grande", 2013, Genero.Comedia, 2);

//    //dalFilme.Adicionar(filme1);
//    //dalFilme.Adicionar(filme2);
//    //dalFilme.Adicionar(filme3);

//    foreach (var filme in dalFilme.Listar())
//    {
//        Console.WriteLine($"Id:{filme.Id}, Filme: {filme.Nome}, Ano: {filme.AnoLancamento}, Gênero: {filme.Genero}, CinemaId: {filme.CinemaId}");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
//}
return;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();

