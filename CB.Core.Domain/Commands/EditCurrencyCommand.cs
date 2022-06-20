using MediatR;

namespace CB.Core.Domain.Commands
{
    public class EditCurrencyCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float ValueInUSD { get; set; }
    }
}
