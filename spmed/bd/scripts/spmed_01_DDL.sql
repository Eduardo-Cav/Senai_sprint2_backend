--DDL
USE SPmed;
--Criando tabelas do banco 
CREATE TABLE tipoUsuario
(
	idTipoUsuario	 INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
	,email			VARCHAR(100) UNIQUE NOT NULL
	,senha			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE paciente
(
	idPaciente		INT PRIMARY KEY IDENTITY
	,idUsuario		INT FOREIGN KEY REFERENCES Usuario(idUsuario)
	,nomePaciente	VARCHAR(200)
	,rg				CHAR(9) UNIQUE NOT NULL
	,cpf			CHAR(11) UNIQUE NOT NULL
	,dataNascimento DATE 
	,endereco		VARCHAR(100) NOT NULL
	,telefone		VARCHAR(11)
);
GO

CREATE TABLE clinica
(
	idClinica				INT PRIMARY KEY IDENTITY
	,endereco				VARCHAR(100) UNIQUE NOT NULL
	,horarioAbertura		TIME(0) NOT NULL
	,horarioFechamento		TIME(0) NOT NULL
	,cnpj					CHAR(14) UNIQUE NOT NULL
	,nomeFantasia			VARCHAR(200) UNIQUE NOT NULL
	,razaoSocial			VARCHAR(200)
);
GO

CREATE TABLE especialidade
(
	idEspecialidade		INT PRIMARY KEY IDENTITY
	,nomeEspecialidade	VARCHAR(200)
);
GO

CREATE TABLE medico
(
	idMedico			INT PRIMARY KEY IDENTITY
	,idEspecialidade	INT FOREIGN KEY REFERENCES especialidade(idEspecialidade)
	,idClinica			INT FOREIGN KEY REFERENCES clinica(idClinica)
	,idUsuario			INT FOREIGN KEY REFERENCES Usuario(idUsuario)
	,nomeMedico			VARCHAR(100) NOT NULL
	,crm				VARCHAR(100) UNIQUE NOT NULL 
);
GO

CREATE TABLE situacao
(
	idSituacao INT PRIMARY KEY IDENTITY
	,descricao VARCHAR(100) NOT NULL
);
GO

CREATE TABLE consulta
(
	idConsulta	     INT PRIMARY KEY IDENTITY
	,idMedico	     INT FOREIGN KEY REFERENCES medico(idMedico)
	,idPaciente 	 INT FOREIGN KEY REFERENCES paciente(idPaciente)
	,idSituacao		 INT FOREIGN KEY REFERENCES situacao(idSituacao)
	,dataAgendamento SMALLDATETIME NOT NULL
	,descricao       VARCHAR(200) DEFAULT('A preencher') --se io médico não inserir uma descrição
	--o campo fica como "A preencher"
);
GO
