using System.Collections.Generic;
using ESFA.DC.ILR.DataStore.Model.Interface;
using ESFA.DC.ILR.DataStore.Model.ReferenceData;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IValidationDataMapper
    {
        IDataStoreCache MapData(IDataStoreContext datStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<ValidationRule> rules, IMessage message);
    }
}
