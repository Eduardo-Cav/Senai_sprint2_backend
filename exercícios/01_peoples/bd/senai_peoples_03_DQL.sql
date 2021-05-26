USE T_Peoples;

SELECT idFuncionario, nome, sobrenome FROM Funcionarios;

--Buscar funcionários através do nome
SELECT idFuncionario, nome, sobrenome FROM Funcionarios
WHERE nome LIKE 'Eduardo';

--Buscar funcionários com nome completo
SELECT idFuncionario, CONCAT(nome, ' ', sobrenome) AS nomeCompleto FROM Funcionarios;

--buscar funcionários de forma ordenada, de a-z ou z-a
SELECT idFuncionario, nome, sobrenome FROM Funcionarios
ORDER BY nome DESC; --z-a

SELECT idFuncionario, nome, sobrenome FROM Funcionarios
ORDER BY nome ASC; --a-z