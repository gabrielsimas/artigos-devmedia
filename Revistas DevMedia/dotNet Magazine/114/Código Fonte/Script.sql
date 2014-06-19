/** Banco de Dados para Artigo Para a Série Aplicações Seguras Padrão OWASP e NIST.GOV **/
--Sistema de Votos no qual, cada curtida de usuário, o projeto ganha R$10,00 diante disto, quanto mais curtidas, maior será o valor arrecadado para o Projeto.
-- A ONG também pode informar o que está precisando e a quantidade de membros auxiliados pela ONG
-- O Cliente pode fazer sua doação de itens necessários para a manutenção das creches e não em dinheiro.
CREATE DATABASE OWASPNIST
GO

USE OWASPNIST
GO

CREATE TABLE ong (
	id				INT IDENTITY,
	cnpj			VARCHAR(14),
	cpf				VARCHAR(11), 
	nomeFantasia	VARCHAR(50),
	razaoSocial		VARCHAR(100),
	estado			VARCHAR(1)
)
GO

ALTER TABLE ong ADD CONSTRAINT PK_ong PRIMARY KEY(id)
GO

SELECT * FROM Ong
GO

DROP TABLE Usuario
GO

CREATE TABLE Usuario(
	id				INT IDENTITY,
	idPapel			INT,
	nomeCompleto	VARCHAR(50),
	apelido			VARCHAR(50),
	conta			VARCHAR(50),
	senha			VARCHAR(500),
	perguntaSecreta	VARCHAR(100),
	respostaSecreta VARCHAR(100),
	email			VARCHAR(50),
	estado			INT, /*0 = Bloqueado; 1 = Liberado */	
)
GO

SELECT * FROM Usuario
GO

ALTER TABLE Usuario ADD CONSTRAINT PK_Usuario PRIMARY KEY(id)
GO

ALTER TABLE Usuario ADD CONSTRAINT FK_UsuarioPapelId FOREIGN KEY(idPapel) REFERENCES Papel(id)
GO

ALTER TABLE Usuario ADD CONSTRAINT CK_Estado CHECK (estado IN (0,1))

ALTER TABLE Usuario ALTER COLUMN senha VARCHAR(500)
GO

CREATE TABLE Papel (

	id				INT IDENTITY,
	nome			VARCHAR(100),
	administrador	INT DEFAULT(0) /*0 = Não; 1= Sim */
)

ALTER TABLE Papel ADD CONSTRAINT PK_Papel PRIMARY KEY(id)
ALTER TABLE Papel ADD CONSTRAINT CK_AdmSimNao CHECK (administrador IN (0,1))


CREATE TABLE Projeto (

	id			INT IDENTITY,
	idOng		INT NOT NULL,
	nome		VARCHAR(100),
	descricao	VARCHAR(200), /**Uma Mini descrição do Projeto**/
	custo		SMALLMONEY
)

ALTER TABLE Projeto ADD CONSTRAINT PK_Projeto PRIMARY KEY(id)
ALTER TABLE Projeto ADD CONSTRAINT FK_Projeto_Ong FOREIGN KEY(idOng) REFERENCES Ong(id)
GO

CREATE TABLE Curtida (
	id INT IDENTITY,
	idProjeto INT NOT NULL
)
GO

ALTER TABLE Curtida ADD CONSTRAINT PK_Curtida PRIMARY KEY(id)
ALTER TABLE Curtida ADD CONSTRAINT FK_Curtida_Projt FOREIGN KEY(idProjeto) REFERENCES Projeto(id)
GO

CREATE TABLE UsuarioCurtida(
	id			INT IDENTITY,
	idUsuario	INT NOT NULL
)

ALTER TABLE UsuarioCurtida ADD CONSTRAINT PK_UsuarioCurtida PRIMARY KEY(id)
ALTER TABLE UsuarioCurtida ADD CONSTRAINT FK_UsuarioCurtida_Projt FOREIGN KEY(idUsuario) REFERENCES Usuario(id)
GO

CREATE TABLE OngNecessidade(
	id		INT IDENTITY,
	idOng	INT NOT NULL,
	item	VARCHAR(100),
	qtd		INT
)

ALTER TABLE OngNecessidade ADD CONSTRAINT PK_OngNecessidade PRIMARY KEY(id)
ALTER TABLE OngNecessidade ADD CONSTRAINT FK_OngNecessidadeOng FOREIGN KEY(idOng) REFERENCES Ong(id)
GO

/*============= LOGS ============*/
/* Log de Erros*/

/* Log de Acesso */

/* Log de Eventos */

/** Fim Banco de Dados para Artigo Para a Série Aplicações Seguras Padrão OWASP e NIST.GOV **/
