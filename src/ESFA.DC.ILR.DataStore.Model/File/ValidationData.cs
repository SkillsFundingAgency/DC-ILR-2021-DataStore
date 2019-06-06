using System.Collections.Generic;
using ESFA.DC.ILR1920.DataStore.EF;

namespace ESFA.DC.ILR.DataStore.Model.File
{
    public class ValidationData
    {
        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();

    }
}
