--DML
USE SPmed;

INSERT INTO tipoUsuario(nomeTipoUsuario)
VALUES				   ('Administrador')
					  ,('Médico')
					  ,('Paciente');
GO

INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES		       (1, 'adm@adm.com', 'adm123')
				  ,(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
				  ,(2, 'roberto.possarle@spmedicalgroup.com.br', 'roberto123')
				  ,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123')
				  ,(3, 'ligia@gmail.com', 'ligia123')
				  ,(3, 'alexandre@gmail.com', 'alexandre123')
				  ,(3, 'fernando@gmail.com', 'fernando123')
				  ,(3, 'henrique@gmail.com', 'henrique123')
				  ,(3, 'joao@hotmail.com', 'joao123')
				  ,(3, 'bruno@gmail.com', 'bruno123')
				  ,(3, 'mariana@outlook.com', 'mariana123');
GO

INSERT INTO paciente(idUSuario, nomePaciente, rg, cpf, dataNascimento, telefone, endereco)
VALUES				(5, 'Ligia', '435225435','94839859000', '13/10/1983', '1134567654', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
				   ,(6, 'Alexandre','326543457','73556944057', '23/07/2001', '11987656543', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
				   ,(7, 'Fernando','546365253', '16839338002', '10/10/1978', '11972084453', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
				   ,(8, 'Henrique','543663625', '14332654765', '13/10/1985', '1134566543', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
				   ,(9, 'João', '325444441','91305348010', '27/08/1975', '1176566377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380');

GO
--Cadastro de cliente sem data de nascimento para atualização de registro
INSERT INTO paciente(idUsuario, nomePaciente, rg, cpf, telefone, endereco)
VALUES				(10, 'Bruno','545662667', '79799299004', '11954368769', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001');
GO



--atualização do registro com a inserção da data de nascimento nula 
UPDATE paciente
SET dataNascimento = '21/03/1972'
WHERE idPaciente = 6;
GO

INSERT INTO paciente(idUsuario, nomePaciente, rg, cpf, dataNascimento, endereco)
VALUES				(11, 'Mariana', '545662668', '13771913039', '05/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO paciente(idUsuario, nomePaciente, rg, cpf, dataNascimento, endereco)
VALUES				(12, 'eDUARDO', '545662768', '13771313039', '02/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO clinica(endereco, horarioAbertura, horarioFechamento, cnpj, nomeFantasia, razaoSocial)
VALUES			   ('Av. Barão Limeira, 532, São Paulo, SP', '08:00:00', '20:00:00', '8640090000130', 
					'Clinica Possarle', 'SP Medical Group');
GO

INSERT INTO especialidade(nomeEspecialidade)
VALUES					 ('Acupuntura')
						,('Anestesiologia')
						,('Angiologia')
						,('Cardiologia')
						,('Cirurgia Cardiovascular')
						,('Cirurgia da mão')
						,('Cirurgia do Aparelho Digestivo')
						,('Cirurgia Geral')
						,('Cirurgia Pediátrica')
						,('Cirurgia Plástica')
						,('Cirurgia Torácica')
						,('Cirurgia Vascular')
						,('Dermatologia')
						,('Radioterapia')
						,('Urologia')
						,('Pediatria')
						,('Psiquiatria');
GO

INSERT INTO medico(idEspecialidade, idClinica, idUsuario, nomeMedico, crm)
VALUES			  (2, 1, 2, 'Ricardo Lemos', '54356SP')
				 ,(17, 1, 3, 'Roberto Possarle', '53452SP')
				 ,(16, 1, 4, 'Helena Strada', '65463SP');
GO
INSERT INTO situacao(descricao)
VALUES				('Realizada')
				   ,('Agendada')
				   ,('Cancelada');
GO

INSERT INTO consulta(idMedico, idPaciente, idSituacao, dataAgendamento, descricao) 
VALUES				(3, 7, 1, '20/01/2020  15:00', 'consulta de cuidados rotineira')
				   ,(2, 2, 3, '06/01/2020  10:00', 'remarcar consulta')
				   ,(2, 3, 1, '07/02/2020  11:00', 'reuniao com paciente')
				   ,(2, 2, 1, '06/02/2018  10:00', 'A preencher')
				   ,(1, 4, 3, '07/02/2019  11:00', 'anestesia em cirurgia')
				   ,(3, 7, 2, '08/03/2020  15:00', 'consulta rotineira')
				   ,(1, 4, 2, '09/03/2020  11:00', 'A preencher');
GO
					



/*A tabela 'paciente' foi inserida por meio do processo de importação de dados, 
através da planilha do excel*/

