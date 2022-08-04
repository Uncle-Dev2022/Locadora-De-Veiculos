using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    public class ConfiguracaoToolBoxLocacao : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Locação";

        public override string TooltipInserir => "Inserir uma nova Locação";

        public override string TooltipEditar => "Editar uma Locação existente";

        public override string TooltipExcluir => "Excluir uma Locação existente";
    }
}
