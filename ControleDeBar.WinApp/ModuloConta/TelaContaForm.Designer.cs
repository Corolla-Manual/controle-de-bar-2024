namespace ControleDeBar.WinApp.ModuloConta
{
    partial class TelaContaForm
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
            comboBoxGarcom = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBoxMesa = new ComboBox();
            btnGravar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBoxGarcom
            // 
            comboBoxGarcom.FormattingEnabled = true;
            comboBoxGarcom.Location = new Point(106, 75);
            comboBoxGarcom.Name = "comboBoxGarcom";
            comboBoxGarcom.Size = new Size(121, 23);
            comboBoxGarcom.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 78);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Garcom:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 110);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "Mesa:";
            // 
            // comboBoxMesa
            // 
            comboBoxMesa.FormattingEnabled = true;
            comboBoxMesa.Location = new Point(106, 107);
            comboBoxMesa.Name = "comboBoxMesa";
            comboBoxMesa.Size = new Size(121, 23);
            comboBoxMesa.TabIndex = 1;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(106, 180);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(89, 30);
            btnGravar.TabIndex = 3;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.Cancel;
            button1.Location = new Point(203, 180);
            button1.Name = "button1";
            button1.Size = new Size(89, 30);
            button1.TabIndex = 2;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // TelaContaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 222);
            Controls.Add(btnGravar);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxMesa);
            Controls.Add(comboBoxGarcom);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaContaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Conta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxGarcom;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxMesa;
        private Button btnGravar;
        private Button button1;
    }
}