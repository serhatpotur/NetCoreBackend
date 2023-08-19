using NetCoreBackend.Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace NetCoreBackend.Business.Constants;

public static class Messages
{
    public static string ProductAdded = "Ürün eklendi";
    public static string ProductNameInvalid = "Ürün ismi geçersiz";
    public static string ProductDeleted = "Ürün silindi";
    public static string ProductUpdated = "Ürün güncellendi";
    public static string ProductsListed = "Ürünler listelendi";
    public static string MaintenanceTime = "Sistem Bakımda";
    public static string ProductNameAlreadyExists = "Eklemeye çalıştığınız ürün mevcut";
    public static string ProductCountOfCategoryError = "Bir kategoride 15 üründen fazlası olamaz";
    public static string CategoryLimitExceded = "Kategori sayısı 15'den fazla olamaz";
    public static string AuthorizationDenied="Yapmak istediğiniz işeleme yetkiniz Yok";
    public static string UserRegistered="Kullanıcı Kayıt Oldu";
    public static string UserNotFound="Kullanıcı Bulanamadı";
    public static string PasswordError="Şifre Hatalı";
    public static string SuccessfulLogin="Giriş Başarılı";
    public static string UserAlreadyExists="Kullanıcı zaten kayıtlı";
    public static string AccessTokenCreated="Access Token oluşturuldu";
}
