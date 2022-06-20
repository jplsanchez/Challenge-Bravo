using CB.Core.Domain.DTO;

namespace CB.Core.Service.Abstractions
{
    public interface IConversionService
    {
        Task<float> Convert(ConversionDTO dto);
    }
}
