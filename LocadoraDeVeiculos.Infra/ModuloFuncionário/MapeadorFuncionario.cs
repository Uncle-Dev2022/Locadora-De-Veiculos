using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraDeVeiculos.Infra.ModuloFuncionário
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATAADMISSAO", funcionario.DataAdmissao);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("GERENTE", funcionario.Gerente);

        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Guid.Parse(leitorFuncionario["ID"].ToString());
            string nome = Convert.ToString(leitorFuncionario["NOME"]);
            decimal salario = Convert.ToDecimal(leitorFuncionario["SALARIO"]);
            DateTime dataAdmissao = Convert.ToDateTime(leitorFuncionario["DATAADMISSAO"]);
            string senha = Convert.ToString(leitorFuncionario["SENHA"]);
            string login = Convert.ToString(leitorFuncionario["LOGIN"]);
            bool gerente = Convert.ToBoolean(leitorFuncionario["GERENTE"]);


            return new Funcionario()
            {
                Id = id,
                Nome = nome,
                Salario = salario,
                DataAdmissao = dataAdmissao,
                Senha = senha,
                Login = login,
                Gerente = gerente,

            };



        }
    }
}
