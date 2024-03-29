﻿using System.Net;
using System.Net.Http.Json;
using MyVetAppointment.Business.Models;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Enums;
using MyVetAppointment.IntegrationTests.Config;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyVetAppointment.IntegrationTests.Services
{

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
            Assert.That(response, Is.Not.Null);
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
            Assert.That(response, Is.Not.Null);
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
            Assert.That(response, Is.Not.Null);
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

            var id = responseDeserialized!.Id.ToString();
            var responseDelete = await client.DeleteAsync($"https://localhost:5001/Customer/delete-customer/{id}");


            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseMessage, Is.Not.Null);
                Assert.That(responseDelete, Is.Not.Null);
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        [Test]
        public async Task Should_PostAnimal()
        {
            //Arrange
            var animal = new Animal
            {
                Name = "Azorel",
                AnimalType = AnimalType.Cat
            };

            var json = JsonContent.Create(animal);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PostAsync("/Customer/add-animal", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task Should_Update_Customer()
        {
            var updateCustomerModel = new UpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.com",
                Password = "test11",
                PasswordConfirm = "test11"
            };
            var json = JsonContent.Create(updateCustomerModel);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PutAsync("/Customer/update", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Should_Not_Update_Customer()
        {
            var updateCustomerModel = new UpdateUserRequest
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.com",
                Password = "test11",
                PasswordConfirm = "test12"
            };
            var json = JsonContent.Create(updateCustomerModel);
            var client = GetClient();
            var token = await LoginCustomer();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await client.PutAsync("/Customer/update", json);

            //Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }


        // [Test]
        // public async Task Should_NOT_PostAnimal()
        // {
        //     //Arrange
        //     var animal = new Animal
        //     {
        //         Name = "Azorel",
        //         AnimalType = AnimalType.Cat
        //     };
        //
        //     var json = JsonContent.Create(animal);
        //     var client = GetClient();
        //     var token = await LoginVetDoctor();
        //     client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //     var response = await client.PostAsync("/Customer/add-animal", json);
        //
        //     //Assert
        //     Assert.That(response, Is.Not.Null);
        //     Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        // }

    }
}