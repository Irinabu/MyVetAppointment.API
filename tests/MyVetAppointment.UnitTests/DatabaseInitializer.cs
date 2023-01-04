using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.UnitTests
{

    public class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            if (context.Users.Any()) return;
            Seed(context);
        }

        private static void Seed(DatabaseContext context)
        {
            var users = new[]
            {
                new User
                {
                    Id = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c"),
                    FirstName = "irinatest",
                    LastName = "testtest",
                    Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502307",
                    Email = "test@test.com"
                },
                new User
                {
                    Id = Guid.Parse("05d173fa-e47e-4ab6-84e0-2cd577109d63"),

                    FirstName = "test2",
                    LastName = "test2",
                    Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502307",
                    Email = "test2@test2.com"
                }
            };


            context.Users.AddRange(users);

            context.SaveChanges();

            var drugs = new[]
            {
                new Drug()
                {
                    Id = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c"),
                    Name = "Paracetamol",
                    TotalQuantity = 20
                }
            };
            
            context.Drugs.AddRange(drugs);
            context.SaveChanges();
        }
    }
}