CREATE DATABASE Boleta;
USE Boleta;

CREATE TABLE Alumnos(
NoControl INT PRIMARY KEY,
Nombre VARCHAR(45)
);

CREATE TABLE Boletas(
Folio INT PRIMARY KEY,
FechaEmision DATETIME,
Semestre INT,
AlumnosNocontrol INT FOREIGN KEY REFERENCES Alumnos(Nocontrol)
);

CREATE TABLE Materias(
IdMateria INT PRIMARY KEY,
nombreMateria VARCHAR(45)
);

CREATE TABLE TipodeExamen(
IdTipoExamen INT PRIMARY KEY,
TipodeExamen VARCHAR(45)
);

CREATE TABLE MateriayBoletas(
ClaveMateria INT FOREIGN KEY REFERENCES Materias(IdMateria),
Folio_Boleta INT FOREIGN KEY REFERENCES Boletas(Folio),
PRIMARY KEY (ClaveMateria, Folio_Boleta),
Tipo_Examen INT FOREIGN KEY REFERENCES TipodeExamen(IdTipoExamen),
Calificacion DECIMAL(5,2)
);
