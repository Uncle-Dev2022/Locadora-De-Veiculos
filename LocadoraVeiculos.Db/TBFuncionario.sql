CREATE TABLE [dbo].[TBFuncionario]
(
     [id] UNIQUEIDENTIFIER NOT NULL, 
     [Nome] VARCHAR(50) NOT NULL, 
     [Salario] MONEY NOT NULL, 
     [DataAdmissao] DATETIME NOT NULL,
     [Senha] VARCHAR(50) NOT NULL, 
     [Login] VARCHAR(50) NOT NULL,        
     [Gerente] BIT NOT NULL, 
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY ([id]) 
)
