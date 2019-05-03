using ESFA.DC.ILR1819.DataStore.EF.Console.DesignTime;
using Microsoft.EntityFrameworkCore.Design;

namespace ESFA.DC.ILR.DataStore.EF.Console.DesignTime
{
    public class ReferenceDataPluralizer : IPluralizer
    {
        public string Pluralize(string name)
        {
            return name.Pluralize() ?? name;
        }

        public string Singularize(string name)
        {
            return name.Singularize() ?? name;
        }
    }
}
