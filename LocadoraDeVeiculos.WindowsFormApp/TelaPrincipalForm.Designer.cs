﻿namespace LocadoraDeVeiculos.WindowsFormApp
{
    partial class TelaPrincipalForm
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
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelRodape = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTipoCadastro = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.toolbox = new System.Windows.Forms.ToolStrip();
            this.GrupoDeVeiculosSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuncionarioSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClienteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VeiculoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CondutorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocacaoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.statusStrip1.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRegistros
            // 
            this.panelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegistros.Location = new System.Drawing.Point(0, 65);
            this.panelRegistros.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(800, 359);
            this.panelRegistros.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRodape});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            this.labelRodape.Name = "labelRodape";
            this.labelRodape.Size = new System.Drawing.Size(67, 20);
            this.labelRodape.Text = "[rodapé]";
            // 
            // labelTipoCadastro
            // 
            this.labelTipoCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelTipoCadastro.Name = "labelTipoCadastro";
            this.labelTipoCadastro.Size = new System.Drawing.Size(121, 34);
            this.labelTipoCadastro.Text = "[tipoCadastro]";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolucao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Padding = new System.Windows.Forms.Padding(5);
            this.btnDevolucao.Size = new System.Drawing.Size(29, 34);
            this.btnDevolucao.Text = "Fazer Devolução";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Padding = new System.Windows.Forms.Padding(5);
            this.btnExcluir.Size = new System.Drawing.Size(66, 34);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(62, 34);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.AccessibleName = "";
            this.btnInserir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInserir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Padding = new System.Windows.Forms.Padding(5);
            this.btnInserir.Size = new System.Drawing.Size(63, 34);
            this.btnInserir.Text = "Inserir";
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // toolbox
            // 
            this.toolbox.Enabled = false;
            this.toolbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator2,
            this.btnDevolucao,
            this.toolStripSeparator4,
            this.labelTipoCadastro});
            this.toolbox.Location = new System.Drawing.Point(0, 28);
            this.toolbox.Name = "toolbox";
            this.toolbox.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolbox.Size = new System.Drawing.Size(800, 37);
            this.toolbox.TabIndex = 5;
            this.toolbox.Text = "toolStrip1";
            // 
            // GrupoDeVeiculosSubMenuItem
            // 
            this.GrupoDeVeiculosSubMenuItem.Name = "GrupoDeVeiculosSubMenuItem";
            this.GrupoDeVeiculosSubMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.GrupoDeVeiculosSubMenuItem.Size = new System.Drawing.Size(243, 26);
            this.GrupoDeVeiculosSubMenuItem.Text = "Grupo De Veículos";
            this.GrupoDeVeiculosSubMenuItem.Click += new System.EventHandler(this.GrupoDeVeiculosSubMenuItem_Click);
            // 
            // taxasMenuItem
            // 
            this.taxasMenuItem.Name = "taxasMenuItem";
            this.taxasMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.taxasMenuItem.Size = new System.Drawing.Size(243, 26);
            this.taxasMenuItem.Text = "Taxas";
            this.taxasMenuItem.Click += new System.EventHandler(this.taxasMenuItem_Click);
            // 
            // FuncionarioSubMenuItem
            // 
            this.FuncionarioSubMenuItem.Name = "FuncionarioSubMenuItem";
            this.FuncionarioSubMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.FuncionarioSubMenuItem.Size = new System.Drawing.Size(243, 26);
            this.FuncionarioSubMenuItem.Text = "Funcionario";
            this.FuncionarioSubMenuItem.Click += new System.EventHandler(this.FuncionarioSubMenuItem_Click);
            // 
            // ClienteMenuItem
            // 
            this.ClienteMenuItem.Name = "ClienteMenuItem";
            this.ClienteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ClienteMenuItem.Size = new System.Drawing.Size(243, 26);
            this.ClienteMenuItem.Text = "Cliente";
            this.ClienteMenuItem.Click += new System.EventHandler(this.ClienteMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClienteMenuItem,
            this.FuncionarioSubMenuItem,
            this.taxasMenuItem,
            this.GrupoDeVeiculosSubMenuItem,
            this.VeiculoMenuItem,
            this.CondutorMenuItem,
            this.planoDeCobrançaToolStripMenuItem,
            this.LocacaoMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // VeiculoMenuItem
            // 
            this.VeiculoMenuItem.Name = "VeiculoMenuItem";
            this.VeiculoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.VeiculoMenuItem.Size = new System.Drawing.Size(243, 26);
            this.VeiculoMenuItem.Text = "Veiculo";
            this.VeiculoMenuItem.Click += new System.EventHandler(this.VeiculoMenuItem_Click);
            // 
            // CondutorMenuItem
            // 
            this.CondutorMenuItem.Name = "CondutorMenuItem";
            this.CondutorMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.CondutorMenuItem.Size = new System.Drawing.Size(243, 26);
            this.CondutorMenuItem.Text = "Condutor";
            this.CondutorMenuItem.Click += new System.EventHandler(this.CondutorMenuItem_Click);
            // 
            // planoDeCobrançaToolStripMenuItem
            // 
            this.planoDeCobrançaToolStripMenuItem.Name = "planoDeCobrançaToolStripMenuItem";
            this.planoDeCobrançaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.planoDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.planoDeCobrançaToolStripMenuItem.Text = "Plano De Cobrança";
            this.planoDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planoDeCobrançaToolStripMenuItem_Click);
            // 
            // LocacaoMenuItem
            // 
            this.LocacaoMenuItem.Name = "LocacaoMenuItem";
            this.LocacaoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.LocacaoMenuItem.Size = new System.Drawing.Size(243, 26);
            this.LocacaoMenuItem.Text = "Locação";
            this.LocacaoMenuItem.Click += new System.EventHandler(this.LocacaoMenuItem_Click);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(800, 28);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // TelaPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.Name = "TelaPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Principal";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.toolbox.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelRodape;
        private System.Windows.Forms.ToolStripLabel labelTipoCadastro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDevolucao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStrip toolbox;
        private System.Windows.Forms.ToolStripMenuItem GrupoDeVeiculosSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxasMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FuncionarioSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClienteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem CondutorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VeiculoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeCobrançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LocacaoMenuItem;
    }
}