using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IValidLearnerDataMapper
    {
        void MapLearnerData(IDataStoreCache cache, IMessage ilr, IEnumerable<string> learnersValid);
    }
}