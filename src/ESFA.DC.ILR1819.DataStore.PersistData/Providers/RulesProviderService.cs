using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.Data.ILR.ValidationErrors.Model.Interfaces;
using ESFA.DC.ILR.DataStore.Interface;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Providers
{
    public class RulesProviderService : IProviderService<List<Rule>>
    {
        private readonly IValidationErrors _validationErrors;

        public RulesProviderService(IValidationErrors validationErrors)
        {
            _validationErrors = validationErrors;
        }

        public async Task<List<Rule>> ProvideAsync(IDataStoreContext dataStoreContext, CancellationToken cancellationToken)
        {
            return await _validationErrors.Rules.ToListAsync(cancellationToken);
    }
    }
}
