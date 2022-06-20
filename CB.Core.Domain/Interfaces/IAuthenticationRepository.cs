using CB.Core.Domain.Entities.Authorization;

namespace CB.Core.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User?> Get(string username, string password);
    }
}
