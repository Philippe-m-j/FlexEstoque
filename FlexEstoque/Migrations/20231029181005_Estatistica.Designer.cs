﻿// <auto-generated />
using System;
using FlexEstoque.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlexEstoque.Migrations
{
    [DbContext(typeof(FlexEstoqueContext))]
    [Migration("20231029181005_Estatistica")]
    partial class Estatistica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("FlexEstoque.Models.CategoriaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProduto");
                });

            modelBuilder.Entity("FlexEstoque.Models.Estatistica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Estatistica");
                });

            modelBuilder.Entity("FlexEstoque.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoriaProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EstoqueMaximo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstoqueMinimo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidadeProduto")
                        .HasColumnType("TEXT");

                    b.Property<string>("ValorProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("FlexEstoque.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Perfil")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("FlexEstoque.Models.Produto", b =>
                {
                    b.HasOne("FlexEstoque.Models.CategoriaProduto", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaProdutoId");

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
