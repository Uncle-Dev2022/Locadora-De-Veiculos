﻿using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDeDados : RepositorioBaseEmBancoDeDados<Condutor, MapeadorCondutor> , IRepositorioCondutor
    {
		protected override string sqlInserir =>
			@"INSERT INTO [TBCONDUTOR]
			(
				[ID],
				[NOME],
				[ENDERECO],
				[CPF],
				[CNH],
				[EMAIL],
				[CLIENTE_ID]

			)
			values
			(
				@ID,
				@NOME,
				@ENDERECO,
				@CPF,
				@CNH,
				@EMAIL,
				@CLIENTE_ID

			);";


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
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[EMAIL] CONDUTOR_EMAIL,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
				
				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF_CNPJ] CLIENTE_CPF_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				CLIENTE.[CNH] CLIENTE_CNH,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE

				FROM 
					[TBCONDUTOR] AS CONDUTOR LEFT JOIN
					[TBCLIENTE] AS CLIENTE
				ON
					CLIENTE.ID = CONDUTOR.CLIENTE_ID
				WHERE
					CONDUTOR.[ID]=@ID";

		protected override string sqlSelecionarTodos =>
			@"SELECT 
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[EMAIL] CONDUTOR_EMAIL,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,

				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF_CNPJ] CLIENTE_CPF_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				CLIENTE.[CNH] CLIENTE_CNH,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE

				FROM 
					[TBCONDUTOR] AS CONDUTOR LEFT JOIN
					[TBCLIENTE] AS CLIENTE
				ON
					CLIENTE.ID = CONDUTOR.CLIENTE_ID";

		protected string sqlSelecionarPorNome =>
			@"SELECT 
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[EMAIL] CONDUTOR_EMAIL,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,

				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF_CNPJ] CLIENTE_CPF_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				CLIENTE.[CNH] CLIENTE_CNH,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE

				FROM 
					[TBCONDUTOR] AS CONDUTOR LEFT JOIN
					[TBCLIENTE] AS CLIENTE
				ON
					CONDUTOR.[NOME] = @CONDUTOR.[NOME]";

		protected string sqlSelecionarPorCPF =>
			@"SELECT 
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[EMAIL] CONDUTOR_EMAIL,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,

				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF_CNPJ] CLIENTE_CPF_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				CLIENTE.[CNH] CLIENTE_CNH,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE

				FROM 
					[TBCONDUTOR] AS CONDUTOR LEFT JOIN
					[TBCLIENTE] AS CLIENTE
				ON
					CONDUTOR.[CPF] = @CONDUTOR.[CPF]";

		protected string sqlSelecionarPorCNH =>
			@"SELECT 
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[EMAIL] CONDUTOR_EMAIL,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,

				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF_CNPJ] CLIENTE_CPF_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				CLIENTE.[CNH] CLIENTE_CNH,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE

				FROM 
					[TBCONDUTOR] AS CONDUTOR LEFT JOIN
					[TBCLIENTE] AS CLIENTE
				ON
					CONDUTOR.[CNH] = @CONDUTOR.[CNH]";

		public Condutor SelecionarCondutorPorNome(string nome)
		{
			return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("@CONDUTOR.[NOME]", nome));
		}

		public Condutor SelecionarCondutorPorCPF(string CPF)
		{
			return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CONDUTOR.[CPF]", CPF));
		}

		public Condutor SelecionarCondutorPorCNH(string CNH)
        {
			return SelecionarPorParametro(sqlSelecionarPorCNH,new SqlParameter("CONDUTOR.[CNH]",CNH));
        }
	}
}
