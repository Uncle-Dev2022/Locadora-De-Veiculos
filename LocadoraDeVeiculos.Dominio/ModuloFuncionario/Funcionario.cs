using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Senha { get; set; }

        public string Login { get; set; }
        public bool Gerente { get; set; }

        public Funcionario()
        {
            DataAdmissao = DateTime.Parse("01/01/2000");

        }

        public Funcionario(string nome, decimal salario, DateTime dataAdmissao, string senha, string login, bool gerente)
        {
            Nome = nome;
            Salario = salario;
            DataAdmissao = dataAdmissao;
            Senha = senha;
            Login = login;
            Gerente = gerente;
        }

        public override bool Equals(object obj)
        {
            Funcionario funcionario = obj as Funcionario;

            if (funcionario == null)
                return false;

            return
                funcionario.Id.Equals(Id) &&
                funcionario.Nome.Equals(Nome) &&
                funcionario.Salario.Equals(Salario) &&
                funcionario.DataAdmissao.Equals(DataAdmissao) &&
                funcionario.Senha.Equals(Senha) &&
                funcionario.Login.Equals(Login) &&
                funcionario.Gerente.Equals(Gerente);
        }

        public Funcionario Clone()
        {
            return MemberwiseClone() as Funcionario;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + " - Salario: " + Salario + " - Data de Admissão: " + DataAdmissao +
                " - Senha: " + Senha + " - Login: " + Login + " - Gerente: " + Gerente;

        }




    }
}
