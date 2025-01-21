using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x=>x.ModelName).NotEmpty().WithMessage("Araba modeli boş bırakılmaz");
            RuleFor(x=>x.Transmission).NotEmpty().WithMessage("Vites türü boş bırakılmaz");
            RuleFor(x=>x.GasType).NotEmpty().WithMessage("Yakıt türü boş bırakılmaz");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat boş bırakılmaz");
            RuleFor(x=>x.Year).NotEmpty().WithMessage("Yıl boş bırakılmaz");
            RuleFor(x=>x.Kilometer).NotEmpty().WithMessage("Kilometre değeri boş bırakılmaz");
            RuleFor(x=>x.GearType).NotEmpty().WithMessage("Vites boş bırakılmaz");
            RuleFor(x=>x.SeatCount).NotEmpty().WithMessage("Koltuk sayısı boş bırakılmaz");
        }
    }
}
