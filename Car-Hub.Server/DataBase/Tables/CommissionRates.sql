CREATE TABLE CommissionRates (
    Brand VARCHAR(50) PRIMARY KEY,
    FixedCommission DECIMAL(10, 2),
    ClassACommission DECIMAL(5, 2),
    ClassBCommission DECIMAL(5, 2),
    ClassCCommission DECIMAL(5, 2)
);