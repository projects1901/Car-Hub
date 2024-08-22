CREATE PROCEDURE CalculateCommissionReport
AS
BEGIN
	-- Temporary table to store commission results
	CREATE TABLE #CommissionReport (
		SalesmanID INT
		,CarBrand VARCHAR(50)
		,CarClass CHAR(1)
		,TotalCommission DECIMAL(10, 2)
		);

	-- Calculate commissions
	INSERT INTO #CommissionReport (
		SalesmanID
		,CarBrand
		,CarClass
		,TotalCommission
		)
	SELECT S.SalesmanID
		,Sale.CarBrand
		,Sale.CarClass
		,(
			CR.FixedCommission + CASE 
				WHEN Sale.CarClass = 'A'
					THEN CR.ClassACommission / 100.0 * 25000 * Sale.NumberOfCars
				WHEN Sale.CarClass = 'B'
					THEN CR.ClassBCommission / 100.0 * 25000 * Sale.NumberOfCars
				WHEN Sale.CarClass = 'C'
					THEN CR.ClassCCommission / 100.0 * 25000 * Sale.NumberOfCars
				END
			) * Sale.NumberOfCars AS TotalCommission
	FROM Sales Sale
	JOIN CommissionRates CR ON Sale.CarBrand = CR.Brand
	JOIN Salesmen S ON Sale.SalesmanID = S.SalesmanID;

	-- Update commissions for Class A cars with additional commission
	UPDATE #CommissionReport
	SET TotalCommission = TotalCommission + (TotalCommission * 0.02)
	WHERE CarClass = 'A'
		AND SalesmanID IN (
			SELECT SalesmanID
			FROM Salesmen
			WHERE LastYearSales > 500000
			);

	-- Select the final report
	SELECT S.[Name]
		,SUM(CR.TotalCommission) AS 'Total Commission'
	FROM #CommissionReport CR
	JOIN Salesmen S ON CR.SalesmanID = S.SalesmanID
	GROUP BY S.[Name];

	-- Breakdown of the Report
	SELECT S.[Name]
		,CR.CarBrand
		,CR.CarClass
		,CR.TotalCommission
	FROM #CommissionReport CR
	JOIN Salesmen S ON CR.SalesmanID = S.SalesmanID;

	-- Clean up
	DROP TABLE #CommissionReport;
END;