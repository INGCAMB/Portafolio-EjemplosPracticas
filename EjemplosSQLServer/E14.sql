-- Medina Beltran Carlos Alberto
-- Creación y uso de la base de datos
CREATE DATABASE E14;
USE E14;

-- Creación de tablas Alumnos y Bitacora
CREATE TABLE Alumnos (
NoControl INT PRIMARY KEY,
Nombre VARCHAR(50)
)

CREATE TABLE Bitacora (
Descripcion VARCHAR(30),
Fecha DATE
)

-- Trigger de INSERT
CREATE TRIGGER Insertar ON Alumnos
FOR INSERT
AS
BEGIN
INSERT INTO Bitacora VALUES ('Insercíón de datos', GETDATE())
END

-- Trigger de UPDATE
CREATE TRIGGER Modificar ON Alumnos
FOR UPDATE
AS
BEGIN
INSERT INTO Bitacora VALUES ('Modificación de datos', GETDATE())
END

-- Trigger de DELETE
CREATE TRIGGER Eliminar ON Alumnos
FOR DELETE
AS
BEGIN
INSERT INTO Bitacora VALUES ('Eliminación de datos', GETDATE())
END

-- Prueba de altas
INSERT INTO Alumnos VALUES (122, 'Ofelia Beltran Lugo');
INSERT INTO Alumnos VALUES (182, 'Carlos Alberto Medina Beltran');
INSERT INTO Alumnos VALUES (432, 'Felipe Lopez Beltran');

-- Prueba de modificaciones
UPDATE Alumnos SET Nombre='Esteban Roberto Ramirez' WHERE  NoControl=122;
UPDATE Alumnos SET Nombre='Sofía Nava Gonzalez' WHERE  NoControl=432;

-- Prueba de baja
DELETE FROM Alumnos WHERE NoControl=432;

-- Consulta de bitácora
SELECT * FROM Bitacora;
