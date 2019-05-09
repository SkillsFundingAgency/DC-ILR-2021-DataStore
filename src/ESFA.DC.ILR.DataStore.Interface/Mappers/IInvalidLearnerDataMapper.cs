using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IInvalidLearnerDataMapper
    {
        InvalidLearnerData MapInvalidLearnerData(IMessage ilr, IEnumerable<string> validLearners);
    }
}