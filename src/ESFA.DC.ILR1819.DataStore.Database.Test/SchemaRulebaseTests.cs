using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model;
using Xunit;

namespace ESFA.DC.ILR1819.DataStore.Database.Test
{
    public sealed class SchemaRulebaseTests : IClassFixture<DatabaseConnectionFixture>
    {
        private readonly DatabaseConnectionFixture _fixture;

        public SchemaRulebaseTests(DatabaseConnectionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CheckColumnAEC_ApprenticeshipPriceEpisode()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("PriceEpisodeIdentifier", 3, false, 25),
                ExpectedColumn.CreateDecimal("TNP4", 4, true, 12, 5),
                ExpectedColumn.CreateDecimal("TNP1", 5, true, 12, 5),
                ExpectedColumn.CreateDate("EpisodeStartDate", 6, true),
                ExpectedColumn.CreateDecimal("TNP2", 7, true, 12, 5),
                ExpectedColumn.CreateDecimal("TNP3", 8, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeUpperBandLimit", 9, true, 12, 5),
                ExpectedColumn.CreateDate("PriceEpisodePlannedEndDate", 10, true),
                ExpectedColumn.CreateDate("PriceEpisodeActualEndDate", 11, true),
                ExpectedColumn.CreateDecimal("PriceEpisodeTotalTNPPrice", 12, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeUpperLimitAdjustment", 13, true, 12, 5),
                ExpectedColumn.CreateInt("PriceEpisodePlannedInstalments", 14, true),
                ExpectedColumn.CreateInt("PriceEpisodeActualInstalments", 15, true),
                ExpectedColumn.CreateInt("PriceEpisodeInstalmentsThisPeriod", 16, true),
                ExpectedColumn.CreateDecimal("PriceEpisodeCompletionElement", 17, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodePreviousEarnings", 18, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeInstalmentValue", 19, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeOnProgPayment", 20, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeTotalEarnings", 21, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeBalanceValue", 22, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeBalancePayment", 23, true, 12, 5),
                ExpectedColumn.CreateBit("PriceEpisodeCompleted", 24, true),
                ExpectedColumn.CreateDecimal("PriceEpisodeCompletionPayment", 25, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeRemainingTNPAmount", 26, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeRemainingAmountWithinUpperLimit", 27, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeCappedRemainingTNPAmount", 28, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeExpectedTotalMonthlyValue", 29, true, 12, 5),
                ExpectedColumn.CreateBigInt("PriceEpisodeAimSeqNumber", 30, true),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstDisadvantagePayment", 31, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondDisadvantagePayment", 32, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftBalancing", 33, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftCompletionPayment", 34, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftOnProgPayment", 35, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondProv1618Pay", 36, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstEmp1618Pay", 37, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondEmp1618Pay", 38, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstProv1618Pay", 39, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeLSFCash", 40, true, 12, 5),
                ExpectedColumn.CreateVarChar("PriceEpisodeFundLineType", 41, true, 100),
                ExpectedColumn.CreateDecimal("PriceEpisodeSFAContribPct", 42, true, 12, 5),
                ExpectedColumn.CreateInt("PriceEpisodeLevyNonPayInd", 43, true),
                ExpectedColumn.CreateDate("EpisodeEffectiveTNPStartDate", 44, true),
                ExpectedColumn.CreateDate("PriceEpisodeFirstAdditionalPaymentThresholdDate", 45, true),
                ExpectedColumn.CreateDate("PriceEpisodeSecondAdditionalPaymentThresholdDate", 46, true),
                ExpectedColumn.CreateVarChar("PriceEpisodeContractType", 47, true, 50),
                ExpectedColumn.CreateDecimal("PriceEpisodePreviousEarningsSameProvider", 48, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeTotProgFunding", 49, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeProgFundIndMinCoInvest", 50, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeProgFundIndMaxEmpCont", 51, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeTotalPMRs", 52, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeCumulativePMRs", 53, true, 12, 5),
                ExpectedColumn.CreateInt("PriceEpisodeCompExemCode", 54, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_ApprenticeshipPriceEpisode", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_ApprenticeshipPriceEpisode_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("PriceEpisodeIdentifier", 3, false, 25),
                ExpectedColumn.CreateInt("Period", 4, false),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftBalancing", 5, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftCompletionPayment", 6, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeApplic1618FrameworkUpliftOnProgPayment", 7, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeBalancePayment", 8, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeBalanceValue", 9, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeCompletionPayment", 10, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstDisadvantagePayment", 11, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstEmp1618Pay", 12, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeFirstProv1618Pay", 13, true, 12, 5),
                ExpectedColumn.CreateInt("PriceEpisodeInstalmentsThisPeriod", 14, true),
                ExpectedColumn.CreateInt("PriceEpisodeLevyNonPayInd", 15, true),
                ExpectedColumn.CreateDecimal("PriceEpisodeLSFCash", 16, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeOnProgPayment", 17, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeProgFundIndMaxEmpCont", 18, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeProgFundIndMinCoInvest", 19, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondDisadvantagePayment", 20, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondEmp1618Pay", 21, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSecondProv1618Pay", 22, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeSFAContribPct", 23, true, 12, 5),
                ExpectedColumn.CreateDecimal("PriceEpisodeTotProgFunding", 24, true, 12, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_ApprenticeshipPriceEpisode_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_ApprenticeshipPriceEpisode_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("PriceEpisodeIdentifier", 3, false, 25),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 16, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_ApprenticeshipPriceEpisode_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateVarChar("LearnRefNumber", 1, false, 12),
                ExpectedColumn.CreateInt("UKPRN", 2, false),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LARSVersion", 2, true, 100),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 3, true, 10),
                ExpectedColumn.CreateVarChar("Year", 4, true, 4)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_HistoricEarningOutput()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("AppIdentifierOutput", 3, false, 10),
                ExpectedColumn.CreateBit("AppProgCompletedInTheYearOutput", 4, true),
                ExpectedColumn.CreateInt("HistoricDaysInYearOutput", 5, true),
                ExpectedColumn.CreateDate("HistoricEffectiveTNPStartDateOutput", 6, true),
                ExpectedColumn.CreateInt("HistoricEmpIdEndWithinYearOutput", 7, true),
                ExpectedColumn.CreateInt("HistoricEmpIdStartWithinYearOutput", 8, true),
                ExpectedColumn.CreateInt("HistoricFworkCodeOutput", 9, true),
                ExpectedColumn.CreateBit("HistoricLearner1618AtStartOutput", 10, true),
                ExpectedColumn.CreateDecimal("HistoricPMRAmountOutput", 11, true, 12, 5),
                ExpectedColumn.CreateDate("HistoricProgrammeStartDateIgnorePathwayOutput", 12, true),
                ExpectedColumn.CreateDate("HistoricProgrammeStartDateMatchPathwayOutput", 13, true),
                ExpectedColumn.CreateInt("HistoricProgTypeOutput", 14, true),
                ExpectedColumn.CreateInt("HistoricPwayCodeOutput", 15, true),
                ExpectedColumn.CreateInt("HistoricSTDCodeOutput", 16, true),
                ExpectedColumn.CreateDecimal("HistoricTNP1Output", 17, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricTNP2Output", 18, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricTNP3Output", 19, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricTNP4Output", 20, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricTotal1618UpliftPaymentsInTheYear", 21, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricTotalProgAimPaymentsInTheYear", 22, true, 12, 5),
                ExpectedColumn.CreateBigInt("HistoricULNOutput", 23, true),
                ExpectedColumn.CreateDate("HistoricUptoEndDateOutput", 24, true),
                ExpectedColumn.CreateDecimal("HistoricVirtualTNP3EndofThisYearOutput", 25, true, 12, 5),
                ExpectedColumn.CreateDecimal("HistoricVirtualTNP4EndofThisYearOutput", 26, true, 12, 5),
                ExpectedColumn.CreateDate("HistoricLearnDelProgEarliestACT2DateOutput", 27, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_HistoricEarningOutput", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("ActualDaysIL", 4, true),
                ExpectedColumn.CreateInt("ActualNumInstalm", 5, true),
                ExpectedColumn.CreateDate("AdjStartDate", 6, true),
                ExpectedColumn.CreateInt("AgeAtProgStart", 7, true),
                ExpectedColumn.CreateDate("AppAdjLearnStartDate", 8, true),
                ExpectedColumn.CreateDate("AppAdjLearnStartDateMatchPathway", 9, true),
                ExpectedColumn.CreateDate("ApplicCompDate", 10, true),
                ExpectedColumn.CreateDecimal("CombinedAdjProp", 11, true, 12, 5),
                ExpectedColumn.CreateBit("Completed", 12, true),
                ExpectedColumn.CreateDate("FirstIncentiveThresholdDate", 13, true),
                ExpectedColumn.CreateBit("FundStart", 14, true),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftBalancingValue", 15, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftCompElement", 16, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FRameworkUpliftCompletionValue", 17, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftMonthInstalVal", 18, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftPrevEarnings", 19, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftPrevEarningsStage1", 20, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftRemainingAmount", 21, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftTotalActEarnings", 22, true, 12, 5),
                ExpectedColumn.CreateVarChar("LearnAimRef", 23, true, 8),
                ExpectedColumn.CreateBit("LearnDel1618AtStart", 24, true),
                ExpectedColumn.CreateInt("LearnDelAppAccDaysIL", 25, true),
                ExpectedColumn.CreateDecimal("LearnDelApplicDisadvAmount", 26, true, 12, 5),
                ExpectedColumn.CreateDecimal("LearnDelApplicEmp1618Incentive", 27, true, 12, 5),
                ExpectedColumn.CreateDate("LearnDelApplicEmpDate", 28, true),
                ExpectedColumn.CreateDecimal("LearnDelApplicProv1618FrameworkUplift", 29, true, 12, 5),
                ExpectedColumn.CreateDecimal("LearnDelApplicProv1618Incentive", 30, true, 12, 5),
                ExpectedColumn.CreateInt("LearnDelAppPrevAccDaysIL", 31, true),
                ExpectedColumn.CreateInt("LearnDelDaysIL", 32, true),
                ExpectedColumn.CreateDecimal("LearnDelDisadAmount", 33, true, 12, 5),
                ExpectedColumn.CreateBit("LearnDelEligDisadvPayment", 34, true),
                ExpectedColumn.CreateInt("LearnDelEmpIdFirstAdditionalPaymentThreshold", 35, true),
                ExpectedColumn.CreateInt("LearnDelEmpIdSecondAdditionalPaymentThreshold", 36, true),
                ExpectedColumn.CreateInt("LearnDelHistDaysThisApp", 37, true),
                ExpectedColumn.CreateDecimal("LearnDelHistProgEarnings", 38, true, 12, 5),
                ExpectedColumn.CreateVarChar("LearnDelInitialFundLineType", 39, true, 100),
                ExpectedColumn.CreateBit("LearnDelMathEng", 40, true),
                ExpectedColumn.CreateDecimal("MathEngAimValue", 41, true, 12, 5),
                ExpectedColumn.CreateInt("OutstandNumOnProgInstalm", 42, true),
                ExpectedColumn.CreateInt("PlannedNumOnProgInstalm", 43, true),
                ExpectedColumn.CreateInt("PlannedTotalDaysIL", 44, true),
                ExpectedColumn.CreateDate("SecondIncentiveThresholdDate", 45, true),
                ExpectedColumn.CreateInt("ThresholdDays", 46, true),
                ExpectedColumn.CreateDate("LearnDelProgEarliestACT2Date", 47, true),
                ExpectedColumn.CreateBit("LearnDelNonLevyProcured", 48, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_LearningDelivery_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("Period", 4, false),
                ExpectedColumn.CreateDecimal("DisadvFirstPayment", 5, true, 12, 5),
                ExpectedColumn.CreateDecimal("DisadvSecondPayment", 6, true, 12, 5),
                ExpectedColumn.CreateVarChar("FundLineType", 7, true, 100),
                ExpectedColumn.CreateInt("InstPerPeriod", 8, true),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftBalancingPayment", 9, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftCompletionPayment", 10, true, 12, 5),
                ExpectedColumn.CreateDecimal("LDApplic1618FrameworkUpliftOnProgPayment", 11, true, 12, 5),
                ExpectedColumn.CreateVarChar("LearnDelContType", 12, true, 50),
                ExpectedColumn.CreateDecimal("LearnDelFirstEmp1618Pay", 13, true, 12, 5),
                ExpectedColumn.CreateDecimal("LearnDelFirstProv1618Pay", 14, true, 12, 5),
                ExpectedColumn.CreateInt("LearnDelLevyNonPayInd", 15, true),
                ExpectedColumn.CreateDecimal("LearnDelSecondEmp1618Pay", 16, true, 12, 5),
                ExpectedColumn.CreateDecimal("LearnDelSecondProv1618Pay", 17, true, 12, 5),
                ExpectedColumn.CreateBit("LearnDelSEMContWaiver", 18, true),
                ExpectedColumn.CreateDecimal("LearnDelSFAContribPct", 19, true, 12, 5),
                ExpectedColumn.CreateBit("LearnSuppFund", 20, true),
                ExpectedColumn.CreateDecimal("LearnSuppFundCash", 21, true, 12, 5),
                ExpectedColumn.CreateDecimal("MathEngBalPayment", 22, true, 12, 5),
                ExpectedColumn.CreateDecimal("MathEngBalPct", 23, true, 12, 5),
                ExpectedColumn.CreateDecimal("MathEngOnProgPayment", 24, true, 12, 5),
                ExpectedColumn.CreateDecimal("MathEngOnProgPct", 25, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimBalPayment", 26, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimCompletionPayment", 27, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimOnProgPayment", 28, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimProgFundIndMaxEmpCont", 29, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimProgFundIndMinCoInvest", 30, true, 12, 5),
                ExpectedColumn.CreateDecimal("ProgrammeAimTotProgFund", 31, true, 12, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_LearningDelivery_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_LearningDelivery_PeriodisedTextValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateVarChar("Period_1", 5, true, 255),
                ExpectedColumn.CreateVarChar("Period_2", 6, true, 255),
                ExpectedColumn.CreateVarChar("Period_3", 7, true, 255),
                ExpectedColumn.CreateVarChar("Period_4", 8, true, 255),
                ExpectedColumn.CreateVarChar("Period_5", 9, true, 255),
                ExpectedColumn.CreateVarChar("Period_6", 10, true, 255),
                ExpectedColumn.CreateVarChar("Period_7", 11, true, 255),
                ExpectedColumn.CreateVarChar("Period_8", 12, true, 255),
                ExpectedColumn.CreateVarChar("Period_9", 13, true, 255),
                ExpectedColumn.CreateVarChar("Period_10", 14, true, 255),
                ExpectedColumn.CreateVarChar("Period_11", 15, true, 255),
                ExpectedColumn.CreateVarChar("Period_12", 16, true, 255)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_LearningDelivery_PeriodisedTextValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnAEC_LearningDelivery_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 16, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "AEC_LearningDelivery_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LARSVersion", 2, true, 100),
                ExpectedColumn.CreateVarChar("PostcodeAreaCostVersion", 3, true, 20),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 4, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_Learner_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("Period", 3, false),
                ExpectedColumn.CreateInt("ALBSeqNum", 4, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_Learner_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_Learner_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("AttributeName", 3, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 4, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 15, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_Learner_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateBit("Achieved", 4, true),
                ExpectedColumn.CreateInt("ActualNumInstalm", 5, true),
                ExpectedColumn.CreateBit("AdvLoan", 6, true),
                ExpectedColumn.CreateDate("ApplicFactDate", 7, true),
                ExpectedColumn.CreateVarChar("ApplicProgWeightFact", 8, true, 1),
                ExpectedColumn.CreateDecimal("AreaCostFactAdj", 9, true, 10, 5),
                ExpectedColumn.CreateDecimal("AreaCostInstalment", 10, true, 10, 5),
                ExpectedColumn.CreateVarChar("FundLine", 11, true, 50),
                ExpectedColumn.CreateBit("FundStart", 12, true),
                ExpectedColumn.CreateDate("LiabilityDate", 13, true),
                ExpectedColumn.CreateBit("LoanBursAreaUplift", 14, true),
                ExpectedColumn.CreateBit("LoanBursSupp", 15, true),
                ExpectedColumn.CreateInt("OutstndNumOnProgInstalm", 16, true),
                ExpectedColumn.CreateInt("PlannedNumOnProgInstalm", 17, true),
                ExpectedColumn.CreateDecimal("WeightedRate", 18, true, 10, 4)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_LearningDelivery_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("Period", 4, false),
                ExpectedColumn.CreateInt("ALBCode", 5, true),
                ExpectedColumn.CreateDecimal("ALBSupportPayment", 6, true, 10, 5),
                ExpectedColumn.CreateDecimal("AreaUpliftBalPayment", 7, true, 10, 5),
                ExpectedColumn.CreateDecimal("AreaUpliftOnProgPayment", 8, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_LearningDelivery_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnALB_LearningDelivery_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 16, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ALB_LearningDelivery_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDV_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "DV_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDV_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, true),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 2, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "DV_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDV_Learner()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("Learn_3rdSector", 3, true),
                ExpectedColumn.CreateInt("Learn_Active", 4, true),
                ExpectedColumn.CreateInt("Learn_ActiveJan", 5, true),
                ExpectedColumn.CreateInt("Learn_ActiveNov", 6, true),
                ExpectedColumn.CreateInt("Learn_ActiveOct", 7, true),
                ExpectedColumn.CreateInt("Learn_Age31Aug", 8, true),
                ExpectedColumn.CreateInt("Learn_BasicSkill", 9, true),
                ExpectedColumn.CreateInt("Learn_EmpStatFDL", 10, true),
                ExpectedColumn.CreateInt("Learn_EmpStatPrior", 11, true),
                ExpectedColumn.CreateInt("Learn_FirstFullLevel2", 12, true),
                ExpectedColumn.CreateInt("Learn_FirstFullLevel2Ach", 13, true),
                ExpectedColumn.CreateInt("Learn_FirstFullLevel3", 14, true),
                ExpectedColumn.CreateInt("Learn_FirstFullLevel3Ach", 15, true),
                ExpectedColumn.CreateInt("Learn_FullLevel2", 16, true),
                ExpectedColumn.CreateInt("Learn_FullLevel2Ach", 17, true),
                ExpectedColumn.CreateInt("Learn_FullLevel3", 18, true),
                ExpectedColumn.CreateInt("Learn_FullLevel3Ach", 19, true),
                ExpectedColumn.CreateInt("Learn_FundAgency", 20, true),
                ExpectedColumn.CreateInt("Learn_FundingSource", 21, true),
                ExpectedColumn.CreateInt("Learn_FundPrvYr", 22, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth1", 23, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth10", 24, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth11", 25, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth12", 26, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth2", 27, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth3", 28, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth4", 29, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth5", 30, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth6", 31, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth7", 32, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth8", 33, true),
                ExpectedColumn.CreateInt("Learn_ILAcMonth9", 34, true),
                ExpectedColumn.CreateInt("Learn_ILCurrAcYr", 35, true),
                ExpectedColumn.CreateInt("Learn_LargeEmployer", 36, true),
                ExpectedColumn.CreateInt("Learn_LenEmp", 37, true),
                ExpectedColumn.CreateInt("Learn_LenUnemp", 38, true),
                ExpectedColumn.CreateInt("Learn_LrnAimRecords", 39, true),
                ExpectedColumn.CreateInt("Learn_ModeAttPlanHrs", 40, true),
                ExpectedColumn.CreateInt("Learn_NotionLev", 41, true),
                ExpectedColumn.CreateInt("Learn_NotionLevV2", 42, true),
                ExpectedColumn.CreateInt("Learn_OLASS", 43, true),
                ExpectedColumn.CreateInt("Learn_PrefMethContact", 44, true),
                ExpectedColumn.CreateInt("Learn_PrimaryLLDD", 45, true),
                ExpectedColumn.CreateInt("Learn_PriorEducationStatus", 46, true),
                ExpectedColumn.CreateInt("Learn_UnempBenFDL", 47, true),
                ExpectedColumn.CreateInt("Learn_UnempBenPrior", 48, true),
                ExpectedColumn.CreateDecimal("Learn_Uplift1516EFA", 49, true, 6, 5),
                ExpectedColumn.CreateDecimal("Learn_Uplift1516SFA", 50, true, 6, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "DV_Learner", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnDV_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("LearnDel_AccToApp", 4, true),
                ExpectedColumn.CreateDate("LearnDel_AccToAppEmpDate", 5, true),
                ExpectedColumn.CreateInt("LearnDel_AccToAppEmpStat", 6, true),
                ExpectedColumn.CreateDecimal("LearnDel_AchFullLevel2Pct", 7, true, 5, 2),
                ExpectedColumn.CreateDecimal("LearnDel_AchFullLevel3Pct", 8, true, 5, 2),
                ExpectedColumn.CreateInt("LearnDel_Achieved", 9, true),
                ExpectedColumn.CreateInt("LearnDel_AchievedIY", 10, true),
                ExpectedColumn.CreateVarChar("LearnDel_AcMonthYTD", 11, true, 2),
                ExpectedColumn.CreateInt("LearnDel_ActDaysILAfterCurrAcYr", 12, true),
                ExpectedColumn.CreateInt("LearnDel_ActDaysILCurrAcYr", 13, true),
                ExpectedColumn.CreateInt("LearnDel_ActEndDateOnAfterJan1", 14, true),
                ExpectedColumn.CreateInt("LearnDel_ActEndDateOnAfterNov1", 15, true),
                ExpectedColumn.CreateInt("LearnDel_ActEndDateOnAfterOct1", 16, true),
                ExpectedColumn.CreateInt("LearnDel_ActiveIY", 17, true),
                ExpectedColumn.CreateInt("LearnDel_ActiveJan", 18, true),
                ExpectedColumn.CreateInt("LearnDel_ActiveNov", 19, true),
                ExpectedColumn.CreateInt("LearnDel_ActiveOct", 20, true),
                ExpectedColumn.CreateInt("LearnDel_ActTotalDaysIL", 21, true),
                ExpectedColumn.CreateInt("LearnDel_AdvLoan", 22, true),
                ExpectedColumn.CreateInt("LearnDel_AgeAimOrigStart", 23, true),
                ExpectedColumn.CreateInt("LearnDel_AgeAtStart", 24, true),
                ExpectedColumn.CreateInt("LearnDel_App", 25, true),
                ExpectedColumn.CreateInt("LearnDel_App1618Fund", 26, true),
                ExpectedColumn.CreateInt("LearnDel_App1925Fund", 27, true),
                ExpectedColumn.CreateInt("LearnDel_AppAimType", 28, true),
                ExpectedColumn.CreateInt("LearnDel_AppKnowl", 29, true),
                ExpectedColumn.CreateInt("LearnDel_AppMainAim", 30, true),
                ExpectedColumn.CreateInt("LearnDel_AppNonFund", 31, true),
                ExpectedColumn.CreateInt("LearnDel_BasicSkills", 32, true),
                ExpectedColumn.CreateInt("LearnDel_BasicSkillsParticipation", 33, true),
                ExpectedColumn.CreateInt("LearnDel_BasicSkillsType", 34, true),
                ExpectedColumn.CreateInt("LearnDel_CarryIn", 35, true),
                ExpectedColumn.CreateInt("LearnDel_ClassRm", 36, true),
                ExpectedColumn.CreateInt("LearnDel_CompAimApp", 37, true),
                ExpectedColumn.CreateInt("LearnDel_CompAimProg", 38, true),
                ExpectedColumn.CreateInt("LearnDel_Completed", 39, true),
                ExpectedColumn.CreateInt("LearnDel_CompletedIY", 40, true),
                ExpectedColumn.CreateDecimal("LearnDel_CompleteFullLevel2Pct", 41, true, 5, 2),
                ExpectedColumn.CreateDecimal("LearnDel_CompleteFullLevel3Pct", 42, true, 5, 2),
                ExpectedColumn.CreateInt("LearnDel_EFACoreAim", 43, true),
                ExpectedColumn.CreateInt("LearnDel_Emp6MonthAimStart", 44, true),
                ExpectedColumn.CreateInt("LearnDel_Emp6MonthProgStart", 45, true),
                ExpectedColumn.CreateDate("LearnDel_EmpDateBeforeFDL", 46, true),
                ExpectedColumn.CreateDate("LearnDel_EmpDatePriorFDL", 47, true),
                ExpectedColumn.CreateInt("LearnDel_EmpID", 48, true),
                ExpectedColumn.CreateInt("LearnDel_Employed", 49, true),
                ExpectedColumn.CreateInt("LearnDel_EmpStatFDL", 50, true),
                ExpectedColumn.CreateInt("LearnDel_EmpStatPrior", 51, true),
                ExpectedColumn.CreateInt("LearnDel_EmpStatPriorFDL", 52, true),
                ExpectedColumn.CreateInt("LearnDel_EnhanAppFund", 53, true),
                ExpectedColumn.CreateDecimal("LearnDel_FullLevel2AchPct", 54, true, 5, 2),
                ExpectedColumn.CreateDecimal("LearnDel_FullLevel2ContPct", 55, true, 5, 2),
                ExpectedColumn.CreateDecimal("LearnDel_FullLevel3AchPct", 56, true, 5, 2),
                ExpectedColumn.CreateDecimal("LearnDel_FullLevel3ContPct", 57, true, 5, 2),
                ExpectedColumn.CreateInt("LearnDel_FuncSkills", 58, true),
                ExpectedColumn.CreateInt("LearnDel_FundAgency", 59, true),
                ExpectedColumn.CreateVarChar("LearnDel_FundingLineType", 60, true, 100),
                ExpectedColumn.CreateInt("LearnDel_FundingSource", 61, true),
                ExpectedColumn.CreateInt("LearnDel_FundPrvYr", 62, true),
                ExpectedColumn.CreateInt("LearnDel_FundStart", 63, true),
                ExpectedColumn.CreateInt("LearnDel_GCE", 64, true),
                ExpectedColumn.CreateInt("LearnDel_GCSE", 65, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth1", 66, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth10", 67, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth11", 68, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth12", 69, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth2", 70, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth3", 71, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth4", 72, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth5", 73, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth6", 74, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth7", 75, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth8", 76, true),
                ExpectedColumn.CreateInt("LearnDel_ILAcMonth9", 77, true),
                ExpectedColumn.CreateInt("LearnDel_ILCurrAcYr", 78, true),
                ExpectedColumn.CreateDate("LearnDel_IYActEndDate", 79, true),
                ExpectedColumn.CreateDate("LearnDel_IYPlanEndDate", 80, true),
                ExpectedColumn.CreateDate("LearnDel_IYStartDate", 81, true),
                ExpectedColumn.CreateInt("LearnDel_KeySkills", 82, true),
                ExpectedColumn.CreateInt("LearnDel_LargeEmpDiscountId", 83, true),
                ExpectedColumn.CreateInt("LearnDel_LargeEmployer", 84, true),
                ExpectedColumn.CreateDate("LearnDel_LastEmpDate", 85, true),
                ExpectedColumn.CreateInt("LearnDel_LeaveMonth", 86, true),
                ExpectedColumn.CreateInt("LearnDel_LenEmp", 87, true),
                ExpectedColumn.CreateInt("LearnDel_LenUnemp", 88, true),
                ExpectedColumn.CreateInt("LearnDel_LoanBursFund", 89, true),
                ExpectedColumn.CreateInt("LearnDel_NotionLevel", 90, true),
                ExpectedColumn.CreateInt("LearnDel_NotionLevelV2", 91, true),
                ExpectedColumn.CreateInt("LearnDel_NumHEDatasets", 92, true),
                ExpectedColumn.CreateInt("LearnDel_OccupAim", 93, true),
                ExpectedColumn.CreateInt("LearnDel_OLASS", 94, true),
                ExpectedColumn.CreateInt("LearnDel_OLASSCom", 95, true),
                ExpectedColumn.CreateInt("LearnDel_OLASSCus", 96, true),
                ExpectedColumn.CreateDate("LearnDel_OrigStartDate", 97, true),
                ExpectedColumn.CreateInt("LearnDel_PlanDaysILAfterCurrAcYr", 98, true),
                ExpectedColumn.CreateInt("LearnDel_PlanDaysILCurrAcYr", 99, true),
                ExpectedColumn.CreateInt("LearnDel_PlanEndBeforeAug1", 100, true),
                ExpectedColumn.CreateInt("LearnDel_PlanEndOnAfterJan1", 101, true),
                ExpectedColumn.CreateInt("LearnDel_PlanEndOnAfterNov1", 102, true),
                ExpectedColumn.CreateInt("LearnDel_PlanEndOnAfterOct1", 103, true),
                ExpectedColumn.CreateInt("LearnDel_PlanTotalDaysIL", 104, true),
                ExpectedColumn.CreateInt("LearnDel_PriorEducationStatus", 105, true),
                ExpectedColumn.CreateInt("LearnDel_Prog", 106, true),
                ExpectedColumn.CreateInt("LearnDel_ProgAimAch", 107, true),
                ExpectedColumn.CreateInt("LearnDel_ProgAimApp", 108, true),
                ExpectedColumn.CreateInt("LearnDel_ProgCompleted", 109, true),
                ExpectedColumn.CreateInt("LearnDel_ProgCompletedIY", 110, true),
                ExpectedColumn.CreateDate("LearnDel_ProgStartDate", 111, true),
                ExpectedColumn.CreateInt("LearnDel_QCF", 112, true),
                ExpectedColumn.CreateInt("LearnDel_QCFCert", 113, true),
                ExpectedColumn.CreateInt("LearnDel_QCFDipl", 114, true),
                ExpectedColumn.CreateInt("LearnDel_QCFType", 115, true),
                ExpectedColumn.CreateInt("LearnDel_RegAim", 116, true),
                ExpectedColumn.CreateVarChar("LearnDel_SecSubAreaTier1", 117, true, 3),
                ExpectedColumn.CreateVarChar("LearnDel_SecSubAreaTier2", 118, true, 5),
                ExpectedColumn.CreateInt("LearnDel_SFAApproved", 119, true),
                ExpectedColumn.CreateInt("LearnDel_SourceFundEFA", 120, true),
                ExpectedColumn.CreateInt("LearnDel_SourceFundSFA", 121, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeApr1", 122, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeAug1", 123, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeDec1", 124, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeFeb1", 125, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeJan1", 126, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeJun1", 127, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeMar1", 128, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeMay1", 129, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeNov1", 130, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeOct1", 131, true),
                ExpectedColumn.CreateInt("LearnDel_StartBeforeSep1", 132, true),
                ExpectedColumn.CreateInt("LearnDel_StartIY", 133, true),
                ExpectedColumn.CreateInt("LearnDel_StartJan1", 134, true),
                ExpectedColumn.CreateInt("LearnDel_StartMonth", 135, true),
                ExpectedColumn.CreateInt("LearnDel_StartNov1", 136, true),
                ExpectedColumn.CreateInt("LearnDel_StartOct1", 137, true),
                ExpectedColumn.CreateInt("LearnDel_SuccRateStat", 138, true),
                ExpectedColumn.CreateInt("LearnDel_TrainAimType", 139, true),
                ExpectedColumn.CreateInt("LearnDel_TransferDiffProvider", 140, true),
                ExpectedColumn.CreateInt("LearnDel_TransferDiffProviderGovStrat", 141, true),
                ExpectedColumn.CreateInt("LearnDel_TransferProvider", 142, true),
                ExpectedColumn.CreateInt("LearnDel_UfIProv", 143, true),
                ExpectedColumn.CreateInt("LearnDel_UnempBenFDL", 144, true),
                ExpectedColumn.CreateInt("LearnDel_UnempBenPrior", 145, true),
                ExpectedColumn.CreateInt("LearnDel_Withdrawn", 146, true),
                ExpectedColumn.CreateVarChar("LearnDel_WorkplaceLocPostcode", 147, true, 8),
                ExpectedColumn.CreateInt("Prog_AccToApp", 148, true),
                ExpectedColumn.CreateInt("Prog_Achieved", 149, true),
                ExpectedColumn.CreateInt("Prog_AchievedIY", 150, true),
                ExpectedColumn.CreateDate("Prog_ActEndDate", 151, true),
                ExpectedColumn.CreateInt("Prog_ActiveIY", 152, true),
                ExpectedColumn.CreateInt("Prog_AgeAtStart", 153, true),
                ExpectedColumn.CreateInt("Prog_EarliestAim", 154, true),
                ExpectedColumn.CreateInt("Prog_Employed", 155, true),
                ExpectedColumn.CreateInt("Prog_FundPrvYr", 156, true),
                ExpectedColumn.CreateInt("Prog_ILCurrAcYear", 157, true),
                ExpectedColumn.CreateInt("Prog_LatestAim", 158, true),
                ExpectedColumn.CreateInt("Prog_SourceFundEFA", 159, true),
                ExpectedColumn.CreateInt("Prog_SourceFundSFA", 160, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "DV_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LARSVersion", 2, true, 50),
                ExpectedColumn.CreateVarChar("OrgVersion", 3, true, 50),
                ExpectedColumn.CreateVarChar("PostcodeDisadvantageVersion", 4, true, 50),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 5, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_Learner()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AcadMonthPayment", 3, true),
                ExpectedColumn.CreateBit("AcadProg", 4, true),
                ExpectedColumn.CreateInt("ActualDaysILCurrYear", 5, true),
                ExpectedColumn.CreateDecimal("AreaCostFact1618Hist", 6, true, 10, 5),
                ExpectedColumn.CreateDecimal("Block1DisadvUpliftNew", 7, true, 10, 5),
                ExpectedColumn.CreateDecimal("Block2DisadvElementsNew", 8, true, 10, 5),
                ExpectedColumn.CreateVarChar("ConditionOfFundingEnglish", 9, true, 100),
                ExpectedColumn.CreateVarChar("ConditionOfFundingMaths", 10, true, 100),
                ExpectedColumn.CreateInt("CoreAimSeqNumber", 11, true),
                ExpectedColumn.CreateDecimal("FullTimeEquiv", 12, true, 10, 5),
                ExpectedColumn.CreateVarChar("FundLine", 13, true, 100),
                ExpectedColumn.CreateDate("LearnerActEndDate", 14, true),
                ExpectedColumn.CreateDate("LearnerPlanEndDate", 15, true),
                ExpectedColumn.CreateDate("LearnerStartDate", 16, true),
                ExpectedColumn.CreateDecimal("NatRate", 17, true, 10, 5),
                ExpectedColumn.CreateDecimal("OnProgPayment", 18, true, 10, 5),
                ExpectedColumn.CreateInt("PlannedDaysILCurrYear", 19, true),
                ExpectedColumn.CreateDecimal("ProgWeightHist", 20, true, 10, 5),
                ExpectedColumn.CreateDecimal("ProgWeightNew", 21, true, 10, 5),
                ExpectedColumn.CreateDecimal("PrvDisadvPropnHist", 22, true, 10, 5),
                ExpectedColumn.CreateDecimal("PrvHistLrgProgPropn", 23, true, 10, 5),
                ExpectedColumn.CreateDecimal("PrvRetentFactHist", 24, true, 10, 5),
                ExpectedColumn.CreateVarChar("RateBand", 25, true, 50),
                ExpectedColumn.CreateDecimal("RetentNew", 26, true, 10, 5),
                ExpectedColumn.CreateBit("StartFund", 27, true),
                ExpectedColumn.CreateInt("ThresholdDays", 28, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_Learner", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_SFA_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_SFA_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_SFA_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 2, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_SFA_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_SFA_Learner_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("Period", 3, false),
                ExpectedColumn.CreateDecimal("LnrOnProgPay", 4, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_SFA_Learner_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnEFA_SFA_Learner_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateVarChar("AttributeName", 3, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 4, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 15, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "EFA_SFA_Learner_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_DPOutcome()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("OutCode", 3, false),
                ExpectedColumn.CreateVarChar("OutType", 4, false, 30),
                ExpectedColumn.CreateDate("OutStartDate", 5, false),
                ExpectedColumn.CreateDate("OutcomeDateForProgression", 6, true),
                ExpectedColumn.CreateBit("PotentialESFProgressionType", 7, true),
                ExpectedColumn.CreateVarChar("ProgressionType", 8, true, 50),
                ExpectedColumn.CreateBit("ReachedSixMonthPoint", 9, true),
                ExpectedColumn.CreateBit("ReachedThreeMonthPoint", 10, true),
                ExpectedColumn.CreateBit("ReachedTwelveMonthPoint", 11, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_DPOutcome", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, true),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 2, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateBit("Achieved", 4, true),
                ExpectedColumn.CreateBit("AddProgCostElig", 5, true),
                ExpectedColumn.CreateDecimal("AdjustedAreaCostFactor", 6, true, 9, 5),
                ExpectedColumn.CreateDecimal("AdjustedPremiumFactor", 7, true, 9, 5),
                ExpectedColumn.CreateDate("AdjustedStartDate", 8, true),
                ExpectedColumn.CreateVarChar("AimClassification", 9, true, 50),
                ExpectedColumn.CreateDecimal("AimValue", 10, true, 10, 5),
                ExpectedColumn.CreateDecimal("ApplicWeightFundRate", 11, true, 10, 5),
                ExpectedColumn.CreateBigInt("EligibleProgressionOutcomeCode", 12, true),
                ExpectedColumn.CreateVarChar("EligibleProgressionOutcomeType", 13, true, 4),
                ExpectedColumn.CreateDate("EligibleProgressionOutomeStartDate", 14, true),
                ExpectedColumn.CreateBit("FundStart", 15, true),
                ExpectedColumn.CreateDecimal("LARSWeightedRate", 16, true, 10, 5),
                ExpectedColumn.CreateDate("LatestPossibleStartDate", 17, true),
                ExpectedColumn.CreateDate("LDESFEngagementStartDate", 18, true),
                ExpectedColumn.CreateBit("PotentiallyEligibleForProgression", 19, true),
                ExpectedColumn.CreateDate("ProgressionEndDate", 20, true),
                ExpectedColumn.CreateBit("Restart", 21, true),
                ExpectedColumn.CreateDecimal("WeightedRateFromESOL", 22, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_LearningDeliveryDeliverable()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("DeliverableCode", 4, false, 5),
                ExpectedColumn.CreateDecimal("DeliverableUnitCost", 5, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_LearningDeliveryDeliverable", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_LearningDeliveryDeliverable_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("DeliverableCode", 4, false, 5),
                ExpectedColumn.CreateInt("Period", 5, false),
                ExpectedColumn.CreateDecimal("AchievementEarnings", 6, true, 10, 5),
                ExpectedColumn.CreateDecimal("AdditionalProgCostEarnings", 7, true, 10, 5),
                ExpectedColumn.CreateBigInt("DeliverableVolume", 8, true),
                ExpectedColumn.CreateDecimal("ProgressionEarnings", 9, true, 10, 5),
                ExpectedColumn.CreateInt("ReportingVolume", 10, true),
                ExpectedColumn.CreateDecimal("StartEarnings", 11, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_LearningDeliveryDeliverable_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESF_LearningDeliveryDeliverable_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("DeliverableCode", 4, false, 5),
                ExpectedColumn.CreateVarChar("AttributeName", 5, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 16, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 17, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESF_LearningDeliveryDeliverable_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESFVAL_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("Learner_Id", 1, false),
                ExpectedColumn.CreateInt("UKPRN", 2, true),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESFVAL_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESFVAL_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 2, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESFVAL_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnESFVAL_ValidationError()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 2, false),
                ExpectedColumn.CreateVarChar("ErrorString", 3, true, 2000),
                ExpectedColumn.CreateVarChar("FieldValues", 4, true, 2000),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 5, false, 100),
                ExpectedColumn.CreateVarChar("RuleId", 6, true, 50)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "ESFVAL_ValidationError", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSFA_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "SFA_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSFA_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateVarChar("UKPRN", 1, false, 8),
                ExpectedColumn.CreateVarChar("CurFundYr", 2, true, 9),
                ExpectedColumn.CreateVarChar("LARSVersion", 3, true, 100),
                ExpectedColumn.CreateVarChar("OrgVersion", 4, true, 100),
                ExpectedColumn.CreateVarChar("PostcodeDisadvantageVersion", 5, true, 50),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 6, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "SFA_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSFA_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateDate("AchApplicDate", 4, true),
                ExpectedColumn.CreateBit("Achieved", 5, true),
                ExpectedColumn.CreateDecimal("AchieveElement", 6, true, 10, 5),
                ExpectedColumn.CreateBit("AchievePayElig", 7, true),
                ExpectedColumn.CreateDecimal("AchievePayPctPreTrans", 8, true, 10, 5),
                ExpectedColumn.CreateDecimal("AchPayTransHeldBack", 9, true, 10, 5),
                ExpectedColumn.CreateInt("ActualDaysIL", 10, true),
                ExpectedColumn.CreateInt("ActualNumInstalm", 11, true),
                ExpectedColumn.CreateInt("ActualNumInstalmPreTrans", 12, true),
                ExpectedColumn.CreateInt("ActualNumInstalmTrans", 13, true),
                ExpectedColumn.CreateDate("AdjLearnStartDate", 14, true),
                ExpectedColumn.CreateBit("AdltLearnResp", 15, true),
                ExpectedColumn.CreateInt("AgeAimStart", 16, true),
                ExpectedColumn.CreateDecimal("AimValue", 17, true, 10, 5),
                ExpectedColumn.CreateDate("AppAdjLearnStartDate", 18, true),
                ExpectedColumn.CreateDecimal("AppAgeFact", 19, true, 10, 5),
                ExpectedColumn.CreateBit("AppATAGTA", 20, true),
                ExpectedColumn.CreateBit("AppCompetency", 21, true),
                ExpectedColumn.CreateBit("AppFuncSkill", 22, true),
                ExpectedColumn.CreateDecimal("AppFuncSkill1618AdjFact", 23, true, 10, 5),
                ExpectedColumn.CreateBit("AppKnowl", 24, true),
                ExpectedColumn.CreateDate("AppLearnStartDate", 25, true),
                ExpectedColumn.CreateDate("ApplicEmpFactDate", 26, true),
                ExpectedColumn.CreateDate("ApplicFactDate", 27, true),
                ExpectedColumn.CreateDate("ApplicFundRateDate", 28, true),
                ExpectedColumn.CreateVarChar("ApplicProgWeightFact", 29, true, 1),
                ExpectedColumn.CreateDecimal("ApplicUnweightFundRate", 30, true, 10, 5),
                ExpectedColumn.CreateDecimal("ApplicWeightFundRate", 31, true, 10, 5),
                ExpectedColumn.CreateBit("AppNonFund", 32, true),
                ExpectedColumn.CreateDecimal("AreaCostFactAdj", 33, true, 10, 5),
                ExpectedColumn.CreateInt("BalInstalmPreTrans", 34, true),
                ExpectedColumn.CreateDecimal("BaseValueUnweight", 35, true, 10, 5),
                ExpectedColumn.CreateDecimal("CapFactor", 36, true, 10, 5),
                ExpectedColumn.CreateDecimal("DisUpFactAdj", 37, true, 10, 4),
                ExpectedColumn.CreateBit("EmpOutcomePayElig", 38, true),
                ExpectedColumn.CreateDecimal("EmpOutcomePctHeldBackTrans", 39, true, 10, 5),
                ExpectedColumn.CreateDecimal("EmpOutcomePctPreTrans", 40, true, 10, 5),
                ExpectedColumn.CreateBit("EmpRespOth", 41, true),
                ExpectedColumn.CreateBit("ESOL", 42, true),
                ExpectedColumn.CreateBit("FullyFund", 43, true),
                ExpectedColumn.CreateVarChar("FundLine", 44, true, 100),
                ExpectedColumn.CreateBit("FundStart", 45, true),
                ExpectedColumn.CreateInt("LargeEmployerID", 46, true),
                ExpectedColumn.CreateDecimal("LargeEmployerSFAFctr", 47, true, 10, 2),
                ExpectedColumn.CreateDate("LargeEmployerStatusDate", 48, true),
                ExpectedColumn.CreateDecimal("LTRCUpliftFctr", 49, true, 10, 5),
                ExpectedColumn.CreateDecimal("NonGovCont", 50, true, 10, 5),
                ExpectedColumn.CreateBit("OLASSCustody", 51, true),
                ExpectedColumn.CreateDecimal("OnProgPayPctPreTrans", 52, true, 10, 5),
                ExpectedColumn.CreateInt("OutstndNumOnProgInstalm", 53, true),
                ExpectedColumn.CreateInt("OutstndNumOnProgInstalmTrans", 54, true),
                ExpectedColumn.CreateInt("PlannedNumOnProgInstalm", 55, true),
                ExpectedColumn.CreateInt("PlannedNumOnProgInstalmTrans", 56, true),
                ExpectedColumn.CreateInt("PlannedTotalDaysIL", 57, true),
                ExpectedColumn.CreateInt("PlannedTotalDaysILPreTrans", 58, true),
                ExpectedColumn.CreateDecimal("PropFundRemain", 59, true, 10, 2),
                ExpectedColumn.CreateDecimal("PropFundRemainAch", 60, true, 10, 2),
                ExpectedColumn.CreateBit("PrscHEAim", 61, true),
                ExpectedColumn.CreateBit("Residential", 62, true),
                ExpectedColumn.CreateBit("Restart", 63, true),
                ExpectedColumn.CreateDecimal("SpecResUplift", 64, true, 10, 5),
                ExpectedColumn.CreateDecimal("StartPropTrans", 65, true, 10, 5),
                ExpectedColumn.CreateInt("ThresholdDays", 66, true),
                ExpectedColumn.CreateBit("Traineeship", 67, true),
                ExpectedColumn.CreateBit("Trans", 68, true),
                ExpectedColumn.CreateDate("TrnAdjLearnStartDate", 69, true),
                ExpectedColumn.CreateBit("TrnWorkPlaceAim", 70, true),
                ExpectedColumn.CreateBit("TrnWorkPrepAim", 71, true),
                ExpectedColumn.CreateDecimal("UnWeightedRateFromESOL", 72, true, 10, 5),
                ExpectedColumn.CreateDecimal("UnweightedRateFromLARS", 73, true, 10, 5),
                ExpectedColumn.CreateDecimal("WeightedRateFromESOL", 74, true, 10, 5),
                ExpectedColumn.CreateDecimal("WeightedRateFromLARS", 75, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "SFA_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSFA_LearningDelivery_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("Period", 4, false),
                ExpectedColumn.CreateDecimal("AchievePayment", 5, true, 10, 5),
                ExpectedColumn.CreateDecimal("AchievePayPct", 6, true, 10, 5),
                ExpectedColumn.CreateDecimal("AchievePayPctTrans", 7, true, 10, 5),
                ExpectedColumn.CreateDecimal("BalancePayment", 8, true, 10, 5),
                ExpectedColumn.CreateDecimal("BalancePaymentUncapped", 9, true, 10, 5),
                ExpectedColumn.CreateDecimal("BalancePct", 10, true, 10, 5),
                ExpectedColumn.CreateDecimal("BalancePctTrans", 11, true, 10, 5),
                ExpectedColumn.CreateDecimal("EmpOutcomePay", 12, true, 10, 5),
                ExpectedColumn.CreateDecimal("EmpOutcomePct", 13, true, 10, 5),
                ExpectedColumn.CreateDecimal("EmpOutcomePctTrans", 14, true, 10, 5),
                ExpectedColumn.CreateInt("InstPerPeriod", 15, true),
                ExpectedColumn.CreateBit("LearnSuppFund", 16, true),
                ExpectedColumn.CreateDecimal("LearnSuppFundCash", 17, true, 10, 5),
                ExpectedColumn.CreateDecimal("OnProgPayment", 18, true, 10, 5),
                ExpectedColumn.CreateDecimal("OnProgPaymentUncapped", 19, true, 10, 5),
                ExpectedColumn.CreateDecimal("OnProgPayPct", 20, true, 10, 5),
                ExpectedColumn.CreateDecimal("OnProgPayPctTrans", 21, true, 10, 5),
                ExpectedColumn.CreateInt("TransInstPerPeriod", 22, true)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "SFA_LearningDelivery_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnSFA_LearningDelivery_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 16, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "SFA_LearningDelivery_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnTBL_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "TBL_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnTBL_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("CurFundYr", 2, true, 10),
                ExpectedColumn.CreateVarChar("LARSVersion", 3, true, 100),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 4, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "TBL_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnTBL_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateDate("ProgStandardStartDate", 4, true),
                ExpectedColumn.CreateVarChar("FundLine", 5, true, 50),
                ExpectedColumn.CreateDecimal("MathEngAimValue", 6, true, 10, 5),
                ExpectedColumn.CreateInt("PlannedNumOnProgInstalm", 7, true),
                ExpectedColumn.CreateDecimal("LearnSuppFundCash", 8, true, 10, 5),
                ExpectedColumn.CreateDate("AdjProgStartDate", 9, true),
                ExpectedColumn.CreateBit("LearnSuppFund", 10, true),
                ExpectedColumn.CreateDecimal("MathEngOnProgPayment", 11, true, 10, 5),
                ExpectedColumn.CreateInt("InstPerPeriod", 12, true),
                ExpectedColumn.CreateDecimal("SmallBusPayment", 13, true, 10, 5),
                ExpectedColumn.CreateDecimal("YoungAppSecondPayment", 14, true, 10, 5),
                ExpectedColumn.CreateDecimal("CoreGovContPayment", 15, true, 10, 5),
                ExpectedColumn.CreateBit("YoungAppEligible", 16, true),
                ExpectedColumn.CreateBit("SmallBusEligible", 17, true),
                ExpectedColumn.CreateInt("MathEngOnProgPct", 18, true),
                ExpectedColumn.CreateInt("AgeStandardStart", 19, true),
                ExpectedColumn.CreateDate("YoungAppSecondThresholdDate", 20, true),
                ExpectedColumn.CreateInt("EmpIdFirstDayStandard", 21, true),
                ExpectedColumn.CreateInt("EmpIdFirstYoungAppDate", 22, true),
                ExpectedColumn.CreateInt("EmpIdSecondYoungAppDate", 23, true),
                ExpectedColumn.CreateInt("EmpIdSmallBusDate", 24, true),
                ExpectedColumn.CreateDate("YoungAppFirstThresholdDate", 25, true),
                ExpectedColumn.CreateDate("AchApplicDate", 26, true),
                ExpectedColumn.CreateBit("AchEligible", 27, true),
                ExpectedColumn.CreateBit("Achieved", 28, true),
                ExpectedColumn.CreateDecimal("AchievementApplicVal", 29, true, 10, 5),
                ExpectedColumn.CreateDecimal("AchPayment", 30, true, 10, 5),
                ExpectedColumn.CreateInt("ActualNumInstalm", 31, true),
                ExpectedColumn.CreateBigInt("CombinedAdjProp", 32, true),
                ExpectedColumn.CreateInt("EmpIdAchDate", 33, true),
                ExpectedColumn.CreateInt("LearnDelDaysIL", 34, true),
                ExpectedColumn.CreateInt("LearnDelStandardAccDaysIL", 35, true),
                ExpectedColumn.CreateInt("LearnDelStandardPrevAccDaysIL", 36, true),
                ExpectedColumn.CreateInt("LearnDelStandardTotalDaysIL", 37, true),
                ExpectedColumn.CreateInt("ActualDaysIL", 38, true),
                ExpectedColumn.CreateDecimal("MathEngBalPayment", 39, true, 10, 5),
                ExpectedColumn.CreateBigInt("MathEngBalPct", 40, true),
                ExpectedColumn.CreateBit("MathEngLSFFundStart", 41, true),
                ExpectedColumn.CreateInt("PlannedTotalDaysIL", 42, true),
                ExpectedColumn.CreateInt("MathEngLSFThresholdDays", 43, true),
                ExpectedColumn.CreateInt("OutstandNumOnProgInstalm", 44, true),
                ExpectedColumn.CreateDecimal("SmallBusApplicVal", 45, true, 10, 5),
                ExpectedColumn.CreateInt("SmallBusStatusFirstDayStandard", 46, true),
                ExpectedColumn.CreateInt("SmallBusStatusThreshold", 47, true),
                ExpectedColumn.CreateDecimal("YoungAppApplicVal", 48, true, 10, 5),
                ExpectedColumn.CreateBigInt("CoreGovContCapApplicVal", 49, true),
                ExpectedColumn.CreateDecimal("CoreGovContUncapped", 50, true, 10, 5),
                ExpectedColumn.CreateDate("ApplicFundValDate", 51, true),
                ExpectedColumn.CreateDecimal("YoungAppFirstPayment", 52, true, 10, 5),
                ExpectedColumn.CreateDecimal("YoungAppPayment", 53, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "TBL_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnTBL_LearningDelivery_Period()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateInt("Period", 4, false),
                ExpectedColumn.CreateDecimal("AchPayment", 5, true, 10, 5),
                ExpectedColumn.CreateDecimal("CoreGovContPayment", 6, true, 10, 5),
                ExpectedColumn.CreateDecimal("CoreGovContUncapped", 7, true, 10, 5),
                ExpectedColumn.CreateInt("InstPerPeriod", 8, true),
                ExpectedColumn.CreateBit("LearnSuppFund", 9, true),
                ExpectedColumn.CreateDecimal("LearnSuppFundCash", 10, true, 10, 5),
                ExpectedColumn.CreateDecimal("MathEngBalPayment", 11, true, 10, 5),
                ExpectedColumn.CreateDecimal("MathEngBalPct", 12, true, 8, 5),
                ExpectedColumn.CreateDecimal("MathEngOnProgPayment", 13, true, 10, 5),
                ExpectedColumn.CreateDecimal("MathEngOnProgPct", 14, true, 8, 5),
                ExpectedColumn.CreateDecimal("SmallBusPayment", 15, true, 10, 5),
                ExpectedColumn.CreateDecimal("YoungAppFirstPayment", 16, true, 10, 5),
                ExpectedColumn.CreateDecimal("YoungAppPayment", 17, true, 10, 5),
                ExpectedColumn.CreateDecimal("YoungAppSecondPayment", 18, true, 10, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "TBL_LearningDelivery_Period", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnTBL_LearningDelivery_PeriodisedValues()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12),
                ExpectedColumn.CreateInt("AimSeqNumber", 3, false),
                ExpectedColumn.CreateVarChar("AttributeName", 4, false, 100),
                ExpectedColumn.CreateDecimal("Period_1", 5, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_2", 6, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_3", 7, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_4", 8, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_5", 9, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_6", 10, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_7", 11, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_8", 12, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_9", 13, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_10", 14, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_11", 15, true, 15, 5),
                ExpectedColumn.CreateDecimal("Period_12", 16, true, 15, 5)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "TBL_LearningDelivery_PeriodisedValues", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVAL_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateInt("Learner_Id", 2, false),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VAL_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVAL_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("EmployerVersion", 2, true, 50),
                ExpectedColumn.CreateVarChar("LARSVersion", 3, true, 50),
                ExpectedColumn.CreateVarChar("OrgVersion", 4, true, 50),
                ExpectedColumn.CreateVarChar("PostcodeVersion", 5, true, 50),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 6, true, 10)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VAL_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVAL_Learner()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 2, false, 12)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VAL_Learner", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVAL_LearningDelivery()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateInt("AimSeqNumber", 2, false)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VAL_LearningDelivery", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVAL_ValidationError()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 2, false),
                ExpectedColumn.CreateVarChar("ErrorString", 3, true, 2000),
                ExpectedColumn.CreateVarChar("FieldValues", 4, true, 2000),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 5, false, 100),
                ExpectedColumn.CreateVarChar("RuleId", 6, true, 50)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VAL_ValidationError", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVALDP_Cases()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateInt("LearnerDestinationAndProgression_Id", 2, false),
                // ExpectedColumn.CreateXml("CaseData", 3, false, -1)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VALDP_Cases", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVALDP_global()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("OrgVersion", 2, true, 50),
                ExpectedColumn.CreateVarChar("RulebaseVersion", 3, true, 10),
                ExpectedColumn.CreateVarChar("ULNVersion", 4, true, 50)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VALDP_global", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVALDP_ValidationError()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateVarChar("ErrorString", 2, true, 2000),
                ExpectedColumn.CreateVarChar("FieldValues", 3, true, 2000),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 4, false, 100),
                ExpectedColumn.CreateVarChar("RuleId", 5, true, 50)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VALDP_ValidationError", expectedColumns, true);
        }

        [Fact]
        public void CheckColumnVALFD_ValidationError()
        {
            List<ExpectedColumn> expectedColumns = new List<ExpectedColumn>
            {
                ExpectedColumn.CreateInt("UKPRN", 1, false),
                ExpectedColumn.CreateBigInt("AimSeqNumber", 2, false),
                ExpectedColumn.CreateVarChar("ErrorString", 3, true, 2000),
                ExpectedColumn.CreateVarChar("FieldValues", 4, true, 2000),
                ExpectedColumn.CreateVarChar("LearnRefNumber", 5, false, 100),
                ExpectedColumn.CreateVarChar("RuleId", 6, true, 50)
            };
            _fixture.SchemaTests.AssertTableColumnsExist("Rulebase", "VALFD_ValidationError", expectedColumns, true);
        }
    }
}
