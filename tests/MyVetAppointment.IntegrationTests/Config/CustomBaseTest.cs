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
}