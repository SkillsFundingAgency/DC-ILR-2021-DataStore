using System.Collections.Generic;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model.File;
using ESFA.DC.ILR1819.DataStore.Model.Funding;
using ESFA.DC.ILR1819.DataStore.Model.History;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreMapper
    {
        ProcessingInformationData MapProcessingInformationData(IDataStoreContext dataStoreContext);

        ValidHeaderData MapValidHeaderData(IMessage message);

        InvalidHeaderData MapInvalidHeaderData(IMessage message);

        ValidLearnerData MapValidLearnerData(IMessage message, IEnumerable<string> validLearnRefNumbers);

        InvalidLearnerData MapInvalidLearnerData(IMessage message, IEnumerable<string> invalidLearnRefNumbers);

        ALBData MapALBData(ALBGlobal albGlobal);

        FM25Data MapFM25Data(FM25Global fm25Global);

        FM35Data MapFM35Data(FM35Global fm35Global);

        FM36Data MapFM36Data(FM36Global fm36Global);

        FM70Data MapFM70Data(FM70Global fm70Global);

        FM81Data MapFM81Data(FM81Global fm81Global);

        FM36HistoryData MapFM36HistoryData(FM36Global fm36Global, IDataStoreContext dataStoreContext);

        ValidationData MapValidationData(IDataStoreContext dataStoreContext, IMessage message, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules);
    }
}
