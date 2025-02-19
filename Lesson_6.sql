CREATE DATABASE Academy_3

USE Academy_3

CREATE TABLE Curators(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(max) NOT NULL CHECK (LEN(Name) > 2),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN(Surname) > 2)
)

CREATE TABLE Faculties(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2)
)

CREATE TABLE Departments(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Building] int NOT NULL CHECK (Building BETWEEN 1 AND 5),
    [Financing] money NOT NULL DEFAULT 0 CHECK (Financing > 0),
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2),
    [FacultyId] int NOT NULL FOREIGN KEY REFERENCES Faculties(Id)
)


CREATE TABLE Groups(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2),
    [Year] int NOT NULL CHECK (Year BETWEEN  1 AND 5),
    [DepartmentId] int NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE GroupsCurators(
    [Id] int identity(1, 1) PRIMARY KEY,
    [CuratorId] int NOT NULL FOREIGN KEY REFERENCES Curators(Id),
    [GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id)
)

CREATE TABLE Subjects(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(100) NOT NULL UNIQUE CHECK (LEN(Name) > 2)
)

CREATE TABLE Teachers(
    [Id] int identity(1, 1) PRIMARY KEY,
    [IsProfessor] bit NOT NULL DEFAULT 0,
    [Name] nvarchar(max) NOT NULL CHECK (LEN(Name) > 2),
    [Salary] money NOT NULL CHECK (Salary >= 0),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN(Surname) > 2)
)

CREATE TABLE Lectures(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Date] date NOT NULL CHECK ([Date] <= CONVERT(date, GETDATE())),
    [SubjectId] int NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
    [TeacherId] int NOT NULL FOREIGN KEY REFERENCES Teachers(Id)
)

CREATE TABLE GroupsLectures(
    [Id] int identity(1, 1) PRIMARY KEY,
    [GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
    [LectureId] int NOT NULL FOREIGN KEY REFERENCES Lectures(Id)
)

CREATE TABLE Students(
    [Id] int identity(1, 1) PRIMARY KEY,
    [Name] nvarchar(max) NOT NULL CHECK (LEN(Name) > 2),
    [Rating] int NOT NULL CHECK (Rating BETWEEN 1 AND 5),
    [Surname] nvarchar(max) NOT NULL CHECK (LEN(Surname) > 2)
)

CREATE TABLE GroupsStudents(
    [Id] int identity(1, 1) PRIMARY KEY,
    [GroupId] int NOT NULL FOREIGN KEY REFERENCES Groups(Id),
    [StudentId] int NOT NULL FOREIGN KEY REFERENCES Students(Id)
)




-- Заполнение таблицы Faculties
INSERT INTO Faculties (Name) VALUES
('Computer Science'),
('Software Development'),
('Mathematics');

-- Заполнение таблицы Departments
INSERT INTO Departments (Building, Financing, Name, FacultyId) VALUES
(1, 120000, 'Algorithms', 1),
(2, 80000, 'Software Engineering', 2),
(3, 50000, 'Discrete Mathematics', 3),
(4, 130000, 'Database Systems', 1);

-- Заполнение таблицы Curators
INSERT INTO Curators (Name, Surname) VALUES
('Alex', 'Ivanov'),
('Maria', 'Petrova'),
('Igor', 'Sidorov');

-- Заполнение таблицы Groups
INSERT INTO Groups (Name, Year, DepartmentId) VALUES
('D221', 5, 1),
('S101', 1, 2),
('S102', 2, 2),
('M301', 3, 3),
('M302', 5, 3);

-- Заполнение таблицы GroupsCurators
INSERT INTO GroupsCurators (CuratorId, GroupId) VALUES
(1, 1),
(2, 2),
(3, 3),
(1, 4),
(2, 5);

-- Заполнение таблицы Subjects
INSERT INTO Subjects (Name) VALUES
('Data Structures'),
('Algorithms'),
('Database Systems'),
('Software Engineering');

-- Заполнение таблицы Teachers
INSERT INTO Teachers (IsProfessor, Name, Salary, Surname) VALUES
(1, 'John', 150000, 'Smith'),
(0, 'Jane', 80000, 'Doe'),
(0, 'Paul', 60000, 'Brown');

-- Заполнение таблицы Lectures
INSERT INTO Lectures (Date, SubjectId, TeacherId) VALUES
('2025-02-10', 1, 1),
('2025-02-11', 2, 2),
('2025-02-12', 3, 3);

-- Заполнение таблицы GroupsLectures
INSERT INTO GroupsLectures (GroupId, LectureId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 2);

-- Заполнение таблицы Students
INSERT INTO Students (Name, Rating, Surname) VALUES
('Ivan', 5, 'Ivanov'),
('Oleg', 4, 'Sidorov'),
('Anna', 3, 'Petrova');

-- Заполнение таблицы GroupsStudents
INSERT INTO GroupsStudents (GroupId, StudentId) VALUES
(1, 1),
(2, 2),
(3, 3);


--Task 1
    SELECT
        Building
    FROM Departments
    GROUP BY Building
    HAVING SUM(Departments.Financing) > 10000
--Task 2
    SELECT
        Groups.Name
    FROM Groups
    JOIN Departments ON Departments.Id = Groups.DepartmentId
    JOIN GroupsLectures ON Groups.Id = GroupsLectures.GroupId
    WHERE Departments.Name = 'Algorithms' AND Groups.Year = 5
    AND GroupsLectures.LectureId IN (SELECT Id FROM Lectures WHERE Date BETWEEN '2024-02-01' AND '2024-02-07')
    GROUP BY Groups.Name
    HAVING COUNT(GroupsLectures.LectureId) > 1;
--Task 3
    SELECT
        Groups.Name
    FROM Groups
    JOIN GroupsStudents ON Groups.Id = GroupsStudents.GroupId
    JOIN Students ON Students.Id = GroupsStudents.StudentId
    GROUP BY Groups.Name
    HAVING AVG(Students.Rating) > (SELECT AVG(Students.Rating)
                                    FROM Groups
                                    JOIN GroupsStudents ON Groups.Id = GroupsStudents.GroupId
                                    JOIN Students ON Students.Id = GroupsStudents.StudentId
                                    WHERE Groups.Name = 'D221'
                                            );
--Task 4
    SELECT
        Teachers.Name,
        Teachers.Surname
    FROM Teachers
    WHERE Teachers.Salary > (SELECT AVG(Salary) FROM Teachers WHERE IsProfessor = 1);
--Task 5
    SELECT
        Groups.Name
    FROM Groups
    JOIN GroupsCurators ON Groups.Id = GroupsCurators.GroupId
    GROUP BY Groups.Name
    HAVING COUNT(GroupsCurators.CuratorId) > 1;
--Task 6
    SELECT
        Groups.Name
    FROM Groups
    JOIN GroupsStudents ON Groups.Id = GroupsStudents.GroupId
    JOIN Students ON Students.Id = GroupsStudents.StudentId
    GROUP BY Groups.Name
    HAVING AVG(Students.Rating) > (SELECT MIN(Students.Rating) FROM Groups
                                   JOIN GroupsStudents ON Groups.Id = GroupsStudents.GroupId
                                   JOIN Students ON Students.Id = GroupsStudents.StudentId
                                   WHERE Groups.Year = 5);
--Task 7
    SELECT
        Faculties.Name
    FROM Faculties
    JOIN Departments ON Faculties.Id = Departments.FacultyId
    GROUP BY Faculties.Name
    HAVING SUM(Departments.Financing) > (SELECT SUM(Departments.Financing) FROM Departments
                                         JOIN Faculties ON Faculties.Id = Departments.FacultyId
                                         WHERE Faculties.Name = 'Computer Science');
--Task 8
    SELECT
        Subjects.Name,
        Teachers.Name + ' ' + Teachers.Surname AS FullName
    FROM Subjects
    JOIN Lectures ON Subjects.Id = Lectures.SubjectId
    JOIN Teachers ON Teachers.Id = Lectures.TeacherId
    GROUP BY Subjects.Name, Teachers.Name, Teachers.Surname
    HAVING COUNT(Lectures.Id) = (SELECT MAX(Count)
                       FROM (SELECT COUNT(Lectures.Id) AS Count
                             FROM Lectures
                             GROUP BY Lectures.SubjectId, Lectures.TeacherId) AS MaxLectures);
--Task 9
    SELECT
       TOP 1 Subjects.Name
    FROM Subjects
    JOIN Lectures ON Subjects.Id = Lectures.SubjectId
    GROUP BY Subjects.Name
    ORDER BY COUNT(Lectures.Id) ASC;
--Task 10
    SELECT
        COUNT(GroupsStudents.StudentId) AS StudentCount,
        COUNT(GroupsLectures.LectureId) AS LectureCount
    FROM Departments
    JOIN Groups ON Departments.Id = Groups.DepartmentId
    JOIN GroupsStudents ON Groups.Id = GroupsStudents.GroupId
    JOIN GroupsLectures ON Groups.Id = GroupsLectures.GroupId
    JOIN Lectures ON GroupsLectures.LectureId = Lectures.Id
    WHERE Departments.Name = 'Software Development';





