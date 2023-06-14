using Castle.DynamicProxy;
using System.Reflection;
using Core.Aspects.Autofac.Performance;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit:true);
        classAttributes.AddRange(methodAttributes);

        //classAttributes.Add(new PerformanceAspect(1)); //Projedeki bütünn metotları kontrol eder 1 saniyeden uzun sürenleri bilgilendirir

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}