using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloPedido
{
    public partial class TelaPedidoForm : Form
    {
        private List<Pedido> pedidos;
        private Pedido pedido;
        public Pedido Pedido
        {
            get { return pedido; }
            set
            {
                NumPedido.Value = value.NumeroPedido;
                cmbProdutos.SelectedItem = value.Produto;
                NumQuantidade.Value = value.Quantidade;
            }
        }
        public TelaPedidoForm(List<Pedido> pedidos, List<Produto> produtos)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.pedidos = pedidos;
            CarregarProdutosDisponiveis(produtos);
        }

        private void CarregarProdutosDisponiveis(List<Produto> produtos)
        {
            foreach (Produto p in produtos)
            {
                cmbProdutos.Items.Add(p);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Produto produtoSelecionado = (Produto)cmbProdutos.SelectedItem;

            int numeroPedido = (int)NumPedido.Value;

            int quantidade = (int)NumQuantidade.Value;

            pedido = new Pedido(numeroPedido, produtoSelecionado, quantidade);


            List<string> erros = pedido.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }

            if (pedidos.Find(p => p.NumeroPedido == pedido.NumeroPedido) != null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Já existe um pedido com esse número!");
                DialogResult = DialogResult.None;
            }
        }
    }
}
