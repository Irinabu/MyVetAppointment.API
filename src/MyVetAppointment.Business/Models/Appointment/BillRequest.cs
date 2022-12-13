using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class BillRequest
    {
        public string Diagnose { get; set; }
        public List<PrescriptionDrugRequest> PrescriptionDrugs { get; set; }

        public BillStatus BillStatus { get; set; }
    }
}
