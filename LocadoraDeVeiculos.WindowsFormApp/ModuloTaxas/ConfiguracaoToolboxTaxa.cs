using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    public class ConfiguracaoToolboxTaxa : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir => "Inserir uma nova Taxa";

        public override string TooltipEditar => "Editar uma nova Taxa";

        public override string TooltipExcluir => "Excluir uma nova Taxa";
    }
}
