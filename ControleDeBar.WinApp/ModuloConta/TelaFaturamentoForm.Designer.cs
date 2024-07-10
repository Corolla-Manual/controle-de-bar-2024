namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaFaturamentoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rdbDia = new RadioButton();
            rdbMes = new RadioButton();
            rdbSemana = new RadioButton();
            txtLucro = new Label();
            button1 = new Button();
            gbFaturamento = new GroupBox();
            gbFaturamento.SuspendLayout();
            SuspendLayout();
            // 
            // rdbDia
            // 
            rdbDia.AutoSize = true;
            rdbDia.Location = new Point(24, 44);
            rdbDia.Name = "rdbDia";
            rdbDia.Size = new Size(161, 19);
            rdbDia.TabIndex = 0;
            rdbDia.Text = "Exibir Faturamento do dia";
            rdbDia.UseVisualStyleBackColor = true;
            rdbDia.CheckedChanged += rdbDia_CheckedChanged;
            // 
            // rdbMes
            // 
            rdbMes.AutoSize = true;
            rdbMes.Location = new Point(24, 94);
            rdbMes.Name = "rdbMes";
            rdbMes.Size = new Size(167, 19);
            rdbMes.TabIndex = 0;
            rdbMes.Text = "Exibir Faturamento do mês";
            rdbMes.UseVisualStyleBackColor = true;
            rdbMes.CheckedChanged += rdbMes_CheckedChanged;
            // 
            // rdbSemana
            // 
            rdbSemana.AutoSize = true;
            rdbSemana.Location = new Point(24, 69);
            rdbSemana.Name = "rdbSemana";
            rdbSemana.Size = new Size(185, 19);
            rdbSemana.TabIndex = 0;
            rdbSemana.Text = "Exibir Faturamento da semana";
            rdbSemana.UseVisualStyleBackColor = true;
            rdbSemana.CheckedChanged += rdbSemana_CheckedChanged;
            // 
            // txtLucro
            // 
            txtLucro.AutoSize = true;
            txtLucro.Location = new Point(6, 19);
            txtLucro.Name = "txtLucro";
            txtLucro.Size = new Size(13, 15);
            txtLucro.TabIndex = 1;
            txtLucro.Text = "0";
            txtLucro.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(282, 122);
            button1.Name = "button1";
            button1.Size = new Size(96, 25);
            button1.TabIndex = 2;
            button1.Text = "Fechar";
            button1.UseVisualStyleBackColor = true;
            // 
            // gbFaturamento
            // 
            gbFaturamento.Controls.Add(txtLucro);
            gbFaturamento.Location = new Point(219, 47);
            gbFaturamento.Name = "gbFaturamento";
            gbFaturamento.Size = new Size(159, 41);
            gbFaturamento.TabIndex = 3;
            gbFaturamento.TabStop = false;
            gbFaturamento.Text = "Faturamento";
            // 
            // TelaFaturamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 159);
            Controls.Add(gbFaturamento);
            Controls.Add(button1);
            Controls.Add(rdbSemana);
            Controls.Add(rdbMes);
            Controls.Add(rdbDia);
            Name = "TelaFaturamentoForm";
            Text = "Faturamento";
            gbFaturamento.ResumeLayout(false);
            gbFaturamento.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rdbDia;
        private RadioButton rdbMes;
        private RadioButton rdbSemana;
        private Label txtLucro;
        private Button button1;
        private GroupBox gbFaturamento;
    }
}