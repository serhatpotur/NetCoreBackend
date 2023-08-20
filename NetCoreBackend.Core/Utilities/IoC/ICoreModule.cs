using Microsoft.Extensions.DependencyInjection;

namespace NetCoreBackend.Core.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection serviceCollection);
}
