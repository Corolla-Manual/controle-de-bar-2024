namespace ControleDeBar.WinApp.ModuloProduto
{
    partial class TelaProdutoForm
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
            txtNome = new TextBox();
            numPreco = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numPreco).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 29);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 59);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Preço: R$";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(77, 26);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(303, 23);
            txtNome.TabIndex = 0;
            // 
            // numPreco
            // 
            numPreco.DecimalPlaces = 2;
            numPreco.Location = new Point(77, 55);
            numPreco.Name = "numPreco";
            numPreco.Size = new Size(101, 23);
            numPreco.TabIndex = 1;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(224, 84);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Gravar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(305, 84);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // TelaProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 120);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(numPreco);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaProdutoForm";
            Text = "Cadastro de Produtos";
            ((System.ComponentModel.ISupportInitialize)numPreco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNome;
        private NumericUpDown numPreco;
        private Button button1;
        private Button button2;
    }
}