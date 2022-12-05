using MyVetAppointment.IntegrationTests.Config;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Net;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.IntegrationTests.Controllers;

[TestFixture]
public class BillTests : CustomBaseTest
{
    [Test]
    public async Task Should_PostBill()
    {
        //Arrange
        var id = await AddAppointment();

        var bill = new Bill()
        {
            Diagnose = "test",
            PrescriptionDrugs = new List<PrescriptionDrug>()
        };

        var json = JsonContent.Create(bill);
        var client = GetClient();
        var token = await LoginVetDoctor();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //Act
        var response = await client.PostAsync("/Bill/" + id, json);

        //Assert
        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public async Task Should_NOT_PostBill()
    {
        var bill = new Bill()
        {
            Diagnose = "test",
            PrescriptionDrugs = new List<PrescriptionDrug>()
        };

        var json = JsonContent.Create(bill);
        var client = GetClient();
        var token = await LoginVetDoctor();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //Act
        var response = await client.PostAsync("/Bill/1", json);

        //Assert
        Assert.IsNotNull(response);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}