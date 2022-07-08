using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor
{
    public class ConfiguracaoToolBoxCondutor : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Condutor";

        public override string TooltipInserir => "Inserir um novo Condutor";

        public override string TooltipEditar => "Editar um Condutor existente";

        public override string TooltipExcluir => "Excluir Condutor existente";
    }
}
