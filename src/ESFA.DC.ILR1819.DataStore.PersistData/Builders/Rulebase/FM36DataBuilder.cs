using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM36.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM36DataBuilder : IRulebaseDataBuilder<FM36Global, IEnumerable<AEC_global>>
    {
        public FM36DataBuilder()
        {
        }

        public IEnumerable<AEC_global> BuildRulebaseData(FM36Global fundingOutput)
        {
            return new List<AEC_global>
            {
                new AEC_global()
            };
        }
    }
}