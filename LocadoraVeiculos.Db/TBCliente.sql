CREATE TABLE [dbo].[TBCliente]
(
    [id] UNIQUEIDENTIFIER NOT NULL, 
    [Nome] VARCHAR(100) NOT NULL, 
    [CPF_CNPJ] VARCHAR(50) NOT NULL, 
    [Endereco] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Telefone] VARCHAR(50) NOT NULL, 
    [CNH] VARCHAR(50) NULL, 
    [TipoCliente] BIT NOT NULL, 
    CONSTRAINT [PK_TBCliente] PRIMARY KEY ([id])
)
