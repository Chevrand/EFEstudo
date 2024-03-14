﻿// <auto-generated />
using System;
using DAL.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.MySql.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20240314125911_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Common.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("Common.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("ano");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("filmes", (string)null);
                });

            modelBuilder.Entity("Common.FilmeCategoria", b =>
                {
                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("filme_categoria", (string)null);
                });

            modelBuilder.Entity("Common.FilmeCategoria", b =>
                {
                    b.HasOne("Common.Categoria", "Categoria")
                        .WithMany("CategoraFilme")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Filme", "Filme")
                        .WithMany("FilmeCategoria")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Common.Categoria", b =>
                {
                    b.Navigation("CategoraFilme");
                });

            modelBuilder.Entity("Common.Filme", b =>
                {
                    b.Navigation("FilmeCategoria");
                });
#pragma warning restore 612, 618
        }
    }
}
