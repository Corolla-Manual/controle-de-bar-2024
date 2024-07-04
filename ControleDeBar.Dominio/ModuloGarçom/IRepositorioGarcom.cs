using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.Dominio.ModuloGarcom
{
    public interface IRepositorioGarcom
    {
        void Cadastrar(Garcom novoGarçom);
        bool Editar(int id, Garcom garçomEditado);
        bool Excluir(int id);
        Garcom SelecionarPorId(int idSelecionado);
        List<Garcom> SelecionarTodos();
    }
}
