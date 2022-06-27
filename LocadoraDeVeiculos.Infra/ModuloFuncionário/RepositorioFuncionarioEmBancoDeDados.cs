using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.Compartilhado;


namespace LocadoraDeVeiculos.Infra.ModuloFuncionário
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBaseEmBancoDeDados<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
           @"INSERT INTO [TBFUNCIONARIO] 
                (
                    [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [SENHA],
                    [LOGIN],
                    [GERENTE]
                   
	            )
	            VALUES
                (
                    @NOME,
                    @SALARIO,
                    @DATAADMISSAO,
                    @SENHA,
                    @LOGIN,
                    @GERENTE
                    
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBFUNCIONARIO]	
		        SET
			        [NOME] = @NOME,
                    [SALARIO] =  @SALARIO,
                    [DATAADMISSAO] =  @DATAADMISSAO,
                    [SENHA] = @SENHA,
                    [LOGIN] = @LOGIN,
                    [GERENTE] = @GERENTE
			        
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBFUNCIONARIO]			        
		        WHERE
			        [ID] = @ID";


        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
		            [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [SENHA],
                    [LOGIN],
                    [GERENTE]
	            FROM 
		            [TBFUNCIONARIO]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
		            [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [SENHA],
                    [LOGIN],
                    [GERENTE]
	            FROM 
		            [TBFUNCIONARIO]";

    }
}
