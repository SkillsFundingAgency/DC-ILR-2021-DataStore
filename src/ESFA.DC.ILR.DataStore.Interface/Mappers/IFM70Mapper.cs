using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IFM70Mapper
    {
        void MapData(IDataStoreCache cache, FM70Global fm70Global);
    }
}
