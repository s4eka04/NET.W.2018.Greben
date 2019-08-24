CREATE DATABASE DbTest1;

USE Dbtest1;

CREATE TABLE CITIS
(
	ID INT NOT  NULL PRIMARY KEY  auto_increment,
	City VARCHAR(20) NOT NULL UNIQUE,
    CountryID INT NOT NULL    
);

CREATE TABLE Customer
(
	CustomerID INT NOT NULL auto_increment,
	CompanyName VARCHAR(50) NOT NULL,
    CityID INT  NOT NULL,
    PRIMARY KEY(CustomerID),
    FOREIGN KEY(CityID) REFERENCES CITIS(ID)
);



INSERT INTO CITIS(City, Country) VALUES
("Berlin", "Germany"), ("Moskow", "Russia"),
 ("London", "England"), ("Madrid", "Spain"),
 ("Brussels", "Belgium");

INSERT INTO CITIS(City, Country) VALUES
("Paris", "France");

INSERT INTO CITIS(City, Country) VALUES
("Stockholm", "Sweden"), ("Oslo", "Norway"),
 ("Copenhagen", "Denmark"), ("malmo", "Sweden"),
 ("Aarhus", "Denmark");
 
 INSERT INTO CITIS(City, Country) VALUES
 ("Liverpool", "ENgland"),
 ("Manchester", "England"), ("Toronto", "Canada"),
 ("Ottawa", "Canada");

INSERT INTO Customer(CompanyName, CityID) VALUES
("Audi", 1), ("BMW", 4), ("Apple", 3), ("Samsung", 5), ("MAZ", 2), ("Disnay", 6);

INSERT INTO Customer(CompanyName, CityID) VALUES
("ShwedenCompany", 12), ("MyCompany", 14), ("OurComp", 13), ("Nuts", 12), ("Wood", 15), ("Dis", 16);

INSERT INTO Customer(CompanyName, CityID) VALUES
("Company1", 12), ("MyCompany2", 12), ("OurComp1", 13), ("Nuts1", 12), ("Wood1", 13), ("Dis1", 13);

INSERT INTO Customer(CompanyName, CityID) VALUES
("Company2", 12), ("MyCompany3", 12), ("OurComp3", 13), ("Nuts2", 12), ("Wood11", 13), ("Dis12", 13);
INSERT INTO Customer(CompanyName, CityID) VALUES
("Company2", 23), ("MyCompany3", 24), ("OurComp3", 25), ("Nuts2", 3), ("Wood11", 23), ("Dis12", 24);



-- FIRST TASK
SELECT CustomerID, CompanyName FROM Customer
ORDER BY CustomerID;


CREATE TABLE Employee
(
	EmployeeID INT NOT NULL PRIMARY KEY auto_increment,
    HiringTime DATE NOT NULL
    
);

INSERT INTO Employee(HiringTime) VALUES
(DATE('1999-4-6')),
(DATE('2010-10-1')),
(DATE('2001-4-5')),
(DATE('2010-4-9'));
-- SECOND TASK
SELECT EmployeeID FROM Employee
ORDER BY HiringTime DESC
LIMIT 1;
-- SECOND TASK
SELECT EmployeeID FROM Employee
WHERE HiringTime = ( SELECT MAX(HiringTime) FROM Employee);

-- THIRD TASK
SELECT DISTINCT Country FROM  Customer
ORDER BY Country;

-- 4th TASK
SELECT Cu.CompanyName  FROM Customer AS Cu JOIN CITIS AS Cy ON Cu.CityID = Cy.ID
WHERE Cy.City IN ("Berlin", "London", "Madrid", "Brussels", "Paris")
ORDER BY Cu.CompanyName;


CREATE TABLE Orders
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    RequiredDate DATE NOT NULL,
    CustomerID INT NOT NULL,
    Freight INT NULL,
    Price DECIMAL NOT NULL,
    Discount DECIMAL NULL,
    CityID INT NOT NULL,
    FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID)
);

INSERT INTO Orders(RequiredDate, CustomerID, Freight, Price, Discount, CityID) VALUES
(Date('1999-1-1'), 12, 120, 200,12, 1),
(Date('2000-2-15'), 1, 200, 160,10,4),
(Date('1995-2-12'), 16, 400, 400, 5, 5),
(Date('1999-10-1'), 5, 300, 210, 13, 4),
(Date('2000-5-6'), 23, 250, 140, 12, 5),
(Date('2001-4-12'), 26, 320, 120, 40, 5),
(Date('1999-8-1'), 9, 30, 110, 11, 5),
(Date('2001-6-2'), 27, 250, 230, 19, 5);

INSERT INTO Orders(RequiredDate, CustomerID, Freight) VALUES
(DATE('1999-10-10'), 1, 159),
(DATE('1999-12-8'), 24, 200),
(DATE('1999-11-2'), 25, 10),
(DATE('2000-12-3'), 4, 100),
(DATE('1999-10-10'), 3, 15),
(DATE('1929-2-18'), 24, 22),
(DATE('2019-2-2'), 3, 10),
(DATE('2010-11-3'), 5, 120),
(DATE('1999-1-1'), 25, 15);  

INSERT INTO Orders(RequiredDate, CustomerID, Freight) VALUES
(DATE('2009-1-13'), 31, 199),
(DATE('1999-2-8'), 36, 210),
(DATE('1989-10-3'), 35, 101);

INSERT INTO Orders(RequiredDate, CustomerID, Freight) VALUES
(DATE('2009-1-13'), 3, 109),
(DATE('1999-2-8'), 36, 110),
(DATE('1989-10-3'), 3, 250);
 

-- 5th TASK
SELECT C.CompanyName FROM Customer AS C JOIN Orders AS O
ON C.CustomerID = O.CustomerID
WHERE O.RequiredDate >= Date('1999-10-1') AND O.RequiredDate <= Date('1999-10-30');

CREATE TABLE ContactPersons 
(
	ID INT NOT  NULL PRIMARY KEY auto_increment,
    NamePerson VARCHAR(20) NOT NULL,
    Phone VARCHAR(12) NULL,
    Email VARCHAR(20) NULL,
    CustomerID INT NOT NULL,
    FOREIGN KEY(CustomerID) REFERENCES Customer(CustomerID)
);

INSERT INTO ContactPersons(NamePerson, Phone, Email, CustomerID) VALUES
('Egor', '1712134771', '171341250', 2),
('Vlad', '17109090', '171423450',1);

INSERT INTO ContactPersons(NamePerson, Phone, Email, CustomerID) VALUES
('Valet', '1712134771', '17134125076', 2),
('Dama', '1710909098', '171423450',1);

-- 6th TASK
SELECT NamePerson FROM ContactPersons 
Where Phone LIKE '171%77%'
AND
Email LIKE '171%50';

-- 7th TASK
SELECT C.City, COUNT(*) AS CustomerCount FROM CITIS AS C JOIN Customer AS Cu
ON C.ID = Cu.CityID
WHERE C.Country IN ('Sweden', 'Norway', 'Denmark')
GROUP BY(C.City);

-- 8th TASK
SELECT C.Country, COUNT(*) As CustomerCount FROM CITIS AS C JOIN Customer AS CU
ON C.ID = Cu.CityID
WHERE C.Country IN ('Sweden', 'Norway', 'Denmark')
GROUP BY(C.Country)
HAVING COUNT(*) >= 10
ORDER BY CustomerCount;


-- 9th TASK
SELECT C.CustomerID , ROUND(AVG(O.Freight)) AS FreightAVG FROM Customer AS C JOIN Orders AS O
ON C.CustomerID = O.CustomerID
JOIN CITIS AS Ci
ON C.CityID = Ci.ID
WHERE Ci.Country IN("Canada", "England")
GROUP BY(Ci.City)
HAVING FreightAVG BETWEEN 10 AND 100
 ORDER BY FreightAVG;

-- 10th TASk
SELECT EmployeeID  FROM Employee
HAVING HiringTime > (SELECT MIN(HiringTime) FROM Employee)
ORDER BY HiringTime
LIMIT 2;

-- 11th TASK 
SELECT *
FROM Employee
ORDER BY HiringTime	
OFFSET 1 ROWS
FETCH NEXT 1 ROWS ONLY;

-- 12th Task
SELECT C.CompanyName, SUM(O.Freight) AS FreightSUM FROM Customer AS C JOIN Orders AS O
ON C.CustomerID = O.CustomerID
JOIN CITIS AS Ci
ON C.CityID = Ci.ID
WHERE O.Freight > (SELECT AVG(O.Freight) FROM Orders AS O)
AND O.RequiredDate BETWEEN DATE('1996-7-15') AND DATE('1996-7-31')
GROUP BY(C.CompanyName)
ORDER BY FreightSUM;

CREATE TABLE Countris
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    NameCountry VARCHAR(50) NOT NULL,
    MainlandID INT NOT NULL 
);

CREATE TABLE Mainlands
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Nameland VARCHAR(50)
);

INSERT INTO Mainlands(Nameland) VALUES
('Eurasia'), ('South America'), ('North America'), ('Africa'), ('Australia');

INSERT INTO Countris(NameCountry, MainlandID) VALUES
('Russia', 1), ('France', 1),
('England', 1), ('Brazil', 2),
('Argentina', 2), ('USA', 3),
('Canada', 3), ('Congo', 4),
('Egypt', 4), ('Australia', 5);


CREATE TABLE Cities
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Namecity VARCHAR(50) NOT NULL,
    CountryID INT NOT NULL
);

INSERT INTO Cities(Namecity, CountryID) VALUES
('Moscow', 1), ('Paris', 2),
('London', 3), ('Brazil', 4),
('Buenos Aires', 5), ('Washington', 6),
('Ottawa', 7), ('Kinshasa', 8),
('Cairo', 9), ('Canberra', 10);

-- 13th TASK
SELECT O.CustomerID, Co.NameCountry, (O.Price - O.Discount) AS OrderPrice FROM Orders AS O JOIN Cities AS Ci ON O.CityID = Ci.ID
JOIN Countris AS Co ON CO.ID = Ci.CountryID
JOIN Mainlands AS M ON M.ID = Co.MainlandID
WHERE O.RequiredDate >= Date('1997-10-1') 
AND  M.Nameland = 'South America'
ORDER BY(OrderPrice)
LIMIT 3;

CREATE TABLE Suppliers
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    CompanyName VARCHAR(50) NOT NULL
);

INSERT INTO Suppliers(CompanyName) VALUES
('Mac'), ('Apple'), ('Google');

CREATE TABLE Products
(
	ID INT NOT NULL PRIMARY KEY AUTO_Increment,
    UnitPrice INT NOT NULL,
    SupplierID INT NOT NULL
);

INSERT INTO Products(UnitPrice,SupplierID) VALUES
(100,1), (150,1), (200,1), (200,2),(140,2), (300,2), (550,3), (500,3),(490,3);

SELECT DISTINCT s.CompanyName,
(SELECT min(t.UnitPrice) FROM Products as t WHERE t.SupplierID = p.SupplierID) as MinPrice,
(SELECT max(t.UnitPrice) FROM Products as t WHERE t.SupplierID = p.SupplierID) as MaxPrice
FROM Products AS p
INNER JOIN Suppliers AS s ON p.SupplierID = s.ID
ORDER BY s.CompanyName;

-- 14th Task
SELECT S.CompanyName, MIN(P.UnitPrice) AS MinPrice, MAX(P.UnitPrice) AS MaxPrice FROM Suppliers AS S JOIN Products AS P ON S.ID = P.SupplierID
GROUP BY(S.CompanyName)
ORDER BY S.CompanyName;


CREATE TABLE Customers
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Customername VARCHAR(50) NOT NULL,
    CityID INT NOT NULL
);

CREATE TABLE Employees 
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Firstname VARCHAR(20) NOT NULL,
    Lastname VARCHAR(20) NULL,
    CityID INT NOT NULL
);

CREATE TABLE Delivery
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Deliveryname VARCHAR(50) NOt NULL,
    OrderID INT NOT NULL   
);

CREATE TABLE Purchases
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
	EmployeeID INT NOT NULL,
    CustomerID INT NOT NULL
);

INSERT INTO Customers(Customername, CityID) VALUES
('Egor', 3), ('Maik', 6), ('Pety', 4), ('Vano', 5), ('IgAr', 3);

INSERT INTO Employees( Firstname, Lastname, CityID) VALUES
('Egor', 'Alexandrovich', 3),('Vlad', 'Greben', 5),('Ivan', 'Dortmon', 2),('Dina', 'Pupko',1),('Vano', 'Kalika', 3),('E', 'PErtak', 9);

INSERT INTO Purchases(EmployeeID, CustomerID) VALUES
(2,2),(1,1),(2,4),(2,2),(3,2),(5,3),(1,5),(5,5),(6,5);

INSERT INTO Delivery(Deliveryname, OrderID) VALUES
('Speedy Express',2),('SE',6),('SExpress',2),('Express',3),('Speed',4),('Speedy',2);

-- 15th TASK
SELECT CONCAT(E.Firstname, ' ', E.Lastname) AS Employee, C.Customername AS Customer   FROM Delivery  AS D JOIN Purchases AS P
ON  D.OrderID = P.ID JOIN Employees AS E
ON P.EmployeeID = E.ID JOIN Customers AS C
ON P.CustomerID = C.ID JOIN Cities AS Cy
ON E.CityID = Cy.ID  AND C.CityID = Cy.ID
WHERE Cy.Namecity = 'London' AND D.Deliveryname = 'Speedy Express';

CREATE TABLE Merchandises
(
	ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    CategoryID INT NOT NULL,
    Count INT NULL,
    DiscountinuedID INT NULL
);

CREATE TABLE Category
(
	ID INT NOT NULL PRIMARY KEY auto_increment,
    Categoryname VARCHAR(50) NOT NULL
);

CREATE TABLE Discountinueds
(
	ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Phone VARCHAR(12) NOT NULL
);

ALTER TABLE Discountinueds
ADD Discountinuedname VARCHAR(20) NOT NULL;

INSERT INTO Discountinueds(Phone, Discountinuedname) VALUES
('123123213', 'Egor'),('654623423', 'Misha'),('12354654', 'Vlad');

INSERT INTO Category(Categoryname) VALUES
('Beverages '),('Vegetables '),('Fruits '),('Seafood '),('Meet');

INSERT INTO Merchandises(CategoryID, Count, DiscountinuedID) VALUES
(1, 10, 1),(2, 20, 2),(1, 30, 2),(1,NULL,NULL),(3, 200, 3),(2, NULL, NULL),(4, 20, 2),(4, 15, 1),(5, 50, 2),(2, 50, 3),(1, 40, 2);


-- 16th TASK
SELECT
C.Categoryname AS ProductName,
M.Count AS UnitsInStock,
D.Discountinuedname AS ContactName,
D.Phone AS Phone
FROM Merchandises AS M JOIN Category AS C
ON M.CategoryID = C.ID JOIN Discountinueds AS D
ON M.DiscountinuedID = D.ID
WHERE C.Categoryname IN( 'Seafood ' ,'Beverages ')
AND M.Count < 20 
ORDER BY(M.Count);
