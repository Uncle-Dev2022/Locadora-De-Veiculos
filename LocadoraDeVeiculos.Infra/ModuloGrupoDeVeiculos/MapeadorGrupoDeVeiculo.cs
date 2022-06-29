using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculo : MapeadorBase<GrupoDeVeiculo> 
    {
        public override void ConfigurarParametros(GrupoDeVeiculo gv, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", gv.Id);
            comando.Parameters.AddWithValue("NOME", gv.Nome);

        }

        public override GrupoDeVeiculo ConverterRegistro(SqlDataReader leitorGrupoDeVeiculo)
        {
            int id = Convert.ToInt32(leitorGrupoDeVeiculo["ID"]);
            string nome = Convert.ToString(leitorGrupoDeVeiculo["NOME"]);


            return new GrupoDeVeiculo()
            {
                Id = id,
                Nome = nome,

            };

        }
    }
}
