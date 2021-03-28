using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rentals>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CustomersID).NotNull();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
        }
    }
}
