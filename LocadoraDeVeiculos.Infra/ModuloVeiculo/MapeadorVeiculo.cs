using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo veiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", veiculo.Id);
            comando.Parameters.AddWithValue("MARCA", veiculo.Marca);
            comando.Parameters.AddWithValue("MODELO", veiculo.Modelo);
            comando.Parameters.AddWithValue("COR", veiculo.Cor);
            comando.Parameters.AddWithValue("ANOMODELO", veiculo.AnoModelo);
            comando.Parameters.AddWithValue("TIPOCOMBUSTIVEL", veiculo.TipoCombustivel);
            comando.Parameters.AddWithValue("PLACA", veiculo.Placa);
            comando.Parameters.AddWithValue("QUILOMETRAGEM", veiculo.Quilometragem);
            comando.Parameters.AddWithValue("CAPACIDADETANQUE", veiculo.CapacidadeTanque);
            comando.Parameters.AddWithValue("IMAGEM", veiculo.Imagem);
            comando.Parameters.AddWithValue("GRUPODEVEICULO_ID", veiculo.GrupoDeVeiculo.Id);

        }


        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            int id = Convert.ToInt32(leitorVeiculo["ID"]);
            string marca = Convert.ToString(leitorVeiculo["MARCA"]);
            string modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            string cor = Convert.ToString(leitorVeiculo["COR"]);
            string anoModelo = Convert.ToString(leitorVeiculo["ANOMODELO"]);
            string tipoCombustivel = Convert.ToString(leitorVeiculo["TIPOCOMBUSTIVEL"]);
            string placa = Convert.ToString(leitorVeiculo["PLACA"]);
            decimal quilometragem = Convert.ToDecimal(leitorVeiculo["QUILOMETRAGEM"]);
            int capacidadeTanque = Convert.ToInt32(leitorVeiculo["CAPACIDADETANQUE"]);
            byte[] imagem = (byte[])leitorVeiculo["IMAGEM"];

            int numeroGrupo = Convert.ToInt32(leitorVeiculo["GRUPODEVEICULO_ID"]);
            string nomeGrupo = Convert.ToString(leitorVeiculo["GRUPODEVEICULO_NOME"]);


            return new Veiculo()
            {
                Id = id,
                Marca = marca,
                Modelo = modelo,
                Cor = cor,
                AnoModelo = anoModelo,
                TipoCombustivel = tipoCombustivel,
                Placa = placa,
                Quilometragem = quilometragem,
                CapacidadeTanque = capacidadeTanque,
                Imagem = imagem,

                GrupoDeVeiculo = new GrupoDeVeiculo
                {
                    Id = numeroGrupo,
                    Nome = nomeGrupo
                }

            };
        }

    }
}
