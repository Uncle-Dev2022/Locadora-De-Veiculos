using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class PessoaFisica : Cliente
    {
        string CPF;
        string CNH;

        public PessoaFisica(string nome,string endereço,string email,string telefone,string cpf,string cnh)
        {
            this.Nome = nome;
            this.Endereco = endereço;
            this.Email = email;
            this.Telefone = telefone;
            this.CPF = cpf;
            this.CNH = cnh;

        }

        public PessoaFisica()
        {

        }

        public override bool Equals(object obj)
        {
            PessoaFisica pessoaFisica = obj as PessoaFisica;

            if(pessoaFisica == null)
                return false;

            return
                pessoaFisica.Id.Equals(Id) &&
                pessoaFisica.Nome.Equals(Nome)&&
                pessoaFisica.Endereco.Equals(Endereco)&&
                pessoaFisica.Email.Equals(Email)&&
                pessoaFisica.Telefone.Equals(Telefone)&&
                pessoaFisica.CPF.Equals(CPF)&&
                pessoaFisica.CNH.Equals(CNH);
                 
        }
    }
}
