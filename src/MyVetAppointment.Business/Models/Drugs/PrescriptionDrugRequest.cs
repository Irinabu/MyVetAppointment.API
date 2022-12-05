namespace MyVetAppointment.Business.Models.Drugs
{
    public class PrescriptionDrugRequest
    {
        public string DrugName { get; set; }
        public double QuantityPerDay { get; set; }
    }
}