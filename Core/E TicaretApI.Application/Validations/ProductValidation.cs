using E_TicaretApI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Validations
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().
                WithMessage("Zehmet olmasa adi bos kecmeyin").
                MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Zehmet olmasa mehsul adinin uzunlugunu 5 ile 150 arasinda edin ");


            RuleFor(p => p.Stock).NotNull().NotEmpty().
                WithMessage("Zehmet olmasa stock melumatini bos kecmeyin")
                .Must(s => s >= 0)
                .WithMessage("Stock melumati negative ola bilmez");


            RuleFor(p => p.Price).NotNull().NotEmpty().
                WithMessage("Zehmet olmasa qiymeti bos kecmeyin").
                Must(s => s >= 0).
                WithMessage("Qiymet negative ola bilmez");
        }
    }
}
