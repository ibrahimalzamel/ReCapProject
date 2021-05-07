using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.Descriptio).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();

            RuleFor(c => c.Descriptio).MinimumLength(2);
            RuleFor(c => c.Descriptio).MaximumLength(50);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            // RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(200).When(c => c.BrandId==3).WithMessage("brand id = 3 ise fiyat 200 olmalı");
            // RuleFor(c => c.Descriptio).Must(StartWithA).WithMessage("açklama A harf ile başlamali ...!!! ");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
