using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearningDeliveryClassMap : ClassMap<LearningDelivery>
    {
        public ValidLearningDeliveryClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.AimSeqNumber);
            Map(m => m.LearnAimRef);
            Map(m => m.AimType);
            Map(m => m.LearnStartDate);
            Map(m => m.OrigLearnStartDate);
            Map(m => m.LearnPlanEndDate);
            Map(m => m.FundModel);
            Map(m => m.ProgType);
            Map(m => m.FworkCode);
            Map(m => m.PwayCode);
            Map(m => m.StdCode);
            Map(m => m.PartnerUKPRN);
            Map(m => m.DelLocPostCode);
            Map(m => m.AddHours);
            Map(m => m.PriorLearnFundAdj);
            Map(m => m.OtherFundAdj);
            Map(m => m.ConRefNumber);
            Map(m => m.EPAOrgID);
            Map(m => m.EmpOutcome);
            Map(m => m.CompStatus);
            Map(m => m.LearnActEndDate);
            Map(m => m.WithdrawReason);
            Map(m => m.Outcome);
            Map(m => m.AchDate);
            Map(m => m.OutGrade);
            Map(m => m.SWSupAimId);
            Map(m => m.PHours);
            Map(m => m.LSDPostcode);
        }
    }
}
