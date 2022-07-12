CREATE TABLE [dbo].[TBTaxa]
(
    [id] UNIQUEIDENTIFIER NOT NULL, 
    [Descricao] VARCHAR(100) NOT NULL, 
    [Valor] FLOAT NOT NULL, 
    [Tipo_Calculo] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY ([id])
)
