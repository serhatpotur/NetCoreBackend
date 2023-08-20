using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;
using System.Diagnostics;

namespace NetCoreBackend.Core.Aspects.Autofac.Performance;

public class PerformanceAspect : MethodInterception
{
    private int _interval;
    private Stopwatch _stopwatch;

    public PerformanceAspect(int interval)
    {
        _interval = interval;
        _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _stopwatch.Start();
    }
    protected override void OnAfter(IInvocation invocation)
    {
        if (_stopwatch.Elapsed.TotalSeconds > _interval)
        {
            Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
        }
        _stopwatch.Restart();
    }
}
