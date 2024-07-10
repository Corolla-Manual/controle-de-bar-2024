using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaPedidoForm : Form
    {
        private Conta conta;
        public Conta Conta
        {
            get { return conta; }
            set
            {
                conta = value;

                foreach (Pedido p in conta.Pedidos)
                {
                    ListaPedidos.Items.Add(p);
                }
            }
        }
        public TelaPedidoForm(List<Produto> produtos)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarProdutos(produtos);
        }

        private void CarregarProdutos(List<Produto> produtos)
        {
            foreach (Produto produto in produtos)
            {
                cmbProdutos.Items.Add(produto);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Produto prod = (Produto)cmbProdutos.SelectedItem;
            int quantidade = (int)NumQuantidade.Value;

            Pedido pedido = new Pedido(prod, quantidade);

            List<string> erros = pedido.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                return;
            }

            ListaPedidos.Items.Add(pedido);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (ListaPedidos.SelectedItem != null)
                ListaPedidos.Items.Remove(ListaPedidos.SelectedItem);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            List<Pedido> pedidos = new List<Pedido>();

            foreach (Pedido p in ListaPedidos.Items)
            {
                pedidos.Add(p);
            }

            conta.Pedidos = pedidos;
            conta.CalcularValorTotal();
        }
    }
}
