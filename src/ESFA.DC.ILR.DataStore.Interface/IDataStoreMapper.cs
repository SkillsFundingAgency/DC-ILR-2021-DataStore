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
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreMapper
    {
        void MapProcessingInformationData(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext);

        void MapValidLearnerData(IDataStoreCache cache, IMessage message, IEnumerable<string> validLearnRefNumbers);

        void MapInvalidLearnerData(IDataStoreCache cache, ILooseMessage message, IEnumerable<string> invalidLearnRefNumbers);

        void MapALBData(IDataStoreCache cache, ALBGlobal albGlobal);

        void MapFM25Data(IDataStoreCache cache, FM25Global fm25Global);

        void MapFM35Data(IDataStoreCache cache, FM35Global fm35Global);

        void MapFM36Data(IDataStoreCache cache, FM36Global fm36Global);

        void MapFM70Data(IDataStoreCache cache, FM70Global fm70Global);

        void MapFM81Data(IDataStoreCache cache, FM81Global fm81Global);

        void MapFM36HistoryData(IDataStoreCache cache, FM36Global fm36Global, IDataStoreContext dataStoreContext);

        void MapValidationData(IDataStoreCache cache, IDataStoreContext dataStoreContext, ILooseMessage message, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules);

        void MapESFFundingData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, FM70Global fm70Global);
    }
}
