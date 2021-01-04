create table dbo.Departments
(
DepartmentID bigint IDENTITY(1,1) NOT NULL,
DepartmentName varchar (1000)
)

select * from dbo.Departments

insert into dbo.Departments Values ('Finance')

insert into dbo.Departments Values ('IT')