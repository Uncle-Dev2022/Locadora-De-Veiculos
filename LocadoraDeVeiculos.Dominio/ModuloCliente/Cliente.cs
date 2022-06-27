using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public bool ClienteFisico;
        public string Nome;
        public string Endereco;
        public string Email;
        public string Telefone;
        public string CPF_CNPJ;
        public string? CNH;

        public Cliente(string nome, string endereco,string email, string telefone,bool tipocliente,string Cpf_cnpj,string? cnh)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            CPF_CNPJ = Cpf_cnpj;

            if (tipocliente== true)
            {
                CNH = cnh;
            }
        }

        public Cliente()
        {

        }

        public override bool Equals(object obj)
        {
            Cliente cliente = obj as Cliente;

            if (cliente == null)
                return false;

            return
                cliente.Id.Equals(Id) &&
                cliente.Nome.Equals(Nome) &&
                cliente.Telefone.Equals(Telefone) &&
                cliente.Email.Equals(Email) &&
                cliente.Endereco.Equals(Endereco) &&
                cliente.CPF_CNPJ.Equals(CPF_CNPJ);
        }
    }
}
