using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
                module.Load(serviceCollection);

            return ServiceTool.Create(serviceCollection);
        }
    }
}
