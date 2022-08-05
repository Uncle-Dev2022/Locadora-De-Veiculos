using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

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
            var id = Guid.Parse(leitorVeiculo["VEICULO_ID"].ToString());
            string marca = Convert.ToString(leitorVeiculo["VEICULO_MARCA"]);
            string modelo = Convert.ToString(leitorVeiculo["VEICULO_MODELO"]);
            string cor = Convert.ToString(leitorVeiculo["VEICULO_COR"]);
            string anoModelo = Convert.ToString(leitorVeiculo["VEICULO_ANOMODELO"]);
            string tipoCombustivel = Convert.ToString(leitorVeiculo["VEICULO_TIPOCOMBUSTIVEL"]);
            string placa = Convert.ToString(leitorVeiculo["VEICULO_PLACA"]);
            decimal quilometragem = Convert.ToDecimal(leitorVeiculo["VEICULO_QUILOMETRAGEM"]);
            int capacidadeTanque = Convert.ToInt32(leitorVeiculo["VEICULO_CAPACIDADETANQUE"]);
            byte[] imagem = (byte[])leitorVeiculo["VEICULO_IMAGEM"];

            var numeroGrupo = Guid.Parse(leitorVeiculo["VEICULO_GRUPODEVEICULO_ID"].ToString());

            string nomeGrupo = Convert.ToString(leitorVeiculo["GRUPOVEICULO_NOME"]);


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
