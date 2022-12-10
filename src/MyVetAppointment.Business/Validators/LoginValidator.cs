using FluentValidation;
using MyVetAppointment.Business.Models.User;

namespace MyVetAppointment.Business.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();

        }
    }
}
