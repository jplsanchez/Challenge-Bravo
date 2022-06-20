namespace CB.Core.Domain.DTO
{
    public record ConversionDTO
    {
        public string From { get; init; }
        public string To { get; init; }
        public float Value { get; init; }
    }
}
