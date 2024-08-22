CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    SalesmanID INT,
    CarBrand VARCHAR(50),
    CarClass CHAR(1),
    NumberOfCars INT,
    FOREIGN KEY (SalesmanID) REFERENCES Salesmen(SalesmanID)
);