using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase
{
    public class AECLearningDeliveryPeriodClassMap : ClassMap<AEC_LearningDelivery_Period>
    {
        public AECLearningDeliveryPeriodClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.Period);
            Map(m => m.DisadvFirstPayment);
            Map(m => m.DisadvSecondPayment);
            Map(m => m.FundLineType);
            Map(m => m.InstPerPeriod);
            Map(m => m.LDApplic1618FrameworkUpliftBalancingPayment);
            Map(m => m.LDApplic1618FrameworkUpliftCompletionPayment);
            Map(m => m.LDApplic1618FrameworkUpliftOnProgPayment);
            Map(m => m.LearnDelContType);
            Map(m => m.LearnDelFirstEmp1618Pay);
            Map(m => m.LearnDelFirstProv1618Pay);
            Map(m => m.LearnDelLevyNonPayInd);
            Map(m => m.LearnDelSecondEmp1618Pay);
            Map(m => m.LearnDelSecondProv1618Pay);
            Map(m => m.LearnDelSEMContWaiver);
            Map(m => m.LearnDelSFAContribPct);
            Map(m => m.LearnSuppFund);
            Map(m => m.LearnSuppFundCash);
            Map(m => m.MathEngBalPayment);
            Map(m => m.MathEngBalPct);
            Map(m => m.MathEngOnProgPayment);
            Map(m => m.MathEngOnProgPct);
            Map(m => m.ProgrammeAimBalPayment);
            Map(m => m.ProgrammeAimCompletionPayment);
            Map(m => m.ProgrammeAimOnProgPayment);
            Map(m => m.ProgrammeAimProgFundIndMaxEmpCont);
            Map(m => m.ProgrammeAimProgFundIndMinCoInvest);
            Map(m => m.ProgrammeAimTotProgFund);
            Map(m => m.LearnDelLearnAddPayment);
        }
    }
}
