using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IInvalidLearnerDataMapper
    {
        IDataStoreCache MapInvalidLearnerData(IMessage ilr, IEnumerable<string> validLearners);
    }
}