using FluentValidation;
using MyVetAppointment.Business.Models.Appointment;

namespace MyVetAppointment.Business.Validators
{
    public class AppointmentValidator : AbstractValidator<AppointmentRequest>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.DateTime).NotNull().NotEmpty();
            RuleFor(x => x.DateTime).GreaterThan(DateTime.Now);

        }
    }
}
