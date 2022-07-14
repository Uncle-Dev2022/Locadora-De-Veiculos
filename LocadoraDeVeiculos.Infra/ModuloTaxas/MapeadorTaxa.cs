using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
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
            comando.Parameters.AddWithValue("TIPO_CALCULO", registro.descricao);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            double valor = (double)leitorRegistro["VALOR"];//double.Parse(leitorRegistro["VALOR"]);
            string descricao = leitorRegistro["DESCRICAO"].ToString();
            TipoCalculo tipoCalculo = (TipoCalculo)leitorRegistro["TIPO_CALCULO"];
            Taxa taxa = new Taxa(valor, descricao, tipoCalculo)
            {
                Id = id
            };
            return taxa;
        }
    }
}
