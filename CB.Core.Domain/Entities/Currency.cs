namespace CB.Core.Domain.Entities
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string? LongName { get; set; }
        public float ValueInUSD { get; set; }
    }
}
