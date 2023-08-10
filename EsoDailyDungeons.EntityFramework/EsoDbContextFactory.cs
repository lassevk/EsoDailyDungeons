using Microsoft.EntityFrameworkCore;

namespace EsoDailyDungeons.EntityFramework;

internal class EsoDbContextFactory : IEsoDbContextFactory
{
    private readonly DbContextOptions _Options;

    public EsoDbContextFactory(DbContextOptions options)
    {
        _Options = options;
    }

    public EsoDbContext Create() => new EsoDbContext(_Options);
}