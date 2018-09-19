using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;

namespace ESFA.DC.ILR1819.DataStore.PersistData
{
    public class StoreFM25
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        private EFA_SFA_global _global;
        private List<EFA_SFA_Learner_Period> _periods;
        private List<EFA_SFA_Learner_PeriodisedValues> _periodValues;

        public StoreFM25(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task StoreAsync(int ukPrn, Global fundingOutputs, CancellationToken cancellationToken)
        {
            _global = new EFA_SFA_global
            {
                RulebaseVersion = fundingOutputs.RulebaseVersion,
                UKPRN = fundingOutputs.UKPRN ?? 0
            };

            _periods = new List<EFA_SFA_Learner_Period>();
            _periodValues = new List<EFA_SFA_Learner_PeriodisedValues>();

            foreach (var learner in fundingOutputs.Learners)
            {
               for (var i = 1; i < 13; i++)
                {
                    _periods.Add(new EFA_SFA_Learner_Period
                    {
                        LearnRefNumber = learner.LearnRefNumber,
                        LnrOnProgPay = learner.OnProgPayment,
                        UKPRN = ukPrn,
                        Period = i
                    });
                }

                foreach (var value in learner.LearnerPeriodisedValues)
                {
                    _periodValues.Add(new EFA_SFA_Learner_PeriodisedValues
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
                await bulkInsert.Insert("Rulebase.EFA_SFA_global", new List<EFA_SFA_global> { _global });
                await bulkInsert.Insert("Rulebase.EFA_SFA_Learner_Period", _periods);
                await bulkInsert.Insert("Rulebase.EFA_SFA_Learner_PeriodisedValues", _periodValues);
            }
        }
    }
}
