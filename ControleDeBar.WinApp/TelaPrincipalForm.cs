

using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloGarcom;
using ControleDeBar.Infra.Orm.ModuloMesa;
using ControleDeBar.Infra.Orm.ModuloPedido;
using ControleDeBar.Infra.Orm.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;
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

        public static TelaPrincipalForm Instancia { get; private set; }

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;

            ControleDeBarDbContext dbContext = new ControleDeBarDbContext();

            repositorioProduto = new RepositorioProdutoEmOrm(dbContext);

            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);

            repositorioGarcom = new RepositorioGarcomEmOrm(dbContext);

            repositorioMesa = new RepositorioMesaEmOrm(dbContext);
            repositorioPedido = new RepositorioPedidoEmOrm(dbContext);
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

            btnVisualizar.Enabled = controladorSelecionado is IControladorVisualizavel;

            ConfigurarToolTips(controladorSelecionado);
        }

        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorVisualizavel controladorVisualizavel)
                btnVisualizar.ToolTipText = controladorVisualizavel.ToolTipVisualizar;

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
            if (controlador is IControladorVisualizavel controladorVisualizavel)
                controladorVisualizavel.Visualizar();
        }
        private void TelaPrincipalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
