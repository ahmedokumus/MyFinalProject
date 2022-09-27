using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //validation codes - doğrulama kodları
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);//p'nin UnitePrice'ı 0'dan büyük olmalı
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//CategoryId'si 1 olanların UnitePrice 10 dan büyük-eşit olmalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün isimleri A ile başlamalı!");//Ürün isimleri A ile başlamalı - Örnek kural oluşturma
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");//ProductName 'A' ile başlıyor mu?
        }
    }
}