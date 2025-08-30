CREATE DATABASE CarDealership;

USE CarDealership;

-- Таблица клиентов
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Phone NVARCHAR(20) NOT NULL
);

-- Таблица автомобилей
CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT CHECK (Year >= 2000),
    Price DECIMAL(10,2) CHECK (Price > 0)
);

-- Таблица заказов
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Orders_Cars FOREIGN KEY (CarId) REFERENCES Cars(Id) ON DELETE CASCADE
);

-- Таблица истории цен автомобилей
CREATE TABLE CarPriceHistory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CarId INT NOT NULL,
    OldPrice DECIMAL(10,2),
    NewPrice DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_CarPriceHistory_Cars FOREIGN KEY (CarId) REFERENCES Cars(Id) ON DELETE CASCADE
);

-- Таблица логов удалённых заказов
CREATE TABLE DeletedOrdersLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT,
    CustomerId INT,
    CarId INT,
    OrderDate DATETIME,
    DeletedAt DATETIME DEFAULT GETDATE()
);

-- Заполнение тестовыми данными
INSERT INTO Customers (Name, Email, Phone) VALUES
('Иван Петров', 'ivan.petrov@email.com', '123-456-789'),
('Мария Сидорова', 'maria.sidorova@email.com', '987-654-321'),
('Алексей Смирнов', 'alex.smirnov@email.com', '555-666-777');

INSERT INTO Cars (Brand, Model, Year, Price) VALUES
('Toyota', 'Camry', 2022, 30000),
('BMW', 'X5', 2023, 60000),
('Mercedes', 'C-Class', 2021, 50000);

INSERT INTO Orders (CustomerId, CarId) VALUES
(1, 1),
(2, 2),
(3, 3);


-- 1️⃣ Триггер на отслеживание изменения цены автомобиля
CREATE TRIGGER trg_CarPriceUpdate
ON Cars
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Price)
    BEGIN
        INSERT INTO CarPriceHistory (CarId, OldPrice, NewPrice, ChangeDate)
        SELECT deleted.Id, deleted.Price, inserted.Price, GETDATE()
        FROM inserted
        JOIN deleted ON inserted.Id = deleted.Id
        WHERE inserted.Price <> deleted.Price;
    END
END;

-- 2️⃣ Триггер на предотвращение удаления клиентов с активными заказами
CREATE TRIGGER trg_PreventCustomerDelete
ON Customers
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Orders WHERE CustomerId IN (SELECT Id FROM deleted))
    BEGIN
        RAISERROR('Невозможно удалить клиента с активными заказами.', 16, 1);
        RETURN;
    END
    DELETE FROM Customers WHERE Id IN (SELECT Id FROM deleted);
END;

-- 3️⃣ Триггер на логирование удаления заказов
CREATE TRIGGER trg_LogDeletedOrders
ON Orders
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DeletedOrdersLog (OrderId, CustomerId, CarId, OrderDate, DeletedAt)
    SELECT Id, CustomerId, CarId, OrderDate, GETDATE()
    FROM deleted;
END;

-- 4️⃣ Триггер на автоматическое обновление цены при изменении года выпуска
CREATE TRIGGER trg_UpdateCarPriceOnYearChange
ON Cars
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Year)
    BEGIN
        UPDATE Cars
        SET Cars.Price = Cars.Price * 0.95
        FROM Cars
        JOIN inserted ON Cars.Id = inserted.Id
        JOIN deleted ON deleted.Id = inserted.Id
        WHERE inserted.Year <> deleted.Year;
    END
END;

-- 5️⃣ Триггер на предотвращение дублирования заказов
CREATE TRIGGER trg_PreventDuplicateOrders
ON Orders
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted
        JOIN Orders ON inserted.CustomerId = Orders.CustomerId AND inserted.CarId = Orders.CarId
    )
    BEGIN
        RAISERROR('Невозможно оформить заказ на один и тот же автомобиль более одного раза.', 16, 1);
        RETURN;
    END

    INSERT INTO Orders (CustomerId, CarId, OrderDate)
    SELECT CustomerId, CarId, ISNULL(OrderDate, GETDATE())
    FROM inserted;
END;
