CREATE TABLE [dbo].[TBCliente] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (100) NOT NULL,
    [CPF_CNPJ]    VARCHAR (50)  NOT NULL,
    [Endereco]    VARCHAR (50)  NOT NULL,
    [Email]       VARCHAR (50)  NOT NULL,
    [Telefone]    VARCHAR (50)  NOT NULL,
    [CNH]         VARCHAR (50)  NULL,
    [TipoCliente] BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

