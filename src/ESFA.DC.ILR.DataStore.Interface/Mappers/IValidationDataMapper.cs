using System.Collections.Generic;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR1819.DataStore.Interface.Mappers
{
    public interface IValidationDataMapper
    {
        ValidationData MapData(IDataStoreContext datStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules, IMessage message);
    }
}
