namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
{
    partial class TelaCadastroFuncionarioForm
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
            this.txtBoxFuncionarioNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxFuncionarioSalario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxGerente = new System.Windows.Forms.CheckBox();
            this.txtBoxFuncionarioSenha = new System.Windows.Forms.TextBox();
            this.txtBoxFuncionarioLogin = new System.Windows.Forms.TextBox();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtBoxFuncionarioNome
            // 
            this.txtBoxFuncionarioNome.Location = new System.Drawing.Point(328, 62);
            this.txtBoxFuncionarioNome.Name = "txtBoxFuncionarioNome";
            this.txtBoxFuncionarioNome.Size = new System.Drawing.Size(268, 31);
            this.txtBoxFuncionarioNome.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nome:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(356, 369);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 65);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(240, 369);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(103, 65);
            this.btnGravar.TabIndex = 18;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Salário:";
            // 
            // txtBoxFuncionarioSalario
            // 
            this.txtBoxFuncionarioSalario.Location = new System.Drawing.Point(328, 99);
            this.txtBoxFuncionarioSalario.MaxLength = 10;
            this.txtBoxFuncionarioSalario.Name = "txtBoxFuncionarioSalario";
            this.txtBoxFuncionarioSalario.Size = new System.Drawing.Size(268, 31);
            this.txtBoxFuncionarioSalario.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Data de Admissão: (dd/mm/aaa)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Senha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Login:";
            // 
            // checkBoxGerente
            // 
            this.checkBoxGerente.AutoSize = true;
            this.checkBoxGerente.Location = new System.Drawing.Point(328, 274);
            this.checkBoxGerente.Name = "checkBoxGerente";
            this.checkBoxGerente.Size = new System.Drawing.Size(248, 29);
            this.checkBoxGerente.TabIndex = 29;
            this.checkBoxGerente.Text = "FUNCIONARIO É GERENTE";
            this.checkBoxGerente.UseVisualStyleBackColor = true;
            // 
            // txtBoxFuncionarioSenha
            // 
            this.txtBoxFuncionarioSenha.Location = new System.Drawing.Point(328, 173);
            this.txtBoxFuncionarioSenha.MaxLength = 10;
            this.txtBoxFuncionarioSenha.Name = "txtBoxFuncionarioSenha";
            this.txtBoxFuncionarioSenha.Size = new System.Drawing.Size(268, 31);
            this.txtBoxFuncionarioSenha.TabIndex = 30;
            // 
            // txtBoxFuncionarioLogin
            // 
            this.txtBoxFuncionarioLogin.Location = new System.Drawing.Point(328, 210);
            this.txtBoxFuncionarioLogin.MaxLength = 10;
            this.txtBoxFuncionarioLogin.Name = "txtBoxFuncionarioLogin";
            this.txtBoxFuncionarioLogin.Size = new System.Drawing.Size(268, 31);
            this.txtBoxFuncionarioLogin.TabIndex = 31;
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(328, 136);
            this.maskedTextBox.Mask = "00/00/0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(268, 31);
            this.maskedTextBox.TabIndex = 33;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 500);
            this.Controls.Add(this.maskedTextBox);
            this.Controls.Add(this.txtBoxFuncionarioLogin);
            this.Controls.Add(this.txtBoxFuncionarioSenha);
            this.Controls.Add(this.checkBoxGerente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxFuncionarioSalario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxFuncionarioNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Name = "TelaCadastroFuncionarioForm";
            this.Text = "Tela Cadastro Funcionario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxFuncionarioNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxFuncionarioSalario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxGerente;
        private System.Windows.Forms.TextBox txtBoxFuncionarioSenha;
        private System.Windows.Forms.TextBox txtBoxFuncionarioLogin;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
    }
}