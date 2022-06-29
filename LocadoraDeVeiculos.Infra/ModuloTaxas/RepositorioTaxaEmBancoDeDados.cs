using System;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;

namespace LocadoraDeVeiculos.Infra.ModuloTaxas
{
    public class RepositorioTaxaEmBancoDeDados : RepositorioBaseEmBancoDeDados<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA] 
                (
                    [DESCRICAO],
                    [VALOR]                   
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR                    
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXA]	
		        SET
                    [DESCRICAO] = @DESCRICAO,
                    [VALOR] = @VALOR     

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
                    [VALOR]     

	            FROM 
		            [TBTAXA]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
		            [ID], 
                    [DESCRICAO],
                    [VALOR]     
	            FROM 
		            [TBTAXA]";
    }
}
