using Moq;
using MyVetAppointment.Data.Entities;
using MyVetAppointment.Data.Repositories;

namespace MyVetAppointment.UnitTests.Repositories;

public class BaseRepositoryTests
{

    [Fact]
    public void GetAllAsync_Should_Return_Not_Empty_List()
    {
        var cId = new Guid("1d044320-3de7-43b2-9fdc-a91388038034");
        var bookInMemoryDatabase = new List<Customer>
        {
            new Customer() {Id=new Guid("1d044320-3de7-43b2-9fdc-a91388038034"), FirstName="Vasile", LastName="Va", Email="vasile@test.com"},
        };
        var repository = new Mock<IBaseRepository<Customer>>();
        repository.Setup(c => c.GetAllAsync(x => true).Result).Returns(bookInMemoryDatabase);

        Assert.NotNull(repository.Object.GetAllAsync(x => true));
    }

    [Fact]
    public void GetAllAsync_Should_Return_Empty_List()
    {
        var cId = new Guid("1d044320-3de7-43b2-9fdc-a91388038034");
        var bookInMemoryDatabase = new List<Customer>
        {
           
        };
        var repository = new Mock<IBaseRepository<Customer>>();
        repository.Setup(c => c.GetAllAsync(x => true).Result).Returns(bookInMemoryDatabase);

        Assert.Empty(repository.Object.GetAllAsync(x => true).Result);
    }
}