using System;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        public override void ConfigurarParametros(PlanoDeCobranca registro, SqlCommand comando)
        {                                    
            decimal planoDiarioValorDiario = registro.planoDiario.valorDiario;
            decimal planoDiarioValorKm = registro.planoDiario.valorKm;

            decimal planoLivreValorDiario = registro.planoLivre.valorDiario;

            decimal planoControladoValorDiario = registro.planoControlado.valorDiario;
            decimal planoControladoValorKm = registro.planoControlado.valorKm;
            decimal planoControladoLimiteKm = registro.planoControlado.limiteKm;


            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);

            comando.Parameters.AddWithValue("GRUPODEVEICULO_ID", registro.grupoDeVeiculo.Id);

            comando.Parameters.AddWithValue("PLANODIARIO_VALORDIARIO", planoDiarioValorDiario);
            comando.Parameters.AddWithValue("PLANODIARIO_VALORKM", planoDiarioValorKm);

            comando.Parameters.AddWithValue("PLANOLIVRE_VALORDIARIO", planoLivreValorDiario);

            comando.Parameters.AddWithValue("PLANOCONTROLADO_VALORDIARIO", planoControladoValorDiario);
            comando.Parameters.AddWithValue("PLANOCONTROLADO_VALORKM", planoControladoValorKm);
            comando.Parameters.AddWithValue("PLANOCONTROLADO_LIMITEKM", planoControladoLimiteKm);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            string nome = leitorRegistro["NOME"].ToString();

            var grupoDeVeiculoId = Convert.ToInt32(leitorRegistro["GRUPODEVEICULO_ID"]);
            var grupoVeiculoNome = leitorRegistro["GRUPODEVEICULO_NOME"].ToString();

            decimal planoDiarioValorDiario = Convert.ToDecimal(leitorRegistro["PLANODIARIO_VALORDIARIO"]);
            decimal planoDiarioValorKm = Convert.ToDecimal(leitorRegistro["PLANODIARIO_VALORKM"]);

            decimal planoLivreValorDiario = Convert.ToDecimal(leitorRegistro["PLANOLIVRE_VALORDIARIO"]);

            decimal planoControladoValorDiario = Convert.ToDecimal(leitorRegistro["PLANOCONTROLADO_VALORDIARIO"]);
            decimal planoControladoValorKm = Convert.ToDecimal(leitorRegistro["PLANOCONTROLADO_VALORKM"]);
            decimal planoControladoLimiteKm = Convert.ToDecimal(leitorRegistro["PLANOCONTROLADO_LIMITEKM"]);


            PlanoControlado planoControlado = new PlanoControlado(planoControladoValorDiario, planoControladoValorKm, planoControladoLimiteKm);
            PlanoLivre planoLivre = new PlanoLivre(planoLivreValorDiario);
            PlanoDiario planoDiario = new PlanoDiario(planoDiarioValorDiario, planoDiarioValorKm);

            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo(grupoVeiculoNome)
            {
                Id = grupoDeVeiculoId
            };

            var planoDeCobranca = new PlanoDeCobranca(nome, grupoDeVeiculo, planoLivre, planoDiario, planoControlado)
            {
                Id = id,
            };

            return planoDeCobranca;
        }
    }
}
