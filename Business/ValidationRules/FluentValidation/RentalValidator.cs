using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty();
            RuleFor(x => x.RentDate).NotEmpty();
            RuleFor(x => x.RentDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.ReturnDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.ReturnDate).GreaterThan(x=>x.RentDate);
        }
    }
}
