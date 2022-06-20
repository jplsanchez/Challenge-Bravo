using CB.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CB.Infra.Data.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Currency>? Currencies { get; set; }
    }
}
