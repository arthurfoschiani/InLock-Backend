use M_InLock

insert into Usuarios (Email, Senha, Permissao)
values ('admin@admin.com', 'admin', 'ADMINISTRADOR'), ('cliente@cliente.com', 'cliente', 'COMUM')

insert into Estudios (NomeEstudio, PaisOrigem, DataCriacao, UsuarioId)
values ('Blizzard', 'EUA', '1991-02-08', 1), ('Rockstar Studios', 'EUA', '1998-12-01', 1), ('Square Enix', 'Japão', '2003-04-01', 1)

insert into Jogos (NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
values ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '2012-05-15', 99, 1),
	('Red Dead Redemption II', 'É um jogo eletrônico de ação-aventura western.', '2018-10-26', 120, 2)

insert into Jogos (NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
values	('GTA 5', 'Jogo estilo livre onde os personagens são foras da lei.', '2013-09-17', 99, 2),
		('Fifa 20', 'É um simulador de futebol.', '2019-09-24', 120, 2),
		('Kingdom Hearts III', 'Kingdom Hearts III é um jogo eletrônico do gênero RPG de ação.', '2019-01-25', 120, 3)