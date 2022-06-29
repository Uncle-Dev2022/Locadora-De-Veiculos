using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de Cliente";

        public override string TooltipInserir => "Inserir um novo Cliente";

        public override string TooltipEditar => "Editar um Cliente existente";

        public override string TooltipExcluir => "Excluir Cliente existente";
    }
}
