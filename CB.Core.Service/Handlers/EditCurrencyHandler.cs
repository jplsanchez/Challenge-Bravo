using CB.Core.Domain.Commands;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces;
using CB.Core.Domain.Notifications;
using MediatR;

namespace CB.Core.Service.Handlers
{
    public class EditCurrencyHandler : IRequestHandler<EditCurrencyCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Currency> _repository;

        public EditCurrencyHandler(IMediator mediator, IRepository<Currency> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<string> Handle(EditCurrencyCommand request, CancellationToken cancellationToken)
        {
            var storedCurrency = _repository.Get(c => c.Id == request.Id).Result.FirstOrDefault();
            var currency = new Currency
            {
                Id = request.Id,
                Name = request.Name ?? storedCurrency!.Name,
                LongName = storedCurrency!.LongName,
                ValueInUSD = request.ValueInUSD != 0 ? request.ValueInUSD : storedCurrency!.ValueInUSD,
                CreatedAt = storedCurrency!.CreatedAt,
                ModifiedAt = DateTime.UtcNow
            };

            try
            {
                await _repository.Edit(currency);
                await _mediator.Publish(new SuccessNotification<Currency>(currency.Id, "Update", true));

                return await Task.FromResult("Currency changed successfully");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new SuccessNotification<Currency>(currency.Id, "Update", false));
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return await Task.FromResult("An error occurred during updating process");
            }
        }
    }
}
