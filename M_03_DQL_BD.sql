use M_InLock

select * from Usuarios

select * from Estudios

select * from Jogos

select J.*, E.*
from Jogos J
inner join Estudios E
on J.EstudioId = E.EstudioId

select E.*, J.*
from Estudios E
left join Jogos J
on J.EstudioId = E.EstudioId

select * from Usuarios where Email = 'admin@admin.com' and Senha = 'admin'

select * from Jogos where JogoId = 1

select * from Estudios where EstudioId = 1