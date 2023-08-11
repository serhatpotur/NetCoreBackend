using Castle.DynamicProxy;
using FluentValidation;
using NetCoreBackend.Core.CrossCuttingConcerns.Validation;
using NetCoreBackend.Core.Utilities.Interceptors;

namespace NetCoreBackend.Core.Aspects.Autofac.Validation;

public class ValidationAspect : MethodInterception
{
    //Type : Attributelara tipleri Type türü ile atarız
    private Type _validatorType;
    public ValidationAspect(Type validatorType)
    {
        //Yazılan tip IValidator değilse hata versin
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            //throw new System.Exception(AspectMessages.WrongValidationType);
            throw new System.Exception("Bu bir doğrulama sınıfı değildir");
        }
        // Eğer gelen tip IValidator ise _validatorType içerisine bu tipi ver (Örn : ProductValidator)
        _validatorType = validatorType;
    }
    protected override void OnBefore(IInvocation invocation)
    {
        //Instance oluştur. (ÖRN ProductValidator newlemek, ProductValidator instance oluşturur)
        var validator = (IValidator)Activator.CreateInstance(_validatorType);
        // Gelen entityi bulur. (_validatorType : ProductValidator, BaseType:AbstractValidator,GetGenericArguments[0] : Product )
        var entityType = _validatorType.BaseType.GetGenericArguments()[0];
        // Kullanılan methodun parametrelerine bak ve entityType değeri ile aynı olan var mı.Birden fazla parametrede olabilir (invocation : Method (Add) , Arguments : Product , entityType product gelmişti)
        var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

        // Ve herbirini tek tek gez ve ValidationTool.Valide et
        foreach (var entity in entities)
        {
            ValidationTool.Validate(validator, entity);
        }
    }
}
