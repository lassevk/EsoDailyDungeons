using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EsoDailyDungeons.Core.Extensions;

public static class HostApplicationBuilderExtensions
{
    private static readonly object _Lock = new();
    private static IHostApplicationBuilder? _PreviousBuilder;
    private static BootstrapperRegistry? _PreviousRegistry;

    public static IHostApplicationBuilder Bootstrap<T>(this IHostApplicationBuilder builder)
        where T : class, IBootstrapper, new()
    {
        var registry = GetBootstrapperRegistry(builder);
        if (registry.IsFirstBootstrap(typeof(T)))
            new T().Bootstrap(builder);

        return builder;
    }

    private static BootstrapperRegistry GetBootstrapperRegistry(IHostApplicationBuilder builder)
    {
        lock (_Lock)
        {
            if (ReferenceEquals(builder, _PreviousBuilder))
                return _PreviousRegistry!;

            var registry = builder.Services.FirstOrDefault(sd => sd.Lifetime == ServiceLifetime.Singleton && sd.ServiceType == typeof(BootstrapperRegistry))?.ImplementationInstance as BootstrapperRegistry;
            if (registry is null)
            {
                registry = new();
                builder.Services.AddSingleton(registry);
            }

            _PreviousBuilder = builder;
            _PreviousRegistry = registry;

            return registry;
        }
    }
}