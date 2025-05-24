using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;
using WebBlazorAPI.API.Endpoints;
using WebRazorAPI.Banco;
using WebRazorAPI.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebRazorContext>();
builder.Services.AddTransient<DAL<Cinema>>();
builder.Services.AddTransient<DAL<Filme>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.AddEndPointsCinemas();
app.AddEndPointsFilmes();

app.Run();
