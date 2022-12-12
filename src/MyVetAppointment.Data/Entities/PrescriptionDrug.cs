namespace MyVetAppointment.Data.Entities;

public class PrescriptionDrug
{
    public Guid Id { get; set; }
    public Guid DrugId { get; set; }
    public Drug? Drug { get; set; }
    public double QuantityPerDay { get; set; }
}