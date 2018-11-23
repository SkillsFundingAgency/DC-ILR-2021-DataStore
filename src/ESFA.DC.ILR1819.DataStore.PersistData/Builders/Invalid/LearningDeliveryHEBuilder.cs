using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Invalid
{
    public class LearningDeliveryHEBuilder
    {
        public static LearningDeliveryHE BuildInvalidHERecord(
            IMessage ilr,
            ILearner learner,
            ILearningDelivery learningDelivery,
            ILearningDeliveryHE heRecord,
            int learningDeliveryHEId)
        {
            return new LearningDeliveryHE
            {
                LearningDeliveryHE_Id = learningDeliveryHEId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
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
                PCFLDCS = (double?)learningDelivery.LearningDeliveryHEEntity.PCFLDCSNullable,
                PCOLAB = (double?)learningDelivery.LearningDeliveryHEEntity.PCOLABNullable,
                PCSLDCS = (double?)learningDelivery.LearningDeliveryHEEntity.PCSLDCSNullable,
                PCTLDCS = (double?)learningDelivery.LearningDeliveryHEEntity.PCTLDCSNullable,
                QUALENT3 = learningDelivery.LearningDeliveryHEEntity.QUALENT3,
                SEC = learningDelivery.LearningDeliveryHEEntity.SECNullable,
                SOC2000 = learningDelivery.LearningDeliveryHEEntity.SOC2000Nullable,
                SPECFEE = learningDelivery.LearningDeliveryHEEntity.SPECFEE,
                SSN = learningDelivery.LearningDeliveryHEEntity.SSN,
                STULOAD = (double?)learningDelivery.LearningDeliveryHEEntity.STULOADNullable,
                TYPEYR = learningDelivery.LearningDeliveryHEEntity.TYPEYR,
                UCASAPPID = learningDelivery.LearningDeliveryHEEntity.UCASAPPID,
                YEARSTU = learningDelivery.LearningDeliveryHEEntity.YEARSTU
            };
        }
    }
}
