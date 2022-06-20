using CB.Core.Domain.Interfaces;
using Microsoft.Extensions.Configuration;


namespace CB.Infra.IoC
{
    public record GlobalSettings : IGlobalSettings
    {
        public string PostgresConnStr { get; init; }
        public string Secret { get; init; }

        public string AdminName { get; init; } 
        public string AdminPassword { get; init; }

        public GlobalSettings(IConfiguration configuration)
        {
            PostgresConnStr = GetHerokuConnectionString(configuration);
            Secret = configuration.GetSection("SECRET").Value;
            AdminName = configuration.GetSection("ADMIN_NAME").Value;
            AdminPassword = configuration.GetSection("ADMIN_PASSWORD").Value;
        }

        private static string GetHerokuConnectionString(IConfiguration configuration)
        {
            string connectionUrl = configuration.GetSection("DATABASE_URL").Value;
            var databaseUri = new Uri(connectionUrl);

            string db = databaseUri.LocalPath.TrimStart('/');

            string[] userInfo = databaseUri.UserInfo
                                .Split(':', StringSplitOptions.RemoveEmptyEntries);

            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};" +
                   $"Port={databaseUri.Port};Database={db};Pooling=true;" +
                   $"SSL Mode=Require;Trust Server Certificate=True;";
        }
    }
}
