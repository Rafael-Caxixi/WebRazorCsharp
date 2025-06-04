namespace WebRazorAPI.Modelos;
public class Filme
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AnoLancamento { get; set; }
    public bool Ativo { get; set; }
    public int CinemaId { get; set; }
    public virtual Cinema? Cinema { get; set; }


    public Filme( string nome, int anoLancamento, int cinemaId)
    {
        Nome = nome;
        AnoLancamento = anoLancamento;
        Ativo = true;
        CinemaId = cinemaId;
    }

    public Filme()
    {
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Ano de Lançamento: {AnoLancamento}, Ativo: {Ativo}";
    }
}
