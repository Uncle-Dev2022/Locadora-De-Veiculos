using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public string Nome;
        public GrupoDeVeiculo grupoDeVeiculo;
        public PlanoLivre planoLivre;
        public PlanoControlado planoControlado;
        public PlanoDiario planoDiario;

        public ICalculaPlano EscolheOPlano(TipoPlano plano)
        {
            if(plano==TipoPlano.Diario)
            {
                return planoDiario;
            }
            else if (plano == TipoPlano.Livre)
            {
                return planoLivre;
            }
            else
            {
                return planoControlado;
            }
        }

        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id.Equals(cobranca.Id) &&
                   Nome == cobranca.Nome &&
                   EqualityComparer<GrupoDeVeiculo>.Default.Equals(grupoDeVeiculo, cobranca.grupoDeVeiculo) &&
                   EqualityComparer<PlanoLivre>.Default.Equals(planoLivre, cobranca.planoLivre) &&
                   EqualityComparer<PlanoControlado>.Default.Equals(planoControlado, cobranca.planoControlado) &&
                   EqualityComparer<PlanoDiario>.Default.Equals(planoDiario, cobranca.planoDiario);
        }

        public PlanoDeCobranca(string nome, GrupoDeVeiculo grupoDeVeiculo, PlanoLivre planoLivre, PlanoDiario planoDiario, PlanoControlado planoControlado)
        {
            this.Nome = nome;
            this.grupoDeVeiculo = grupoDeVeiculo;
            this.planoDiario = planoDiario;
            this.planoLivre = planoLivre;
            this.planoControlado = planoControlado;
        }

        public PlanoDeCobranca()
        {
            this.planoDiario = new PlanoDiario();
            this.planoControlado = new PlanoControlado();
            this.planoLivre = new PlanoLivre();
        }

        //public override bool Equals(object obj)
        //{
        //    PlanoDeCobranca planoDeCobranca = obj as PlanoDeCobranca;

        //    bool grupoDeVeiculoIgual = this.grupoDeVeiculo.Equals(planoDeCobranca.grupoDeVeiculo);

        //    bool planoLivreIgual = this.planoLivre.Equals(planoDeCobranca.planoLivre);
        //    bool planoDiarioIgual = this.planoDiario.Equals(planoDeCobranca.planoDiario);
        //    bool planoControladoIgual = this.planoControlado.Equals(planoDeCobranca.planoControlado);

        //    return grupoDeVeiculoIgual && planoLivreIgual && planoDiarioIgual && planoControladoIgual;
        //}
    }
    public class PlanoLivre : ICalculaPlano
    {
        public decimal valorDiario;
        
        public PlanoLivre(decimal valorDiario)
        {
            this.valorDiario = valorDiario;
        }
        public PlanoLivre()
        {

        }
        public override bool Equals(object obj)
        {
            PlanoLivre plano = obj as PlanoLivre;
            return this.valorDiario == plano.valorDiario;
        }
    }
    public class PlanoDiario : ICalculaPlano
    {
        public decimal valorDiario;
        public decimal valorKm;
        public PlanoDiario(decimal valorDiario, decimal valorKm)
        {
            this.valorDiario = valorDiario;
            this.valorKm = valorKm;
        }
        public PlanoDiario()
        {

        }
        public override bool Equals(object obj)
        {
            PlanoDiario plano = obj as PlanoDiario;
            return this.valorDiario == plano.valorDiario && this.valorKm == plano.valorKm;
        }

        
    }
    public class PlanoControlado : ICalculaPlano
    {
        public decimal valorDiario;
        public decimal valorKm;
        public decimal limiteKm;

        public PlanoControlado(decimal valorDiario, decimal valorKm, decimal limiteKm)
        {
            this.valorDiario = valorDiario;
            this.valorKm = valorKm;
            this.limiteKm = limiteKm;
        }
        public PlanoControlado()
        {

        }
        public override bool Equals(object obj)
        {
            PlanoControlado plano = obj as PlanoControlado;

            return this.valorKm == plano.valorKm && this.limiteKm == plano.limiteKm && this.valorDiario == plano.valorDiario;
        }

       
    }
}
