﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobrancaForm : Form
    {
        PlanoDeCobranca plano;

        public TelaCadastroPlanoDeCobrancaForm(List<GrupoDeVeiculo> gruposDeVeiculo)
        {
            InitializeComponent();
            CarregarGrupoDeVeiculo(gruposDeVeiculo);
        }

        private void CarregarGrupoDeVeiculo(List<GrupoDeVeiculo> gruposDeVeiculo)
        {
            comboBoxGrupoDeVeiculo.Items.Clear();

            foreach (var grupodeveiculo in gruposDeVeiculo)
            {
                comboBoxGrupoDeVeiculo.Items.Add(grupodeveiculo);
            }
        }
        public Func<PlanoDeCobranca, Result<PlanoDeCobranca>> GravarRegistro { get; set; }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                textBoxNome.Text = plano.Nome;
                TextBoxDiarioValorDiario.Text = plano.planoDiario.valorDiario.ToString();
                TextBoxDiarioValorKM.Text = plano.planoDiario.valorKm.ToString();

                TextBoxLivreValorDiario.Text = plano.planoLivre.valorDiario.ToString();

                TextBoxControladoValorDiario.Text = plano.planoControlado.valorDiario.ToString();
                TextBoxControladoValorKM.Text = plano.planoControlado.valorKm.ToString();
                TextBoxLimiteKM.Text = plano.planoControlado.limiteKm.ToString();

                comboBoxGrupoDeVeiculo.SelectedItem = plano.grupoDeVeiculo;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plano.Nome = textBoxNome.Text;

            try
            {
                plano.grupoDeVeiculo = comboBoxGrupoDeVeiculo.SelectedItem as GrupoDeVeiculo;
                plano.planoLivre.valorDiario = Convert.ToDecimal(TextBoxLivreValorDiario.Text);

                plano.planoDiario.valorDiario = Convert.ToDecimal(TextBoxDiarioValorDiario.Text);
                plano.planoDiario.valorKm = Convert.ToDecimal(TextBoxDiarioValorKM.Text);

                plano.planoControlado.valorKm = Convert.ToDecimal(TextBoxControladoValorKM.Text);
                plano.planoControlado.limiteKm = Convert.ToDecimal(TextBoxLimiteKM.Text);
                plano.planoControlado.valorDiario = Convert.ToDecimal(TextBoxControladoValorDiario.Text);

            }
            catch (Exception exep)
            {
                MessageBox.Show("Os Três Planos precisam estar cadastrados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Plano De CObrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
