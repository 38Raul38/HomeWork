CREATE DATABASE Academy

CREATE TABLE Groups(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(10) NOT NULL UNIQUE CHECK (LEN([Name]) >= 2),
    [Rating] int NOT NULL CHECK (0 < LEN([Rating]) <= 5),
    [Year] int NOT NULL CHECK (1 < LEN([Year]) < 5)
)

CREATE  TABLE Departments(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([Name]) >= 2)
)

CREATE TABLE Faculties(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN([Name]) >= 2),
)

CREATE TABLE Teachers(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(50) NOT NULL CHECK (LEN([Name]) >= 2),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN([Surname]) >= 2),
    [EmploymentDate] date NOT NULL CHECK (EmploymentDate > '01.01.1990'),
    [Salary] money NOT NULL CHECK (Salary > 0),
    [Premium] money NOT NULL DEFAULT 0 CHECK (Premium > 0)
)
