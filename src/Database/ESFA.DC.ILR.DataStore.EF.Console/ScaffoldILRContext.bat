dotnet.exe ef dbcontext scaffold "Server=.\;Database=ESFA.DC.ILR.DataStore.Database;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -c ILR2021_DataStoreEntities --schema dbo --schema Rulebase --schema Valid --force --startup-project . --project ..\ESFA.DC.ILR2021.DataStore.EF --verbose

pause