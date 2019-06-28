using System.Collections.Generic;

namespace ESFA.DC.ILR.DataStore.Model.Interface
{
    public interface IDataStoreCache
    {
        void Add<T>(T model);

        void AddRange<T>(IEnumerable<T> range);

        IEnumerable<T> Get<T>();
    }
}
