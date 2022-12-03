using Application.UnitTests;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.UnitTests.Services;

internal class CustomerServiceTests
{
    private readonly ICustomerService customerService;
    private readonly DITests diKernel;

    public CustomerServiceTests()
    {
        diKernel = new DITests();
        customerService = diKernel.ResolveService<ICustomerService>();
    }
}