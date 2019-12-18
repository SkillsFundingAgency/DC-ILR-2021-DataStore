using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Loose.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IValidationDataMapper
    {
        void MapData(IDataStoreCache cache, IDataStoreContext dataStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules, ILooseMessage message);
    }
}
