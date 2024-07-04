using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloGarçom
{
    public partial class TabelaGarcomControl : UserControl
    {
        public TabelaGarcomControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }
        
        public void AtualizarRegistros(List<Garcom> garçoms)
        {
            grid.Rows.Clear();

            foreach (Garcom g in garçoms)
                grid.Rows.Add(g.Id, g.Nome, g.Cpf);
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "Cpf" }
            };
        }
    }
}
