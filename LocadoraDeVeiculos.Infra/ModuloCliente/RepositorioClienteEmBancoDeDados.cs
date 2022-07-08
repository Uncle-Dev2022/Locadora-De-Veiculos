using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBaseEmBancoDeDados<Cliente,MapeadorCliente>,IRepositorioCliente
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
			    @TELEFONE,
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

        protected string sqlSelecionarPorNome =>
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
                    [NOME]=@NOME";

        protected string sqlSelecionarPorCPF_CNPJ =>
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
                    [CPF_CNPJ]=@CPF_CNPJ";

        public Cliente SelecionarClientePorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Cliente SelecionarClientePorCPFOuCNPJ(string CPF_CNPJ)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF_CNPJ, new SqlParameter("CPF_CNPJ", CPF_CNPJ));
        }
    }
}
