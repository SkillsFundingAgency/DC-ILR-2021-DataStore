using System.Collections.Generic;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.Model.Funding;
using ESFA.DC.ILR.DataStore.Model.History;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class DataStoreMapper : IDataStoreMapper
    {
        private readonly IProcessingInformationDataMapper _processingInformationDataMapper;
        private readonly IValidHeaderDataMapper _validHeaderDataMapper;
        private readonly IInvalidHeaderDataMapper _invalidHeaderDataMapper;
        private readonly IValidLearnerDataMapper _validLearnerDataMapper;
        private readonly IInvalidLearnerDataMapper _invalidLearnerDataMapper;
        private readonly IALBMapper _albMapper;
        private readonly IFM25Mapper _fm25Mapper;
        private readonly IFM35Mapper _fm35Mapper;
        private readonly IFM36Mapper _fm36Mapper;
        private readonly IFM70Mapper _fm70Mapper;
        private readonly IFM81Mapper _fm81Mapper;
        private readonly IFM36HistoryMapper _fm36HistoryMapper;
        private readonly IValidationDataMapper _validationDataMapper;

        public DataStoreMapper(
            IProcessingInformationDataMapper processingInformationDataMapper,
            IValidHeaderDataMapper validHeaderDataMapper,
            IInvalidHeaderDataMapper invalidHeaderDataMapper,
            IValidLearnerDataMapper validLearnerDataMapper,
            IInvalidLearnerDataMapper invalidLearnerDataMapper,
            IALBMapper albMapper,
            IFM25Mapper fm25Mapper,
            IFM35Mapper fm35Mapper,
            IFM36Mapper fm36Mapper,
            IFM70Mapper fm70Mapper,
            IFM81Mapper fm81Mapper,
            IFM36HistoryMapper fm36HistoryMapper,
            IValidationDataMapper validationDataMapper)
        {
            _processingInformationDataMapper = processingInformationDataMapper;
            _validHeaderDataMapper = validHeaderDataMapper;
            _invalidHeaderDataMapper = invalidHeaderDataMapper;
            _validLearnerDataMapper = validLearnerDataMapper;
            _invalidLearnerDataMapper = invalidLearnerDataMapper;
            _albMapper = albMapper;
            _fm25Mapper = fm25Mapper;
            _fm35Mapper = fm35Mapper;
            _fm36Mapper = fm36Mapper;
            _fm70Mapper = fm70Mapper;
            _fm81Mapper = fm81Mapper;
            _fm36HistoryMapper = fm36HistoryMapper;
            _validationDataMapper = validationDataMapper;
        }

        public ProcessingInformationData MapProcessingInformationData(IDataStoreContext dataStoreContext) => _processingInformationDataMapper.MapData(dataStoreContext);

        public ValidHeaderData MapValidHeaderData(IMessage message) => _validHeaderDataMapper.MapData(message);

        public InvalidHeaderData MapInvalidHeaderData(IMessage message) => _invalidHeaderDataMapper.MapData(message);

        public ValidLearnerData MapValidLearnerData(IMessage message, IEnumerable<string> validLearnRefNumbers) => _validLearnerDataMapper.MapLearnerData(message, validLearnRefNumbers);

        public InvalidLearnerData MapInvalidLearnerData(IMessage message, IEnumerable<string> validLearnRefNumbers) => _invalidLearnerDataMapper.MapInvalidLearnerData(message, validLearnRefNumbers);

        public ALBData MapALBData(ALBGlobal albGlobal) => _albMapper.MapALBData(albGlobal);

        public FM25Data MapFM25Data(FM25Global fm25Global) => _fm25Mapper.MapData(fm25Global);

        public FM35Data MapFM35Data(FM35Global fm35Global) => _fm35Mapper.MapData(fm35Global);

        public FM36Data MapFM36Data(FM36Global fm36Global) => _fm36Mapper.MapData(fm36Global);

        public FM70Data MapFM70Data(FM70Global fm70Global) => _fm70Mapper.MapData(fm70Global);

        public FM81Data MapFM81Data(FM81Global fm81Global) => _fm81Mapper.MapData(fm81Global);

        public FM36HistoryData MapFM36HistoryData(FM36Global fm36Global, IDataStoreContext dataStoreContext) => _fm36HistoryMapper.MapData(fm36Global, dataStoreContext);

        public ValidationData MapValidationData(IDataStoreContext dataStoreContext, IMessage message, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules)
            => _validationDataMapper.MapData(dataStoreContext, validationErrors, rules, message);
    }
}
