using Common.Interfaces;

namespace Common.Data;

public class Filme : IEntity
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime Ano { get; set; }
    public virtual ICollection<FilmeCategoria> FilmeCategoria { get; set; }

    public Filme()
    {
        FilmeCategoria = new HashSet<FilmeCategoria>();
    }

    public override string ToString()
    {
        return $"# Id: {Id} | Titulo: {Titulo} | Ano: {Ano:dd-MM-yyyy}";
    }
}
