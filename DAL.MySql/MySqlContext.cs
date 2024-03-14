using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.MySql;

public class MySqlContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<FilmeCategoria> FilmeCategorias { get; set; }

    public MySqlContext() { }

    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=csharp_udemy_ef;Uid=root;Pwd=senha@123;", ServerVersion.Parse("8.3.0-mysql"));
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
