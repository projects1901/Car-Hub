--Note below contains Combined table required for creating Commission Report with some data

-- Table for Salesmen
CREATE TABLE Salesmen (
    SalesmanID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    LastYearSales DECIMAL(10, 2)
);

-- Table for Sales
CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    SalesmanID INT,
    CarBrand VARCHAR(50),
    CarClass CHAR(1),
    NumberOfCars INT,
    FOREIGN KEY (SalesmanID) REFERENCES Salesmen(SalesmanID)
);

-- Table for Commission Rates
CREATE TABLE CommissionRates (
    Brand VARCHAR(50) PRIMARY KEY,
    FixedCommission DECIMAL(10, 2),
    ClassACommission DECIMAL(5, 2),
    ClassBCommission DECIMAL(5, 2),
    ClassCCommission DECIMAL(5, 2)
);


-- Insert Salesmen
INSERT INTO Salesmen (Name, LastYearSales) VALUES
('John Smith', 490000),
('Richard Porter', 1000000),
('Tony Grid', 650000);

-- Insert Commission Rates
INSERT INTO CommissionRates (Brand, FixedCommission, ClassACommission, ClassBCommission, ClassCCommission) VALUES
('Audi', 800, 8, 6, 4),
('Jaguar', 750, 6, 5, 3),
('Land Rover', 850, 7, 5, 4),
('Renault', 400, 5, 3, 2);


-- Insert Sales Data
INSERT INTO Sales (SalesmanID, CarBrand, CarClass, NumberOfCars) VALUES
-- Salesman 1
(1, 'Audi', 'A', 1),
(1, 'Jaguar', 'A', 3),
(1, 'Land Rover', 'B', 0),
(1, 'Renault', 'A', 6),
(1, 'Audi', 'B', 2),
(1, 'Jaguar', 'B', 4),
(1, 'Land Rover', 'B', 2),
(1, 'Renault', 'B', 2),
(1, 'Audi', 'C', 3),
(1, 'Jaguar', 'C', 6),
(1, 'Land Rover', 'C', 1),
(1, 'Renault', 'C', 1),

-- Salesman 2
(2, 'Audi', 'A', 0),
(2, 'Jaguar', 'A', 5),
(2, 'Land Rover', 'A', 5),
(2, 'Renault', 'A', 3),
(2, 'Audi', 'B', 0),
(2, 'Jaguar', 'B', 4),
(2, 'Land Rover', 'B', 2),
(2, 'Renault', 'B', 2),
(2, 'Audi', 'C', 0),
(2, 'Jaguar', 'C', 2),
(2, 'Land Rover', 'C', 1),
(2, 'Renault', 'C', 1),

-- Salesman 3
(3, 'Audi', 'A', 4),
(3, 'Jaguar', 'A', 2),
(3, 'Land Rover', 'A', 1),
(3, 'Renault', 'A', 6),
(3, 'Audi', 'B', 2),
(3, 'Jaguar', 'B', 7),
(3, 'Land Rover', 'B', 2),
(3, 'Renault', 'B', 3),
(3, 'Audi', 'C', 0),
(3, 'Jaguar', 'C', 1),
(3, 'Land Rover', 'C', 3),
(3, 'Renault', 'C', 1);