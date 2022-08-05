namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.FuncionarioSelecionadotxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkedListBoxTaxas = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnGravar1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.comboBoxGrupoDeVeiculo = new System.Windows.Forms.ComboBox();
            this.comboBoxPlanoDeCobranca = new System.Windows.Forms.ComboBox();
            this.comboBoxCondutor = new System.Windows.Forms.ComboBox();
            this.comboBoxVeiculo = new System.Windows.Forms.ComboBox();
            this.dateTimePickerLocacao = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDevolucao = new System.Windows.Forms.DateTimePicker();
            this.KmdoVeiculotxt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Valortxt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonControlado = new System.Windows.Forms.RadioButton();
            this.radioLivre = new System.Windows.Forms.RadioButton();
            this.radioDiario = new System.Windows.Forms.RadioButton();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Funcionario :";
            // 
            // FuncionarioSelecionadotxt
            // 
            this.FuncionarioSelecionadotxt.AutoSize = true;
            this.FuncionarioSelecionadotxt.Location = new System.Drawing.Point(126, 27);
            this.FuncionarioSelecionadotxt.Name = "FuncionarioSelecionadotxt";
            this.FuncionarioSelecionadotxt.Size = new System.Drawing.Size(111, 20);
            this.FuncionarioSelecionadotxt.TabIndex = 1;
            this.FuncionarioSelecionadotxt.Text = "[O Funcionario]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 40);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grupo De \r\nVeiculo :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "Plano De\r\nCobrança:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 40);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data De \r\nLocação :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Condutor :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Veiculo :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 40);
            this.label8.TabIndex = 8;
            this.label8.Text = "Km do  \r\nVeiculo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 364);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 40);
            this.label9.TabIndex = 9;
            this.label9.Text = "Devolução\r\nPrevista :";
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.checkedListBoxTaxas);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 113);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Taxas da Locação";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTaxas
            // 
            this.checkedListBoxTaxas.CheckOnClick = true;
            this.checkedListBoxTaxas.FormattingEnabled = true;
            this.checkedListBoxTaxas.Location = new System.Drawing.Point(1, 1);
            this.checkedListBoxTaxas.Name = "checkedListBoxTaxas";
            this.checkedListBoxTaxas.Size = new System.Drawing.Size(584, 114);
            this.checkedListBoxTaxas.TabIndex = 18;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 463);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 149);
            this.tabControl1.TabIndex = 10;
            // 
            // btnGravar1
            // 
            this.btnGravar1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar1.Location = new System.Drawing.Point(540, 628);
            this.btnGravar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGravar1.Name = "btnGravar1";
            this.btnGravar1.Size = new System.Drawing.Size(112, 52);
            this.btnGravar1.TabIndex = 16;
            this.btnGravar1.Text = "Gravar";
            this.btnGravar1.UseVisualStyleBackColor = true;
            this.btnGravar1.Click += new System.EventHandler(this.btnGravar1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(676, 628);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 52);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(126, 80);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(248, 28);
            this.comboBoxCliente.TabIndex = 18;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCliente_SelectedIndexChanged);
            // 
            // comboBoxGrupoDeVeiculo
            // 
            this.comboBoxGrupoDeVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupoDeVeiculo.FormattingEnabled = true;
            this.comboBoxGrupoDeVeiculo.Location = new System.Drawing.Point(126, 147);
            this.comboBoxGrupoDeVeiculo.Name = "comboBoxGrupoDeVeiculo";
            this.comboBoxGrupoDeVeiculo.Size = new System.Drawing.Size(248, 28);
            this.comboBoxGrupoDeVeiculo.TabIndex = 19;
            this.comboBoxGrupoDeVeiculo.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrupoDeVeiculo_SelectedIndexChanged);
            // 
            // comboBoxPlanoDeCobranca
            // 
            this.comboBoxPlanoDeCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlanoDeCobranca.FormattingEnabled = true;
            this.comboBoxPlanoDeCobranca.Location = new System.Drawing.Point(126, 227);
            this.comboBoxPlanoDeCobranca.Name = "comboBoxPlanoDeCobranca";
            this.comboBoxPlanoDeCobranca.Size = new System.Drawing.Size(248, 28);
            this.comboBoxPlanoDeCobranca.TabIndex = 20;
            this.comboBoxPlanoDeCobranca.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlanoDeCobranca_SelectedIndexChanged);
            // 
            // comboBoxCondutor
            // 
            this.comboBoxCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondutor.FormattingEnabled = true;
            this.comboBoxCondutor.Location = new System.Drawing.Point(540, 80);
            this.comboBoxCondutor.Name = "comboBoxCondutor";
            this.comboBoxCondutor.Size = new System.Drawing.Size(248, 28);
            this.comboBoxCondutor.TabIndex = 21;
            // 
            // comboBoxVeiculo
            // 
            this.comboBoxVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVeiculo.FormattingEnabled = true;
            this.comboBoxVeiculo.Location = new System.Drawing.Point(540, 147);
            this.comboBoxVeiculo.Name = "comboBoxVeiculo";
            this.comboBoxVeiculo.Size = new System.Drawing.Size(248, 28);
            this.comboBoxVeiculo.TabIndex = 22;
            // 
            // dateTimePickerLocacao
            // 
            this.dateTimePickerLocacao.Location = new System.Drawing.Point(126, 372);
            this.dateTimePickerLocacao.Name = "dateTimePickerLocacao";
            this.dateTimePickerLocacao.Size = new System.Drawing.Size(248, 27);
            this.dateTimePickerLocacao.TabIndex = 23;
            // 
            // dateTimePickerDevolucao
            // 
            this.dateTimePickerDevolucao.Location = new System.Drawing.Point(540, 372);
            this.dateTimePickerDevolucao.Name = "dateTimePickerDevolucao";
            this.dateTimePickerDevolucao.Size = new System.Drawing.Size(248, 27);
            this.dateTimePickerDevolucao.TabIndex = 24;
            // 
            // KmdoVeiculotxt
            // 
            this.KmdoVeiculotxt.AutoSize = true;
            this.KmdoVeiculotxt.Location = new System.Drawing.Point(540, 230);
            this.KmdoVeiculotxt.Name = "KmdoVeiculotxt";
            this.KmdoVeiculotxt.Size = new System.Drawing.Size(114, 20);
            this.KmdoVeiculotxt.TabIndex = 25;
            this.KmdoVeiculotxt.Text = "[Km do veiculo]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 628);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Total Previsto :  R$";
            // 
            // Valortxt
            // 
            this.Valortxt.AutoSize = true;
            this.Valortxt.Location = new System.Drawing.Point(149, 628);
            this.Valortxt.Name = "Valortxt";
            this.Valortxt.Size = new System.Drawing.Size(53, 20);
            this.Valortxt.TabIndex = 27;
            this.Valortxt.Text = "[Valor]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonControlado);
            this.groupBox1.Controls.Add(this.radioLivre);
            this.groupBox1.Controls.Add(this.radioDiario);
            this.groupBox1.Location = new System.Drawing.Point(56, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 80);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione o tipo";
            // 
            // radioButtonControlado
            // 
            this.radioButtonControlado.AutoSize = true;
            this.radioButtonControlado.Location = new System.Drawing.Point(320, 40);
            this.radioButtonControlado.Name = "radioButtonControlado";
            this.radioButtonControlado.Size = new System.Drawing.Size(105, 24);
            this.radioButtonControlado.TabIndex = 2;
            this.radioButtonControlado.TabStop = true;
            this.radioButtonControlado.Text = "Controlado";
            this.radioButtonControlado.UseVisualStyleBackColor = true;
            // 
            // radioLivre
            // 
            this.radioLivre.AutoSize = true;
            this.radioLivre.Location = new System.Drawing.Point(163, 40);
            this.radioLivre.Name = "radioLivre";
            this.radioLivre.Size = new System.Drawing.Size(61, 24);
            this.radioLivre.TabIndex = 1;
            this.radioLivre.TabStop = true;
            this.radioLivre.Text = "Livre";
            this.radioLivre.UseVisualStyleBackColor = true;
            // 
            // radioDiario
            // 
            this.radioDiario.AutoSize = true;
            this.radioDiario.Location = new System.Drawing.Point(6, 40);
            this.radioDiario.Name = "radioDiario";
            this.radioDiario.Size = new System.Drawing.Size(71, 24);
            this.radioDiario.TabIndex = 0;
            this.radioDiario.TabStop = true;
            this.radioDiario.Text = "Diario";
            this.radioDiario.UseVisualStyleBackColor = true;
            this.radioDiario.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 693);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Valortxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.KmdoVeiculotxt);
            this.Controls.Add(this.dateTimePickerDevolucao);
            this.Controls.Add(this.dateTimePickerLocacao);
            this.Controls.Add(this.comboBoxVeiculo);
            this.Controls.Add(this.comboBoxCondutor);
            this.Controls.Add(this.comboBoxPlanoDeCobranca);
            this.Controls.Add(this.comboBoxGrupoDeVeiculo);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGravar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FuncionarioSelecionadotxt);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.Text = "Tela Cadastro Locacao";
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FuncionarioSelecionadotxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnGravar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxas;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.ComboBox comboBoxGrupoDeVeiculo;
        private System.Windows.Forms.ComboBox comboBoxPlanoDeCobranca;
        private System.Windows.Forms.ComboBox comboBoxCondutor;
        private System.Windows.Forms.ComboBox comboBoxVeiculo;
        private System.Windows.Forms.DateTimePicker dateTimePickerLocacao;
        private System.Windows.Forms.DateTimePicker dateTimePickerDevolucao;
        private System.Windows.Forms.Label KmdoVeiculotxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Valortxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDiario;
        private System.Windows.Forms.RadioButton radioButtonControlado;
        private System.Windows.Forms.RadioButton radioLivre;
    }
}