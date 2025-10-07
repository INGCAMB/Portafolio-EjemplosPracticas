--Crear Base de datos Encuesta
CREATE DATABASE Encuesta;

--Uso de la BD Encuesta
USE Encuesta;

-- Crear Tabla Encuesta
CREATE TABLE Encuesta
(
--Atriubuto con llave primaria
NoEncuesta INT PRIMARY KEY,
--Atributos con sus respectivos tipos de datos y tamaños de longitud
Fecha DATE,
Tipo VARCHAR(15),
Carrera VARCHAR(15),
Semestre INT
)

-- Crear Tabla Respuesta
CREATE TABLE Pregunta
(
--Atriubuto con llave primaria
NoPregunta INT PRIMARY KEY,
--Atributos con sus respectivos tipos de datos y tamaños de longitud
Pregunta VARCHAR(30),
Respuesta VARCHAR(30),
--Atributo con llave foranea de tipo entero referenciado a la tabla encuesta atributo de llave primaria
NoEncuesta INT FOREIGN KEY REFERENCES Encuesta(NoEncuesta)
)

-- Crear Tabla Encuesta-Pregunta
CREATE TABLE EncuestaPreg
(
--Atributo con llave foranea de tipo entero referenciado a la tabla encuesta atributo de llave primaria
NoEncuesta INT FOREIGN KEY REFERENCES Encuesta(NoEncuesta),
--Atributo con llave foranea de tipo entero referenciado a la tabla pregunta atributo de llave primaria
NoPregunta INT FOREIGN KEY REFERENCES Pregunta(NoPregunta)
)
