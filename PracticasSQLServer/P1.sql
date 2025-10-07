-- Medina Beltran Carlos Alberto
CREATE DATABASE P1;
USE P1;

EXEC sp_addtype cadena, 'varchar(30)', null;
EXEC sp_addtype numero, 'int', null;

-- Creación de tablas
CREATE TABLE Empleados (
    IdEmpleado INT NOT NULL,
    apPaterno cadena,
    apMaterno cadena,
    Nombre VARCHAR(40),
    Direccion VARCHAR(40),
    Telefono VARCHAR(15),
    IdDepto numero
);

CREATE TABLE Departamento (
    IdDepto numero NOT NULL,
    Departamento VARCHAR(40)
);

-- Modificar - Constraint
-- Llaves primarias
ALTER TABLE Empleados 
ADD CONSTRAINT PK_Empleados
PRIMARY KEY(IdEmpleado);

ALTER TABLE Departamento
ADD CONSTRAINT PK_Departamento
PRIMARY KEY(IdDepto);

-- Llave foranea
ALTER TABLE Empleados
ADD CONSTRAINT FK_EmpleadosDepto
FOREIGN KEY (IdDepto) REFERENCES Departamento(IdDepto);

-- Añade Correo al empleado
ALTER TABLE Empleados
ADD CorreoElectrónico VARCHAR(40);

-- Añade Fecha al empleado
ALTER TABLE Empleados
ADD FechaNac DATE;

--Reglas
CREATE RULE RL_Nombres
AS @nombre IN ('Producción', 'Administración', 'Sistemas')
GO
EXEC sp_bindrule RL_Nombres, 'Departamento.Departamento';

CREATE RULE RL_FormatoTel
AS @tel LIKE ('[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]')
GO
EXEC sp_bindrule RL_FormatoTel, 'Empleados.Telefono';

-- Insertar
INSERT INTO Empleados VALUES (1, 'Beltran', 'Medina', 'Alberto', 'Calle primera', '664-455-11-00', 1, 'alberto@gmail.com', '2000-11-22');
INSERT INTO Empleados VALUES (2, 'Jimenez', 'Lugo', 'Ofelia', 'Calle segunda', '664-548-32-21', 2, 'ofelia@gmail.com', '2000-11-22');

INSERT INTO Departamento VALUES (1, 'Sistemas');
INSERT INTO Departamento VALUES (2, 'Administración');

-- Vistas - Join
CREATE VIEW V_EmplSis AS
SELECT e.IdEmpleado, apPaterno, apMaterno, Nombre, Direccion, Telefono, Departamento FROM Empleados AS e
INNER JOIN Departamento AS d
ON e.IdDepto = d.IdDepto;
SELECT * FROM V_EmplSis;

CREATE VIEW V_Deptos AS
SELECT d.IdDepto, Departamento, e.IdEmpleado, Nombre, apPaterno, apMaterno, Telefono, e.CorreoElectrónico FROM Departamento AS d
INNER JOIN Empleados AS e
ON e.IdDepto = d.IdDepto
WHERE Departamento = 'Producción';
SELECT * FROM V_Deptos;

CREATE VIEW V_NombresM AS
SELECT * FROM Empleados
WHERE Nombre LIKE ('M%');
SELECT * FROM V_NombresM;
