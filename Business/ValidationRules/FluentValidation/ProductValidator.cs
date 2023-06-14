using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        //ürünlerin ProductName'i boş olamaz.
        RuleFor(p => p.ProductName).NotEmpty();
        //ürünlerin adı minimum 2 karakter olmalı.
        RuleFor(p => p.ProductName).MinimumLength(2);
        //ürünlerin UnitPrice'ı boş olamaz.
        RuleFor(p => p.UnitPrice).NotEmpty();
        //ürünlerin UnitPrice'ı 0 dan büyük olmalı.
        RuleFor(p => p.UnitPrice).GreaterThan(0);
        //CategoryId 1e eşit olan ürünlerin UnitPrice'ı 10 dan büyük eşit olmalı.
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        //Yeni kural ekleme - Ürün ismi A ile başlamalı
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
    }
    //arg yukarıdan gelen parametre(ProductName)
    private bool StartWithA(string arg) //True dönerse kurala uygun. False dönerse kurala uygun değil
    {
        return arg.StartsWith("A");
    }
}