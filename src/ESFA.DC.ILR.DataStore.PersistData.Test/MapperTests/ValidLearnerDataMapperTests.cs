using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.PersistData.Mapper;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF.Valid;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.DataStore.PersistData.Test.MapperTests
{
    public class ValidLearnerDataMapperTests
    {
        private readonly int _ukprn = 123456789;

        [Fact]
        public void GetCollectionDetails_Test()
        {
            var header = new Mock<IHeader>();
            header.Setup(h => h.CollectionDetailsEntity.CollectionString).Returns("collectionString");
            header.Setup(h => h.CollectionDetailsEntity.FilePreparationDate).Returns(new DateTime(2000, 01, 01));
            header.Setup(h => h.CollectionDetailsEntity.YearString).Returns("1920");

            var collectionDetails = Mapper().BuildCollectionDetails(_ukprn, header.Object);

            collectionDetails.Should().NotBeNull();
            collectionDetails.Single().UKPRN.Should().Be(_ukprn);
            collectionDetails.Single().Collection.Should().Be("collectionString");
            collectionDetails.Single().FilePreparationDate.Should().Be(new DateTime(2000, 01, 01));
            collectionDetails.Single().Year.Should().Be("1920");
        }

        [Fact]
        public void GetLearningProviders_Test()
        {
            var collectionDetails = Mapper().BuildLearningProviders(_ukprn);

            collectionDetails.Should().NotBeNull();
            collectionDetails.Single().UKPRN.Should().Be(_ukprn);
        }

        [Fact]
        public void GetSources_Test()
        {
            var sourceMock = new Mock<ISource>();
            sourceMock.Setup(s => s.ComponentSetVersion).Returns("ComponentSetVersion");
            sourceMock.Setup(s => s.DateTime).Returns(new DateTime(2000, 01, 01));
            sourceMock.Setup(s => s.ProtectiveMarkingString).Returns("ProtectiveMarking");
            sourceMock.Setup(s => s.ReferenceData).Returns("ReferenceData");
            sourceMock.Setup(s => s.Release).Returns("Release");
            sourceMock.Setup(s => s.SerialNo).Returns("SerialNo");
            sourceMock.Setup(s => s.SoftwarePackage).Returns("SoftwarePackage");
            sourceMock.Setup(s => s.SoftwareSupplier).Returns("SoftwareSupplier");

            var source = Mapper().BuildSources(_ukprn, sourceMock.Object);

            source.Should().NotBeNull();
            source.Single().UKPRN.Should().Be(_ukprn);
            source.Single().ComponentSetVersion.Should().Be("ComponentSetVersion");
            source.Single().DateTime.Should().Be(new DateTime(2000, 01, 01));
            source.Single().ProtectiveMarking.Should().Be("ProtectiveMarking");
            source.Single().ReferenceData.Should().Be("ReferenceData");
            source.Single().Release.Should().Be("Release");
            source.Single().SerialNo.Should().Be("SerialNo");
            source.Single().SoftwarePackage.Should().Be("SoftwarePackage");
            source.Single().SoftwareSupplier.Should().Be("SoftwareSupplier");
        }

        [Fact]
        public void GetSourceFiles_Test()
        {
            var sourceFileMock = new Mock<ISourceFile>();

            sourceFileMock.Setup(sf => sf.DateTimeNullable).Returns(new DateTime(2000, 01, 01));
            sourceFileMock.Setup(sf => sf.FilePreparationDate).Returns(new DateTime(2000, 01, 01));
            sourceFileMock.Setup(sf => sf.Release).Returns("Release");
            sourceFileMock.Setup(sf => sf.SerialNo).Returns("SerialNo");
            sourceFileMock.Setup(sf => sf.SoftwarePackage).Returns("SoftwarePackage");
            sourceFileMock.Setup(sf => sf.SoftwareSupplier).Returns("SoftwareSupplier");
            sourceFileMock.Setup(sf => sf.SourceFileName).Returns("SourceFileName");

            var sourceFilesMock = new List<ISourceFile> { sourceFileMock.Object };
            var sourceFiles = Mapper().BuildSourceFiles(_ukprn, sourceFilesMock);

            sourceFiles.Should().NotBeNull();
            sourceFiles.Single().UKPRN.Should().Be(_ukprn);
            sourceFiles.Single().DateTime.Should().Be(new DateTime(2000, 01, 01));
            sourceFiles.Single().FilePreparationDate.Should().Be(new DateTime(2000, 01, 01));
            sourceFiles.Single().Release.Should().Be("Release");
            sourceFiles.Single().SerialNo.Should().Be("SerialNo");
            sourceFiles.Single().SoftwarePackage.Should().Be("SoftwarePackage");
            sourceFiles.Single().SoftwareSupplier.Should().Be("SoftwareSupplier");
            sourceFiles.Single().SourceFileName.Should().Be("SourceFileName");
        }

        [Fact]
        public void GetValidLearner_Test()
        {
            var learnerMock = new Mock<ILearner>();

            learnerMock.Setup(l => l.LearnRefNumber).Returns("LearnRefNumber");
            learnerMock.Setup(l => l.AccomNullable).Returns(1);
            learnerMock.Setup(l => l.AddLine1).Returns("AddLine1");
            learnerMock.Setup(l => l.AddLine2).Returns("AddLine2");
            learnerMock.Setup(l => l.AddLine3).Returns("AddLine3");
            learnerMock.Setup(l => l.AddLine4).Returns("AddLine4");
            learnerMock.Setup(l => l.ALSCostNullable).Returns(2);
            learnerMock.Setup(l => l.CampId).Returns("CampId");
            learnerMock.Setup(l => l.DateOfBirthNullable).Returns(new DateTime(2000, 01, 01));
            learnerMock.Setup(l => l.Email).Returns("Email");
            learnerMock.Setup(l => l.EngGrade).Returns("EngGrade");
            learnerMock.Setup(l => l.Ethnicity).Returns(3);
            learnerMock.Setup(l => l.FamilyName).Returns("FamilyName");
            learnerMock.Setup(l => l.GivenNames).Returns("GivenNames");
            learnerMock.Setup(l => l.LLDDHealthProb).Returns(4);
            learnerMock.Setup(l => l.MathGrade).Returns("MathGrade");
            learnerMock.Setup(l => l.NINumber).Returns("NINumber");
            learnerMock.Setup(l => l.PlanEEPHoursNullable).Returns(5);
            learnerMock.Setup(l => l.PlanLearnHoursNullable).Returns(6);
            learnerMock.Setup(l => l.PMUKPRNNullable).Returns(7);
            learnerMock.Setup(l => l.Postcode).Returns("Postcode");
            learnerMock.Setup(l => l.PostcodePrior).Returns("PostcodePrior");
            learnerMock.Setup(l => l.PrevLearnRefNumber).Returns("PrevLearnRefNumber");
            learnerMock.Setup(l => l.PrevUKPRNNullable).Returns(8);
            learnerMock.Setup(l => l.PriorAttainNullable).Returns(9);
            learnerMock.Setup(l => l.Sex).Returns("Sex");
            learnerMock.Setup(l => l.TelNo).Returns("TelNo");
            learnerMock.Setup(l => l.ULN).Returns(10);

            var learner = Mapper().BuildValidLearner(_ukprn, learnerMock.Object);

            learner.Should().NotBeNull();
            learner.UKPRN.Should().Be(_ukprn);
            learner.LearnRefNumber.Should().Be("LearnRefNumber");
            learner.Accom.Should().Be(1);
            learner.AddLine1.Should().Be("AddLine1");
            learner.AddLine2.Should().Be("AddLine2");
            learner.AddLine3.Should().Be("AddLine3");
            learner.AddLine4.Should().Be("AddLine4");
            learner.ALSCost.Should().Be(2);
            learner.CampId.Should().Be("CampId");
            learner.DateOfBirth.Should().Be(new DateTime(2000, 01, 01));
            learner.Email.Should().Be("Email");
            learner.EngGrade.Should().Be("EngGrade");
            learner.Ethnicity.Should().Be(3);
            learner.FamilyName.Should().Be("FamilyName");
            learner.GivenNames.Should().Be("GivenNames");
            learner.LLDDHealthProb.Should().Be(4);
            learner.MathGrade.Should().Be("MathGrade");
            learner.NINumber.Should().Be("NINumber");
            learner.PlanEEPHours.Should().Be(5);
            learner.PlanLearnHours.Should().Be(6);
            learner.PMUKPRN.Should().Be(7);
            learner.Postcode.Should().Be("Postcode");
            learner.PostcodePrior.Should().Be("PostcodePrior");
            learner.PrevLearnRefNumber.Should().Be("PrevLearnRefNumber");
            learner.PrevUKPRN.Should().Be(8);
            learner.PriorAttain.Should().Be(9);
            learner.Sex.Should().Be("Sex");
            learner.TelNo.Should().Be("TelNo");
            learner.ULN.Should().Be(10);
        }

        [Fact]
        public void GetContactPreference_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var contactPreferenceMock = new Mock<IContactPreference>();
            contactPreferenceMock.Setup(cp => cp.ContPrefCode).Returns(1);
            contactPreferenceMock.Setup(cp => cp.ContPrefType).Returns("ContPrefType");

            var contactPreference = Mapper().BuildContactPreference(_ukprn, learnerMock.Object, contactPreferenceMock.Object);

            contactPreference.Should().NotBeNull();
            contactPreference.UKPRN.Should().Be(_ukprn);
            contactPreference.LearnRefNumber.Should().Be("12345");
            contactPreference.ContPrefCode.Should().Be(1);
            contactPreference.ContPrefType.Should().Be("ContPrefType");
        }

        [Fact]
        public void GetLearningDelivery_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.LearnAimRef).Returns("LearnAimRef");
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);
            learningDeliveryMock.Setup(ld => ld.AchDateNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryMock.Setup(ld => ld.AddHoursNullable).Returns(2);
            learningDeliveryMock.Setup(ld => ld.AimType).Returns(3);
            learningDeliveryMock.Setup(ld => ld.CompStatus).Returns(4);
            learningDeliveryMock.Setup(ld => ld.ConRefNumber).Returns("ConRefNumber");
            learningDeliveryMock.Setup(ld => ld.DelLocPostCode).Returns("DelLocPostCode");
            learningDeliveryMock.Setup(ld => ld.EmpOutcomeNullable).Returns(5);
            learningDeliveryMock.Setup(ld => ld.EPAOrgID).Returns("EPAOrgID");
            learningDeliveryMock.Setup(ld => ld.FundModel).Returns(6);
            learningDeliveryMock.Setup(ld => ld.FworkCodeNullable).Returns(7);
            learningDeliveryMock.Setup(ld => ld.LearnActEndDateNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryMock.Setup(ld => ld.LearnPlanEndDate).Returns(new DateTime(2000, 01, 01));
            learningDeliveryMock.Setup(ld => ld.LearnStartDate).Returns(new DateTime(2000, 01, 01));
            learningDeliveryMock.Setup(ld => ld.LSDPostcode).Returns("LSDPostcode");
            learningDeliveryMock.Setup(ld => ld.OrigLearnStartDateNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryMock.Setup(ld => ld.OtherFundAdjNullable).Returns(8);
            learningDeliveryMock.Setup(ld => ld.OtjActHoursNullable).Returns(9);
            learningDeliveryMock.Setup(ld => ld.OutGrade).Returns("OutGrade");
            learningDeliveryMock.Setup(ld => ld.OutcomeNullable).Returns(10);
            learningDeliveryMock.Setup(ld => ld.PartnerUKPRNNullable).Returns(11);
            learningDeliveryMock.Setup(ld => ld.PHoursNullable).Returns(12);
            learningDeliveryMock.Setup(ld => ld.PriorLearnFundAdjNullable).Returns(13);
            learningDeliveryMock.Setup(ld => ld.ProgTypeNullable).Returns(14);
            learningDeliveryMock.Setup(ld => ld.PwayCodeNullable).Returns(15);
            learningDeliveryMock.Setup(ld => ld.StdCodeNullable).Returns(16);
            learningDeliveryMock.Setup(ld => ld.SWSupAimId).Returns("SWSupAimId");
            learningDeliveryMock.Setup(ld => ld.WithdrawReasonNullable).Returns(17);

            var learningDelivery = Mapper().BuildLearningDelivery(_ukprn, learnerMock.Object, learningDeliveryMock.Object);

            learningDelivery.Should().NotBeNull();
            learningDelivery.UKPRN.Should().Be(_ukprn);
            learningDelivery.LearnRefNumber.Should().Be("12345");
            learningDelivery.LearnAimRef.Should().Be("LearnAimRef");
            learningDelivery.AimSeqNumber.Should().Be(1);
            learningDelivery.AchDate.Should().Be(new DateTime(2000, 01, 01));
            learningDelivery.AddHours.Should().Be(2);
            learningDelivery.AimType.Should().Be(3);
            learningDelivery.CompStatus.Should().Be(4);
            learningDelivery.ConRefNumber.Should().Be("ConRefNumber");
            learningDelivery.DelLocPostCode.Should().Be("DelLocPostCode");
            learningDelivery.EmpOutcome.Should().Be(5);
            learningDelivery.EPAOrgID.Should().Be("EPAOrgID");
            learningDelivery.FundModel.Should().Be(6);
            learningDelivery.FworkCode.Should().Be(7);
            learningDelivery.LearnActEndDate.Should().Be(new DateTime(2000, 01, 01));
            learningDelivery.LearnPlanEndDate.Should().Be(new DateTime(2000, 01, 01));
            learningDelivery.LearnStartDate.Should().Be(new DateTime(2000, 01, 01));
            learningDelivery.LSDPostcode.Should().Be("LSDPostcode");
            learningDelivery.OrigLearnStartDate.Should().Be(new DateTime(2000, 01, 01));
            learningDelivery.OtherFundAdj.Should().Be(8);
            learningDelivery.OtjActHours.Should().Be(9);
            learningDelivery.OutGrade.Should().Be("OutGrade");
            learningDelivery.Outcome.Should().Be(10);
            learningDelivery.PartnerUKPRN.Should().Be(11);
            learningDelivery.PHours.Should().Be(12);
            learningDelivery.PriorLearnFundAdj.Should().Be(13);
            learningDelivery.ProgType.Should().Be(14);
            learningDelivery.PwayCode.Should().Be(15);
            learningDelivery.StdCode.Should().Be(16);
            learningDelivery.SWSupAimId.Should().Be("SWSupAimId");
            learningDelivery.WithdrawReason.Should().Be(17);
        }

        [Fact]
        public void GetLearningDeliveryHERecord_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.DOMICILE).Returns("DOMICILE");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.ELQNullable).Returns(1);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.FUNDCOMP).Returns(2);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.FUNDLEV).Returns(3);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.GROSSFEENullable).Returns(4);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.HEPostCode).Returns("HEPostCode");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.MODESTUD).Returns(5);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.MSTUFEE).Returns(6);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.NETFEENullable).Returns(7);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.NUMHUS).Returns("NUMHUS");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.PCFLDCSNullable).Returns(8);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.PCOLABNullable).Returns(9);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.PCSLDCSNullable).Returns(10);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.PCTLDCSNullable).Returns(11);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.QUALENT3).Returns("QUALENT3");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.SECNullable).Returns(12);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.SOC2000Nullable).Returns(13);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.SPECFEE).Returns(14);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.SSN).Returns("SSN");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.STULOADNullable).Returns(15);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.TYPEYR).Returns(16);
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.UCASAPPID).Returns("UCASAPPID");
            learningDeliveryMock.Setup(ld => ld.LearningDeliveryHEEntity.YEARSTU).Returns(17);

            var learningDeliveryHE = Mapper().BuildLearningDeliveryHERecord(_ukprn, learnerMock.Object, learningDeliveryMock.Object);

            learningDeliveryHE.Should().NotBeNull();
            learningDeliveryHE.UKPRN.Should().Be(_ukprn);
            learningDeliveryHE.LearnRefNumber.Should().Be("12345");
            learningDeliveryHE.AimSeqNumber.Should().Be(1);
            learningDeliveryHE.DOMICILE.Should().Be("DOMICILE");
            learningDeliveryHE.ELQ.Should().Be(1);
            learningDeliveryHE.FUNDCOMP.Should().Be(2);
            learningDeliveryHE.FUNDLEV.Should().Be(3);
            learningDeliveryHE.GROSSFEE.Should().Be(4);
            learningDeliveryHE.HEPostCode.Should().Be("HEPostCode");
            learningDeliveryHE.MODESTUD.Should().Be(5);
            learningDeliveryHE.MSTUFEE.Should().Be(6);
            learningDeliveryHE.NETFEE.Should().Be(7);
            learningDeliveryHE.NUMHUS.Should().Be("NUMHUS");
            learningDeliveryHE.PCFLDCS.Should().Be(8);
            learningDeliveryHE.PCOLAB.Should().Be(9);
            learningDeliveryHE.PCSLDCS.Should().Be(10);
            learningDeliveryHE.PCTLDCS.Should().Be(11);
            learningDeliveryHE.QUALENT3.Should().Be("QUALENT3");
            learningDeliveryHE.SEC.Should().Be(12);
            learningDeliveryHE.SOC2000.Should().Be(13);
            learningDeliveryHE.SPECFEE.Should().Be(14);
            learningDeliveryHE.SSN.Should().Be("SSN");
            learningDeliveryHE.STULOAD.Should().Be(15);
            learningDeliveryHE.TYPEYR.Should().Be(16);
            learningDeliveryHE.UCASAPPID.Should().Be("UCASAPPID");
            learningDeliveryHE.YEARSTU.Should().Be(17);
        }

        [Fact]
        public void GetLearningDeliveryAppFinRecord_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);

            var appFinRecordMock = new Mock<IAppFinRecord>();
            appFinRecordMock.Setup(afr => afr.AFinAmount).Returns(2);
            appFinRecordMock.Setup(afr => afr.AFinCode).Returns(3);
            appFinRecordMock.Setup(afr => afr.AFinDate).Returns(new DateTime(2000, 01, 01));
            appFinRecordMock.Setup(afr => afr.AFinType).Returns("AFinType");

            var appFinRecord = Mapper().BuildLearningDeliveryAppFinRecord(_ukprn, learnerMock.Object, learningDeliveryMock.Object, appFinRecordMock.Object, 0);

            appFinRecord.Should().NotBeNull();
            appFinRecord.AppFinRecord_Id.Should().Be(0);
            appFinRecord.UKPRN.Should().Be(_ukprn);
            appFinRecord.AimSeqNumber.Should().Be(1);
            appFinRecord.AFinAmount.Should().Be(2);
            appFinRecord.AFinCode.Should().Be(3);
            appFinRecord.AFinDate.Should().Be(new DateTime(2000, 01, 01));
            appFinRecord.AFinType.Should().Be("AFinType");
        }

        [Fact]
        public void GetLearningDeliveryFAMRecord_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);

            var learningDeliveryFamMock = new Mock<ILearningDeliveryFAM>();
            learningDeliveryFamMock.Setup(ldf => ldf.LearnDelFAMCode).Returns("LearnDelFAMCode");
            learningDeliveryFamMock.Setup(ldf => ldf.LearnDelFAMDateFromNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryFamMock.Setup(ldf => ldf.LearnDelFAMDateToNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryFamMock.Setup(ldf => ldf.LearnDelFAMType).Returns("LearnDelFAMType");

            var learningDeliveryFam = Mapper().BuildLearningDeliveryFAMRecord(_ukprn, learnerMock.Object, learningDeliveryMock.Object, learningDeliveryFamMock.Object, 0);

            learningDeliveryFam.Should().NotBeNull();
            learningDeliveryFam.UKPRN.Should().Be(_ukprn);
            learningDeliveryFam.LearnRefNumber.Should().Be("12345");
            learningDeliveryFam.AimSeqNumber.Should().Be(1);
            learningDeliveryFam.LearningDeliveryFAM_Id.Should().Be(0);
            learningDeliveryFam.LearnDelFAMCode.Should().Be("LearnDelFAMCode");
            learningDeliveryFam.LearnDelFAMDateFrom.Should().Be(new DateTime(2000, 01, 01));
            learningDeliveryFam.LearnDelFAMDateTo.Should().Be(new DateTime(2000, 01, 01));
            learningDeliveryFam.LearnDelFAMType.Should().Be("LearnDelFAMType");
        }

        [Fact]
        public void GetLearningDeliveryWorkPlacement_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);

            var learningDeliveryWorkPlacementMock = new Mock<ILearningDeliveryWorkPlacement>();
            learningDeliveryWorkPlacementMock.Setup(ldwp => ldwp.WorkPlaceEmpIdNullable).Returns(1);
            learningDeliveryWorkPlacementMock.Setup(ldwp => ldwp.WorkPlaceEndDateNullable).Returns(new DateTime(2000, 01, 01));
            learningDeliveryWorkPlacementMock.Setup(ldwp => ldwp.WorkPlaceHours).Returns(2);
            learningDeliveryWorkPlacementMock.Setup(ldwp => ldwp.WorkPlaceMode).Returns(3);
            learningDeliveryWorkPlacementMock.Setup(ldwp => ldwp.WorkPlaceStartDate).Returns(new DateTime(2000, 01, 01));

            var learningDeliveryWorkPlacement = Mapper().BuildLearningDeliveryWorkPlacement(_ukprn, learnerMock.Object, learningDeliveryMock.Object, learningDeliveryWorkPlacementMock.Object);

            learningDeliveryWorkPlacement.Should().NotBeNull();
            learningDeliveryWorkPlacement.UKPRN.Should().Be(_ukprn);
            learningDeliveryWorkPlacement.LearnRefNumber.Should().Be("12345");
            learningDeliveryWorkPlacement.AimSeqNumber.Should().Be(1);
            learningDeliveryWorkPlacement.WorkPlaceEmpId.Should().Be(1);
            learningDeliveryWorkPlacement.WorkPlaceEndDate.Should().Be(new DateTime(2000, 01, 01));
            learningDeliveryWorkPlacement.WorkPlaceHours.Should().Be(2);
            learningDeliveryWorkPlacement.WorkPlaceMode.Should().Be(3);
            learningDeliveryWorkPlacement.WorkPlaceStartDate.Should().Be(new DateTime(2000, 01, 01));
        }

        [Fact]
        public void GetProviderSpecDeliveryMonitoring_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learningDeliveryMock = new Mock<ILearningDelivery>();
            learningDeliveryMock.Setup(ld => ld.AimSeqNumber).Returns(1);

            var providerSpecDeliveryMonitoringMock = new Mock<IProviderSpecDeliveryMonitoring>();
            providerSpecDeliveryMonitoringMock.Setup(psdm => psdm.ProvSpecDelMon).Returns("ProvSpecDelMon");
            providerSpecDeliveryMonitoringMock.Setup(psdm => psdm.ProvSpecDelMonOccur).Returns("ProvSpecDelMonOccur");

            var providerSpecDeliveryMonitoring = Mapper().BuildProviderSpecDeliveryMonitoring(_ukprn, learnerMock.Object, learningDeliveryMock.Object, providerSpecDeliveryMonitoringMock.Object);

            providerSpecDeliveryMonitoring.Should().NotBeNull();
            providerSpecDeliveryMonitoring.UKPRN.Should().Be(_ukprn);
            providerSpecDeliveryMonitoring.LearnRefNumber.Should().Be("12345");
            providerSpecDeliveryMonitoring.AimSeqNumber.Should().Be(1);
            providerSpecDeliveryMonitoring.ProvSpecDelMon.Should().Be("ProvSpecDelMon");
            providerSpecDeliveryMonitoring.ProvSpecDelMonOccur.Should().Be("ProvSpecDelMonOccur");
        }

        [Fact]
        public void GetLearnerEmploymentStatus_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learnerEmploymentStatusMock = new Mock<ILearnerEmploymentStatus>();
            learnerEmploymentStatusMock.Setup(les => les.DateEmpStatApp).Returns(new DateTime(2000, 01, 01));
            learnerEmploymentStatusMock.Setup(les => les.EmpIdNullable).Returns(1);
            learnerEmploymentStatusMock.Setup(les => les.EmpStat).Returns(2);

            var learnerEmploymentStatus = Mapper().BuildLearnerEmploymentStatus(_ukprn, learnerMock.Object, learnerEmploymentStatusMock.Object);

            learnerEmploymentStatus.Should().NotBeNull();
            learnerEmploymentStatus.UKPRN.Should().Be(_ukprn);
            learnerEmploymentStatus.LearnRefNumber.Should().Be("12345");
            learnerEmploymentStatus.DateEmpStatApp.Should().Be(new DateTime(2000, 01, 01));
            learnerEmploymentStatus.EmpId.Should().Be(1);
            learnerEmploymentStatus.EmpStat.Should().Be(2);
        }

        [Fact]
        public void GetEmploymentStatusMonitoring_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learnerEmploymentStatusMock = new Mock<ILearnerEmploymentStatus>();
            learnerEmploymentStatusMock.Setup(les => les.DateEmpStatApp).Returns(new DateTime(2000, 01, 01));

            var employmentStatusMonitoringMock = new Mock<IEmploymentStatusMonitoring>();
            employmentStatusMonitoringMock.Setup(esm => esm.ESMCode).Returns(1);
            employmentStatusMonitoringMock.Setup(esm => esm.ESMType).Returns("ESMType");

            var employmentStatusMonitoring = Mapper().BuildEmploymentStatusMonitoring(_ukprn, learnerMock.Object, learnerEmploymentStatusMock.Object, employmentStatusMonitoringMock.Object);

            employmentStatusMonitoring.Should().NotBeNull();
            employmentStatusMonitoring.UKPRN.Should().Be(_ukprn);
            employmentStatusMonitoring.LearnRefNumber.Should().Be("12345");
            employmentStatusMonitoring.DateEmpStatApp.Should().Be(new DateTime(2000, 01, 01));
            employmentStatusMonitoring.ESMCode.Should().Be(1);
            employmentStatusMonitoring.ESMType.Should().Be("ESMType");
        }

        [Fact]
        public void GetLearnerFAM_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learnerFamMock = new Mock<ILearnerFAM>();
            learnerFamMock.Setup(lfm => lfm.LearnFAMCode).Returns(1);
            learnerFamMock.Setup(lfm => lfm.LearnFAMType).Returns("LearnFAMType");

            var learnerFam = Mapper().BuildLearnerFAM(_ukprn, learnerMock.Object, learnerFamMock.Object);

            learnerFam.Should().NotBeNull();
            learnerFam.UKPRN.Should().Be(_ukprn);
            learnerFam.LearnRefNumber.Should().Be("12345");
            learnerFam.LearnFAMCode.Should().Be(1);
            learnerFam.LearnFAMType.Should().Be("LearnFAMType");
        }

        [Fact]
        public void GetLearnerHE_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");
            learnerMock.Setup(l => l.LearnerHEEntity.TTACCOMNullable).Returns(1);
            learnerMock.Setup(l => l.LearnerHEEntity.UCASPERID).Returns("UCASPERID");

            var learnerHE = Mapper().BuildLearnerHE(_ukprn, learnerMock.Object);

            learnerHE.Should().NotBeNull();
            learnerHE.UKPRN.Should().Be(_ukprn);
            learnerHE.LearnRefNumber.Should().Be("12345");
            learnerHE.TTACCOM.Should().Be(1);
            learnerHE.UCASPERID.Should().Be("UCASPERID");
        }

        [Fact]
        public void GetLearnerHEFinancialSupport_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var learnerHEFinancialSupportMock = new Mock<ILearnerHEFinancialSupport>();
            learnerHEFinancialSupportMock.Setup(lh => lh.FINAMOUNT).Returns(1);
            learnerHEFinancialSupportMock.Setup(lh => lh.FINTYPE).Returns(2);

            var learnerHEFinancialSupport = Mapper().BuildLearnerHEFinancialSupport(_ukprn, learnerMock.Object, learnerHEFinancialSupportMock.Object);

            learnerHEFinancialSupport.Should().NotBeNull();
            learnerHEFinancialSupport.UKPRN.Should().Be(_ukprn);
            learnerHEFinancialSupport.LearnRefNumber.Should().Be("12345");
            learnerHEFinancialSupport.FINAMOUNT.Should().Be(1);
            learnerHEFinancialSupport.FINTYPE.Should().Be(2);
        }

        [Fact]
        public void GetLLDDAndHealthProblem_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var llddAndHealthProblemMock = new Mock<ILLDDAndHealthProblem>();
            llddAndHealthProblemMock.Setup(lhp => lhp.LLDDCat).Returns(1);
            llddAndHealthProblemMock.Setup(lhp => lhp.PrimaryLLDDNullable).Returns(2);

            var llddAndHealthProblem = Mapper().BuildLLDDAndHealthProblem(_ukprn, learnerMock.Object, llddAndHealthProblemMock.Object, 0);

            llddAndHealthProblem.Should().NotBeNull();
            llddAndHealthProblem.UKPRN.Should().Be(_ukprn);
            llddAndHealthProblem.LearnRefNumber.Should().Be("12345");
            llddAndHealthProblem.LLDDandHealthProblem_ID.Should().Be(0);
            llddAndHealthProblem.LLDDCat.Should().Be(1);
            llddAndHealthProblem.PrimaryLLDD.Should().Be(2);
        }

        [Fact]
        public void GetProviderSpecLearnerMonitoring_Test()
        {
            var learnerMock = new Mock<ILearner>();
            learnerMock.Setup(l => l.LearnRefNumber).Returns("12345");

            var providerSpecLearnerMonitoringMock = new Mock<IProviderSpecLearnerMonitoring>();
            providerSpecLearnerMonitoringMock.Setup(pslm => pslm.ProvSpecLearnMon).Returns("ProvSpecLearnMon");
            providerSpecLearnerMonitoringMock.Setup(pslm => pslm.ProvSpecLearnMonOccur).Returns("ProvSpecLearnMonOccur");

            var providerSpecLearnerMonitoring = Mapper().BuildProviderSpecLearnerMonitoring(_ukprn, learnerMock.Object, providerSpecLearnerMonitoringMock.Object);

            providerSpecLearnerMonitoring.Should().NotBeNull();
            providerSpecLearnerMonitoring.UKPRN.Should().Be(_ukprn);
            providerSpecLearnerMonitoring.LearnRefNumber.Should().Be("12345");
            providerSpecLearnerMonitoring.ProvSpecLearnMon.Should().Be("ProvSpecLearnMon");
            providerSpecLearnerMonitoring.ProvSpecLearnMonOccur.Should().Be("ProvSpecLearnMonOccur");
        }

        [Fact]
        public void GetLearnerDestinationAndProgression_Test()
        {
            var learnerDestinationAndProgressionMock = new Mock<ILearnerDestinationAndProgression>();
            learnerDestinationAndProgressionMock.Setup(ldp => ldp.LearnRefNumber).Returns("12345");
            learnerDestinationAndProgressionMock.Setup(ldp => ldp.ULN).Returns(1);

            var learnerDestinationAndProgression = Mapper().BuildLearnerDestinationAndProgression(_ukprn, learnerDestinationAndProgressionMock.Object);

            learnerDestinationAndProgression.Should().NotBeNull();
            learnerDestinationAndProgression.UKPRN.Should().Be(_ukprn);
            learnerDestinationAndProgression.LearnRefNumber.Should().Be("12345");
            learnerDestinationAndProgression.ULN.Should().Be(1);
        }

        [Fact]
        public void GetDPOutcome_Test()
        {
            var learnerDestinationAndProgressionMock = new Mock<ILearnerDestinationAndProgression>();
            learnerDestinationAndProgressionMock.Setup(ldp => ldp.LearnRefNumber).Returns("12345");

            var dpOutcomeMock = new Mock<IDPOutcome>();
            dpOutcomeMock.Setup(dpo => dpo.OutCode).Returns(1);
            dpOutcomeMock.Setup(dpo => dpo.OutCollDate).Returns(new DateTime(2000, 01, 01));
            dpOutcomeMock.Setup(dpo => dpo.OutEndDateNullable).Returns(new DateTime(2000, 01, 01));
            dpOutcomeMock.Setup(dpo => dpo.OutStartDate).Returns(new DateTime(2000, 01, 01));
            dpOutcomeMock.Setup(dpo => dpo.OutType).Returns("OutType");

            var dpOutcome = Mapper().BuildDPOutcome(_ukprn, learnerDestinationAndProgressionMock.Object, dpOutcomeMock.Object);

            dpOutcome.Should().NotBeNull();
            dpOutcome.UKPRN.Should().Be(_ukprn);
            dpOutcome.LearnRefNumber.Should().Be("12345");
            dpOutcome.OutCode.Should().Be(1);
            dpOutcome.OutCollDate.Should().Be(new DateTime(2000, 01, 01));
            dpOutcome.OutEndDate.Should().Be(new DateTime(2000, 01, 01));
            dpOutcome.OutStartDate.Should().Be(new DateTime(2000, 01, 01));
            dpOutcome.OutType.Should().Be("OutType");
        }

        private ValidLearnerDataMapper Mapper() => new ValidLearnerDataMapper();
    }
}
