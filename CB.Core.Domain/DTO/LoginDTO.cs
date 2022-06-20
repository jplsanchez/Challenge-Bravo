namespace CB.Core.Domain.DTO
{
    public record LoginDTO
    {
        public string Username { get; init; }
        public string Password { get; init; }

        public LoginDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
