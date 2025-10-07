-- Medina Beltran Carlos Alberto
-- Creación y uso de la base de datos
CREATE DATABASE E10;
USE E10;

-- Creación de tablas
-- Para el problema 1
CREATE TABLE Empleado ( 
NoEmp INT,
Nombre VARCHAR(50),
SueldoxHora DECIMAL(6,2),
HorasTrab INT
);

-- Para el problema 2 y 3
CREATE TABLE Estudiante ( 
NoControl INT,
Nombre VARCHAR(50),
Carrera VARCHAR(30),
CreditosCursados INT,
PromExamenes DECIMAL(4,2),
PromTrabajos DECIMAL(4,2),
PromParticipaciones DECIMAL(4,2)
);

-- Alta de registros a las tablas
INSERT INTO Empleado VALUES (1, 'Francisco Esquivel Soto', 145.19, 40);
INSERT INTO Empleado VALUES (2, 'Maria Guadalupe Rodriguez', 157.28, 43);
INSERT INTO Empleado VALUES (3, 'Carlos Medina Rojas', 132.64, 41);

INSERT INTO Estudiante VALUES (18212216, 'Alberto Medina Beltran', 'Sistemas computacionales', 200, 95, 65, 70);
INSERT INTO Estudiante VALUES (18212321, 'Ofelia Beltran Lugo', 'Informática', 138, 80, 58, 75);
INSERT INTO Estudiante VALUES (18245125, 'Karina Ruvalcaba', 'TICs', 90, 69, 46, 74);

-- Creación de funciones
-- Problema 1
CREATE FUNCTION dbo.CalcularSueldo (@SuelxH DECIMAL, @Horas INT) 
RETURNS DECIMAL
AS
BEGIN
DECLARE @SueldoBruto DECIMAL;
SET @SueldoBruto = @SuelxH * @Horas;
RETURN @SueldoBruto
END

-- Problema 2
CREATE FUNCTION dbo.EtapaCursante (@Creditos INT) 
RETURNS VARCHAR(11)
AS
BEGIN
DECLARE @Etapa VARCHAR(11);
SET @Etapa =
CASE
	WHEN @Creditos < 90 THEN 'Básica'
	WHEN @Creditos >= 90 AND @Creditos < 200 THEN 'Disciplinaria'
	WHEN @Creditos >= 200 AND @Creditos <= 274 THEN 'Terminal'
ELSE 'N/A'
END
RETURN @Etapa
END

-- Problema 3
CREATE FUNCTION dbo.PromGeneral (@Examenes DECIMAL, @Trabajos DECIMAL, @Participaciones DECIMAL) 
RETURNS VARCHAR(20)
AS
BEGIN
DECLARE @Promedio DECIMAL;
DECLARE @Resultado VARCHAR(20);
SET @Promedio = @Examenes * 0.6 + @Trabajos * 0.3 + @Participaciones * 0.1;
SET @Resultado =
CASE
	WHEN @Promedio > 90 AND @Promedio <= 100 THEN 'Excelente'
	WHEN @Promedio > 80 AND @Promedio <= 90 THEN 'Muy bueno'
	WHEN @Promedio > 70 AND @Promedio <= 80 THEN 'Bueno'
	WHEN @Promedio > 60 AND @Promedio <= 70 THEN 'Malo'
	WHEN @Promedio <= 60 THEN 'Debe estudiar más'
ELSE 'N/A'
END
RETURN @Resultado
END

-- Pruebas de funciones con consultas
-- Problema 1
SELECT NoEmp, Nombre, SueldoxHora, HorasTrab, dbo.CalcularSueldo(SueldoxHora, HorasTrab) AS [Sueldo bruto] FROM Empleado; 

-- Problema 2
SELECT NoControl, Nombre, Carrera, CreditosCursados, dbo.EtapaCursante(CreditosCursados) AS [Etapa actual] FROM Estudiante;

-- Problema 3
SELECT NoControl, Nombre, Carrera, PromExamenes, PromTrabajos, PromParticipaciones, 
dbo.PromGeneral(PromExamenes, PromTrabajos, PromParticipaciones) AS [Promedio general] FROM Estudiante; 
