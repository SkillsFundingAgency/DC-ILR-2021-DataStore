using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.PersistData.Builders;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM25
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        private FM25_global _fm25Global;
        private List<FM25_Learner> _learner;

        private FM25_FM35_global _periodGlobal;
        private List<FM25_FM35_Learner_Period> _periods;
        private List<FM25_FM35_Learner_PeriodisedValues> _periodValues;

        public StoreFM25(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task StoreAsync(int ukPrn, Global fundingOutputs, CancellationToken cancellationToken)
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

            await SaveData(cancellationToken);
        }

        private async Task SaveData(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using (var bulkInsert = new BulkInsert(_connection, _transaction, cancellationToken))
            {
                await bulkInsert.Insert("Rulebase.FM25_global", new List<FM25_global> { _fm25Global });
                await bulkInsert.Insert("Rulebase.FM25_Learner", _learner);
                await bulkInsert.Insert("Rulebase.FM25_FM35_global", new List<FM25_FM35_global> { _periodGlobal });
                await bulkInsert.Insert("Rulebase.FM25_FM35_Learner_Period", _periods);
                await bulkInsert.Insert("Rulebase.FM25_FM35_Learner_PeriodisedValues", _periodValues);
            }
        }
    }
}
