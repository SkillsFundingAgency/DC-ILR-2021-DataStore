using System;
using System.Collections.Generic;

namespace ESFA.DC.ILR.DataStore.PersistData.Builders.Extension
{
    public static class IEnumerableExtensions
    {
        public static void NullSafeForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    action(item);
                }
            }
        }
    }
}
