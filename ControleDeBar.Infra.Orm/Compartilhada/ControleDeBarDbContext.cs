using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Dominio.ModuloMesa;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.Compartilhada
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Garcom> Garçoms { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
             "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ControleBarDB;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(produtoBuilder =>
            {
                produtoBuilder.ToTable("TBProduto");

                produtoBuilder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                produtoBuilder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

                produtoBuilder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("real");
            });

            modelBuilder.Entity<Garcom>(garçomBuilder =>
            {
                garçomBuilder.ToTable("TBGarçom");

                garçomBuilder.Property(d => d.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                garçomBuilder.Property(d => d.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(250)");

                garçomBuilder.Property(d => d.Cpf)
                    .IsRequired()
                    .HasColumnType("varchar(14)");
            });

            modelBuilder.Entity<Pedido>(pedidoBuilder =>
            {
                pedidoBuilder.ToTable("TBPedido");

                pedidoBuilder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                pedidoBuilder.Property(p => p.NumeroPedido)
                .IsRequired()
                .HasColumnType("int");

                pedidoBuilder.Property(p => p.Quantidade)
                .IsRequired()
                .HasColumnType("int");

                pedidoBuilder.HasOne(p => p.Produto)
                .WithMany()
                .IsRequired()
                .HasForeignKey("Produto_Id")
                .HasConstraintName("FK_TBPedido_TBProduto")
                .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Mesa>(mesaBuilder =>
            {
                mesaBuilder.ToTable("TBMesa");

                mesaBuilder.Property(m => m.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                mesaBuilder.Property(m => m.Ocupada)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                mesaBuilder.Property(m => m.NumeroMesa)
                    .IsRequired()
                    .HasColumnType("varchar(5)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}
