using Castle.DynamicProxy;

namespace NetCoreBackend.Core.Utilities.Interceptors;

// Bu Attribute'yi Classlara veya Methodlara ekleyebilirsin , Birden fazla ekleyebilirsin ve inherit edilen bir noktada bu attribute çalışsın    
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; } // Öncelik demek. hangi attribute önce çalışsın. Cash,Log, Validate vs

    public virtual void Intercept(IInvocation invocation)
    {

    }
}