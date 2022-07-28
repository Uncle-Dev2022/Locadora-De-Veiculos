using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    public class ConfiguracaoToolBoxTaxa : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir => "Inserir uma nova Taxa";

        public override string TooltipEditar => "Editar uma nova Taxa";

        public override string TooltipExcluir => "Excluir uma nova Taxa";
    }
}
