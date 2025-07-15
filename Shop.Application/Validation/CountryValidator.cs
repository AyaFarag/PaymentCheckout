using FluentValidation;
using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Validation
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(n => n.Name).NotNull().WithMessage("Country can't be null");
          

        }
    }
}
