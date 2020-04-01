using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM35Mapper
    {
        void MapData(IDataStoreCache cache, FM35Global fm35Global);
    }
}
