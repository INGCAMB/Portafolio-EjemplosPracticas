-- Creación y uso de la base de datos
CREATE DATABASE E9;
USE E9; -- La base de datos es la misma que la dek ejemplo 7

SELECT * FROM Customer;
SELECT * FROM Item;
SELECT * FROM Orders;
SELECT * FROM Supplier;
SELECT * FROM Contain;
SELECT * FROM Supplies;

INSERT INTO Customer VALUES (14586, 'Raul', 'Alvarez', 664, 3717479, 'Calle primera', 'Tijuana', 'Baja California', 22540, 25000);
INSERT INTO Customer VALUES (78459, 'Alberto', 'Beltran', 664, 1245879, 'Calle segunda', 'Tijuana', 'Baja California', 27480, 45000);
INSERT INTO Customer VALUES (45628, 'Héctor', 'Jiménez', 664, 4568219, 'Calle tercera', 'Tijuana', 'Baja California', 22540, 34800);

INSERT INTO Item VALUES ('Ketchup', 60, 220, 75);
INSERT INTO Item VALUES ('Computadora', 8000, 56, 20);
INSERT INTO Item VALUES ('Escritorio', 1500, 70, 15);

INSERT INTO Orders VALUES ('2020-10-15', 2, 16, 'Calle primera', 'Tijuas', 'Baja California', 22540, 664, 3717479, 14586);
INSERT INTO Orders VALUES ('2020-10-16', 2, 16, 'Calle segunda', 'Tijuas', 'Baja California', 27480, 664, 1245879, 78459);
INSERT INTO Orders VALUES ('2020-10-18', 2, 16, 'Calle tercera', 'Tijuas', 'Baja California', 22540, 664, 4568219, 45628);

INSERT INTO Supplier VALUES ('Costeña', 52, 664, 3152484, 'Angeles', 'Tijuas', 'Baja California', 24456, 'México');
INSERT INTO Supplier VALUES ('Asus', 1, 664, 4851236, 'Calle gringa', 'Los Angeles', 'California', 58476, 'USA');
INSERT INTO Supplier VALUES ('HomeDepot', 1, 664, 3152484, 'Robles', 'Tijuas', 'Baja California', 24685, 'México');

INSERT INTO Contain VALUES (1, 1);
INSERT INTO Contain VALUES (1, 3);
INSERT INTO Contain VALUES (2, 1);
INSERT INTO Contain VALUES (2, 2);
INSERT INTO Contain VALUES (3, 2);
INSERT INTO Contain VALUES (3, 3);

INSERT INTO Supplies VALUES (1, 1, 40);
INSERT INTO Supplies VALUES (2, 2, 5600);
INSERT INTO Supplies VALUES (3, 3, 1200);

-- 1)
CREATE VIEW V_Prob1 AS
SELECT c.custId, firstName, lastName, c.areaCode, c.number, c.city, c.state, creditLimit FROM Customer AS c
INNER JOIN Orders
ON c.custId = Orders.custId;

SELECT * FROM V_Prob1;

-- 2)
CREATE VIEW V_Prob2 AS
SELECT i.itemNo, itemName, unitPrice, qtyOnHand, reorderPoint FROM Item AS i
INNER JOIN Contain
ON i.itemNo = Contain.itemNo
INNER JOIN Orders
ON Contain.orderNo = Orders.orderNo;

SELECT * FROM V_Prob2;

-- 3)
CREATE VIEW V_Prob3 AS
SELECT s.supplierNo, supName, city, country, itemName, unitPrice, qtyOnHand FROM Supplier AS s
INNER JOIN Supplies
ON s.supplierNo = Supplies.supplierNo
INNER JOIN Item
ON Supplies.itemNo = Item.itemNo;

SELECT * FROM V_Prob3;

-- 4)
CREATE VIEW V_Prob4 AS
SELECT i.itemNo, itemName, unitPrice, o.orderNo, date, city, state FROM Item AS i
FULL OUTER JOIN Contain
ON i.itemNo = Contain.itemNo
FULL OUTER JOIN Orders AS o
ON Contain.orderNo = o.orderNo;

SELECT * FROM V_Prob4;

-- 5)
CREATE VIEW V_Prob5 AS
SELECT sur.supplierNo, supName, areaCode, number, city, state, country, itemNo, unitCost FROM Supplier AS sur
LEFT OUTER JOIN Supplies AS sus
ON sur.supplierNo = sus.supplierNo;

SELECT * FROM V_Prob5;

-- 6)
CREATE VIEW V_Prob6 AS
SELECT orderNo, tax, date, c.custId, firstName, c.street, c.city, creditLimit FROM Customer AS c
INNER JOIN Orders AS o
ON c.custId = o.custId;

SELECT * FROM V_Prob6;

-- 7)
CREATE VIEW V_Prob7 AS
SELECT * FROM Customer
WHERE (
	SELECT SUM(unitPrice) FROM Customer AS c
	INNER JOIN Orders AS o
	ON c.custId = o.custId
	INNER JOIN Contain AS con
	ON o.orderNo = con.orderNo
	INNER JOIN Item AS i
	ON con.itemNo = i.itemNo
) > 10000;

SELECT * FROM V_Prob7;

-- 8)
CREATE VIEW V_Prob8 AS
SELECT i.itemNo, itemName, unitPrice, qtyOnHand, reorderPoint FROM Item AS i
INNER JOIN Contain AS con
ON i.itemNo = con.itemNo
INNER JOIN Orders AS o
ON con.orderNo = o.orderNo
INNER JOIN Customer AS c
ON o.custId = c.custId
WHERE firstName='Héctor' AND lastName='Jiménez';

SELECT * FROM V_Prob6;

-- 9)
CREATE VIEW V_Prob9 AS
SELECT * FROM Item
WHERE unitPrice > (SELECT AVG(unitPrice) FROM Item);

SELECT * FROM V_Prob6;

-- 10)
CREATE VIEW V_Prob10 AS
SELECT * FROM Item
WHERE itemName LIKE '%jet%'

SELECT * FROM V_Prob6;
