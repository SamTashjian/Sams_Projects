SELECT        Customers.CustomerID,Orders.CustomerID, Customers.CompanyName, Orders.OrderDate
FROM            Customers INNER JOIN
                         Orders ON Customers.CustomerID = Orders.CustomerID
						 Order By Customers.CustomerID

select Customers.ContactName, Customers.Address, Customers.City, Customers.Country, Customers.PostalCode, Customers.Region
from Customers
where Customers.Country = 'usa' and Customers.Region ='wa'
order by Customers.ContactName

select Customers.Region, count (*) as c 
from Customers where Customers.Country = 'usa'
group by Customers.Region
order by c 


select Products.ProductName, Products.UnitPrice, Orders.CustomerID, [Order Details].Quantity, [Order Details].UnitPrice
from Orders
	inner join [Order Details]
		on Orders.OrderID = [Order Details].OrderID
			inner join Products
				on [Order Details].ProductID = Products.ProductID
				order by Orders.CustomerID

select Employees.FirstName, Territories.TerritoryDescription
from Employees
	inner join EmployeeTerritories
		on Employees.EmployeeID = EmployeeTerritories.EmployeeID
	inner join Territories
		on EmployeeTerritories.TerritoryID = Territories.TerritoryID
		where Territories.TerritoryDescription like 'B%'
select*
from Customers
	inner join CustomerCustomerDemo		
		on Customers.CustomerID	= CustomerCustomerDemo.CustomerID
	inner join CustomerDemographics
		on CustomerCustomerDemo.CustomerTypeID = CustomerDemographics.CustomerTypeID


