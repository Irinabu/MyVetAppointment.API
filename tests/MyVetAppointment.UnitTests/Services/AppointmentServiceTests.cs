using Application.UnitTests;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Business.Models.User;
using System.Diagnostics;

namespace MyVetAppointment.UnitTests.Services
{ 
    public class AppointmentServiceTests
    {
        private readonly IAppointmentService appointmentServiceMock;
        private readonly DITests diKernel;

        public AppointmentServiceTests()
        {
            diKernel = new DITests();
            appointmentServiceMock = diKernel.ResolveService<IAppointmentService>();
        }

        [Fact]
        public async void Should_PostAppointment()
        {

            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.MaxValue,
                Description =
                    "Test appointment ...",
                Title = "Test Appointment",
                FirstName = "irinatest",
                LastName = "testtest"
            };

            var user = new Customer()
            {
                Id = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa87c"),
                FirstName = "irinatest",
                LastName = "testtest",
                Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502307",
                Email = "test@test.com"
            };

            var appointmentResponse = await appointmentServiceMock.AddAppointment(appointment, user);
            Assert.False(string.IsNullOrEmpty(appointmentResponse.Title));
        } 
        
        [Fact]
        public async void Should_UpdateAppointment()
        {

            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.MaxValue,
                Description =
                    "Test appointment ...",
                Title = "Test Appointment",
                FirstName = "irinatest",
                LastName = "testtest"
            };

            var user = new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = "Customer",
                LastName = "DE TEST parola:string11",
                Email = "customer.test@test.com",
                Password = "899d8c5f546e1b096244fe7a01206c41ed15aeadc8b2750a934aef05d2f2c004"
            };

            var appointmentResponse = await appointmentServiceMock.UpdateAppointment(appointment, Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c"),  user);
            Assert.False(string.IsNullOrEmpty(appointmentResponse.Title));
        }        
        
        [Fact]
        public async void Should_DeleteAppointment()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c");

            var appointmentResponse = await appointmentServiceMock.DeleteAppointment(guid1);
            
            Assert.Equal(guid1, appointmentResponse.Id);
        }
        
        [Fact]
        public async void Should_NOT_DeleteAppointment()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa88c");
           
            await Assert.ThrowsAsync<ArgumentNullException>(() => appointmentServiceMock.DeleteAppointment(guid1));
        }

        [Fact]
        public async void Should_GetCustomerAppointments()
        {
            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.MaxValue,
                Description =
                    "Appointment for get...",
                Title = "Test Appointment",
                FirstName = "appointment",
                LastName = "appointment"
            };

            var user = new Customer()
            {
                Id = Guid.Parse("ef4e79d1-b867-43d6-82cd-96a7a53fb213"),
                FirstName = "customer",
                LastName = "customer",
                Password = "6a6a15287530d0de99de4a998ea33e5f36d204337da797254cee9326af502334",
                Email = "customer_cust@test.com"
            };

            var appointmentResponse = await appointmentServiceMock.AddAppointment(appointment, user);

            var appontments = await appointmentServiceMock.GetUserAppointments(user);

            Assert.True(appontments!.Count > 0);
        }
        
    }
}
