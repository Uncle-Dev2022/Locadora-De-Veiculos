using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public Condutor Condutor { get; set; }
        public Guid CondutorId { get; set; }
        public GrupoDeVeiculo GrupoDeVeiculo { get; set; }
        public Guid GrupoDeVeiculoId { get; set; }
        public Veiculo veiculo { get; set; }
        public Guid veiculoId { get; set; }
        public PlanoDeCobranca planoDeCobranca { get; set; }
        public Guid planoDeCobrancaId { get; set; }
        public List<Taxas> Taxas { get; set; }
        public DateTime dataDeLocacao { get; set; }
        public DateTime dataDeDevolucaoPrevista { get; set; }
        public string KmAtualVeiculo { get; set; }

        public Locacao()
        {

        }
    }
}
