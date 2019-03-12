using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.Data.ILR.ValidationErrors.Model;
using ESFA.DC.ILR.IO.Model.Validation;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR1819.DataStore.Interface;
using ESFA.DC.ILR1819.DataStore.Interface.Mappers;
using ESFA.DC.ILR1819.DataStore.Model.File;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Mapper
{
    public class ValidationDataMapper : IValidationDataMapper
    {
        public ValidationData MapData(IDataStoreContext dataStoreContext, IEnumerable<ValidationError> validationErrors, IEnumerable<Rule> rules, IMessage message)
        {
            var validationData = new ValidationData
            {
                ValidationErrors = validationErrors?
                    .Select(ve =>
                    {
                        var fieldValues = GetFieldValuesString(ve.ValidationErrorParameters);
                        var errorMessage = rules.FirstOrDefault(r => string.Equals(r.Rulename, ve.RuleName, StringComparison.OrdinalIgnoreCase))?.Message;

                        var learningDelivery =
                            message?
                                .Learners?
                                .FirstOrDefault(x => x.LearnRefNumber == ve.LearnerReferenceNumber)?
                                .LearningDeliveries
                                .FirstOrDefault(x => x.AimSeqNumber == ve.AimSequenceNumber);

                        var severity = ve.Severity != null && ve.Severity.Length >= 1 ? ve.Severity?.Substring(0, 1) : null;

                        return new EF.ValidationError
                        {
                            UKPRN = dataStoreContext.Ukprn,
                            SWSupAimID = learningDelivery?.SWSupAimId,
                            FileLevelError = 1,
                            AimSeqNum = ve.AimSequenceNumber,
                            ErrorMessage = errorMessage,
                            FieldValues = fieldValues,
                            LearnAimRef = learningDelivery?.LearnAimRef,
                            LearnRefNumber = ve.LearnerReferenceNumber,
                            RuleName = ve.RuleName,
                            Severity = severity,
                            Source = dataStoreContext.OriginalFilename
                        };
                }).ToList() ?? new List<EF.ValidationError>()
            };

            return validationData;
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
