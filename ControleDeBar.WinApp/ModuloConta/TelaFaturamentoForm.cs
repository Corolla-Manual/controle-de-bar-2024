using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado;
using System.Drawing.Text;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFaturamentoForm : Form
    {
        public TelaFaturamentoForm(List<Conta> contas)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.contas = contas;
            rdbDia.Checked = true;
        }

        private List<Conta> contas;

        private void RealizaFaturamento(string condicao)
        {
            double valor = 0;

            if (condicao == "dia")
            {
                foreach (Conta C in contas.FindAll(x => x.DataConclusao.Date == DateTime.Now.Date))
                {
                    valor += C.ValorTotal;
                }
            }

            else if (condicao == "semana")
            {
                DateTime semana = DateTime.Now.AddDays(-7);

                foreach (Conta c in contas.FindAll(x => x.DataConclusao.Date >= semana.Date))
                {
                    valor += c.ValorTotal;
                }
            }

            else if (condicao == "mes")
            {
                foreach (Conta c in contas.FindAll(x => x.DataConclusao.Month == DateTime.Now.Month))
                {
                    valor += c.ValorTotal;
                }
            }

            txtLucro.Text = valor.ToString();
        }

        private void rdbDia_CheckedChanged(object sender, EventArgs e)
        {
            RealizaFaturamento("dia");
        }

        private void rdbSemana_CheckedChanged(object sender, EventArgs e)
        {
            RealizaFaturamento("semana");
        }

        private void rdbMes_CheckedChanged(object sender, EventArgs e)
        {
            RealizaFaturamento("mes");
        }
    }
}
