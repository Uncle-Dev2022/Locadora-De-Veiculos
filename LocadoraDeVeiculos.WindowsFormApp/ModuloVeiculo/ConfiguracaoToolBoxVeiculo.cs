using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Veículo";

        public override string TooltipInserir => "Inserir um novo Veículo";

        public override string TooltipEditar => "Editar um Veículo existente";

        public override string TooltipExcluir => "Excluir um Veículo existente";



    }
}
