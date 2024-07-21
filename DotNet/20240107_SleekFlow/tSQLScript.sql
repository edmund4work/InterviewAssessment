-- Todo Table
CREATE TABLE tblTodo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME NOT NULL,
    StatusId INT NOT NULL,
    Enabled BIT NOT NULL,
    Priority INT NOT NULL,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL,
    UpdatedID int Not NUll,
    UpdatedDate DATETIME NOT NULL
);

CREATE TABLE tblTodoStatusLog (
    ID INT PRIMARY KEY IDENTITY(1,1),
    todoID int not null,
    StatusID int not null,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL
)

CREATE TABLE tblUser (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Enabled BOOLEAN NOT NULL,
    Priority INT NOT NULL,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL,
    UpdatedID int Not NUll,
    UpdatedDate DATETIME NOT NULL
);

-- CommonTags Table
CREATE TABLE tblCommonTags (
    ID INT PRIMARY KEY IDENTITY(1,1),
    tagName NVARCHAR(255) NOT NULL,
    Enabled BIT NOT NULL
);

INSERT INTO tblCommonTags (tagName,Enabled)
VALUES
    ('Works' , 1),
    ('Good Ideas', 1),
    ('Project Management', 1);

-- CommonStatus Table
CREATE TABLE tblCommonStatus (
    statusID INT PRIMARY KEY IDENTITY(1,1),
    statusName NVARCHAR(255) NOT NULL
);
INSERT INTO commonStatus (statusName)
VALUES
    ('Active'),
    ('Pending'),
    ('Discontinued'),
    ('Completed'),
    ('Not Started');

-- TodoTags Table
CREATE TABLE tblTodoTags (
    ID INT PRIMARY KEY IDENTITY(1,1),
    todoID INT NOT NULL,
    tagName NVARCHAR(255) NOT NULL
);