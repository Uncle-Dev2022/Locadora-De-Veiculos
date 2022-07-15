﻿namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxGerente = new System.Windows.Forms.CheckBox();
            this.txtBoxFuncionarioSenha = new System.Windows.Forms.TextBox();
            this.txtBoxFuncionarioLogin = new System.Windows.Forms.TextBox();
            this.dateTimePickerDataAdmissao = new System.Windows.Forms.DateTimePicker();
            this.SenhaBox = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxSalario = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxFuncionarioNome
            // 
            this.txtBoxFuncionarioNome.Location = new System.Drawing.Point(161, 47);
            this.txtBoxFuncionarioNome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxFuncionarioNome.Name = "txtBoxFuncionarioNome";
            this.txtBoxFuncionarioNome.Size = new System.Drawing.Size(215, 27);
            this.txtBoxFuncionarioNome.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nome:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(481, 239);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 52);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(388, 239);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(82, 52);
            this.btnGravar.TabIndex = 18;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Salário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Data de Admissão:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Senha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Login:";
            // 
            // checkBoxGerente
            // 
            this.checkBoxGerente.AutoSize = true;
            this.checkBoxGerente.Location = new System.Drawing.Point(161, 203);
            this.checkBoxGerente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxGerente.Name = "checkBoxGerente";
            this.checkBoxGerente.Size = new System.Drawing.Size(206, 24);
            this.checkBoxGerente.TabIndex = 29;
            this.checkBoxGerente.Text = "FUNCIONARIO É GERENTE";
            this.checkBoxGerente.UseVisualStyleBackColor = true;
            // 
            // txtBoxFuncionarioSenha
            // 
            this.txtBoxFuncionarioSenha.Location = new System.Drawing.Point(161, 166);
            this.txtBoxFuncionarioSenha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxFuncionarioSenha.MaxLength = 10;
            this.txtBoxFuncionarioSenha.Name = "txtBoxFuncionarioSenha";
            this.txtBoxFuncionarioSenha.PasswordChar = '*';
            this.txtBoxFuncionarioSenha.Size = new System.Drawing.Size(215, 27);
            this.txtBoxFuncionarioSenha.TabIndex = 30;
            this.txtBoxFuncionarioSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxFuncionarioLogin
            // 
            this.txtBoxFuncionarioLogin.Location = new System.Drawing.Point(161, 136);
            this.txtBoxFuncionarioLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxFuncionarioLogin.MaxLength = 10;
            this.txtBoxFuncionarioLogin.Name = "txtBoxFuncionarioLogin";
            this.txtBoxFuncionarioLogin.Size = new System.Drawing.Size(215, 27);
            this.txtBoxFuncionarioLogin.TabIndex = 31;
            // 
            // dateTimePickerDataAdmissao
            // 
            this.dateTimePickerDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataAdmissao.Location = new System.Drawing.Point(161, 106);
            this.dateTimePickerDataAdmissao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerDataAdmissao.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerDataAdmissao.Name = "dateTimePickerDataAdmissao";
            this.dateTimePickerDataAdmissao.Size = new System.Drawing.Size(214, 27);
            this.dateTimePickerDataAdmissao.TabIndex = 32;
            // 
            // SenhaBox
            // 
            this.SenhaBox.AutoSize = true;
            this.SenhaBox.Location = new System.Drawing.Point(388, 166);
            this.SenhaBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SenhaBox.Name = "SenhaBox";
            this.SenhaBox.Size = new System.Drawing.Size(133, 24);
            this.SenhaBox.TabIndex = 33;
            this.SenhaBox.Text = "Mostrar Senha?";
            this.SenhaBox.UseVisualStyleBackColor = true;
            this.SenhaBox.CheckedChanged += new System.EventHandler(this.Senha_CheckedChanged);
            // 
            // maskedTextBoxSalario
            // 
            this.maskedTextBoxSalario.Location = new System.Drawing.Point(161, 77);
            this.maskedTextBoxSalario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maskedTextBoxSalario.Mask = "999999,99";
            this.maskedTextBoxSalario.Name = "maskedTextBoxSalario";
            this.maskedTextBoxSalario.Size = new System.Drawing.Size(121, 27);
            this.maskedTextBoxSalario.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "R$";
            // 
            // TelaCadastroFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 309);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxSalario);
            this.Controls.Add(this.SenhaBox);
            this.Controls.Add(this.dateTimePickerDataAdmissao);
            this.Controls.Add(this.txtBoxFuncionarioLogin);
            this.Controls.Add(this.txtBoxFuncionarioSenha);
            this.Controls.Add(this.checkBoxGerente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxFuncionarioNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TelaCadastroFuncionarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxGerente;
        private System.Windows.Forms.TextBox txtBoxFuncionarioSenha;
        private System.Windows.Forms.TextBox txtBoxFuncionarioLogin;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataAdmissao;
        private System.Windows.Forms.CheckBox SenhaBox;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSalario;
        private System.Windows.Forms.Label label6;
    }
}