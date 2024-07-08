using ControleDeBar.Dominio.ModuloMesa;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public interface IRepositorioMesa
    {
        void Cadastrar(Mesa novaMesa);
        bool Editar(int id, Mesa mesaEditada);
        bool Excluir(int id);
        Mesa SelecionarPorId(int idSelecionado);
        List<Mesa> SelecionarTodos();
    }
}
