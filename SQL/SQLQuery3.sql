--insert a region
create procedure RegionInsert(
	@RegionDiscription nchar(50),
	@RegionId int output
	) as 
begin 
	insert into Region (RegionDescription)
	values (@RegionDiscription);

	set @RegionId = SCOPE_IDENTITY();
end

--declare our output variable and execute the stored proc
declare @Id int 
exec RegionInsert 'NorthEast', @Id output --note: output is used on output param
select @Id -- return just the id
select * from Region -- return the whole table

--update a region
go
create procedure RegionUpdate(
	@RegionDescription nchar(50),
	@RegionId int
	) as 
begin
	update Region
	set RegionDescription = @RegionDescription
	where RegionID = @RegionId
end

--execute the statement, nothing special just pass parameters
exec RegionUpdate 'Bobs Barn', 5
select *
from Region

--
go

create procedure RegionDelete(
	@RegionId int 
)as
begin
	delete Region
	where RegionID = @RegionId;
end

exec RegionDelete 5
select * 
from Region

