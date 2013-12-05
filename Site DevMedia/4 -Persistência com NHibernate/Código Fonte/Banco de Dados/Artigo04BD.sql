/*Script de Banco de Dados para o Artigo 04
Persistência com NHibernate
*/
--Criando Banco de Dados Artigo 04
CREATE DATABASE Artigo04
GO

USE Artigo04
GO

--Tabela Autor
CREATE TABLE Autor(
	id					INT IDENTITY,
	nomeCompleto		VARCHAR(100) NOT NULL,
	email				VARCHAR(100) NOT NULL,
	contaDevmedia		VARCHAR(100) NOT NULL,
	DataCadastro		DATETIME
)
GO

ALTER TABLE Autor ADD CONSTRAINT PK_Autor PRIMARY KEY(id)
GO

ALTER TABLE Autor ADD CONSTRAINT DefaultDataCadastro DEFAULT GETDATE() FOR DataCadastro
GO

--Tabela Tecnologia
CREATE TABLE Tecnologia(
	id					INT IDENTITY,
	nome				VARCHAR(100)
)
GO

ALTER TABLE Tecnologia ADD CONSTRAINT PK_Tecnologia PRIMARY KEY(id)
GO

--Tabela Artigo
CREATE TABLE Artigo(
	id					INT IDENTITY,
	idTecnologia		INT,
	idAutor				INT,	
	titulo				VARCHAR(100),
	descricao			VARCHAR(1000),
	valor				FLOAT,
	DataInicio			DATE,
	DataFim				DATE,
	DataPublicacao		DATE
)
GO

ALTER TABLE Artigo ADD CONSTRAINT PK_Artigo PRIMARY KEY(id)
GO

ALTER TABLE Artigo ADD CONSTRAINT DefaultDataInicioArtigo				DEFAULT GETDATE() FOR DataInicio
ALTER TABLE Artigo ADD CONSTRAINT DefaultDataFimArtigo					DEFAULT GETDATE() FOR DataFim
ALTER TABLE Artigo ADD CONSTRAINT DefaultDataPublicacaoArtigo			DEFAULT GETDATE() FOR DataPublicacao
GO

ALTER TABLE Artigo ADD CONSTRAINT FK_Artigo_Tecnologia	FOREIGN KEY(idTecnologia) REFERENCES Tecnologia(id)
ALTER TABLE Artigo ADD CONSTRAINT FK_Artigo_Autor		FOREIGN KEY(idAutor) REFERENCES Autor(id)	
GO

/*Testes*/
INSERT INTO Tecnologia (nome) VALUES ('.NET'); select SCOPE_IDENTITY();

SELECT * FROM Tecnologia
GO

DELETE FROM Tecnologia

