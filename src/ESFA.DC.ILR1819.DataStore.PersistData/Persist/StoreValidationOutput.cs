using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.Data.ILR.ValidationErrors.Model.Interfaces;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.PersistData.Abstract;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Logging.Interfaces;
using ESFA.DC.Serialization.Interfaces;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Persist
{
    public sealed class StoreValidationOutput : AbstractStore, IStoreValidationOutput
    {
        private readonly ILogger _logger;
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;
        private readonly IValidationErrors _validationErrors;

        public StoreValidationOutput(ILogger logger, IJsonSerializationService jsonSerializationService, IKeyValuePersistenceService keyValuePersistenceService, IValidationErrors validationErrors)
        {
            _logger = logger;
            _jsonSerializationService = jsonSerializationService;
            _keyValuePersistenceService = keyValuePersistenceService;
            _validationErrors = validationErrors;
        }

        public async Task StoreAsync(IDataStoreContext dataStoreContext, SqlTransaction sqlTransaction, int ukPrn, IMessage ilr, CancellationToken cancellationToken)
        {
            _logger?.LogDebug("StoreValidationOutput.StoreAsync 4");

            var ilrValidationErrors = await GetValidationErrors(dataStoreContext.ValidationErrorsKey, cancellationToken);
            var validationRuleDefinitions = await GetValidationRules();

            var validationErrors = BuildEfValidationErrors(ilr, dataStoreContext.Ukprn, dataStoreContext.OriginalFilename, ilrValidationErrors, validationRuleDefinitions).ToList();

            _logger?.LogDebug($"StoreValidationOutput.StoreAsync 5 {validationErrors.Count}");

            _logger?.LogDebug("StoreValidationOutput.StoreAsync 6");
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            _logger?.LogDebug("StoreValidationOutput.StoreAsync 7");

            await _bulkInsert.Insert("dbo.ValidationError", validationErrors, sqlTransaction, cancellationToken);

            _logger?.LogDebug("StoreValidationOutput.StoreAsync done");
        }

        private async Task<List<ValidationError>> GetValidationErrors(string validationErrorsKey, CancellationToken cancellationToken)
        {
            return _jsonSerializationService.Deserialize<List<ValidationError>>(await _keyValuePersistenceService.GetAsync(validationErrorsKey, cancellationToken));
        }

        private Task<List<Rule>> GetValidationRules()
        {
            return _validationErrors.Rules.ToListAsync();
        }

        private IEnumerable<EF.ValidationError> BuildEfValidationErrors(IMessage message, int ukprn, string fileName, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules)
        {
            return validationErrors?.Select(ve =>
            {
                var fieldValues = GetFieldValuesString(ve.ValidationErrorParameters);
                var errorMessage = rules.FirstOrDefault(r => string.Equals(r.Rulename, ve.RuleName, StringComparison.OrdinalIgnoreCase))?.Message;

                var learningDelivery = message.Learners
                    .SingleOrDefault(x => x.LearnRefNumber == ve.LearnerReferenceNumber)?
                    .LearningDeliveries.SingleOrDefault(x => x.AimSeqNumber == ve.AimSequenceNumber);

                var severity = ve.Severity != null && ve.Severity.Length >= 1 ? ve.Severity?.Substring(0, 1) : null;

                return new EF.ValidationError
                {
                    UKPRN = ukprn,
                    SWSupAimID = learningDelivery?.SWSupAimId,
                    FileLevelError = 1,
                    AimSeqNum = ve.AimSequenceNumber,
                    ErrorMessage = errorMessage,
                    FieldValues = fieldValues,
                    LearnAimRef = learningDelivery?.LearnAimRef,
                    LearnRefNumber = ve.LearnerReferenceNumber,
                    RuleName = ve.RuleName,
                    Severity = severity,
                    Source = fileName
                };
            }) ?? new List<EF.ValidationError>();
        }

        private string GetFieldValuesString(List<ValidationErrorParameter> validationErrorParameters)
        {
            if (validationErrorParameters == null)
            {
                return string.Empty;
            }

            var result = new System.Text.StringBuilder();

            validationErrorParameters.ForEach(x =>
            {
                result.Append($"{x.PropertyName ?? string.Empty}={x.Value ?? string.Empty}");
                result.Append("|");
            });

            return result.ToString();
        }
    }
}
