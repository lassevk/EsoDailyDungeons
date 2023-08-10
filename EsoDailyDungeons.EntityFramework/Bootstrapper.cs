using EsoDailyDungeons.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EsoDailyDungeons.EntityFramework;

public class Bootstrapper : IBootstrapper
{
    public void Bootstrap(IHostApplicationBuilder builder)
    {
        var options = new DbContextOptionsBuilder()
            .UseSqlServer(builder.Configuration.GetConnectionString("Main"))
            .Options;
        builder.Services.AddSingleton<IEsoDbContextFactory>(new EsoDbContextFactory(options));
    }
}
