	CREATE TABLE [dbo].[TBPlanoDeCobranca]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL,
    [grupoDeVeiculo_id] UNIQUEIDENTIFIER NOT NULL,
    [PlanoDiario_ValorDiario] DECIMAL(11, 4) NOT NULL, 
    [PlanoDiario_ValorKm] DECIMAL(11, 4) NOT NULL , 
    [PlanoLivre_ValorDiario] DECIMAL(11, 4) NOT NULL, 
    [PlanoControlado_ValorDiario] DECIMAL(11, 4) NOT NULL, 
    [PlanoControlado_ValorKm] DECIMAL(11, 4) NOT NULL, 
    [PlanoControlado_LimiteKm] DECIMAL(11, 4) NOT NULL, 
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TBPlanoDeCobranca_ToTable] FOREIGN KEY ([grupoDeVeiculo_id]) REFERENCES [TBGrupoVeiculo]([Id])       
)
