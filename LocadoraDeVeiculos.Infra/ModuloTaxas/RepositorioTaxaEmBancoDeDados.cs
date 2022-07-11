using System;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;

namespace LocadoraDeVeiculos.Infra.ModuloTaxas
{
    public class RepositorioTaxaEmBancoDeDados : RepositorioBaseEmBancoDeDados<Taxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [DESCRICAO],
                    [VALOR],
                    [TIPO_CALCULO]
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPO_CALCULO
                );SELECT SCOPE_IDENTITY();";

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
    }
}
