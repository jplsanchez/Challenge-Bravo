using CB.Core.Domain.Commands;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces;
using CB.Core.Domain.Notifications;
using MediatR;

namespace CB.Core.Service.Handlers
{
    public class DeleteCurrencyHandler : IRequestHandler<DeleteCurrencyCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Currency> _repository;

        public DeleteCurrencyHandler(IMediator mediator, IRepository<Currency> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<string> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new SuccessNotification<Currency>(request.Id, "Delete", true));

                return await Task.FromResult("Currency deleted successfully");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new SuccessNotification<Currency>(request.Id, "Delete", false));
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return await Task.FromResult("An error occurred during deletion process");
            }
        }
    }
}
