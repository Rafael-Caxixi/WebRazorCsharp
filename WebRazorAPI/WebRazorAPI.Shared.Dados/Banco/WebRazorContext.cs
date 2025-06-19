using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebRazorAPI.Modelos;
using WebRazorAPI.Shared.Dados.Modelos;

namespace WebRazorAPI.Banco;

public class WebRazorContext : IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MeuFilmeDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public WebRazorContext(DbContextOptions options) : base(options)
    {

    }

    public WebRazorContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder
    //        .UseSqlServer(connectionString)
    //        .UseLazyLoadingProxies();
    //}
}
