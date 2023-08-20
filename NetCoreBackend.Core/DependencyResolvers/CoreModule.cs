using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching.Microsoft;
using NetCoreBackend.Core.Utilities.IoC;
using System.Diagnostics;

namespace NetCoreBackend.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        serviceCollection.AddSingleton<Stopwatch>();

    }
}
