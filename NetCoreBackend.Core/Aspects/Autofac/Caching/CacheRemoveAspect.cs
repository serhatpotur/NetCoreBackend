using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.Aspects.Autofac.Caching;

//  Data ekle,sil,güncelleme işlemi gibi işlemlerde. Verinin değiştiği işlemlerde kullanılır
public class CacheRemoveAspect : MethodInterception
{
    private string _pattern;
    ICacheManager _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        // OnSuccess dememizin sebebi işlem başarılı ise çalıssın. 
        _cacheManager.RemoveByPattern(_pattern);
    }
}
