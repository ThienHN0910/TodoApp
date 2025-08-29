CREATE DATABASE TodoDb;

GO
USE TodoDb;
GO


CREATE TABLE dbo.Tasks (
    Id int PRIMARY KEY identity(1,1),
    Name NVARCHAR(200) NOT NULL,
    CreatedAt DATE NOT NULL DEFAULT GetDate(),
    Deadline DATE NOT NULL,
    Priority Varchar(12) NOT NULL,
    Status bit NOT NULL DEFAULT 0,
);


select * from Tasks;