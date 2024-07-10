using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase, IControladorAdicionar,
        IControladorConcluir, IControladorEmAberto, IControladorFaturamento
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

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta de ID \"{novoRegistro.Id}\" foi criada com sucesso!");
        }

        public override void Editar()
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
                    "Você não pode editar uma conta já fechada!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Conta> contaCadastradas = repositorioConta.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(repositorioGarcom.SelecionarTodos(), repositorioMesa.SelecionarTodos());

            telaConta.Conta = contaSelecionada;

            contaSelecionada.Mesa.Ocupada = false;
            repositorioMesa.Editar(contaSelecionada.Mesa.Id, contaSelecionada.Mesa);

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;


            Conta registroEditado = telaConta.Conta;

            registroEditado.Mesa.Ocupada = true;
            repositorioConta.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta de Id \"{registroEditado.Id}\" foi editada com sucesso!");
        }

        public override void Excluir()
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

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir a conta de Id \"{contaSelecionada.Id}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            contaSelecionada.Mesa.Ocupada = false;
            repositorioConta.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta de Id\"{contaSelecionada.Id}\" foi excluída com sucesso!");
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
            throw new NotImplementedException();
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
