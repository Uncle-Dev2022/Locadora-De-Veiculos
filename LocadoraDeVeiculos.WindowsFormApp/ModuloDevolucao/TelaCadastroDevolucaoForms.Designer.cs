namespace LocadoraDeVeiculos.WindowsFormApp.ModuloDevolucao
{
    partial class TelaCadastroDevolucaoForms
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkedListBoxTaxasSelecionadas = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkedListBoxTaxasAdicionais = new System.Windows.Forms.CheckedListBox();
            this.comboBoxCombustivel = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDevolucaoReal = new System.Windows.Forms.DateTimePicker();
            this.textBoxquilometragemDevolucao = new System.Windows.Forms.TextBox();
            this.labelFuncionario = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelCondutor = new System.Windows.Forms.Label();
            this.labelGrupoDeVeiculo = new System.Windows.Forms.Label();
            this.labelVeiculo = new System.Windows.Forms.Label();
            this.labelPlanoDeCobranca = new System.Windows.Forms.Label();
            this.labelDataDaLocacao = new System.Windows.Forms.Label();
            this.labelDevolucaoPrevista = new System.Windows.Forms.Label();
            this.labelValorTotal = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(528, 607);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 39);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(447, 607);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(72, 39);
            this.btnGravar.TabIndex = 20;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Funcionário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Condutor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Grupo De Veículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Veículo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Plano De Cobrança:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 174);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Data Da Locação:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 198);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Devolução Prevista:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 222);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Quilometragem Devolução";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 246);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Data De Devolução";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 270);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Nivel do Tanque de Conbustível:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 607);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.TabIndex = 33;
            this.label12.Text = "Valor Toral:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(75, 300);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 289);
            this.tabControl1.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBoxTaxasSelecionadas);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Taxas Ja Selecionadas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTaxasSelecionadas
            // 
            this.checkedListBoxTaxasSelecionadas.CheckOnClick = true;
            this.checkedListBoxTaxasSelecionadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTaxasSelecionadas.Enabled = false;
            this.checkedListBoxTaxasSelecionadas.FormattingEnabled = true;
            this.checkedListBoxTaxasSelecionadas.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxTaxasSelecionadas.Name = "checkedListBoxTaxasSelecionadas";
            this.checkedListBoxTaxasSelecionadas.Size = new System.Drawing.Size(370, 255);
            this.checkedListBoxTaxasSelecionadas.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkedListBoxTaxasAdicionais);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Taxas Adicionais ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTaxasAdicionais
            // 
            this.checkedListBoxTaxasAdicionais.CheckOnClick = true;
            this.checkedListBoxTaxasAdicionais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTaxasAdicionais.FormattingEnabled = true;
            this.checkedListBoxTaxasAdicionais.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxTaxasAdicionais.Name = "checkedListBoxTaxasAdicionais";
            this.checkedListBoxTaxasAdicionais.Size = new System.Drawing.Size(370, 255);
            this.checkedListBoxTaxasAdicionais.TabIndex = 1;
            // 
            // comboBoxCombustivel
            // 
            this.comboBoxCombustivel.FormattingEnabled = true;
            this.comboBoxCombustivel.Items.AddRange(new object[] {
            "- 1/4",
            "-2/4",
            "-3/4",
            "-4/4"});
            this.comboBoxCombustivel.Location = new System.Drawing.Point(208, 267);
            this.comboBoxCombustivel.Name = "comboBoxCombustivel";
            this.comboBoxCombustivel.Size = new System.Drawing.Size(121, 23);
            this.comboBoxCombustivel.TabIndex = 35;
            // 
            // dateTimePickerDevolucaoReal
            // 
            this.dateTimePickerDevolucaoReal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDevolucaoReal.Location = new System.Drawing.Point(208, 240);
            this.dateTimePickerDevolucaoReal.Name = "dateTimePickerDevolucaoReal";
            this.dateTimePickerDevolucaoReal.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDevolucaoReal.TabIndex = 36;
            // 
            // textBoxquilometragemDevolucao
            // 
            this.textBoxquilometragemDevolucao.Location = new System.Drawing.Point(208, 214);
            this.textBoxquilometragemDevolucao.Name = "textBoxquilometragemDevolucao";
            this.textBoxquilometragemDevolucao.Size = new System.Drawing.Size(100, 23);
            this.textBoxquilometragemDevolucao.TabIndex = 37;
            // 
            // labelFuncionario
            // 
            this.labelFuncionario.AutoSize = true;
            this.labelFuncionario.Location = new System.Drawing.Point(208, 26);
            this.labelFuncionario.Name = "labelFuncionario";
            this.labelFuncionario.Size = new System.Drawing.Size(12, 15);
            this.labelFuncionario.TabIndex = 38;
            this.labelFuncionario.Text = "-";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(208, 50);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(12, 15);
            this.labelCliente.TabIndex = 39;
            this.labelCliente.Text = "-";
            // 
            // labelCondutor
            // 
            this.labelCondutor.AutoSize = true;
            this.labelCondutor.Location = new System.Drawing.Point(208, 74);
            this.labelCondutor.Name = "labelCondutor";
            this.labelCondutor.Size = new System.Drawing.Size(12, 15);
            this.labelCondutor.TabIndex = 40;
            this.labelCondutor.Text = "-";
            // 
            // labelGrupoDeVeiculo
            // 
            this.labelGrupoDeVeiculo.AutoSize = true;
            this.labelGrupoDeVeiculo.Location = new System.Drawing.Point(208, 99);
            this.labelGrupoDeVeiculo.Name = "labelGrupoDeVeiculo";
            this.labelGrupoDeVeiculo.Size = new System.Drawing.Size(12, 15);
            this.labelGrupoDeVeiculo.TabIndex = 41;
            this.labelGrupoDeVeiculo.Text = "-";
            // 
            // labelVeiculo
            // 
            this.labelVeiculo.AutoSize = true;
            this.labelVeiculo.Location = new System.Drawing.Point(208, 125);
            this.labelVeiculo.Name = "labelVeiculo";
            this.labelVeiculo.Size = new System.Drawing.Size(12, 15);
            this.labelVeiculo.TabIndex = 42;
            this.labelVeiculo.Text = "-";
            // 
            // labelPlanoDeCobranca
            // 
            this.labelPlanoDeCobranca.AutoSize = true;
            this.labelPlanoDeCobranca.Location = new System.Drawing.Point(208, 150);
            this.labelPlanoDeCobranca.Name = "labelPlanoDeCobranca";
            this.labelPlanoDeCobranca.Size = new System.Drawing.Size(12, 15);
            this.labelPlanoDeCobranca.TabIndex = 43;
            this.labelPlanoDeCobranca.Text = "-";
            // 
            // labelDataDaLocacao
            // 
            this.labelDataDaLocacao.AutoSize = true;
            this.labelDataDaLocacao.Location = new System.Drawing.Point(208, 174);
            this.labelDataDaLocacao.Name = "labelDataDaLocacao";
            this.labelDataDaLocacao.Size = new System.Drawing.Size(12, 15);
            this.labelDataDaLocacao.TabIndex = 44;
            this.labelDataDaLocacao.Text = "-";
            // 
            // labelDevolucaoPrevista
            // 
            this.labelDevolucaoPrevista.AutoSize = true;
            this.labelDevolucaoPrevista.Location = new System.Drawing.Point(208, 198);
            this.labelDevolucaoPrevista.Name = "labelDevolucaoPrevista";
            this.labelDevolucaoPrevista.Size = new System.Drawing.Size(12, 15);
            this.labelDevolucaoPrevista.TabIndex = 45;
            this.labelDevolucaoPrevista.Text = "-";
            // 
            // labelValorTotal
            // 
            this.labelValorTotal.AutoSize = true;
            this.labelValorTotal.Location = new System.Drawing.Point(174, 607);
            this.labelValorTotal.Name = "labelValorTotal";
            this.labelValorTotal.Size = new System.Drawing.Size(12, 15);
            this.labelValorTotal.TabIndex = 46;
            this.labelValorTotal.Text = "-";
            // 
            // TelaCadastroDevolucaoForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 658);
            this.Controls.Add(this.labelValorTotal);
            this.Controls.Add(this.labelDevolucaoPrevista);
            this.Controls.Add(this.labelDataDaLocacao);
            this.Controls.Add(this.labelPlanoDeCobranca);
            this.Controls.Add(this.labelVeiculo);
            this.Controls.Add(this.labelGrupoDeVeiculo);
            this.Controls.Add(this.labelCondutor);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.labelFuncionario);
            this.Controls.Add(this.textBoxquilometragemDevolucao);
            this.Controls.Add(this.dateTimePickerDevolucaoReal);
            this.Controls.Add(this.comboBoxCombustivel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroDevolucaoForms";
            this.Text = "Tela Cadastro Devolucao";
            this.Load += new System.EventHandler(this.TelaCadastroDevolucaoForms_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxCombustivel;
        private System.Windows.Forms.DateTimePicker dateTimePickerDevolucaoReal;
        private System.Windows.Forms.TextBox textBoxquilometragemDevolucao;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxasSelecionadas;
        private System.Windows.Forms.CheckedListBox checkedListBoxTaxasAdicionais;
        private System.Windows.Forms.Label labelFuncionario;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelCondutor;
        private System.Windows.Forms.Label labelGrupoDeVeiculo;
        private System.Windows.Forms.Label labelVeiculo;
        private System.Windows.Forms.Label labelPlanoDeCobranca;
        private System.Windows.Forms.Label labelDataDaLocacao;
        private System.Windows.Forms.Label labelDevolucaoPrevista;
        private System.Windows.Forms.Label labelValorTotal;
    }
}