namespace Common.Data;

public class FilmeCategoria
{
    public int FilmeId { get; set; }
    public int CategoriaId { get; set; }

    public virtual Filme Filme { get; set; }
    public virtual Categoria Categoria { get; set; }
}
