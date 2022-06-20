using MediatR;

namespace CB.Core.Domain.Notifications
{
    public record ErrorNotification : INotification
    {
        public string? Exception { get; init; }
        public string? StackError { get; init; }
    }
}
