using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IESFFundingMapper
    {
        void MapData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, FM70Global albGlobal);
    }
}
