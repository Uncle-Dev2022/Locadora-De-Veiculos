CREATE TABLE [dbo].[TBFuncionario]
(
	 [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
     [Nome] VARCHAR(50) NOT NULL, 
     [Salario] MONEY NOT NULL, 
     [DataAdmissao] DATETIME NOT NULL,
     [Senha] VARCHAR(50) NOT NULL, 
     [Login] VARCHAR(50) NOT NULL,        
     [Gerente] BIT NOT NULL 
)
