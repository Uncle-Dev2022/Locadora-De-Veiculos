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
	             FROM [DBO].[TBPlanoDeCobranca]
              WHERE
	             ID=@ID";        
        protected override string sqlSelecionarPorId =>
            @"SELECT
                PL.[ID] AS ID,
                PL.[NOME] AS NOME,
                [GRUPODEVEICULO_ID],
                GP.[NOME] AS GRUPODEVEICULO_NOME, 
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [TBPlanoDeCobranca] AS PL inner join [TBGRUPOVEICULO] AS GP
                ON
                    PL.GRUPODEVEICULO_ID = GP.ID 
                WHERE
                    PL.[ID]=@ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                PL.[ID] AS ID,
                PL.[NOME] AS NOME,
                [GRUPODEVEICULO_ID],
                GP.[NOME] AS GRUPODEVEICULO_NOME, 
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [TBPlanoDeCobranca] AS PL inner join [TBGRUPOVEICULO] AS GP
                ON
                    PL.GRUPODEVEICULO_ID = GP.ID ";

        protected string sqlSelecionarPorNome =>
            @"SELECT
                PL.[ID] AS ID,
                PL.[NOME] AS NOME,                
                [GRUPODEVEICULO_ID],
                GP.NOME AS GRUPODEVEICULO_NOME, 
                [PLANODIARIO_VALORDIARIO],
                [PLANODIARIO_VALORKM],
                [PLANOLIVRE_VALORDIARIO],
                [PLANOCONTROLADO_VALORDIARIO],
                [PLANOCONTROLADO_VALORKM],
                [PLANOCONTROLADO_LIMITEKM]

                FROM
                    [DBO].[TBPlanoDeCobranca] inner join [GRUPODEVEICULO] AS GP
                    WHERE [NOME] = @NOME";

        public PlanoDeCobranca SelecionarPlanoDeCobrancaPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("[NOME]", nome));
        }
    }

}
