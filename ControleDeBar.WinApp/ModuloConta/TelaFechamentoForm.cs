using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaFechamentoForm : Form
    {
        private Conta conta;
        public Conta Conta
        {
            get { return conta; }
            set
            {
                conta = value;
                txtMesa.Text = "" + value.Mesa;
                txtGarcom.Text = "" + value.Garcom;
                foreach (Pedido p in value.Pedidos)
                {
                    ListaPedidos.Items.Add(p);
                }
                txtPreco.Text = "" + value.ValorTotal;
            }
        }
        public TelaFechamentoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            conta.Mesa.Ocupada = false;
            conta.Concluida = true;
        }

        private void txtMesa_Click(object sender, EventArgs e)
        {

        }
    }
}
