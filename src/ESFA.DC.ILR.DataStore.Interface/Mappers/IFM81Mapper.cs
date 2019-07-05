using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM81Mapper
    {
        void MapData(IDataStoreCache cache, FM81Global fm81Global);
    }
}
