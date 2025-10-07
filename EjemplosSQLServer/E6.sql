-- Creación y uso de base de datos
CREATE DATABASE Reglas;

USE Reglas;

-- Creación de tablas
CREATE TABLE Puestos (
	IdPuesto INT IDENTITY,
	Descripcion VARCHAR(40)
);

CREATE TABLE Proyectos (
	IdProyecto INT IDENTITY,
	Descripcion VARCHAR(40)
);

CREATE TABLE Empleados (
	IdEmpleado INT IDENTITY,
	Nombre VARCHAR(40),
	Correo VARCHAR(30),
	Telefono VARCHAR(15),
	Genero VARCHAR(1),
	idPuesto INT
);

CREATE TABLE Proy_Empleado (
	IdEmpleado INT,
	IdProyecto INT
);

-- REGLA PUESTOS
CREATE RULE puesto_regla
AS @relgaspuesto IN ('Sistemas', 'Administración')
GO
EXEC sp_bindrule puesto_regla, 'Puestos.Descripcion';

-- LLAVES PRIMARIAS Y SECUNDARIAS
ALTER TABLE Puestos
ADD CONSTRAINT PK_IdPuestos
PRIMARY KEY (IdPuesto);

ALTER TABLE Proyectos
ADD CONSTRAINT PK_IdProyectos
PRIMARY KEY (IdProyecto);

ALTER TABLE Empleados
ADD CONSTRAINT PK_IdEmpleados
PRIMARY KEY (IdEmpleado);

ALTER TABLE Empleados
ADD CONSTRAINT FK_IdPuestos
FOREIGN KEY (IdPuesto) REFERENCES Puestos(IdPuesto);

-- REGLA FORMATOTEL
CREATE RULE formatoTel
AS @formatotel LIKE ('664-___-__-__')
GO
EXEC sp_bindrule formatoTel, 'Empleados.Telefono';

-- Condiciones de Unicos para Empleados y Proyectos
ALTER TABLE Empleados
ADD CONSTRAINT U_Nombre
UNIQUE (Nombre);

ALTER TABLE Proyectos
ADD CONSTRAINT U_Descripcion
UNIQUE (Descripcion);

-- Creación de regla para género
CREATE RULE genero
AS @genero IN ('M', 'F')
GO
EXEC sp_bindrule genero, 'Empleados.Genero';

-- Creación de regla para correo
CREATE RULE formato_correo
AS @formatocorreo LIKE ('%@_____.com')
GO
EXEC sp_bindrule formato_correo, 'Empleados.Correo';

-- Pruebas de errores
INSERT INTO Puestos VALUES ('Sistemas');
INSERT INTO Puestos VALUES ('Administración');
INSERT INTO Puestos VALUES ('Gerente'); -- Lanza error por regla

INSERT INTO Proyectos VALUES ('Reparaci n de computadoras');
INSERT INTO Proyectos VALUES ('Pedidos');
INSERT INTO Proyectos VALUES ('Pedidos'); -- Error por repetici n

INSERT INTO Empleados VALUES ('Ra l Alvarez', 'correito@gmail.com', '664-371-74-79', 'M', 2);
INSERT INTO Empleados VALUES ('Lorena Salazar', 'otrocorreo@gmail.com', '664-123-45-67', 'F', 1);
INSERT INTO Empleados VALUES ('Ra l Alvarez', 'correito@gmail.com', '664-371-74-79', 'M', 1); -- Error por repetir nombre
INSERT INTO Empleados VALUES ('Alberto Medina', 'otromas@hotmail.mx', '664-765-43-21', 'M', 1); -- Error por correo
INSERT INTO Empleados VALUES ('Alberto Medina', 'otromas@gmail.com', '664-765-4321', 'M', 1); -- Error por tel fono
INSERT INTO Empleados VALUES ('Alberto Medina', 'otromas@gmail.com', '664-765-43-21', 'H', 1); -- Error por g nero
