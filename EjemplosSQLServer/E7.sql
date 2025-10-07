-- Medina Beltran Carlos Alberto
-- Creación de tablas
CREATE DATABASE EjemploMasCompleto;
USE EjemploMasCompleto;

DROP TABLE Customer;
DROP TABLE Item;
DROP TABLE Orders;
DROP TABLE Supplier;
DROP TABLE Contain;
DROP TABLE Supplies;

CREATE TABLE Customer (		--Tabla Customer
	custId INT NOT NULL,
	firstName VARCHAR(15),
	lastName VARCHAR(25),
	areaCode INT,
	number INT,
	street VARCHAR(20),
	city VARCHAR(20),
	state VARCHAR(15),
	zip INT,
	creditLimit INT
);

CREATE TABLE Orders (		--Tabla Orders
	orderNo INT IDENTITY NOT NULL,
	date DATE,
	totalAmount INT,
	tax INT,
	street VARCHAR(20),
	city VARCHAR(20),
	state VARCHAR(15),
	zip INT,
	areaCode INT,
	number INT,
	custId INT,
	PRIMARY KEY (orderNo),
	FOREIGN KEY (custId) REFERENCES Customer(custId)
);

CREATE TABLE Item (		--Tabla Items
	itemNo INT IDENTITY NOT NULL,
	itemName VARCHAR(40),
	unitPrice INT,
	qtyOnHand INT,
	reorderPoint INT,
	PRIMARY KEY (itemNo)
);

CREATE TABLE Supplier (		--Tabla Supplier
	supplierNo INT IDENTITY NOT NULL,
	supName VARCHAR(40),
	countryCode INT,
	areaCode INT,
	number INT,
	street VARCHAR(20),
	city VARCHAR(20),
	state VARCHAR(15),
	zip INT,
	country VARCHAR(20),
	PRIMARY KEY (supplierNo)
);

CREATE TABLE Contain (		--Tabla relacion M-M de Order e Item
	 orderNo INT NOT NULL,
	 itemNo INT NOT NULL
);

CREATE TABLE Supplies (		--Tabla relacion M-M de Item y Supplier
	itemNo INT NOT NULL,
	supplierNo INT NOT NULL,
	unitCost DECIMAL(6,2)
);

---------------- RESTRICCIONES ------------------
-- 1) Creación de llaves compuestas y llaves foráneas con restricciones
ALTER TABLE Contain		-- Llave compuesta de tabla Contain
ADD CONSTRAINT PK_Contains
PRIMARY KEY(orderNo, itemNo);

ALTER TABLE Contain		-- Llaves foráneas de tabla Supplies
ADD CONSTRAINT FK_order
FOREIGN KEY (orderNo) REFERENCES Orders(orderNo)

ALTER TABLE Contain
ADD CONSTRAINT FK_item_con
FOREIGN KEY (itemNo) REFERENCES Item(itemNo)


ALTER TABLE Supplies	-- Llave compuesta de tabla Supplies
ADD CONSTRAINT PK_Supplies
PRIMARY KEY(itemNo, supplierNo);

ALTER TABLE Supplies		-- Llaves foráneas de tabla Supplies
ADD CONSTRAINT FK_item_sup
FOREIGN KEY (itemNo) REFERENCES Item(itemNo)

ALTER TABLE Supplies
ADD CONSTRAINT FK_supplier
FOREIGN KEY (supplierNo) REFERENCES Supplier(supplierNo)

-- 2) Restricción de límite de crédito entre 10,000 y 100,000
ALTER TABLE Customer
ADD CONSTRAINT CK_credit
CHECK (creditLimit >= 10000 AND creditLimit <= 100000);

-- 3) Restricción de nombre de Item único
ALTER TABLE Item
ADD CONSTRAINT U_item
UNIQUE (itemName);

-- 4) Restricción de crear clave primaria en Customer
ALTER TABLE Customer
ADD CONSTRAINT PK_Customer
PRIMARY KEY(custId);

-- 5) Restricción de valor por defecto reorderPoint
ALTER TABLE Item
ADD CONSTRAINT DF_minimo
DEFAULT 10
FOR reorderPoint;

-- 6) Restricción para revisar que los países sean específicos
ALTER TABLE Supplier
ADD CONSTRAINT CK_countries
CHECK (country IN ('México', 'USA', 'Japón', 'Francia', 'Italia'));

---------------- REGLAS ------------------
-- 1) Regla para atributos zip sean de 5 digitos
CREATE RULE RL_Zip
AS @zip >= 11111 AND @zip <= 99999;
GO
EXEC sp_bindrule RL_Zip, 'Customer.zip'; -- Se aplica la regla a las tablas
EXEC sp_bindrule RL_Zip, 'Orders.zip';
EXEC sp_bindrule RL_Zip, 'Supplier.zip';

-- 2) Regla unitPrice entre 1 y 9999
CREATE RULE RL_unitPrice
AS @price > 1 AND @price < 9999
GO
EXEC sp_bindrule RL_unitPrice, 'Item.unitPrice'; -- Se aplica la regla a la tabla

-- 3) Regla de id de 5 digitos
CREATE RULE RL_customerId
AS @id > 11111 AND @id < 99999
GO
EXEC sp_bindrule RL_customerId, 'Customer.custId'; -- Se aplica la regla a la tabla

-- 4) Regla area código de 3 dígitos
CREATE RULE RL_areaCode
AS @code > 111 AND @code < 999;
GO
EXEC sp_bindrule RL_areaCode, 'Customer.areaCode'; -- Se aplica la regla a las tablas
EXEC sp_bindrule RL_areaCode, 'Orders.areaCode';
EXEC sp_bindrule RL_areaCode, 'Supplier.areaCode';

-- 5) Regla de solamente valores alfabéticos
CREATE RULE RL_names
AS @name NOT LIKE '%[^a-z]%';
GO
EXEC sp_bindrule RL_names, 'Customer.firstName'; -- Se aplica la regla a las tablas
EXEC sp_bindrule RL_names, 'Customer.lastName';
EXEC sp_bindrule RL_names, 'Supplier.supName';

----------- COMPROBACIÓN --------------
-- Valores válidos
INSERT INTO Customer VALUES (12345, 'Raúl', 'Alvarez', 664, 3717479, 'Callecita', 'Tijuas', 'Baja California', 22245, 75000);
INSERT INTO Orders VALUES ('2020-10-18', 1, 16, 'Callecita', 'Tijuas', 'Baja California', 22245, 664, 3717479, 12345);
INSERT INTO Item VALUES ('Manzana', 8, 75, 25);
INSERT INTO Supplier VALUES ('Granjita', 52, 664, 1234567, 'Angeles', 'Tijuas', 'Baja California', 24456, 'México');
INSERT INTO Contain VALUES (1, 1);
INSERT INTO Supplies VALUES (1, 1, 10);

-- Restricciones
-- 2)
INSERT INTO Customer (custId, creditLimit) VALUES (55555, 5000);

-- 3)
INSERT INTO Item (itemName) VALUES ('Manzana');

-- 5)
INSERT INTO Item VALUES ('Pera', 7, 68, DEFAULT);
SELECT * FROM Item;

-- 6)
INSERT INTO Supplier (country) VALUES ('Rusia');

-- Reglas
-- 1)
INSERT INTO Customer (custId, zip) VALUES (54321, 1234);
INSERT INTO Orders (zip) VALUES (1234);
INSERT INTO Supplier (zip) VALUES (1234);

-- 2)
INSERT INTO Item (unitPrice) VALUES (10000);

-- 3)
INSERT INTO Customer (custId) VALUES (123456);

-- 4)
INSERT INTO Customer (custId, areaCode) VALUES (21367, 1234);
INSERT INTO Orders (areaCode) VALUES (1234);
INSERT INTO Supplier (areaCode) VALUES (1234);

-- 5)
INSERT INTO Customer (custId, firstName, lastName) VALUES (43882, 'R4ul', 'Alvarez');
INSERT INTO Customer (custId, firstName, lastName) VALUES (47482, 'Raul', 'Alvar3z');
INSERT INTO Supplier (SupName) VALUES ('S4msung');
