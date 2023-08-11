using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using NetCoreBackend.Business.Abstract;
using NetCoreBackend.Business.Concrate;
using NetCoreBackend.Core.Utilities.Interceptors;
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
        builder.RegisterType<EfProductDal>().As<ICategoryDal>().SingleInstance();


        // GetExecutingAssembly :Çalışan uygulama içerisinde assembly leri bul
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        // Ve bu assembly içerisinde ki implement edilmiş interfaceleri bul (AsImplementedInterfaces)
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                // Ve onlar için AspectInterceptorSelectoru kullan,çağır
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}
