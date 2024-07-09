using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TabelaMesaControl : UserControl
    {
        public TabelaMesaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Mesa> mesas)
        {
            grid.Rows.Clear();

            foreach (Mesa m in mesas)
                grid.Rows.Add(m.Id, m.Ocupada ? "Ocupada" : "Disponivel", m.NumeroMesa);
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Número da Mesa", HeaderText = "Número da Mesa" }
            };
        }
    }
}
