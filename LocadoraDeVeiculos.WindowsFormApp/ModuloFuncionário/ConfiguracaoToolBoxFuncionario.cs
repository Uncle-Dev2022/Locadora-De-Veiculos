using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
{
    public class ConfiguracaoToolBoxFuncionario : ConfiguracaoToolBoxBase
    {
        public override string TipoCadastro => "Controle de funcionario";

        public override string TooltipInserir => "Inserir um novo funcionario";

        public override string TooltipEditar => "Editar um funcionario existente";

        public override string TooltipExcluir => "Excluir um funcionario existente";

    }
}
