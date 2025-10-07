-- Creación y uso de la base de datos
CREATE DATABASE Empresa;
USE Empresa;

-- Creación de tablas
CREATE TABLE Empleado (
	NoEmpl INT IDENTITY,
	Nombre VARCHAR(40),
	RFC VARCHAR(13),
	Correo VARCHAR(40),
	NoDepto INT,
	Empresa VARCHAR(30),
	IdPuesto INT,
	Estado VARCHAR(15)
);

CREATE TABLE Depto (
	NoDepto INT IDENTITY,
	DescDepto VARCHAR(40)
);

CREATE TABLE Producto (
	IdPto INT IDENTITY,
	Descripcion VARCHAR(40),
	Tipo INT,
	FechaCreacionPto DATE,
	Estado VARCHAR(15)
);

CREATE TABLE Tipo (
	Tipo INT IDENTITY,
	DescTipo VARCHAR(40)
);

CREATE TABLE Puesto (
	IdPuesto INT IDENTITY,
	DescPuesto VARCHAR(40),
	Estado VARCHAR(15)
);

-- Alta de valores para las tablas Departamento y Tipo
INSERT INTO Depto VALUES ('Sistemas y computación');
INSERT INTO Depto VALUES ('Producción');
INSERT INTO Depto VALUES ('Ing. Industrial');

INSERT INTO Tipo VALUES ('Electrónicos');
INSERT INTO Tipo VALUES ('Blancos');
INSERT INTO Tipo VALUES ('Muebles');

----- Creación de llaves primarias ------
ALTER TABLE Empleado
ADD CONSTRAINT PK_NoEmpleado
PRIMARY KEY(NoEmpl);

ALTER TABLE Depto
ADD CONSTRAINT PK_NoDepto
PRIMARY KEY(NoDepto);

ALTER TABLE Producto
ADD CONSTRAINT PK_IdPto
PRIMARY KEY(IdPto);

ALTER TABLE Tipo
ADD CONSTRAINT PK_idTipo
PRIMARY KEY(Tipo);

ALTER TABLE Puesto
ADD CONSTRAINT PK_idPuesto
PRIMARY KEY(idPuesto);

------ Creación de llaves foráneas ------
-- Empleado llave foránea NoDepto
ALTER TABLE Empleado
ADD CONSTRAINT FK_NoDepto
FOREIGN KEY(NoDepto)
REFERENCES dbo.Depto(NoDepto);

-- Empleado llave foránea NoDepto
ALTER TABLE Empleado
ADD CONSTRAINT FK_IdPuesto
FOREIGN KEY(IdPuesto)
REFERENCES dbo.Puesto(IdPuesto);

-- Producto llave foránea Tipo
ALTER TABLE Producto
ADD CONSTRAINT FK_idTipo
FOREIGN KEY(Tipo)
REFERENCES dbo.Tipo(Tipo);

--------------- Creación de restricciones -------------------
-- Agregar CHECK en Producto para que solamente acepte los valores de la tabla Tipo
ALTER TABLE Producto
ADD CONSTRAINT CK_Tipo
CHECK (Tipo >= 1 AND Tipo <= 3);

-- Creación de valor Default para Empresa con valor 'IKE'
ALTER TABLE Empleado
ADD CONSTRAINT DF_Empresa
DEFAULT 'IKE'
FOR Empresa;

-- Creación de UNIQUE para le RFC
ALTER TABLE Empleado
ADD CONSTRAINT U_RFC
UNIQUE (RFC);

-- Creación de valor por defecto y asignación a múltiples tablas
CREATE DEFAULT Estado AS 'Activo';
EXEC sp_bindefault Estado, 'Empleado.Estado';
EXEC sp_bindefault Estado, 'Producto.Estado';
EXEC sp_bindefault Estado, 'Puesto.Estado';

-- Alta de registros a cada tabla con verificación de cumplimiento de las restricciones
INSERT INTO Puesto VALUES('Gerente', DEFAULT); -- Valor por defecto
INSERT INTO Puesto VALUES('Recursos humanos', DEFAULT); -- Valor por defecto
INSERT INTO Puesto VALUES('Producción', 'Inactivo');

INSERT INTO Empleado VALUES ('Alberto', 'AAER0007153F2', 'correito@gmail.com', 1, 'Empresita', 1, DEFAULT); -- Estado por defecto
INSERT INTO Empleado VALUES ('Pancho', 'PAOSNFIDHTYR', 'panfilo@gmail.com', 3, 'Empresita', 2, 'Inactivo');
INSERT INTO Empleado VALUES ('Raul', 'CASOASTASCVA', 'otrocorreito@gmail.com', 2, 'Empresita', 3, DEFAULT);
INSERT INTO Empleado VALUES ('Error1', 'CASOASTASCVA', 'otrocorreito@gmail.com', 2, 'Empresita', 3, DEFAULT); -- Al dar alta lanza error porque está repitiendo RFC

INSERT INTO Producto VALUES ('Tableta', 1, '2020-06-21', DEFAULT);
INSERT INTO Producto VALUES ('Tenis', 2, '2020-04-16', 'Inactivo');
INSERT INTO Producto VALUES ('Escritorio', 3, '2020-02-08', DEFAULT);
INSERT INTO Producto VALUES ('Computadora', 1, '2020-01-12', 'Inactivo');
INSERT INTO Producto VALUES ('Resma de hojas', 2, '2020-03-30', DEFAULT);
INSERT INTO Producto VALUES ('Cama', 3, '2020-03-27', DEFAULT);
INSERT INTO Producto VALUES ('Error1', 4, '2020-07-15', DEFAULT); -- Al dar alta lanza error porque el tipo de producto choca con la restricción

-- Consulta de registros en cada tabla
SELECT * FROM Empleado;
SELECT * FROM Depto;
SELECT * FROM Producto;
SELECT * FROM Tipo;
SELECT * FROM Puesto;
