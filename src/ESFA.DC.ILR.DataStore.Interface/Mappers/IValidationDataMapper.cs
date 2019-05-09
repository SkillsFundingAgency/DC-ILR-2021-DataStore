using System.Collections.Generic;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.DataStore.Model.File;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.DataStore.Interface.Mappers
{
    public interface IValidationDataMapper
    {
        ValidationData MapData(IDataStoreContext datStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules, IMessage message);
    }
}
