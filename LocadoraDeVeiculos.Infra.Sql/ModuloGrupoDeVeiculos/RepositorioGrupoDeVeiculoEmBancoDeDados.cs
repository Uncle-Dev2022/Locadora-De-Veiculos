using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculoOrm :
        RepositorioBaseEmBancoDeDados<GrupoDeVeiculo, MapeadorGrupoDeVeiculo>, IRepositorioGrupoDeVeiculo
    {


        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULO] 
                (
                    [ID],                   
                    [NOME]                   
	            )
	            VALUES
                (
                    @ID,
                    @NOME
                    
                );";

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

        private string sqlSelecionarPorNome =>
               @"SELECT 
                   [ID],       
                   [NOME] 
            FROM
                [TBGRUPOVEICULO]
            WHERE 
                [NOME] = @NOME";

        public GrupoDeVeiculo SelecionarGrupoDeVeiculoPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }


    }
}
