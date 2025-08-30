CREATE DATABASE Academy_2

USE Academy_2


CREATE TABLE Curators(
    [Id] int identity(1, 1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(max) NOT NULL CHECK (LEN(Name) > 2),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN(Surname) > 2)
)

CREATE TABLE Faculties(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2)
)

CREATE TABLE Teachers(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(max) NOT NULL CHECK (LEN(Name) > 2),
    [Salary] money  NOT NULL CHECK (Salary >= 0),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN(Surname) > 2)
)

CREATE TABLE Subjects(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2)
)

CREATE TABLE Departments(
    [Id] int identity(1, 1) PRIMARY KEY NOT NULL,
    [Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2),
    [FacultyId] int NOT NULL FOREIGN KEY REFERENCES Faculties(Id),
)

CREATE TABLE Groups(
    [Id] int identity(1, 1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(10) NOT NULL UNIQUE CHECK (LEN(Name) > 2),
    [Year] int NOT NULL CHECK (Year BETWEEN 1 AND 5),
    [DepartmentId] int  NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE GroupsCurators(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [CuratorId] int NOT NULL FOREIGN KEY REFERENCES Curators(Id),
    [GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id)
)

CREATE TABLE  Lectures(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [LectureRoom] nvarchar(max) NOT NULL CHECK (LEN(LectureRoom) > 2),
    [SubjectId] int NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE GroupsLectures(
    [Id] int identity (1,1) PRIMARY KEY NOT NULL,
    [GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
    [LectureId] int NOT NULL FOREIGN KEY REFERENCES Lectures(Id),
)


-- Заполнение таблицы Curators
INSERT INTO Curators (Name, Surname) VALUES
('John', 'Smith'),
('Anna', 'Brown'),
('Mark', 'Johnson');

-- Заполнение таблицы Faculties
INSERT INTO Faculties (Name, Financing) VALUES
('Computer Science', 500000),
('Mathematics', 300000);

-- Заполнение таблицы Teachers
INSERT INTO Teachers (Name, Surname, Salary) VALUES
('Samantha', 'Adams', 60000),
('Robert', 'Wilson', 55000),
('Emma', 'Clark', 58000);

-- Заполнение таблицы Subjects
INSERT INTO Subjects (Name) VALUES
('Database Theory'),
('Algorithms'),
('Mathematical Analysis');

-- Заполнение таблицы Departments
INSERT INTO Departments (Name, Financing, FacultyId) VALUES
('Software Engineering', 600000, 1),
('Applied Mathematics', 200000, 2);

-- Заполнение таблицы Groups
INSERT INTO Groups (Name, Year, DepartmentId) VALUES
('P107', 3, 1),
('M201', 5, 2);

-- Заполнение таблицы GroupsCurators
INSERT INTO GroupsCurators (CuratorId, GroupId) VALUES
(1, 1),
(2, 2);

-- Заполнение таблицы Lectures
INSERT INTO Lectures (LectureRoom, SubjectId) VALUES
('B103', 1),
('A205', 2);

-- Заполнение таблицы GroupsLectures
INSERT INTO GroupsLectures (GroupId, LectureId) VALUES
(1, 1),
(2, 2);

-- Связь преподавателей с лекциями (предполагается, что связь через отдельную таблицу, если нет, нужно изменить схему)
CREATE TABLE TeachersLectures (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
    LectureId INT NOT NULL FOREIGN KEY REFERENCES Lectures(Id)
);

INSERT INTO TeachersLectures (TeacherId, LectureId) VALUES
(1, 1),
(2, 2);

--Task 1
    SELECT *FROM Teachers, Groups
--Task 2
    SELECT
        Faculties.Name
    FROM  Faculties
    JOIN Departments  ON Faculties.Id = Departments.FacultyId
    WHERE Departments.Financing > Faculties.Financing
--Task 3
    SELECT
        Curators.Surname,
        Groups.Name AS GroupsName
    FROM Curators
    JOIN GroupsCurators  ON Curators.Id = GroupsCurators.CuratorId
    JOIN Groups  on Groups.Id = GroupsCurators.GroupId
--Task 4
    SELECT
        Teachers.Name,
        Teachers.Surname
    FROM Teachers
    JOIN TeachersLectures  ON Teachers.Id = TeachersLectures.TeacherId
    JOIN Lectures  ON Lectures.Id = TeachersLectures.LectureId
    JOIN GroupsLectures  ON TeachersLectures.LectureId = GroupsLectures.LectureId
    JOIN Groups  on Groups.Id = GroupsLectures.GroupId
    WHERE Groups.Name = 'P107'
--Task 5
    SELECT
        Teachers.Surname,
        Faculties.Name
    FROM Teachers
    JOIN TeachersLectures ON Teachers.Id = TeachersLectures.TeacherId
    JOIN Lectures ON Lectures.Id = TeachersLectures.LectureId
    JOIN GroupsLectures  ON Lectures.Id = GroupsLectures.LectureId
    JOIN Groups ON Groups.Id = GroupsLectures.GroupId
    JOIN Departments ON Departments.Id = Groups.DepartmentId
    JOIN Faculties on Departments.FacultyId = Faculties.Id
--Task 6
    SELECT
        Departments.Name,
        Groups.Name
    FROM Departments
    JOIN Groups ON Departments.Id = Groups.DepartmentId
--Task 7
    SELECT
        Subjects.Name
    FROM Subjects
    JOIN Lectures ON Subjects.Id = Lectures.SubjectId
    JOIN TeachersLectures ON Lectures.Id = TeachersLectures.LectureId
    JOIN Teachers ON TeachersLectures.TeacherId = Teachers.Id
    WHERE Teachers.Name = 'Samantha' AND Teachers.Surname = 'Adams';
--Task 8
    SELECT
        Departments.Name
    FROM Departments
    JOIN Groups ON Departments.Id = Groups.DepartmentId
    JOIN GroupsLectures ON Groups.Id = GroupsLectures.GroupId
    JOIN Lectures ON Lectures.Id = GroupsLectures.LectureId
    JOIN Subjects  ON Subjects.Id = Lectures.SubjectId
    WHERE Subjects.Name = 'Database Theory'
--Task 9
    SELECT
        Groups.Name
    FROM Groups
    JOIN Departments ON Departments.Id = Groups.DepartmentId
    JOIN Faculties  ON Faculties.Id = Departments.FacultyId
    WHERE Faculties.Name = 'Computer Science'
--Task 10
    SELECT
        Groups.Name AS GroupName,
        Faculties.Name AS FacultyName
    FROM Groups
    JOIN Departments ON Departments.Id = Groups.DepartmentId
    JOIN Faculties ON Faculties.Id = Departments.FacultyId
    WHERE Groups.Year = 5
--Task 11
    SELECT
        Teachers.Name + ' ' + Teachers.Surname AS FullName,
        Subjects.Name AS SubjectName,
        Groups.Name AS GroupName
    FROM Teachers
    JOIN TeachersLectures  ON Teachers.Id = TeachersLectures.TeacherId
    JOIN Lectures ON TeachersLectures.LectureId = Lectures.Id
    JOIN Subjects  ON Subjects.Id = Lectures.SubjectId
    JOIN GroupsLectures  ON Lectures.Id = GroupsLectures.LectureId
    JOIN Groups ON Groups.Id = GroupsLectures.GroupId
    WHERE Lectures.LectureRoom = 'B103'










