using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BeerValidator: AbstractValidator<Beer>
    {
        public BeerValidator()
        {
            RuleFor(b => b.Name).MinimumLength(2);
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.BreweryId).NotEmpty();
            RuleFor(b => b.Price).NotEmpty();
            RuleFor(b => b.AlcoholContent).NotEmpty();
        }
    }
}
