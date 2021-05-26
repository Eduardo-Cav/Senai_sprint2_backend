--DQL
USE SENAI_HROADS_TARDE;

SELECT * FROM personagem;

SELECT * FROM classe;

SELECT * FROM usuario;

SELECT * FROM tipoUsuario;

SELECT nome
FROM classe;

SELECT * FROM habilidade;

SELECT * FROM classeHabilidade;

SELECT COUNT (DISTINCT idHabilidade) 'Quantidade/Habilidades'
FROM habilidade
GO

SELECT habilidade.idHabilidade
FROM habilidade;


SELECT * FROM tipoHabilidade;

SELECT H.nome AS habilidade, tipoHabilidade.Nome AS tipoHabilidade
FROM habilidade AS H
INNER JOIN tipoHabilidade
ON H.idTH = tipoHabilidade.idTipoHabilidade;


SELECT personagem.nome, classe.nome FROM personagem
INNER JOIN classe
ON personagem.idClasse = classe.idClasse;

SELECT personagem.nome, classe.nome FROM personagem
RIGHT JOIN classe
ON personagem.idClasse = classe.idClasse;

SELECT H.nome AS Habilidade, C.nome AS classe
FROM classeHabilidade AS CH
INNER JOIN classe AS C
ON C.idClasse = CH.idClasse
INNER JOIN Habilidade AS H
ON H.idHabilidade = CH.idHabilidade;

SELECT classe.nome, H.nome 
FROM classeHabilidade AS CH
INNER JOIN classe
ON classe.idClasse = CH.idClasse
INNER JOIN habilidade AS H
ON H.idHabilidade = CH.idHabilidade;


SELECT H.nome AS Habilidade, C.nome AS Classe
FROM classeHabilidade AS CH
RIGHT JOIN habilidade AS H
ON  H.idHabilidade = CH.idHabilidade
RIGHT JOIN classe AS C
ON C.idClasse = CH.idClasse;
