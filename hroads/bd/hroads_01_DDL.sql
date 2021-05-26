--DDL
CREATE DATABASE SENAI_HROADS_TARDE;

USE SENAI_HROADS_TARDE;

CREATE TABLE classe
(
	idClasse INT PRIMARY KEY IDENTITY
	,nome VARCHAR(200) NOT NULL
);
GO

CREATE TABLE personagem
(
	idPersonagem INT PRIMARY KEY IDENTITY
	,nome VARCHAR(200)
	,idClasse INT FOREIGN KEY REFERENCES Classe(idClasse)
	,capacidadeMaxVida INT
	,capacidadeMaxMana INT
	,dataAtualizacao DATE
	,dataCriacao DATE
);
GO


CREATE TABLE tipoHabilidade
(
	idTipoHabilidade INT PRIMARY KEY IDENTITY
	,nome VARCHAR(200) NOT NULL
);
GO

CREATE TABLE habilidade
(
	idHabilidade INT PRIMARY KEY IDENTITY
	,idTH INT FOREIGN KEY REFERENCES TipoHabilidade(idTipoHabilidade)
	,nome VARCHAR(200) NOT NULL
);
GO

CREATE TABLE classeHabilidade
(
	idClasse INT FOREIGN KEY REFERENCES Classe(idClasse)
	,idHabilidade INT FOREIGN KEY REFERENCES Habilidade(idHabilidade)
);

CREATE TABLE tipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	,titulo VARCHAR(200) NOT NULL
);

CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,email VARCHAR(200) NOT NULL
	,senha VARCHAR(200) NOT NULL
	,idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
);


