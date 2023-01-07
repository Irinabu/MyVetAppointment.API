using Application.UnitTests;
using MyVetAppointment.Business.Models.Animal;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.UnitTests.Services
{

    public class CustomerServiceTests
    {
        private readonly ICustomerService customerServiceMock;
        private readonly IAuthenticateService authenticateServiceMock;
        private readonly DITests diKernel;

        public CustomerServiceTests()
        {
            diKernel = new DITests();
            customerServiceMock = diKernel.ResolveService<ICustomerService>();
            authenticateServiceMock = diKernel.ResolveService<IAuthenticateService>();
        }

       
        [Fact]
        public void Should_GetCustomers()
        {
            var customersResponse = customerServiceMock.GetAllAsync();
            Assert.True(customersResponse.Count>0);
        }

        [Fact]
        public void Should_GetCustomerByEmail()
        {
            var registerRequest = new RegisterRequest
            {
                Email = "customer_for_test@test.com",
                FirstName = "custtst",
                LastName = "tstcust",
                Password = "lalacust",
                PasswordConfirm = "lalacust"
            };
            var registerResponse = authenticateServiceMock.RegisterCustomerAsync(registerRequest);
            var customerResponse = customerServiceMock.GetCustomerByEmailAsync("customer_for_test@test.com");
            Assert.True(customerResponse != null);
        }

        [Fact]
        public void Should_DeleteCustomer()
        {
            var registerRequest = new RegisterRequest
            {
                Email = "customer_for_test@test.com",
                FirstName = "custtst",
                LastName = "tstcust",
                Password = "lalacust",
                PasswordConfirm = "lalacust"
            };
            authenticateServiceMock.RegisterCustomerAsync(registerRequest);
            var customerResponse = customerServiceMock.GetCustomerByEmailAsync("customer_for_test@test.com");
            var response = customerServiceMock.DeleteCustomer(customerResponse.Id.ToString());
            
            Assert.True(response==true);
        }

        
        [Fact]
        public void Should_AddAnimalAsync()
        {
            var user = new Customer()
            {
                Id = Guid.Parse("0eb81d17-3a31-4244-bea1-3d7b4e4d0c9a"),
                FirstName = "customer_pet",
                LastName = "customer",
                Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af504444",
                Email = "customer_pet_cust2@test.com"
            };
            var animal = new AnimalRequest()
            {
                Name = "Chelutzu2",
                AnimalType = 0
            };
            var response = customerServiceMock.AddAnimalAsync(animal, user);
            Assert.True(response != null);
        }

        [Fact]
        public void Should_GetUserAnimals()
        {
            var user = new Customer()
            {
                Id = Guid.Parse("f5640ecb-0ff6-47a4-8fb6-85b1ccfb3b7b"),
                FirstName = "customer_pet",
                LastName = "customer",
                Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af504444",
                Email = "customer_pet_cust@test.com"
            };

            var animal = new AnimalRequest()
            {
                Name = "Chelutzu",
                AnimalType = 0
            };

            customerServiceMock.AddAnimalAsync(animal, user);
            var response = customerServiceMock.GetUserAnimals(user);
            Assert.True(response !=null);

        }

    }
}
