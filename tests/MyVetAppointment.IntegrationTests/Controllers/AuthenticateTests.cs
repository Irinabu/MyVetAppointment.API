using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Services;

[TestFixture]
public class AuthenticateTests : CustomBaseTest
{
    [Test]
    public async Task Should_LoginVetDoctor()
    {
        //Arrange
        var expected = new LoginRequest
        {
            Email = "doctor.test@test.com",
            Password = "string12"
        };

        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/login", json);
        var responseMessage = await response.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<LoginResponse>(responseMessage);

        //Assert
        Assert.IsNotNull(responseDeserialized);
        Assert.IsNotNull(responseDeserialized.Token);
        Assert.AreEqual("VetDoctor", responseDeserialized.Role);
    }

    [Test]
    public async Task Should_NOT_LoginVetDoctor()
    {
        //Arrange
        var expected = new LoginRequest
        {
            Email = "doctor.test@test.com",
            Password = "string1"
        };

        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/login", json);
        var responseMessage = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.IsNotNull(responseMessage);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }
}