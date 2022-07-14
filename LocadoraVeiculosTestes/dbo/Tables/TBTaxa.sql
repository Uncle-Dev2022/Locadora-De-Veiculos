CREATE TABLE [dbo].[TBTaxa] (
    [id]           UNIQUEIDENTIFIER NOT NULL,
    [Descricao]    VARCHAR (100)    NOT NULL,
    [Valor]        FLOAT (53)       NOT NULL,
    [Tipo_Calculo] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([id] ASC)
);

