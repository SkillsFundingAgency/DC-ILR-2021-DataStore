using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.Model.Loose.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Invalid;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class InvalidLearnerDataMapper : IInvalidLearnerDataMapper
    {
        public void MapInvalidLearnerData(IDataStoreCache cache, ILooseMessage ilr, IEnumerable<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var header = ilr.HeaderEntity;
            var sourceFileCollection = ilr.SourceFilesCollection;
            var learners = ilr.Learners?.Where(l => !learnersValid.Contains(!string.IsNullOrWhiteSpace(l.LearnRefNumber) ? l.LearnRefNumber.Trim() : string.Empty, StringComparer.OrdinalIgnoreCase));
            var learnerDestinationAndProgressions = ilr.LearnerDestinationAndProgressions?.Where(ldp => !learnersValid.Contains(!string.IsNullOrWhiteSpace(ldp.LearnRefNumber) ? ldp.LearnRefNumber.Trim() : string.Empty, StringComparer.OrdinalIgnoreCase));

            PopulateInvalidLearners(cache, ukprn, header, sourceFileCollection, learners, learnerDestinationAndProgressions);
        }

        private void PopulateInvalidLearners(IDataStoreCache cache, int ukprn, ILooseHeader header, IReadOnlyCollection<ILooseSourceFile> sourceFileCollection, IEnumerable<ILooseLearner> learners, IEnumerable<ILooseLearnerDestinationAndProgression> learnerDestinationAndProgressions)
        {
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

            cache.AddRange(BuildCollectionDetails(ukprn, header));
            cache.AddRange(BuildLearningProviders(ukprn));
            cache.AddRange(BuildSources(ukprn, source));

            if (sourceFileCollection == null)
            {
                cache.Add(new List<SourceFile>());
            }
            else
            {
                sourceFileCollection.NullSafeForEach(sourceFile => cache.Add(BuildSourceFiles(ukprn, sourceFile, sourceFileId++)));
            }

            learners.NullSafeForEach(learner =>
            {
                cache.Add(BuildInvalidLearner(ukprn, learner, learnerId));

                learner.ContactPreferences.NullSafeForEach(
                    contactPreference =>
                        cache.Add(BuildContactPreference(ukprn, learner, contactPreference, learnerId, contactPreferenceId++)));

                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    cache.Add(BuildLearningDelivery(ukprn, learner, learningDelivery, learnerId, learnerDeliveryId));

                    learningDelivery.LearningDeliveryHEs.NullSafeForEach(learningDeliveryHE => cache.Add(BuildLearningDeliveryHERecord(ukprn, learner, learningDelivery, learningDeliveryHE, learningDeliveryHEId++)));

                    learningDelivery.AppFinRecords.NullSafeForEach(
                        appFinRecord =>
                            cache.Add(BuildLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord, learnerDeliveryId, appFinRecordId++)));

                    learningDelivery.LearningDeliveryFAMs.NullSafeForEach(
                        famRecord =>
                            cache.Add(BuildLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learnerDeliveryId, learnerDeliveryFamId++)));

                    learningDelivery.LearningDeliveryWorkPlacements.NullSafeForEach(workPlacement =>
                        cache.Add(BuildLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement, learnerDeliveryId, learningDeliveryWorkPlacementId++)));

                    learningDelivery.ProviderSpecDeliveryMonitorings.NullSafeForEach(monitoring =>
                        cache.Add(BuildProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring, learnerDeliveryId, providerSpecDeliveryMonitoringId++)));

                    learnerDeliveryId++;
                });

                learner.LearnerEmploymentStatuses.NullSafeForEach(employmentStatus =>
                    {
                        cache.Add(BuildLearnerEmploymentStatus(ukprn, learner, employmentStatus, learnerId, learnerEmploymentStatusId));
                        employmentStatus.EmploymentStatusMonitorings.NullSafeForEach(monitoring => 
                            cache.Add(BuildEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring, learnerEmploymentStatusId, learnerEmploymentStatusMonitoringId++)));

                        learnerEmploymentStatusId++;
                    });

                learner.LearnerFAMs.NullSafeForEach(fam => cache.Add(BuildLearnerFAM(ukprn, learner, fam, learnerId, learnerFAMId++)));

                learner.LearnerHEs.NullSafeForEach(learnerHE =>
                {
                    cache.Add(BuildLearnerHE(ukprn, learner, learnerHE, learnerId, learnerHEId++));
                    learnerHE.LearnerHEFinancialSupports.NullSafeForEach(support => cache.Add(BuildLearnerHEFinancialSupport(ukprn, learner, support, learnerHEFinancialSupportId++)));
                });

                learner.LLDDAndHealthProblems.NullSafeForEach(problem => cache.Add(BuildLLDDAndHealthProblem(ukprn, learner, problem, learnerId, lLDDandHealthProblemID++)));

                learner.ProviderSpecLearnerMonitorings.NullSafeForEach(monitoring => cache.Add(BuildProviderSpecLearnerMonitorings(ukprn, learner, monitoring, learnerId, providerSpecLearnerMonitoringId++)));

                learnerId++;
            });

            learnerDestinationAndProgressions.NullSafeForEach(learnerDestinationAndProgression =>
            {
                cache.Add(BuildLearnerDestinationandProgression(ukprn, learnerDestinationAndProgression, learnerDestinationandProgressionId));

                learnerDestinationAndProgression.DPOutcomes.NullSafeForEach(dpOutcome => cache.Add(BuildDpOutcome(ukprn, learnerDestinationAndProgression, dpOutcome, dPOutcomeId++, learnerDestinationandProgressionId)));

                learnerDestinationandProgressionId++;
            });
        }

        public List<CollectionDetail> BuildCollectionDetails(int ukprn, ILooseHeader header)
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

        public List<Source> BuildSources(int ukprn, ILooseSource source)
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

        public SourceFile BuildSourceFiles(int ukprn, ILooseSourceFile sourceFile, int sourceFileId)
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

        public Learner BuildInvalidLearner(int ukprn, ILooseLearner ilrLearner, int id)
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
                Ethnicity = ilrLearner.EthnicityNullable,
                FamilyName = ilrLearner.FamilyName,
                GivenNames = ilrLearner.GivenNames,
                LLDDHealthProb = ilrLearner.LLDDHealthProbNullable,
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
                ULN = ilrLearner.ULNNullable
            };
        }

        public ContactPreference BuildContactPreference(int ukprn, ILooseLearner learner, ILooseContactPreference contactPreference, int learnerId, int contactPreferenceId)
        {
            return new ContactPreference
            {
                ContactPreference_Id = contactPreferenceId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCodeNullable,
                ContPrefType = contactPreference.ContPrefType
            };
        }

        public LearningDelivery BuildLearningDelivery(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, int learnerId, int deliveryId)
        {
            return new LearningDelivery
            {
                Learner_Id = learnerId,
                LearningDelivery_Id = deliveryId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnAimRef = learningDelivery.LearnAimRef,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable,
                AchDate = learningDelivery.AchDateNullable,
                AddHours = learningDelivery.AddHoursNullable,
                AimType = learningDelivery.AimTypeNullable,
                CompStatus = learningDelivery.CompStatusNullable,
                ConRefNumber = learningDelivery.ConRefNumber,
                DelLocPostCode = learningDelivery.DelLocPostCode,
                EmpOutcome = learningDelivery.EmpOutcomeNullable,
                EPAOrgID = learningDelivery.EPAOrgID,
                FundModel = learningDelivery.FundModelNullable,
                FworkCode = learningDelivery.FworkCodeNullable,
                LearnActEndDate = learningDelivery.LearnActEndDateNullable,
                LearnPlanEndDate = learningDelivery.LearnPlanEndDateNullable,
                LearnStartDate = learningDelivery.LearnStartDateNullable,
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

        public AppFinRecord BuildLearningDeliveryAppFinRecord(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, ILooseAppFinRecord appFinRecord, int learnerDeliveryId, int appFinRecordId)
        {
            return new AppFinRecord
            {
                AppFinRecord_Id = appFinRecordId,
                LearningDelivery_Id = learnerDeliveryId,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                AFinAmount = appFinRecord.AFinAmountNullable,
                AFinCode = appFinRecord.AFinCodeNullable,
                AFinDate = appFinRecord.AFinDateNullable,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable
            };
        }

        public LearningDeliveryFAM BuildLearningDeliveryFAMRecord(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, ILooseLearningDeliveryFAM learningDeliveryFam, int learnerDeliveryId, int learnerDeliveryFamId)
        {
            return new LearningDeliveryFAM
            {
                LearningDeliveryFAM_Id = learnerDeliveryFamId,
                LearningDelivery_Id = learnerDeliveryId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable,
                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
            };
        }

        public LearningDeliveryHE BuildLearningDeliveryHERecord(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, ILooseLearningDeliveryHE looseLearningDeliveryHe, int learningDeliveryHEId)
        {
            return new LearningDeliveryHE
            {
                LearningDeliveryHE_Id = learningDeliveryHEId,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DOMICILE = looseLearningDeliveryHe.DOMICILE,
                ELQ = looseLearningDeliveryHe.ELQNullable,
                FUNDCOMP = looseLearningDeliveryHe.FUNDCOMPNullable,
                FUNDLEV = looseLearningDeliveryHe.FUNDLEVNullable,
                GROSSFEE = looseLearningDeliveryHe.GROSSFEENullable,
                HEPostCode = looseLearningDeliveryHe.HEPostCode,
                MODESTUD = looseLearningDeliveryHe.MODESTUDNullable,
                MSTUFEE = looseLearningDeliveryHe.MSTUFEENullable,
                NETFEE = looseLearningDeliveryHe.NETFEENullable,
                NUMHUS = looseLearningDeliveryHe.NUMHUS,
                PCFLDCS = (double?)looseLearningDeliveryHe.PCFLDCSNullable,
                PCOLAB = (double?)looseLearningDeliveryHe.PCOLABNullable,
                PCSLDCS = (double?)looseLearningDeliveryHe.PCSLDCSNullable,
                PCTLDCS = (double?)looseLearningDeliveryHe.PCTLDCSNullable,
                QUALENT3 = looseLearningDeliveryHe.QUALENT3,
                SEC = looseLearningDeliveryHe.SECNullable,
                SOC2000 = looseLearningDeliveryHe.SOC2000Nullable,
                SPECFEE = looseLearningDeliveryHe.SPECFEENullable,
                SSN = looseLearningDeliveryHe.SSN,
                STULOAD = (double?)looseLearningDeliveryHe.STULOADNullable,
                TYPEYR = looseLearningDeliveryHe.TYPEYRNullable,
                UCASAPPID = looseLearningDeliveryHe.UCASAPPID,
                YEARSTU = looseLearningDeliveryHe.YEARSTUNullable
            };
        }

        public LearningDeliveryWorkPlacement BuildLearningDeliveryWorkPlacement(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, ILooseLearningDeliveryWorkPlacement learningDeliveryWorkPlacement, int learnerDeliveryId, int learningDeliveryWorkPlacementId)
        {
            return new LearningDeliveryWorkPlacement
            {
                LearningDeliveryWorkPlacement_Id = learningDeliveryWorkPlacementId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                WorkPlaceEmpId = learningDeliveryWorkPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                WorkPlaceEndDate = learningDeliveryWorkPlacement.WorkPlaceEndDateNullable,
                WorkPlaceHours = learningDeliveryWorkPlacement.WorkPlaceHoursNullable,
                WorkPlaceMode = learningDeliveryWorkPlacement.WorkPlaceModeNullable,
                WorkPlaceStartDate = learningDeliveryWorkPlacement.WorkPlaceStartDateNullable
            };
        }

        public ProviderSpecDeliveryMonitoring BuildProviderSpecDeliveryMonitoring(int ukprn, ILooseLearner learner, ILooseLearningDelivery learningDelivery, ILooseProviderSpecDeliveryMonitoring monitoring, int learnerDeliveryId, int providerSpecDeliveryMonitoringId)
        {
            return new ProviderSpecDeliveryMonitoring
            {
                ProviderSpecDeliveryMonitoring_Id = providerSpecDeliveryMonitoringId,
                LearningDelivery_Id = learnerDeliveryId,
                AimSeqNumber = learningDelivery.AimSeqNumberNullable,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = monitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = monitoring.ProvSpecDelMonOccur,
                UKPRN = ukprn
            };
        }

        public LearnerEmploymentStatus BuildLearnerEmploymentStatus(int ukprn, ILooseLearner learner, ILooseLearnerEmploymentStatus learnerEmploymentStatus, int learnerId, int learnerEmploymentStatusId)
        {
            return new LearnerEmploymentStatus
            {
                Learner_Id = learnerId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                AgreeId = null,// removed from 2021, learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatAppNullable,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStatNullable
            };
        }

        public EmploymentStatusMonitoring BuildEmploymentStatusMonitoring(int ukprn, ILooseLearner learner, ILooseLearnerEmploymentStatus learnerEmploymentStatus, ILooseEmploymentStatusMonitoring employmentStatusMonitoring, int learnerEmploymentStatusId, int learnerEmploymentStatusMonitoringId)
        {
            return new EmploymentStatusMonitoring
            {
                EmploymentStatusMonitoring_Id = learnerEmploymentStatusMonitoringId,
                LearnerEmploymentStatus_Id = learnerEmploymentStatusId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatAppNullable,
                ESMCode = employmentStatusMonitoring.ESMCodeNullable,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }

        public LearnerFAM BuildLearnerFAM(int ukprn, ILooseLearner learner, ILooseLearnerFAM fam, int learnerId, int learnerFAMId)
        {
            return new LearnerFAM
            {
                LearnerFAM_Id = learnerFAMId,
                Learner_Id = learnerId,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = fam.LearnFAMCodeNullable,
                LearnFAMType = fam.LearnFAMType
            };
        }

        public LearnerHE BuildLearnerHE(int ukprn, ILooseLearner learner, ILooseLearnerHE learnerHe, int learnerId, int learnerHEId)
        {
            return new LearnerHE
            {
                LearnerHE_Id = learnerHEId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learnerHe.TTACCOMNullable,
                UKPRN = ukprn,
                UCASPERID = learnerHe.UCASPERID
            };
        }

        public LearnerHEFinancialSupport BuildLearnerHEFinancialSupport(int ukprn, ILooseLearner learner, ILooseLearnerHEFinancialSupport support, int learnerHEFinancialSupportId)
        {
            return new LearnerHEFinancialSupport
            {
                LearnerHEFinancialSupport_Id = learnerHEFinancialSupportId,
                FINAMOUNT = support.FINAMOUNTNullable,
                FINTYPE = support.FINTYPENullable,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn
            };
        }

        public LLDDandHealthProblem BuildLLDDAndHealthProblem(int ukprn, ILooseLearner learner, ILooseLLDDAndHealthProblem problem, int learnerId, int lLDDandHealthProblemId)
        {
            return new LLDDandHealthProblem
            {
                LLDDandHealthProblem_Id = lLDDandHealthProblemId,
                Learner_Id = learnerId,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = problem.LLDDCatNullable,
                PrimaryLLDD = problem.PrimaryLLDDNullable,
                UKPRN = ukprn
            };
        }

        public ProviderSpecLearnerMonitoring BuildProviderSpecLearnerMonitorings(int ukprn, ILooseLearner learner, ILooseProviderSpecLearnerMonitoring monitoring, int learnerId, int providerSpecLearnerMonitoringId)
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

        public LearnerDestinationandProgression BuildLearnerDestinationandProgression(int ukprn, ILooseLearnerDestinationAndProgression learnerDestinationAndProgression, int learnerDestinationAndProgressionId)
        {
            return new LearnerDestinationandProgression
            {
                LearnerDestinationandProgression_Id = learnerDestinationAndProgressionId,
                UKPRN = ukprn,
                LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                ULN = learnerDestinationAndProgression.ULNNullable
            };
        }

        public DPOutcome BuildDpOutcome(int ukprn, ILooseLearnerDestinationAndProgression learnerDestinationAndProgression, ILooseDPOutcome dpOutcome, int dPOutcomeId, int learnerDestinationandProgressionId)
        {
            return new DPOutcome
            {
                DPOutcome_Id = dPOutcomeId,
                LearnerDestinationandProgression_Id = learnerDestinationandProgressionId,
                LearnRefNumber = learnerDestinationAndProgression.LearnRefNumber,
                OutCode = dpOutcome.OutCodeNullable,
                UKPRN = ukprn,
                OutCollDate = dpOutcome.OutCollDateNullable,
                OutEndDate = dpOutcome.OutEndDateNullable,
                OutStartDate = dpOutcome.OutStartDateNullable,
                OutType = dpOutcome.OutType
            };
        }
    }
}
