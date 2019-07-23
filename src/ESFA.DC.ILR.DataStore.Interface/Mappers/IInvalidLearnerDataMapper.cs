using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IInvalidLearnerDataMapper
    {
        void MapInvalidLearnerData(IDataStoreCache cache, ILooseMessage ilr, IEnumerable<string> learnersValid);
    }
}