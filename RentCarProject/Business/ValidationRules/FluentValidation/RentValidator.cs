using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentValidator:AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(p => p.Car).NotEmpty();
            RuleFor(p => p.Customer).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
        }
    }
}
