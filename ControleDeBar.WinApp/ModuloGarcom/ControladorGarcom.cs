using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloGarcom
{
    public class ControladorGarcom : ControladorBase
    {
        public override string TipoCadastro => "Garcom";

        public override string ToolTipAdicionar => "Cadastrar um novo Garcom";

        public override string ToolTipEditar => "Editar um Garcom existente";

        public override string ToolTipExcluir => "Excluir um Garcom existente";

        TabelaGarcomControl tabelaGarcom;

        IRepositorioGarcom repositorioGarcom;

        public ControladorGarcom(IRepositorioGarcom repositorioGarcom)
        {
            this.repositorioGarcom = repositorioGarcom;
        }

        public override void Adicionar()
        {
            List<Garcom> garcomsCadastrados = repositorioGarcom.SelecionarTodos();

            TelaGarcomForm telaGarcom = new TelaGarcomForm(garcomsCadastrados);

            DialogResult resultado = telaGarcom.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom novoRegistro = telaGarcom.Garcom;

            repositorioGarcom.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{novoRegistro.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garcomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Garcom> garcomsCadastrados = repositorioGarcom.SelecionarTodos();

            TelaGarcomForm telaGarcom = new TelaGarcomForm(garcomsCadastrados);

            telaGarcom.Garcom = garcomSelecionado;

            DialogResult resultado = telaGarcom.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom registroEditado = telaGarcom.Garcom;

            repositorioGarcom.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{registroEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom garcomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garcomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{garcomSelecionado.Nome}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioGarcom.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{garcomSelecionado.Nome}\" foi exluído com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaGarcom == null)
                tabelaGarcom = new TabelaGarcomControl();

            CarregarRegistros();

            return tabelaGarcom;
        }

        public override void CarregarRegistros()
        {
            List<Garcom> garcoms = repositorioGarcom.SelecionarTodos();

            tabelaGarcom.AtualizarRegistros(garcoms);
            AtualizarQuantidadeRodape();
        }

        private void AtualizarQuantidadeRodape()
        {
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {repositorioGarcom.SelecionarTodos().Count} registro(s)...");
        }
    }
}
