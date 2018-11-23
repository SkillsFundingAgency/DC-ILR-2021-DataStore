using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM81.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM81DataBuilder : IRulebaseDataBuilder<FM81Global, IEnumerable<TBL_global>>
    {
        public FM81DataBuilder()
        {
        }

        public IEnumerable<TBL_global> BuildRulebaseData(FM81Global fundingOutput)
        {
            return new List<TBL_global>
            {
                new TBL_global()
            };
        }
    }
}