using CB.Core.Domain.DTO;
using CB.Core.Domain.Entities;
using CB.Core.Domain.Exceptions;
using CB.Core.Domain.Interfaces;
using CB.Core.Service.Abstractions;

namespace CB.Core.Service.Services
{
    public class ConversionService : IConversionService
    {
        private readonly IRepository<Currency> _repository;

        public ConversionService(IRepository<Currency> repository)
        {
            _repository = repository;
        }

        public async Task<float> Convert(ConversionDTO dto)
        {
            var fromCurrency = (await _repository.Get(c => dto.From == c.Name)).FirstOrDefault();
            ValidateCurrency(dto.From, fromCurrency);

            var toCurrency = (await _repository.Get(c => dto.To == c.Name)).FirstOrDefault();
            ValidateCurrency(dto.To, toCurrency);

            return fromCurrency!.ValueInUSD / toCurrency!.ValueInUSD * dto.Value;
        }

        private static void ValidateCurrency(string currencyName, Currency? currencyToValidate)
        {
            if (currencyToValidate == null)
            {
                throw new CurrencyUnavailableException("The currency cannot be found.", currencyName);
            }
        }
    }
}
