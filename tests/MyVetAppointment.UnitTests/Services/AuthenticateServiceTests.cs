using Application.UnitTests;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

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
    [Fact]
    public async void Login_Should_Fail_With_Null_Email()
    {
        //ARRANGE
        var loginService = diKernel.ResolveService<IAuthenticateService>();

        var loginRequest = new LoginRequest
        {
            Email = null,
            Password = "string123",
        };

        //ACT

        await Assert.ThrowsAsync<Exception>(() => authenticateServiceMock.LoginAsync(loginRequest));
        //ASSERT
    }

}