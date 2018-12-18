using System.Collections.Generic;
using System.Linq;
using ESFA.DC.Data.AppsEarningsHistory.Model;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public class FM36HistoryMapper : IFM36HistoryMapper
    {
        public FM36HistoryMapper()
        {
        }

        public IEnumerable<AppsEarningsHistory> MapAppsEarningsHistory(FM36Global fm36Global, string returnCode, string year)
        {
            return fm36Global.Learners
                .SelectMany(l => l.HistoricEarningOutputValues.Select(ho =>
                new AppsEarningsHistory
                {
                    UKPRN = fm36Global.UKPRN,
                    CollectionReturnCode = "R" + returnCode,
                    CollectionYear = year,
                    LatestInYear = true,
                    LearnRefNumber = l.LearnRefNumber,
                    ULN = l.ULN,
                    AppIdentifier = ho.AppIdentifierOutput,
                    AppProgCompletedInTheYearInput = ho.AppProgCompletedInTheYearOutput,
                    BalancingProgAimPaymentsInTheYear = ho.BalancingProgAimPaymentsInTheYear,
                    CompletionProgaimPaymentsInTheYear = ho.CompletionProgAimPaymentsInTheYear,
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
                    OnProgProgAimPaymentsInTheYear = ho.OnProgProgAimPaymentsInTheYear,
                    ProgrammeStartDateIgnorePathway = ho.HistoricProgrammeStartDateIgnorePathwayOutput,
                    ProgrammeStartDateMatchPathway = ho.HistoricProgrammeStartDateMatchPathwayOutput,
                    ProgType = ho.HistoricProgTypeOutput,
                    PwayCode = ho.HistoricPwayCodeOutput,
                    STDCode = ho.HistoricSTDCodeOutput,
                    TotalProgAimPaymentsInTheYear = ho.HistoricTotalProgAimPaymentsInTheYear,
                    UptoEndDate = ho.HistoricUptoEndDateOutput
                }));
        }
    }
}
