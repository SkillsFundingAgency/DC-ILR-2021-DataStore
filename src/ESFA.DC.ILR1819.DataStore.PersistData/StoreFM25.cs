using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM25 : IStoreFM25
    {
        private FM25_global _fm25Global;
        private List<FM25_Learner> _learner;

        private FM25_FM35_global _periodGlobal;
        private List<FM25_FM35_Learner_Period> _periods;
        private List<FM25_FM35_Learner_PeriodisedValues> _periodValues;

        public async Task StoreAsync(SqlConnection connection, SqlTransaction transaction, int ukPrn, FM25Global fundingOutputs, CancellationToken cancellationToken)
        {
            _fm25Global = new FM25_global
            {
                LARSVersion = fundingOutputs.LARSVersion,
                OrgVersion = fundingOutputs.OrgVersion,
                PostcodeDisadvantageVersion = fundingOutputs.PostcodeDisadvantageVersion,
                RulebaseVersion = fundingOutputs.RulebaseVersion,
                UKPRN = ukPrn
            };

            _periodGlobal = new FM25_FM35_global
            {
                RulebaseVersion = fundingOutputs.RulebaseVersion,
                UKPRN = ukPrn
            };

            StoreGlobal(connection, transaction, cancellationToken);

            if (fundingOutputs.Learners == null || !fundingOutputs.Learners.Any())
            {
                return;
            }

            _learner = new List<FM25_Learner>();
            _periods = new List<FM25_FM35_Learner_Period>();
            _periodValues = new List<FM25_FM35_Learner_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
                _learner.Add(FM25LearnerBuilder.BuildFm25Learner(ukPrn, learner));

               for (var i = 1; i < 13; i++)
                {
                    _periods.Add(new FM25_FM35_Learner_Period
                    {
                        LearnRefNumber = learner.LearnRefNumber,
                        LnrOnProgPay = learner.OnProgPayment,
                        UKPRN = ukPrn,
                        Period = i
                    });
                }

                foreach (var value in learner.LearnerPeriodisedValues)
                {
                    _periodValues.Add(new FM25_FM35_Learner_PeriodisedValues
                    {
                        UKPRN = ukPrn,
                        LearnRefNumber = value.LearnRefNumber,
                        AttributeName = value.AttributeName,
                        Period_1 = value.Period1,
                        Period_2 = value.Period2,
                        Period_3 = value.Period3,
                        Period_4 = value.Period4,
                        Period_5 = value.Period5,
                        Period_6 = value.Period6,
                        Period_7 = value.Period7,
                        Period_8 = value.Period8,
                        Period_9 = value.Period9,
                        Period_10 = value.Period10,
                        Period_11 = value.Period11,
                        Period_12 = value.Period12,
                    });
                }
            }

            await SaveData(connection, transaction, cancellationToken);
        }

        private async void StoreGlobal(
            SqlConnection connection,
            SqlTransaction transaction,
            CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (var bulkInsert = new BulkInsert(connection, transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.FM25_global", new List<FM25_global> { _fm25Global });
                await bulkInsert.Insert("Rulebase.FM25_FM35_global", new List<FM25_FM35_global> { _periodGlobal });
            }
        }

        private async Task SaveData(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (var bulkInsert = new BulkInsert(connection, transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.FM25_Learner", _learner);
                await bulkInsert.Insert("Rulebase.FM25_FM35_Learner_Period", _periods);
                await bulkInsert.Insert("Rulebase.FM25_FM35_Learner_PeriodisedValues", _periodValues);
            }
        }
    }
}
