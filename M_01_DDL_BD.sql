create database M_InLock
use M_InLock

create table Usuarios(
	UsuarioId int primary key identity,
	Email varchar (255) not null unique,
	Senha varchar (255) not null,
	Permissao varchar (255) not null
);

create table Estudios(
	EstudioId int primary key identity,
	NomeEstudio varchar (255) not null unique,
	PaisOrigem varchar (255) not null,
	DataCriacao date,
	UsuarioId int foreign key references Usuarios(UsuarioId)
);

create table Jogos(
	JogoId int primary key identity,
	NomeJogo varchar (255) not null unique,
	Descricao text not null,
	DataLancamento date,
	Valor money,
	EstudioId int foreign key references Estudios (EstudioId)
);