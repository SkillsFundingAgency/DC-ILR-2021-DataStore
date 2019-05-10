using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.DataStore.Interface
{
    public interface IDataStoreContextFactory<T>
    {
        IDataStoreContext Build(T context);
    }
}
