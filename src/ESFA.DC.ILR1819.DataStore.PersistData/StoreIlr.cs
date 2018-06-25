using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.JobContext.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public sealed class StoreIlr : IStoreIlr
    {
        private readonly SqlConnection _connection;

        private readonly SqlTransaction _transaction;

        private readonly IJobContextMessage _jobContextMessage;

        public StoreIlr(
            SqlConnection connection,
            SqlTransaction transaction,
            IJobContextMessage jobContextMessage)
        {
            _connection = connection;
            _transaction = transaction;
            _jobContextMessage = jobContextMessage;
        }

        public async Task StoreAsync(IMessage ilr, List<string> validLearners, CancellationToken cancellationToken)
        {
            Task fileDetailsTask = ProcessFileDetails(ilr, cancellationToken);

            await Task.WhenAll(
                ProcessLearners(ilr, validLearners, cancellationToken),
                ProcessLearnerDestinationsAndProgressions(ilr, validLearners, cancellationToken),
                fileDetailsTask);

            //await ProcessLearners(ilr, learnersValid);
            //await ProcessLearnerDestinationsAndProgressions(ilr, learnersValid);
            //await fileDetailsTask;
        }

        private async Task ProcessLearners(
            IMessage ilr,
            List<string> learnersValid,
            CancellationToken cancellationToken)
        {
            List<EF.Valid.Learner> recordsValidLearners = new List<EF.Valid.Learner>();
            List<EF.Invalid.Learner> recordsInvalidLearners = new List<EF.Invalid.Learner>();

            List<EF.Valid.AppFinRecord> recordsValidAppFinRecords = new List<EF.Valid.AppFinRecord>();
            List<EF.Invalid.AppFinRecord> recordsInvalidAppFinRecords = new List<EF.Invalid.AppFinRecord>();

            List<EF.Valid.LearningDelivery> recordsValidLearningDeliverys = new List<EF.Valid.LearningDelivery>();
            List<EF.Invalid.LearningDelivery> recordsInvalidLearningDeliverys = new List<EF.Invalid.LearningDelivery>();

            List<EF.Valid.ContactPreference> recordsValidContactPreferences = new List<EF.Valid.ContactPreference>();
            List<EF.Invalid.ContactPreference> recordsInvalidContactPreferences = new List<EF.Invalid.ContactPreference>();

            List<EF.Valid.EmploymentStatusMonitoring> recordsValidEmploymentStatusMonitorings = new List<EF.Valid.EmploymentStatusMonitoring>();
            List<EF.Invalid.EmploymentStatusMonitoring> recordsInvalidEmploymentStatusMonitorings = new List<EF.Invalid.EmploymentStatusMonitoring>();

            List<EF.Valid.LearnerEmploymentStatu> recordsValidLearnerEmploymentStatus = new List<EF.Valid.LearnerEmploymentStatu>();
            List<EF.Invalid.LearnerEmploymentStatu> recordsInvalidLearnerEmploymentStatus = new List<EF.Invalid.LearnerEmploymentStatu>();

            List<EF.Valid.LearnerFAM> recordsValidLearnerFams = new List<EF.Valid.LearnerFAM>();
            List<EF.Invalid.LearnerFAM> recordsInvalidLearnerFams = new List<EF.Invalid.LearnerFAM>();

            List<EF.Valid.LearningDeliveryFAM> recordsValidLearnerDeliveryFams = new List<EF.Valid.LearningDeliveryFAM>();
            List<EF.Invalid.LearningDeliveryFAM> recordsInvalidLearnerDeliveryFams = new List<EF.Invalid.LearningDeliveryFAM>();

            List<EF.Valid.LearnerHE> recordsValidLearnerHes = new List<EF.Valid.LearnerHE>();
            List<EF.Invalid.LearnerHE> recordsInvalidLearnerHes = new List<EF.Invalid.LearnerHE>();

            List<EF.Valid.LearningDeliveryHE> recordsValidLearningDeliveryHes = new List<EF.Valid.LearningDeliveryHE>();
            List<EF.Invalid.LearningDeliveryHE> recordsInvalidLearningDeliveryHes = new List<EF.Invalid.LearningDeliveryHE>();

            List<EF.Valid.LearningDeliveryWorkPlacement> recordsValidLearningDeliveryWorkPlacements = new List<EF.Valid.LearningDeliveryWorkPlacement>();
            List<EF.Invalid.LearningDeliveryWorkPlacement> recordsInvalidLearningDeliveryWorkPlacements = new List<EF.Invalid.LearningDeliveryWorkPlacement>();

            List<EF.Valid.LearnerHEFinancialSupport> recordsValidLearnerHefinancialSupports = new List<EF.Valid.LearnerHEFinancialSupport>();
            List<EF.Invalid.LearnerHEFinancialSupport> recordsInvalidLearnerHefinancialSupports = new List<EF.Invalid.LearnerHEFinancialSupport>();

            List<EF.Valid.LLDDandHealthProblem> recordsValidLlddandHealthProblems = new List<EF.Valid.LLDDandHealthProblem>();
            List<EF.Invalid.LLDDandHealthProblem> recordsInvalidLlddandHealthProblems = new List<EF.Invalid.LLDDandHealthProblem>();

            List<EF.Valid.ProviderSpecDeliveryMonitoring> recordsValidProviderSpecDeliveryMonitorings = new List<EF.Valid.ProviderSpecDeliveryMonitoring>();
            List<EF.Invalid.ProviderSpecDeliveryMonitoring> recordsInvalidProviderSpecDeliveryMonitorings = new List<EF.Invalid.ProviderSpecDeliveryMonitoring>();

            List<EF.Valid.ProviderSpecLearnerMonitoring> recordsValidProviderSpecLearnerMonitorings = new List<EF.Valid.ProviderSpecLearnerMonitoring>();
            List<EF.Invalid.ProviderSpecLearnerMonitoring> recordsInvalidProviderSpecLearnerMonitorings = new List<EF.Invalid.ProviderSpecLearnerMonitoring>();

            int learnerId = 1;
            int learnerDeliveryId = 1;
            int learnerEmploymentStatusId = 1;
            int learnerEmploymentStatusMonitoringId = 1;
            int learningDeliveryHEId = 1;
            int learnerDeliveryFamId = 1;
            int appFinRecordId = 1;
            int learningDeliveryWorkPlacementId = 1;
            int learnerFAMId = 1;
            int learnerHEId = 1;
            int learnerHEFinancialSupportId = 1;
            int lLDDandHealthProblemId = 1;
            int providerSpecLearnerMonitoringId = 1;
            int providerSpecDeliveryMonitoringId = 1;
            int contactPreferenceId = 1;
            int lLDDandHealthProblemID = 1;

            foreach (ILearner ilrLearner in ilr.Learners)
            {
                if (learnersValid.Contains(ilrLearner.LearnRefNumber, StringComparer.OrdinalIgnoreCase))
                {
                    recordsValidLearners.Add(new EF.Valid.Learner
                    {
                        LearnRefNumber = ilrLearner.LearnRefNumber,
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        Accom = ilrLearner.AccomNullable,
                        AddLine1 = ilrLearner.AddLine1,
                        AddLine2 = ilrLearner.AddLine2,
                        AddLine3 = ilrLearner.AddLine3,
                        AddLine4 = ilrLearner.AddLine4,
                        ALSCost = ilrLearner.ALSCostNullable,
                        CampId = ilrLearner.CampId,
                        DateOfBirth = ilrLearner.DateOfBirthNullable,
                        Email = ilrLearner.Email,
                        EngGrade = ilrLearner.EngGrade,
                        Ethnicity = ilrLearner.Ethnicity,
                        FamilyName = ilrLearner.FamilyName,
                        GivenNames = ilrLearner.GivenNames,
                        LLDDHealthProb = ilrLearner.LLDDHealthProb,
                        MathGrade = ilrLearner.MathGrade,
                        NINumber = ilrLearner.NINumber,
                        OTJHours = ilrLearner.OTJHoursNullable,
                        PlanEEPHours = ilrLearner.PlanEEPHoursNullable,
                        PlanLearnHours = ilrLearner.PlanLearnHoursNullable,
                        PMUKPRN = ilrLearner.PMUKPRNNullable,
                        Postcode = ilrLearner.Postcode,
                        PostcodePrior = ilrLearner.PostcodePrior,
                        PrevLearnRefNumber = ilrLearner.PrevLearnRefNumber,
                        PrevUKPRN = ilrLearner.PrevUKPRNNullable,
                        PriorAttain = ilrLearner.PriorAttainNullable,
                        Sex = ilrLearner.Sex,
                        TelNo = ilrLearner.TelNo,
                        ULN = ilrLearner.ULN
                    });

                    foreach (IContactPreference contactPreference in ilrLearner.ContactPreferences ?? Enumerable.Empty<IContactPreference>())
                    {
                        recordsValidContactPreferences.Add(new EF.Valid.ContactPreference
                        {
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            ContPrefCode = contactPreference.ContPrefCode,
                            ContPrefType = contactPreference.ContPrefType
                        });
                    }

                    foreach (ILearningDelivery learningDelivery in ilrLearner.LearningDeliveries)
                    {
                        recordsValidLearningDeliverys.Add(new EF.Valid.LearningDelivery
                        {
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LearnAimRef = learningDelivery.LearnAimRef,
                            AimSeqNumber = learningDelivery.AimSeqNumber,
                            AchDate = learningDelivery.AchDateNullable,
                            AddHours = learningDelivery.AddHoursNullable,
                            AimType = learningDelivery.AimType,
                            CompStatus = learningDelivery.CompStatus,
                            ConRefNumber = learningDelivery.ConRefNumber,
                            DelLocPostCode = learningDelivery.DelLocPostCode,
                            EmpOutcome = learningDelivery.EmpOutcomeNullable,
                            EPAOrgID = learningDelivery.EPAOrgID,
                            FundModel = learningDelivery.FundModel,
                            FworkCode = learningDelivery.FworkCodeNullable,
                            LearnActEndDate = learningDelivery.LearnActEndDateNullable,
                            LearnPlanEndDate = learningDelivery.LearnPlanEndDate,
                            LearnStartDate = learningDelivery.LearnStartDate,
                            OrigLearnStartDate = learningDelivery.OrigLearnStartDateNullable,
                            OtherFundAdj = learningDelivery.OtherFundAdjNullable,
                            OutGrade = learningDelivery.OutGrade,
                            Outcome = learningDelivery.OutcomeNullable,
                            PartnerUKPRN = learningDelivery.PartnerUKPRNNullable,
                            PriorLearnFundAdj = learningDelivery.PriorLearnFundAdjNullable,
                            ProgType = learningDelivery.ProgTypeNullable,
                            PwayCode = learningDelivery.PwayCodeNullable,
                            StdCode = learningDelivery.StdCodeNullable,
                            SWSupAimId = learningDelivery.SWSupAimId,
                            WithdrawReason = learningDelivery.WithdrawReasonNullable
                        });

                        foreach (IAppFinRecord learningDeliveryAppFinRecord in learningDelivery.AppFinRecords ?? Enumerable.Empty<IAppFinRecord>())
                        {
                            recordsValidAppFinRecords.Add(new EF.Valid.AppFinRecord
                            {
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                AFinAmount = learningDeliveryAppFinRecord.AFinAmount,
                                AFinCode = learningDeliveryAppFinRecord.AFinCode,
                                AFinDate = learningDeliveryAppFinRecord.AFinDate,
                                AFinType = learningDeliveryAppFinRecord.AFinType,
                                AimSeqNumber = learningDelivery.AimSeqNumber
                            });
                        }

                        foreach (ILearningDeliveryFAM learningDeliveryFam in learningDelivery.LearningDeliveryFAMs ?? Enumerable.Empty<ILearningDeliveryFAM>())
                        {
                            recordsValidLearnerDeliveryFams.Add(new EF.Valid.LearningDeliveryFAM
                            {
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
                            });
                        }

                        if (learningDelivery.LearningDeliveryHEEntity != null)
                        {
                            recordsValidLearningDeliveryHes.Add(new EF.Valid.LearningDeliveryHE
                            {
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
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
                            });
                        }

                        foreach (ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement in learningDelivery.LearningDeliveryWorkPlacements ?? Enumerable.Empty<ILearningDeliveryWorkPlacement>())
                        {
                            recordsValidLearningDeliveryWorkPlacements.Add(new EF.Valid.LearningDeliveryWorkPlacement
                            {
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHours,
                                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceMode,
                                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDate
                            });
                        }

                        foreach (IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring in learningDelivery.ProviderSpecDeliveryMonitorings ?? Enumerable.Empty<IProviderSpecDeliveryMonitoring>())
                        {
                            recordsValidProviderSpecDeliveryMonitorings.Add(new EF.Valid.ProviderSpecDeliveryMonitoring
                            {
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                ProvSpecDelMon = providerSpecDeliveryMonitoring.ProvSpecDelMon,
                                ProvSpecDelMonOccur = providerSpecDeliveryMonitoring.ProvSpecDelMonOccur,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                            });
                        }
                    }

                    foreach (ILearnerEmploymentStatus learnerEmploymentStatus in ilrLearner.LearnerEmploymentStatuses ?? Enumerable.Empty<ILearnerEmploymentStatus>())
                    {
                        foreach (IEmploymentStatusMonitoring employmentStatusMonitoring in learnerEmploymentStatus.EmploymentStatusMonitorings ?? Enumerable.Empty<IEmploymentStatusMonitoring>())
                        {
                            recordsValidEmploymentStatusMonitorings.Add(new EF.Valid.EmploymentStatusMonitoring
                            {
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                                ESMCode = employmentStatusMonitoring.ESMCode,
                                ESMType = employmentStatusMonitoring.ESMType
                            });
                        }

                        recordsValidLearnerEmploymentStatus.Add(new EF.Valid.LearnerEmploymentStatu
                        {
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            AgreeId = learnerEmploymentStatus.AgreeId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                            EmpId = learnerEmploymentStatus.EmpIdNullable,
                            EmpStat = learnerEmploymentStatus.EmpStat
                        });
                    }

                    foreach (ILearnerFAM learnerFaM in ilrLearner.LearnerFAMs ?? Enumerable.Empty<ILearnerFAM>())
                    {
                        recordsValidLearnerFams.Add(new EF.Valid.LearnerFAM
                        {
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LearnFAMCode = learnerFaM.LearnFAMCode,
                            LearnFAMType = learnerFaM.LearnFAMType
                        });
                    }

                    if (ilrLearner.LearnerHEEntity != null)
                    {
                        recordsValidLearnerHes.Add(new EF.Valid.LearnerHE
                        {
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            TTACCOM = ilrLearner.LearnerHEEntity.TTACCOMNullable,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            UCASPERID = ilrLearner.LearnerHEEntity.UCASPERID
                        });
                    }

                    foreach (ILearnerHEFinancialSupport heFinancialSupport in ilrLearner.LearnerHEEntity?.LearnerHEFinancialSupports ?? Enumerable.Empty<ILearnerHEFinancialSupport>())
                    {
                        recordsValidLearnerHefinancialSupports.Add(new EF.Valid.LearnerHEFinancialSupport
                        {
                            FINAMOUNT = heFinancialSupport.FINAMOUNT,
                            FINTYPE = heFinancialSupport.FINTYPE,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });
                    }

                    foreach (ILLDDAndHealthProblem llddAndHealthProblem in ilrLearner.LLDDAndHealthProblems ?? Enumerable.Empty<ILLDDAndHealthProblem>())
                    {
                        recordsValidLlddandHealthProblems.Add(new EF.Valid.LLDDandHealthProblem
                        {
                            LLDDandHealthProblem_ID = lLDDandHealthProblemID,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LLDDCat = llddAndHealthProblem.LLDDCat,
                            PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });

                        lLDDandHealthProblemID++;
                    }

                    foreach (IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring in ilrLearner.ProviderSpecLearnerMonitorings ?? Enumerable.Empty<IProviderSpecLearnerMonitoring>())
                    {
                        recordsValidProviderSpecLearnerMonitorings.Add(new EF.Valid.ProviderSpecLearnerMonitoring
                        {
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                            ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
                        });
                    }
                }
                else
                {
                    recordsInvalidLearners.Add(new EF.Invalid.Learner
                    {
                        Learner_Id = learnerId,
                        LearnRefNumber = ilrLearner.LearnRefNumber,
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        Accom = ilrLearner.AccomNullable,
                        AddLine1 = ilrLearner.AddLine1,
                        AddLine2 = ilrLearner.AddLine2,
                        AddLine3 = ilrLearner.AddLine3,
                        AddLine4 = ilrLearner.AddLine4,
                        ALSCost = ilrLearner.ALSCostNullable,
                        CampId = ilrLearner.CampId,
                        DateOfBirth = ilrLearner.DateOfBirthNullable,
                        Email = ilrLearner.Email,
                        EngGrade = ilrLearner.EngGrade,
                        Ethnicity = ilrLearner.Ethnicity,
                        FamilyName = ilrLearner.FamilyName,
                        GivenNames = ilrLearner.GivenNames,
                        LLDDHealthProb = ilrLearner.LLDDHealthProb,
                        MathGrade = ilrLearner.MathGrade,
                        NINumber = ilrLearner.NINumber,
                        OTJHours = ilrLearner.OTJHoursNullable,
                        PlanEEPHours = ilrLearner.PlanEEPHoursNullable,
                        PlanLearnHours = ilrLearner.PlanLearnHoursNullable,
                        PMUKPRN = ilrLearner.PMUKPRNNullable,
                        Postcode = ilrLearner.Postcode,
                        PostcodePrior = ilrLearner.PostcodePrior,
                        PrevLearnRefNumber = ilrLearner.PrevLearnRefNumber,
                        PrevUKPRN = ilrLearner.PrevUKPRNNullable,
                        PriorAttain = ilrLearner.PriorAttainNullable,
                        Sex = ilrLearner.Sex,
                        TelNo = ilrLearner.TelNo,
                        ULN = ilrLearner.ULN
                    });

                    foreach (IContactPreference contactPreference in ilrLearner.ContactPreferences ?? Enumerable.Empty<IContactPreference>())
                    {
                        recordsInvalidContactPreferences.Add(new EF.Invalid.ContactPreference
                        {
                            ContactPreference_Id = contactPreferenceId,
                            Learner_Id = learnerId,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            ContPrefCode = contactPreference.ContPrefCode,
                            ContPrefType = contactPreference.ContPrefType
                        });

                        contactPreferenceId++;
                    }

                    foreach (ILearningDelivery learningDelivery in ilrLearner.LearningDeliveries)
                    {
                        recordsInvalidLearningDeliverys.Add(new EF.Invalid.LearningDelivery
                        {
                            Learner_Id = learnerId,
                            LearningDelivery_Id = learnerDeliveryId,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LearnAimRef = learningDelivery.LearnAimRef,
                            AimSeqNumber = learningDelivery.AimSeqNumber,
                            AchDate = learningDelivery.AchDateNullable,
                            AddHours = learningDelivery.AddHoursNullable,
                            AimType = learningDelivery.AimType,
                            CompStatus = learningDelivery.CompStatus,
                            ConRefNumber = learningDelivery.ConRefNumber,
                            DelLocPostCode = learningDelivery.DelLocPostCode,
                            EmpOutcome = learningDelivery.EmpOutcomeNullable,
                            EPAOrgID = learningDelivery.EPAOrgID,
                            FundModel = learningDelivery.FundModel,
                            FworkCode = learningDelivery.FworkCodeNullable,
                            LearnActEndDate = learningDelivery.LearnActEndDateNullable,
                            LearnPlanEndDate = learningDelivery.LearnPlanEndDate,
                            LearnStartDate = learningDelivery.LearnStartDate,
                            OrigLearnStartDate = learningDelivery.OrigLearnStartDateNullable,
                            OtherFundAdj = learningDelivery.OtherFundAdjNullable,
                            OutGrade = learningDelivery.OutGrade,
                            Outcome = learningDelivery.OutcomeNullable,
                            PartnerUKPRN = learningDelivery.PartnerUKPRNNullable,
                            PriorLearnFundAdj = learningDelivery.PriorLearnFundAdjNullable,
                            ProgType = learningDelivery.ProgTypeNullable,
                            PwayCode = learningDelivery.PwayCodeNullable,
                            StdCode = learningDelivery.StdCodeNullable,
                            SWSupAimId = learningDelivery.SWSupAimId,
                            WithdrawReason = learningDelivery.WithdrawReasonNullable
                        });

                        foreach (IAppFinRecord learningDeliveryAppFinRecord in learningDelivery.AppFinRecords ?? Enumerable.Empty<IAppFinRecord>())
                        {
                            recordsInvalidAppFinRecords.Add(new EF.Invalid.AppFinRecord
                            {
                                AppFinRecord_Id = appFinRecordId,
                                LearningDelivery_Id = learnerDeliveryId,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                AFinAmount = learningDeliveryAppFinRecord.AFinAmount,
                                AFinCode = learningDeliveryAppFinRecord.AFinCode,
                                AFinDate = learningDeliveryAppFinRecord.AFinDate,
                                AFinType = learningDeliveryAppFinRecord.AFinType,
                                AimSeqNumber = learningDelivery.AimSeqNumber
                            });

                            appFinRecordId++;
                        }

                        foreach (ILearningDeliveryFAM learningDeliveryFam in learningDelivery.LearningDeliveryFAMs ?? Enumerable.Empty<ILearningDeliveryFAM>())
                        {
                            recordsInvalidLearnerDeliveryFams.Add(new EF.Invalid.LearningDeliveryFAM
                            {
                                LearningDeliveryFAM_Id = learnerDeliveryFamId,
                                LearningDelivery_Id = learnerDeliveryId,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
                            });

                            learnerDeliveryFamId++;
                        }

                        if (learningDelivery.LearningDeliveryHEEntity != null)
                        {
                            recordsInvalidLearningDeliveryHes.Add(new EF.Invalid.LearningDeliveryHE
                            {
                                LearningDeliveryHE_Id = learningDeliveryHEId,
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
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
                            });

                            learningDeliveryHEId++;
                        }

                        foreach (ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement in learningDelivery.LearningDeliveryWorkPlacements ?? Enumerable.Empty<ILearningDeliveryWorkPlacement>())
                        {
                            recordsInvalidLearningDeliveryWorkPlacements.Add(new EF.Invalid.LearningDeliveryWorkPlacement
                            {
                                LearningDeliveryWorkPlacement_Id = learningDeliveryWorkPlacementId,
                                LearningDelivery_Id = learnerDeliveryId,
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHours,
                                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceMode,
                                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDate
                            });

                            learningDeliveryWorkPlacementId++;
                        }

                        foreach (IProviderSpecDeliveryMonitoring providerSpecDeliveryMonitoring in learningDelivery.ProviderSpecDeliveryMonitorings ?? Enumerable.Empty<IProviderSpecDeliveryMonitoring>())
                        {
                            recordsInvalidProviderSpecDeliveryMonitorings.Add(new EF.Invalid.ProviderSpecDeliveryMonitoring
                            {
                                ProviderSpecDeliveryMonitoring_Id = providerSpecDeliveryMonitoringId,
                                LearningDelivery_Id = learnerDeliveryId,
                                AimSeqNumber = learningDelivery.AimSeqNumber,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                ProvSpecDelMon = providerSpecDeliveryMonitoring.ProvSpecDelMon,
                                ProvSpecDelMonOccur = providerSpecDeliveryMonitoring.ProvSpecDelMonOccur,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                            });

                            providerSpecDeliveryMonitoringId++;
                        }

                        learnerDeliveryId++;
                    }

                    foreach (ILearnerEmploymentStatus learnerEmploymentStatus in ilrLearner.LearnerEmploymentStatuses ?? Enumerable.Empty<ILearnerEmploymentStatus>())
                    {
                        recordsInvalidLearnerEmploymentStatus.Add(new EF.Invalid.LearnerEmploymentStatu
                        {
                            Learner_Id = learnerId,
                            LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            AgreeId = learnerEmploymentStatus.AgreeId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                            EmpId = learnerEmploymentStatus.EmpIdNullable,
                            EmpStat = learnerEmploymentStatus.EmpStat
                        });

                        foreach (IEmploymentStatusMonitoring employmentStatusMonitoring in learnerEmploymentStatus.EmploymentStatusMonitorings ?? Enumerable.Empty<IEmploymentStatusMonitoring>())
                        {
                            recordsInvalidEmploymentStatusMonitorings.Add(new EF.Invalid.EmploymentStatusMonitoring
                            {
                                EmploymentStatusMonitoring_Id = learnerEmploymentStatusMonitoringId,
                                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                                LearnRefNumber = ilrLearner.LearnRefNumber,
                                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                                ESMCode = employmentStatusMonitoring.ESMCode,
                                ESMType = employmentStatusMonitoring.ESMType
                            });

                            learnerEmploymentStatusMonitoringId++;
                        }

                        learnerEmploymentStatusId++;
                    }

                    foreach (ILearnerFAM learnerFaM in ilrLearner.LearnerFAMs ?? Enumerable.Empty<ILearnerFAM>())
                    {
                        recordsInvalidLearnerFams.Add(new EF.Invalid.LearnerFAM
                        {
                            LearnerFAM_Id = learnerFAMId,
                            Learner_Id = learnerId,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LearnFAMCode = learnerFaM.LearnFAMCode,
                            LearnFAMType = learnerFaM.LearnFAMType
                        });

                        learnerFAMId++;
                    }

                    if (ilrLearner.LearnerHEEntity != null)
                    {
                        recordsInvalidLearnerHes.Add(new EF.Invalid.LearnerHE
                        {
                            LearnerHE_Id = learnerHEId,
                            Learner_Id = learnerId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            TTACCOM = ilrLearner.LearnerHEEntity.TTACCOMNullable,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            UCASPERID = ilrLearner.LearnerHEEntity.UCASPERID
                        });

                        learnerHEId++;
                    }

                    foreach (ILearnerHEFinancialSupport heFinancialSupport in ilrLearner.LearnerHEEntity?.LearnerHEFinancialSupports ?? Enumerable.Empty<ILearnerHEFinancialSupport>())
                    {
                        recordsInvalidLearnerHefinancialSupports.Add(new EF.Invalid.LearnerHEFinancialSupport
                        {
                            LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                            FINAMOUNT = heFinancialSupport.FINAMOUNT,
                            FINTYPE = heFinancialSupport.FINTYPE,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });

                        learnerHEFinancialSupportId++;
                    }

                    foreach (ILLDDAndHealthProblem llddAndHealthProblem in ilrLearner.LLDDAndHealthProblems ?? Enumerable.Empty<ILLDDAndHealthProblem>())
                    {
                        recordsInvalidLlddandHealthProblems.Add(new EF.Invalid.LLDDandHealthProblem
                        {
                            LLDDandHealthProblem_Id = lLDDandHealthProblemId,
                            Learner_Id = learnerId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            LLDDCat = llddAndHealthProblem.LLDDCat,
                            PrimaryLLDD = llddAndHealthProblem.PrimaryLLDDNullable,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
                        });

                        lLDDandHealthProblemId++;
                    }

                    foreach (IProviderSpecLearnerMonitoring providerSpecLearnerMonitoring in ilrLearner.ProviderSpecLearnerMonitorings ?? Enumerable.Empty<IProviderSpecLearnerMonitoring>())
                    {
                        recordsInvalidProviderSpecLearnerMonitorings.Add(new EF.Invalid.ProviderSpecLearnerMonitoring
                        {
                            ProviderSpecLearnerMonitoring_Id = providerSpecLearnerMonitoringId,
                            Learner_Id = learnerId,
                            LearnRefNumber = ilrLearner.LearnRefNumber,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            ProvSpecLearnMon = providerSpecLearnerMonitoring.ProvSpecLearnMon,
                            ProvSpecLearnMonOccur = providerSpecLearnerMonitoring.ProvSpecLearnMonOccur
                        });

                        providerSpecLearnerMonitoringId++;
                    }

                    learnerId++;
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Invalid.AppFinRecord", recordsInvalidAppFinRecords);
                await bulkInsert.Insert("Invalid.ContactPreference", recordsInvalidContactPreferences);
                await bulkInsert.Insert("Invalid.EmploymentStatusMonitoring", recordsInvalidEmploymentStatusMonitorings);
                await bulkInsert.Insert("Invalid.Learner", recordsInvalidLearners);
                await bulkInsert.Insert("Invalid.LearnerEmploymentStatus", recordsInvalidLearnerEmploymentStatus);
                await bulkInsert.Insert("Invalid.LearnerFAM", recordsInvalidLearnerFams);
                await bulkInsert.Insert("Invalid.LearnerHE", recordsInvalidLearnerHes);
                await bulkInsert.Insert("Invalid.LearnerHEFinancialSupport", recordsInvalidLearnerHefinancialSupports);
                await bulkInsert.Insert("Invalid.LearningDelivery", recordsInvalidLearningDeliverys);
                await bulkInsert.Insert("Invalid.LearningDeliveryFAM", recordsInvalidLearnerDeliveryFams);
                await bulkInsert.Insert("Invalid.LearningDeliveryHE", recordsInvalidLearningDeliveryHes);
                await bulkInsert.Insert("Invalid.LearningDeliveryWorkPlacement", recordsInvalidLearningDeliveryWorkPlacements);
                await bulkInsert.Insert("Invalid.LLDDandHealthProblem", recordsInvalidLlddandHealthProblems);
                await bulkInsert.Insert("Invalid.ProviderSpecDeliveryMonitoring", recordsInvalidProviderSpecDeliveryMonitorings);
                await bulkInsert.Insert("Invalid.ProviderSpecLearnerMonitoring", recordsInvalidProviderSpecLearnerMonitorings);

                await bulkInsert.Insert("Valid.AppFinRecord", recordsValidAppFinRecords);
                await bulkInsert.Insert("Valid.ContactPreference", recordsValidContactPreferences);
                await bulkInsert.Insert("Valid.EmploymentStatusMonitoring", recordsValidEmploymentStatusMonitorings);
                await bulkInsert.Insert("Valid.Learner", recordsValidLearners);
                await bulkInsert.Insert("Valid.LearnerEmploymentStatus", recordsValidLearnerEmploymentStatus);
                await bulkInsert.Insert("Valid.LearnerFAM", recordsValidLearnerFams);
                await bulkInsert.Insert("Valid.LearnerHE", recordsValidLearnerHes);
                await bulkInsert.Insert("Valid.LearnerHEFinancialSupport", recordsValidLearnerHefinancialSupports);
                await bulkInsert.Insert("Valid.LearningDelivery", recordsValidLearningDeliverys);
                await bulkInsert.Insert("Valid.LearningDeliveryFAM", recordsValidLearnerDeliveryFams);
                await bulkInsert.Insert("Valid.LearningDeliveryHE", recordsValidLearningDeliveryHes);
                await bulkInsert.Insert("Valid.LearningDeliveryWorkPlacement", recordsValidLearningDeliveryWorkPlacements);
                await bulkInsert.Insert("Valid.LLDDandHealthProblem", recordsValidLlddandHealthProblems);
                await bulkInsert.Insert("Valid.ProviderSpecDeliveryMonitoring", recordsValidProviderSpecDeliveryMonitorings);
                await bulkInsert.Insert("Valid.ProviderSpecLearnerMonitoring", recordsValidProviderSpecLearnerMonitorings);
            }
        }

        private async Task ProcessFileDetails(IMessage ilr, CancellationToken cancellationToken)
        {
            DateTime nowUtc = DateTime.UtcNow;

            EF.Valid.CollectionDetail collectionDetailsValid = new EF.Valid.CollectionDetail
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Invalid.CollectionDetail collectionDetailsInvalid = new EF.Invalid.CollectionDetail
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                Collection = ilr.HeaderEntity.CollectionDetailsEntity.CollectionString,
                FilePreparationDate = ilr.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                Year = ilr.HeaderEntity.CollectionDetailsEntity.YearString
            };

            EF.Valid.LearningProvider learningProviderValid = new EF.Valid.LearningProvider
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };

            EF.Invalid.LearningProvider learningProviderInvalid = new EF.Invalid.LearningProvider
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN
            };

            EF.Valid.Source sourceValid = new EF.Valid.Source
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ComponentSetVersion = "1.0",
                DateTime = nowUtc,
                ProtectiveMarking = "NA",
                ReferenceData = "NA",
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC"
            };

            EF.Invalid.Source sourceInvalid = new EF.Invalid.Source
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                ComponentSetVersion = "1.0",
                DateTime = nowUtc,
                ProtectiveMarking = "NA",
                ReferenceData = "NA",
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC"
            };

            EF.Valid.SourceFile sourceFileValid = new EF.Valid.SourceFile
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                DateTime = nowUtc,
                FilePreparationDate = ilr.HeaderEntity.SourceEntity.DateTime,
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC",
                SourceFileName = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString()
            };

            EF.Invalid.SourceFile sourceFileInvalid = new EF.Invalid.SourceFile
            {
                UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                DateTime = nowUtc,
                FilePreparationDate = ilr.HeaderEntity.SourceEntity.DateTime,
                Release = "0.1.0",
                SerialNo = "NA",
                SoftwarePackage = "DataStore Persist",
                SoftwareSupplier = "ESFA DC",
                SourceFileName = _jobContextMessage.KeyValuePairs[JobContextMessageKey.Filename].ToString()
            };

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Valid.CollectionDetails", new List<EF.Valid.CollectionDetail> { collectionDetailsValid });
                await bulkInsert.Insert("Valid.LearningProvider", new List<EF.Valid.LearningProvider> { learningProviderValid });
                await bulkInsert.Insert("Valid.Source", new List<EF.Valid.Source> { sourceValid });
                await bulkInsert.Insert("Valid.SourceFile", new List<EF.Valid.SourceFile> { sourceFileValid });

                await bulkInsert.Insert("Invalid.CollectionDetails", new List<EF.Invalid.CollectionDetail> { collectionDetailsInvalid });
                await bulkInsert.Insert("Invalid.LearningProvider", new List<EF.Invalid.LearningProvider> { learningProviderInvalid });
                await bulkInsert.Insert("Invalid.Source", new List<EF.Invalid.Source> { sourceInvalid });
                await bulkInsert.Insert("Invalid.SourceFile", new List<EF.Invalid.SourceFile> { sourceFileInvalid });
            }
        }

        private async Task ProcessLearnerDestinationsAndProgressions(
            IMessage ilr,
            List<string> learnersValid,
            CancellationToken cancellationToken)
        {
            int learnerDestinationandProgressionId = 1;
            int dPOutcomeId = 1;

            List<EF.Valid.DPOutcome> recordsValidDpoutcomes = new List<EF.Valid.DPOutcome>();
            List<EF.Invalid.DPOutcome> recordsInvalidDpoutcomes = new List<EF.Invalid.DPOutcome>();

            List<EF.Valid.LearnerDestinationandProgression> recordsValidLearnerDestinationandProgressions = new List<EF.Valid.LearnerDestinationandProgression>();
            List<EF.Invalid.LearnerDestinationandProgression> recordsInvalidLearnerDestinationandProgressions = new List<EF.Invalid.LearnerDestinationandProgression>();

            foreach (ILearnerDestinationAndProgression learnerDestinationAndProgression in ilr.LearnerDestinationAndProgressions ?? Enumerable.Empty<ILearnerDestinationAndProgression>())
            {
                if (learnersValid.Contains(learnerDestinationAndProgression.LearnRefNumber, StringComparer.OrdinalIgnoreCase))
                {
                    recordsValidLearnerDestinationandProgressions.Add(new EF.Valid.LearnerDestinationandProgression
                    {
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                        ULN = learnerDestinationAndProgression.ULN
                    });

                    foreach (IDPOutcome dpOutcome in learnerDestinationAndProgression.DPOutcomes)
                    {
                        recordsValidDpoutcomes.Add(new EF.Valid.DPOutcome
                        {
                            LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                            OutCode = dpOutcome.OutCode,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            OutCollDate = dpOutcome.OutCollDate,
                            OutEndDate = dpOutcome.OutEndDateNullable,
                            OutStartDate = dpOutcome.OutStartDate,
                            OutType = dpOutcome.OutType
                        });
                    }
                }
                else
                {
                    recordsInvalidLearnerDestinationandProgressions.Add(new EF.Invalid.LearnerDestinationandProgression
                    {
                        LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                        UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                        LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                        ULN = learnerDestinationAndProgression.ULN
                    });

                    foreach (IDPOutcome dpOutcome in learnerDestinationAndProgression.DPOutcomes)
                    {
                        recordsInvalidDpoutcomes.Add(new EF.Invalid.DPOutcome
                        {
                            DPOutcome_Id = dPOutcomeId,
                            LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                            LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                            OutCode = dpOutcome.OutCode,
                            UKPRN = ilr.HeaderEntity.SourceEntity.UKPRN,
                            OutCollDate = dpOutcome.OutCollDate,
                            OutEndDate = dpOutcome.OutEndDateNullable,
                            OutStartDate = dpOutcome.OutStartDate,
                            OutType = dpOutcome.OutType
                        });

                        dPOutcomeId++;
                    }

                    learnerDestinationandProgressionId++;
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (BulkInsert bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Invalid.DPOutcome", recordsInvalidDpoutcomes);
                await bulkInsert.Insert("Invalid.LearnerDestinationandProgression", recordsInvalidLearnerDestinationandProgressions);
                await bulkInsert.Insert("Valid.DPOutcome", recordsValidDpoutcomes);
                await bulkInsert.Insert("Valid.LearnerDestinationandProgression", recordsValidLearnerDestinationandProgressions);
            }
        }
    }
}