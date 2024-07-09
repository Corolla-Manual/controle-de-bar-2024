using ControleDeBar.Dominio.ModuloGarcom;

namespace ControleDeBar.WinApp.ModuloGarcom
{
    public partial class TelaGarcomForm : Form
    {
        public Garcom Garcom
        {
            get => garcom;

            set
            {
                txtNome.Text = value.Nome;
                txtCpf.Text = value.Cpf;
            }
        }

        private Garcom garcom;

        private List<Garcom> garcomsCadastrados;

        public TelaGarcomForm(List<Garcom> garcomsCadastrados)
        {
            InitializeComponent();

            this.garcomsCadastrados = garcomsCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            garcom = new Garcom(txtNome.Text, txtCpf.Text);

            List<string> erros = garcom.Validar();

            if (GarcomTemCpfDuplicado())
                erros.Add("Já existe um garcom com este cpf cadastrado");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

        }

        private bool GarcomTemCpfDuplicado()
        {
            return garcomsCadastrados.Any(c => c.Cpf == garcom.Cpf);
        }
    }
}
