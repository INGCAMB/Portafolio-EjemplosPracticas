-- Medina Beltran Carlos Alberto
CREATE DATABASE P2;
USE P2;

-- Creación de tablas
CREATE TABLE Estudiante (
NoControl INT PRIMARY KEY,
Nombre VARCHAR(50),
Carrera VARCHAR(50),
Promedio DECIMAL(6,2)
)

CREATE TABLE ALTA (
Mensaje VARCHAR(20),
Fecha DATE
)

-- 1) Procedimiento
CREATE PROCEDURE AltaDeEstudiantes
@NC INT,
@Nom VARCHAR(50),
@Car VARCHAR (50),
@Prom DECIMAL(6,2)
AS
BEGIN 
INSERT INTO Estudiante VALUES (@NC, @Nom, @Car, @Prom)
END

EXEC AltaDeEstudiantes 11210621, 'Enrique Ramirez Gomez', 'ISC', 99
EXEC AltaDeEstudiantes 12210123, 'Ruben A. Ortega Ramos', 'TIC', 89

-- 2) Trigger
CREATE TRIGGER Insertar ON Estudiante
FOR INSERT
AS
BEGIN 
INSERT INTO ALTA VALUES ('ALTA', GETDATE())
END

EXEC AltaDeEstudiantes 12345678, 'Alberto Pruebas', 'INF', 80

SELECT * FROM ALTA;

-- 3) Función
CREATE FUNCTION dbo.NombreMes(@Mes INT)
RETURNS VARCHAR(15)
AS
BEGIN
DECLARE @Resultado VARCHAR(20);
SET @Resultado =
CASE
    WHEN @Mes = 1 THEN 'Enero'
    WHEN @Mes = 2 THEN 'Febrero'
    WHEN @Mes = 3 THEN 'Marzo'
    WHEN @Mes = 4 THEN 'Abril'
    WHEN @Mes = 5 THEN 'Mayo'
    WHEN @Mes = 6 THEN 'Junio'
    WHEN @Mes = 7 THEN 'Julio'
    WHEN @Mes = 8 THEN 'Agosto'
    WHEN @Mes = 9 THEN 'Septiembre'
    WHEN @Mes = 10 THEN 'Octubre'
    WHEN @Mes = 11 THEN 'Noviembre'
ELSE 'Diciembre'
END
RETURN @Resultado
END

SELECT dbo.NombreMes(3) AS [Nombre Mes]
