using System;
using System.Collections;
using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Model
{
    public class DataStoreCache : IDataStoreCache
    {
        private readonly Dictionary<Type, IList> _dictionary = new Dictionary<Type, IList>();

        public void Add<T>(T model)
        {
           Lookup<T>().Add(model);
        }

        public void AddRange<T>(IEnumerable<T> range)
        {
            var list = Lookup<T>();

            foreach (var model in range)
            {
                list.Add(model);
            }
        }

        public IEnumerable<T> Get<T>()
        {
            return Lookup<T>() as List<T>;
        }

        private IList Lookup<T>()
        {
            if (_dictionary.TryGetValue(typeof(T), out IList list))
            {
                return list;
            }

            _dictionary.Add(typeof(T), new List<T>());
            return Lookup<T>();
        }
    }
}
