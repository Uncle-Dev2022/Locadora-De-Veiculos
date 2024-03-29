﻿CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (50) NOT NULL,
    [Salario]      MONEY        NOT NULL,
    [DataAdmissao] DATETIME     NOT NULL,
    [Senha]        VARCHAR (50) NOT NULL,
    [Login]        VARCHAR (50) NOT NULL,
    [Gerente]      BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

