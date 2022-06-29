using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente :MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF_CNPJ", registro.CPF_CNPJ);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
            comando.Parameters.AddWithValue("CNH", string.IsNullOrEmpty(registro.CNH) ? DBNull.Value : registro.CNH);
            comando.Parameters.AddWithValue("TIPOCLIENTE", registro.tipoCliente);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var Cpf_cnpj = Convert.ToString(leitorRegistro["CPF_CNPJ"]);
            var enderco = Convert.ToString(leitorRegistro["ENDERECO"]);
            var email = Convert.ToString(leitorRegistro["EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["TELEFONE"]);
            var tipoCliente = Convert.ToBoolean(leitorRegistro["TIPOCLIENTE"]);
            string cnh = "";

            if(leitorRegistro["CNH"] != DBNull.Value)
            {
                cnh = Convert.ToString(leitorRegistro["CNH"]);
            }

            var cliente = new Cliente(nome, enderco, email, telefone, tipoCliente, Cpf_cnpj, cnh)
            {
                Id = id,
            };

            return cliente;
        }
    }
}
