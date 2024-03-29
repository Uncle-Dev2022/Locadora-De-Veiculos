﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public bool tipoCliente;
        public string Nome;
        public string Endereco;
        public string Email;
        public string Telefone;
        public string CPF_CNPJ;
        public string? CNH;

        public Cliente(string nome, string endereco, string email, string telefone, bool tipocliente, string Cpf_cnpj, string? cnh)
        {
            Nome = nome;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            CPF_CNPJ = Cpf_cnpj;
            tipoCliente = tipocliente;

            if (tipocliente == true)
            {
                CNH = cnh;
            }

        }

        public Cliente()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                Id == cliente.Id &&
                Nome == cliente.Nome &&
                Telefone == cliente.Telefone &&
                Email == cliente.Email &&
                Endereco == cliente.Endereco &&
                CPF_CNPJ == cliente.CPF_CNPJ &&
                CNH == cliente.CNH;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
