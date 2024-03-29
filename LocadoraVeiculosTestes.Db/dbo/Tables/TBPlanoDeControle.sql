﻿CREATE TABLE [dbo].[TBPlanoDeControle] (
    [Id]                          INT             NOT NULL,
    [Nome]                        VARCHAR (50)    NOT NULL,
    [grupoDeVeiculo_id]           INT             NOT NULL,
    [PlanoDiario_ValorDiario]     DECIMAL (11, 4) NOT NULL,
    [PlanoDiario_ValorKm]         DECIMAL (11, 4) NOT NULL,
    [PlanoLivre_ValorDiario]      DECIMAL (11, 4) NOT NULL,
    [PlanoControlado_ValorDiario] DECIMAL (11, 4) NOT NULL,
    [PlanoControlado_ValorKm]     DECIMAL (11, 4) NOT NULL,
    [PlanoControlado_LimiteKm]    DECIMAL (11, 4) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

