select LastName, FirstName
from Employee
--order by LastName
order by LastName desc

select LastName, FirstName, HireDate, City
from Employee
	inner join Location
		on Employee.LocationID = Location.LocationID
order by City, HireDate desc

select *
from Employee
where [Status] is not null
order by [Status] desc

--expressiona
select ProductName, RetailPrice, ROUND((RetailPrice * 1.07), 2) as PriceWithTax
from CurrentProducts

select FirstName + ' ' + LastName as [Employee Name], 
HireDate,
convert (nvarchar, HireDate, 101) as 'mm/dd/yyyy',
convert (nvarchar, HireDate, 103) as 'dd/mm/yyyy',
convert (nvarchar, HireDate, 106) as 'European Letter',
convert (nvarchar, HireDate, 107) as 'Business Letter',
convert (nvarchar, HireDate, 110) as 'mm-dd-yy'
from Employee
order by HireDate desc

select ProductName, RetailPrice, ROUND((RetailPrice * 1.07), 2) as PriceWithTax
from CurrentProducts
order by PriceWithTax desc


--aggregates
select EmpID, 
	sum(Amount) as TotalGrantAmount,
	count(Amount) as NumberOfGrants
from [Grant]
where EmpID is not null
group by EmpID
order by TotalGrantAmount

select  
	sum(Amount) as TotalGrantAmount,
	count(Amount) as NumberOfGrants,
	max(Amount) as MaxGrant
from [Grant]
where EmpID is not null

select e.EmpID, e.FirstName, e.LastName, max(Amount) as MaxAmount
from [Grant] g
	inner join Employee e
		on g.EmpID = e.EmpID
group by e.EmpID, e.FirstName, e.LastName

select count(*) from [Grant]
select count(EmpID) from [Grant]

select count(*) - count(EmpID) as GrantsWithoutEmployee
from [Grant]

select e.EmpID, e.FirstName, e.LastName, max(Amount) as MaxAmount
from [Grant] g
	inner join Employee e
		on g.EmpID = e.EmpID
group by e.EmpID, e.FirstName, e.LastName
having MAX(Amount) > 20000
order by e.LastName

select l.City, count(EmpID) as TotalEmployees
from Employee e
	inner join Location l
		on e.LocationID = l.LocationID
where City <> 'Boston'
group by City
having count(EmpID) > 2
order by TotalEmployees