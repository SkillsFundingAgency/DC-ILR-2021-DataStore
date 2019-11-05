using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
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

namespace ESFA.DC.ILR.DataStore.PersistData
{
    public class DataStoreMapper : IDataStoreMapper
    {
        private readonly IProcessingInformationDataMapper _processingInformationDataMapper;
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
        private readonly IESFFundingMapper _esfFundingMapper;

        public DataStoreMapper(
            IProcessingInformationDataMapper processingInformationDataMapper,
            IValidLearnerDataMapper validLearnerDataMapper,
            IInvalidLearnerDataMapper invalidLearnerDataMapper,
            IALBMapper albMapper,
            IFM25Mapper fm25Mapper,
            IFM35Mapper fm35Mapper,
            IFM36Mapper fm36Mapper,
            IFM70Mapper fm70Mapper,
            IFM81Mapper fm81Mapper,
            IFM36HistoryMapper fm36HistoryMapper,
            IValidationDataMapper validationDataMapper,
            IESFFundingMapper esfFundingMapper)
        {
            _processingInformationDataMapper = processingInformationDataMapper;
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
            _esfFundingMapper = esfFundingMapper;
        }

        public void MapProcessingInformationData(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext) => _processingInformationDataMapper.MapData(cache, referenceDataVersions, dataStoreContext);

        public void MapValidLearnerData(IDataStoreCache cache, IMessage message, IEnumerable<string> validLearnRefNumbers) => _validLearnerDataMapper.MapLearnerData(cache, message, validLearnRefNumbers);

        public void MapInvalidLearnerData(IDataStoreCache cache, ILooseMessage message, IEnumerable<string> validLearnRefNumbers) => _invalidLearnerDataMapper.MapInvalidLearnerData(cache, message, validLearnRefNumbers);

        public void MapALBData(IDataStoreCache cache, ALBGlobal albGlobal) => _albMapper.MapALBData(cache, albGlobal);

        public void MapFM25Data(IDataStoreCache cache, FM25Global fm25Global) => _fm25Mapper.MapData(cache, fm25Global);

        public void MapFM35Data(IDataStoreCache cache, FM35Global fm35Global) => _fm35Mapper.MapData(cache, fm35Global);

        public void MapFM36Data(IDataStoreCache cache, FM36Global fm36Global) => _fm36Mapper.MapData(cache, fm36Global);

        public void MapFM70Data(IDataStoreCache cache, FM70Global fm70Global) => _fm70Mapper.MapData(cache, fm70Global);

        public void MapFM81Data(IDataStoreCache cache, FM81Global fm81Global) => _fm81Mapper.MapData(cache, fm81Global);

        public void MapFM36HistoryData(IDataStoreCache cache, FM36Global fm36Global, IDataStoreContext dataStoreContext) => _fm36HistoryMapper.MapData(cache, fm36Global, dataStoreContext);

        public void MapValidationData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules)
            => _validationDataMapper.MapData(cache, dataStoreContext, validationErrors, rules, message);

        public void MapESFFundingData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IMessage message, FM70Global fm70Global) => _esfFundingMapper.MapData(cache, dataStoreContext, message, fm70Global);
    }
}
