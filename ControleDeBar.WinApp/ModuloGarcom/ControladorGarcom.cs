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
            List<Garcom> garçomsCadastrados = repositorioGarcom.SelecionarTodos();

            TelaGarcomForm telaGarcom = new TelaGarcomForm(garçomsCadastrados);

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

            Garcom garçomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garçomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Garcom> garçomsCadastrados = repositorioGarcom.SelecionarTodos();

            TelaGarcomForm telaDisciplina = new TelaGarcomForm(garçomsCadastrados);

            telaDisciplina.Garcom = garçomSelecionado;

            DialogResult resultado = telaDisciplina.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom registroEditado = telaDisciplina.Garcom;

            repositorioGarcom.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{registroEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaGarcom.ObterRegistroSelecionado();

            Garcom garçomSelecionado = repositorioGarcom.SelecionarPorId(idSelecionado);

            if (garçomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{garçomSelecionado.Nome}\" ",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (resposta != DialogResult.Yes)
                return;

            repositorioGarcom.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{garçomSelecionado.Nome}\" foi exluído com sucesso!");
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
            List<Garcom> garçoms = repositorioGarcom.SelecionarTodos();

            tabelaGarcom.AtualizarRegistros(garçoms);
        }
    }
}
