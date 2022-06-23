using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBaseEmBancoDeDados<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [DBO].[TBCLIENTE]
                (

                [NOME],
                [CPF_CNPJ],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [CNH],
                [TIPOCLIENTE]
                )
              VALUES
                (
			    @NOME,
			    @CPF_CNPJ,
			    @ENDERECO,
			    @EMAIL,
			    TELEFONE
			    @CNH,
			    @TIPOCLIENTE
			    ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [DBO].[TBCLIENTE]
	            SET
		            [NOME] = @NOME,
		            [CPF_CNPJ] = @CPF_CNPJ,
                    [ENDERECO] = @ENDERECO,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE,
                    [CNH] = @CNH,
                    [TIPOCLIENTE] = @TIPOCLIENTE
	            WHERE 
		            [ID]=@ID";


        protected override string sqlExcluir =>
            @"DELETE 
	             FROM [DBO].[TBCLIENTE]
              WHERE
	             ID=@ID";


        protected override string sqlSelecionarPorId => 
            @"SELECT
                [ID],
		        [NOME],
		        [CPF_CNPJ],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [CNH],
                [TIPOCLIENTE]

                FROM
                    [DBO].[TBCLIENTE]
                WHERE
                    [ID]=@ID";


        protected override string sqlSelecionarTodos => 
            @"SELECT
                [ID],
		        [NOME],
		        [CPF_CNPJ],
                [ENDERECO],
                [EMAIL],
                [TELEFONE],
                [CNH],
                [TIPOCLIENTE]

                FROM
                    [DBO].[TBCLIENTE]";
    }
}
