using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    internal class RepositorioPlanoDeCobrancaEmBancoDeDados : RepositorioBaseEmBancoDeDados<PlanoDeCobranca, MapeadorPlanoDeCobranca>
    {
        protected override string sqlInserir =>
    @"INSERT INTO [DBO].[TBPlanoDeCobranca]
                (
                [GRUPODEVEICULO_ID],
                [TIPOPLANO],
                [VALORDIARIO],
                [VALORKM],
                [LIMITEKM]
                )
              VALUES
                (
			    @GRUPODEVEICULO_ID,
			    @TIPOPLANO,
			    @VALORDIARIO,
			    @VALORKM,
			    @LIMITEKM
			    ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [DBO].[TBPlanoDeCobranca]
	            SET
                   [GRUPODEVEICULO_ID] = @GRUPODEVEICULO_ID,
                   [TIPOPLANO] = @TIPOPLANO,
                   [VALORDIARIO] = @VALORDIARIO,
                   [VALORKM] = @VALORKM,
                   [LIMITEKM] = @LIMITEKM
	            WHERE 
		            [ID]=@ID";

        protected override string sqlExcluir =>
            @"DELETE 
	             FROM [DBO].[TBPlanoDeCobranc]
              WHERE
	             ID=@ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                [ID],
                [GRUPODEVEICULO_ID],
                [(SELECT [NOME] FROM [DBO].[TBGrupoVeiculo] WHERE TBGrupoVeiculo.Id = [GRUPODEVEICULO_ID])] AS GRUPODEVEICULO_NOME,
                [TIPOPLANO],
                [VALORDIARIO],
                [VALORKM],
                [LIMITEKM]
                FROM
                    [DBO].[TBPlanoDeCobranca]
                WHERE
                    [ID]=@ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                [ID],
                [GRUPODEVEICULO_ID],
                [(SELECT [NOME] FROM [DBO].[TBGrupoVeiculo] WHERE TBGrupoVeiculo.Id = [GRUPODEVEICULO_ID])] AS GRUPODEVEICULO_NOME,
                [TIPOPLANO],
                [VALORDIARIO],
                [VALORKM],
                [LIMITEKM]

                FROM
                    [DBO].[TBPlanoDeCobranca]";
    }
}
