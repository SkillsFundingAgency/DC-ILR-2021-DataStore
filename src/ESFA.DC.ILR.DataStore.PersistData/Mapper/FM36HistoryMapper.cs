using System.Collections.Generic;
using System.Linq;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class FM36HistoryMapper : IFM36HistoryMapper
    {
        public void MapData(IDataStoreCache cache, FM36Global fm36Global, IDataStoreContext dataStoreContext)
        {
            cache.AddRange(BuildAppsEarningsHistory(fm36Global, dataStoreContext.CollectionPeriod, dataStoreContext.CollectionYear));
        }

        public List<AppsEarningsHistory> BuildAppsEarningsHistory(FM36Global fm36Global, string returnCode, string year)
        {
            return fm36Global?
                .Learners?
                .SelectMany(l => l.HistoricEarningOutputValues.Select(ho =>
                new AppsEarningsHistory
                {
                    UKPRN = fm36Global.UKPRN,
                    CollectionReturnCode = returnCode,
                    CollectionYear = year,
                    LatestInYear = true,
                    LearnRefNumber = l.LearnRefNumber,
                    ULN = l.ULN,
                    AppIdentifier = ho.AppIdentifierOutput,
                    AppProgCompletedInTheYearInput = ho.AppProgCompletedInTheYearOutput,
                    BalancingProgAimPaymentsInTheYear = null,
                    CompletionProgaimPaymentsInTheYear = null,
                    DaysInYear = ho.HistoricDaysInYearOutput,
                    FworkCode = ho.HistoricFworkCodeOutput,
                    HistoricEffectiveTNPStartDateInput = ho.HistoricEffectiveTNPStartDateOutput,
                    HistoricEmpIdEndWithinYear = ho.HistoricEmpIdEndWithinYearOutput,
                    HistoricEmpIdStartWithinYear = ho.HistoricEmpIdStartWithinYearOutput,
                    HistoricLearnDelProgEarliestACT2DateInput = ho.HistoricLearnDelProgEarliestACT2DateOutput,
                    HistoricLearner1618StartInput = ho.HistoricLearner1618AtStartOutput,
                    HistoricPMRAmount = ho.HistoricPMRAmountOutput,
                    HistoricTNP1Input = ho.HistoricTNP1Output,
                    HistoricTNP2Input = ho.HistoricTNP2Output,
                    HistoricTNP3Input = ho.HistoricTNP3Output,
                    HistoricTNP4Input = ho.HistoricTNP4Output,
                    HistoricTotal1618UpliftPaymentsInTheYearInput = ho.HistoricTotal1618UpliftPaymentsInTheYear,
                    HistoricVirtualTNP3EndOfTheYearInput = ho.HistoricVirtualTNP3EndofThisYearOutput,
                    HistoricVirtualTNP4EndOfTheYearInput = ho.HistoricVirtualTNP4EndofThisYearOutput,
                    OnProgProgAimPaymentsInTheYear = null,
                    ProgrammeStartDateIgnorePathway = ho.HistoricProgrammeStartDateIgnorePathwayOutput,
                    ProgrammeStartDateMatchPathway = ho.HistoricProgrammeStartDateMatchPathwayOutput,
                    ProgType = ho.HistoricProgTypeOutput,
                    PwayCode = ho.HistoricPwayCodeOutput,
                    STDCode = ho.HistoricSTDCodeOutput,
                    TotalProgAimPaymentsInTheYear = ho.HistoricTotalProgAimPaymentsInTheYear,
                    UptoEndDate = ho.HistoricUptoEndDateOutput
                })).ToList() ?? new List<AppsEarningsHistory>();
        }
    }
}
