dotnet.exe ef dbcontext scaffold "Server=.\;Database=ESFA.DC.ILR.DataStore.Database;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -c ILR2021_DataStoreEntitiesInvalid --schema Invalid --force --startup-project . --project ..\ESFA.DC.ILR2021.DataStore.EF.Invalid --verbose	