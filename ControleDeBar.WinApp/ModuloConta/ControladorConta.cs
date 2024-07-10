using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase, IControladorAdicionar,
        IControladorConcluir, IControladorEmAberto, IControladorFaturamento, IControladorApenasCadastravel
    {
        TabelaContaControl tabelaConta;

        IRepositorioConta repositorioConta;
        IRepositorioGarcom repositorioGarcom;
        IRepositorioMesa repositorioMesa;
        IRepositorioPedido repositorioPedido;
        IRepositorioProduto repositorioProduto;

        public ControladorConta(IRepositorioConta repositorioConta, IRepositorioMesa repositorioMesa,
            IRepositorioPedido repositorioPedido, IRepositorioGarcom repositorioGarcom, IRepositorioProduto repositorioProduto)
        {
            this.repositorioConta = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioMesa = repositorioMesa;
            this.repositorioPedido = repositorioPedido;
        }

        public override string TipoCadastro => "Conta";

        public override string ToolTipAdicionar => "Cadastrar uma nova Conta";

        public override string ToolTipEditar => "Editar uma Conta existente";

        public override string ToolTipExcluir => "Excluir uma Conta existente";

        public string ToolTipAdicionarItem => "Adicionar um pedido a conta.";

        public string ToolTipConcluir => "Conclui uma conta em aberto.";

        public string ToolTipVisualizarEmAberto => "Visualizar as contas em aberto.";

        public string ToolTipFaturamento => "Visualizar o faturamento.";

        public override void Adicionar()
        {
            List<Conta> contaCadastradas = repositorioConta.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(repositorioGarcom.SelecionarTodos(), repositorioMesa.SelecionarTodos());

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Conta novoRegistro = telaConta.Conta;

            novoRegistro.Mesa.Ocupada = true;

            repositorioConta.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta foi criada com sucesso!");
        }

        public override void Editar()
        {
            //Não é necessário
        }

        public override void Excluir()
        {
            //Não é necessário
        }
        public void AdicionarItem()
        {
            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            if (contaSelecionada.Concluida)
            {
                MessageBox.Show(
                    "Você não pode adicionar pedidos a uma conta concluída!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaPedidoForm telaFechamento = new TelaPedidoForm(repositorioProduto.SelecionarTodos());

            telaFechamento.Conta = contaSelecionada;

            DialogResult resultado = telaFechamento.ShowDialog();

            if (resultado != DialogResult.OK)
                return;


            Conta registroEditado = telaFechamento.Conta;

            repositorioConta.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"Os pedidos na Conta de Id \"{registroEditado.Id}\" foram adicionados com sucesso!");
        }

        public void Concluir()
        {
            int idSelecionado = tabelaConta.ObterRegistroSelecionado();

            Conta contaSelecionada = repositorioConta.SelecionarPorId(idSelecionado);

            if (contaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (contaSelecionada.Concluida)
            {
                MessageBox.Show(
                    "Você não pode concluir uma conta já concluída!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TelaFechamentoForm telaFechamento = new TelaFechamentoForm();

            telaFechamento.Conta = contaSelecionada;

            contaSelecionada.Mesa.Ocupada = false;

            DialogResult resultado = telaFechamento.ShowDialog();

            if (resultado != DialogResult.OK)
                return;


            Conta registroEditado = telaFechamento.Conta;

            repositorioConta.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta de Id \"{registroEditado.Id}\" foi fechada com sucesso!");
        }

        public void VisualizarEmAberto(ToolStripButton btn)
        {
            if (btn.BackColor != Control.DefaultBackColor)
            {
                btn.BackColor = Control.DefaultBackColor;
                CarregarRegistros();
                return;
            }
            btn.BackColor = Color.LightSkyBlue;
            List<Conta> contas = repositorioConta.SelecionarEmAberto();
            tabelaConta.AtualizarRegistros(contas);
            AtualizarQuantidadeRodape(contas);
        }

        public void Faturamento()
        {
            TelaFaturamentoForm telaFaturamento = new TelaFaturamentoForm(repositorioConta.SelecionarTodos());

            telaFaturamento.ShowDialog();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaConta == null)
                tabelaConta = new TabelaContaControl();

            CarregarRegistros();

            return tabelaConta;
        }

        public override void CarregarRegistros()
        {
            List<Conta> contas = repositorioConta.SelecionarTodos();

            tabelaConta.AtualizarRegistros(contas);
            AtualizarQuantidadeRodape(contas);
        }

        private void AtualizarQuantidadeRodape(List<Conta> contas)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {contas.Count} registro(s)...");
        }
    }
}
