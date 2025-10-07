-- Medina Beltran Carlos Alberto
-- Creación y uso de la base de datos
CREATE DATABASE T25;
USE T25;

-- Creación de tablas
CREATE TABLE Productos (
Id INT PRIMARY KEY,
Descripcion VARCHAR(50),
Precio MONEY,
Tipo VARCHAR(50) DEFAULT 'Aparatos de comunicación'
)

CREATE RULE RL_Tipo AS
@Tipo IN ('Conectividad', 'Dispositivo de entrada',
	'Dispositivo de salida', 'Aparatos de comunicación');
EXEC sp_bindrule 'RL_Tipo', 'Productos.Tipo';

CREATE TABLE Vendedor (
Id INT PRIMARY KEY,
Nombre VARCHAR(50),
Correo VARCHAR(50),
Telefono VARCHAR(20),
CONSTRAINT CH_Correo CHECK (Correo LIKE '%@%'),
CONSTRAINT CH_Telef CHECK (Telefono LIKE '664%' OR Telefono LIKE '665%' OR Telefono LIKE '686%')
)

CREATE TABLE Registro (
Id INT IDENTITY(1,1),
IdVen INT,
IdProd INT,
Fecha DATE
)

-- a)
CREATE PROCEDURE VentasMesPasado
AS
BEGIN
SELECT COUNT(*) AS Monto FROM Registro WHERE MONTH(Fecha) = MONTH(GETDATE()) - 1;
END

-- Creación de registros para la condición
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (1, 5, '2020-11-15')
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (2, 3, '2020-11-22')
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (1, 5, '2020-11-28')

-- Ejecución
EXEC VentasMesPasado

-- b)
-- Alta de productos
CREATE PROCEDURE AltaProducto
@Id INT,
@Des VARCHAR(50),
@Pre MONEY,
@Tipo VARCHAR(50)
AS
BEGIN
INSERT INTO Productos VALUES (@Id, @Des, @Pre, @Tipo)
END

EXEC AltaProducto 1, 'Router', 400, 'Conectividad'
EXEC AltaProducto 2, 'Mouse', 250, 'Dispositivo de entrada'
EXEC AltaProducto 3, 'Monitor', 2500, 'Dispositivo de salida'
EXEC AltaProducto 4, 'Teléfono', 4500, 'Aparatos de comunicación'
EXEC AltaProducto 5, 'Laptop', 8000, 'Aparatos de comunicación'

-- Alta de Vendedores
CREATE PROCEDURE AltaVendedor
@Id INT,
@Nom VARCHAR(50),
@Cor VARCHAR(50),
@Tel VARCHAR(50)
AS
BEGIN
INSERT INTO Vendedor VALUES (@Id, @Nom, @Cor, @Tel)
END

EXEC AltaVendedor 1, 'Ofelia Beltran Lugo', 'correoofelia@email.com', '6643717479'
EXEC AltaVendedor 2, 'Carlos Alberto Medina Beltran', 'correito@carlitos.com', '6651234567'
EXEC AltaVendedor 3, 'Felipe Lopez Beltran', 'Felipe@domeo.com', '6861234567'

-- Alta de Registro
CREATE PROCEDURE AltaRegistro
@IdVen INT,
@IdProd INT
AS
BEGIN
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (@IdVen, @IdProd, GETDATE())
END

EXEC AltaRegistro 1, 1
EXEC AltaRegistro 1, 2
EXEC AltaRegistro 2, 2
EXEC AltaRegistro 2, 3
EXEC AltaRegistro 3, 3
EXEC AltaRegistro 3, 4
EXEC AltaRegistro 3, 5

-- c)
CREATE PROCEDURE VentasMarzo
AS
BEGIN
SELECT Nombre, SUM(Precio) AS Ventas FROM Vendedor AS v
LEFT JOIN Registro AS r ON v.Id = r.IdVen
FULL JOIN Productos AS p ON r.IdProd = p.Id
WHERE MONTH(Fecha) = 3
GROUP BY Nombre
END

-- Creación de registros para la condición
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (1, 5, '2020-3-15')
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (2, 3, '2020-3-22')
INSERT INTO Registro (IdVen, IdProd, Fecha) VALUES (1, 5, '2020-3-28')

-- Ejecución
EXEC VentasMarzo

-- d)
CREATE VIEW V_InfoVenta AS
SELECT r.Id, Fecha, Descripcion, Precio, Tipo
FROM Registro AS r
FULL JOIN Productos AS p ON r.IdProd = p.Id

SELECT * FROM V_InfoVenta;

-- e)
CREATE PROCEDURE VentasTipo
AS
BEGIN
SELECT Tipo, SUM(Precio) FROM Productos AS p
LEFT JOIN Registro AS r ON p.Id = r.IdProd
GROUP BY Tipo
END

EXEC VentasTipo
