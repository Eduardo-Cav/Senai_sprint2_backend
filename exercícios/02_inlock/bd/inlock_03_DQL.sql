--DQL
USE inlock_games_tarde;
--lista todos os usuários
SELECT * FROM usuario;

--lista todos os estudios
SELECT * FROM estudio;

--lista todos os jogos
SELECT * FROM jogo;

--Lista os tipos de usuarios
SELECT * FROM tipoUsuario;

--Listar todos os jogos e seus respectivos estúdios
SELECT nomeJogo, nomeEstudio, descricao, dataLancamento, valor FROM jogo j
INNER JOIN estudio e
ON e.idEstudio = j.idEstudio;

--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
--todos os estúdios mesmo que eles não contenham nenhum jogo de referência
SELECT nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM estudio e
LEFT JOIN jogo j
ON j.idEstudio = e.idEstudio;

--buscar um usuário por email e senha
SELECT idUsuario, email, senha, idTipoUsuario FROM usuario
WHERE email = 'admin@admin.com' AND senha = 'admin';

--buscar um jogo por id
SELECT nomeJogo FROM jogo
WHERE idJogo = 1;

--bucar um estúdio por id
SELECT nomeEstudio FROM estudio
WHERE idEstudio = 1;