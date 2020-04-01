using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.Export.Mappers.Valid
{
    public class ValidDPOutcomeClassMap : DefaultTableClassMap<DPOutcome>
    {
        public ValidDPOutcomeClassMap()
        {
            Map(m => m.LearnerDestinationandProgression).Ignore();
        }
    }
}
