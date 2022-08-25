USE BeSpokeBikes

--CREATE DATABASE BeSpokeBikes


DROP TABLE BeSpokeBikes.dbo.Product

CREATE TABLE BeSpokeBikes.dbo.Product
(
    Id INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(250) NOT NULL,
    Manufacturer VARCHAR(250) NOT NULL,
    Style VARCHAR(250) NOT NULL,
	PurchasePrice DECIMAL(19,4) NOT NULL,
    SalePrice DECIMAL(19,4) NOT NULL,
	QuantityOnHand INT NOT NULL,
	CommisionPercent DECIMAL(12,8) NOT NULL,

	CONSTRAINT PK_Product_Id PRIMARY KEY CLUSTERED (Id)
);

INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('Artemis', 'Cool Bikes', 'Mountain', 1000.00, 2000.00, 20, 10.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('Hydra', 'Cool Bikes', 'Hybrid', 1500.00, 3000.00, 10, 15.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('Icarus', 'Cool Bikes', 'Road', 800.00, 1500.00, 30, 10.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('Street Master', 'Rad Wheels', 'Road', 2500.00, 3500.00, 5, 5.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('TAB1000', 'Rockstar Rides', 'Mountain', 4000.00, 6000.00, 20, 12.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('HeadSmart80', 'Rockstar Rides', 'Helmet', 30.00, 70.00, 50, 20.0)
INSERT INTO Product ([Name], Manufacturer, Style, PurchasePrice, SalePrice, QuantityOnHand, CommisionPercent) VALUES ('Hand Mittens', 'Cool Bikes', 'Gloves', 10.00, 25.00, 50, 10.0)


DROP TABLE BeSpokeBikes.dbo.Salesperson

CREATE TABLE BeSpokeBikes.dbo.Salesperson
(
    Id INT NOT NULL IDENTITY(1, 1),
    FirstName VARCHAR(250) NOT NULL,
    LastName VARCHAR(250) NOT NULL,
    [Address] VARCHAR(250) NOT NULL,
    [Phone] VARCHAR(250) NOT NULL,
	StartDate DATETIME2 NOT NULL,
    TerminationDate DATETIME2 NULL,
	ManagerId INT NULL,

	CONSTRAINT PK_Salesperson_Id PRIMARY KEY CLUSTERED (Id),

    CONSTRAINT FK_Salesperson_ManagerId FOREIGN KEY (ManagerId) REFERENCES dbo.Salesperson(Id)
);

INSERT INTO Salesperson (FirstName, LastName, [Address], [Phone], StartDate, TerminationDate, ManagerId) VALUES ('Head', 'Dude', '100 Boss Lane', '555-829-3214', '10-12-2000', NULL, NULL)

INSERT INTO Salesperson (FirstName, LastName, [Address], [Phone], StartDate, TerminationDate, ManagerId) 
VALUES ('John', 'Salesguy', '23 Sales Rd', '555-829-4453', '10-12-2010', '12-25-2020', (SELECT Id FROM Salesperson WHERE FirstName = 'Head' AND LastName = 'Dude'))

INSERT INTO Salesperson (FirstName, LastName, [Address], [Phone], StartDate, TerminationDate, ManagerId) 
VALUES ('Marsha', 'Abernathy', '284 Pinecrest Dr', '555-829-5623', '10-18-2010', NULL, (SELECT Id FROM Salesperson WHERE FirstName = 'Head' AND LastName = 'Dude'))

INSERT INTO Salesperson (FirstName, LastName, [Address], [Phone], StartDate, TerminationDate, ManagerId) 
VALUES ('Kelly', 'Sanchez', '23 Peachtree Rd', '555-829-0001', '1-12-2018', NULL, (SELECT Id FROM Salesperson WHERE FirstName = 'John' AND LastName = 'Salesguy'))


DROP TABLE BeSpokeBikes.dbo.Customer

CREATE TABLE BeSpokeBikes.dbo.Customer
(
    Id INT NOT NULL IDENTITY(1, 1),
    FirstName VARCHAR(250) NOT NULL,
    LastName VARCHAR(250) NOT NULL,
    [Address] VARCHAR(250) NOT NULL,
    [Phone] VARCHAR(250) NOT NULL,
	StartDate DATETIME2 NOT NULL,

	CONSTRAINT PK_Customer_Id PRIMARY KEY CLUSTERED (Id)
);

INSERT INTO Customer (FirstName, LastName, [Address], [Phone], StartDate) VALUES ('Will', 'Scranton', '25 Somewhere Pl', '555-876-1234', '1-12-2020')
INSERT INTO Customer (FirstName, LastName, [Address], [Phone], StartDate) VALUES ('Gena', 'Milliken', '834 Outer Rd', '555-876-5612', '2-23-2021')



DROP TABLE BeSpokeBikes.dbo.Sale

CREATE TABLE BeSpokeBikes.dbo.Sale
(
    Id INT NOT NULL IDENTITY(1, 1),
    CustomerId INT NOT NULL,
    SalespersonId INT NOT NULL,
	[Date] DATETIME2 NOT NULL,
    ProductId INT NOT NULL,
    PurchasePrice DECIMAL(19,4) NOT NULL,
	CommissionPercent DECIMAL(12,8) NOT NULL,

	CONSTRAINT PK_Sale_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Sale_CustomerId FOREIGN KEY (CustomerId) REFERENCES dbo.Customer(Id),
    CONSTRAINT FK_Sale_SalespersonId FOREIGN KEY (SalespersonId) REFERENCES dbo.Salesperson(Id),
    CONSTRAINT FK_Sale_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Product(Id)
);

INSERT INTO Sale (CustomerId, SalespersonId, [Date], ProductId, PurchasePrice, CommissionPercent) 
VALUES 
(
    (SELECT Id FROM Customer WHERE FirstName = 'Gena' AND LastName = 'Milliken'), 
    (SELECT Id FROM Salesperson WHERE FirstName = 'John' AND LastName = 'Salesguy'), 
    '3-6-2022', 
    (SELECT Id FROM Product WHERE [Name] = 'Hydra'), 
    (SELECT SalePrice FROM Product WHERE [Name] = 'Hydra'), 
    (SELECT CommisionPercent FROM Product WHERE [Name] = 'Hydra')
)





DROP TABLE BeSpokeBikes.dbo.Discount

CREATE TABLE BeSpokeBikes.dbo.Discount
(
    Id INT NOT NULL IDENTITY(1, 1),
    [Description] VARCHAR(250) NOT NULL,
    ProductId INT NOT NULL,
    [StartDate] DATETIME2 NOT NULL,
    [EndDate] DATETIME2 NOT NULL,
	DiscountPercent DECIMAL(12,8) NULL,
    DiscountAmount DECIMAL(19,4) NULL,

	CONSTRAINT PK_Discount_Id PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Discount_ProductId FOREIGN KEY (ProductId) REFERENCES dbo.Product(Id),
    CHECK (DiscountPercent IS NOT NULL OR DiscountAmount IS NOT NULL)
);

INSERT INTO Discount ([Description], ProductId, [StartDate], [EndDate], DiscountPercent, DiscountAmount)
VALUES ('Big Sale', (SELECT Id FROM Product WHERE [Name] = 'Icarus'), '6-8-2022', '10-4-2022', 20.0, NULL)
