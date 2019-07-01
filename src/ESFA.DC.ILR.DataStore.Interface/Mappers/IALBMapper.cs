using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IALBMapper
    {
        IDataStoreCache MapALBData(ALBGlobal albGlobal);
    }
}
