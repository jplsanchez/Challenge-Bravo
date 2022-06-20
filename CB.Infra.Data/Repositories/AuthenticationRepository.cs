using CB.Core.Domain.Entities.Authorization;
using CB.Core.Domain.Interfaces;

namespace CB.Infra.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IGlobalSettings _settings;

        public AuthenticationRepository(IGlobalSettings settings)
        {
            _settings = settings;
        }

        public async Task<User?> Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 2, Username = _settings.AdminName, Password = _settings.AdminPassword});
            return await Task.FromResult(users.Where(u => u.Username.ToLower() == username.ToLower() && u.Password == password.ToLower()).FirstOrDefault());
        }
    }
}
