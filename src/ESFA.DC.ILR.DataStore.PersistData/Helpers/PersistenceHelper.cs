using System;
using System.Data.SqlClient;

namespace ESFA.DC.ILR.DataStore.PersistData.Helpers
{
    public static class PersistenceHelper
    {
        public static SqlParameter AddWithNullableValue(this SqlParameterCollection collection, string parameterName, object value)
        {
            return collection.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}
