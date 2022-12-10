using FluentValidation;
using MyVetAppointment.Business.Models.Appointment;

namespace MyVetAppointment.Business.Validators
{
    public class BillValidator : AbstractValidator<BillRequest>
    {
        public BillValidator()
        {
            RuleFor(x => x.Diagnose).NotNull().NotEmpty();
            RuleForEach(x => x.PrescriptionDrugs).SetValidator(new PrescriptionDrugValidator());
        }
    }
}
