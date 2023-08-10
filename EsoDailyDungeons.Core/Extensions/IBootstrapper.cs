using Microsoft.Extensions.Hosting;

namespace EsoDailyDungeons.Core.Extensions;

public interface IBootstrapper
{
    void Bootstrap(IHostApplicationBuilder builder);
}