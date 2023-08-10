namespace EsoDailyDungeons.EntityFramework;

public interface IEsoDbContextFactory
{
    EsoDbContext Create();
}