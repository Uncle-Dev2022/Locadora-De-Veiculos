using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloTaxas
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("VALOR", registro.valor);
            comando.Parameters.AddWithValue("DESCRICAO", registro.descricao);
            comando.Parameters.AddWithValue("TIPO_CALCULO", registro.tipoCalculo);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            double valor = (double)leitorRegistro["VALOR"];//double.Parse(leitorRegistro["VALOR"]);
            string descricao = leitorRegistro["DESCRICAO"].ToString();
            TipoCalculo tipoCalculo = Enum.Parse<TipoCalculo>(leitorRegistro["TIPO_CALCULO"].ToString());
            Taxa taxa = new Taxa(valor, descricao, tipoCalculo)
            {
                Id = id
            };
            return taxa;
        }
    }
}
