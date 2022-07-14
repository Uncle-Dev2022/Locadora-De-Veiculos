using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    internal class ControladorTaxa : ControladorBase
    {
        private readonly IRepositorioTaxa repositorioTaxa;
        private readonly ServicoTaxa servicoTaxa;
        private TabelaTaxasControl tabelaTaxas;

        public ControladorTaxa(IRepositorioTaxa repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
            this.repositorioTaxa = repositorioTaxa;
        }
        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();

            tela.Taxa = taxaSelecionada.Clonar();

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa contatoSelecionado = ObtemTaxaSelecionada();

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(contatoSelecionado);
                CarregarTaxas();
            }
        }

        public override void Inserir()
        {
            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxas == null)
                tabelaTaxas = new TabelaTaxasControl();

            CarregarTaxas();

            return tabelaTaxas;
        }
        private Taxa ObtemTaxaSelecionada()
        {
            var numero = tabelaTaxas.ObtemNumeroTaxaSelecionado();
            
            return repositorioTaxa.SelecionarPorId(numero);
        }
        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(taxas);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");

        }
    }
}