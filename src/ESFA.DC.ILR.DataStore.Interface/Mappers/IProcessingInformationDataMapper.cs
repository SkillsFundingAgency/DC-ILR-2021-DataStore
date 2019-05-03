using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IProcessingInformationDataMapper
    {
        ProcessingInformationData MapData(IDataStoreContext dataStoreContext);
    }
}
