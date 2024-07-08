using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.WinApp.Compartilhado;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeBar.WinApp.ModuloMesa
{
    public partial class TelaMesaForm : Form
    {
        private Mesa mesa;

        public Mesa Mesa
        {
            get => mesa;

            set
            {
                numMesa.Value = value.NumeroMesa;
            }
        }

        private List<Mesa> mesasCadastradas;

        public TelaMesaForm(List<Mesa> mesasCadastradas)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.mesasCadastradas = mesasCadastradas;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int numeromesa = (int)numMesa.Value;

            mesa = new Mesa(numeromesa);

            List<string> erros = new List<string>();

            if (MesaTemNumeroDuplicado())
                erros.Add("Já existe uma mesa com este número cadastrado");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private bool MesaTemNumeroDuplicado()
        {
            return mesasCadastradas.Any(m => m.NumeroMesa == mesa.NumeroMesa);
        }
    }
}
