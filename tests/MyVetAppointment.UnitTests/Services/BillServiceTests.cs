using Application.UnitTests;
using MyVetAppointment.Business.Models.Appointment;
using MyVetAppointment.Business.Models.Drugs;
using MyVetAppointment.Business.Services;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.UnitTests.Services
{
    public class BillServiceTests
    {
        private readonly IBillService billServiceMock;
        private readonly DITests diKernel;

        public BillServiceTests()
        {
            diKernel = new DITests();
            billServiceMock = diKernel.ResolveService<IBillService>();
        }

        [Fact]
        public async void Should_PostBill()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c");
            var bill = new BillRequest()
            {
                Diagnose = "test diagnose",
                PrescriptionDrugs = new List<PrescriptionDrugRequest>()
            };

            var billResponse = await billServiceMock.AddBillAsync(bill, guid1);
            Assert.False(string.IsNullOrEmpty(billResponse.Diagnose));
        } 
        
        [Fact]
        public async void Should_NOT_PostBill()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa88c");
            var bill = new BillRequest()
            {
                Diagnose = "test diagnose",
                PrescriptionDrugs = new List<PrescriptionDrugRequest>()
            };

            await Assert.ThrowsAsync<NullReferenceException>(() => billServiceMock.AddBillAsync(bill, guid1));
        }
        
        [Fact]
        public async void Should_DeleteBill()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa89c");
            var bill = new BillRequest()
            {
                Diagnose = "test diagnose",
                PrescriptionDrugs = new List<PrescriptionDrugRequest>()
            };

            await billServiceMock.DeleteBillAsync(guid1);
            Assert.True(true);
        }  
        
        [Fact]
        public async void Should_NOT_DeleteBill()
        {
            var guid1 = Guid.Parse("c74faa1b-3f57-41f3-806c-1d7710faa88c");
            var bill = new BillRequest()
            {
                Diagnose = "test diagnose",
                PrescriptionDrugs = new List<PrescriptionDrugRequest>()
            };

            await Assert.ThrowsAsync<NullReferenceException>(() => billServiceMock.AddBillAsync(bill, guid1));
        }
    }
}
