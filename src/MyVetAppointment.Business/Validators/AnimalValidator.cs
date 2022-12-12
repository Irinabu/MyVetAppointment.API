using FluentValidation;
using MyVetAppointment.Business.Models.Animal;

namespace MyVetAppointment.Business.Validators
{
    public class AnimalValidator : AbstractValidator<AnimalRequest>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.AnimalType).IsInEnum();
        }

    }
}
