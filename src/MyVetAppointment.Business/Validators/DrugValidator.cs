using FluentValidation;
using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Validators
{
    public class DrugValidator : AbstractValidator<DrugRequest>
    {
        public DrugValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.TotalQuantity).GreaterThan(0);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now);

        }
    }
}