using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("CPF", string.IsNullOrEmpty(registro.CPF) ? DBNull.Value : registro.CPF);
            comando.Parameters.AddWithValue("CNH", string.IsNullOrEmpty(registro.CNH) ? DBNull.Value : registro.CNH);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.cliente.Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorRegistro)
        {
            int condutorId = Convert.ToInt32(leitorRegistro["CONDUTOR_ID"]);
            string condutorNome = Convert.ToString(leitorRegistro["CONDUTOR_NOME"]);
            string condutorEndereco = Convert.ToString(leitorRegistro["CONDUTOR_ENDERECO"]);
            string condutorCpf = "";

            if (leitorRegistro["CONDUTOR_CPF"] != DBNull.Value)
            {
               condutorCpf = Convert.ToString(leitorRegistro["CONDUTOR_CPF"]);
            }

            string condutorCnh = "";

            if(leitorRegistro["CONDUTOR_CNH"] != DBNull.Value)
            {
                condutorCnh = Convert.ToString(leitorRegistro["CONDUTOR_CNH"]);

            }
            string condutorEmail = Convert.ToString(leitorRegistro["CONDUTOR_EMAIL"]);

            int ClienteId = Convert.ToInt32(leitorRegistro["CONDUTOR_CLIENTE_ID"]);
            string ClienteNome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            string ClienteCpf_Cnpj = Convert.ToString(leitorRegistro["CLIENTE_CPF_CNPJ"]);
            string ClienteEndereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            string ClienteEmail = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            string ClienteTelefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            string ClienteCnh = Convert.ToString(leitorRegistro["CLIENTE_CNH"]);
            bool ClienteTipoCliente = Convert.ToBoolean(leitorRegistro["CLIENTE_TIPOCLIENTE"]);

            var condutor = new Condutor(condutorNome, condutorEndereco, condutorCpf, condutorCnh, condutorEmail)
            {
                Id = condutorId,
            };

            condutor.cliente = new Cliente(ClienteNome, ClienteEndereco, ClienteEmail, ClienteTelefone, ClienteTipoCliente, ClienteCpf_Cnpj, ClienteCnh)
            {
                Id = ClienteId,
            };

            return condutor;
        }
    }
}
