namespace ControleDeBar.Dominio.ModuloConta
{
    public interface IRepositorioConta
    {
        void Cadastrar(Conta novaConta);
        bool Editar(int id, Conta contaEditada);
        bool Excluir(int id);
        Conta SelecionarPorId(int idSelecionado);
        List<Conta> SelecionarEmAberto();
        List<Conta> SelecionarTodos();
    }
}
