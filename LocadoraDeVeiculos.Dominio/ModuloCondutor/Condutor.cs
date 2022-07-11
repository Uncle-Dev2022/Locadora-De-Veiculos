﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Cliente cliente;
        public string Nome;
        public string Endereco;
        public string CPF;
        public string CNH;
        public string Email;

        public Condutor(string nome,string endereco,string cpf,string cnh,string email)
        {
            this.Nome = nome;
            this.Endereco=endereco;
            this.CPF = cpf;
            this.CNH = cnh;
            this.Email = email;
        }

        public Condutor()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   Endereco == condutor.Endereco &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Email == condutor.Email;
        }
    }
}