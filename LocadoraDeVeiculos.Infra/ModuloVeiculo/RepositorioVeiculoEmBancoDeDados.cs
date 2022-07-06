using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDeDados :
        RepositorioBaseEmBancoDeDados<Veiculo, MapeadorVeiculo>,
        IRepositorioVeiculo
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
                   (
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
                   
                );  SELECT SCOPE_IDENTITY();";

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
                   VEICULO.[ID] AS IDVEICULO,
                   VEICULO.[MARCA] AS MARCAVEICULO,
                   VEICULO.[MODELO] AS MODELOVEICULO,
                   VEICULO.[COR] AS CORVEICULO,
                   VEICULO.[ANOMODELO] AS ANOMODELOVEICULO,
                   VEICULO.[TIPOCOMBUSTIVEL] AS TIPOCOMBUSTIVELVEICULO,
                   VEICULO.[PLACA] AS PLACAVEICULO,
                   VEICULO.[QUILOMETRAGEM] AS QUILOMETRAGEMVEICULO,
                   VEICULO.[CAPACIDADETANQUE] AS CAPACIDADETANQUEVEICULO,
                   VEICULO.[IMAGEM] AS IMAGEMVEICULO,
                   VEICULO.[GRUPODEVEICULO_ID] AS IDGRUPO,

                   GRUPODEVEICULO.[ID] AS IDGRUPO,
                   GRUPODEVEICULO.[NOME] AS IDGRUPO


            FROM
                TBVEICULO AS VEICULO INNER JOIN TBGRUPOVEICULO AS GRUPODEVEICULO ON VEICULO.[GRUPODEVEICULO_ID] = GRUPODEVEICULO.[ID]
            WHERE 
             VEICULO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                   VEICULO.[MARCA],
                   VEICULO.[MODELO],
                   VEICULO.[COR],
                   VEICULO.[ANOMODELO],
                   VEICULO.[TIPOCOMBUSTIVEL],
                   VEICULO.[PLACA],
                   VEICULO.[QUILOMETRAGEM],
                   VEICULO.[CAPACIDADETANQUE],
                   VEICULO.[IMAGEM],
                   VEICULO.[GRUPODEVEICULO_ID],

                   GRUPODEVEICULO.[ID] AS IDGRUPO,
                   GRUPODEVEICULO.[NOME] AS IDGRUPO

            FROM
                TBVEICULO AS VEICULO inner JOIN  TBGRUPOVEICULO AS GRUPOVEICULO ON VEICULO.[GRUPODEVEICULO_ID] = GRUPOVEICULO.[ID]";

        private string sqlSelecionarPorPlaca =>
                @"SELECT 
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
            FROM
                [TBVEICULO]
            WHERE 
                [PLACA] = @PLACA";

        

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }

        

    }






}

