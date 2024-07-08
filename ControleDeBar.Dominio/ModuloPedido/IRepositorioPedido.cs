namespace ControleDeBar.Dominio.ModuloPedido
{
    public interface IRepositorioPedido
    {
        void Cadastrar(Pedido novoPedido);
        bool Editar(int id, Pedido pedidoEditado);
        bool Excluir(int id);
        Pedido SelecionarPorId(int idSelecionado);
        List<Pedido> SelecionarTodos();
    }
}
