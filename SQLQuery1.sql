CREATE TABLE Request(
ID int NOT NULL PRIMARY KEY IDENTITY,
FullName varchar(255) NULL,
Email varchar(255) NULL UNIQUE,
Mes varchar (255) NULL,
);


