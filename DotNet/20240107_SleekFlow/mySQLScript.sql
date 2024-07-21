use sleekflowDB;

CREATE TABLE tblTodo (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    DueDate DATETIME NOT NULL,
    StatusId INT NOT NULL, -- Assuming this is a foreign key to commonStatus table
    Enabled BOOLEAN NOT NULL,
    Priority INT NOT NULL,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL,
    UpdatedID int Not NUll,
    UpdatedDate DATETIME NOT NULL
);


CREATE TABLE tblTodoStatusLog (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    todoID int not null,
    StatusID int not null,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL
)

CREATE TABLE tblUser (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Enabled BOOLEAN NOT NULL,
    Priority INT NOT NULL,
    CreatedID int Not NUll,
    CreatedDate DATETIME NOT NULL,
    UpdatedID int Not NUll,
    UpdatedDate DATETIME NOT NULL
);

CREATE TABLE tblCommonTags (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    tagName VARCHAR(255) NOT NULL,
    Enabled BOOLEAN NOT NULL
);
INSERT INTO tblCommonTags (tagName,Enabled)
VALUES
    ('Works' , 1),
    ('Good Ideas', 1),
    ('Project Management', 1);


CREATE TABLE tblCommonStatus (
    statusID INT AUTO_INCREMENT PRIMARY KEY,
    statusName VARCHAR(255) NOT NULL
);
INSERT INTO tblCommonStatus (statusName)
VALUES
    ('Active'),
    ('Pending'),
    ('Discontinued'),
    ('Completed'),
    ('Not Started');

CREATE TABLE tblTodoTags (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    todoID INT  NOT NULL,
    tagName VARCHAR(255) NOT NULL
);