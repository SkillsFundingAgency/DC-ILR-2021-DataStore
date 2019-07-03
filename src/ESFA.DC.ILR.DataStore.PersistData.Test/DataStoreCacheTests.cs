using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test
{
    public class DataStoreCacheTests
    {
        [Fact]
        public void Get_Test()
        {
            var dataStoreCache = new DataStoreCache();

            dataStoreCache.Add(1);
            dataStoreCache.Add(2);
            dataStoreCache.AddRange(new List<int>() { 3, 4, 5 });

            dataStoreCache.Add("string");

            dataStoreCache.Get<int>().Should().Contain(5);
            dataStoreCache.Get<int>().Should().BeOfType<List<int>>();

            dataStoreCache.Get<int>().Should().ContainInOrder(1, 2, 3, 4, 5);
            dataStoreCache.Get<string>().Should().HaveCount(1);

            dataStoreCache.Get<long>().Should().BeEmpty();
        }
    }
}
