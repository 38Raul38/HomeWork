CREATE DATABASE Shop

USE Shop

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100)
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);



INSERT INTO Customers (FirstName, LastName, Email) VALUES
('John', 'Doe', 'john.doe@example.com'),
('Jane', 'Smith', 'jane.smith@example.com'),
('Michael', 'Johnson', 'michael.johnson@example.com'),
('Emily', 'Davis', 'emily.davis@example.com'),
('William', 'Brown', 'william.brown@example.com');

INSERT INTO Products (ProductName, Price) VALUES
('Laptop', 999.99),
('Smartphone', 699.50),
('Tablet', 399.99),
('Headphones', 149.75),
('Smartwatch', 249.99);

INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2025-02-01', 1149.74),
(2, '2025-02-05', 699.50),
(3, '2025-02-10', 1649.98),
(4, '2025-02-12', 249.99),
(5, '2025-02-15', 549.74);

INSERT INTO OrderDetails (OrderID, ProductID, Quantity, Price) VALUES
(1, 1, 1, 999.99),
(1, 4, 1, 149.75),
(2, 2, 1, 699.50),
(3, 1, 1, 999.99),
(3, 3, 1, 399.99),
(3, 5, 1, 249.99),
(4, 5, 1, 249.99),
(5, 4, 2, 299.50);



-- Task 1
-- Made above

-- Task 2
UPDATE Customers
SET Email = 'JohnDoe@gmail.com'
WHERE CustomerID = 1;

-- Task 3
DELETE Customers WHERE CustomerID = 5;

-- Task 4
SELECT
    * FROM Customers
ORDER BY LastName;

-- Task 5
-- Made above

-- Task 6
-- Made above

-- Task 7
UPDATE Orders
SET TotalAmount = 120
WHERE OrderID = 2;

-- Task 8
DELETE Orders WHERE OrderID = 3;

-- Task 9
SELECT
    * FROM Orders
WHERE CustomerID = 1;

-- Task 10
SELECT
    * FROM Orders
WHERE YEAR(OrderDate) = 2023;

-- Task 11
-- Made above

-- Task 12
UPDATE Products
SET Price = 650
WHERE ProductID = 2;

-- Task 13
DELETE Products WHERE ProductID = 4;

-- Task 14
SELECT
    * FROM Products
WHERE Price > 100;

-- Task 15
SELECT
    * FROM Products
WHERE Price <= 50;

-- Task 16
-- Made above

-- Task 17
UPDATE OrderDetails
SET Quantity = 5
WHERE OrderDetailID = 11;

-- Task 18
DELETE FROM OrderDetails WHERE OrderDetailID = 2;

-- Task 19
SELECT
    * FROM OrderDetails
WHERE OrderID = 1;

-- Task 20
SELECT
    * FROM OrderDetails
WHERE ProductID = 2;

-- Task 21
SELECT
    FirstName + ' ' + LastName AS 'FullName', OrderID
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID;

-- Task 22
SELECT
    Products.ProductName, Customers.FirstName + ' ' + Customers.LastName AS 'FullName', OrderDetails.Quantity
FROM OrderDetails
INNER JOIN Orders ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Customers ON Customers.CustomerID = Orders.CustomerID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID;

-- Task 23
SELECT
    * FROM Orders
LEFT JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

-- Task 24
SELECT
    Products.ProductName, Orders.OrderID, Orders.CustomerID, Orders.OrderDate, Orders.TotalAmount
FROM Orders
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON Products.ProductID = OrderDetails.ProductID;

-- Task 25
SELECT
    Customers.FirstName + ' ' + LastName AS 'FullName', Orders.OrderID
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;

-- Task 26
SELECT
    ProductName, OrderID, OrderDetails.ProductID, Quantity, OrderDetails.Price
FROM Products
RIGHT JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID;

-- Task 27
SELECT
    ProductName
FROM Products
INNER JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
INNER JOIN Orders ON OrderDetails.OrderID = Orders.OrderID;

-- Task 28
SELECT
    Customers.CustomerID, Customers.FirstName + ' ' + Customers.LastName AS 'FullName', Orders.OrderID, Orders.TotalAmount
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID;

-- Task 29
SELECT
    FirstName + ' ' + LastName AS 'FullName'
FROM Customers
WHERE CustomerID IN (
    SELECT CustomerID FROM Orders WHERE TotalAmount > 500
);

-- Task 30
SELECT
    ProductName
FROM Products
WHERE ProductID IN (
    SELECT ProductID FROM OrderDetails GROUP BY ProductID HAVING SUM(Quantity) > 5
);

-- Task 31
SELECT
    Customers.FirstName, Customers.LastName,
       (SELECT SUM(TotalAmount) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID) AS TotalSpent
FROM Customers
WHERE (SELECT SUM(TotalAmount) FROM Orders WHERE Customers.CustomerID = Orders.CustomerID) IS NOT NULL;

-- Task 32
SELECT
    ProductName, Price
FROM Products
WHERE Price > (
    SELECT AVG(Price) FROM Products
);

-- Task 33
SELECT
    Orders.OrderID, Customers.FirstName, Customers.LastName, Products.ProductName, OrderDetails.Quantity, OrderDetails.Price
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
JOIN Products ON OrderDetails.ProductID = Products.ProductID;

-- Task 34
SELECT
    Customers.CustomerID, Customers.FirstName, Customers.LastName, Orders.OrderID, Products.ProductName, OrderDetails.Quantity, OrderDetails.Price
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
JOIN Products ON OrderDetails.ProductID = Products.ProductID;

-- Task 35
SELECT
    Customers.CustomerID, Customers.FirstName, Customers.LastName, Products.ProductName, OrderDetails.Quantity,
       OrderDetails.Quantity * Products.Price AS TotalCost
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON Products.ProductID = OrderDetails.ProductID;

-- Task 36
SELECT
    Orders.OrderID, SUM(OrderDetails.Quantity * OrderDetails.Price) AS OrderTotal
FROM Orders
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
GROUP BY Orders.OrderID
HAVING SUM(OrderDetails.Quantity * OrderDetails.Price) > 3300;

-- Task 37
SELECT
    Customers.CustomerID, Customers.FirstName, Customers.LastName
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName
HAVING AVG(Orders.TotalAmount) > (
    SELECT AVG(TotalAmount) FROM Orders
);

-- Task 38
SELECT
    Customers.FirstName, Customers.CustomerID, COUNT(Orders.OrderID) AS OrderCount
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName;

-- Task 39
SELECT
    ProductID, SUM(Quantity) AS TotalQuantity
FROM OrderDetails
GROUP BY ProductID
HAVING SUM(Quantity) > 3;

-- Task 40
SELECT
    Customers.CustomerID, Customers.FirstName, Customers.LastName, Orders.OrderID, SUM(OrderDetails.Quantity) AS TotalProducts
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName, Orders.OrderID;

