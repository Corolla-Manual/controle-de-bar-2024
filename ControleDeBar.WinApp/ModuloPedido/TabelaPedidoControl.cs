using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloPedido
{
    public partial class TabelaPedidoControl : UserControl
    {
        public TabelaPedidoControl()
        {
            InitializeComponent();
            Grid.Columns.AddRange(ObterColunas());
            Grid.ConfigurarGridSomenteLeitura();
            Grid.ConfigurarGridZebrado();
        }
        public void AtualizarRegistros(List<Pedido> pedidos)
        {
            Grid.Rows.Clear();

            foreach (Pedido p in pedidos)
                Grid.Rows.Add(p.Id, p.NumeroPedido, p.Produto, p.Quantidade);
        }

        public int ObterRegistroSelecionado()
        {
            return Grid.SelecionarId();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroPedido", HeaderText = "Número do Pedido" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Produto", HeaderText = "Produto" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Quantidade" }
            };
        }
    }
}
