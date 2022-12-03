﻿using System.Net;
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
        Random random = new Random();
        var expected = new RegisterRequest
        {
            Email = "doctor" + random.Next() + ".test@gmail.com",
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
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public async Task Should_NOT_RegisterVetDoctor()
    {
        //Arrange
        var expected = new RegisterRequest
        {
            Email = "doctor1.test@gmail.com",
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

    [Test]
    public async Task Should_RegisterCustomer()
    {
        //Arrange
        Random random = new Random();
        var expected = new RegisterRequest
        {
            Email = "cust" + random.Next() + ".test@gmail.com",
            FirstName = "custTest",
            LastName = "custTest",
            Password = "PasswordTest",
            PasswordConfirm = "PasswordTest",
        };


        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/register-customer", json);
        var responseMessage = await response.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<RegisterResponse>(responseMessage);

        Console.WriteLine();

        //Assert
        Assert.IsNotNull(responseDeserialized);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public async Task Should_NOT_RegisterCustomer()
    {
        //Arrange
        var expected = new RegisterRequest
        {
            Email = "cust1.test@gmail.com",
            FirstName = "custTest",
            LastName = "custTest",
            Password = "PasswordTest",
            PasswordConfirm = "PasswordTest",
        };

        var json = JsonContent.Create(expected);
        var client = GetClient();

        //Act
        var response = await client.PostAsync("https://localhost:5001/Authenticate/register-customer", json);
        var responseMessage = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.IsNotNull(responseMessage);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }
}