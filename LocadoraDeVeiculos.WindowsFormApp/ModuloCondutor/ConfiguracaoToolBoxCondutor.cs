using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;

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
