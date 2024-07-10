using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloMesa
{
    internal class ControladorMesa : ControladorBase
    {
        public override string TipoCadastro => "Mesa";

        public override string ToolTipAdicionar => "Adicionar uma Mesa";

        public override string ToolTipEditar => "Editar uma mesa existente";

        public override string ToolTipExcluir => "Remover uma mesa existente";

        TabelaMesaControl tabelaMesa;

        IRepositorioMesa repositorioMesa;

        public ControladorMesa(IRepositorioMesa repositorioMesa)
        {
            this.repositorioMesa = repositorioMesa;
        }

        public override void Adicionar()
        {
            List<Mesa> mesasCadastradas = repositorioMesa.SelecionarTodos();

            TelaMesaForm telaMesa = new TelaMesaForm(mesasCadastradas);

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Mesa novoRegistro = telaMesa.Mesa;

            repositorioMesa.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A Mesa de número \"{novoRegistro.NumeroMesa}\" foi criada com sucesso!");
        }


        public override void Editar()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Mesa> mesasCadastradas = repositorioMesa.SelecionarTodos();

            TelaMesaForm telaMesa = new TelaMesaForm(mesasCadastradas);

            telaMesa.Mesa = mesaSelecionada;

            DialogResult resultado = telaMesa.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Mesa registroEditado = telaMesa.Mesa;

            repositorioMesa.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A mesa de número \"{registroEditado.NumeroMesa}\" foi editada com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaMesa.ObterRegistroSelecionado();

            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(idSelecionado);

            if (mesaSelecionada == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro da mesa de número \"{mesaSelecionada.NumeroMesa}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                repositorioMesa.Excluir(idSelecionado);
            }
            catch
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{mesaSelecionada.NumeroMesa}\" esta em uso e não pode ser excluído!");
                return;
            }

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"A mesa de número \"{mesaSelecionada.NumeroMesa}\" foi excluida com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMesa == null)
                tabelaMesa = new TabelaMesaControl();

            CarregarRegistros();

            return tabelaMesa;
        }

        public override void CarregarRegistros()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarTodos();

            tabelaMesa.AtualizarRegistros(mesas);
            AtualizarQuantidadeRodape();
        }

        private void AtualizarQuantidadeRodape()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {repositorioMesa.SelecionarTodos().Count} registro(s)...");
        }
    }
}
