namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaFechamentoForm
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
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            ListaPedidos = new ListBox();
            label3 = new Label();
            txtMesa = new Label();
            txtGarcom = new Label();
            txtPreco = new Label();
            btnCancelar = new Button();
            btnConcluir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Mesa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Garçom:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 202);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 3;
            label4.Text = "Total: R$";
            // 
            // ListaPedidos
            // 
            ListaPedidos.FormattingEnabled = true;
            ListaPedidos.ItemHeight = 15;
            ListaPedidos.Location = new Point(12, 90);
            ListaPedidos.Name = "ListaPedidos";
            ListaPedidos.SelectionMode = SelectionMode.None;
            ListaPedidos.Size = new Size(248, 109);
            ListaPedidos.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 72);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Pedidos:";
            // 
            // txtMesa
            // 
            txtMesa.AutoSize = true;
            txtMesa.Location = new Point(70, 19);
            txtMesa.Name = "txtMesa";
            txtMesa.Size = new Size(38, 15);
            txtMesa.TabIndex = 5;
            txtMesa.Text = "label5";
            txtMesa.Click += txtMesa_Click;
            // 
            // txtGarcom
            // 
            txtGarcom.AutoSize = true;
            txtGarcom.Location = new Point(70, 44);
            txtGarcom.Name = "txtGarcom";
            txtGarcom.Size = new Size(38, 15);
            txtGarcom.TabIndex = 6;
            txtGarcom.Text = "label5";
            // 
            // txtPreco
            // 
            txtPreco.AutoSize = true;
            txtPreco.Location = new Point(64, 202);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(38, 15);
            txtPreco.TabIndex = 7;
            txtPreco.Text = "label5";
            txtPreco.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(185, 220);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConcluir
            // 
            btnConcluir.DialogResult = DialogResult.OK;
            btnConcluir.Location = new Point(104, 220);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(75, 23);
            btnConcluir.TabIndex = 1;
            btnConcluir.Text = "Concluir";
            btnConcluir.UseVisualStyleBackColor = true;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // TelaFechamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 254);
            Controls.Add(btnConcluir);
            Controls.Add(btnCancelar);
            Controls.Add(txtPreco);
            Controls.Add(txtGarcom);
            Controls.Add(txtMesa);
            Controls.Add(ListaPedidos);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaFechamentoForm";
            Text = "Fechamento de Conta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private ListBox ListaPedidos;
        private Label label3;
        private Label txtMesa;
        private Label txtGarcom;
        private Label txtPreco;
        private Button btnCancelar;
        private Button btnConcluir;
    }
}