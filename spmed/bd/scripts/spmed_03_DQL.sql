--DQL
USE SPmed;

SELECT * FROM tipoUsuario;

SELECT * FROM usuario

SELECT * FROM paciente;

SELECT * FROM clinica;

SELECT * FROM especialidade;

SELECT * FROM medico;

SELECT * FROM situacao;

SELECT * FROM consulta;


--vincular a tabela consulta com paciente, medico e situacao para melhor interatividade

											/*utilização do CONVERT para definir que dataAgendamento 
											será mostrado no padrão brasileiro*/
SELECT idConsulta, nomeMedico, nomePaciente, CONVERT(VARCHAR, dataAgendamento, 103) dataAgendamento, s.descricao situacao 
FROM consulta c
INNER JOIN medico m
ON m.idMedico = c.idMedico
INNER JOIN paciente p
ON p.idPaciente = c.idPaciente
INNER JOIN situacao s
ON s.idSituacao = c.idSituacao;


--vincular a tabela de medico com a de especialidades
SELECT nomeMedico, nomeEspecialidade FROM medico
INNER JOIN especialidade e
ON medico.idEspecialidade = e.idEspecialidade;


--vincular a tabela de médico com a tabela de clinica
SELECT nomeMedico, crm, nomeFantasia as clinica, endereco FROM medico
INNER JOIN clinica c
ON medico.idClinica = c.idClinica;


--simulação de login
SELECT nomeTipoUsuario FROM usuario u
INNER JOIN tipoUsuario tu
ON u.idTipoUsuario = tu.idTipoUsuario
WHERE email = 'adm@adm.com' AND senha = 'adm123';


--contagem da quantidade de usuarios existem na tabela 'usuario'
SELECT COUNT (DISTINCT idUsuario) 'qntdUsuarios'
FROM usuario;


--mudar o estilo de data para o padrão brasileiro
SELECT GETDATE() padrao_Brasil, CONVERT(VARCHAR, GETDATE(), 103)


--feito o calculo da idade dos pacientes através da data de nascimento e o ano atual
SELECT nomePaciente, YEAR(GETDATE()) - YEAR(dataNascimento)-
IIF(MONTH(GETDATE())*31
+DAY(GETDATE())<MONTH(dataNascimento)*31
+DAY(dataNascimento), 1, 0) AS idadePaciente
FROM paciente;



--função criada para contar quantos médicos pertencem a cada especialidade
CREATE FUNCTION med_especialidade(@idEspecialidade VARCHAR(30))
RETURNS INT
AS
	BEGIN
	DECLARE @quantidade AS INT
	SET @quantidade =
	(

	SELECT COUNT(nomeMedico) FROM medico
	INNER JOIN especialidade e
	ON medico.idEspecialidade = e.idEspecialidade
	WHERE e.nomeEspecialidade = @idEspecialidade

	)
	RETURN @quantidade
END
GO

SELECT quantidade = dbo.med_especialidade('Anestesiologia');


--criar uma função para retornar a idade de todos os usuarios atraves de uma store procedure
CREATE PROCEDURE idadePacienteAll
AS
SELECT idPaciente, nomePaciente, YEAR(GETDATE()) - YEAR(dataNascimento)-
IIF(MONTH(GETDATE())*31
+DAY(GETDATE())<MONTH(dataNascimento)*31
+DAY(dataNascimento), 1, 0) AS idadePaciente
FROM paciente;

EXEC idadePacienteAll;


--criar uma função para retornar a idade de um usuario especifico pelo id atraves de umas store procedure
CREATE PROCEDURE idadePaciente(@idPaciente INT)
AS
SELECT idPaciente, nomePaciente, YEAR(GETDATE()) - YEAR(dataNascimento)-
IIF(MONTH(GETDATE())*31
+DAY(GETDATE())<MONTH(dataNascimento)*31
+DAY(dataNascimento), 1, 0) AS idadePaciente
FROM paciente
WHERE paciente.idPaciente = @idPaciente;

EXEC idadePaciente @idPaciente = 3;





