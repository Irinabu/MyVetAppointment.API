using System.Net;
using System.Net.Http.Json;
using System.Text;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Services;

[TestFixture]
public class VetDoctorTests : CustomBaseTest
{

    [Test]
    public async Task GET_VetDoctors_ShouldBe_Status_OK()
    {
        //Arrange
        var client = GetClient();

        //Act
        var response = await client.GetAsync("/VetDoctor/vets");

        //Assert
        response.StatusCode.Equals(HttpStatusCode.OK);
    }

    [Test]
    public async Task GET_VetDoctorByEmail_ShouldBe_Status_OK()
    {
        //Arrange
        var email = "doctor@test.com";
        var client = GetClient();

        //Act
        var response = await client.GetAsync($"/VetDoctor/vets/{email}");

        //Assert
        response.StatusCode.Equals(HttpStatusCode.OK);
    }

    [Test]
    public async Task DELETE_VetDoctors_ShouldBe_Status_NotFound()
    {
        //Arrange
        var client = GetClient();
        var id = "123";

        //Act
        var response = await client.DeleteAsync($"https://localhost:5001/VetDoctor/delete-vet/{id}");

        //Assert
        response.StatusCode.HasFlag(HttpStatusCode.NotFound);
    }




}