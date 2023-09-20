--DDL - Data Definition Language

CREATE DATABASE [Event+Tarde]

USE [Event+Tarde]

------------------------------------------
-- Tabelas sem chave estrangeira
CREATE TABLE TiposDeUsuario
(
	IdTiposDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(50) NOT NULL ,
	Endereco VARCHAR(100) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE
)	

CREATE TABLE TiposDeEventos
(
	IdTiposDeEventos INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(50) NOT NULL UNIQUE
)




---------------------------------------------------
-- Tabelas com chave estrangeira
CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTiposDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTiposDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
)

CREATE TABLE Eventos
(
	IdEventos INT PRIMARY KEY IDENTITY,
	IdTiposDeEventos INT FOREIGN KEY REFERENCES TiposDeEventos(IdTiposDeEventos) NOT NULL,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataEvento DATE NOT NULL,
	HorarioEvento TIME NOT NULL
)

CREATE TABLE PresencasEvento
(
	IdPresencasEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEventos INT FOREIGN KEY REFERENCES Eventos(IdEventos) NOT NULL,
	Situacao BIT DEFAULT(0)
)


CREATE TABLE ComentarioEvento
(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEventos INT FOREIGN KEY REFERENCES Eventos(IdEventos) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	Exibe BIT DEFAULT(0)
)


SELECT * FROM TiposDeUsuario
SELECT * FROM TiposDeEventos
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Eventos
SELECT * FROM PresencasEvento
SELECT * FROM ComentarioEvento
