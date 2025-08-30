USE Academy_4

CREATE TABLE [Group] (
    GroupId INT PRIMARY KEY,
    GroupName NVARCHAR(50) NOT NULL,
    StudentsCount INT DEFAULT 0
);

CREATE TABLE Student (
    StudentId INT PRIMARY KEY,
    StudentName NVARCHAR(100) NOT NULL,
    GroupId INT,
    AverageGrade DECIMAL(4,2) DEFAULT 0,
    FOREIGN KEY (GroupId) REFERENCES [Group](GroupId)
);

CREATE TABLE Course (
    CourseId INT PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL,
    TeacherId INT
);

CREATE TABLE Enrollment (
    EnrollmentId INT PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

CREATE TABLE Teacher (
    TeacherId INT PRIMARY KEY,
    TeacherName NVARCHAR(100) NOT NULL
);

CREATE TABLE Grade (
    GradeId INT PRIMARY KEY,
    StudentId INT,
    CourseId INT,
    GradeValue INT CHECK (GradeValue BETWEEN 1 AND 5),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

CREATE TABLE Warnings (
    WarningId INT PRIMARY KEY,
    StudentId INT,
    Reason NVARCHAR(255),
    WarningDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE GradeHistory (
    HistoryId INT PRIMARY KEY,
    GradeId INT,
    OldGradeValue INT,
    ChangeDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (GradeId) REFERENCES Grade(GradeId)
);

CREATE TABLE Attendance (
    AttendanceId INT PRIMARY KEY,
    StudentId INT,
    AttendanceDate DATE,
    IsPresent BIT,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE RetakeList (
    RetakeId INT PRIMARY KEY,
    StudentId INT,
    AddedDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY,
    StudentId INT,
    Amount DECIMAL(10,2),
    PaymentDate DATE,
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

INSERT INTO [Group] VALUES (1, 'Группа A', 0), (2, 'Группа B', 0);
INSERT INTO Course VALUES (1, 'Введение в программирование', 1), (2, 'Базы данных', 2);
INSERT INTO Teacher VALUES (1, 'Иванов И.И.'), (2, 'Петров П.П.');

--Task 1
CREATE TRIGGER trg_LimitStudentsInGroup
ON Student
AFTER INSERT
AS
BEGIN
    DECLARE @GroupId INT;
    SELECT @GroupId = GroupId FROM inserted;

    IF (SELECT COUNT(*) FROM Student WHERE GroupId = @GroupId) > 30
    BEGIN
        ROLLBACK;
        RAISERROR('Максимальное количество студентов в группе - 30.', 16, 1);
    END
END;

--Task 2
CREATE TRIGGER trg_UpdateStudentsCount
ON Student
AFTER INSERT, DELETE
AS
BEGIN
    DECLARE @GroupId INT;
    SELECT @GroupId = COALESCE((SELECT GroupId FROM inserted), (SELECT GroupId FROM deleted));

    UPDATE [Group]
    SET StudentsCount = (SELECT COUNT(*) FROM Student WHERE GroupId = @GroupId)
    WHERE GroupId = @GroupId;
END;

--Task 3
CREATE TRIGGER trg_AutoEnrollIntroCourse
ON Student
AFTER INSERT
AS
BEGIN
    DECLARE @StudentId INT, @CourseId INT;
    SELECT @StudentId = StudentId FROM inserted;
    SELECT @CourseId = CourseId FROM Course WHERE CourseName = 'Введение в программирование';

    IF @CourseId IS NOT NULL
    BEGIN
        INSERT INTO Enrollment (EnrollmentId, StudentId, CourseId)
        VALUES ((SELECT ISNULL(MAX(EnrollmentId), 0) + 1 FROM Enrollment), @StudentId, @CourseId);
    END
END;

--Task 4
CREATE TRIGGER trg_WarningLowGrade
ON Grade
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO Warnings (WarningId, StudentId, Reason)
    SELECT ISNULL((SELECT MAX(WarningId) FROM Warnings), 0) + 1, i.StudentId, 'Оценка ниже 3'
    FROM inserted i
    WHERE i.GradeValue < 3;
END;

--Task 5
CREATE TRIGGER trg_PreventTeacherDeletion
ON Teacher
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Course WHERE TeacherId IN (SELECT TeacherId FROM deleted))
    BEGIN
        RAISERROR('Нельзя удалить преподавателя с активными курсами.', 16, 1);
        RETURN;
    END
    DELETE FROM Teacher WHERE TeacherId IN (SELECT TeacherId FROM deleted);
END;

--Task 6
CREATE TRIGGER trg_GradeHistory
ON Grade
AFTER UPDATE
AS
BEGIN
    INSERT INTO GradeHistory (HistoryId, GradeId, OldGradeValue)
    SELECT ISNULL((SELECT MAX(HistoryId) FROM GradeHistory), 0) + 1, d.GradeId, d.GradeValue
    FROM deleted d;
END;

--Task 7
CREATE TRIGGER trg_AttendanceControl
ON Attendance
AFTER INSERT
AS
BEGIN
    INSERT INTO RetakeList (RetakeId, StudentId)
    SELECT ISNULL((SELECT MAX(RetakeId) FROM RetakeList), 0) + 1, i.StudentId
    FROM inserted i
    WHERE (
        SELECT COUNT(*) FROM Attendance
        WHERE StudentId = i.StudentId AND IsPresent = 0
        AND AttendanceDate >= DATEADD(DAY, -30, GETDATE())
    ) > 5;
END;

--Task 8
CREATE TRIGGER trg_PreventStudentDeletion
ON Student
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Payments p WHERE p.StudentId IN (SELECT StudentId FROM deleted) AND p.Amount < 0
    ) OR EXISTS (
        SELECT 1 FROM Grade g WHERE g.StudentId IN (SELECT StudentId FROM deleted) AND g.GradeValue < 3
    )
    BEGIN
        RAISERROR('Нельзя удалить студента с долгами или неудовлетворительными оценками.', 16, 1);
        RETURN;
    END
    DELETE FROM Student WHERE StudentId IN (SELECT StudentId FROM deleted);
END;

--Task 9
CREATE TRIGGER trg_UpdateAverageGrade
ON Grade
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE Student
    SET AverageGrade = (
        SELECT AVG(CAST(GradeValue AS DECIMAL(4,2)))
        FROM Grade
        WHERE StudentId = s.StudentId
    )
    FROM Student s
    INNER JOIN inserted i ON s.StudentId = i.StudentId;
END;
