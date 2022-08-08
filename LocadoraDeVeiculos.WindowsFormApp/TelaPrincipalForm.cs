using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraDeVeiculos.WindowsFormApp.ModuloCliente;
using LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor;
using LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário;
using LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao;
using LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas;
using LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo;
using System;
using System.Windows.Forms;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca;


namespace LocadoraDeVeiculos.WindowsFormApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private IServiceLocator serviceLocator;
        public TelaPrincipalForm(IServiceLocator serviceLocator)
        {

            InitializeComponent();

            this.serviceLocator = serviceLocator;

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

        }


        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }


        private void ClienteMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCliente>());
        }

        private void FuncionarioSubMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorFuncionario>());

        }

        private void GrupoDeVeiculosSubMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorGrupoDeVeiculo>());
        }
        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorTaxa>());
        }

        private void VeiculoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorVeiculo>());
        }

        private void CondutorMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorCondutor>());
        }
        private void planoDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorPlanoDeCobranca>());
        }
        private void LocacaoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocator.Get<ControladorLocacao>());
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            controlador.Agrupar();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }

        private void ConfigurarBotoes(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnDevolucao.Enabled = configuracao.AgruparHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }
        private void ConfigurarTooltips(ConfiguracaoToolBoxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnDevolucao.ToolTipText = configuracao.TooltipAgrupar;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {

            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolBoxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;


            panelRegistros.Controls.Add(listagemControl);

        }

    }
}
