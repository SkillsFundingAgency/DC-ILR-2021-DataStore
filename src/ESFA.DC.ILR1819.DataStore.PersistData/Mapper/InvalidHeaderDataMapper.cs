using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.EF.Invalid;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class InvalidHeaderDataMapper : IInvalidHeaderDataMapper
    {
        public InvalidHeaderData MapData(IMessage message)
        {
            var ukprn = message.LearningProviderEntity.UKPRN;

            var invalidHeaderData = new InvalidHeaderData();

            invalidHeaderData.CollectionDetails = new List<CollectionDetail>()
            {
                new CollectionDetail
                {
                    UKPRN = ukprn,
                    Collection = message.HeaderEntity.CollectionDetailsEntity.CollectionString,
                    FilePreparationDate = message.HeaderEntity.CollectionDetailsEntity.FilePreparationDate,
                    Year = message.HeaderEntity.CollectionDetailsEntity.YearString
                }
            };

            invalidHeaderData.LearningProviders = new List<LearningProvider>()
            {
                new LearningProvider
                {
                    UKPRN = ukprn
                }
            };

            var source = message.HeaderEntity.SourceEntity;

            invalidHeaderData.Sources = new List<Source>()
            {
                new Source
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

            invalidHeaderData.SourceFiles = BuildInvalidSourceFileCollection(message);

            return invalidHeaderData;
        }

        private List<EF.Invalid.SourceFile> BuildInvalidSourceFileCollection(IMessage message)
        {
            var ukprn = message.LearningProviderEntity.UKPRN;

            var sourceFilesList = new List<EF.Invalid.SourceFile>();

            if (message.SourceFilesCollection == null)
            {
                return sourceFilesList;
            }

            var i = 0;

            foreach (var sf in message.SourceFilesCollection)
            {
                sourceFilesList.Add(
                    new SourceFile
                    {
                        SourceFile_Id = i,
                        UKPRN = ukprn,
                        DateTime = sf.DateTimeNullable,
                        FilePreparationDate = sf.FilePreparationDate,
                        Release = sf.Release,
                        SerialNo = sf.SerialNo,
                        SoftwarePackage = sf.SoftwarePackage,
                        SoftwareSupplier = sf.SoftwareSupplier,
                        SourceFileName = sf.SourceFileName,
                    });

                i++;
            }

            return sourceFilesList;
        }
    }
}
