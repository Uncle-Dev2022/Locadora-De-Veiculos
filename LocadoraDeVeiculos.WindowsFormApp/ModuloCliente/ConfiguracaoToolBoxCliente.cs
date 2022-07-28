using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;

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
