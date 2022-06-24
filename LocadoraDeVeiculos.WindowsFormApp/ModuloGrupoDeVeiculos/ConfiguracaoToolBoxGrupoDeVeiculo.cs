using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos
{
    public class ConfiguracaoToolBoxGrupoDeVeiculo : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de grupo de veículos";

        public override string TooltipInserir => "Inserir um novo grupo de veículos";

        public override string TooltipEditar => "Editar um grupo de veículos existente";

        public override string TooltipExcluir => "Excluir um grupo de veículos existente";

    }
}
