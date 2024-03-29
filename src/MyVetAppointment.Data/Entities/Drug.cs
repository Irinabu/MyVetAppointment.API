﻿namespace MyVetAppointment.Data.Entities
{

    public class Drug
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double TotalQuantity { get; set; }
        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}