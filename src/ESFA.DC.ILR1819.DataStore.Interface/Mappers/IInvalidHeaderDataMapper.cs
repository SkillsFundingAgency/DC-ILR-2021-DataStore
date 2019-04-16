using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IInvalidHeaderDataMapper
    {
        InvalidHeaderData MapData(IMessage message);
    }
}
