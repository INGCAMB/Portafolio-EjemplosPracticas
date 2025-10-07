-- Creación de la base de datos
CREATE DATABASE PaseLista;

-- Uso de la base de datos
USE PaseLista;

-- Creación de la tabla Alumno
CREATE TABLE Alumno (
NoControl INT PRIMARY KEY,
Nombre VARCHAR(30),
Correo VARCHAR(20),
Carrera VARCHAR(20)
);

-- Creación de la tabla Profesor
CREATE TABLE Profesor (
IdProfe INT PRIMARY KEY,
Nombre VARCHAR(30),
Correo VARCHAR(20)
);

-- Creación de la tabla Grupo
CREATE TABLE Grupo (
Codigo VARCHAR(12) PRIMARY KEY,
IdMateria INT FOREIGN KEY REFERENCES Materia(IdMateria),
Horario VARCHAR(15),
IdProfe INT FOREIGN KEY REFERENCES Profesor(IdProfe)
);

-- Creación de la tabla Materia
CREATE TABLE Materia (
IdMateria INT PRIMARY KEY,
Nombre VARCHAR(20)
);

-- Creación de la tabla Asistencia
CREATE TABLE Asistencia (
IdAsis INT PRIMARY KEY,
Fecha DATE,
CodGrupo VARCHAR(12) FOREIGN KEY REFERENCES Grupo(Codigo)
);

-- Creación de la tabla relación de Alumno-Grupo
CREATE TABLE AlumGrupo (
NoControl INT FOREIGN KEY REFERENCES Alumno(NoControl),
CodGrupo VARCHAR(12) FOREIGN KEY REFERENCES Grupo(Codigo),
);

-- Creación de la tabla relación de Alumno-Asistencia
CREATE TABLE AlumAsist (
NoControl INT FOREIGN KEY REFERENCES Alumno(NoControl),
IdAsist INT FOREIGN KEY REFERENCES Asistencia(IdAsis),
Asistencia BIT
);

INSERT INTO Alumno (NoControl, Nombre, Correo, Carrera) VALUES (18212141, 'Raul A', 'correo', 'Sistemas');
INSERT INTO Alumno (NoControl, Nombre, Correo, Carrera) VALUES (12156485, 'Alberto', 'correo2', 'Sistemas');
INSERT INTO Alumno (NoControl, Nombre, Correo, Carrera) VALUES (18212216, 'Alan', 'correo3', 'TICS');

SELECT * FROM Asistencia;

INSERT INTO Materia (IdMateria, Nombre) VALUES (1, 'Bases de datos');
INSERT INTO Materia (IdMateria, Nombre) VALUES (2, 'Lenguajes interfaz');

INSERT INTO Profesor (IdProfe, Nombre, Correo) VALUES (1, 'Margarita', 'Correo1');
INSERT INTO Profesor (IdProfe, Nombre, Correo) VALUES (2, 'Jose', 'Correo2');
INSERT INTO Profesor (IdProfe, Nombre, Correo) VALUES (3, 'Armando', 'Correo3');

INSERT INTO Grupo (Codigo, IdMateria, Horario, IdProfe) VALUES ('1234asdf', 1, '13:00-14:00', 1);
INSERT INTO Grupo (Codigo, IdMateria, Horario, IdProfe) VALUES ('zxcv568', 2, '14:00-15:00', 2);

INSERT INTO Asistencia (IdAsis, Fecha, CodGrupo) VALUES (1, '2020-10-01', '1234asdf');
INSERT INTO Asistencia (IdAsis, Fecha, CodGrupo) VALUES (2, '2020-10-01', 'zxcv568');

INSERT INTO AlumGrupo (NoControl, CodGrupo) VALUES (18212141, '1234asdf');
INSERT INTO AlumGrupo (NoControl, CodGrupo) VALUES (12156485, '1234asdf');
INSERT INTO AlumGrupo (NoControl, CodGrupo) VALUES (18212216, '1234asdf');

INSERT INTO AlumAsist (NoControl, IdAsist, Asistencia) VALUES (18212216, 1, 1);
INSERT INTO AlumAsist (NoControl, IdAsist, Asistencia) VALUES (12156485, 1, 0);
INSERT INTO AlumAsist (NoControl, IdAsist, Asistencia) VALUES (18212216, 1, 1);

SELECT * FROM AlumAsist;
