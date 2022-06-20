namespace CB.Core.Domain.Exceptions
{
    [Serializable]
    public class CurrencyUnavailableException : Exception
    {
        public string Currency { get; }

        public CurrencyUnavailableException(string message, string currency) : base(message)
        {
            Currency = currency;
        }
    }
}
