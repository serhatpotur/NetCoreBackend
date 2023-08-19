using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NetCoreBackend.Business.Abstract;
using NetCoreBackend.Business.Concrate;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.Security.JWT;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.DataAccess.Concrate.EntityFramework;

namespace NetCoreBackend.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //Program.cs için yazıldı
        // IProductDal isterlerse , ProductManager ver
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        // GetExecutingAssembly :Çalışan uygulama içerisinde assembly leri bul
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        // Ve bu assembly içerisinde ki implement edilmiş interfaceleri bul (AsImplementedInterfaces)
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                // Ve onlar için AspectInterceptorSelectoru kullan,çağır

                //Load çalıştığında ilk olarak yukarıda ki çağırdığımız manager sınıflarına bakar ve  Aspect'i([ValidationAspect vs]) var mı bakar . Daha sonra AspectInterceptorSelector uygular
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}
