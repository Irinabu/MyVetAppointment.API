using System.Net;
using MyVetAppointment.IntegrationTests.Config;
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
}