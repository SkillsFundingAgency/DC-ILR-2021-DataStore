using ESFA.DC.ILR.Constants;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop.Context
{
    public class DataStoreContextFactory : IDataStoreContextFactory<IDesktopContext>
    {
        public IDataStoreContext Build(IDesktopContext desktopContext)
        {
            return new DataStoreDesktopContext(desktopContext, ILRContextKeys.DataStoreTasks);
        }
    }
}
