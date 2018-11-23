using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.FundingOutput.Model.Output;
using ESFA.DC.ILR1819.DataStore.EF;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Builders.Rulebase
{
    public class ALBDataBuilder : IRulebaseDataBuilder<ALBGlobal, IEnumerable<ALB_global>>
    {
        public ALBDataBuilder()
        {
        }

        public IEnumerable<ALB_global> BuildRulebaseData(ALBGlobal fundingOutput)
        {
            return new List<ALB_global>
            {
                new ALB_global()
            };
        }
    }
}