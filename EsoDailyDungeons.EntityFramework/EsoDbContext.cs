using Microsoft.EntityFrameworkCore;

namespace EsoDailyDungeons.EntityFramework;

public class EsoDbContext : DbContext
{
    public EsoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
}
