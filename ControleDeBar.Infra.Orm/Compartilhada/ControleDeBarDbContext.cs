using ControleDeBar.Dominio.ModuloProduto;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.Compartilhada
{
    public class ControleDeBarDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }

}
