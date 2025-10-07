-- 1
CREATE DATABASE Evento;

USE Evento;

-- 2
EXEC sp_addtype texto, 'char(30)', null;

-- 3
EXEC sp_addtype numero, 'int', null;

-- 4
CREATE TABLE ParticipanteEvento (
noPartEven numero primary key,
noPart numero,
noEvent numero
);

-- 5
CREATE TABLE Participantes (
noPartic numero primary key,
Nombre varchar(50),
Direccion texto,
Teléfono varchar(15),
TipoParticipante texto,
AñoEvento numero
);

-- 6
CREATE TABLE Eventos (
IdEvento numero primary key,
nombreEvento texto,
fecha date,
hora time,
lugar texto,
tipo varchar(15),
);
