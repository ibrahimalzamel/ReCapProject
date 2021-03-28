using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.UserID).NotEmpty();
            RuleFor(c => c.CompanyName).NotEmpty();

            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.CompanyName).MaximumLength(30);
        }
    }
}
