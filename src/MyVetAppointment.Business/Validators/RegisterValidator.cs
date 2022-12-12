using FluentValidation;
using MyVetAppointment.Business.Models.User;

namespace MyVetAppointment.Business.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.PasswordConfirm).NotNull().NotEmpty();
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirm);

        }
    }
}
