using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Helpers
{
    public static class PeriodisedValueHelper
    {
        private static ConcurrentDictionary<Type, ConcurrentDictionary<int, PropertyInfo>> _propertyInfoCache = new ConcurrentDictionary<Type, ConcurrentDictionary<int, PropertyInfo>>();

        public static O GetPeriodValue<T, O>(this T periodisedValue, int period)
        {
            var value = periodisedValue?.GetType().GetProperty(PersistDataConstants.PeriodPrefix + period)?.GetValue(periodisedValue);

            return TypeHelper.PeriodValueTypeHandler<O>(value);
        }
    }
}
