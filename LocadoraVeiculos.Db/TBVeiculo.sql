CREATE TABLE [dbo].[TBVeiculo]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Marca] VARCHAR(50) NOT NULL,
    [Modelo] VARCHAR(200) NOT NULL,
    [Cor] VARCHAR(50) NOT NULL,
    [AnoModelo] VARCHAR(50) NOT NULL,
    [TipoCombustivel] VARCHAR(50) NOT NULL,
    [Placa] VARCHAR(7) NOT NULL,
    [Quilometragem] DECIMAL NOT NULL,
    [CapacidadeTanque] INT NOT NULL,
    [Imagem] VARBINARY(MAX) NOT NULL,
    [GrupoDeVeiculo_ID] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_TBVeiculo_ToTBGrupoVeiculo] FOREIGN KEY ([GrupoDeVeiculo_ID]) REFERENCES [TBGrupoVeiculo]([Id]),
)
