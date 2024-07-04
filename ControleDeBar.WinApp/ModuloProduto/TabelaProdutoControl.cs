using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TabelaProdutoControl : UserControl
    {
        public TabelaProdutoControl()
        {
            InitializeComponent();
            Grid.Columns.AddRange(ObterColunas());
            Grid.ConfigurarGridSomenteLeitura();
            Grid.ConfigurarGridZebrado();
        }
        public void AtualizarRegistros(List<Produto> produtos)
        {
            Grid.Rows.Clear();

            foreach (Produto p in produtos)
                Grid.Rows.Add(p.Id, p.Nome, p.Preco);
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preço" }
            };
        }
    }
}
