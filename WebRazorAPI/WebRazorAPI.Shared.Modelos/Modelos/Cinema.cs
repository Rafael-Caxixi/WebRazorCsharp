namespace WebRazorAPI.Modelos;
public class Cinema
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();

    public Cinema(string nome)
    {
        Nome = nome;
    }

    public Cinema()
    {
    }

    public void AdicionarFilme(Filme filme)
    {
        Filmes.Add(filme);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}";
    }
}
