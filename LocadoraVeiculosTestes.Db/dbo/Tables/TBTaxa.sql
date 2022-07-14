CREATE TABLE [dbo].[TBTaxa] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Descricao]    VARCHAR (100) NOT NULL,
    [Valor]        FLOAT (53)    NOT NULL,
    [Tipo_Calculo] VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

