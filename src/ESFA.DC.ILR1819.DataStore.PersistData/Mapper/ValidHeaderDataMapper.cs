using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Valid;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class ValidHeaderDataMapper : IValidHeaderDataMapper
    {
        public ValidHeaderData MapData(IMessage message)
        {
            var ukprn = message.LearningProviderEntity.UKPRN;

            var validHeaderData = new ValidHeaderData();

            validHeaderData.CollectionDetails = new List<CollectionDetail>()
            {
                new CollectionDetail
                {
                    UKPRN = ukprn,
                    Collection = message.HeaderEntity.CollectionDetailsEntity.CollectionString,
                    FilePreparationDate = message.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                    Year = message.HeaderEntity.CollectionDetailsEntity.YearString
                }
            };

            validHeaderData.LearningProviders = new List<LearningProvider>()
            {
                new LearningProvider
                {
                    UKPRN = ukprn
                }
            };

            var source = message.HeaderEntity.SourceEntity;

            validHeaderData.Sources = new List<Source>()
            {
                new EF.Valid.Source
                {
                    UKPRN = ukprn,
                    ComponentSetVersion = source.ComponentSetVersion,
                    DateTime = source.DateTime,
                    ProtectiveMarking = source.ProtectiveMarkingString,
                    ReferenceData = source.ReferenceData,
                    Release = source.Release,
                    SerialNo = source.SerialNo,
                    SoftwarePackage = source.SoftwarePackage,
                    SoftwareSupplier = source.SoftwareSupplier
                }
            };

            validHeaderData.SourceFiles = message
                .SourceFilesCollection?
                .Select(sf => new SourceFile
                {
                    UKPRN = ukprn,
                    DateTime = sf.DateTimeNullable,
                    FilePreparationDate = sf.FilePreparationDate,
                    Release = sf.Release,
                    SerialNo = sf.SerialNo,
                    SoftwarePackage = sf.SoftwarePackage,
                    SoftwareSupplier = sf.SoftwareSupplier,
                    SourceFileName = sf.SourceFileName,
                }).ToList()
                ?? new List<EF.Valid.SourceFile>();

            return validHeaderData;
        }
    }
}
