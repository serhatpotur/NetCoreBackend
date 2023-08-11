using Castle.DynamicProxy;

namespace NetCoreBackend.Core.Utilities.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    //invocation =method
    //OnBefore, OnAfter,OnException,OnSuccess içleri boş geliyor. Kullandığımız yerde hangisini doldurursak o çalışacak
    protected virtual void OnBefore(IInvocation invocation) { }
    protected virtual void OnAfter(IInvocation invocation) { }
    protected virtual void OnException(IInvocation invocation, System.Exception ex) { }
    protected virtual void OnSuccess(IInvocation invocation) { }
    public override void Intercept(IInvocation invocation)
    {
        //Genellikle OnBefore() ve OnException() kullanılır.
        var isSuccess = true;
        OnBefore(invocation); // attribute methodun başında mı çalışsın
        try
        {
            invocation.Proceed();
        }
        catch (Exception ex)
        {
            isSuccess = false;
            OnException(invocation, ex); // attribute method hata aldığında mı çalışsın
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                OnSuccess(invocation); // attribute method başarılı olduğundan mı çalışsın
            }
        }
        OnAfter(invocation); // attribute methodun sonunda mı çalışsın
    }
}