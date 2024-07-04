using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.WinApp.ModuloGarçom
{
    public class ControladorGarcom : ControladorBase
    {
        public override string TipoCadastro => "Garçom";

        public override string ToolTipAdicionar => "Cadastrar um novo Garçom";

        public override string ToolTipEditar => "Editar um Garçom existente";

        public override string ToolTipExcluir => "Excluir um Garçom existente";

        TabelaGarcomControl tabelaGarçom;

        IRepositorioGarcom repositorioGarçom;

        public ControladorGarcom(IRepositorioGarcom repositorioGarçom)
        {
            this.repositorioGarçom = repositorioGarçom;
        }

        public override void Adicionar()
        {
            List<Garcom> garçomsCadastrados = repositorioGarçom.SelecionarTodos();

            TelaGarcomForm telaGarçom = new TelaGarcomForm(garçomsCadastrados);

            DialogResult resultado = telaGarçom.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom novoRegistro = telaGarçom.Garçom;

            repositorioGarçom.Cadastrar(novoRegistro);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{novoRegistro.Nome}\" foi criado com sucesso!");
        }

        public override void Editar()
        {
            int idSelecionado = tabelaGarçom.ObterRegistroSelecionado();

            Garcom garçomSelecionado = repositorioGarçom.SelecionarPorId(idSelecionado);

            if (garçomSelecionado == null)
            {
                MessageBox.Show(
                    "Você precisa selecionar um registro para executar esta ação!",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<Garcom> garçomsCadastrados = repositorioGarçom.SelecionarTodos();

            TelaGarcomForm telaDisciplina = new TelaGarcomForm(garçomsCadastrados);

            telaDisciplina.Garçom = garçomSelecionado;

            DialogResult resultado = telaDisciplina.ShowDialog();

            if (resultado != DialogResult.OK)
                return;

            Garcom registroEditado = telaDisciplina.Garçom;

            repositorioGarçom.Editar(idSelecionado, registroEditado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{registroEditado.Nome}\" foi editado com sucesso!");
        }

        public override void Excluir()
        {
            int idSelecionado = tabelaGarçom.ObterRegistroSelecionado();

            Garcom garçomSelecionado = repositorioGarçom.SelecionarPorId(idSelecionado);

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

            repositorioGarçom.Excluir(idSelecionado);

            CarregarRegistros();

            TelaPrincipalForm.Instancia.AtualizarRodape($"O registro \"{garçomSelecionado.Nome}\" foi exluído com sucesso!");
        }

        public override UserControl ObterListagem()
        {
            if (tabelaGarçom == null)
                tabelaGarçom = new TabelaGarcomControl();

            CarregarRegistros();

            return tabelaGarçom;
        }

        public override void CarregarRegistros()
        {
            List<Garcom> garçoms = repositorioGarçom.SelecionarTodos();

            tabelaGarçom.AtualizarRegistros(garçoms);
        }
    }
}
