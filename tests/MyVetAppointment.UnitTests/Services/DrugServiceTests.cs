using Application.UnitTests;
using MyVetAppointment.Business.Services;

namespace MyVetAppointment.UnitTests.Services
{
    public class DrugServiceTests
    {
        private readonly IDrugService drugServiceMock;
        private readonly DITests diKernel;

        public DrugServiceTests()
        {
            diKernel = new DITests();
            drugServiceMock = diKernel.ResolveService<IDrugService>();
        }

        // [Fact]
        // public async void Should_PostDrug()
        // {
        //     var drugService = diKernel.ResolveService<IDrugService>();
        //
        //     var drug = new DrugRequest()
        //     {
        //         Name = "Paracetamol",
        //         TotalQuantity = 50
        //     };
        //
        //     var drugResponse = await drugService.AddDrugAsync(drug);
        //     Assert.False(string.IsNullOrEmpty(drugResponse.Name));
        // }
    }
}
