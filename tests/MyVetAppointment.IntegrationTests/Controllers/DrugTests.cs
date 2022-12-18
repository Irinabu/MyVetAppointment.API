using System.Net;
using System.Net.Http.Json;
using Azure;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;
using MyVetAppointment.IntegrationTests.Config;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Controllers
{
    [TestFixture]
    public class DrugTests : CustomBaseTest
    {
        [Test]
        public async Task Should_GetDrugs()
        {
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.GetAsync("/Drug");

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_NOT_GetDrugs()
        {
            //Arrange
            var client = GetClient();
            // var token = await LoginCustomer();
            // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.GetAsync("/Drug");

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }
        [Test]
        public async Task Should_PostDrug()
        {
            //Arrange
            var drug = new Drug
            {
                Name = "Paracetamol",
                TotalQuantity = 50,
                Price = 5,
                ExpirationDate = DateTime.MaxValue

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

        [Test]
        public async Task Should_DeleteDrug()
        {
            var id = await AddDrug();

            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.DeleteAsync("/Drug/" + id);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public async Task Should_NOT_DeleteDrug()
        {
            var id = await AddDrug();

            var client = GetClient();
            // var token = await LoginCustomer();
            // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //Act
            var response = await client.DeleteAsync("/Bill/" + id);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task Should_UpdateDrug()
        {
            //Arrange
            var id = await AddDrug();
        
            var drugUpdated = new DrugRequest()
            {
                Name = "Paracetamol",
                TotalQuantity = 50,
                Price = 5,
                ExpirationDate = DateTime.MaxValue
            };
        
            var json = JsonContent.Create(drugUpdated);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        
            //Act
            var responseUpdate = await client.PutAsync("/Drug?id=" + id, json);

            //Assert
            Assert.That(responseUpdate, Is.Not.Null);

            Assert.That(responseUpdate.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Test]
        public async Task Should_NOT_UpdateDrug()
        {
            //Arrange
            var id = await AddDrug();

            var drugUpdated = new DrugRequest()
            {
                Name = "Paracetamol",
                TotalQuantity = 50,
                Price = 5,
                ExpirationDate = DateTime.MaxValue
            };

            var json = JsonContent.Create(drugUpdated);
            var client = GetClient();
            var token = await LoginVetDoctor();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        
            //Act
            var response = await client.PutAsync("/Drug?id=" + new Guid(), json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    }
}
