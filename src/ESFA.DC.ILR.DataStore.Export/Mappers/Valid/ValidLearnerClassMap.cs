using CsvHelper.Configuration;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidLearnerClassMap : ClassMap<Learner>
    {
        public ValidLearnerClassMap()
        {
            Map(m => m.UKPRN);
            Map(m => m.LearnRefNumber);
            Map(m => m.PrevLearnRefNumber);
            Map(m => m.PrevUKPRN);
            Map(m => m.PMUKPRN);
            Map(m => m.ULN);
            Map(m => m.FamilyName);
            Map(m => m.GivenNames);
            Map(m => m.DateOfBirth);
            Map(m => m.Ethnicity);
            Map(m => m.Sex);
            Map(m => m.LLDDHealthProb);
            Map(m => m.NINumber);
            Map(m => m.PriorAttain);
            Map(m => m.Accom);
            Map(m => m.ALSCost);
            Map(m => m.PlanLearnHours);
            Map(m => m.PlanEEPHours);
            Map(m => m.MathGrade);
            Map(m => m.EngGrade);
            Map(m => m.PostcodePrior);
            Map(m => m.Postcode);
            Map(m => m.AddLine1);
            Map(m => m.AddLine2);
            Map(m => m.AddLine3);
            Map(m => m.AddLine4);
            Map(m => m.TelNo);
            Map(m => m.Email);
            Map(m => m.CampId);
        }
    }
}
