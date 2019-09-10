-- 1. 
SELECT CustomerID, CompanyName
FROM Customers
ORDER BY CustomerID;

-- 2. 
SELECT TOP (1) EmployeeID
FROM Employees 
ORDER BY HireDate DESC;

-- 3. 
SELECT DISTINCT Country
FROM Customers
ORDER BY Country;

-- 4. 
SELECT CompanyName
FROM Customers
WHERE City in ('Berlin', 'London', 'Madrid', 'Bruxelles', 'Paris')
ORDER BY CustomerID DESC;

-- 5. 
SELECT CustomerID
FROM Orders
WHERE RequiredDate BETWEEN '19960901' AND '19960930'
ORDER BY CustomerID;

-- 6. 

SELECT ContactName
FROM Customers
WHERE Phone Like '(171)%77%' And Fax Like '(171)%50';

-- 7. 
SELECT City, COUNT(CustomerID) 'CustomerCount'
FROM Customers
WHERE Country in ('Sweden', 'Norway', 'Denmark')
GROUP BY City;

-- 8.  
SELECT Country, CountCust 'CustomerCount'
FROM (SELECT Country, COUNT(CustomerID) as CountCust
		FROM Customers
		GROUP BY Country) A
WHERE CountCust >= 10
ORDER By CountCust DESC;

-- 9. 
SELECT CustomerID, F_AVG 'FreightAVG'
FROM (SELECT CustomerID, ROUND(AVG(Freight), 0) as F_AVG
		FROM Orders
		WHERE ShipCountry in ('UK', 'Canada')
		GROUP BY CustomerID) A
WHERE F_AVG NOT BETWEEN 10 and 99
ORDER BY F_AVG DESC;

-- 10. 
SELECT TOP (1) EmployeeID
FROM (SELECT TOP (2) EmployeeID, HireDate
		FROM Employees
		ORDER BY HireDate DESC) A
ORDER BY HireDate;

-- 11. 
SELECT EmployeeID
FROM Employees 
ORDER BY HireDate DESC
	OFFSET 1 ROW
	FETCH NEXT 1 ROWS ONLY;

-- 12.
SELECT CustomerID, F_Sum as 'FreightSum'
FROM (SELECT CustomerID, Sum(Freight) as F_SUM
	  FROM Orders
	  WHERE ShippedDate BETWEEN '19970615' AND '19970630'
	  GROUP BY CustomerID) A
WHERE F_SUM > (SELECT AVG(Freight) FROM Orders)
ORDER BY FreightSum;

--13.
SELECT TOP(3) CustomerID, ShipCountry, ([Order Details].UnitPrice*[Order Details].Quantity - [Order Details].Discount)'OrderPrice'
FROM Orders INNER JOIN [Order Details] ON Orders.OrderID = [Order Details].OrderID
WHERE OrderDate >= '19970901' AND ShipCountry in ('Argentina', 'Bolivia', 'Brazil', 'Chile', 'Colombia', 
'Ecuador', 'French Guiana', 'Guyana', 'Paraguay', 'Peru', 'Falkland Islands', 'Suriname', 'Uruguay', 'Venezuela')
Order By OrderPrice DESC;

-- 14. 
SELECT DISTINCT s.CompanyName, Min(UnitPrice) 'MinPrice', Max(UnitPrice) 'MaxPrice'
FROM dbo.Products AS p INNER JOIN dbo.Suppliers AS s ON p.SupplierID = s.SupplierID
GROUP BY s.CompanyName
ORDER BY s.CompanyName;

-- 15.
SELECT Customers.CompanyName 'Customer', CONCAT(Employees.FirstName, ' ', Employees.LastName) 'Employee'
FROM ((Customers INNER JOIN Orders On Customers.CustomerID = Orders.CustomerID) 
	INNER JOIN Employees ON Orders.EmployeeID = Employees.EmployeeID)
	INNER JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID
WHERE Customers.City = 'London' AND Employees.City = 'London' AND Shippers.CompanyName = 'Speedy Express';

-- 16.
SELECT Products.ProductName, Products.UnitsInStock, Suppliers.ContactName, Suppliers.Phone
From (Products INNER JOIN Suppliers ON Products.SupplierID=Suppliers.SupplierID) INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
WHERE Categories.CategoryName in ('Beverages', 'Seafood') AND Products.Discontinued = 0 AND Products.UnitsInStock < 20
Order By Products.UnitsInStock;