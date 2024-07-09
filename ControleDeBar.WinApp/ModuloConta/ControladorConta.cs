using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.Dominio.ModuloConta;

namespace ControleDeBar.WinApp.ModuloConta
{
    public class ControladorConta : ControladorBase
    {
        TabelaContaControl tabelaConta;

        IRepositorioConta repositorioConta;

        public ControladorConta(IRepositorioConta repositorioConta)
        {
            this.repositorioConta = repositorioConta;
        }

        public override string TipoCadastro => "Conta";

        public override string ToolTipAdicionar => "Cadastrar uma nova Conta";

        public override string ToolTipEditar => "Editar uma Conta existente";

        public override string ToolTipExcluir => "Excluir uma Conta existente";

        public override void Adicionar()
        {
            List<Conta> contaCadastradas = repositorioConta.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(contaCadastradas);

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Conta novoRegistro = telaConta.Conta;

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

            List<Conta> contaCadastradas = repositorioConta.SelecionarTodos();

            TelaContaForm telaConta = new TelaContaForm(contaCadastradas);

            telaConta.Conta = contaSelecionada;

            DialogResult resultado = telaConta.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Conta registroEditado = telaConta.Conta;

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

            repositorioConta.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Conta de Id\"{contaSelecionada.Id}\" foi exluída com sucesso!");
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
        }
    }
}
