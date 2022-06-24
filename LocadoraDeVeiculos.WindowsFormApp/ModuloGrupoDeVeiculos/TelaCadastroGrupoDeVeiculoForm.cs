using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos
{
    public partial class TelaCadastroGrupoDeVeiculoForm : Form
    {
        GrupoDeVeiculo gp;

        public TelaCadastroGrupoDeVeiculoForm()
        {
            InitializeComponent();
        }

        public Func<GrupoDeVeiculo, ValidationResult> GravarRegistro { get; set; }

        public GrupoDeVeiculo GrupoDeVeiculo
        {
            get { return gp; }
            set
            {
                gp = value;

                txtBoxGrupoVeiculo.Text = gp.Nome;
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            gp.Nome = txtBoxGrupoVeiculo.Text;

            var resultadoValidacao = GravarRegistro(gp);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}









