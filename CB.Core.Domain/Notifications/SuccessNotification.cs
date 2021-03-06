using CB.Core.Domain.Entities;
using MediatR;

namespace CB.Core.Domain.Notifications
{
    public record SuccessNotification<T> : INotification where T : BaseEntity
    {
        public Guid ObjectId { get; init; }
        public Type ObjectType => typeof(T);
        public string Operation { get; init; }
        public bool Success { get; init; }

        public SuccessNotification(Guid objectId, string operation, bool isSuccess)
        {
            ObjectId = objectId;
            Operation = operation;
            Success = isSuccess;
        }
    }
}
