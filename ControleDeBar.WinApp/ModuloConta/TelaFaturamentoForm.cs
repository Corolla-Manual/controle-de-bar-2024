﻿using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.WinApp.Compartilhado;

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
            listBox1.Items.Clear();

            if (condicao == "dia")
            {
                foreach (Conta C in contas.FindAll(x => x.DataConclusao.Date == DateTime.Now.Date))
                {
                    valor += C.ValorTotal;
                    listBox1.Items.Add(C);
                }
            }

            else if (condicao == "semana")
            {
                DateTime semana = DateTime.Now.AddDays(-7);

                foreach (Conta c in contas.FindAll(x => x.DataConclusao.Date >= semana.Date))
                {
                    valor += c.ValorTotal;
                    listBox1.Items.Add(c);
                }
            }

            else if (condicao == "mes")
            {
                foreach (Conta c in contas.FindAll(x => x.DataConclusao.Month == DateTime.Now.Month))
                {
                    valor += c.ValorTotal;
                    listBox1.Items.Add(c);
                }
            }

            txtLucro.Text = "R$" + valor;
        }

        private void rdbDia_CheckedChanged(object sender, EventArgs e)
        {
            gbFaturamento.Text = "Faturamento do dia";
            RealizaFaturamento("dia");
        }

        private void rdbSemana_CheckedChanged(object sender, EventArgs e)
        {
            gbFaturamento.Text = "Faturamento da semana";
            RealizaFaturamento("semana");
        }

        private void rdbMes_CheckedChanged(object sender, EventArgs e)
        {
            gbFaturamento.Text = "Faturamento do mês";
            RealizaFaturamento("mes");
        }
    }
}
