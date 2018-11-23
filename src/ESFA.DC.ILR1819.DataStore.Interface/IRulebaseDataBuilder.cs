namespace ESFA.DC.ILR1819.DataStore.Interface
{
    public interface IRulebaseDataBuilder<T, O>
    {
        O BuildRulebaseData(T fundingOutput);
    }
}