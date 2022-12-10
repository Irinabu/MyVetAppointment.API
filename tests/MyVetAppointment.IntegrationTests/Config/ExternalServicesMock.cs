using System.Reflection;
using Moq;

namespace MyVetAppointment.IntegrationTests.Config;

public class ExternalServicesMock
{
    //public Mock<IAuthenticateService> _authenticateService { get; }
    //public Mock<IUserRepository> _userRepository { get; }

    public IEnumerable<(Type, object)> GetMocks()
    {
        return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(x =>
            {
                var underlyingType = x.PropertyType.GetGenericArguments()[0];
                var value = x.GetValue(this) as Mock;

                return (underlyingType, value!.Object);
            })
            .ToArray();
    }
}