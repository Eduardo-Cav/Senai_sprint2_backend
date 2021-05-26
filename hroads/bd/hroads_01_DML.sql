--DML
USE SENAI_HROADS_TARDE;

INSERT INTO classe (nome)
VALUES				('Barbaro')
				,	('Cruzado')
				,	('Caçadora de Demonios')
				,	('Monge')	
				,	('Necromante')
				,	('Feiticeiro')
				,	('Arcanista');

INSERT INTO personagem (nome, idClasse, capacidadeMaxVida, capacidadeMaxMana, dataAtualizacao, dataCriacao)
VALUES					('DeuBug', 1, 100, 80, '02/03/2021', '18/01/2019'),
						('BitBug', 4, 100, 100, '02/02/2021', '17/03/2016'),
						('Fer8' , 7, 75, 60, '02/02/2021', '18/03/2018');


INSERT INTO habilidade (nome, idTH)
VALUES					('Lança Mortal', 1)
					   ,('Escudo Supremo', 2)
					   ,('Recuperar Vida', 3);
					  

INSERT INTO tipoHabilidade(nome)
VALUES					   ('Ataque')
						,  ('Defesa')
						,  ('Cura')
						,  ('Magia');

INSERT INTO classeHabilidade(idClasse, idHabilidade)
VALUES						  (1, 1)	
			                 ,(1, 2)
							 ,(2, 2)
							 ,(3, 1)
							 ,(4, 3)
							 ,(4, 2)
							 ,(6, 3);

INSERT INTO tipoUsuario(titulo)
VALUES				   ('Administrador')
					  ,('Jogador');

INSERT INTO usuario(email, senha, idTipoUsuario)
VALUES			   ('admin@admin.com', 'admin', 1)
				  ,('jogador@jogador.com', 'jogador', 2);