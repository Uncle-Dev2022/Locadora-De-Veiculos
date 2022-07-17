﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionário
{
    public interface IRepositorioFuncionario : IRepositorio<GrupoDeVeiculo>
    {
        GrupoDeVeiculo SelecionarFuncionarioPorNome(string nome);

        GrupoDeVeiculo SelecionarFuncionarioPorLogin(string usuario);

    }
}