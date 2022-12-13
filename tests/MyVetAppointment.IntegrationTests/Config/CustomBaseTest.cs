using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Json;

namespace MyVetAppointment.IntegrationTests.Config;

public class CustomBaseTest
{
    private readonly CustomWebApplicationFactory _webApplicationFactory;

    public CustomBaseTest()
    {
        ExternalServicesMock = new ExternalServicesMock();
        _webApplicationFactory = new CustomWebApplicationFactory(ExternalServicesMock);
    }

    public ExternalServicesMock ExternalServicesMock { get; }

    public HttpClient GetClient()
    {
        return _webApplicationFactory.CreateDefaultClient();
    }

    public async Task<string> LoginCustomer()
    {
        var clientLogin = GetClient();

        var expected = new LoginRequest
        {
            Email = "customer.test@test.com",
            Password = "string11"
        };

        var json = JsonContent.Create(expected);
        var responseLogin = await clientLogin.PostAsync("https://localhost:5001/Authenticate/login", json);
        var responseMessage = await responseLogin.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<LoginResponse>(responseMessage);

        return responseDeserialized!.Token!;
    }

    public async Task<string> LoginVetDoctor()
    {
        var clientLogin = GetClient();

        var expected = new LoginRequest
        {
            Email = "doctor.test@test.com",
            Password = "string12"
        };

        var json = JsonContent.Create(expected);
        var responseLogin = await clientLogin.PostAsync("https://localhost:5001/Authenticate/login", json);
        var responseMessage = await responseLogin.Content.ReadAsStringAsync();
        var responseDeserialized = JsonConvert.DeserializeObject<LoginResponse>(responseMessage);

        return responseDeserialized!.Token!;
    }

    public async Task<Guid> AddAppointment()
    {
        var appointment = new AppointmentRequest()
        {
            DateTime = DateTime.MaxValue,
            Description =
                "Test appointment ...",
            Title = "Test Appointment",
            FirstName = "Doctor",
            LastName = "Test,parola:string12"
        };

        var json = JsonContent.Create(appointment);
        var client = GetClient();
        var token = await LoginCustomer();
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var response = await client.PostAsync("/Appointment", json);
        dynamic appointmentResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
        return appointmentResponse.id;
    }

    public async Task<Guid> AddBill()
    {
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

        var response = await client.PostAsync("/Bill/" + id, json);
        dynamic billResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
        return billResponse.id;
    }

    public async Task<Guid> AddDrug()
    {
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
        dynamic drugResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
        return drugResponse.id;
    }
}