using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Services;

[TestFixture]
public class CustomerTests : CustomBaseTest
{
    [Test]
    public async Task GET_Customers_ShouldBe_Status_OK()
    {
        //Arrange
        var client = GetClient();
        var token = await LoginCustomer();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        Console.WriteLine("Token: " + token);

        //Act
        var response = await client.GetAsync("/Customer/customers");

        //Assert
        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GET_CustomerByEmail_ShouldBe_Status_OK()
    {
        //Arrange
        var email = "customer.test@test.com";
        var client = GetClient();
        var token = await LoginCustomer();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //Act
        var response = await client.GetAsync($"/Customer/{email}");

        //Assert
        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task DELETE_Customer_ShouldBe_Status_NotFound()
    {
        //Arrange
        var client = GetClient();
        var id = "123";
        var token = await LoginCustomer();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //Act
        var response = await client.DeleteAsync($"Customer/delete-customer/{id}");

        //Assert
        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }


    [Test]
    public async Task DELETE_Customer_ShouldBe_Status_OK()
    {
        //Arrange
        var register = new RegisterRequest
        {
            Email = "proba2Customer@test.com",
            FirstName = "Proba",
            LastName = "string",
            Password = "string",
            PasswordConfirm = "string"
        };

        var json = JsonContent.Create(register);
        var client = GetClient();
        var token = await LoginCustomer();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


        //Act
        await client.PostAsync("https://localhost:5001/Authenticate/register-customer", json);
        var customer = await client.GetAsync($"https://localhost:5001/Customer/{register.Email}");
        var responseMessage = await customer.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<GetUserResponse>(responseMessage);

        var id = responseDeserialized.Id.ToString();
        var responseDelete = await client.DeleteAsync($"https://localhost:5001/Customer/delete-customer/{id}");


        //Assert
        Assert.IsNotNull(responseMessage);
        Assert.IsNotNull(responseDelete);
        Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

}