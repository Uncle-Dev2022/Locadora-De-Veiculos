﻿using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

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
            var id = Guid.Parse(leitorGrupoDeVeiculo["ID"].ToString());
            string nome = Convert.ToString(leitorGrupoDeVeiculo["NOME"]);


            return new GrupoDeVeiculo()
            {
                Id = id,
                Nome = nome,

            };

        }
    }
}
