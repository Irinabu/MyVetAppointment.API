using AutoMapper;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Data.Persistence;


public static class DatabaseContextSeed
{
    public static async Task SeedDatabaseAsync(DatabaseContext context, IUserRepository userRepository, IMapper mapper)
    {

        if ((await userRepository.GetAllAsync(x => x.Id != Guid.Empty)).Count == 0)
        {
            var user = new VetDoctor
            {
                Id = Guid.NewGuid(),
                FirstName = "Doctor",
                LastName = "Test,parola:string12",
                Email = "doctor.test@test.com",
                Password= "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502307",
            };
            var user1 = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = "Customer",
                LastName = "DE TEST parola:string11",
                Email = "customer.test@test.com",
                Password = "899d8c5f546e1b096244fe7a01206c41ed15aeadc8b2750a934aef05d2f2c004"
            };
            await userRepository.AddAsync(user);
            await userRepository.AddAsync(user1);

        }
        await context.SaveChangesAsync();
    }
}