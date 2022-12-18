using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Controllers
{

    [TestFixture]
    public class RegisterTests : CustomBaseTest
    {
        [Test]
        public async Task Should_RegisterVetDoctor()
        {
            //Arrange
            var random = new Random();
            var expected = new RegisterRequest
            {
                Email = "doctor" + random.Next() + ".test@gmail.com",
                FirstName = "DoctorTest",
                LastName = "DoctorTest",
                Password = "PasswordTest",
                PasswordConfirm = "PasswordTest"
            };


            var json = JsonContent.Create(expected);
            var client = GetClient();

            //Act
            var response = await client.PostAsync("https://localhost:5001/Authenticate/register-vet-doctor", json);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseDeserialized = JsonConvert.DeserializeObject<RegisterResponse>(responseMessage);

            Console.WriteLine();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDeserialized, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            });
        }

        [Test]
        public async Task Should_NOT_RegisterVetDoctor()
        {
            //Arrange
            var expected = new RegisterRequest
            {
                Email = "doctor.test@test.com",
                FirstName = "DoctorTest",
                LastName = "DoctorTest",
                Password = "PasswordTest",
                PasswordConfirm = "PasswordTest"
            };

            var json = JsonContent.Create(expected);
            var client = GetClient();

            //Act
            var response = await client.PostAsync("https://localhost:5001/Authenticate/register-vet-doctor", json);
            var responseMessage = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseMessage, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            });
        }

        [Test]
        public async Task Should_RegisterCustomer()
        {
            //Arrange
            var random = new Random();
            var expected = new RegisterRequest
            {
                Email = "cust" + random.Next() + ".test@gmail.com",
                FirstName = "custTest",
                LastName = "custTest",
                Password = "PasswordTest",
                PasswordConfirm = "PasswordTest"
            };


            var json = JsonContent.Create(expected);
            var client = GetClient();

            //Act
            var response = await client.PostAsync("https://localhost:5001/Authenticate/register-customer", json);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseDeserialized = JsonConvert.DeserializeObject<RegisterResponse>(responseMessage);

            Console.WriteLine();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDeserialized, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            });
        }

        [Test]
        public async Task Should_NOT_RegisterCustomer()
        {
            //Arrange
            var expected = new RegisterRequest
            {
                Email = "customer.test@test.com",
                FirstName = "custTest",
                LastName = "custTest",
                Password = "PasswordTest",
                PasswordConfirm = "PasswordTest"
            };

            var json = JsonContent.Create(expected);
            var client = GetClient();

            //Act
            var response = await client.PostAsync("https://localhost:5001/Authenticate/register-customer", json);
            var responseMessage = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseMessage, Is.Not.Null);
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            });
        }
    }
}