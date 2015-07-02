declare @SetID uniqueidentifier
	set @SetID = newid()
begin tran
	if not exists (select 'x' from ValueSet where SetName='Так/Ні')
    begin
      INSERT INTO dbo.ValueSet(ValueSetID, SetName) 
      VALUES (@SetID, 'Так/Ні');
    
      INSERT INTO dbo.DocumentValue(ValueSetID, DocValue, DocColor) 
      select @SetID, 'Так', -16728064
      union 
      select @SetID, 'Ні', -65536	
	end
if (@@ERROR!=0)
	rollback tran
commit tran
	