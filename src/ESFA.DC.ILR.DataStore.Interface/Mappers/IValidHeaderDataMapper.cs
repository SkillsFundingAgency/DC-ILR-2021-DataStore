using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IValidHeaderDataMapper
    {
        ValidHeaderData MapData(IMessage message);
    }
}
