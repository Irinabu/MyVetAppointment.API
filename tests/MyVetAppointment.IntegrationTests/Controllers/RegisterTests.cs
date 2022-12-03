using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Controllers;

[TestFixture]
public class RegisterTests : CustomBaseTest
{
    [Test]
    public async Task Should_RegisterVetDoctor()
    {
        //Arrange
        var expected = new RegisterRequest
        {
            Email = "doctor3.test@gmail.com",
            FirstName = "DoctorTest",
            LastName = "DoctorTest",
            Password = "PasswordTest",
            PasswordConfirm = "PasswordTest",
        };


        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/register-vet-doctor", json);
        var responseMessage = await response.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<RegisterResponse>(responseMessage);

        Console.WriteLine();

        //Assert
        Assert.IsNotNull(responseDeserialized);
        Assert.AreEqual("VetDoctor", responseDeserialized.Role);
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
            PasswordConfirm = "PasswordTest",
        };

        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/register-vet-doctor", json);
        var responseMessage = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.IsNotNull(responseMessage);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }
}