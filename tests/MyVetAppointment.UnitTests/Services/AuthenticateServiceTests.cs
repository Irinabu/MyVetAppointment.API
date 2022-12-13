using Application.UnitTests;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Exceptions;

namespace MyVetAppointment.UnitTests.Services;

public class AuthenticateServiceTests
{
    private readonly IAuthenticateService authenticateServiceMock;
    private readonly DITests diKernel;

    public AuthenticateServiceTests()
    {
        diKernel = new DITests();
        authenticateServiceMock = diKernel.ResolveService<IAuthenticateService>();
    }


    [Fact]
    public async Task Login_Should_Return_Token()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = "test@test.com",
            Password = "string12"
        };

        //ACT
        var loginResponse = await loginService.LoginAsync(loginRequest);

        //ASSERT
        Assert.False(string.IsNullOrEmpty(loginResponse.Token));
    }

    [Fact]
    public async Task Login_Should_Return_Error()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = "test@test.com",
            Password = "string123"
        };

        //ACT

        await Assert.ThrowsAsync<BadRequestException>(() => authenticateServiceMock.LoginAsync(loginRequest));
        //ASSERT
    }

    [Fact]
    public async Task Login_Should_Fail_With_Null_Email()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = null,
            Password = "string123"
        };

        //ACT

        await Assert.ThrowsAsync<BadRequestException>(() => authenticateServiceMock.LoginAsync(loginRequest));
        //ASSERT
    }
}