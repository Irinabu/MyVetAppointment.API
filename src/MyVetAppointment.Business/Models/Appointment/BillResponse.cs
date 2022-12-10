using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class BillResponse
    {
        public string? Diagnose { get; set; }
        public ICollection<PrescriptionDrugRequest>? PrescriptionDrugs { get; set; }

    }
}
