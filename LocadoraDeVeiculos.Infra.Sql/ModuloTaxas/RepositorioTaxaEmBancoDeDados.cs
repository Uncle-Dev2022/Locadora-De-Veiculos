using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloTaxas
{
    public class RepositorioTaxaEmBancoDeDados : RepositorioBaseEmBancoDeDados<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [ID],
                    [DESCRICAO],
                    [VALOR],
                    [TIPO_CALCULO]
	            )
	            VALUES
                (
                    @ID,
                    @DESCRICAO,
                    @VALOR,
                    @TIPO_CALCULO
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
                    [DESCRICAO] = @DESCRICAO,
                    [VALOR] = @VALOR,
                    [TIPO_CALCULO] = @TIPO_CALCULO     
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]			        
		        WHERE
			        [ID] = @ID";


        protected override string sqlSelecionarPorId =>
            @"SELECT 
		            [ID], 
                    [DESCRICAO],
                    [VALOR],
                    [TIPO_CALCULO]

	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
                    [DESCRICAO],
                    [VALOR],
                    [TIPO_CALCULO]
	            FROM 
		            [TBTAXA]";

        protected string sqlSelecionarPorDescricao =>
            @"SELECT 
		            [ID], 
                    [DESCRICAO],
                    [VALOR],
                    [TIPO_CALCULO]
	            FROM 
		            [TBTAXA]
                WHERE [DESCRICAO] = @DESCRICAO";

        public Taxa SelecionarPorDescricao(string descricao)
        {
            return SelecionarPorParametro
                (sqlSelecionarPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}
