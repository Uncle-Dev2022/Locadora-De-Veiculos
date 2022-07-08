CREATE TABLE [dbo].[TBPlanoDeControle]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [grupoDeVeiculo_id] INT NOT NULL,
    [tipoPlano] VARCHAR(20) NOT NULL,
    [valorDiario] DECIMAL(11, 4) NOT NULL , 
    [valorKm] DECIMAL(11, 4) NULL DEFAULT 0, 
    [limiteKm] DECIMAL(11, 4) NULL DEFAULT 0
)
