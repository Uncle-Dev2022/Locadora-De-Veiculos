using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public int QuilometragemDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public TanqueGasolinaEnum NivelGasolina { get; set; }
        public decimal ValorTotal { get; set; }

        //Classe do Thiago
        public Locacao Locacao { get; set; }
        public Guid LocacaoId { get; set; }


        public List<Taxa> TaxasAdicionais { get; set; }

        public Devolucao()
        {
            TaxasAdicionais = new();
        }

        public Devolucao(int quilometragemDevolucao, DateTime dataDevolucao,
            TanqueGasolinaEnum nivelGasolina, decimal valorTotal, Locacao locacao,
            Guid locacaoId, List<Taxa> taxasAdicionais)
        {
            QuilometragemDevolucao = quilometragemDevolucao;
            DataDevolucao = dataDevolucao;
            NivelGasolina = nivelGasolina;
            ValorTotal = valorTotal;
            Locacao = locacao;
            LocacaoId = locacaoId;
            TaxasAdicionais = taxasAdicionais;
        }

        public override bool Equals(object obj)
        {
            Devolucao devolucao = obj as Devolucao;

            if (devolucao == null)
                return false;

            return
                devolucao.Id.Equals(Id) &&
                devolucao.QuilometragemDevolucao.Equals(QuilometragemDevolucao) &&
                devolucao.DataDevolucao.Equals(DataDevolucao) &&
                devolucao.DataDevolucao.Equals(ValorTotal) &&
                 CompararTaxas(devolucao) &&
                devolucao.NivelGasolina.Equals(NivelGasolina);

        }

        private bool CompararTaxas(Devolucao devolucao)
        {
            if (TaxasAdicionais.Count != devolucao.TaxasAdicionais.Count)
                return false;

            for (int i = 0; i < TaxasAdicionais.Count; i++)
                if (!EqualityComparer<Taxa>.Default.Equals(TaxasAdicionais[i], devolucao.TaxasAdicionais[i]))
                    return false;

            return true;
        }


    }

}
