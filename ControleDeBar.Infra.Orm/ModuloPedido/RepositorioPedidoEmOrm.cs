using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Infra.Orm.Compartilhada;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infra.Orm.ModuloPedido
{
    public class RepositorioPedidoEmOrm : IRepositorioPedido
    {
        ControleDeBarDbContext dbContext;

        public RepositorioPedidoEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Cadastrar(Pedido novoPedido)
        {
            dbContext.Pedidos.Add(novoPedido);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Pedido pedidoEditado)
        {
            Pedido pedido = dbContext.Pedidos.Find(id)!;

            if (pedido == null)
                return false;

            pedido.AtualizarRegistro(pedidoEditado);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Pedido pedido = dbContext.Pedidos.Find(id)!;

            if (pedido == null)
                return false;

            dbContext.Pedidos.Remove(pedido);
            dbContext.SaveChanges();

            return true;
        }

        public Pedido SelecionarPorId(int idSelecionado)
        {
            return dbContext.Pedidos.Find(idSelecionado)!;
        }

        public List<Pedido> SelecionarTodos()
        {
            return dbContext.Pedidos.Include(x => x.Produto).ToList();
        }
    }
}
