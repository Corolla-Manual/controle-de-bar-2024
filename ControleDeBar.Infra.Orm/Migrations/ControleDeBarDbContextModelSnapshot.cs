﻿// <auto-generated />
using System;
using ControleDeBar.Infra.Orm.Compartilhada;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDeBar.Infra.Orm.Migrations
{
    [DbContext(typeof(ControleDeBarDbContext))]
    partial class ControleDeBarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloConta.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Concluida")
                        .HasColumnType("bit");

                    b.Property<int>("Garcom_Id")
                        .HasColumnType("int");

                    b.Property<int>("Mesa_Id")
                        .HasColumnType("int");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Garcom_Id");

                    b.HasIndex("Mesa_Id");

                    b.ToTable("TBConta", (string)null);
                });

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

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloMesa.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NumeroMesa")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Ocupada")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("TBMesa", (string)null);
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloPedido.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Conta_Id")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("int");

                    b.Property<int>("Produto_Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Conta_Id");

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

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloConta.Conta", b =>
                {
                    b.HasOne("ControleDeBar.Dominio.ModuloGarcom.Garcom", "Garcom")
                        .WithMany()
                        .HasForeignKey("Garcom_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBConta_TBGarcom");

                    b.HasOne("ControleDeBar.Dominio.ModuloMesa.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("Mesa_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBConta_TBMesa");

                    b.Navigation("Garcom");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloPedido.Pedido", b =>
                {
                    b.HasOne("ControleDeBar.Dominio.ModuloConta.Conta", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("Conta_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TBConta_TBPedido");

                    b.HasOne("ControleDeBar.Dominio.ModuloProduto.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("Produto_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBPedido_TBProduto");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDeBar.Dominio.ModuloConta.Conta", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
