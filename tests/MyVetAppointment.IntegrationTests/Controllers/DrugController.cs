using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.IntegrationTests.Config;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Controllers
{
    [TestFixture]
    public class DrugTests : CustomBaseTest
    {
        [Test]
        public async Task Should_PostDrug()
        {
            //Arrange
            var drug = new Drug
            {
                Name = "Paracetamol",
                TotalQuantity = 50
            };

            var json = JsonContent.Create(drug);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PostAsync("/Drug", json);
         
            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task Should_NOT_PostDrug()
        {
            //Arrange
            var drug = new Drug
            {
                Name = "Paracetamol",
                TotalQuantity = 50
            };

            var json = JsonContent.Create(drug);
            var client = GetClient();
            var response = await client.PostAsync("/Drug", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
    }
}
