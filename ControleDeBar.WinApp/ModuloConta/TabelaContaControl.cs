using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TabelaContaControl : UserControl
    {
        public TabelaContaControl()
        {
            InitializeComponent();
            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Conta> contas)
        {
            grid.Rows.Clear();

            foreach (Conta c in contas)
                grid.Rows.Add(c.Id, c.Pedidos, c.Mesa, c.Garcom, c.Concluida, c.ValorTotal);
        }
        public int ObterRegistroSelecionado()
        {
            return grid.SelecionarId();
        }

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Pedidos", HeaderText = "Pedidos" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Mesa", HeaderText = "Mesa" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Garcom", HeaderText = "Garcom" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Concluida", HeaderText = "Concluida" },
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "ValorTotal" }
            };
        }
    }
}
