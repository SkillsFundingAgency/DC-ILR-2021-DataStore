using System.Data.OleDb;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.ILR.DataStore.Access;
using ESFA.DC.ILR.DataStore.Export.Interface;
using ESFA.DC.ILR.DataStore.Export.Mappers.Rulebase;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR2021.DataStore.EF;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.DataStore.Export.SchemaExport
{
    public class AlbExport : AbstractSchemaExport, IOrderedExport
    {
        public AlbExport(IExport export, ILogger logger) 
            : base(new ValidMdbContext(), export, logger, Constants.TaskExportAlbTables, 4)
        {
        }

        public async Task ExportAsync(IDataStoreCache dataStoreCache, OleDbConnection connection, string exportPath,
            CancellationToken cancellationToken)
        {
            await ExportTableAsync<ALB_global, ALBglobalClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_Learner, ALBLearnerClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_Learner_Period, ALBLearnerPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_Learner_PeriodisedValue, ALBLearnerPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery, ALBLearningDeliveryClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_Period, ALBLearningDeliveryPeriodClassMap>(exportPath, dataStoreCache, connection, cancellationToken);

            await ExportTableAsync<ALB_LearningDelivery_PeriodisedValue, ALBLearningDeliveryPeriodisedValuesClassMap>(exportPath, dataStoreCache, connection, cancellationToken);
        }
    }
}
