using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM25Mapper
    {
        void MapData(IDataStoreCache cache, FM25Global fm25Global);
    }
}
