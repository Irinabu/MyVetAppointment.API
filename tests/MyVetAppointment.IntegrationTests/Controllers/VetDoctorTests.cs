using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Services
{

    [TestFixture]
    public class VetDoctorTests : CustomBaseTest
    {
        [Test]
        public async Task GET_VetDoctors_ShouldBe_Status_OK()
        {
            //Arrange
            var client = GetClient();
            var token = await LoginVet();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync("/VetDoctor/vets");

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GET_VetDoctorByEmail_ShouldBe_Status_OK()
        {
            //Arrange
            var email = "doctor.test@test.com";
            var client = GetClient();
            var token = await LoginVet();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync($"/VetDoctor/{email}");

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task DELETE_VetDoctors_ShouldBe_Status_NotFound()
        {
            //Arrange
            var client = GetClient();
            var id = "123";
            var token = await LoginVet();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.DeleteAsync($"VetDoctor/delete-vet/{id}");

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }


        [Test]
        public async Task DELETE_VetDoctors_ShouldBe_Status_OK()
        {
            //Arrange
            var register = new RegisterRequest
            {
                Email = "probaDoc@test.com",
                FirstName = "Proba",
                LastName = "string",
                Password = "string",
                PasswordConfirm = "string"
            };

            var json = JsonContent.Create(register);
            var client = GetClient();
            var token = await LoginVet();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


            //Act
            await client.PostAsync("https://localhost:5001/Authenticate/register-vet-doctor", json);
            var doc = await client.GetAsync($"https://localhost:5001/VetDoctor/{register.Email}");
            var responseMessage = await doc.Content.ReadAsStringAsync();
            var responseDeserialized = JsonConvert.DeserializeObject<GetUserResponse>(responseMessage);

            var id = responseDeserialized!.Id.ToString();
            var responseDelete = await client.DeleteAsync($"https://localhost:5001/VetDoctor/delete-vet/{id}");


            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseMessage, Is.Not.Null);
                Assert.That(responseDelete, Is.Not.Null);
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        private async Task<string> LoginVet()
        {
            var clientLogin = GetClient();

            var expected = new LoginRequest
            {
                Email = "doctor.test@test.com",
                Password = "string12"
            };

            var json = JsonContent.Create(expected);
            var responseLogin = await clientLogin.PostAsync("https://localhost:5001/Authenticate/login", json);
            var responseMessage = await responseLogin.Content.ReadAsStringAsync();
            var responseDeserialized = JsonConvert.DeserializeObject<LoginResponse>(responseMessage);

            return responseDeserialized!.Token!;
        }

        [Test]
        public async Task Should_Update_VetDoctor()
        {
            var updateVetDoctorModel = new UpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.com",
                Password = "test11",
                PasswordConfirm = "test11"
            };
            var json = JsonContent.Create(updateVetDoctorModel);
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PutAsync("/VetDoctor/update", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_Not_Update_VetDoctor()
        {
            var updateVetDoctorModel = new UpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.com",
                Password = "test11",
                PasswordConfirm = "test12"
            };
            var json = JsonContent.Create(updateVetDoctorModel);
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PutAsync("/VetDoctor/update", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
    }
}