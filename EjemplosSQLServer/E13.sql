-- Medina Beltran Carlos Alberto
-- 1) Creación de base de datos y tabla
CREATE DATABASE T22;
USE T22;

-- Crear tabla alumnos
CREATE TABLE Alumnos (
NoControl INT,
Nombre VARCHAR(50),
Carrera VARCHAR(50),
Calificacion DECIMAL(6,2),
Periodo INT
)

-- 2) Insertar datos de los alumnos
INSERT INTO Alumnos VALUES
(18212141, 'Ofelia Beltran Lugo', 'Ing. Sistemas Computacionales', 90, 2018),
(18212216, 'Carlos Alberto Medina Beltran', 'Ing. Sistemas Computacionales', 85, 2018),
(17215784, 'Francisco Soto Esquivel', 'Ing. Tics', 70, 2019),
(17645281, 'Felipe Lopez Beltran', 'Ing. Informática', 80, 2019),
(16235458, 'Alan Guemes Perez', 'Ing. Tics', 70, 2017),
(16854795, 'Ulises Torres Saldaña', 'Ing. Informática', 75, 2016)

-- 3) Procedimiento
CREATE PROCEDURE ReporteEstudiantes
AS
BEGIN
SELECT * FROM Alumnos WHERE Calificacion > (SELECT AVG(Calificacion) FROM Alumnos)
END

EXEC ReporteEstudiantes

-- 4) Procedimiento
CREATE PROCEDURE EstudiantesSistemas
AS
BEGIN
SELECT * FROM Alumnos WHERE Carrera = 'Ing. Sistemas Computacionales'
END

EXEC EstudiantesSistemas

-- 5) Procedimiento
CREATE PROCEDURE InsertarAlumno
 -- Parámetros
@id INT,
@nom VARCHAR(50),
@car VARCHAR(50),
@cal DECIMAL(6,2),
@per INT
AS
BEGIN
INSERT INTO Alumnos VALUES (@id, @nom, @car, @cal, @per)
END

EXEC InsertarAlumno 12345678, 'Fulanito de tal lugar', 'Ing. Tics', 80, 2019

SELECT * FROM Alumnos;

-- 6) Procedimiento
CREATE PROCEDURE DosAñosAntiguedad
AS
BEGIN
SELECT * FROM Alumnos WHERE YEAR(GETDATE()) - Periodo >= 2
END

EXEC DosAñosAntiguedad
