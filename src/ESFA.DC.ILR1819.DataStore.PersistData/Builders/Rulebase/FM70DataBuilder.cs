using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.FM70.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class FM70DataBuilder : IRulebaseDataBuilder<FM70Global, IEnumerable<ESF_global>>
    {
        public FM70DataBuilder()
        {
        }

        public IEnumerable<ESF_global> BuildRulebaseData(FM70Global fundingOutput)
        {
            return new List<ESF_global>
            {
                new ESF_global()
            };
        }
    }
}