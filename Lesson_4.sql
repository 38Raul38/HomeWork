create database Academy

use Academy

CREATE TABLE Departments (
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Financing] money NOT NULL CHECK (Financing >= 0) DEFAULT 0,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 0)
);

create table [Faculties] (
    [Id] int identity(1,1) primary key,
    [Dean] nvarchar(max) not null check (len([Dean]) > 0),
    [Name] nvarchar(100) not null unique check (len([Name]) > 0)
);

CREATE TABLE [Groups] (
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Name] nvarchar(10) NOT NULL UNIQUE CHECK (LEN([Name]) > 0),
    [Rating] int NOT NULL CHECK ([Rating] BETWEEN 0 AND 5),
    [Year] int NOT NULL CHECK ([Year] BETWEEN 1 AND 5)
);

CREATE TABLE [Teachers] (
    [ID] int IDENTITY(1,1) PRIMARY KEY,
    [EmploymentDate] date NOT NULL CHECK ([EmploymentDate] >= '1990-01-01'),
    [IsAssistant] bit NOT NULL DEFAULT 0,
    [IsProfessor] bit NOT NULL DEFAULT 0,
    [Name] nvarchar(MAX) NOT NULL CHECK (LEN([Name]) > 0),
    [Position] nvarchar(MAX) NOT NULL CHECK (LEN([Position]) > 0),
    [Premium] money NOT NULL CHECK ([Premium] >= 0) DEFAULT 0,
    [Salary] money NOT NULL CHECK ([Salary] > 0),
    [Surname] nvarchar(MAX) NOT NULL CHECK (LEN([Surname]) > 0)
);

INSERT INTO [Departments] ([Financing], [Name]) VALUES
(25000, N'Computer Science'),
(23000, N'Mathematics'),
(4000, N'Physics'),
(13500, N'Chemistry'),
(14500, N'Biology'),
(13200, N'Software Development”'),
(12800, N'Philosophy'),
(5000, N'Engineering'),
(33000, N'Economics'),
(27900, N'Linguistics');

INSERT INTO Faculties ([Dean], [Name]) VALUES
('Dr. John Smith', 'Faculty of Mathematics'),
('Dr. Alice Johnson', 'Faculty of Physics'),
('Dr. Michael Brown', 'Faculty of Chemistry'),
('Dr. Sarah White', 'Faculty of Biology');

INSERT INTO Groups ([Name], [Rating], [Year]) VALUES
('Group A', 4, 1),
('Group B', 5, 2),
('Group C', 3, 3),
('Group D', 4, 4),
('Group E', 2, 5);


INSERT INTO Teachers (EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) VALUES
('1997-09-15', 0, 1, 'John', 'Professor of Mathematics', 20.00, 5000.00, 'Smith'),
('2010-03-22', 1, 0, 'Alice', 'Assistant Professor of Physics', 180.00, 4000.00, 'Johnson'),
('2015-08-01', 0, 0, 'Michael', 'Lecturer of Chemistry', 1000.00, 350.00, 'Brown'),
('1998-06-10', 1, 0, 'Sarah', 'Assistant Professor of Biology', 19.00, 42.00, 'White')


--Task 1
    SELECT Name, Financing, Id
        FROM Departments;
--Task 2
    SELECT Name AS [Group Name], Rating AS [Group Rating]
            FROM Groups;
--Task 3
    SELECT Surname, (Salary / Premium) * 100 as 'percent', (Salary / (Salary + Premium) * 100) AS 'sal_percent'
            FROM Teachers;
--Task 4
    SELECT 'The dean of faculty ' + Faculties.Name + ' is ' + Faculties.Dean
            FROM Faculties;
--Task 5
    SELECT Surname FROM Teachers WHERE IsProfessor = 1 AND Salary > 1050
--Task 6
    SELECT Name FROM Departments WHERE Financing < 11000 OR Financing > 25000
--Task 7
    SELECT Name FROM Departments WHERE Name != 'Computer Science'
--Task 8
    SELECT Surname FROM Teachers WHERE IsAssistant = 1
--Task 9
    SELECT  Surname, Position, Salary, Premium FROM Teachers WHERE IsAssistant = 1 AND Premium BETWEEN 160 AND 550
--Task 10
    SELECT  Surname, Salary, Premium FROM Teachers
--Task 11
    SELECT DISTINCT Surname, Position FROM Teachers WHERE EmploymentDate < '01.01.2000'
--Task 12
    SELECT Name AS 'Name Of Department' FROM Departments WHERE Name < 'Software Development' ORDER BY Name
--Task 13
    SELECT DISTINCT Surname FROM  Teachers WHERE Salary + Premium > 1200
--Task 14
    SELECT Name FROM GROUPS WHERE Rating BETWEEN 2 AND 4
--Task 15
    SELECT DISTINCT Surname FROM Teachers WHERE Salary < 550 OR Premium < 200
