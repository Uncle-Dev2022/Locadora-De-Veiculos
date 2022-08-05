﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionário
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario SelecionarFuncionarioPorNome(string nome);

        Funcionario SelecionarFuncionarioPorLogin(string usuario);

    }
}