using CsvHelper.Configuration;

namespace ESFA.DC.ILR.DataStore.Export.Mappers
{
    public class DefaultTableClassMap<T> : ClassMap<T>
    {
        public DefaultTableClassMap()
        {
            AutoMap();
        }
    }
}
