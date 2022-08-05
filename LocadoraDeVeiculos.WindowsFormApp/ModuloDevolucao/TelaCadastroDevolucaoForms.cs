using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForms : Form
    {
        private Devolucao _devolucao;

        private Locacao Locacao;
        private ServicoTaxa _servicoTaxa;

        public Devolucao Devolucao
        {
            get { return _devolucao; }
            set
            {
                _devolucao = value;
            }
        }

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }

        public TelaCadastroDevolucaoForms(Devolucao devolucao,
            Locacao Locacao, ServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this._devolucao = devolucao;
            this.Locacao = Locacao;
            this._servicoTaxa = servicoTaxa;

            textBoxquilometragemDevolucao.Enabled = false;
            dateTimePickerDevolucaoReal.Enabled = false;
            comboBoxCombustivel.Enabled = false;
            checkedListBoxTaxasAdicionais.Enabled = false;


            var combustiveis = Enum.GetValues(typeof(TanqueGasolinaEnum));

            foreach (TanqueGasolinaEnum combustivel in combustiveis)
                comboBoxCombustivel.Items.Add(combustivel);

            foreach (var taxaLocacao in Locacao.Taxa)
                checkedListBoxTaxasSelecionadas.Items.Add(taxaLocacao);

            List<Taxa> _taxas = _servicoTaxa.SelecionarTodasAsTaxas();

            for (int i = 0; i < _taxas.Count; i++)
            {
                if (Locacao.Taxas.Contains((Taxa)checkedListBoxTaxasSelecionadas.Items[i]))
                {

                }
                else
                {
                    checkedListBoxTaxasAdicionais.Items.Add(_taxas[i]);
                }
            }
        }





        private void TelaCadastroDevolucaoForms_Load(object sender, EventArgs e)
        {
                    }

        private void AtualizarTotalPrevisto()
        {
            ObterDadosDaTela();
            textBoxValorTotal.Text = Devolucao.ValorTotal.ToString();
        }

        private void ObterDadosDaTela()
        {
            Devolucao.DataDevolucao = dateTimePickerDevolucaoReal.Value;
            Devolucao.NivelGasolina = (TanqueGasolinaEnum)comboBoxCombustivel.SelectedItem;
            

            foreach (Taxa taxa in checkedListBoxTaxasSelecionadas.CheckedItems)
                if (!Devolucao.TaxasAdicionais.Contains(taxa))
                    Devolucao.TaxasAdicionais.Add(taxa);

            List<Taxa> taxas = new();

            foreach (Taxa item in checkedListBoxTaxasSelecionadas.Items)
                if (!checkedListBoxTaxasSelecionadas.CheckedItems.Contains(item))
                    taxas.Add(item);
            Devolucao.ValorTotal = Devolucao.CalcularTotal(numericUpDownKmRodadosLocacao.Value, configuracao, (TanqueEnum)comboBoxNivelTanque.SelectedItem);
        }





    }
}
