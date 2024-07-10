﻿using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloConta;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.Infra.Orm.ModuloPedido;
using ControleDeBar.Infra.Orm.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;
using ControleDeBar.WinApp.ModuloConta;
using ControleDeBar.WinApp.ModuloGarcom;
using ControleDeBar.WinApp.ModuloMesa;
using ControleDeBar.WinApp.ModuloProduto;

namespace ControleDeBar.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;
        IRepositorioProduto repositorioProduto;
        IRepositorioMesa repositorioMesa;
        IRepositorioGarcom repositorioGarcom;
        IRepositorioPedido repositorioPedido;
        IRepositorioConta repositorioConta;

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;

            ControleDeBarDbContext dbContext = new ControleDeBarDbContext();
            repositorioProduto = new RepositorioProdutoEmOrm(dbContext);
            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);
            repositorioMesa = new RepositorioMesaEmOrm(dbContext);
            repositorioPedido = new RepositorioPedidoEmOrm(dbContext);
            repositorioConta = new RepositorioContaEmOrm(dbContext);
        }

        private void garcomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorGarcom(repositorioGarcom);

            ConfigurarTelaPrincipal(controlador);
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorProduto(repositorioProduto);
            ConfigurarTelaPrincipal(controlador);
        }

        private void mesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorMesa(repositorioMesa);
            ConfigurarTelaPrincipal(controlador);
        }
        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorConta(repositorioConta, repositorioMesa,
                repositorioPedido, repositorioGarcom, repositorioProduto);
            ConfigurarTelaPrincipal(controlador);
        }
        public void AtualizarRodape(string texto)
        {
            statusLabelPrincipal.Text = texto;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorSelecionado)
        {
            lblTipoCadastro.Text = "Cadastro de " + controladorSelecionado.TipoCadastro;

            ConfigurarToolBox(controladorSelecionado);
            ConfigurarListagem(controladorSelecionado);
        }

        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = controladorSelecionado is ControladorBase;
            btnEditar.Enabled = controladorSelecionado is ControladorBase;
            btnExcluir.Enabled = controladorSelecionado is ControladorBase;

            btn_ContasEmAberto.Enabled = controladorSelecionado is IControladorEmAberto;
            btn_AdicionarPedido.Enabled = controladorSelecionado is IControladorAdicionar;
            btn_FecharConta.Enabled = controladorSelecionado is IControladorConcluir;
            btn_Faturamento.Enabled = controladorSelecionado is IControladorFaturamento;

            if (controladorSelecionado is IControladorApenasCadastravel)
            {
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }

            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorEmAberto controladorVisualizavel)
                btn_ContasEmAberto.ToolTipText = controladorVisualizavel.ToolTipVisualizarEmAberto;

            if (controladorSelecionado is IControladorFaturamento controladorFaturamento)
                btn_Faturamento.ToolTipText = controladorFaturamento.ToolTipFaturamento;

            if (controladorSelecionado is IControladorConcluir controladorConcluir)
                btn_FecharConta.ToolTipText = controladorConcluir.ToolTipConcluir;

            if (controladorSelecionado is IControladorAdicionar controladorAdicionar)
                btn_AdicionarPedido.ToolTipText = controladorAdicionar.ToolTipAdicionarItem;
        }

        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagem = controladorSelecionado.ObterListagem();
            listagem.Dock = DockStyle.Fill;

            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagem);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorEmAberto controladorVisualizavel)
                controladorVisualizavel.VisualizarEmAberto(btn_ContasEmAberto);

        }
        private void btn_AdicionarPedido_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorAdicionar controladorAdicionar)
                controladorAdicionar.AdicionarItem();
        }

        private void btn_FecharConta_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorConcluir controladorConcluir)
                controladorConcluir.Concluir();
        }

        private void btn_Faturamento_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorFaturamento controladorFaturamento)
                controladorFaturamento.Faturamento();
        }
        private void TelaPrincipalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
