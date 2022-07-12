using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaEmBancoDeDados : RepositorioBaseEmBancoDeDados<PlanoDeCobranca, MapeadorPlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        protected override string sqlInserir =>
    @"INSERT INTO [DBO].[TBPlanoDeCobranca]
            (
                [ID],
                [NOME],
                [GRUPODEVEICULO_ID],
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]
            )
              VALUES
            (
                @ID,
                @NOME,
			    @GRUPODEVEICULO_ID,
			    @PLANODIARIO_VALORDIARIO,
			    @PLANODIARIO_VALORKM,
			    @PLANOLIVRE_VALORDIARIO,
			    @PLANOCONTROLADO_VALORDIARIO,
                @PLANOCONTROLADO_VALORKM,
                @PLANOCONTROLADO_LIMITEKM
			);";

        protected override string sqlEditar =>
            @"UPDATE [DBO].[TBPlanoDeCobranca]
	            SET
                   [NOME] = @NOME,
                   [GRUPODEVEICULO_ID] = @GRUPODEVEICULO_ID,
                   [PLANODIARIO_VALORDIARIO] = @PLANODIARIO_VALORDIARIO,
                   [PLANODIARIO_VALORKM] = @PLANODIARIO_VALORKM,
                   [PLANOLIVRE_VALORDIARIO] = @PLANOLIVRE_VALORDIARIO,
                   [PLANOCONTROLADO_VALORDIARIO] = @PLANOCONTROLADO_VALORDIARIO,
                   [PLANOCONTROLADO_VALORKM] = @PLANOCONTROLADO_VALORKM,
                   [PLANOCONTROLADO_LIMITEKM] = @PLANOCONTROLADO_LIMITEKM
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
                [NOME],
                [GRUPODEVEICULO_ID],
                [(SELECT [NOME] FROM [DBO].[TBGrupoVeiculo] WHERE TBGrupoVeiculo.Id = [GRUPODEVEICULO_ID])] AS GRUPODEVEICULO_NOME,
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [DBO].[TBPlanoDeCobranca]
                WHERE
                    [ID]=@ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                [ID],
                [NOME],
                [GRUPODEVEICULO_ID],
                [(SELECT [NOME] FROM [DBO].[TBGrupoVeiculo] WHERE TBGrupoVeiculo.Id = [GRUPODEVEICULO_ID])] AS GRUPODEVEICULO_NOME,
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [DBO].[TBPlanoDeCobranca]";

        protected string sqlSelecionarPorNome =>
            @"SELECT
                [ID],
                [NOME],
                [GRUPODEVEICULO_ID],
                [(SELECT [NOME] FROM [DBO].[TBGrupoVeiculo] WHERE TBGrupoVeiculo.Id = [GRUPODEVEICULO_ID])] AS GRUPODEVEICULO_NOME,
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [DBO].[TBPlanoDeCobranca]
                WHERE [NOME] = @NOME";

        public PlanoDeCobranca SelecionarPlanoDeCobrancaPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("[NOME]", nome));
        }
    }

}
