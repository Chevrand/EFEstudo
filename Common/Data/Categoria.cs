using Common.Interfaces;

namespace Common.Data;

public class Categoria : IEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<FilmeCategoria> CategoraFilme { get; set; }

    public Categoria()
    {
        CategoraFilme = new HashSet<FilmeCategoria>();
    }

    public override string ToString()
    {
        return $"# Id: {Id} | Nome: {Nome}";
    }
}
