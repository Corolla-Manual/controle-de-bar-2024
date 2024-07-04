using ControleDeBar.Dominio.ModuloGarcom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeBar.WinApp.ModuloGarçom
{
    public partial class TelaGarcomForm : Form
    {
        public Garcom Garçom
        {
            get => garçom;

            set
            {
                txtNome.Text = value.Nome;
                txtCpf.Text = value.Cpf;
            }
        }

        private Garcom garçom;

        private List<Garcom> garçomsCadastrados;

        public TelaGarcomForm(List<Garcom> garçomsCadastrados)
        {
            InitializeComponent();

            this.garçomsCadastrados = garçomsCadastrados;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            garçom = new Garcom(txtNome.Text, txtCpf.Text);

            List<string> erros = garçom.Validar();

            if (GarçomTemCpfDuplicado())
                erros.Add("Já existe um garçom com este cpf cadastrado");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

        }

        private bool GarçomTemCpfDuplicado()
        {
            return garçomsCadastrados.Any(c => c.Cpf == garçom.Cpf);
        }
    }
}
