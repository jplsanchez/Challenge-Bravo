using CB.Core.Domain.Entities.Authorization;

namespace CB.Core.Service.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
