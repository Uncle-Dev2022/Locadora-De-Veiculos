using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloDevolucao
{
    public class ConfigToolBoxDevolucao : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Devolucão";

        public override string TooltipInserir => "Inserir uma nova Devolucão";

        public override string TooltipEditar => "Editar uma devolucão existente";

        public override string TooltipExcluir => "Excluir uma devolucão existente";



    }
}
