using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.TransactionScopeAspect;

public class TransactionScopeAspect : MethodInterception
{
    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope transactionScope = new TransactionScope())
        {
            try
            {
                invocation.Proceed();// Methodu çalıştır demek
                transactionScope.Complete();
            }
            catch (System.Exception e)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}