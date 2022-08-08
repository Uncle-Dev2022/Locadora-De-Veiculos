using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncinario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        Locacao locacao;
        private List<Cliente> Cliente;
        private List<Condutor> Condutores;
        private List<GrupoDeVeiculo> GruposDeVeiculos;
        private List<Veiculo> Veiculos;
        private List<PlanoDeCobranca> PlanosDeCobrancas;
        private List<Taxa> Taxas;
        private List<Funcionario> funcionarios;

        public TelaCadastroLocacaoForm(ServicoCliente clientes,ServicoCondutor Condutores,ServicoGrupoDeVeiculo gruposDeVeiculos,ServicoVeiculo veiculos, ServicoPlanoDeCobranca planosDeCobrancas,ServicoTaxa taxas,ServicoFuncionario funcionarios)
        {
            InitializeComponent();
            this.Cliente = clientes.SelecionarTodosOsClientes();
            this.Condutores = Condutores.SelecionarTodosOsCondutores();
            this.GruposDeVeiculos = gruposDeVeiculos.SelecionarTodosOsGruposDeVeiculo();
            this.Veiculos = veiculos.SelecionarTodosOsVeiculos();
            this.PlanosDeCobrancas = planosDeCobrancas.SelecionarTodosOsPlanosDeCobranca();
            this.Taxas = taxas.SelecionarTodasAsTaxas();
            this.funcionarios = funcionarios.SelecionarTodosOsFuncionario();
            CarregarCliente(Cliente);
            CarregarGruposDeVeiculos(this.GruposDeVeiculos);
            CarregarPlanosDeCobranca(PlanosDeCobrancas);
            CarregarTaxa(Taxas);
        }


        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao _locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                if(locacao.dataDeLocacao != DateTime.MinValue)
                {
                    comboBoxCliente.SelectedItem = locacao.Cliente;
                    comboBoxCondutor.SelectedItem = locacao.Condutor;
                    comboBoxGrupoDeVeiculo.SelectedItem = locacao.GrupoDeVeiculo;
                    comboBoxVeiculo.SelectedItem = locacao.veiculo;
                    comboBoxPlanoDeCobranca.SelectedItem = locacao.planoDeCobranca;
                    dateTimePickerLocacao.Value = locacao.dataDeLocacao;
                    dateTimePickerDevolucao.Value = locacao.dataDeDevolucaoPrevista;
                    KmdoVeiculotxt.Text = locacao.veiculo.Quilometragem.ToString();

                    Valortxt.Text = CalcularValor(locacao.planoDeCobranca);

                    for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
                        if (locacao.Taxas.Contains((Taxa)checkedListBoxTaxas.Items[i]))
                            checkedListBoxTaxas.SetItemChecked(i, true);
                }
                
            }
        }

        private string CalcularValor(PlanoDeCobranca planoDeCobranca)
        {
            decimal valor;
            
            if (planoDeCobranca != null)
            {
                string nomeplano;

                if (radioDiario.Checked)
                {
                    nomeplano = radioDiario.Text;
                    valor = planoDeCobranca.planoDiario.valorDiario * CalcularDiferencaDias();
                }
                else if (radioLivre.Checked)
                {
                    nomeplano = radioLivre.Text;
                    valor = planoDeCobranca.planoLivre.valorDiario * CalcularDiferencaDias();
                }
                else
                {
                    nomeplano = radioButtonControlado.Text;
                    valor = planoDeCobranca.planoControlado.valorDiario * CalcularDiferencaDias();
                }

                

                return Convert.ToString(valor);
                
            }

            return "Sem Dados para calculo";
        }

        private int CalcularDiferencaDias()
        {
            int totalDias = 0;
            DateTime dataDeLocacao;
            DateTime dataDeDevolucao;

            if (dateTimePickerLocacao!= null && dateTimePickerDevolucao!= null)
            {
                dataDeLocacao = dateTimePickerLocacao.Value;

                dataDeDevolucao = dateTimePickerDevolucao.Value;

                totalDias = dataDeDevolucao.DayOfYear - dataDeLocacao.DayOfYear;
                
            }

            return totalDias;
        }

        private void CarregarCliente(List<Cliente> clientes)
        {
            comboBoxCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                comboBoxCliente.Items.Add(cliente);
            }
        }

        private void CarregarCondutores(List<Condutor> condutores,Cliente cliente)
        {
            comboBoxCondutor.Items.Clear();

            foreach (var condutor in condutores)
            {
                if(condutor.cliente.Id==cliente.Id)
                {
                    comboBoxCondutor.Items.Add(condutor);
                }
            }
        }

        private void CarregarGruposDeVeiculos(List<GrupoDeVeiculo> GruposDeVeiculos)
        {
            comboBoxGrupoDeVeiculo.Items.Clear();

            foreach (var grupoDeVeiculo in GruposDeVeiculos)
            {
                comboBoxGrupoDeVeiculo.Items.Add(grupoDeVeiculo);
            }
        }

        private void CarregarVeiculos(List<Veiculo> Veiculos,GrupoDeVeiculo grupodeveiculo)
        {
            comboBoxVeiculo.Items.Clear();

            foreach (var veiculo in Veiculos)
            {
                if(veiculo.GrupoDeVeiculo.Id==grupodeveiculo.Id)
                {
                    comboBoxVeiculo.Items.Add(veiculo);
                }
            }
        }

        private void CarregarPlanosDeCobranca(List<PlanoDeCobranca> PlanosDeCobrancas)
        {
            comboBoxPlanoDeCobranca.Items.Clear();

            foreach (var planoDeCobranca in PlanosDeCobrancas)
            {
                    comboBoxPlanoDeCobranca.Items.Add(planoDeCobranca);
            }
        }

        private void CarregarTaxa(List<Taxa> Taxas)
        {
            checkedListBoxTaxas.Items.Clear();

            foreach (var Taxa in Taxas)
            {
                checkedListBoxTaxas.Items.Add(Taxa);
            }
        }

        private void btnGravar1_Click(object sender, EventArgs e)
        {
            locacao.Cliente = (Cliente)comboBoxCliente.SelectedItem;
            locacao.Condutor = (Condutor)comboBoxCondutor.SelectedItem;
            locacao.GrupoDeVeiculo= (GrupoDeVeiculo)comboBoxGrupoDeVeiculo.SelectedItem;
            locacao.veiculo = (Veiculo)comboBoxVeiculo.SelectedItem;
            locacao.planoDeCobranca= (PlanoDeCobranca)comboBoxPlanoDeCobranca.SelectedItem;
            locacao.dataDeDevolucaoPrevista = dateTimePickerDevolucao.Value;
            locacao.dataDeLocacao = dateTimePickerLocacao.Value;
            locacao.funcionario = funcionarios[0];

            for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
                if (locacao.Taxas.Contains((Taxa)checkedListBoxTaxas.Items[i]))
                    checkedListBoxTaxas.SetItemChecked(i, true);

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {

                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecioando = (Cliente)comboBoxCliente.SelectedItem;

            CarregarCondutores(Condutores, clienteSelecioando);
        }

        private void comboBoxGrupoDeVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrupoDeVeiculo GrupoDeVeiculoSelecionado = (GrupoDeVeiculo)comboBoxGrupoDeVeiculo.SelectedItem;

            CarregarVeiculos(Veiculos, GrupoDeVeiculoSelecionado);
        }

        private void comboBoxPlanoDeCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlanoDeCobranca planoSelecionado = (PlanoDeCobranca)comboBoxPlanoDeCobranca.SelectedItem;

            CalcularValor(planoSelecionado);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
