create table dbo.Employees(
EmployeeID bigint identity(1,1) NOT NULL,
EmployeeName varchar(1000),
Department varchar(1000),
MailID varchar(1000),
DOJ date
)

select * from dbo.Employees

insert into dbo.Employees values ('Sam', 'Finance', 'sam123@gmail.com', '5-11-2019')

insert into dbo.Employees values ('Bob', 'IT', 'bob123@gmail.com', '4-10-2019')