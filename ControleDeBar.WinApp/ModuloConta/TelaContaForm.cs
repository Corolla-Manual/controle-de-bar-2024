using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
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

        public TelaContaForm(List<Garcom> garcons, List<Mesa> mesas)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarComboBox(garcons, mesas);
        }

        private void CarregarComboBox(List<Garcom> garcons, List<Mesa> mesas)
        {
            foreach (Garcom g in garcons)
            {
                comboBoxGarcom.Items.Add(g);
            }
            foreach (Mesa m in mesas)
            {
                if (!m.Ocupada)
                    comboBoxMesa.Items.Add(m);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Garcom garcom = (Garcom)comboBoxGarcom.SelectedItem!;
            Mesa mesa = (Mesa)comboBoxMesa.SelectedItem!;

            conta = new Conta(mesa, garcom);

            List<string> erros = new List<string>();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
