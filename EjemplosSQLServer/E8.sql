-- Creación y uso de la base de datos
-- Medina Beltran Carlos Alberto
CREATE DATABASE DiferentesConsultas;
USE DiferentesConsultas;

-- Creación de tablas
CREATE TABLE Pedidos (
    Num_pedido INT,
    Clie INT,
    Producto VARCHAR(10),
    Cant INT,
    Importe INT
);

CREATE TABLE Clientes (
    Num_cliente INT,
    Empresa VARCHAR(20),
    Rep_clie INT,
    Limite_credito INT
);

CREATE TABLE Oficinas (
    Oficina INT,
    Ciudad VARCHAR(20),
    Region VARCHAR(10),
    Objetivo INT,
    Ventas INT
);

CREATE TABLE RepVentas (
    Nombre VARCHAR(20),
    Oficinas_rep INT,
    Cuota INT,
    Ventas INT
);

INSERT INTO Pedidos VALUES (112961, 2117, '2A44L', 7, 31500);
INSERT INTO Pedidos VALUES (113012, 2111, '41003', 35, 3745);
INSERT INTO Pedidos VALUES (112989, 2101, '114', 6, 1458);
INSERT INTO Pedidos VALUES (113051, 2118, 'XK47', 4, 1420);
INSERT INTO Pedidos VALUES (112968, 2102, '41004', 34, 3978);
INSERT INTO Pedidos VALUES (113036, 2107, '41002', 9, 22500);
INSERT INTO Pedidos VALUES (113045, 2112, '2A44R', 10, 45000);
INSERT INTO Pedidos VALUES (112963, 2103, '41004', 28, 3276);
INSERT INTO Pedidos VALUES (113013, 2118, '41003', 1, 652);
INSERT INTO Pedidos VALUES (113058, 2108, '112', 10, 1480);
INSERT INTO Pedidos VALUES (112997, 2124, '41003', 1, 652);
INSERT INTO Pedidos VALUES (112983, 2103, '41004', 6, 702);
INSERT INTO Pedidos VALUES (113024, 2114, 'XK47', 20, 7100);
INSERT INTO Pedidos VALUES (113062, 2124, '114', 10, 2430);
INSERT INTO Pedidos VALUES (112979, 2114, '4100Z', 6, 15000);
INSERT INTO Pedidos VALUES (113027, 2103, '41002', 54, 4104);
INSERT INTO Pedidos VALUES (113007, 2112, '773C', 3, 2925);
INSERT INTO Pedidos VALUES (113069, 2109, '775C', 22, 31350);
INSERT INTO Pedidos VALUES (113034, 2107, '2A45C', 8, 632);
INSERT INTO Pedidos VALUES (112992, 2118, '41002', 10, 760);
INSERT INTO Pedidos VALUES (112975, 2111, '2A44C', 6, 2100);
INSERT INTO Pedidos VALUES (113055, 2108, '4100X', 6, 150);
INSERT INTO Pedidos VALUES (113048, 2120, '779C', 2, 3750);
INSERT INTO Pedidos VALUES (112993, 2106, '2A45C', 24, 1896);
INSERT INTO Pedidos VALUES (113065, 2106, 'XK47', 6, 2130);
INSERT INTO Pedidos VALUES (113003, 2108, '779C', 3, 5625);
INSERT INTO Pedidos VALUES (113049, 2118, 'XK47', 2, 776);
INSERT INTO Pedidos VALUES (112987, 2103, '4100Y', 11, 27500);
INSERT INTO Pedidos VALUES (113057, 2111, '4100X', 24, 600);
INSERT INTO Pedidos VALUES (113042, 2113, '2A44R', 5, 22500);

INSERT INTO Clientes VALUES (2111, 'JCP Inc.', 103, 50000);
INSERT INTO Clientes VALUES (2102, 'First Corp.', 101, 65000);
INSERT INTO Clientes VALUES (2103, 'Acne Klg.', 105, 50000);
INSERT INTO Clientes VALUES (2123, 'Carter & Sons', 102, 40000);
INSERT INTO Clientes VALUES (2107, 'Ace International', 110, 35000);
INSERT INTO Clientes VALUES (2115, 'Saithgon Corp.', 101, 20000);
INSERT INTO Clientes VALUES (2101, 'Jones Mig.', 106, 65000);
INSERT INTO Clientes VALUES (2112, 'Zetacorp', 108, 50000);
INSERT INTO Clientes VALUES (2121, 'QMA Assoc.', 103, 45000);
INSERT INTO Clientes VALUES (2114, 'Orion Corp.', 102, 20000);
INSERT INTO Clientes VALUES (2124, 'Peter Brothers', 107, 40000);
INSERT INTO Clientes VALUES (2108, 'Holn & Landig', 109, 55000);
INSERT INTO Clientes VALUES (2117, 'J. P. Slnclair', 106, 35000);
INSERT INTO Clientes VALUES (2122, 'Three-Hay Lines', 105, 30000);
INSERT INTO Clientes VALUES (2120, 'Rico Enterprises', 102, 50000);
INSERT INTO Clientes VALUES (2106, 'Fred Lewis Corp.', 102, 65000);
INSERT INTO Clientes VALUES (2119, 'Soloaca Inc.', 109, 25000);
INSERT INTO Clientes VALUES (2118, 'Midwest Systems', 108, 60000);
INSERT INTO Clientes VALUES (2113, 'Ian & Schaidt', 104, 20000);
INSERT INTO Clientes VALUES (2109, 'Chen Associates', 107, 25000);
INSERT INTO Clientes VALUES (2105, 'AAA Investments', 101, 45000);

INSERT INTO Oficinas VALUES (22, 'Denver', 'Oeste', 300000, 786042);
INSERT INTO Oficinas VALUES (11, 'New Yotk', 'Este', 575000, 692637);
INSERT INTO Oficinas VALUES (12, 'Chicago', 'Este', 800000, 735042);
INSERT INTO Oficinas VALUES (13, 'Atlanta', 'Este', 350000, 367911);
INSERT INTO Oficinas VALUES (21, 'Los Angeles', 'Oeste', 725000, 835915);

INSERT INTO RepVentas VALUES ('Bill Adams', 13, 350000, 367911);
INSERT INTO RepVentas VALUES ('Mary Jones', 11, 300000, 392725);
INSERT INTO RepVentas VALUES ('Sue Smith', 21, 350000, 474050);
INSERT INTO RepVentas VALUES ('Sam Clark', 11, 275000, 299912);
INSERT INTO RepVentas VALUES ('Bob Smith', 12, 200000, 142594);
INSERT INTO RepVentas VALUES ('Dan Roberts', 12, 300000, 305673);
INSERT INTO RepVentas VALUES ('Tom Snyder', NULL, NULL, 75985);
INSERT INTO RepVentas VALUES ('Larry Fitch', 21, 350000, 361865);
INSERT INTO RepVentas VALUES ('Paul Cruz', 12, 275000, 286775);
INSERT INTO RepVentas VALUES ('Nancy Angelli', 22, 300000, 186042);

-- 1)
SELECT Objetivo, Ventas
FROM Oficinas;

-- 2)
SELECT Objetivo, Ventas
FROM Oficinas
WHERE Region = 'Oeste';

-- 3)
SELECT Objetivo, Ventas
FROM Oficinas
WHERE Region = 'Oeste' AND (Objetivo < Ventas)
ORDER BY Ciudad;

-- 4)
SELECT AVG(Objetivo) AS 'Objetivos promedio', AVG(Ventas) AS 'Ventas promedio'
FROM Oficinas
WHERE Region = 'Este';

-- 5)
SELECT Nombre, Oficinas_rep
FROM RepVentas;

-- 6)
SELECT AVG(Ventas) AS 'Ventas Promedio'
FROM RepVentas;

-- 7)
SELECT Nombre
FROM RepVentas
WHERE Ventas > 500000;

-- 8)
SELECT Nombre, Cuota -- No tienen dirección
FROM RepVentas;

-- 9)
SELECT /*Poblacion,*/ Region, Ventas -- No tienen población
FROM Oficinas;

-- 10)
SELECT Ciudad, Region, Ventas
FROM Oficinas;

-- 11)
SELECT Nombre, Ventas, Ventas * 1.03 AS 'Ventas con elevación de 3%'
FROM RepVentas;

-- 12)
SELECT *
FROM Oficinas;

-- 13)
SELECT *
FROM Oficinas
WHERE Ventas < Objetivo * 0.8;

-- 14)
SELECT *
FROM Pedidos
WHERE Importe BETWEEN 30000.00 AND 39999.99;

-- 15)
SELECT *
FROM RepVentas
WHERE NOT (Ventas * 0.8 <= Cuota AND Cuota <= Ventas * 1.2);

-- 16)
SELECT *
FROM RepVentas
WHERE Ventas < Cuota AND Ventas < 300000;

-- 17)
SELECT *
FROM Oficinas
ORDER BY Ventas DESC;

-- 18)
SELECT MIN(Cuota) AS 'Cuota mínima', MAX(Cuota) AS 'Cuota máxima'
FROM RepVentas;

-- 19)
SELECT COUNT(*) AS 'Vendedores que superaron la cuota'
FROM RepVentas
WHERE Ventas > Cuota;

-- 20)
SELECT COUNT(*) AS 'Pedidos superiores a $25,000'
FROM Pedidos
WHERE Importe > 25000;
