using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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

        private Locacao locacao;
        private List<Taxa> taxas;



        public TelaCadastroDevolucaoForms(Locacao locacao, ServicoTaxa taxa)
        {
            InitializeComponent();
            this.locacao = locacao;
            this.taxas = taxa.SelecionarTodasAsTaxas();

            textBoxquilometragemDevolucao.Enabled = false;
            dateTimePickerDevolucaoReal.Enabled = false;
            comboBoxCombustivel.Enabled = false;
            checkedListBoxTaxasAdicionais.Enabled = false;


            var combustiveis = Enum.GetValues(typeof(TanqueGasolinaEnum));

            foreach (TanqueGasolinaEnum combustivel in combustiveis)
                comboBoxCombustivel.Items.Add(combustivel);

            foreach (var taxaLocacao in locacao.Taxas)
                checkedListBoxTaxasSelecionadas.Items.Add(taxaLocacao);

            List<Taxa> _taxas = taxa.SelecionarTodasAsTaxas();

            for (int i = 0; i < _taxas.Count; i++)
            {
                if (locacao.Taxas.Contains((Taxa)checkedListBoxTaxasSelecionadas.Items[i]))
                {

                }
                else
                {
                    checkedListBoxTaxasAdicionais.Items.Add(_taxas[i]);
                }
            }
        }


        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }


        public Devolucao Devolucao
        {
            get { return _devolucao; }
            set
            {
                _devolucao = value;
            }
        }


        private void TelaCadastroDevolucaoForms_Load(object sender, EventArgs e)
        {

        }


        private void AtualizarTotalPrevisto()
        {
            ObterDadosDaTela();
            labelValorTotal.Text = Devolucao.ValorTotal.ToString();
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            _devolucao.QuilometragemDevolucao = int.Parse(textBoxquilometragemDevolucao.Text);
            _devolucao.DataDevolucao = dateTimePickerDevolucaoReal.Value;

            if (comboBoxCombustivel.SelectedItem.ToString() == "Cheio")
            {
                _devolucao.NivelGasolina = TanqueGasolinaEnum.Cheio;
            }

            else if (comboBoxCombustivel.SelectedItem.ToString() == "Meio_Cheio")
            {
                _devolucao.NivelGasolina = TanqueGasolinaEnum.Meio_Cheio;
            }

            else if (comboBoxCombustivel.SelectedItem.ToString() == "Meio")
            {
                _devolucao.NivelGasolina = TanqueGasolinaEnum.Meio;
            }

            else if (comboBoxCombustivel.SelectedItem.ToString() == "Meio_Vazio")
            {
                _devolucao.NivelGasolina = TanqueGasolinaEnum.Meio_vazio;
            }

            else if (comboBoxCombustivel.SelectedItem.ToString() == "Vazio")
            {
                _devolucao.NivelGasolina = TanqueGasolinaEnum.Vazio;
            }


        }
    }
}
