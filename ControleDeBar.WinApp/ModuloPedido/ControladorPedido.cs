using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloPedido
{
    public class ControladorPedido : ControladorBase
    {
        IRepositorioPedido repositorioPedido;
        List<Produto> produtos;
        TabelaPedidoControl tabelaPedido;
        public ControladorPedido(IRepositorioPedido repositorioPedido, IRepositorioProduto repositorioProduto)
        {
            this.repositorioPedido = repositorioPedido;
            produtos = repositorioProduto.SelecionarTodos();
        }

        public override string TipoCadastro => "Pedido";

        public override string ToolTipAdicionar => "Cadastrar um novo pedido.";

        public override string ToolTipEditar => "Editar um pedido existente.";

        public override string ToolTipExcluir => "Excluir um pedido existente.";

        public override void Adicionar()
        {
            List<Pedido> PedidosCadastradas = repositorioPedido.SelecionarTodos();
            TelaPedidoForm telaPedido = new TelaPedidoForm(PedidosCadastradas, produtos);

            DialogResult resultado = telaPedido.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Pedido novoRegistro = telaPedido.Pedido;

            repositorioPedido.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{novoRegistro.NumeroPedido}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaPedido.ObterRegistroSelecionado();

            Pedido PedidoSelecionado = repositorioPedido.SelecionarPorId(idSelecionado);

            if (PedidoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Pedido> pedidosCadastrados = repositorioPedido.SelecionarTodos();

            TelaPedidoForm telaPedido = new TelaPedidoForm(pedidosCadastrados, produtos);

            telaPedido.Pedido = PedidoSelecionado;

            DialogResult resultado = telaPedido.ShowDialog();
            if (resultado != DialogResult.OK)
                return;

            Pedido registroEditado = telaPedido.Pedido;

            repositorioPedido.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{registroEditado.NumeroPedido}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaPedido.ObterRegistroSelecionado();

            Pedido PedidoSelecionado = repositorioPedido.SelecionarPorId(idSelecionado);

            if (PedidoSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{PedidoSelecionado.NumeroPedido}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resposta != DialogResult.Yes)
                return;

            repositorioPedido.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{PedidoSelecionado.NumeroPedido}\" foi excluído com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaPedido == null)
                tabelaPedido = new TabelaPedidoControl();

            CarregarRegistros();

            return tabelaPedido;
        }
        public override void CarregarRegistros()
        {
            List<Pedido> pedidos = repositorioPedido.SelecionarTodos();
            tabelaPedido.AtualizarRegistros(pedidos);
            AtualizarQuantidadeRodape();
        }
        private void AtualizarQuantidadeRodape()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {repositorioPedido.SelecionarTodos().Count} registro(s)...");
        }
    }
}
