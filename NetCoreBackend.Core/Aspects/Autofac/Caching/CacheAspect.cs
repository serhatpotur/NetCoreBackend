using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.CrossCuttingConcerns.Caching;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private int _duration;
    private ICacheManager _cacheManager;

    public CacheAspect(int duration = 60) //default 60 değeri alsın
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }
    public override void Intercept(IInvocation invocation)
    {
        //NetCoreBackend.Business.ProductManager.GetAll ismini aldık
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        // Methodun parametrelerini aldık
        var arguments = invocation.Arguments.ToList();
        // key olarak methodname ve varsa parametreleri ekle ve bize bir key oluştur , parametre yoksa "Null" ekle
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
        // key bellekte var mı
        if (_cacheManager.IsAdd(key))
        {
            // key bellekte varsa methodu çalıştırmadan manuel bir return olustur
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }
        invocation.Proceed(); // key bellekte yoksa methodu çalıştırmaya devam et
        _cacheManager.Add(key, invocation.ReturnValue, _duration); // bilgileri belleğe ekle
    }

}
