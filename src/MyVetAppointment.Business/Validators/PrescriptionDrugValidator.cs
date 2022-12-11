using FluentValidation;
using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Validators
{
    public class PrescriptionDrugValidator : AbstractValidator<PrescriptionDrugRequest>
    {
        public PrescriptionDrugValidator()
        {
            RuleFor(x => x.QuantityPerDay).GreaterThan(0);
        }
    }
}
