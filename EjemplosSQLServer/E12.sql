-- Medina Beltran Carlos Alberto
-- Creación y uso de la base de datos
CREATE DATABASE T21;
USE T21;

-- Creación de la tabla
CREATE TABLE Vendedor (
id INT,
Nombre VARCHAR(50),
Fecha DATE,
Poliza DECIMAL(10,2)
);

-- Alta de registros
INSERT INTO Vendedor VALUES
(1, 'Ofelia Beltran Lugo', GETDATE(), 4500),
(2, 'Carlos Alberto Medina Beltran', '2020-04-17', 4360),
(3, 'Felipe Lopez Beltran', '2020-07-16', 2650);

-- Creación de función
CREATE FUNCTION dbo.CalculaBono(@Poliza DECIMAL(10, 2), @Fecha DATE)
RETURNS DECIMAL(10, 2)
BEGIN
	-- Monto de bono total
	DECLARE @Bono DECIMAL(10, 2)
	-- Porcentaje de bono
	DECLARE @Por DECIMAL(3, 2) 
	-- Calcula el porcentaje de la comisión
	SET @Por= 
	CASE
		WHEN @Poliza < 3000 THEN 0
		WHEN @Poliza >= 3000 AND @Poliza <= 4000 THEN 0.1
		WHEN @Poliza > 4000 AND @Poliza <= 5000 THEN 0.15
		ELSE 0.2
	END
	-- Calcula el bono
	SET @Bono = @Poliza * @Por 
	-- Compara si la venta fue hecha en abril (mes número 4)
	IF (MONTH(@Fecha) = 4) 
	-- Si fue hecha en abril entonces da bono extra
		SET @Bono = @Bono + 1000 
	-- Regresa el bono
	RETURN @Bono 
END

-- Comprobación de la función
SELECT *, dbo.CalculaBono(Poliza, Fecha) FROM Vendedor;
