using System;
using System.Data.SqlClient;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    internal class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        public override void ConfigurarParametros(PlanoDeCobranca registro, SqlCommand comando)
        {            
            decimal valorDiario;
            decimal valorKm = default;
            decimal limiteKm = default;

            if (registro.tipoPlano == TipoPlano.Diario)
            {                
                valorDiario = registro.planoDiario.valorDiario;
                valorKm = registro.planoDiario.valorKm;
            }
            else if (registro.tipoPlano == TipoPlano.Controlado)
            {
                valorDiario = registro.planoControlado.valorDiario;
                valorKm = registro.planoControlado.valorKm;
                limiteKm = registro.planoControlado.limiteKm;
            }            
            else
                valorDiario = registro.planoLivre.valorDiario;

            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPODEVEICULO_ID", registro.grupoDeVeiculo.Id);
            comando.Parameters.AddWithValue("TIPOPLANO", registro.tipoPlano);
            comando.Parameters.AddWithValue("VALORDIARIO", valorDiario);
            comando.Parameters.AddWithValue("VALORKM", valorKm == default? null : valorKm);
            comando.Parameters.AddWithValue("LIMITEKM", limiteKm == default? null : limiteKm);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            decimal valorDiario;
            decimal valorKm = default;
            decimal limiteKm = default;

            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var grupoDeVeiculoId = Convert.ToInt32(leitorRegistro["GRUPODEVEICULO_ID"]);
            var tipoPlano = Enum.Parse<TipoPlano>(leitorRegistro["TIPOPLANO"].ToString());
            valorDiario = Convert.ToDecimal(leitorRegistro["VALORDIARIO"]);
            valorKm = Convert.ToDecimal(leitorRegistro["VALORKM"]);
            limiteKm = Convert.ToDecimal(leitorRegistro["LIMITEKM"]);

            var grupoVeiculoNome = leitorRegistro["GRUPODEVEICULO_NOME"].ToString();

            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo(grupoVeiculoNome)
            {
                Id = grupoDeVeiculoId
            };

            var planoDeCobranca = new PlanoDeCobranca(grupoDeVeiculo, tipoPlano, valorDiario, valorKm, limiteKm)
            {
                Id = id,
            };

            return planoDeCobranca;
        }
    }
}
