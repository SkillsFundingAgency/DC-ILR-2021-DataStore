using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Extension
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
