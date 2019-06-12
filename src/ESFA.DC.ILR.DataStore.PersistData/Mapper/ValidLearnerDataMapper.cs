using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.DataStore.Interface.Mappers;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.DataStore.PersistData.Builders.Extension;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1920.DataStore.EF.Valid;

namespace ESFA.DC.ILR.DataStore.PersistData.Mapper
{
    public class ValidLearnerDataMapper : IValidLearnerDataMapper
    {
        public ValidLearnerData MapLearnerData(IMessage ilr, IEnumerable<string> learnersValid)
        {
            var ukprn = ilr.LearningProviderEntity.UKPRN;

            var header = ilr.HeaderEntity;
            var sourceFileCollection = ilr.SourceFilesCollection;
            var learners = ilr.Learners?.Where(l => learnersValid.Contains(l.LearnRefNumber, StringComparer.OrdinalIgnoreCase));
            var destinationAndProgressions = ilr.LearnerDestinationAndProgressions?.Where(ldp => learnersValid.Contains(ldp.LearnRefNumber, StringComparer.OrdinalIgnoreCase));

            return PopulateValidLearners(ukprn, header, sourceFileCollection, learners, destinationAndProgressions);
        }

        private ValidLearnerData PopulateValidLearners(int ukprn, IHeader header, IReadOnlyCollection<ISourceFile> sourceFileCollection, IEnumerable<ILearner> learners, IEnumerable<ILearnerDestinationAndProgression> destinationAndProgressions)
        {
            var validLearnerData = new ValidLearnerData();
            var source = header.SourceEntity;
            int lLDDandHealthProblemID = 1;
            int learningDeliveryFamId = 1;

            validLearnerData.CollectionDetails.AddRange(BuildCollectionDetails(ukprn, header));
            validLearnerData.LearningProviders.AddRange(BuildLearningProviders(ukprn));
            validLearnerData.Sources.AddRange(BuildSources(ukprn, source));
            validLearnerData.SourceFiles.AddRange(BuildSourceFiles(ukprn, sourceFileCollection));

            learners.NullSafeForEach(learner =>
            {
                validLearnerData.RecordsValidLearners.Add(BuildValidLearner(ukprn, learner));

                learner.ContactPreferences.NullSafeForEach(contactPreference => validLearnerData.RecordsValidContactPreferences.Add(BuildContactPreference(ukprn, learner, contactPreference)));
                learner.LearningDeliveries.NullSafeForEach(learningDelivery =>
                {
                    validLearnerData.RecordsValidLearningDeliverys.Add(BuildLearningDelivery(ukprn, learner, learningDelivery));

                    if (learningDelivery.LearningDeliveryHEEntity != null)
                    {
                        validLearnerData.RecordsValidLearningDeliveryHes.Add(BuildLearningDeliveryHERecord(ukprn, learner, learningDelivery));
                    }

                    learningDelivery.AppFinRecords.NullSafeForEach(appFinRecord => validLearnerData.RecordsValidAppFinRecords.Add(BuildLearningDeliveryAppFinRecord(ukprn, learner, learningDelivery, appFinRecord)));
                    learningDelivery.LearningDeliveryFAMs.NullSafeForEach(famRecord => validLearnerData.RecordsValidLearnerDeliveryFams.Add(BuildLearningDeliveryFAMRecord(ukprn, learner, learningDelivery, famRecord, learningDeliveryFamId++)));
                    learningDelivery.LearningDeliveryWorkPlacements.NullSafeForEach(workPlacement => validLearnerData.RecordsValidLearningDeliveryWorkPlacements.Add(BuildLearningDeliveryWorkPlacement(ukprn, learner, learningDelivery, workPlacement)));
                    learningDelivery.ProviderSpecDeliveryMonitorings.NullSafeForEach(monitoring => validLearnerData.RecordsValidProviderSpecDeliveryMonitorings.Add(BuildProviderSpecDeliveryMonitoring(ukprn, learner, learningDelivery, monitoring)));
                });

                learner.LearnerEmploymentStatuses.NullSafeForEach(employmentStatus =>
                    {
                        validLearnerData.RecordsValidLearnerEmploymentStatus.Add(BuildLearnerEmploymentStatus(ukprn, learner, employmentStatus));
                        employmentStatus.EmploymentStatusMonitorings.NullSafeForEach(monitoring => validLearnerData.RecordsValidEmploymentStatusMonitorings.Add(BuildEmploymentStatusMonitoring(ukprn, learner, employmentStatus, monitoring)));
                    });

                learner.LearnerFAMs.NullSafeForEach(fam => validLearnerData.RecordsValidLearnerFams.Add(BuildLearnerFAM(ukprn, learner, fam)));

                if (learner.LearnerHEEntity != null)
                {
                    validLearnerData.RecordsValidLearnerHes.Add(BuildLearnerHE(ukprn, learner));
                    learner.LearnerHEEntity.LearnerHEFinancialSupports.NullSafeForEach(support => validLearnerData.RecordsValidLearnerHefinancialSupports.Add(BuildLearnerHEFinancialSupport(ukprn, learner, support)));
                }

                learner.LLDDAndHealthProblems.NullSafeForEach(problem => validLearnerData.RecordsValidLlddandHealthProblems.Add(BuildLLDDAndHealthProblem(ukprn, learner, problem, lLDDandHealthProblemID++)));

                learner.ProviderSpecLearnerMonitorings.NullSafeForEach(monitoring => validLearnerData.RecordsValidProviderSpecLearnerMonitorings.Add(BuildProviderSpecLearnerMonitoring(ukprn, learner, monitoring)));
            });

            destinationAndProgressions.NullSafeForEach(destinationAndProgression =>
            {
                validLearnerData.RecordsValidLearnerDestinationandProgressions.Add(BuildLearnerDestinationAndProgression(ukprn, destinationAndProgression));
                destinationAndProgression.DPOutcomes.NullSafeForEach(dpOutcome => validLearnerData.RecordsValidDpOutcomes.Add(BuildDPOutcome(ukprn, destinationAndProgression, dpOutcome)));
            });

            return validLearnerData;
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

        public List<SourceFile> BuildSourceFiles(int ukprn, IReadOnlyCollection<ISourceFile> sourceFileCollection)
        {
            return sourceFileCollection?
                       .Select(sf => new SourceFile
                       {
                           UKPRN = ukprn,
                           DateTime = sf.DateTimeNullable,
                           FilePreparationDate = sf.FilePreparationDate,
                           Release = sf.Release,
                           SerialNo = sf.SerialNo,
                           SoftwarePackage = sf.SoftwarePackage,
                           SoftwareSupplier = sf.SoftwareSupplier,
                           SourceFileName = sf.SourceFileName,
                       }).ToList()
                   ?? new List<SourceFile>();
        }

        public Learner BuildValidLearner(int ukprn, ILearner ilrLearner)
        {
            return new Learner
            {
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

        public ContactPreference BuildContactPreference(int ukprn, ILearner learner, IContactPreference contactPreference)
        {
            return new ContactPreference
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                ContPrefCode = contactPreference.ContPrefCode,
                ContPrefType = contactPreference.ContPrefType
            };
        }

        public LearningDelivery BuildLearningDelivery(int ukprn, ILearner learner, ILearningDelivery learningDelivery)
        {
            return new LearningDelivery
            {
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

        public LearningDeliveryHE BuildLearningDeliveryHERecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery)
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

        public AppFinRecord BuildLearningDeliveryAppFinRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IAppFinRecord appFinRecord)
        {
            return new AppFinRecord
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                AFinAmount = appFinRecord.AFinAmount,
                AFinCode = appFinRecord.AFinCode,
                AFinDate = appFinRecord.AFinDate,
                AFinType = appFinRecord.AFinType,
                AimSeqNumber = learningDelivery.AimSeqNumber
            };
        }

        public LearningDeliveryFAM BuildLearningDeliveryFAMRecord(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryFAM learningDeliveryFam, int id)
        {
            return new LearningDeliveryFAM
            {
                LearningDeliveryFAM_Id = id,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnDelFAMCode = learningDeliveryFam.LearnDelFAMCode,
                LearnDelFAMDateFrom = learningDeliveryFam.LearnDelFAMDateFromNullable,
                LearnDelFAMDateTo = learningDeliveryFam.LearnDelFAMDateToNullable,
                LearnDelFAMType = learningDeliveryFam.LearnDelFAMType
            };
        }

        public LearningDeliveryWorkPlacement BuildLearningDeliveryWorkPlacement(int ukprn, ILearner learner, ILearningDelivery learningDelivery, ILearningDeliveryWorkPlacement workPlacement)
        {
            return new LearningDeliveryWorkPlacement
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                WorkPlaceEmpId = workPlacement.WorkPlaceEmpIdNullable.GetValueOrDefault(-1),
                WorkPlaceEndDate = workPlacement.WorkPlaceEndDateNullable,
                WorkPlaceHours = workPlacement.WorkPlaceHours,
                WorkPlaceMode = workPlacement.WorkPlaceMode,
                WorkPlaceStartDate = workPlacement.WorkPlaceStartDate
            };
        }

        public ProviderSpecDeliveryMonitoring BuildProviderSpecDeliveryMonitoring(int ukprn, ILearner learner, ILearningDelivery learningDelivery, IProviderSpecDeliveryMonitoring monitoring)
        {
            return new ProviderSpecDeliveryMonitoring
            {
                AimSeqNumber = learningDelivery.AimSeqNumber,
                LearnRefNumber = learner.LearnRefNumber,
                ProvSpecDelMon = monitoring.ProvSpecDelMon,
                ProvSpecDelMonOccur = monitoring.ProvSpecDelMonOccur,
                UKPRN = ukprn
            };
        }

        public LearnerEmploymentStatus BuildLearnerEmploymentStatus(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus)
        {
            return new LearnerEmploymentStatus
            {
                UKPRN = ukprn,
                AgreeId = learnerEmploymentStatus.AgreeId,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                EmpId = learnerEmploymentStatus.EmpIdNullable,
                EmpStat = learnerEmploymentStatus.EmpStat
            };
        }

        public EmploymentStatusMonitoring BuildEmploymentStatusMonitoring(int ukprn, ILearner learner, ILearnerEmploymentStatus learnerEmploymentStatus, IEmploymentStatusMonitoring employmentStatusMonitoring)
        {
            return new EmploymentStatusMonitoring
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                DateEmpStatApp = learnerEmploymentStatus.DateEmpStatApp,
                ESMCode = employmentStatusMonitoring.ESMCode,
                ESMType = employmentStatusMonitoring.ESMType
            };
        }

        public LearnerFAM BuildLearnerFAM(int ukprn, ILearner learner, ILearnerFAM fam)
        {
            return new LearnerFAM
            {
                UKPRN = ukprn,
                LearnRefNumber = learner.LearnRefNumber,
                LearnFAMCode = fam.LearnFAMCode,
                LearnFAMType = fam.LearnFAMType
            };
        }

        public LearnerHE BuildLearnerHE(int ukprn, ILearner learner)
        {
            return new LearnerHE
            {
                LearnRefNumber = learner.LearnRefNumber,
                TTACCOM = learner.LearnerHEEntity.TTACCOMNullable,
                UKPRN = ukprn,
                UCASPERID = learner.LearnerHEEntity.UCASPERID
            };
        }

        public LearnerHEFinancialSupport BuildLearnerHEFinancialSupport(int ukprn, ILearner learner, ILearnerHEFinancialSupport support)
        {
            return new LearnerHEFinancialSupport
            {
                FINAMOUNT = support.FINAMOUNT,
                FINTYPE = support.FINTYPE,
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn
            };
        }

        public LLDDandHealthProblem BuildLLDDAndHealthProblem(int ukprn, ILearner learner, ILLDDAndHealthProblem problem, int id)
        {
            return new LLDDandHealthProblem
            {
                LLDDandHealthProblem_ID = id,
                LearnRefNumber = learner.LearnRefNumber,
                LLDDCat = problem.LLDDCat,
                PrimaryLLDD = problem.PrimaryLLDDNullable,
                UKPRN = ukprn
            };
        }

        public ProviderSpecLearnerMonitoring BuildProviderSpecLearnerMonitoring(int ukprn, ILearner learner, IProviderSpecLearnerMonitoring monitoring)
        {
            return new ProviderSpecLearnerMonitoring
            {
                LearnRefNumber = learner.LearnRefNumber,
                UKPRN = ukprn,
                ProvSpecLearnMon = monitoring.ProvSpecLearnMon,
                ProvSpecLearnMonOccur = monitoring.ProvSpecLearnMonOccur
            };
        }

        public LearnerDestinationandProgression BuildLearnerDestinationAndProgression(int ukprn, ILearnerDestinationAndProgression destinationAndProgression)
        {
            return new LearnerDestinationandProgression
            {
                UKPRN = ukprn,
                LearnRefNumber = destinationAndProgression.LearnRefNumber,
                ULN = destinationAndProgression.ULN
            };
        }

        public DPOutcome BuildDPOutcome(int ukprn, ILearnerDestinationAndProgression destinationAndProgression, IDPOutcome dpOutcome)
        {
            return new DPOutcome
            {
                LearnRefNumber = destinationAndProgression.LearnRefNumber,
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
