using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface ILearnerValidDataBuilder
    {
        ValidLearnerData BuildValidLearnerData(IMessage ilr, List<string> learnersValid);
    }
}