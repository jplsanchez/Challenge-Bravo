using CB.Core.Domain.DTO;
using CB.Core.Domain.Entities;
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

        public Task<float> Convert(ConversionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
