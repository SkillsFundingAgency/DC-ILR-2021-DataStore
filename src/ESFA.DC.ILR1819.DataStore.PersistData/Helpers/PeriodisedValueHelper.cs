using ESFA.DC.ILR1819.DataStore.PersistData.Constants;

namespace ESFA.DC.ILR1819.DataStore.PersistData.Helpers
{
    public class PeriodisedValueHelper
    {
        public static O GetPeriodValue<T, O>(T periodisedValue, int period)
        {
            var value = periodisedValue?.GetType().GetProperty(PersistDataConstants.PeriodPrefix + period)?.GetValue(periodisedValue);

            return TypeHelper.PeriodValueTypeHandler<O>(value);
        }
    }
}
