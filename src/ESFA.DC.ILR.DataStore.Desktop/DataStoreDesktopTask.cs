﻿using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Interface;
using ESFA.DC.ILR.Desktop.Interface;

namespace ESFA.DC.ILR.DataStore.Desktop
{
    public class DataStoreDesktopTask : IDesktopTask
    {
        private readonly IEntryPoint _entryPoint;
        private readonly IDataStoreContextFactory<IDesktopContext> _dataStoreContextFactory;

        public DataStoreDesktopTask(IEntryPoint entryPoint, IDataStoreContextFactory<IDesktopContext> dataStoreContextFactory)
        {
            _entryPoint = entryPoint;
            _dataStoreContextFactory = dataStoreContextFactory;
        }

        public async Task<IDesktopContext> ExecuteAsync(IDesktopContext desktopContext, CancellationToken cancellationToken)
        {
            var dataStoreContext = _dataStoreContextFactory.Build(desktopContext);

            await _entryPoint.Callback(dataStoreContext, cancellationToken);

            return desktopContext;
        }
    }
}
