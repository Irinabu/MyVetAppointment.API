namespace MyVetAppointment.Data.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public string Diagnose { get; set; }
    public ICollection<PrescriptionDrug> PrescriptionDrugs { get; set; }

    public Appointment Appointment { get; set; }
}