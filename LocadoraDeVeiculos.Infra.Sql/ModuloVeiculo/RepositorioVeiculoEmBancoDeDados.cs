using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDeDados :
        RepositorioBaseEmBancoDeDados<Veiculo, MapeadorVeiculo>,
        IRepositorioVeiculo
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
                   (
                   [ID],
                   [MARCA],
                   [MODELO],
                   [COR],
                   [ANOMODELO],
                   [TIPOCOMBUSTIVEL],
                   [PLACA],
                   [QUILOMETRAGEM],
                   [CAPACIDADETANQUE],
                   [IMAGEM],
                   [GRUPODEVEICULO_ID]
                    )
             VALUES
               (
                   @ID,
                   @MARCA,
                   @MODELO,
                   @COR,
                   @ANOMODELO,
                   @TIPOCOMBUSTIVEL,
                   @PLACA,
                   @QUILOMETRAGEM,
                   @CAPACIDADETANQUE,
                   @IMAGEM,
                   @GRUPODEVEICULO_ID
                   
                );";

        protected override string sqlEditar =>
             @" UPDATE [TBVEICULO]
                    SET 
                   [MARCA] = @MARCA,
                   [MODELO] = @MODELO,
                   [COR] = @COR,
                   [ANOMODELO] =  @ANOMODELO,
                   [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                   [PLACA] = @PLACA,
                   [QUILOMETRAGEM] = @QUILOMETRAGEM,
                   [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                   [IMAGEM] = @IMAGEM,
                   [GRUPODEVEICULO_ID] = @GRUPODEVEICULO_ID

                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBVEICULO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
          @"SELECT 
                   VEICULO.[ID] AS VEICULO_ID,
                   VEICULO.[MARCA] AS VEICULO_MARCA,
                   VEICULO.[MODELO] AS VEICULO_MODELO,
                   VEICULO.[COR] AS VEICULO_COR,
                   VEICULO.[ANOMODELO] AS VEICULO_ANOMODELO,
                   VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                   VEICULO.[PLACA] AS VEICULO_PLACA,
                   VEICULO.[QUILOMETRAGEM] AS VEICULO_QUILOMETRAGEM,
                   VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                   VEICULO.[IMAGEM] AS VEICULO_IMAGEM,
                   VEICULO.[GRUPODEVEICULO_ID] AS VEICULO_GRUPODEVEICULO_ID,
                   
                   GRUPOVEICULO.[NOME] AS GRUPOVEICULO_NOME


            FROM
                TBVEICULO AS VEICULO LEFT JOIN 
                TBGRUPOVEICULO AS GRUPOVEICULO
            ON
                VEICULO.[GRUPODEVEICULO_ID] = GRUPOVEICULO.[ID]

            WHERE 
                VEICULO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                   VEICULO.[ID] AS VEICULO_ID,
                   VEICULO.[MARCA] AS VEICULO_MARCA,
                   VEICULO.[MODELO] AS VEICULO_MODELO,
                   VEICULO.[COR] AS VEICULO_COR,
                   VEICULO.[ANOMODELO] AS VEICULO_ANOMODELO,
                   VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                   VEICULO.[PLACA] AS VEICULO_PLACA,
                   VEICULO.[QUILOMETRAGEM] AS VEICULO_QUILOMETRAGEM,
                   VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                   VEICULO.[IMAGEM] AS VEICULO_IMAGEM,
                   VEICULO.[GRUPODEVEICULO_ID] AS VEICULO_GRUPODEVEICULO_ID,
                   
                   GRUPOVEICULO.[NOME] AS GRUPOVEICULO_NOME


            FROM
                TBVEICULO AS VEICULO LEFT JOIN 
                TBGRUPOVEICULO AS GRUPOVEICULO
            ON 
                VEICULO.[GRUPODEVEICULO_ID] = GRUPOVEICULO.[ID]";

        private string sqlSelecionarPorPlaca =>
                @"SELECT 
                   VEICULO.[ID] AS VEICULO_ID,
                   VEICULO.[MARCA] AS VEICULO_MARCA,
                   VEICULO.[MODELO] AS VEICULO_MODELO,
                   VEICULO.[COR] AS VEICULO_COR,
                   VEICULO.[ANOMODELO] AS VEICULO_ANOMODELO,
                   VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,
                   VEICULO.[PLACA] AS VEICULO_PLACA,
                   VEICULO.[QUILOMETRAGEM] AS VEICULO_QUILOMETRAGEM,
                   VEICULO.[CAPACIDADETANQUE] AS VEICULO_CAPACIDADETANQUE,
                   VEICULO.[IMAGEM] AS VEICULO_IMAGEM,
                   VEICULO.[GRUPODEVEICULO_ID] AS VEICULO_GRUPODEVEICULO_ID,

                   GRUPOVEICULO.[NOME] AS GRUPOVEICULO_NOME


            FROM
                TBVEICULO AS VEICULO LEFT JOIN 
                TBGRUPOVEICULO AS GRUPOVEICULO 
            ON 
                VEICULO.[PLACA] = @PLACA";



        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }



    }






}

