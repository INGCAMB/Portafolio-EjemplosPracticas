-- Medina Beltran Carlos Alberto
-- Creación y uso de la base de datos
CREATE DATABASE E11;
USE E11;

-- Creación de la tabla
CREATE TABLE Empleado(
NoEmp INT,
Nombre VARCHAR(40),
-- Salario Bruto Mensual
SalarioBruto DECIMAL(8,2)
)

-- Altas de registros
INSERT INTO Empleado VALUES (1, 'Alberto Beltran', 50501.18);
INSERT INTO Empleado VALUES (2, 'Ofelia Beltran', 24522.22);
INSERT INTO Empleado VALUES (3, 'Felipe Lopez', 14216.54);

-- Creación de la función
CREATE FUNCTION dbo.CalcularISR(@Salario DECIMAL)
RETURNS DECIMAL
AS
BEGIN
	DECLARE @ISR DECIMAL(12,2);
	DECLARE @LimIn DECIMAL(12,2);
	DECLARE @Cuota DECIMAL(12,2);
	DECLARE @Pocentaje DECIMAL(12,2);
	
	SET @LimIn =
	CASE
		WHEN @Salario >= 0.01 AND @Salario <= 578.52 THEN 0.01
		WHEN @Salario > 578.52 AND @Salario <= 4910.18 THEN 578.52
		WHEN @Salario > 4910.18 AND @Salario <= 8629.20 THEN 4910.18
		WHEN @Salario > 8629.20 AND @Salario <= 10031.07 THEN 8629.20
		WHEN @Salario > 10031.07 AND @Salario <= 12009.94 THEN 10031.07
		WHEN @Salario > 12009.94 AND @Salario <= 24222.31 THEN 12009.94
		WHEN @Salario > 24222.31 AND @Salario <= 3817.69 THEN 24222.31
		WHEN @Salario > 3817.69 AND @Salario <= 72887.50 THEN 3817.69
		WHEN @Salario > 72887.50 AND @Salario <= 97183.33 THEN 72887.50
		WHEN @Salario > 97183.33 AND @Salario <= 291550.00 THEN 97183.33
		ELSE 291550.01
	END
	
	SET @Cuota =
	CASE
		WHEN @Salario >= 0.01 AND @Salario <= 578.52 THEN 0.00
		WHEN @Salario > 578.52 AND @Salario <= 4910.18 THEN 11.11
		WHEN @Salario > 4910.18 AND @Salario <= 8629.20 THEN 288.33
		WHEN @Salario > 8629.20 AND @Salario <= 10031.07 THEN 692.96
		WHEN @Salario > 10031.07 AND @Salario <= 12009.94 THEN 917.26
		WHEN @Salario > 12009.94 AND @Salario <= 24222.31 THEN 1271.87
		WHEN @Salario > 24222.31 AND @Salario <= 3817.69 THEN 3880.44
		WHEN @Salario > 3817.69 AND @Salario <= 72887.50 THEN 7162.74
		WHEN @Salario > 72887.50 AND @Salario <= 97183.33 THEN 17575.69
		WHEN @Salario > 97183.33 AND @Salario <= 291550.00 THEN 91435.02
		ELSE 91435.02
	END
	
	SET @Pocentaje =
	CASE
		WHEN @Salario >= 0.01 AND @Salario <= 578.52 THEN 1.92
		WHEN @Salario > 578.52 AND @Salario <= 4910.18 THEN 6.40
		WHEN @Salario > 4910.18 AND @Salario <= 8629.20 THEN 10.88
		WHEN @Salario > 8629.20 AND @Salario <= 10031.07 THEN 16.00
		WHEN @Salario > 10031.07 AND @Salario <= 12009.94 THEN 17.92
		WHEN @Salario > 12009.94 AND @Salario <= 24222.31 THEN 21.36
		WHEN @Salario > 24222.31 AND @Salario <= 3817.69 THEN 23.52
		WHEN @Salario > 3817.69 AND @Salario <= 72887.50 THEN 30.00
		WHEN @Salario > 72887.50 AND @Salario <= 97183.33 THEN 32.00
		WHEN @Salario > 97183.33 AND @Salario <= 291550.00 THEN 34.00
		ELSE 35.00
	END

	SET @ISR = ((@Salario - @LimIn) * (@Pocentaje / 100)) + @Cuota;

	RETURN @ISR
END

-- Uso de la función con una consulta
SELECT *, dbo.CalcularISR(SalarioBruto) AS [ISR], SalarioBruto - dbo.CalcularISR(SalarioBruto) AS [Salario Neto] FROM Empleado;
