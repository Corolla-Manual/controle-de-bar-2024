using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFaturamentoForm : Form
    {
        public TelaFaturamentoForm(Conta conta)
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
    }
}
