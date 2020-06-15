Create proc GetPrferencbyname
@name nvarchar
as begin select * from dbo.UserPreference
where userEmail = @name
end