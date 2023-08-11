using Castle.DynamicProxy;
using System.Reflection;

namespace NetCoreBackend.Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{


    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        // Classın attributelarını bul
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();
        // Methodun attributelarını bul(validation, log, cache vs)
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        // Bulduğun attributeları bir listeye at
        classAttributes.AddRange(methodAttributes);
        //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

        //Attributeların çalışma sırasını belirlediğimiz alan
        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}
