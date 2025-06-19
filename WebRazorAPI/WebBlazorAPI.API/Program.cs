using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using WebBlazorAPI.API.Endpoints;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;
using WebRazorAPI.Shared.Dados.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebRazorContext>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:MeuFilmeDB"])
            .UseLazyLoadingProxies();
});

builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<WebRazorContext>();

builder.Services.AddAuthorization();

builder.Services.AddTransient<DAL<Cinema>>();
builder.Services.AddTransient<DAL<Filme>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors();


var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

});

app.UseStaticFiles();
app.UseAuthorization();

app.AddEndPointsCinemas();
app.AddEndPointsFilmes();

app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorizacao");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

