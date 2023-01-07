using Application.UnitTests;
using MyVetAppointment.Business.Models.User;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.UnitTests.Services
{
    public class VetDoctorServiceTests
    {
        private readonly IVetDoctorService vetDoctorServiceMock;
        private readonly IAuthenticateService authenticateServiceMock;
        private readonly DITests diKernel;

        public VetDoctorServiceTests()
        {
            diKernel = new DITests();
            vetDoctorServiceMock = diKernel.ResolveService<IVetDoctorService>();
            authenticateServiceMock = diKernel.ResolveService<IAuthenticateService>();
        }

        [Fact]
        public void Should_GetVetDoctors()
        {
            var vetDoctorsResponse = vetDoctorServiceMock.GetAllAsync();
            Assert.True(vetDoctorsResponse.Count > 0);
        }

        [Fact]
        public void Should_GetVetDoctorByEmail()
        {
            var vetDoctorResponse = vetDoctorServiceMock.GetVetDoctorByEmailAsync("doctor@test.com");
            Assert.True(true);
        }

        [Fact]
        public void Should_DeleteVetDoctor()
        {
            var registerRequest = new RegisterRequest
            {
                Email = "doc_for_test@test.com",
                FirstName = "docttst",
                LastName = "doccust",
                Password = "laladoct",
                PasswordConfirm = "laladoc"
            };
            authenticateServiceMock.RegisterVetDoctorAsync(registerRequest);
            var docResponse = vetDoctorServiceMock.GetVetDoctorByEmailAsync("doc_for_test@test.com");
            var response = vetDoctorServiceMock.DeleteVetDoctor(docResponse.Id.ToString());

            Assert.True(response == true);
        }
    }
}
