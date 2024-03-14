using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.SqlServer;

public class SqlServerContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<FilmeCategoria> FilmeCategorias { get; set; }

    public SqlServerContext() { }

    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost, 1434;Database=csharp_udemy_ef;User Id=sa;Password=senha@123;Encrypt=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Filmes
        modelBuilder.Entity<Filme>()
            .ToTable("filmes");

        modelBuilder.Entity<Filme>()
            .Property(f => f.Titulo)
            .HasColumnName("titulo");

        modelBuilder.Entity<Filme>()
            .Property(f => f.Ano)
            .HasColumnName("ano");

        // Categorias
        modelBuilder.Entity<Categoria>()
            .ToTable("categorias");

        modelBuilder.Entity<Categoria>()
            .Property(c => c.Nome)
            .HasColumnName("nome");

        // FilmeCategoria
        modelBuilder.Entity<FilmeCategoria>()
            .ToTable("filme_categoria");

        modelBuilder.Entity<FilmeCategoria>()
            .HasKey(fc => new { fc.FilmeId, fc.CategoriaId });
    }
}
