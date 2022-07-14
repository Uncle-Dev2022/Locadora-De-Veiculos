using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    public class ConfiguracaoToolBoxPlanoDeCobranca : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Plano de Cobrança";

        public override string TooltipInserir => "Inserir um novo Plano de Cobrança";

        public override string TooltipEditar => "Editar um Plano de Cobrança existente";

        public override string TooltipExcluir => "Excluir Plano de Cobrança existente";
    }
}
