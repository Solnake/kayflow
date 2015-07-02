select a.MeteringDate, o.OfficeName, co.OfficeName
	, u.UnitName
from Act a 
join Office o on o.OfficeID=a.OfficeID
join TerritorialUnit u on u.TerritorialUnitID=a.TerritorialUnitID
join Office co on co.OfficeID=u.OfficeID
where
	a.OfficeID!=u.OfficeID

update a
set
	a.OfficeID = u.OfficeID	
from Act a 
join Office o on o.OfficeID=a.OfficeID
join TerritorialUnit u on u.TerritorialUnitID=a.TerritorialUnitID
join Office co on co.OfficeID=u.OfficeID
where
	a.OfficeID!=u.OfficeID

select a.MeteringDate, o.OfficeName, co.OfficeName
	, c.CategoryID, c.CategoryName
from Act a 
join Office o on o.OfficeID=a.OfficeID
join Category c on c.CategoryID=a.CategoryID
join Office co on co.OfficeID=c.OfficeID
where
	a.OfficeID!=c.OfficeID

select a.MeteringDate, o.OfficeName, co.OfficeName
	, c.CategoryID, c.CategoryName
	, rc.CategoryID, rc.CategoryName
from Act a 
join Office o on o.OfficeID=a.OfficeID
join Category c on c.CategoryID=a.CategoryID
join Office co on co.OfficeID=c.OfficeID
join Category rc on rc.CategoryName=c.CategoryName and rc.OfficeID=o.OfficeID
where
	a.OfficeID!=c.OfficeID

update a
set
	a.CategoryID=rc.CategoryID
from Act a 
join Office o on o.OfficeID=a.OfficeID
join Category c on c.CategoryID=a.CategoryID
join Office co on co.OfficeID=c.OfficeID
join Category rc on rc.CategoryName=c.CategoryName and rc.OfficeID=o.OfficeID
where
	a.OfficeID!=c.OfficeID



