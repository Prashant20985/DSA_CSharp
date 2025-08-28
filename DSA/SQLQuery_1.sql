-- JOINS

-- 1. INNER JOIN: List all orders with customer names
SELECT c.CustomerName, o.OrderID, o.TotalAmount, o.OrderDate
FROM Orders o 
INNER JOIN Customers c ON c.CustomerID = o.CustomerID;

-- 2. LEFT JOIN: Show all customers and their orders (even those without orders)
SELECT c.CustomerName, o.OrderID, o.TotalAmount
FROM Customers c 
LEFT JOIN Orders o ON o.CustomerID = c.CustomerID;

-- Right Join: Show all orders and customers
SELECT c.CustomerName, o.OrderID, o.TotalAmount
FROM Orders o
RIGHT JOIN Customers c ON o.CustomerID = c.CustomerID;

-- Full Outer Join
SELECT c.CustomerName, o.OrderID
FROM Orders o
FULL OUTER JOIN 
Customers c ON c.CustomerID = o.CustomerID;

SELECT c.CustomerName, o.OrderID
FROM Orders o
LEFT JOIN 
Customers c ON c.CustomerID = o.CustomerID
UNION
SELECT c.CustomerName, o.OrderID
FROM Orders o
RIGHT JOIN
Customers c ON c.CustomerID = o.CustomerID;

-- Cross Join
SELECT c.CustomerName, p.ProductName
FROM Customers c
CROSS JOIN Products p;

-- Get all orders of a customer with employee details
SELECT c.CustomerName, o.OrderID, e.EmployeeName
From Customers c
JOIN Orders o ON o.CustomerID = c.CustomerID
JOIN Employees e ON o.EmployeeID = e.EmployeeID;

--Find orders with product deltails
SELECT o.OrderID, p.ProductName, od.Quantity, od.Price
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID;

-- Customers with No Orders 
SELECT * FROM 
Customers c 
Left JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL;

-- Employess and their Managers Self Join 
SELECT e.EmployeeName As Employee, m.EmployeeName AS Manager
From Employees e 
LEFT JOIN Employees m ON e.EmployeeID = m.ManagerID;

-- All Products Ordered By Customer Alice Smith
SELECT c.CustomerName, p.ProductName, o.OrderID 
FROM Orders o
JOIN OrderDetails od ON od.OrderID = o.OrderID
JOIN Customers c on c.CustomerID = o.CustomerID
JOIN Products p on p.ProductID = od.ProductID
WHERE c.CustomerName = 'Alice Smith';

-- Get all employess and orders they processed even if no orders 
SELECT e.EmployeeName, o.OrderID
FROM Employees e 
LEFT JOIN Orders o ON e.EmployeeID = o.EmployeeID;

-- List all customer and any orders from 2025
SELECT c.CustomerName, o.OrderID, o.OrderDate
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate >= '2025-01-01' OR o.OrderDate IS NULL

-- Aggregate Fundtions

-- Count Total Customer
SELECT COUNT(*) FROM Customers;

-- Find total orders per customer and Order By order count
SELECT c.CustomerID, c.CustomerName , COUNT(o.OrderID) As OrderCount
FROM Orders o
JOIN Customers c On c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CustomerName
ORDER By OrderCount;

-- Find Total Sales Amount
SELECT SUM(TotalAmount) As TotalSales FROM Orders;

-- Avg order Value
SELECT AVG(TotalAmount) AS AvgOrderVal From Orders;

-- Most Expensive Product
SELECT MAX(UnitPrice) MostExpensiveProduc FROM Products;

-- Cheapest Product in electroanics category
SELECT MIN(UnitPrice) AS MinPrice
FROM Products
WHERE Category = 'Electronics';

-- Total Quantity Sold per product 
SELECT SUM(Quantity) AS TotalQuantity, ProductID
FROM OrderDetails 
GROUP By ProductID;

-- Customer who have spent more than 1000
SELECT  CustomerID, SUM(TotalAmount) AS TotalSpent
FROM Orders o
GROUP BY CustomerID
HAVING SUM(o.TotalAmount) > 1000;

-- Avg price per category
SELECT AVG(UnitPrice) AS AvgPrice, Category
FROM Products
GROUP BY Category;

-- Total Order Per Employee
SELECT EmployeeID, COUNT(OrderID) AS TotalOrders
FROM Orders
GROUP By EmployeeID;

-- Subquery: A quesry inside another query, used in where, from and select
-- Runs once before the outer query.

-- Customers who have placed order
SELECT CustomerID, CustomerName
From Customers
WHERE CustomerID IN (SELECT DISTINCT CustomerID From Orders);

-- Produce More expensive than the avg price
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) From Products);

-- Find Most expensive product details
SELECT *
FROM Products
WHERE UnitPrice = (SELECT MAX(UnitPrice) From Products);

-- Orders Above the avg order value
SELECT OrderID, TotalAmount
FROM Orders
WHERE TotalAmount > (SELECT AVG(TotalAmount) From Orders);

-- Customers who ordered Laptops
SELECT c.CustomerName
From Customers c
WHERE CustomerID IN (
    SELECT o.CustomerID
    FROM Orders o
    JOIN OrderDetails od ON od.OrderID = o.OrderID
    JOIN Products p On p.ProductID = od.ProductID
    WHERE p.ProductName = 'Laptop'
);

-- Employees Who did not handle any orders in January 2025
SELECT EmployeeName
FROM Employees
WHERE EmployeeID NOT IN (
    SELECT DISTINCT EmployeeID 
    FROM Orders
    where OrderDate BETWEEN '2025-01-01' AND '2025-01-31'
)

-- Products Never Ordered
SELECT ProductName
FROM Products
WHERE ProductID IN (
    SELECT DISTINCT ProductID
    FROM OrderDetails
);

-- Highest Spending Customer 
SELECT CustomerName
FROM Customers
WHERE CustomerID = (
    SELECT TOP 1 CustomerID
    FROM Orders
    GROUP BY CustomerID
    ORDER BY SUM(TotalAmount) DESC
)

-- Order Conatining more than 5 items
SELECT OrderID 
FROM Orders 
Where OrderId IN (
    SELECT OrderID
    FROM OrderDetails
    GROUP BY OrderID
    HAVING SUM(Quantity) > 5
)

Select * from OrderDetails;

-- Categories with AVG price > 500
SELECT DISTINCT Category
FROM Products
WHERE Category IN (
    SELECT Category
    FROM Products
    GROUP By Category
    HAVING AVG(UnitPrice) > 500
)

SELECT DISTINCT Category FROM Products
GROUP BY Category
HAVING AVG(UnitPrice) > 100

-- Corelated Subqueries: Runs once for each row in the outer quesry,
-- Can use values from the outer query inside the subquery
-- Slower than normal subquery 

-- 1. Customers whose total spending is above average spending
SELECT CustomerName
FROM Customers c
WHERE (
    SELECT SUM(TotalAmount)
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
) > (SELECT AVG(TotalAmount) FROM Orders);

-- 2. Products priced above the category average
SELECT ProductName, UnitPrice, Category
FROM Products p1
WHERE UnitPrice > (
    SELECT AVG(UnitPrice)
    FROM Products p2
    WHERE p2.Category = p1.Category
);

-- 3. Orders with more items than the average order quantity
SELECT OrderID
FROM Orders o
WHERE (
    SELECT SUM(Quantity)
    FROM OrderDetails od
    WHERE od.OrderID = o.OrderID
) > (
    SELECT AVG(TotalQty)
    FROM (
        SELECT SUM(Quantity) AS TotalQty
        FROM OrderDetails
        GROUP BY OrderID
    ) sub
);

-- 4. Customers who ordered more than once
SELECT CustomerName
FROM Customers c
WHERE (
    SELECT COUNT(*)
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
) > 1;

-- 5. Employees who handled orders with value above $2000
SELECT EmployeeName
FROM Employees e
WHERE EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.EmployeeID = e.EmployeeID
    AND o.TotalAmount > 2000
);

-- 6. Products that are the most expensive in their category
SELECT ProductName, Category, UnitPrice
FROM Products p1
WHERE UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products p2
    WHERE p2.Category = p1.Category
);

-- 7. Customers whose first order was in 2024
SELECT CustomerName
FROM Customers c
WHERE (
    SELECT MIN(OrderDate)
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
) BETWEEN '2024-01-01' AND '2024-12-31';

-- 8. Orders that contain at least one Electronics product
SELECT OrderID
FROM Orders o
WHERE EXISTS (
    SELECT 1
    FROM OrderDetails od
    JOIN Products p ON od.ProductID = p.ProductID
    WHERE od.OrderID = o.OrderID
    AND p.Category = 'Electronics'
);

-- Like/Conatins

-- 9. Customers who never ordered "Smartphone"
SELECT CustomerName
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
    WHERE o.CustomerID = c.CustomerID
    AND p.ProductName = 'Smartphone'
);

-- 10. Employees who processed orders in multiple months
SELECT EmployeeName
FROM Employees e
WHERE (
    SELECT COUNT(DISTINCT FORMAT(OrderDate, 'yyyy-MM'))
    FROM Orders o
    WHERE o.EmployeeID = e.EmployeeID
) > 1;


-- 1. Customers whose name starts with 'A'
SELECT * FROM Customers
WHERE CustomerName LIKE 'A%';

-- 2. Customers whose name ends with 'n'
SELECT * FROM Customers
WHERE CustomerName LIKE '%n';

-- 3. Customers whose name contains 'Smith'
SELECT * FROM Customers
WHERE CustomerName LIKE '%Smith%';

-- 4. Products containing 'phone'
SELECT * FROM Products
WHERE ProductName LIKE '%phone%';

-- 5. Products with 5-letter names
SELECT * FROM Products
WHERE ProductName LIKE '_____';

-- 6. Orders from customers with 'son' in their name
SELECT o.*
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE c.CustomerName LIKE '%son%';

-- 7. Products where the second letter is 'a'
SELECT * FROM Products
WHERE ProductName LIKE '_a%';

-- 8. Customers in cities starting with 'New'
SELECT * FROM Customers
WHERE City LIKE 'New%';

-- 9. CONTAINS example (SQL Server full-text)
SELECT * FROM Products
WHERE CONTAINS(ProductName, 'Laptop OR Tablet');

-- 10. Orders with comments containing 'urgent'
SELECT * FROM Orders
WHERE CONTAINS(Comments, 'urgent');

-- 1. Customers whose names start with 'A'
SELECT * FROM Customers
WHERE CustomerName LIKE 'A%';

-- 2. Customers whose names end with 'son'
SELECT * FROM Customers
WHERE CustomerName LIKE '%son';

-- 3. Customers whose names contain 'li'
SELECT * FROM Customers
WHERE CustomerName LIKE '%li%';

-- 4. Customers with second letter 'o'
SELECT * FROM Customers
WHERE CustomerName LIKE '_o%';

-- 5. Products in category containing 'Electro'
SELECT * FROM Products
WHERE Category LIKE '%Electro%';

-- 6. Customers with names NOT starting with 'J'
SELECT * FROM Customers
WHERE CustomerName NOT LIKE 'J%';

-- 7. Find names with '%' literally
SELECT * FROM Customers
WHERE CustomerName LIKE '%!%%' ESCAPE '!';

-- 8. Employees whose last names have 5 letters
SELECT * FROM Employees
WHERE EmployeeName LIKE '_____';

-- 9. Orders where OrderID starts with '10'
SELECT * FROM Orders
WHERE CAST(OrderID AS VARCHAR) LIKE '10%';

-- 10. Products whose name starts and ends with same letter
SELECT * FROM Products
WHERE LEFT(ProductName,1) = RIGHT(ProductName,1);

-- Data Completeness
-- Count validation
SELECT COUNT(*) FROM source_table;
SELECT COUNT(*) FROM target_table;

-- Missing records
SELECT id FROM source_table
EXCEPT
SELECT id FROM target_table;

-- Data Quality
-- NULL check
SELECT * FROM orders WHERE order_date IS NULL;

-- Duplicate check
SELECT emp_id, COUNT(*) 
FROM employee 
GROUP BY emp_id 
HAVING COUNT(*) > 1;
Data Transformation
    
-- Validate calculated columns
SELECT salary_usd, salary_inr 
FROM emp 
WHERE salary_inr != salary_usd*80;
Referential Integrity
    
-- Check orphan records
SELECT cust_id 
FROM sales 
WHERE cust_id NOT IN (SELECT cust_id FROM dim_customer);

-- Incremental Load
-- Check newly loaded data
SELECT COUNT(*) 
FROM target_table 
WHERE load_date = CURRENT_DATE;

-- SCD Validation    
-- Ensure active records have NULL end_date
SELECT * 
FROM dim_customer 
WHERE current_flag='Y' AND end_date IS NOT NULL;

