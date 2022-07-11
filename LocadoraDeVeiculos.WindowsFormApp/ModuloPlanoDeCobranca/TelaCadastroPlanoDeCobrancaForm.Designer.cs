namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    partial class TelaCadastroPlanoDeCobrancaForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelDiario = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxDiarioValorKM = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxDiarioValorDiario = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControlDiario = new System.Windows.Forms.TabControl();
            this.Diario = new System.Windows.Forms.TabPage();
            this.Livre = new System.Windows.Forms.TabPage();
            this.Controlado = new System.Windows.Forms.TabPage();
            this.panelLivre = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxLivreValorDiario = new System.Windows.Forms.MaskedTextBox();
            this.panelControlado = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxControladoValorKM = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxControladoValorDiario = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxLimiteKM = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.panelDiario.SuspendLayout();
            this.tabControlDiario.SuspendLayout();
            this.Diario.SuspendLayout();
            this.Livre.SuspendLayout();
            this.Controlado.SuspendLayout();
            this.panelLivre.SuspendLayout();
            this.panelControlado.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Gravar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelDiario
            // 
            this.panelDiario.Controls.Add(this.label3);
            this.panelDiario.Controls.Add(this.TextBoxDiarioValorKM);
            this.panelDiario.Controls.Add(this.TextBoxDiarioValorDiario);
            this.panelDiario.Controls.Add(this.label2);
            this.panelDiario.Location = new System.Drawing.Point(6, 6);
            this.panelDiario.Name = "panelDiario";
            this.panelDiario.Size = new System.Drawing.Size(280, 171);
            this.panelDiario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor Diário:";
            // 
            // TextBoxDiarioValorKM
            // 
            this.TextBoxDiarioValorKM.Location = new System.Drawing.Point(135, 70);
            this.TextBoxDiarioValorKM.Mask = "R$ 0000,00";
            this.TextBoxDiarioValorKM.Name = "TextBoxDiarioValorKM";
            this.TextBoxDiarioValorKM.Size = new System.Drawing.Size(98, 23);
            this.TextBoxDiarioValorKM.TabIndex = 5;
            // 
            // TextBoxDiarioValorDiario
            // 
            this.TextBoxDiarioValorDiario.Location = new System.Drawing.Point(135, 27);
            this.TextBoxDiarioValorDiario.Mask = "R$ 0000,00";
            this.TextBoxDiarioValorDiario.Name = "TextBoxDiarioValorDiario";
            this.TextBoxDiarioValorDiario.Size = new System.Drawing.Size(98, 23);
            this.TextBoxDiarioValorDiario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor por Km:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grupo de Veículo:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // tabControlDiario
            // 
            this.tabControlDiario.Controls.Add(this.Diario);
            this.tabControlDiario.Controls.Add(this.Livre);
            this.tabControlDiario.Controls.Add(this.Controlado);
            this.tabControlDiario.Location = new System.Drawing.Point(12, 95);
            this.tabControlDiario.Name = "tabControlDiario";
            this.tabControlDiario.SelectedIndex = 0;
            this.tabControlDiario.Size = new System.Drawing.Size(300, 211);
            this.tabControlDiario.TabIndex = 5;
            // 
            // Diario
            // 
            this.Diario.Controls.Add(this.panelDiario);
            this.Diario.Location = new System.Drawing.Point(4, 24);
            this.Diario.Name = "Diario";
            this.Diario.Padding = new System.Windows.Forms.Padding(3);
            this.Diario.Size = new System.Drawing.Size(292, 183);
            this.Diario.TabIndex = 0;
            this.Diario.Text = "Diário";
            this.Diario.UseVisualStyleBackColor = true;
            // 
            // Livre
            // 
            this.Livre.Controls.Add(this.panelLivre);
            this.Livre.Location = new System.Drawing.Point(4, 24);
            this.Livre.Name = "Livre";
            this.Livre.Padding = new System.Windows.Forms.Padding(3);
            this.Livre.Size = new System.Drawing.Size(292, 183);
            this.Livre.TabIndex = 1;
            this.Livre.Text = "Livre";
            this.Livre.UseVisualStyleBackColor = true;
            // 
            // Controlado
            // 
            this.Controlado.Controls.Add(this.panelControlado);
            this.Controlado.Location = new System.Drawing.Point(4, 24);
            this.Controlado.Name = "Controlado";
            this.Controlado.Padding = new System.Windows.Forms.Padding(3);
            this.Controlado.Size = new System.Drawing.Size(292, 183);
            this.Controlado.TabIndex = 2;
            this.Controlado.Text = "Controlado";
            this.Controlado.UseVisualStyleBackColor = true;
            // 
            // panelLivre
            // 
            this.panelLivre.Controls.Add(this.label4);
            this.panelLivre.Controls.Add(this.TextBoxLivreValorDiario);
            this.panelLivre.Location = new System.Drawing.Point(6, 6);
            this.panelLivre.Name = "panelLivre";
            this.panelLivre.Size = new System.Drawing.Size(280, 171);
            this.panelLivre.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Valor Diário:";
            // 
            // TextBoxLivreValorDiario
            // 
            this.TextBoxLivreValorDiario.Location = new System.Drawing.Point(135, 27);
            this.TextBoxLivreValorDiario.Mask = "R$ 0000,00";
            this.TextBoxLivreValorDiario.Name = "TextBoxLivreValorDiario";
            this.TextBoxLivreValorDiario.Size = new System.Drawing.Size(98, 23);
            this.TextBoxLivreValorDiario.TabIndex = 3;
            // 
            // panelControlado
            // 
            this.panelControlado.Controls.Add(this.TextBoxLimiteKM);
            this.panelControlado.Controls.Add(this.label5);
            this.panelControlado.Controls.Add(this.label6);
            this.panelControlado.Controls.Add(this.TextBoxControladoValorKM);
            this.panelControlado.Controls.Add(this.TextBoxControladoValorDiario);
            this.panelControlado.Controls.Add(this.label7);
            this.panelControlado.Location = new System.Drawing.Point(6, 6);
            this.panelControlado.Name = "panelControlado";
            this.panelControlado.Size = new System.Drawing.Size(280, 171);
            this.panelControlado.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Valor Diário:";
            // 
            // TextBoxControladoValorKM
            // 
            this.TextBoxControladoValorKM.Location = new System.Drawing.Point(135, 70);
            this.TextBoxControladoValorKM.Mask = "R$ 0000,00";
            this.TextBoxControladoValorKM.Name = "TextBoxControladoValorKM";
            this.TextBoxControladoValorKM.Size = new System.Drawing.Size(98, 23);
            this.TextBoxControladoValorKM.TabIndex = 5;
            // 
            // TextBoxControladoValorDiario
            // 
            this.TextBoxControladoValorDiario.Location = new System.Drawing.Point(135, 27);
            this.TextBoxControladoValorDiario.Mask = "R$ 0000,00";
            this.TextBoxControladoValorDiario.Name = "TextBoxControladoValorDiario";
            this.TextBoxControladoValorDiario.Size = new System.Drawing.Size(98, 23);
            this.TextBoxControladoValorDiario.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Valor por Km:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Limite KM:";
            // 
            // TextBoxLimiteKM
            // 
            this.TextBoxLimiteKM.Location = new System.Drawing.Point(135, 112);
            this.TextBoxLimiteKM.Mask = "R$ 0000,00";
            this.TextBoxLimiteKM.Name = "TextBoxLimiteKM";
            this.TextBoxLimiteKM.Size = new System.Drawing.Size(98, 23);
            this.TextBoxLimiteKM.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nome: ";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(132, 16);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(158, 23);
            this.textBoxNome.TabIndex = 7;
            // 
            // TelaCadastroPlanoDeCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 376);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControlDiario);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TelaCadastroPlanoDeCobranca";
            this.Text = "TelaCadastroPlanoDeCobranca";
            this.panelDiario.ResumeLayout(false);
            this.panelDiario.PerformLayout();
            this.tabControlDiario.ResumeLayout(false);
            this.Diario.ResumeLayout(false);
            this.Livre.ResumeLayout(false);
            this.Controlado.ResumeLayout(false);
            this.panelLivre.ResumeLayout(false);
            this.panelLivre.PerformLayout();
            this.panelControlado.ResumeLayout(false);
            this.panelControlado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelDiario;
        private System.Windows.Forms.MaskedTextBox TextBoxDiarioValorKM;
        private System.Windows.Forms.MaskedTextBox TextBoxDiarioValorDiario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControlDiario;
        private System.Windows.Forms.TabPage Diario;
        private System.Windows.Forms.TabPage Livre;
        private System.Windows.Forms.TabPage Controlado;
        private System.Windows.Forms.Panel panelLivre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TextBoxLivreValorDiario;
        private System.Windows.Forms.Panel panelControlado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TextBoxControladoValorKM;
        private System.Windows.Forms.MaskedTextBox TextBoxControladoValorDiario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox TextBoxLimiteKM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNome;
    }
}