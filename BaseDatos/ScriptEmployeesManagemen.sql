CREATE DATABASE EmployeesManagementDb;
GO

-- Usar bd EmployeesManagementDb
USE EmployeesManagementDb;
GO

-- Crear la tabla Employees
CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY ,   -- Clave primaria con incremento automático
    CompanyId INT,
	CreatedOn DATETIME,
	DeletedOn DATETIME,
	Email NVARCHAR(255),
	Fax NVARCHAR(100),
	Name NVARCHAR(100),
	Lastlogin DATETIME,
	Password NVARCHAR(100),
	PortalId INT,
	RoleId INT,
	StatusId INT, 
	Telephone NVARCHAR(100),
	UpdatedOn DATETIME,
	Username NVARCHAR(100)
);
GO

