using AutoMapper;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.Data.Persistence
{

    public static class DatabaseContextSeed
    {
        public static async Task SeedDatabaseAsync(DatabaseContext context, IUserRepository userRepository,
            IAppointmentRepository appointmentRepository, IBillRepository billRepository,
            IDrugRepository drugRepository,
            IPrescriptionDrugRepository prescriptionDrugRepository, IMapper mapper)
        {
            if ((await userRepository.GetAllAsync(x => x.Id != Guid.Empty)).Count == 0)
            {
                var user = new VetDoctor
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Doctor",
                    LastName = "Test,parola:string12",
                    Email = "doctor.test@test.com",
                    Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502307"
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

                var appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    Customer = user1,
                    VetDoctor = user,
                    DateTime = DateTime.Now,
                    Description = "Mi-a cazut calul in balta",
                    AppointmentStatus = AppointmentStatus.Pending,
                    Title = "Cal lesinat"
                };

                await appointmentRepository.AddAsync(appointment);

                appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    Customer = user1,
                    VetDoctor = user,
                    DateTime = DateTime.Now.AddMonths(6),
                    Description =
                        "Pisicii mele prea birmaneze i-a cazut un whiskas de asta sau cum se cheama. Ajutor domn' doctor va rog.",
                    Title = "Pisica fara un whisker",
                    AppointmentStatus = AppointmentStatus.Pending
                };

                await appointmentRepository.AddAsync(appointment);

                appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    Customer = user1,
                    VetDoctor = user,
                    DateTime = DateTime.Now.AddMonths(6),
                    Description = "De cateva zile vad ca nu mai stie sa inoate Nemo asta a meu. Ce ii fac",
                    Title = "Peste inecat",
                    AppointmentStatus = AppointmentStatus.Pending
                };

                await appointmentRepository.AddAsync(appointment);

                var drug = new Drug
                {
                    Id = Guid.NewGuid(),
                    Name = "Paracetamol",
                    Price = 10.5,
                    TotalQuantity = 50,
                    ExpirationDate = DateTime.Now.AddMonths(6)
                };
                await drugRepository.AddAsync(drug);
            }

            await context.SaveChangesAsync();
        }
    }
}