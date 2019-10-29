using Microsoft.EntityFrameworkCore;

namespace ESFA.DC.ILR.DataStore.Export.Export
{
    public static class DbContextExtension
    {
        public static string GetTableName<T>(this DbContext context)
        {
            var mapping = context.Model.FindEntityType(typeof(T)).Relational();
            return mapping.TableName;
        }
    }
}
