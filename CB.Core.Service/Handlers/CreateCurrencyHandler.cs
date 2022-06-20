using CB.Core.Domain.Commands;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces.Repositories;
using CB.Core.Domain.Notifications;
using MediatR;

namespace CB.Core.Service.Handlers
{
    public class CreateCurrencyHandler
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Currency> _repository;

        public CreateCurrencyHandler(IMediator mediator, IRepository<Currency> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<string> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = new Currency 
            { 
                Id = Guid.NewGuid(),
                Name = request.Name,
                ValueInUSD = request.ValueInUSD,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            try
            {
                await _repository.Add(currency);
                await _mediator.Publish(new SuccessNotification<Currency>(currency.Id, true));

                return await Task.FromResult("Currency created successfully");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new SuccessNotification<Currency>(currency.Id, false));
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return await Task.FromResult("An error occurred during creation process");
            }
        }
    }
}
