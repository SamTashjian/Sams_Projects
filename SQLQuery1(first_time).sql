USE Northwind
GO

select *
from Employees

select *
from Territories

select *
from EmployeeTerritories

select FirstName, LastName, Title, TerritoryDescription, RegionDescription
from Employees
	inner join EmployeeTerritories
		on Employees.EmployeeID = EmployeeTerritories.EmployeeID
	inner join Territories
		on Territories.TerritoryID = EmployeeTerritories.TerritoryID
	inner join Region
		on Territories.RegionID = Region.RegionID

select OrderID, CustomerID, Orders.EmployeeID, LastName, FirstName
from Orders
	left join Employees
		on Orders.EmployeeID = Employees.EmployeeID

select OrderID, CustomerID, Orders.EmployeeID, LastName, FirstName
from Orders
	inner join Employees
		on Orders.EmployeeID = Employees.EmployeeID