using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados : RepositorioBaseEmBancoDeDados<Condutor, MapeadorCondutor>
    {
		protected override string sqlInserir =>
			@"INSERT INTO [TBCONDUTOR]
			(
				[NOME],
				[ENDERECO],
				[CPF],
				[CNH],
				[EMAIL],
				[CLIENTE_ID]

			)
			values
			(
				@NOME,
				@ENDERECO,
				@CPF,
				@CNH,
				@EMAIL,
				@CLIENTE_ID

			); Select SCOPE_IDENTITY();";


		protected override string sqlEditar =>
			@"UPDATE [TBCONDUTOR]

			SET
				[NOME]=@NOME,
				[ENDERECO]=@ENDERECO,
				[CPF]=@CPF,
				[CNH]=@CNH,
				[EMAIL]=@EMAIL,
				[CLIENTE_ID]=@CLIENTE_ID

			WHERE
				[ID] = @ID";

        protected override string sqlExcluir => 
			@"DELETE FROM [TBCONDUTOR]
					WHERE [ID]=@ID";

        protected override string sqlSelecionarPorId =>
			@"SELECT 
				[NOME],
				[ENDERECO],
				[CPF],
				[CNH],
				[EMAIL],
				[CLIENTE_ID]

				FROM 
					[TBCONDUTOR]
				WHERE
				[ID]=@ID";

		protected override string sqlSelecionarTodos =>
			@"SELECT 
				[NOME],
				[ENDERECO],
				[CPF],
				[CNH],
				[EMAIL],
				[CLIENTE_ID]

				FROM 
					[TBCONDUTOR]";

	}
}
