using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionário
{
    public class RepositorioFuncionarioEmBancoDeDados :
        RepositorioBaseEmBancoDeDados<GrupoDeVeiculo, MapeadorFuncionario>, IRepositorioFuncionario
    {
        protected override string sqlInserir =>
           @"INSERT INTO [TBFUNCIONARIO] 
                (
                    [ID],
                    [NOME],
                    [SALARIO],
                    [DATAADMISSAO],
                    [SENHA],
                    [LOGIN],
                    [GERENTE]
                   
	            )
	            VALUES
                (
                    @ID,
                    @NOME,
                    @SALARIO,
                    @DATAADMISSAO,
                    @SENHA,
                    @LOGIN,
                    @GERENTE
                    
                );";

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

        private string sqlSelecionarPorNome =>
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
                [NOME] = @NOME";

        private string sqlSelecionarPorLogin =>
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
                [LOGIN] = @LOGIN";


        public GrupoDeVeiculo SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public GrupoDeVeiculo SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }

    }
}
