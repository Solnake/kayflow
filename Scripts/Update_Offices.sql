INSERT INTO dbo.OfficeTerritorialUnit(OfficeID, TerritorialUnitID)
select u.OfficeID, u.TerritorialUnitID
from TerritorialUnit u
left join OfficeTerritorialUnit t on t.TerritorialUnitID=u.TerritorialUnitID
WHERE
	t.OfficeID is null


update ex
set
	ex.OfficeID = e.OfficeID
from Expense ex
join Employee e on e.EmployeeID=ex.EmployeeID
where
	ex.OfficeID is null
    