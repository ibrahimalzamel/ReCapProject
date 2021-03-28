using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotNull().EmailAddress();
            RuleFor(u => u.Password).NotEmpty();

            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).MinimumLength(12);
            RuleFor(u => u.Password).MinimumLength(4); 
            
            RuleFor(u => u.FirstName).MaximumLength(20);
            RuleFor(u => u.LastName).MaximumLength(20);
            RuleFor(u => u.Email).MaximumLength(30);
            RuleFor(u => u.Password).MaximumLength(20);
        }
    }
}
