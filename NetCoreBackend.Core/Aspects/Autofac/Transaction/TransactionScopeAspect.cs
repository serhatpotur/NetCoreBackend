using Castle.DynamicProxy;
using NetCoreBackend.Core.Utilities.Interceptors;
using System.Transactions;

namespace NetCoreBackend.Core.Aspects.Autofac.Transaction;

public class TransactionScopeAspect : MethodInterception
{

    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope scope=new TransactionScope())
        {
			try
			{
				invocation.Proceed();
				scope.Complete();
			}
			catch (Exception ex)
			{
				scope.Dispose();
				throw;
			}
        }
    }
}
