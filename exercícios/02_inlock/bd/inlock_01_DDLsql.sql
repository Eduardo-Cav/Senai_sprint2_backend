--DDL

CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO

CREATE TABLE estudio
(
	idEstudio		INT PRIMARY KEY IDENTITY
	,nomeEstudio	VARCHAR(200) NOT NULL
);
GO

CREATE TABLE jogo
(
	idJogo			INT PRIMARY KEY IDENTITY
	,nomeJogo		VARCHAR(200) NOT NULL
	,descricao		VARCHAR(200) NOT NULL
	,dataLancamento DATE NOT NULL
	,valor			SMALLMONEY NOT NULL
	,idEstudio		INT FOREIGN KEY REFERENCES estudio(idEstudio)
);
GO

CREATE TABLE tipoUsuario
(
	idTipoUsuario	INT PRIMARY KEY IDENTITY
	,titulo			VARCHAR(200) NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,email			VARCHAR(200) NOT NULL
	,senha			VARCHAR(200) NOT NULL
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
);
GO

