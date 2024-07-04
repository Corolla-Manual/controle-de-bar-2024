using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        TabelaProdutoControl tabelaProduto;
        IRepositorioProduto repositorioProduto;

        public ControladorProduto()
        {

        }

        public override string TipoCadastro => "Produto";

        public override string ToolTipAdicionar => "Adicionar um produto.";

        public override string ToolTipEditar => "Editar um produto existente.";

        public override string ToolTipExcluir => "Remover um produto existente.";

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaProduto == null)
                tabelaProduto = new TabelaProdutoControl();

            CarregarRegistros();

            return tabelaProduto;
        }

        public override void CarregarRegistros()
        {
            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            tabelaProduto.AtualizarRegistros(produtos);
        }
    }
}
