using System;

namespace ESFA.DC.ILR.DataStore.PersistData.Helpers
{
    public class TypeHelper
    {
        public static TR PeriodValueTypeHandler<TR>(object value)
        {
            if (value == null)
            {
                return default(TR);
            }

            if (typeof(TR) == typeof(bool?) || typeof(TR) == typeof(bool))
            {
                return value.ToString() == "0.0" ? (TR)(object)false : (TR)(object)true;
            }

            if (typeof(TR) == typeof(int?) || typeof(TR) == typeof(int))
            {
                return (TR)(object)Convert.ToInt32(value);
            }

            if (typeof(TR) == typeof(long?) || typeof(TR) == typeof(long))
            {
                return (TR)(object)Convert.ToInt64(value);
            }

            return (TR)value;
        }
    }
}
