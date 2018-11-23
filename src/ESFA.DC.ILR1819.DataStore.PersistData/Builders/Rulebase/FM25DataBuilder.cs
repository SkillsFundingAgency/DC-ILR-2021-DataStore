using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM25.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM25DataBuilder : IRulebaseDataBuilder<FM25Global, IEnumerable<FM25_global>>
    {
        public FM25DataBuilder()
        {
        }

        public IEnumerable<FM25_global> BuildRulebaseData(FM25Global fundingOutput)
        {
            return new List<FM25_global>
            {
                new FM25_global()
            };
        }
    }
}