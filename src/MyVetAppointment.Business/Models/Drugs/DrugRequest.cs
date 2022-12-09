namespace MyVetAppointment.Business.Models.Drugs
{
    public class DrugRequest
    {
        public string Name { get; set; }
        public double TotalQuantity { get; set; }
        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
