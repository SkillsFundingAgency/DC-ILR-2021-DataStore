using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IProcessingInformationDataMapper
    {
        void MapData(IDataStoreCache cache, ReferenceDataVersions referenceDataVersions, IDataStoreContext dataStoreContext);
    }
}
