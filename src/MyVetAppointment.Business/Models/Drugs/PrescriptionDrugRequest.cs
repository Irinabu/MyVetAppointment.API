namespace MyVetAppointment.Business.Models.Drugs
{
    public class PrescriptionDrugRequest
    {
        public Guid DrugId { get; set; }
        public double QuantityPerDay { get; set; }
    }
}