using FluentValidation;
using NetCoreBackend.Entities.Concrate;

namespace NetCoreBackend.Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("Ürün ismi boş geçilemez");
        RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün ismi en az 2 karakter olmalıdır");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmaldır");
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.CategoryId == 3).WithMessage("İçecek kategorisinde bulunan ürünlerin fiyatı 10'dan büyük olmalı");
        RuleFor(x => x.ProductName).Must(StartWithA).WithMessage("Ürün ismi A ile başlamalı");
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}
