using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;

namespace LocadoraDeVeiculos.Dominio.Tests
{
    
    public class OrmTest
    {
        public static void InserindoPlanoDeCobranca()
        {
            //InserindoGrupoDeVeiculo();

            LocadoraDeVeiculosDbContext7 locadoraContext = new LocadoraDeVeiculosDbContext7();

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca();

            GrupoDeVeiculo grupo = locadoraContext.GruposDeVeiculo.First(x => x.Id == planoDeCobranca.Id);

            //planoDeCobranca.ConfigurarGrupoDeVeiculo(grupo);

            locadoraContext.PlanosDeCobranca.Add(planoDeCobranca);

            locadoraContext.SaveChanges();
        }
        public static void InserindoTaxa()
        {
            LocadoraDeVeiculosDbContext7 locadoraContext = new LocadoraDeVeiculosDbContext7();

            Taxa taxa = new Taxa(11.49, "Taxa", TipoCalculo.Fixo);

            locadoraContext.Taxas.Add(taxa);

            locadoraContext.SaveChanges();
        }
    }
}
