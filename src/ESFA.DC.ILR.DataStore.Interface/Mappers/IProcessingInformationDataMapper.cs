using ESFA.DC.ILR.DataStore.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IProcessingInformationDataMapper
    {
        IDataStoreCache MapData(IDataStoreContext dataStoreContext);
    }
}
