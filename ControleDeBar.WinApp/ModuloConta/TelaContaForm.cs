using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloConta
{
    public partial class TelaContaForm : Form
    {
        private Conta conta;
        public Conta Conta
        {
            get { return conta; }
            set
            {
                comboBoxGarcom.SelectedItem = value.Garcom;
                comboBoxMesa.SelectedItem = value.Mesa;
            }
        }

        private List<Conta> contasCadastradas;

        public TelaContaForm(List<Conta> contasCadastradas)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.contasCadastradas = contasCadastradas;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Garcom garcom = (Garcom)comboBoxGarcom.SelectedItem!;
            Mesa mesa = (Mesa)comboBoxMesa.SelectedItem!;

            List<Pedido> pedidos = new List<Pedido>();

            conta = new Conta(pedidos, mesa, garcom, 0, false);

            List<string> erros = new List<string>();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
