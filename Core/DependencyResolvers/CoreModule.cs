using System.Diagnostics;
using Core.CrossCunttingConcerns.Caching;
using Core.CrossCunttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        serviceCollection.AddMemoryCache();
        serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();

        serviceCollection.AddSingleton<Stopwatch>();
    }
}