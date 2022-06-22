CREATE TABLE [dbo].[TBFuncionario]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] VARCHAR(50) NOT NULL, 
    [Senha] VARCHAR(50) NOT NULL, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Salario] MONEY NOT NULL, 
    [DataAdmissao] DATETIME NOT NULL, 
    [TipoDePerfil] BIT NOT NULL IDENTITY
)
