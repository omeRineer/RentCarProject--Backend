using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarBrand).NotEmpty();
            RuleFor(p => p.CarColor).NotEmpty();
            RuleFor(p => p.CarModelYear).NotEmpty();
            RuleFor(p => p.CarDailyPrice).GreaterThanOrEqualTo(350).NotEmpty();
            RuleFor(p => p.CarDescription).MaximumLength(75);
        }
    }
}
