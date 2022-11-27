using Application.UnitTests;
using Moq;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Business.Services.Implementations;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.UnitTests.Config;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace MyVetAppointment.UnitTests.Services;

public class AuthenticateServiceTests
{
    private readonly DITests diKernel;
    private readonly IAuthenticateService authenticateServiceMock;
    
    public AuthenticateServiceTests()
    {
        diKernel = new DITests();
        authenticateServiceMock= diKernel.ResolveService<IAuthenticateService>();
    }


 

    [Fact]
    public async void Login_Should_Return_Token()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = "test@test.com",
            Password = "string12",
        };

        //ACT
        var loginResponse = await loginService.LoginAsync(loginRequest);

        //ASSERT
        Assert.False(string.IsNullOrEmpty(loginResponse.Token));
    }
    [Fact]
    public async void Login_Should_Return_Error()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = "test@test.com",
            Password = "string123",
        };

        //ACT

        await Assert.ThrowsAsync<Exception>(() => authenticateServiceMock.LoginAsync(loginRequest));
        //ASSERT
    }

}