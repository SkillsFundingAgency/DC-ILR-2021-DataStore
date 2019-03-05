using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IInvalidLearnerDataMapper
    {
        InvalidLearnerData MapInvalidLearnerData(IMessage ilr, IEnumerable<string> validLearners);
    }
}