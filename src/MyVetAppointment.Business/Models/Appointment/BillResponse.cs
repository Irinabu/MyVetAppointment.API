using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Data.Enums;

namespace MyVetAppointment.Business.Models.Appointment
{
    public class BillResponse
    {
        public Guid Id { get; set; }
        public Guid appointmentId { get; set; }
        public string Diagnose { get; set; }
        public List<PrescriptionDrugRequest> PrescriptionDrugs { get; set; }

        public BillStatus BillStatus { get; set; }

    }
}
