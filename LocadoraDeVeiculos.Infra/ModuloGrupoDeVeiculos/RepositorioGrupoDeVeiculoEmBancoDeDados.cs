using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;


namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculoEmBancoDeDados :
        RepositorioBaseEmBancoDeDados<GrupoDeVeiculo, ValidadorGrupoDeVeiculo, MapeadorGrupoDeVeiculo>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULO] 
                (
                    [NOME]
                   
	            )
	            VALUES
                (
                    @NOME
                    
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBGRUPOVEICULO]	
		        SET
			        [NOME] = @NOME
			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULO]			        
		        WHERE
			        [ID] = @ID";


        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [NOME]
	            FROM 
		            [TBGRUPOVEICULO]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [NOME]
	            FROM 
		            [TBGRUPOVEICULO]";
    }
}
