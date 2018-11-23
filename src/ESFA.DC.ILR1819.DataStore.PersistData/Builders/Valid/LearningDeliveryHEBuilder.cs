using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Valid
{
    public class LearningDeliveryHEBuilder
    {
        public static LearningDeliveryHE BuildValidHERecord(
            int ukprn,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryHE heRecord)
        {
            return new LearningDeliveryHE
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DOMICILE = learningDelivery.LearningDeliveryHEEntity.DOMICILE,
                ELQ = learningDelivery.LearningDeliveryHEEntity.ELQNullable,
                FUNDCOMP = learningDelivery.LearningDeliveryHEEntity.FUNDCOMP,
                FUNDLEV = learningDelivery.LearningDeliveryHEEntity.FUNDLEV,
                GROSSFEE = learningDelivery.LearningDeliveryHEEntity.GROSSFEENullable,
                HEPostCode = learningDelivery.LearningDeliveryHEEntity.HEPostCode,
                MODESTUD = learningDelivery.LearningDeliveryHEEntity.MODESTUD,
                MSTUFEE = learningDelivery.LearningDeliveryHEEntity.MSTUFEE,
                NETFEE = learningDelivery.LearningDeliveryHEEntity.NETFEENullable,
                NUMHUS = learningDelivery.LearningDeliveryHEEntity.NUMHUS,
                PCFLDCS = learningDelivery.LearningDeliveryHEEntity.PCFLDCSNullable,
                PCOLAB = learningDelivery.LearningDeliveryHEEntity.PCOLABNullable,
                PCSLDCS = learningDelivery.LearningDeliveryHEEntity.PCSLDCSNullable,
                PCTLDCS = learningDelivery.LearningDeliveryHEEntity.PCTLDCSNullable,
                QUALENT3 = learningDelivery.LearningDeliveryHEEntity.QUALENT3,
                SEC = learningDelivery.LearningDeliveryHEEntity.SECNullable,
                SOC2000 = learningDelivery.LearningDeliveryHEEntity.SOC2000Nullable,
                SPECFEE = learningDelivery.LearningDeliveryHEEntity.SPECFEE,
                SSN = learningDelivery.LearningDeliveryHEEntity.SSN,
                STULOAD = learningDelivery.LearningDeliveryHEEntity.STULOADNullable,
                TYPEYR = learningDelivery.LearningDeliveryHEEntity.TYPEYR,
                UCASAPPID = learningDelivery.LearningDeliveryHEEntity.UCASAPPID,
                YEARSTU = learningDelivery.LearningDeliveryHEEntity.YEARSTU
            };
        }
    }
}
