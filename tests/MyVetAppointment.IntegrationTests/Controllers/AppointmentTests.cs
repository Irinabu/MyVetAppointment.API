using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Data.Enums;
using Newtonsoft.Json.Linq;

namespace MyVetAppointment.IntegrationTests.Controllers
{
    [TestFixture]
    public class AppointmentTests : CustomBaseTest
    {
        [Test]
        public async Task Should_GetAppointmentsByCustomer()
        {
            //Arrange
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync("/Appointment");

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_GetAppointmentsByVet()
        {
            //Arrange
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync("/Appointment");

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_NOT_GetAppointments()
        {
            //Arrange
            var client = GetClient();
            // var token = await LoginCustomer();
            // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync("/Appointment");

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task Should_PostAppointment()
        {
            //Arrange
            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.Now,
                Description =
                    "Pisica mea ...",
                Title = "Pisica bolnava",
                FirstName = "Doctor",
                LastName = "Test,parola:string12"
            };

            var json = JsonContent.Create(appointment);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.PostAsync("/Appointment", json);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task Should_NOT_PostAppointment()
        {
            //Arrange
            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.Now,
                Description =
                    "Pisica mea ...",
                Title = "Pisica bolnava",
                FirstName = "Doctor",
                LastName = "Test,parola:string12"
            };

            var json = JsonContent.Create(appointment);
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.PostAsync("/Appointment", json);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        [Test]
        public async Task Should_UpdateAppointment()
        {
            //Arrange
            var id = await AddAppointment();

            var appointmentUpdated = new AppointmentRequest()
            {
                DateTime = DateTime.Now,
                Description =
                    "Test appointment ...",
                Title = "Test Appointment",
                FirstName = "Doctor",
                LastName = "Test,parola:string12",
                Status = AppointmentStatus.Accepted
            };

            var json = JsonContent.Create(appointmentUpdated);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var responseUpdate = await client.PutAsync("/Appointment/" + id, json);

            //Assert
            Assert.IsNotNull(responseUpdate);
            Assert.That(responseUpdate.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_NOT_UpdateAppointment()
        {
            //Arrange
            var id = await AddAppointment();

            var appointment = new AppointmentRequest()
            {
                DateTime = DateTime.Now,
                Description =
                    "Test appointment ...",
                Title = "Test Appointment",
                FirstName = "Doctor",
                LastName = "Test,parola:string12",
                Status = AppointmentStatus.Accepted
            };

            var json = JsonContent.Create(appointment);
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.PutAsync("/Appointment/" + new Guid(), json);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

    }
}
