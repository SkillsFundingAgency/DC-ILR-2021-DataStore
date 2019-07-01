using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM25Mapper
    {
        IDataStoreCache MapData(FM25Global fm25Global);
    }
}
