using MyVetAppointment.Business.Models.Drugs;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class BillRequest
    {
        public string Diagnose { get; set; }
        public ICollection<PrescriptionDrugRequest> PrescriptionDrugs { get; set; }

    }
}
