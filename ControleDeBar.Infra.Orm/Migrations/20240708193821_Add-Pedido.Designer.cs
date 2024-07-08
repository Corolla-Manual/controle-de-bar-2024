﻿// <auto-generated />
using ControleDeBar.Infra.Orm.Compartilhada;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeBar.Infra.Orm.Migrations
{
    [DbContext(typeof(ControleDeBarDbContext))]
    [Migration("20240708193821_Add-Pedido")]
    partial class AddPedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloGarcom.Garcom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("TBGarçom", (string)null);
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloPedido.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("int");

                    b.Property<int>("Produto_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Produto_Id");

                    b.ToTable("TBPedido", (string)null);
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloProduto.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TBProduto", (string)null);
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloPedido.Pedido", b =>
                {
                    b.HasOne("ControleDeBar.Dominio.ModuloProduto.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("Produto_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBPedido_TBProduto");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}