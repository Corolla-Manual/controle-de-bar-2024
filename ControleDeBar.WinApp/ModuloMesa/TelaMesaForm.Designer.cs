namespace ControleDeBar.WinApp.ModuloMesa
{
    partial class TelaMesaForm
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
            btnGravar = new Button();
            button1 = new Button();
            numMesa = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numMesa).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 77);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "Número da mesa:";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(105, 140);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(89, 30);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(202, 140);
            button1.Name = "button1";
            button1.Size = new Size(89, 30);
            button1.TabIndex = 1;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // numMesa
            // 
            numMesa.Location = new Point(146, 73);
            numMesa.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMesa.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMesa.Name = "numMesa";
            numMesa.Size = new Size(120, 23);
            numMesa.TabIndex = 3;
            numMesa.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TelaMesaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 187);
            Controls.Add(numMesa);
            Controls.Add(btnGravar);
            Controls.Add(button1);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaMesaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Mesa";
            ((System.ComponentModel.ISupportInitialize)numMesa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGravar;
        private Button button1;
        private NumericUpDown numMesa;
    }
}