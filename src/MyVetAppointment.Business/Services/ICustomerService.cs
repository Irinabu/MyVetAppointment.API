﻿using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Business.Services
{

    public interface ICustomerService
    {
        Customer GetCustomerByEmailAsync(string email);
        bool DeleteCustomer(string id);

        List<Customer> GetAllAsync();

        public Task<AnimalResponse> AddAnimalAsync(AnimalRequest animal, User user);

        public Task<List<AnimalResponse>?> GetUserAnimals(User user);
    }
}