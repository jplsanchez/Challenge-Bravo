using MediatR;

namespace CB.Core.Domain.Commands
{
    public class DeleteCurrencyCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
