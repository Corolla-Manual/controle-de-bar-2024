namespace ControleDeBar.WinApp.ModuloPedido
{
    partial class TelaPedidoForm
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
            NumPedido = new NumericUpDown();
            label2 = new Label();
            button3 = new Button();
            btnGravar = new Button();
            cmbProdutos = new ComboBox();
            label3 = new Label();
            NumQuantidade = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumQuantidade).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Número do Pedido:";
            // 
            // NumPedido
            // 
            NumPedido.Location = new Point(134, 24);
            NumPedido.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NumPedido.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumPedido.Name = "NumPedido";
            NumPedido.Size = new Size(121, 23);
            NumPedido.TabIndex = 1;
            NumPedido.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 70);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 2;
            label2.Text = "Produtos disponiveis:";
            // 
            // button3
            // 
            button3.DialogResult = DialogResult.Cancel;
            button3.Location = new Point(218, 144);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(134, 144);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // cmbProdutos
            // 
            cmbProdutos.FormattingEnabled = true;
            cmbProdutos.Location = new Point(134, 66);
            cmbProdutos.Name = "cmbProdutos";
            cmbProdutos.Size = new Size(159, 23);
            cmbProdutos.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 111);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 11;
            label3.Text = "Quantidade:";
            // 
            // NumQuantidade
            // 
            NumQuantidade.Location = new Point(135, 109);
            NumQuantidade.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            NumQuantidade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumQuantidade.Name = "NumQuantidade";
            NumQuantidade.Size = new Size(57, 23);
            NumQuantidade.TabIndex = 4;
            NumQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TelaPedidoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 179);
            Controls.Add(NumQuantidade);
            Controls.Add(label3);
            Controls.Add(cmbProdutos);
            Controls.Add(btnGravar);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(NumPedido);
            Controls.Add(label1);
            Name = "TelaPedidoForm";
            Text = "Cadastro de Pedido";
            ((System.ComponentModel.ISupportInitialize)NumPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown NumPedido;
        private Label label2;
        private Button button3;
        private Button btnGravar;
        private ComboBox cmbProdutos;
        private Label label3;
        private NumericUpDown NumQuantidade;
    }
}