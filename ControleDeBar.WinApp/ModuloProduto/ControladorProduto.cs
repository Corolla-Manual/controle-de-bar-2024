using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        TabelaProdutoControl tabelaProduto;
        IRepositorioProduto repositorioProduto;

        public ControladorProduto(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public override string TipoCadastro => "Produto";

        public override string ToolTipAdicionar => "Adicionar um produto.";

        public override string ToolTipEditar => "Editar um produto existente.";

        public override string ToolTipExcluir => "Remover um produto existente.";

        public override void Adicionar()
        {
            List<Produto> ProdutosCadastradas = repositorioProduto.SelecionarTodos();

            TelaProdutoForm telaProduto = new TelaProdutoForm(ProdutosCadastradas);

            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Produto novoRegistro = telaProduto.Produto;

            repositorioProduto.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{novoRegistro.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto ProdutoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if (ProdutoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Produto> ProdutosCadastradas = repositorioProduto.SelecionarTodos();

            TelaProdutoForm telaProduto = new TelaProdutoForm(ProdutosCadastradas);

            telaProduto.Produto = ProdutoSelecionado;

            DialogResult resultado = telaProduto.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Produto registroEditado = telaProduto.Produto;

            repositorioProduto.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{registroEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaProduto.ObterRegistroSelecionado();

            Produto ProdutoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);

            if (ProdutoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{ProdutoSelecionado.Nome}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioProduto.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{ProdutoSelecionado.Nome}\" foi excluído com sucesso!");
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
            AtualizarQuantidadeRodape();
        }

        private void AtualizarQuantidadeRodape()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {repositorioProduto.SelecionarTodos().Count} registro(s)...");
        }
    }
}
