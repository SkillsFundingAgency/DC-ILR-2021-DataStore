using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreMapper
    {
        IDataStoreCache MapProcessingInformationData(IDataStoreContext dataStoreContext);

        IDataStoreCache MapValidLearnerData(IMessage message, IEnumerable<string> validLearnRefNumbers);

        IDataStoreCache MapInvalidLearnerData(IMessage message, IEnumerable<string> invalidLearnRefNumbers);

        IDataStoreCache MapALBData(ALBGlobal albGlobal);

        IDataStoreCache MapFM25Data(FM25Global fm25Global);

        IDataStoreCache MapFM35Data(FM35Global fm35Global);

        IDataStoreCache MapFM36Data(FM36Global fm36Global);

        IDataStoreCache MapFM70Data(FM70Global fm70Global);

        IDataStoreCache MapFM81Data(FM81Global fm81Global);

        IDataStoreCache MapFM36HistoryData(FM36Global fm36Global, IDataStoreContext dataStoreContext);

        IDataStoreCache MapValidationData(IDataStoreContext dataStoreContext, IMessage message, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules);
    }
}
