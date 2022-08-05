using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao>
    {
        public ServicoDevolucao(RepositorioDevolucaoOrm repositorio) : base(repositorio)
        {
        }

        public override Result Validar(Devolucao registro)
        {
            throw new NotImplementedException();
        }
    }
}
