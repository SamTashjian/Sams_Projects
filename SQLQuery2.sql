select *
from Customers
	inner join Orders 
		on Customers.CustomerID = Orders.CustomerID
where Customers.CustomerID = 'AROUT'

select Orders.OrderID, OrderDate, [Order Details].UnitPrice, Products.UnitPrice, [Order Details].Quantity, [Order Details].Discount, Products.ProductName
from Orders	
	inner join [Order Details]
		on Orders.OrderID = [Order Details].OrderID
			inner join Products
				on [Order Details].ProductID = Products.ProductID


				