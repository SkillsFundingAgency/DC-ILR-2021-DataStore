using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class InvalidLearnerDataMapper : IInvalidLearnerDataMapper
    {
        public InvalidLearnerData MapInvalidLearnerData(IMessage ilr, IEnumerable<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var header = ilr.HeaderEntity;
            var sourceFileCollection = ilr.SourceFilesCollection;
            var learners = ilr.Learners?.Where(l => !learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase));
            var learnerDestinationAndProgressions = ilr.LearnerDestinationAndProgressions?.Where(ldp => !learnersValid.Contains(ldp.LearnRefNumber, StringComparer.OrdinalIgnoreCase));

            return PopulateInvalidLearners(ukprn, header, sourceFileCollection, learners, learnerDestinationAndProgressions);
        }

        private InvalidLearnerData PopulateInvalidLearners(int ukprn, IHeader header, IReadOnlyCollection<ISourceFile> sourceFileCollection, IEnumerable<ILearner> learners, IEnumerable<ILearnerDestinationAndProgression> learnerDestinationAndProgressions)
        {
            var invalidLearnerData = new InvalidLearnerData();
            var source = header.SourceEntity;

            int sourceFileId = 1;
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
            int providerSpecLearnerMonitoringId = 1;
            int providerSpecDeliveryMonitoringId = 1;
            int contactPreferenceId = 1;
            int lLDDandHealthProblemID = 1;
            int learnerDestinationandProgressionId = 1;
            int dPOutcomeId = 1;

            invalidLearnerData.CollectionDetails.AddRange(BuildCollectionDetails(ukprn, header));
            invalidLearnerData.LearningProviders.AddRange(BuildLearningProviders(ukprn));
            invalidLearnerData.Sources.AddRange(BuildSources(ukprn, source));

            if (sourceFileCollection == null)
            {
                invalidLearnerData.SourceFiles = new List<SourceFile>();
            }
            else
            {
                sourceFileCollection.NullSafeForEach(sourceFile => invalidLearnerData.SourceFiles.Add(BuildSourceFiles(ukprn, sourceFile, sourceFileId++)));
            }

            learners.NullSafeForEach(learner =>
            {
                invalidLearnerData.RecordsInvalidLearners.Add(BuildInvalidLearner(ukprn, learner, learnerId));

                learner.ContactPreferences.NullSafeForEach(
                    contactPreference =>
                        invalidLearnerData.RecordsInvalidContactPreferences.Add(BuildContactPreference(ukprn, learner, contactPreference, learnerId, contactPreferenceId++)));

                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    invalidLearnerData.RecordsInvalidLearningDeliverys.Add(BuildLearningDelivery(ukprn, learner, learningDelivery, learnerId, learnerDeliveryId));

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        invalidLearnerData.RecordsInvalidLearningDeliveryHes.Add(BuildLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDeliveryHEId++));
                    }

                    learningDelivery.AppFinRecords.NullSafeForEach(
                        appFinRecord =>
                            invalidLearnerData.RecordsInvalidAppFinRecords.Add(BuildLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId++)));

                    learningDelivery.LearningDeliveryFAMs.NullSafeForEach(
                        famRecord =>
                            invalidLearnerData.RecordsInvalidLearnerDeliveryFams.Add(BuildLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, learnerDeliveryFamId++)));

                    learningDelivery.LearningDeliveryWorkPlacements.NullSafeForEach(workPlacement =>
                        invalidLearnerData.RecordsInvalidLearningDeliveryWorkPlacements.Add(BuildLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId++)));

                    learningDelivery.ProviderSpecDeliveryMonitorings.NullSafeForEach(monitoring =>
                        invalidLearnerData.RecordsInvalidProviderSpecDeliveryMonitorings.Add(BuildProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId++)));

                    learnerDeliveryId++;
                });

                learner.LearnerEmploymentStatuses.NullSafeForEach(employmentStatus =>
                    {
                        invalidLearnerData.RecordsInvalidLearnerEmploymentStatus.Add(BuildLearnerEmploymentStatus(ukprn, learner, employmentStatus, learnerId, learnerEmploymentStatusId));
                        employmentStatus.EmploymentStatusMonitorings.NullSafeForEach(monitoring => 
                            invalidLearnerData.RecordsInvalidEmploymentStatusMonitorings.Add(BuildEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId++)));

                        learnerEmploymentStatusId++;
                    });

                learner.LearnerFAMs.NullSafeForEach(fam => invalidLearnerData.RecordsInvalidLearnerFams.Add(BuildLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId++)));

                if (learner.LearnerHEEntity != null)
                {
                    invalidLearnerData.RecordsInvalidLearnerHes.Add(BuildLearnerHE(ukprn, learner, learnerId, learnerHEId++));

                    learner.LearnerHEEntity.LearnerHEFinancialSupports.NullSafeForEach(support => invalidLearnerData.RecordsInvalidLearnerHefinancialSupports.Add(BuildLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId++)));
                }

                learner.LLDDAndHealthProblems.NullSafeForEach(problem => invalidLearnerData.RecordsInvalidLlddandHealthProblems.Add(BuildLLDDAndHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemID++)));

                learner.ProviderSpecLearnerMonitorings.NullSafeForEach(monitoring => invalidLearnerData.RecordsInvalidProviderSpecLearnerMonitorings.Add(BuildProviderSpecLearnerMonitorings(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId++)));

                learnerId++;
            });

            learnerDestinationAndProgressions.NullSafeForEach(learnerDestinationAndProgression =>
            {
                invalidLearnerData.RecordsInvalidLearnerDestinationandProgressions.Add(BuildLearnerDestinationandProgression(ukprn, learnerDestinationAndProgression, learnerDestinationandProgressionId));

                learnerDestinationAndProgression.DPOutcomes.NullSafeForEach(dpOutcome => invalidLearnerData.RecordsInvalidDpOutcomes.Add(BuildDpOutcome(ukprn, learnerDestinationAndProgression, dpOutcome, dPOutcomeId++, learnerDestinationandProgressionId)));

                learnerDestinationandProgressionId++;
            });

            return invalidLearnerData;
        }

        public List<CollectionDetail> BuildCollectionDetails(int ukprn, IHeader header)
        {
            return new List<CollectionDetail>
            {
                new CollectionDetail
                {
                    UKPRN = ukprn,
                    Collection = header.CollectionDetailsEntity.CollectionString,
                    FilePreparationDate = header.CollectionDetailsEntity.FilePreparationDate,
                    Year = header.CollectionDetailsEntity.YearString,
                },
            };
        }

        public List<LearningProvider> BuildLearningProviders(int ukprn)
        {
            return new List<LearningProvider>
            {
                new LearningProvider
                {
                    UKPRN = ukprn,
                },
            };
        }

        public List<Source> BuildSources(int ukprn, ISource source)
        {
            return new List<Source>
            {
                new Source
                {
                    UKPRN = ukprn,
                    ComponentSetVersion = source.ComponentSetVersion,
                    DateTime = source.DateTime,
                    ProtectiveMarking = source.ProtectiveMarkingString,
                    ReferenceData = source.ReferenceData,
                    Release = source.Release,
                    SerialNo = source.SerialNo,
                    SoftwarePackage = source.SoftwarePackage,
                    SoftwareSupplier = source.SoftwareSupplier,
                },
            };
        }

        public SourceFile BuildSourceFiles(int ukprn, ISourceFile sourceFile, int sourceFileId)
        {
            return new SourceFile
            {
                SourceFile_Id = sourceFileId,
                UKPRN = ukprn,
                DateTime = sourceFile.DateTimeNullable,
                FilePreparationDate = sourceFile.FilePreparationDate,
                Release = sourceFile.Release,
                SerialNo = sourceFile.SerialNo,
                SoftwarePackage = sourceFile.SoftwarePackage,
                SoftwareSupplier = sourceFile.SoftwareSupplier,
                SourceFileName = sourceFile.SourceFileName,
            };
        }

        public Learner BuildInvalidLearner(int ukprn, ILearner ilrLearner, int id)
        {
            return new Learner
            {
                Learner_Id = id,
                LearnRefNumber = ilrLearner.LearnRefNumber,
                UKPRN = ukprn,
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
            };
        }

        public ContactPreference BuildContactPreference(int ukprn, ILearner learner, IContactPreference contactPreference, int learnerId, int contactPreferenceId)
        {
            return new ContactPreference
            {
                ContactPreference_Id = contactPreferenceId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }

        public LearningDelivery BuildLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery, int learnerId, int deliveryId)
        {
            return new LearningDelivery
            {
                Learner_Id = learnerId,
                LearningDelivery_Id = deliveryId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
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
                LSDPostcode = learningDelivery.LSDPostcode,
                OrigLearnStartDate = learningDelivery.OrigLearnStartDateNullable,
                OtherFundAdj = learningDelivery.OtherFundAdjNullable,
                OutGrade = learningDelivery.OutGrade,
                Outcome = learningDelivery.OutcomeNullable,
                PartnerUKPRN = learningDelivery.PartnerUKPRNNullable,
                PHours = learningDelivery.PHoursNullable,
                PriorLearnFundAdj = learningDelivery.PriorLearnFundAdjNullable,
                ProgType = learningDelivery.ProgTypeNullable,
                PwayCode = learningDelivery.PwayCodeNullable,
                StdCode = learningDelivery.StdCodeNullable,
                SWSupAimId = learningDelivery.SWSupAimId,
                WithdrawReason = learningDelivery.WithdrawReasonNullable
            };
        }

        public AppFinRecord BuildLearningDeliveryAppFinRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord, int learnerDeliveryId, int appFinRecordId)
        {
            return new AppFinRecord
            {
                AppFinRecord_Id = appFinRecordId,
                LearningDelivery_Id = learnerDeliveryId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                AFinAmount = appFinRecord.AFinAmount,
                AFinCode = appFinRecord.AFinCode,
                AFinDate = appFinRecord.AFinDate,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumber
            };
        }

        public LearningDeliveryFAM BuildLearningDeliveryFAMRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM learningDeliveryFam, int learnerDeliveryId, int learnerDeliveryFamId)
        {
            return new LearningDeliveryFAM
            {
                LearningDeliveryFAM_Id = learnerDeliveryFamId,
                LearningDelivery_Id = learnerDeliveryId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
            };
        }

        public LearningDeliveryHE BuildLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, int learningDeliveryHEId)
        {
            return new LearningDeliveryHE
            {
                LearningDeliveryHE_Id = learningDeliveryHEId,
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

        public LearningDeliveryWorkPlacement BuildLearningDeliveryWorkPlacement(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement learningDeliveryWorkPlacement, int learnerDeliveryId, int learningDeliveryWorkPlacementId)
        {
            return new LearningDeliveryWorkPlacement
            {
                LearningDeliveryWorkPlacement_Id = learningDeliveryWorkPlacementId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHours,
                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceMode,
                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDate
            };
        }

        public ProviderSpecDeliveryMonitoring BuildProviderSpecDeliveryMonitoring(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring, int learnerDeliveryId, int providerSpecDeliveryMonitoringId)
        {
            return new ProviderSpecDeliveryMonitoring
            {
                ProviderSpecDeliveryMonitoring_Id = providerSpecDeliveryMonitoringId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = monitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = monitoring.ProvSpecDelMonOccur,
                UKPRN = ukprn
            };
        }

        public LearnerEmploymentStatus BuildLearnerEmploymentStatus(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, int learnerId, int learnerEmploymentStatusId)
        {
            return new LearnerEmploymentStatus
            {
                Learner_Id = learnerId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }

        public EmploymentStatusMonitoring BuildEmploymentStatusMonitoring(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring, int learnerEmploymentStatusId, int learnerEmploymentStatusMonitoringId)
        {
            return new EmploymentStatusMonitoring
            {
                EmploymentStatusMonitoring_Id = learnerEmploymentStatusMonitoringId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                ESMCode = employmentStatusMonitoring.ESMCode,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }

        public LearnerFAM BuildLearnerFAM(int ukprn, ILearner learner, ILearnerFAM fam, int learnerId, int learnerFAMId)
        {
            return new LearnerFAM
            {
                LearnerFAM_Id = learnerFAMId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = fam.LearnFAMCode,
                LearnFAMType = fam.LearnFAMType
            };
        }

        public LearnerHE BuildLearnerHE(int ukprn, ILearner learner, int learnerId, int learnerHEId)
        {
            return new LearnerHE
            {
                LearnerHE_Id = learnerHEId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ukprn,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }

        public LearnerHEFinancialSupport BuildLearnerHEFinancialSupport(int ukprn, ILearner learner, ILearnerHEFinancialSupport support, int learnerHEFinancialSupportId)
        {
            return new LearnerHEFinancialSupport
            {
                LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                FINAMOUNT = support.FINAMOUNT,
                FINTYPE = support.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn
            };
        }

        public LLDDandHealthProblem BuildLLDDAndHealthProblem(int ukprn, ILearner learner, ILLDDAndHealthProblem problem, int learnerId, int lLDDandHealthProblemId)
        {
            return new LLDDandHealthProblem
            {
                LLDDandHealthProblem_Id = lLDDandHealthProblemId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = problem.LLDDCat,
                PrimaryLLDD = problem.PrimaryLLDDNullable,
                UKPRN = ukprn
            };
        }

        public ProviderSpecLearnerMonitoring BuildProviderSpecLearnerMonitorings(int ukprn, ILearner learner, IProviderSpecLearnerMonitoring monitoring, int learnerId, int providerSpecLearnerMonitoringId)
        {
            return new ProviderSpecLearnerMonitoring
            {
                ProviderSpecLearnerMonitoring_Id = providerSpecLearnerMonitoringId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                ProvSpecLearnMon = monitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = monitoring.ProvSpecLearnMonOccur
            };
        }

        public LearnerDestinationandProgression BuildLearnerDestinationandProgression(int ukprn, ILearnerDestinationAndProgression learnerDestinationAndProgression, int learnerDestinationAndProgressionId)
        {
            return new LearnerDestinationandProgression
            {
                LearnerDestinationandProgression_Id = learnerDestinationAndProgressionId,
                UKPRN = ukprn,
                LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                ULN = learnerDestinationAndProgression.ULN
            };
        }

        public DPOutcome BuildDpOutcome(int ukprn, ILearnerDestinationAndProgression learnerDestinationAndProgression, IDPOutcome dpOutcome, int dPOutcomeId, int learnerDestinationandProgressionId)
        {
            return new DPOutcome
            {
                DPOutcome_Id = dPOutcomeId,
                LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                OutCode = dpOutcome.OutCode,
                UKPRN = ukprn,
                OutCollDate = dpOutcome.OutCollDate,
                OutEndDate = dpOutcome.OutEndDateNullable,
                OutStartDate = dpOutcome.OutStartDate,
                OutType = dpOutcome.OutType
            };
        }
    }
}
