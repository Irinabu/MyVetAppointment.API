using Application.UnitTests;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Entities;

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
        public async void Should_Post()
        {
            var appointmentService = diKernel.ResolveService<IAppointmentService>();

            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.MaxValue,
                Description =
                    "Test appointment ...",
                Title = "Test Appointment",
                FirstName = "irinatest",
                LastName = "testtest"
            };

            var appointmentResponse = await appointmentService.AddAppointment(appointment, new User());
            Assert.False(string.IsNullOrEmpty(appointmentResponse.Title));
        }
    }
}
