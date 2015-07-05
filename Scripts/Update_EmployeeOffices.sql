INSERT INTO dbo.EmployeeOffices(EmployeeID, OfficeID)
select e.EmployeeID, e.OfficeID
from Employee e
left join EmployeeOffices o on e.EmployeeID=o.EmployeeID
where
	o.OfficeID is null