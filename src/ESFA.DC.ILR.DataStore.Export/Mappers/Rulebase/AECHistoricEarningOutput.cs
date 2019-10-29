using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECHistoricEarningOutputClassMap : ClassMap<AEC_HistoricEarningOutput>
    {
        public AECHistoricEarningOutputClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AppIdentifierOutput);
            Map(m => m.AppProgCompletedInTheYearOutput);
            Map(m => m.HistoricDaysInYearOutput);
            Map(m => m.HistoricEffectiveTNPStartDateOutput);
            Map(m => m.HistoricEmpIdEndWithinYearOutput);
            Map(m => m.HistoricEmpIdStartWithinYearOutput);
            Map(m => m.HistoricFworkCodeOutput);
            Map(m => m.HistoricLearner1618AtStartOutput);
            Map(m => m.HistoricPMRAmountOutput);
            Map(m => m.HistoricProgrammeStartDateIgnorePathwayOutput);
            Map(m => m.HistoricProgrammeStartDateMatchPathwayOutput);
            Map(m => m.HistoricProgTypeOutput);
            Map(m => m.HistoricPwayCodeOutput);
            Map(m => m.HistoricSTDCodeOutput);
            Map(m => m.HistoricTNP1Output);
            Map(m => m.HistoricTNP2Output);
            Map(m => m.HistoricTNP3Output);
            Map(m => m.HistoricTNP4Output);
            Map(m => m.HistoricTotal1618UpliftPaymentsInTheYear);
            Map(m => m.HistoricTotalProgAimPaymentsInTheYear);
            Map(m => m.HistoricULNOutput);
            Map(m => m.HistoricUptoEndDateOutput);
            Map(m => m.HistoricVirtualTNP3EndofThisYearOutput);
            Map(m => m.HistoricVirtualTNP4EndofThisYearOutput);
            Map(m => m.HistoricLearnDelProgEarliestACT2DateOutput);
        }
    }
}
